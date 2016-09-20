using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using AmazonAccess.Misc;
using AmazonAccess.Models;
using AmazonAccess.Services.FeedsReports.Model;
using CuttingEdge.Conditions;
using LINQtoCSV;

namespace AmazonAccess.Services.FeedsReports
{
	public class ReportsService
	{
		private readonly IFeedsReportsServiceClient _client;
		private readonly AmazonCredentials _credentials;
		private readonly Throttler _requestReportThrottler = new Throttler( 15, 61 );
		private readonly Throttler _getReportRequestListThrottler = new Throttler( 10, 46 );
		private readonly Throttler _getReportListThrottler = new Throttler( 10, 61 );
		private readonly Throttler _getReportListByNextTokenThrottler = new Throttler( 30, 3 );
		private readonly Throttler _getReportThrottler = new Throttler( 15, 61 );

		public ReportsService( IFeedsReportsServiceClient client, AmazonCredentials credentials )
		{
			Condition.Requires( client, "client" ).IsNotNull();
			Condition.Requires( credentials, "credentials" ).IsNotNull();

			this._client = client;
			this._credentials = credentials;
		}

		public IEnumerable< T > GetReportForAllMarketplaces< T >( ReportType reportType, DateTime startDate, DateTime endDate, string marker ) where T : class, new()
		{
			AmazonLogger.Trace( "GetReportForAllMarketplaces", this._credentials.SellerId, marker, "Begin invoke" );

			var report = this.GetReportForMarketplaces< T >( reportType, this._credentials.AmazonMarketplaces.GetMarketplaceIdAsList(), startDate, endDate, marker );

			AmazonLogger.Trace( "GetReportForAllMarketplaces", this._credentials.SellerId, marker, "End invoke" );
			return report;
		}

		public List< T > GetReportForEachMarketplaceAndJoin< T >( ReportType reportType, DateTime startDate, DateTime endDate, bool skipDuplicates, Func< T, string > getKey, string marker ) where T : class, new()
		{
			var report = new List< T >();
			this.GetReportForEachMarketplace( reportType, startDate, endDate, skipDuplicates, getKey, ( marketplace, portion ) => report.AddRange( portion ), marker );
			return report;
		}

		public Dictionary< string, List< T > > GetReportForEachMarketplace< T >( ReportType reportType, DateTime startDate, DateTime endDate, bool skipDuplicates, Func< T, string > getKey, string marker ) where T : class, new()
		{
			var report = new Dictionary< string, List< T > >();
			this.GetReportForEachMarketplace( reportType, startDate, endDate, skipDuplicates, getKey, ( marketplace, portion ) => report.Add( marketplace, portion ), marker );
			return report;
		}

		public void GetReportForEachMarketplace< T >( ReportType reportType, DateTime startDate, DateTime endDate, bool skipDuplicates, Func< T, string > getKey,
			Action< string, T > processReportAction, string marker ) where T : class, new()
		{
			this.GetReportForEachMarketplace( reportType, startDate, endDate, skipDuplicates, getKey, ( marketplace, portion ) =>
			{
				foreach( var p in portion )
				{
					processReportAction( marketplace, p );
				}
			}, marker );
		}

		public void GetReportForEachMarketplace< T >( ReportType reportType, DateTime startDate, DateTime endDate, bool skipDuplicates, Func< T, string > getKey,
			Action< string, List< T > > processReportAction, string marker ) where T : class, new()
		{
			AmazonLogger.Trace( "GetReportByMarketplace", this._credentials.SellerId, marker, "Begin invoke" );

			var marketplaces = this._credentials.AmazonMarketplaces.GetMarketplaceIdAsList();

			var keys = new List< string >();
			foreach( var marketplace in marketplaces )
			{
				var reportPortion = this.GetReportForMarketplaces< T >( reportType, new List< string > { marketplace }, startDate, endDate, marker ).ToList();
				if( skipDuplicates )
				{
					var filteredItems = reportPortion.Select( x => new { key = getKey( x ), value = x } ).Where( x => !keys.Contains( x.key ) ).ToList();
					keys.AddRange( filteredItems.Select( x => x.key ) );
					reportPortion = filteredItems.Select( x => x.value ).ToList();
				}
				processReportAction( marketplace, reportPortion );
			}

			AmazonLogger.Trace( "GetReportByMarketplace", this._credentials.SellerId, marker, "End invoke" );
		}

		private IEnumerable< T > GetReportForMarketplaces< T >( ReportType reportType, List< string > marketplaces, DateTime startDate, DateTime endDate, string marker ) where T : class, new()
		{
			AmazonLogger.Trace( "GetReportForMarketplaces", this._credentials.SellerId, marker, "Begin invoke" );

			var reportRequestId = this.GetReportRequestId( reportType, marketplaces, startDate, endDate, marker );

			var reportId = this.GetNewReportId( reportRequestId, marker );
			if( string.IsNullOrEmpty( reportId ) )
				reportId = this.GetExistingReportId( reportType, marker );
			if( string.IsNullOrEmpty( reportId ) )
				throw AmazonLogger.Error( "GetReport", this._credentials.SellerId, marker, "Can't request new report or find existing" );
			if( reportId.Equals( "_NO_DATA_" ) )
			{
				AmazonLogger.Trace( "GetReport", this._credentials.SellerId, marker, "Empty report" );
				return new List< T >();
			}

			var reportString = this.GetReportById( reportId, marker );
			if( reportString == null )
				throw AmazonLogger.Error( "GetReport", this._credentials.SellerId, marker, "Can't get report" );

			var report = this.ConvertReport< T >( reportString );
			return report;
		}

		private string GetReportRequestId( ReportType reportType, List< string > marketplaces, DateTime startDate, DateTime endDate, string marker )
		{
			AmazonLogger.Trace( "GetReportRequestId", this._credentials.SellerId, marker, "Begin invoke" );

			var request = new RequestReportRequest
			{
				SellerId = this._credentials.SellerId,
				MWSAuthToken = this._credentials.MwsAuthToken,
				MarketplaceIdList = marketplaces,
				ReportType = reportType.Description,
				StartDate = startDate,
				EndDate = endDate
			};
			var response = ActionPolicies.Get.Get( () => this._requestReportThrottler.Execute( () => this._client.RequestReport( request, marker ) ) );
			if( response.IsSetRequestReportResult() && response.RequestReportResult.IsSetReportRequestInfo() )
				return response.RequestReportResult.ReportRequestInfo.ReportRequestId;

			return string.Empty;
		}

		private string GetNewReportId( string reportRequestId, string marker )
		{
			AmazonLogger.Trace( "GetNewReportId", this._credentials.SellerId, marker, "Begin invoke" );

			var request = new GetReportRequestListRequest
			{
				SellerId = this._credentials.SellerId,
				MWSAuthToken = this._credentials.MwsAuthToken,
				ReportRequestIdList = new List< string > { reportRequestId },
				RequestedFromDate = DateTime.MinValue.ToUniversalTime(),
				RequestedToDate = DateTime.UtcNow.ToUniversalTime()
			};

			for( var i = 0; i < 100; i++ )
			{
				ActionPolicies.CreateApiDelay( 30 ).Wait();

				var response = ActionPolicies.Get.Get( () => this._getReportRequestListThrottler.Execute( () => this._client.GetReportRequestList( request, marker ) ) );
				if( !response.IsSetGetReportRequestListResult() || !response.GetReportRequestListResult.IsSetReportRequestInfo() )
					return string.Empty;

				var info = response.GetReportRequestListResult.ReportRequestInfo.FirstOrDefault( x => x.ReportRequestId.Equals( reportRequestId ) );
				if( info == null || !info.IsSetReportProcessingStatus() || info.ReportProcessingStatus.Equals( "_CANCELLED_", StringComparison.InvariantCultureIgnoreCase ) )
					return string.Empty;

				if( info.ReportProcessingStatus.Equals( "_DONE_NO_DATA_", StringComparison.InvariantCultureIgnoreCase ) )
					return "_NO_DATA_";

				if( !string.IsNullOrEmpty( info.GeneratedReportId ) )
					return info.GeneratedReportId;
			}

			throw AmazonLogger.Error( "GetNewReportId", this._credentials.SellerId, marker, "Limit of replays was reached" );
		}

		private string GetExistingReportId( ReportType reportType, string marker )
		{
			AmazonLogger.Trace( "GetExistingReportId", this._credentials.SellerId, marker, "Begin invoke" );

			var request = new GetReportListRequest
			{
				SellerId = this._credentials.SellerId,
				MWSAuthToken = this._credentials.MwsAuthToken,
				AvailableFromDate = DateTime.MinValue.ToUniversalTime(),
				AvailableToDate = DateTime.UtcNow.ToUniversalTime()
			};
			var reportListResponse = ActionPolicies.Get.Get( () => this._getReportListThrottler.Execute( () => this._client.GetReportList( request, marker ) ) );
			if( !reportListResponse.IsSetGetReportListResult() || !reportListResponse.GetReportListResult.IsSetReportInfo() )
				return string.Empty;

			var reportInfo = reportListResponse.GetReportListResult.ReportInfo.FirstOrDefault( r => r.ReportType.Equals( reportType.Description ) );
			if( reportInfo != null )
				return reportInfo.ReportId;

			return this.GetExistingReportIdInNextPages( reportListResponse.GetReportListResult.NextToken, reportType.Description, marker );
		}

		private string GetExistingReportIdInNextPages( string nextToken, string reportType, string marker )
		{
			for( var i = 0; i < 30 && !string.IsNullOrEmpty( nextToken ); i++ )
			{
				AmazonLogger.Trace( "GetExistingReportIdInNextPages", this._credentials.SellerId, marker, "NextToken:{0}", nextToken );

				var request = new GetReportListByNextTokenRequest
				{
					SellerId = this._credentials.SellerId,
					MWSAuthToken = this._credentials.MwsAuthToken,
					NextToken = nextToken
				};
				var response = ActionPolicies.Get.Get( () => this._getReportListByNextTokenThrottler.Execute( () => this._client.GetReportListByNextToken( request, marker ) ) );
				if( !response.IsSetGetReportListByNextTokenResult() || !response.GetReportListByNextTokenResult.IsSetReportInfo() )
					return string.Empty;

				var reportInfo = response.GetReportListByNextTokenResult.ReportInfo.FirstOrDefault( r => r.ReportType.Equals( reportType ) );
				if( reportInfo != null )
					return reportInfo.ReportId;

				nextToken = response.GetReportListByNextTokenResult.NextToken;
			}
			return string.Empty;
		}

		private string GetReportById( string reportId, string marker )
		{
			AmazonLogger.Trace( "GetReportById", this._credentials.SellerId, marker, "Begin invoke" );

			var request = new GetReportRequest
			{
				SellerId = this._credentials.SellerId,
				MWSAuthToken = this._credentials.MwsAuthToken,
				ReportId = reportId
			};
			var response = ActionPolicies.Get.Get( () => this._getReportThrottler.Execute( () => this._client.GetReport( request, marker ) ) );
			if( response.IsSetGetReportResult() && response.GetReportResult.IsSetResult() )
				return response.GetReportResult.Result;

			return null;
		}

		private IEnumerable< T > ConvertReport< T >( string reportString ) where T : class, new()
		{
			using( var ms = new MemoryStream( Encoding.UTF8.GetBytes( reportString ) ) )
			using( var reader = new StreamReader( ms ) )
			{
				var cc = new CsvContext();
				var report = cc.Read< T >( reader, new CsvFileDescription { FirstLineHasColumnNames = true, SeparatorChar = '\t', IgnoreUnknownColumns = true, FileCultureInfo = CultureInfo.InvariantCulture } );
				return report.ToList();
			}
		}
	}
}