using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using AmazonAccess.Services.MarketplaceWebServiceFeeds.Model;
using MarketplaceWebService;
using Netco.Logging;

namespace AmazonAccess.Services.MarketplaceWebServiceFeeds
{
	public class FeedsService
	{
		public void SubmitFeed( IMarketplaceWebService client, SubmitFeedRequest request )
		{
			var response = client.SubmitFeed( request );
			try
			{
				if( response.IsSetSubmitFeedResult() )
				{
					var feedSubmissionId = response.SubmitFeedResult.FeedSubmissionInfo.FeedSubmissionId;
					while( !this.IsReportReady( client, feedSubmissionId, request.Merchant ) )
					{
						//waiting for the report
						Thread.Sleep( TimeSpan.FromMinutes( 1 ) );
					}
					//this.GetReport( client, feedSubmissionId,request.Merchant );
				}
			}
			catch( MarketplaceWebServiceException ex )
			{
				this.Log().Info( string.Concat( "Caught Exception: ", ex.Message ) );
				this.Log().Info( string.Concat( "Response Status Code: ", ex.StatusCode ) );
				this.Log().Info( string.Concat( "Error Code: ", ex.ErrorCode ) );
				this.Log().Info( string.Concat( "Error Type: ", ex.ErrorType ) );
				this.Log().Info( string.Concat( "Request ID: ", ex.RequestId ) );
			}
		}

		//private void GetReport( IMarketplaceWebService client, string feedSubmissionId,string merchant )
		//{
		//	var response = client.GetFeedSubmissionResult( new GetFeedSubmissionResultRequest
		//		{
		//			FeedSubmissionId = feedSubmissionId,
		//			Merchant = merchant
		//		} );

		//}

		private bool IsReportReady( IMarketplaceWebService client, string feedSubmissionId, string merchant )
		{
			var ready = false;
			var response = client.GetFeedSubmissionList( new GetFeedSubmissionListRequest
				{
					FeedSubmissionIdList = new IdList { Id = new List< string > { feedSubmissionId } },
					Merchant = merchant
				} );
			if( response.IsSetGetFeedSubmissionListResult() )
			{
				var info = response.GetFeedSubmissionListResult.FeedSubmissionInfo.FirstOrDefault( i => i.FeedSubmissionId.Equals( feedSubmissionId ) );
				if( info != null )
					ready = info.FeedProcessingStatus.Equals( "_DONE_" );
			}
			return ready;
		}
	}
}