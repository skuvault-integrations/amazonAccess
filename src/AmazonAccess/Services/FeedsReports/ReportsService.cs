using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
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
		private const int GetNewReportIdRetryCount = 40;
#if DEBUG
		private readonly Func< int, int > GetNewReportIdRetryDelayFunc = i => 30;
#else
		private readonly Func< int, int > GetNewReportIdRetryDelayFunc = i => i < 2 ? 60 : 120;
#endif

		public ReportsService( IFeedsReportsServiceClient client, AmazonCredentials credentials )
		{
			Condition.Requires( client, "client" ).IsNotNull();
			Condition.Requires( credentials, "credentials" ).IsNotNull();

			this._client = client;
			this._credentials = credentials;
		}

		#region TryGetReport
		public bool TryGetReportForEachMarketplace( string marker, ReportType reportType, DateTime startDate, DateTime endDate )
		{
			foreach( var marketplace in this._credentials.AmazonMarketplaces.GetMarketplaceIdAsList() )
			{
				var isSuccess = this.TryGetReportForMarketplaces( marker, reportType, new List< string > { marketplace }, startDate, endDate );
				if( !isSuccess )
					return false;
			}
			return true;
		}

		public bool TryGetReportForAllMarketplaces( string marker, ReportType reportType, DateTime startDate, DateTime endDate, bool dontSendMarketplaces = false )
		{
			var marketplaces = dontSendMarketplaces ? new List< string >() : this._credentials.AmazonMarketplaces.GetMarketplaceIdAsList();
			var result = this.TryGetReportForMarketplaces( marker, reportType, marketplaces, startDate, endDate );
			return result;
		}
		#endregion

		#region GetReportForAllMarketplaces
		public IEnumerable< T > GetReportForAllMarketplaces< T >( string marker, ReportType reportType, DateTime startDate, DateTime endDate, bool dontSendMarketplaces = false ) where T : class, new()
		{
			AmazonLogger.Trace( "GetReportForAllMarketplaces", this._credentials.SellerId, marker, "Begin invoke" );

			var marketplaces = dontSendMarketplaces ? new List< string >() : this._credentials.AmazonMarketplaces.GetMarketplaceIdAsList();
			var report = this.GetReportForMarketplaces< T >( marker, reportType, marketplaces, startDate, endDate );

			AmazonLogger.Trace( "GetReportForAllMarketplaces", this._credentials.SellerId, marker, "End invoke" );
			return report;
		}
		#endregion

		#region GetReportForEachMarketplace
		public List< T > GetReportForEachMarketplaceAndJoin< T >( string marker, ReportType reportType, DateTime startDate, DateTime endDate, bool skipDuplicates, Func< T, string > getKey ) where T : class, new()
		{
			var report = new List< T >();
			this.GetReportForEachMarketplace( marker, reportType, startDate, endDate, skipDuplicates, getKey, ( marketplace, portion ) => report.AddRange( portion ) );
			return report;
		}

		public Dictionary< AmazonMarketplace, List< T > > GetReportForEachMarketplace< T >( string marker, ReportType reportType, DateTime startDate, DateTime endDate, bool skipDuplicates, Func< T, string > getKey ) where T : class, new()
		{
			var report = new Dictionary< AmazonMarketplace, List< T > >();
			this.GetReportForEachMarketplace( marker, reportType, startDate, endDate, skipDuplicates, getKey, ( marketplace, portion ) => report.Add( marketplace, portion ) );
			return report;
		}

		public void GetReportForEachMarketplace< T >( string marker, ReportType reportType, DateTime startDate, DateTime endDate, bool skipDuplicates, Func< T, string > getKey,
			Action< AmazonMarketplace, T > processReportAction ) where T : class, new()
		{
			this.GetReportForEachMarketplace( marker, reportType, startDate, endDate, skipDuplicates, getKey, ( marketplace, portion ) =>
			{
				foreach( var p in portion )
				{
					processReportAction( marketplace, p );
				}
			} );
		}

		public void GetReportForEachMarketplace< T >( string marker, ReportType reportType, DateTime startDate, DateTime endDate, bool skipDuplicates, Func< T, string > getKey,
			Action< AmazonMarketplace, List< T > > processReportAction ) where T : class, new()
		{
			AmazonLogger.Trace( "GetReportForEachMarketplace", this._credentials.SellerId, marker, "Begin invoke" );

			var keys = new List< string >();
			foreach( var marketplace in this._credentials.AmazonMarketplaces.Marketplaces )
			{
				var reportPortion = this.GetReportForMarketplaces< T >( marker, reportType, new List< string > { marketplace.MarketplaceId }, startDate, endDate ).ToList();
				if( skipDuplicates )
				{
					var newReportPortionQuery = from pItem in reportPortion
						let pKey = getKey( pItem ).ToLower()
						join key in keys on pKey equals key into existingKeys
						where !existingKeys.Any()
						select new { Key = pKey, PortionItem = pItem };
					newReportPortionQuery = newReportPortionQuery.GroupBy( x => x.Key ).Select( x => x.First() );

					var newReportPortion = newReportPortionQuery.ToList();
					if( newReportPortion.Count != reportPortion.Count )
						reportPortion = newReportPortion.Select( x => x.PortionItem ).ToList();
					keys.AddRange( newReportPortion.Select( x => x.Key ) );
				}
				processReportAction( marketplace, reportPortion );
			}

			AmazonLogger.Trace( "GetReportForEachMarketplace", this._credentials.SellerId, marker, "End invoke" );
		}
		#endregion

		#region common
		private IEnumerable< T > GetReportForMarketplaces< T >( string marker, ReportType reportType, List< string > marketplaces, DateTime startDate, DateTime endDate ) where T : class, new()
		{
			AmazonLogger.Trace( "GetReportForMarketplaces", this._credentials.SellerId, marker, "Begin invoke" );

			var reportRequestId = this.GetReportRequestId( marker, reportType, marketplaces, startDate, endDate );

			var reportId = this.GetNewReportId( marker, reportRequestId );
			if( string.IsNullOrEmpty( reportId ) )
				reportId = this.GetExistingReportId( marker, reportType, marketplaces );
			if( string.IsNullOrEmpty( reportId ) )
			{
				AmazonLogger.Trace( "GetReportForMarketplaces", this._credentials.SellerId, marker, "Can't request new report or find existing. Maybe report is empty. See previous attempt." );
				return new List< T >();
			}
			if( reportId.Equals( "_NO_DATA_" ) )
			{
				AmazonLogger.Trace( "GetReportForMarketplaces", this._credentials.SellerId, marker, "Empty report" );
				return new List< T >();
			}

			var reportString = this.GetReportById( marker, reportId );
			if( reportString == null )
				throw AmazonLogger.Error( "GetReportForMarketplaces", this._credentials.SellerId, marker, "Can't get report" );

			var report = this.ConvertReport< T >( reportString );
			return report;
		}

		private bool TryGetReportForMarketplaces( string marker, ReportType reportType, List< string > marketplaces, DateTime startDate, DateTime endDate )
		{
			try
			{
				var request = new RequestReportRequest
				{
					SellerId = this._credentials.SellerId,
					MWSAuthToken = this._credentials.MwsAuthToken,
					MarketplaceIdList = marketplaces,
					ReportType = reportType.Description,
					StartDate = startDate,
					EndDate = endDate
				};
				var response = this._client.RequestReport( request, marker );
				return true;
			}
			catch( Exception )
			{
				return false;
			}
		}

		private string GetReportRequestId( string marker, ReportType reportType, List< string > marketplaces, DateTime startDate, DateTime endDate )
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

		private string GetNewReportId( string marker, string reportRequestId )
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

			for( var i = 0; i < GetNewReportIdRetryCount; i++ )
			{
				ActionPolicies.CreateApiDelay( this.GetNewReportIdRetryDelayFunc( i ) ).Wait();

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

		private string GetExistingReportId( string marker, ReportType reportType, List< string > marketplaces )
		{
			AmazonLogger.Trace( "GetExistingReportId", this._credentials.SellerId, marker, "Begin invoke" );

			var request = new GetReportListRequest
			{
				SellerId = this._credentials.SellerId,
				MWSAuthToken = this._credentials.MwsAuthToken,
				MarketplaceIdListList = marketplaces, //Amazon returns reports for any marketplaces from this list
				ReportTypeList = new List< string > { reportType.Description },
				AvailableFromDate = DateTime.MinValue.ToUniversalTime(),
				AvailableToDate = DateTime.UtcNow.ToUniversalTime()
			};
			var reportListResponse = ActionPolicies.Get.Get( () => this._getReportListThrottler.Execute( () => this._client.GetReportList( request, marker ) ) );
			if( !reportListResponse.IsSetGetReportListResult() || !reportListResponse.GetReportListResult.IsSetReportInfo() )
				return string.Empty;

			var reportInfo = reportListResponse.GetReportListResult.ReportInfo.FirstOrDefault( r => r.ReportType.Equals( reportType.Description ) );
			if( reportInfo != null )
				return reportInfo.ReportId;

			return this.GetExistingReportIdInNextPages( marker, reportListResponse.GetReportListResult.NextToken, reportType.Description, marketplaces );
		}

		private string GetExistingReportIdInNextPages( string marker, string nextToken, string reportType, List< string > marketplaces )
		{
			for( var i = 0; i < 30 && !string.IsNullOrEmpty( nextToken ); i++ )
			{
				AmazonLogger.Trace( "GetExistingReportIdInNextPages", this._credentials.SellerId, marker, "NextToken:{0}", nextToken );

				var request = new GetReportListByNextTokenRequest
				{
					SellerId = this._credentials.SellerId,
					MWSAuthToken = this._credentials.MwsAuthToken,
					MarketplaceIdListList = marketplaces,
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

		private string GetReportById( string marker, string reportId )
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
			reportString = WebUtility.HtmlDecode( reportString );

			using( var ms = new MemoryStream( Encoding.UTF8.GetBytes( reportString ) ) )
			using( var reader = new StreamReader( ms ) )
			{
				var cc = new CsvContext();
				var csvOptions = new CsvFileDescription
				{
					FirstLineHasColumnNames = true, SeparatorChar = '\t', IgnoreUnknownColumns = true, FileCultureInfo = CultureInfo.InvariantCulture,
					QuoteAllFields = true, TextEncoding = Encoding.UTF8, UseFieldIndexForReadingData = false
				};
				var report = cc.Read< T >( reader, csvOptions );
				return report.ToList();
			}
		}
		#endregion
	}
}