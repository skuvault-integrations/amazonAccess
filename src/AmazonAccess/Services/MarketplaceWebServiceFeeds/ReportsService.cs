using System;
using System.Collections.Generic;
using System.Linq;
using AmazonAccess.Models;
using MarketplaceWebService.Model;

namespace AmazonAccess.Services.MarketplaceWebServiceFeeds
{
	public class ReportsService
	{
		public void GetInventoryReport( IMarketplaceWebServiceFeeds client )
		{

			var reportId = this.GetReportId( client, new GetReportListRequest
				{
					Merchant = "A7I0VA9RRJTE8",
					AvailableFromDate = DateTime.UtcNow - TimeSpan.FromDays( 1 ),
					AvailableToDate = DateTime.UtcNow
				} );
			var response = client.GetReport( new GetReportRequest { ReportId = reportId } );

			if( response.IsSetGetReportResult() )
			{
				var report = response.GetReportResult.ToXMLFragment();
			}
		}

		private string GetReportId( IMarketplaceWebServiceFeeds client, GetReportListRequest request )
		{
			var reportRequestId = this.GetReportRequestId( client, new RequestReportRequest
				{
					MarketplaceIdList = new IdList { Id = new List< string > { "ATVPDKIKX0DER" } },
					ReportType = ReportType.Inventory.Description,
					Merchant = "A7I0VA9RRJTE8",
					StartDate = DateTime.MinValue.ToUniversalTime(),
					EndDate = DateTime.UtcNow
				} );
			var reportId = this.GetGeneratedReportId( client, reportRequestId );
			var reportListResponse = client.GetReportList( request );

			if( reportListResponse.IsSetGetReportListResult() && string.IsNullOrEmpty( reportId ) )
			{
				var reportListResult = reportListResponse.GetReportListResult;
				if( reportListResult.IsSetReportInfo() )
				{
					var reportInfo = reportListResult.ReportInfo.FirstOrDefault( r => r.ReportRequestId.Equals( reportRequestId ) );
					if( reportInfo != null )
						reportId = reportInfo.ReportId;
					else if( reportListResult.IsSetNextToken() )
					{
						var nextResponse = client.GetReportListByNextToken( new GetReportListByNextTokenRequest
							{
								Merchant = "A7I0VA9RRJTE8",
								NextToken = reportListResult.NextToken
							} );

						reportId = this.GetReportIdInNextPages( nextResponse.GetReportListByNextTokenResult, client, reportRequestId, reportId );
					}
				}
			}
			return reportId;
		}

		private string GetReportIdInNextPages( GetReportListByNextTokenResult reportListByNextTokenResult, IMarketplaceWebServiceFeeds client, string reportRequestId, string reportId )
		{
			if( !string.IsNullOrEmpty( reportId ) )
				return reportId;

			if( reportListByNextTokenResult.IsSetReportInfo() )
			{
				var reportInfo = reportListByNextTokenResult.ReportInfo.FirstOrDefault( r => r.ReportRequestId.Equals( reportRequestId ) );
				if( reportInfo != null )
					reportId = reportInfo.ReportId;
			}
			if( reportListByNextTokenResult.IsSetNextToken() && string.IsNullOrEmpty( reportId ) )
			{
				var nextResponse = client.GetReportListByNextToken( new GetReportListByNextTokenRequest
					{
						Merchant = "A7I0VA9RRJTE8",
						NextToken = reportListByNextTokenResult.NextToken
					} );

				reportId = this.GetReportIdInNextPages( nextResponse.GetReportListByNextTokenResult, client, reportRequestId, reportId );
			}
			return reportId;
		}

		private string GetGeneratedReportId( IMarketplaceWebServiceFeeds client, string reportRequestId )
		{
			var reportId = string.Empty;
			var response = client.GetReportRequestList( new GetReportRequestListRequest
				{
					Merchant = "A7I0VA9RRJTE8",
					ReportRequestIdList = new IdList { Id = new List< string > { reportRequestId } },
					RequestedFromDate = DateTime.MinValue.ToUniversalTime(),
					RequestedToDate = DateTime.UtcNow
				} );
			var info = response.GetReportRequestListResult.ReportRequestInfo.FirstOrDefault( i => i.ReportRequestId.Equals( reportRequestId ) );
			if( info != null )
				reportId = info.GeneratedReportId;
			else if( response.GetReportRequestListResult.IsSetNextToken() )
			{
				var nextResponse = client.GetReportRequestListByNextToken( new GetReportRequestListByNextTokenRequest
					{
						Merchant = "A7I0VA9RRJTE8",
						NextToken = response.GetReportRequestListResult.NextToken
					} );
				reportId = this.GetGeneratedReportIdFromNextPages( nextResponse.GetReportRequestListByNextTokenResult, client, reportRequestId, reportId );
			}

			return reportId;
		}

		private string GetGeneratedReportIdFromNextPages( GetReportRequestListByNextTokenResult reportRequestListByNextTokenResult, IMarketplaceWebServiceFeeds client, string reportRequestId, string reportId )
		{
			if( !string.IsNullOrEmpty( reportId ) )
				return reportId;

			if( reportRequestListByNextTokenResult.IsSetReportRequestInfo() )
			{
				var info = reportRequestListByNextTokenResult.ReportRequestInfo.FirstOrDefault( i => i.ReportRequestId.Equals( reportRequestId ) );
				if( info != null )
					reportId = info.GeneratedReportId;
			}
			if( reportRequestListByNextTokenResult.IsSetNextToken() && string.IsNullOrEmpty( reportId ) )
			{
				var nextResponse = client.GetReportRequestListByNextToken( new GetReportRequestListByNextTokenRequest
					{
						Merchant = "A7I0VA9RRJTE8",
						NextToken = reportRequestListByNextTokenResult.NextToken
					} );

				reportId = this.GetGeneratedReportIdFromNextPages( nextResponse.GetReportRequestListByNextTokenResult, client, reportRequestId, reportId );
			}
			return reportId;
		}

		private string GetReportRequestId( IMarketplaceWebServiceFeeds client, RequestReportRequest request )
		{
			var reportId = string.Empty;

			var response = client.RequestReport( request );

			if( response.IsSetRequestReportResult() )
				reportId = response.RequestReportResult.ReportRequestInfo.ReportRequestId;

			return reportId;
		}
	}
}