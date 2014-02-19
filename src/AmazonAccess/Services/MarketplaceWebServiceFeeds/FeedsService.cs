using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using AmazonAccess.Misc;
using AmazonAccess.Services.MarketplaceWebServiceFeeds.Model;
using MarketplaceWebService;

namespace AmazonAccess.Services.MarketplaceWebServiceFeeds
{
	public class FeedsService
	{
		public void SubmitFeed( IMarketplaceWebService client, SubmitFeedRequest request )
		{
			var response = client.SubmitFeed( request );
			
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
			ActionPolicies.CreateApiDelay( 2 ).Wait();

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