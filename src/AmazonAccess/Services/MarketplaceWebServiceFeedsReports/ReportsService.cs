using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using AmazonAccess.Models;
using AmazonAccess.Services.MarketplaceWebServiceFeedsReports.Model;
using LINQtoCSV;

namespace AmazonAccess.Services.MarketplaceWebServiceFeedsReports
{
	public class ReportsService
	{
		private readonly IMarketplaceWebServiceFeedsReports _client;
		private readonly AmazonCredentials _credentials;

		public ReportsService( IMarketplaceWebServiceFeedsReports client, AmazonCredentials credentials )
		{
			this._client = client;
			this._credentials = credentials;
		}

		public IEnumerable< T > GetReport< T >( ReportType reportType, DateTime startDate, DateTime endDate ) where T : class, new()
		{
			var reportRequestId = this.GetReportRequestId( reportType, startDate, endDate );
			var reportId = this.GetNewReportId( reportRequestId );
			if( string.IsNullOrEmpty( reportId ) )
				reportId = this.GetExistingReportId( reportType );
			if( string.IsNullOrEmpty( reportId ) )
				throw new Exception( "Can't request new report or find existing" );

			var reportStream = this.GetReportById( reportId );
			if( reportStream == null )
				throw new Exception( "Can't get report" );

			var report = this.ConvertReport< T >( reportStream );
			return report;
		}

		private string GetReportRequestId( ReportType reportType, DateTime startDate, DateTime endDate )
		{
			var request = new RequestReportRequest
			{
				Merchant = this._credentials.SellerId,
				MWSAuthToken = this._credentials.MwsAuthToken,
				MarketplaceIdList = new IdList { Id = this._credentials.AmazonMarketplaces.GetMarketplaceIdAsList() },
				ReportType = reportType.Description,
				StartDate = startDate,
				EndDate = endDate
			};
			var response = this._client.RequestReport( request );

			var reportId = response.IsSetRequestReportResult() ? response.RequestReportResult.ReportRequestInfo.ReportRequestId : string.Empty;
			return reportId;
		}

		private string GetNewReportId( string reportRequestId )
		{
			var reportId = string.Empty;
			var request = new GetReportRequestListRequest
			{
				Merchant = this._credentials.SellerId,
				MWSAuthToken = this._credentials.MwsAuthToken,
				ReportRequestIdList = new IdList { Id = new List< string > { reportRequestId } },
				RequestedFromDate = DateTime.MinValue.ToUniversalTime(),
				RequestedToDate = DateTime.UtcNow.ToUniversalTime()
			};
			while( true )
			{
				var response = this._client.GetReportRequestList( request );
				var info = response.GetReportRequestListResult.ReportRequestInfo.FirstOrDefault( i => i.ReportRequestId.Equals( reportRequestId ) );
				if( info == null || !info.IsSetReportProcessingStatus() || info.ReportProcessingStatus.Equals( "_CANCELLED_", StringComparison.InvariantCultureIgnoreCase ) )
					break;

				if( info.ReportProcessingStatus.Equals( "_IN_PROGRESS_", StringComparison.InvariantCultureIgnoreCase ) )
				{
					Thread.Sleep( TimeSpan.FromSeconds( 30 ) );
					continue;
				}

				if( !string.IsNullOrEmpty( info.GeneratedReportId ) )
					return info.GeneratedReportId;
			}

			return reportId;
		}

		private string GetExistingReportId( ReportType reportType )
		{
			var reportListResponse = this._client.GetReportList( new GetReportListRequest
			{
				Merchant = this._credentials.SellerId,
				MWSAuthToken = this._credentials.MwsAuthToken,
				AvailableFromDate = DateTime.MinValue.ToUniversalTime(),
				AvailableToDate = DateTime.UtcNow.ToUniversalTime()
			} );
			if( !reportListResponse.IsSetGetReportListResult() || !reportListResponse.GetReportListResult.IsSetReportInfo() )
				return string.Empty;

			var reportListResult = reportListResponse.GetReportListResult;
			var reportInfo = reportListResult.ReportInfo.FirstOrDefault( r => r.ReportType.Equals( reportType.Description ) );
			if( reportInfo != null )
				return reportInfo.ReportId;

			if( !reportListResult.IsSetNextToken() )
				return string.Empty;

			var reportId = this.GetExistingReportIdInNextPages( reportListResult.NextToken, reportType.Description );
			return reportId;
		}

		private string GetExistingReportIdInNextPages( string nextToken, string reportType )
		{
			var nextResponse = this._client.GetReportListByNextToken( new GetReportListByNextTokenRequest
			{
				Merchant = this._credentials.SellerId,
				MWSAuthToken = this._credentials.MwsAuthToken,
				NextToken = nextToken
			} );

			if( !nextResponse.IsSetGetReportListByNextTokenResult() || !nextResponse.GetReportListByNextTokenResult.IsSetReportInfo() )
				return string.Empty;

			var reportListByNextTokenResult = nextResponse.GetReportListByNextTokenResult;
			var reportInfo = reportListByNextTokenResult.ReportInfo.FirstOrDefault( r => r.ReportType.Equals( reportType ) );
			if( reportInfo != null )
				return reportInfo.ReportId;

			if( !reportListByNextTokenResult.IsSetNextToken() )
				return string.Empty;

			return this.GetExistingReportIdInNextPages( reportListByNextTokenResult.NextToken, reportType );
		}

		private Stream GetReportById( string reportId )
		{
			var request = new GetReportRequest
			{
				Merchant = this._credentials.SellerId,
				MWSAuthToken = this._credentials.MwsAuthToken,
				ReportId = reportId,
				Report = new MemoryStream()
			};
			var response = this._client.GetReport( request );
			if( !response.IsSetGetReportResult() || request.Report == null )
				return null;
			return request.Report;
		}

		private IEnumerable< T > ConvertReport< T >( Stream stream ) where T : class, new()
		{
			var reader = new StreamReader( stream, Encoding.UTF8 );
			var cc = new CsvContext();
			var report = cc.Read< T >( reader, new CsvFileDescription { FirstLineHasColumnNames = true, SeparatorChar = '\t' } );
			return report;
		}
	}
}