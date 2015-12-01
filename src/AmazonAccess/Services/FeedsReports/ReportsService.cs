using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using AmazonAccess.Models;
using AmazonAccess.Services.FeedsReports.Model;
using LINQtoCSV;

namespace AmazonAccess.Services.FeedsReports
{
	public class ReportsService
	{
		private readonly IFeedReportServiceClient _client;
		private readonly AmazonCredentials _credentials;

		public ReportsService( IFeedReportServiceClient client, AmazonCredentials credentials )
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

			var reportString = this.GetReportById( reportId );
			if( reportString == null )
				throw new Exception( "Can't get report" );

			var report = this.ConvertReport< T >( reportString );
			return report;
		}

		private string GetReportRequestId( ReportType reportType, DateTime startDate, DateTime endDate )
		{
			var request = new RequestReportRequest
			{
				SellerId = this._credentials.SellerId,
				MWSAuthToken = this._credentials.MwsAuthToken,
				MarketplaceId = this._credentials.AmazonMarketplaces.GetMarketplaceIdAsList(),
				ReportType = reportType.Description,
				StartDate = startDate,
				EndDate = endDate
			};
			var response = this._client.RequestReport( request, null );

			var reportId = response.IsSetRequestReportResult() ? response.RequestReportResult.ReportRequestInfo.ReportRequestId : string.Empty;
			return reportId;
		}

		private string GetNewReportId( string reportRequestId )
		{
			var reportId = string.Empty;
			var request = new GetReportRequestListRequest
			{
				SellerId = this._credentials.SellerId,
				MWSAuthToken = this._credentials.MwsAuthToken,
				ReportRequestIdList = new List< string > { reportRequestId },
				RequestedFromDate = DateTime.MinValue.ToUniversalTime(),
				RequestedToDate = DateTime.UtcNow.ToUniversalTime()
			};
			while( true )
			{
				var response = this._client.GetReportRequestList( request, null );
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
				SellerId = this._credentials.SellerId,
				MWSAuthToken = this._credentials.MwsAuthToken,
				AvailableFromDate = DateTime.MinValue.ToUniversalTime(),
				AvailableToDate = DateTime.UtcNow.ToUniversalTime()
			}, null );
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
				SellerId = this._credentials.SellerId,
				MWSAuthToken = this._credentials.MwsAuthToken,
				NextToken = nextToken
			}, null );

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

		private string GetReportById( string reportId )
		{
			var request = new GetReportRequest
			{
				SellerId = this._credentials.SellerId,
				MWSAuthToken = this._credentials.MwsAuthToken,
				ReportId = reportId
			};
			var response = this._client.GetReport( request, null );
			if( !response.IsSetGetReportResult() || !response.GetReportResult.IsSetResult() )
				return null;
			return response.GetReportResult.Result;
		}

		private IEnumerable< T > ConvertReport< T >( string reportString ) where T : class, new()
		{
			using( var ms = new MemoryStream( Encoding.UTF8.GetBytes( reportString ) ) )
			{
				var reader = new StreamReader( ms );
				var cc = new CsvContext();
				var report = cc.Read< T >( reader, new CsvFileDescription { FirstLineHasColumnNames = true, SeparatorChar = '\t' } );
				return report.ToList();
			}
		}
	}
}