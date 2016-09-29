using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using AmazonAccess.Misc;
using AmazonAccess.Models;
using AmazonAccess.Services.FeedsReports.Model;
using AmazonAccess.Services.FeedsReports.Model.FeedSubmissionResult;
using CuttingEdge.Conditions;

namespace AmazonAccess.Services.FeedsReports
{
	public class FeedsService
	{
		private readonly IFeedsReportsServiceClient _client;
		private readonly AmazonCredentials _credentials;
		private readonly Throttler _submitFeedThrottler = new Throttler( 15, 121 );
		private readonly Throttler _getFeedSubmissionListThrottler = new Throttler( 10, 46 );
		private readonly Throttler _getFeedSubmissionResultThrottler = new Throttler( 15, 61 );

		public FeedsService( IFeedsReportsServiceClient client, AmazonCredentials credentials )
		{
			Condition.Requires( client, "client" ).IsNotNull();
			Condition.Requires( credentials, "credentials" ).IsNotNull();

			this._client = client;
			this._credentials = credentials;
		}

		public void SubmitFeed( string marker, FeedType feedType, string feedContent )
		{
			AmazonLogger.Trace( "SubmitFeed", this._credentials.SellerId, marker, "Begin invoke" );

			var request = new SubmitFeedRequest
			{
				SellerId = this._credentials.SellerId,
				MWSAuthToken = this._credentials.MwsAuthToken,
				MarketplaceId = this._credentials.AmazonMarketplaces.GetMarketplaceIdAsList(),
				FeedType = feedType.Description,
				FeedContent = feedContent,
			};
			var response = ActionPolicies.Get.Get( () => this._submitFeedThrottler.Execute( () => this._client.SubmitFeed( request, marker ) ) );
			if( !response.IsSetSubmitFeedResult() )
				throw AmazonLogger.Error( "SubmitFeed", this._credentials.SellerId, marker, "Result was not received" );

			var feedSubmissionId = response.SubmitFeedResult.FeedSubmissionInfo.FeedSubmissionId;
			this.WaitFeedSubmission( marker, feedSubmissionId );
			this.CheckSubmissionResult( marker, feedSubmissionId );

			AmazonLogger.Trace( "SubmitFeed", this._credentials.SellerId, marker, "End invoke" );
		}

		private void WaitFeedSubmission( string marker, string feedSubmissionId )
		{
			AmazonLogger.Trace( "WaitFeedSubmitting", this._credentials.SellerId, marker, "Begin invoke" );

			var request = new GetFeedSubmissionListRequest
			{
				SellerId = this._credentials.SellerId,
				MWSAuthToken = this._credentials.MwsAuthToken,
				MarketplaceId = this._credentials.AmazonMarketplaces.GetMarketplaceIdAsList(),
				FeedSubmissionIdList = new List< string > { feedSubmissionId }
			};

			ActionPolicies.CreateApiDelay( 140 ).Wait();

			while( true )
			{
				var response = ActionPolicies.Get.Get( () => this._getFeedSubmissionListThrottler.Execute( () => this._client.GetFeedSubmissionList( request, marker ) ) );
				if( !response.IsSetGetFeedSubmissionListResult() )
					throw AmazonLogger.Error( "WaitFeedSubmitting", this._credentials.SellerId, marker, "Result was not received for SubmissionId {0}", feedSubmissionId );

				var info = response.GetFeedSubmissionListResult.FeedSubmissionInfo.FirstOrDefault( i => i.FeedSubmissionId.Equals( feedSubmissionId ) );
				if( info == null )
					throw AmazonLogger.Error( "WaitFeedSubmitting", this._credentials.SellerId, marker, "SubmissionId {0} was not found", feedSubmissionId );
				if( info.FeedProcessingStatus.Equals( "_CANCELLED_" ) )
					throw AmazonLogger.Error( "WaitFeedSubmitting", this._credentials.SellerId, marker, "The request has been aborted due to a fatal error" );

				if( info.FeedProcessingStatus.Equals( "_DONE_" ) )
					break;

				ActionPolicies.CreateApiDelay( 40 ).Wait();
			}
		}

		private void CheckSubmissionResult( string marker, string feedSubmissionId )
		{
			AmazonLogger.Trace( "CheckSubmissionResult", this._credentials.SellerId, marker, "Begin invoke" );

			var request = new GetFeedSubmissionResultRequest
			{
				SellerId = this._credentials.SellerId,
				MWSAuthToken = this._credentials.MwsAuthToken,
				MarketplaceId = this._credentials.AmazonMarketplaces.GetMarketplaceIdAsList(),
				FeedSubmissionId = feedSubmissionId
			};
			var response = ActionPolicies.Get.Get( () => this._getFeedSubmissionResultThrottler.Execute( () => this._client.GetFeedSubmissionResult( request, marker ) ) );
			if( !response.IsSetGetFeedSubmissionResultResult() || !response.GetFeedSubmissionResultResult.IsSetResult() )
				throw AmazonLogger.Error( "CheckSubmissionResult", this._credentials.SellerId, marker, "Result was not received for SubmissionId {0}", feedSubmissionId );

			try
			{
				using( var reader = new StringReader( response.GetFeedSubmissionResultResult.Result ) )
				{
					var serlizer = new XmlSerializer( typeof( FeedSubmissionResult ) );
					var envelope = ( FeedSubmissionResult )serlizer.Deserialize( reader );

					var firstMessage = envelope.Message.First();
					var processingSummary = firstMessage.ProcessingReport.ProcessingSummary ?? ( firstMessage.ProcessingReport.Summary != null ? firstMessage.ProcessingReport.Summary.ProcessingSummary : null );
					if( processingSummary == null )
						AmazonLogger.Warn( "CheckSubmissionResult", this._credentials.SellerId, marker, "ProcessingSummary is null" );
					else
					{
						AmazonLogger.Trace( "CheckSubmissionResult", this._credentials.SellerId, marker, "Processed:{0} Successful:{1} Errors:{2} Warnings:{3}",
							processingSummary.MessagesProcessed, processingSummary.MessagesSuccessful, processingSummary.MessagesWithError, processingSummary.MessagesWithWarning );
					}

					var result = firstMessage.ProcessingReport.Result ?? ( firstMessage.ProcessingReport.Summary != null ? firstMessage.ProcessingReport.Summary.Result : null );
					if( result == null )
					{
						AmazonLogger.Trace( "CheckSubmissionResult", this._credentials.SellerId, marker, "Result is null" );
						return;
					}
					var groupedResults = result.GroupBy( x => x.ResultMessageCode );
					foreach( var groupedResult in groupedResults )
					{
						// 13013 - SKU do not exist in Amazon
						// 5000 - SKU length is too big (max:40)
						var count = groupedResult.Count();
						var type = groupedResult.First().ResultCode;
						AmazonLogger.Warn( "CheckSubmissionResult", this._credentials.SellerId, marker, "Message type: {0}. Message code: {1}. Massages count: {2}",
							type, groupedResult.Key, count );
					}
				}
			}
			catch( Exception ex )
			{
				AmazonLogger.Error( "CheckSubmissionResult", this._credentials.SellerId, marker, ex, "Can not parse result" );
			}
		}
	}
}