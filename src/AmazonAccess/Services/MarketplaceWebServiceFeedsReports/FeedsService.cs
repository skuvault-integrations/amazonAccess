using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml.Serialization;
using AmazonAccess.Misc;
using AmazonAccess.Services.MarketplaceWebServiceFeedsReports.Model;
using AmazonEnvelope = AmazonAccess.Services.MarketplaceWebServiceFeedsReports.ReportModel.AmazonEnvelope;

namespace AmazonAccess.Services.MarketplaceWebServiceFeedsReports
{
	public class FeedsService
	{
		private readonly IMarketplaceWebServiceFeedsReports _client;

		public FeedsService( IMarketplaceWebServiceFeedsReports client )
		{
			this._client = client;
		}

		public void SubmitFeed( SubmitFeedRequest request )
		{
			var response = this._client.SubmitFeed( request );
			if( !response.IsSetSubmitFeedResult() )
				throw new Exception( string.Format( "[amazon] SubmitFeed. Seller: {0}\nResult was not received", request.Merchant ) );

			var feedSubmissionId = response.SubmitFeedResult.FeedSubmissionInfo.FeedSubmissionId;
			while( !this.IsFeedSubmitted( this._client, feedSubmissionId, request.Merchant, request.MWSAuthToken ) )
				Thread.Sleep( TimeSpan.FromMinutes( 1 ) );

			this.CheckSubmissionResult( feedSubmissionId, request.Merchant, request.MWSAuthToken );
		}

		private bool IsFeedSubmitted( IMarketplaceWebServiceFeedsReports client, string feedSubmissionId, string merchant, string mwsAuthToken )
		{
			var response = client.GetFeedSubmissionList( new GetFeedSubmissionListRequest
			{
				FeedSubmissionIdList = new IdList { Id = new List< string > { feedSubmissionId } },
				Merchant = merchant,
				MWSAuthToken = mwsAuthToken
			} );
			ActionPolicies.CreateApiDelay( 2 ).Wait();

			if( !response.IsSetGetFeedSubmissionListResult() )
				throw new Exception( string.Format( "[amazon] GetFeedSubmissionList. Seller: {0}\nResult was not received", merchant ) );

			var info = response.GetFeedSubmissionListResult.FeedSubmissionInfo.FirstOrDefault( i => i.FeedSubmissionId.Equals( feedSubmissionId ) );
			if( info == null )
				throw new Exception( string.Format( "[amazon] GetFeedSubmissionList. Seller: {0}\nSubmissionId was not found", merchant ) );
			if( info.FeedProcessingStatus.Equals( "_CANCELLED_" ) )
				throw new Exception( string.Format( "[amazon] GetFeedSubmissionList. Seller: {0}\nThe request has been aborted due to a fatal error", merchant ) );

			return info.FeedProcessingStatus.Equals( "_DONE_" );
		}

		private void CheckSubmissionResult( string feedSubmissionId, string merchant, string mwsAuthToken )
		{
			var request = new GetFeedSubmissionResultRequest
			{
				FeedSubmissionId = feedSubmissionId,
				Merchant = merchant,
				MWSAuthToken = mwsAuthToken,
				FeedSubmissionResult = new MemoryStream()
			};
			var response = this._client.GetFeedSubmissionResult( request );
			ActionPolicies.CreateApiDelay( 2 ).Wait();

			if( !response.IsSetGetFeedSubmissionResultResult() || request.FeedSubmissionResult == null )
				throw new Exception( string.Format( "[amazon] GetFeedSubmissionResult. Seller: {0}\nResult was not received", merchant ) );

			var reader = new StreamReader( request.FeedSubmissionResult, Encoding.UTF8 );
			bool isErrorExist;
			try
			{
				var serlizer = new XmlSerializer( typeof( AmazonEnvelope ) );
				var envelope = ( AmazonEnvelope )serlizer.Deserialize( reader );
				isErrorExist = envelope.Message.Any( x => x.ProcessingReport.ProcessingSummary.MessagesWithError > 0 );
			}
			catch( Exception ex )
			{
				AmazonLogger.Log.Error( ex, "[amazon] GetFeedSubmissionResult. Seller: {0}. Can not parse result", merchant );
				return;
			}

			if( isErrorExist )
				throw new Exception( string.Format( "[amazon] GetFeedSubmissionResult. Seller: {0}\nFeed was not submitted: {1}", merchant, reader.ReadToEnd() ) );
		}
	}
}