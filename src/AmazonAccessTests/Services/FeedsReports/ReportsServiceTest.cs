using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AmazonAccess.Models;
using AmazonAccess.Services.FeedsReports;
using AmazonAccess.Services.FeedsReports.ReportModel;
using FluentAssertions;
using NUnit.Framework;

namespace AmazonAccessTests.Services.FeedsReports
{
	[ TestFixture ]
	public class ReportsServiceTest
	{
		[ Test ]
		public void GetReportForEachMarketplaceTest()
		{
			var reportsServiceStubCurrent = new ReportsServiceStub( new FeedsReportsServiceClient( "a", "s", "http://qwe.ru" ), new AmazonCredentials( "qwe", "secret", "seller", "mws", new AmazonMarketplaces( new List< string > { "us", "ca", "mx" } ) ) );
			var methodResCurrent = new List< ProductInventory >();
			var sw = Stopwatch.StartNew();
			reportsServiceStubCurrent.GetReportForEachMarketplace< ProductInventory >( "marker", ReportType.InventoryReport, DateTime.Now, DateTime.Now, true, p => p.Sku, ( x, y ) => methodResCurrent.AddRange( y ) );
			Debug.WriteLine( sw.Elapsed );

			var reportsServiceStubMax = new ReportsServiceStub( new FeedsReportsServiceClient( "a", "s", "http://qwe.ru" ), new AmazonCredentials( "qwe", "secret", "seller", "mws", new AmazonMarketplaces( new List< string > { "us", "ca", "mx" } ) ) );
			var methodResMax = new List< ProductInventory >();
			sw.Restart();
			reportsServiceStubMax.GetReportForEachMarketplace_Max< ProductInventory >( "marker", ReportType.InventoryReport, DateTime.Now, DateTime.Now, true, p => p.Sku, ( x, y ) => methodResMax.AddRange( y ) );
			Debug.WriteLine( sw.Elapsed );

			var reportsServiceStubO = new ReportsServiceStub( new FeedsReportsServiceClient( "a", "s", "http://qwe.ru" ), new AmazonCredentials( "qwe", "secret", "seller", "mws", new AmazonMarketplaces( new List< string > { "us", "ca", "mx" } ) ) );
			var methodReO = new List< ProductInventory >();
			sw.Restart();
			reportsServiceStubO.GetReportForEachMarketplace_Original< ProductInventory >( "marker", ReportType.InventoryReport, DateTime.Now, DateTime.Now, true, p => p.Sku, ( x, y ) => methodReO.AddRange( y ) );
			Debug.WriteLine( sw.Elapsed );

			methodReO = methodReO.OrderBy( x => x.Sku ).ToList();
			methodResCurrent = methodResCurrent.OrderBy( x => x.Sku ).ToList();
			methodResMax = methodResMax.OrderBy( x => x.Sku ).ToList();
			for( var i = 0; i < methodReO.Count; i++ )
			{
				methodReO[ i ].ShouldBeEquivalentTo( methodResCurrent[ i ] );
			}
			for( var i = 0; i < methodReO.Count; i++ )
			{
				methodReO[ i ].ShouldBeEquivalentTo( methodResMax[ i ] );
			}
		}
	}

	public class ReportsServiceStub: ReportsService
	{
		private int callCount = 0;

		public ReportsServiceStub( IFeedsReportsServiceClient client, AmazonCredentials credentials ): base( client, credentials )
		{
		}

		protected IEnumerable< ProductInventory > GetReportForMarketplaces( int reportItemsCount )
		{
			var count = reportItemsCount;
			return Enumerable.Range( ( this.callCount++ ) * ( count / 2 ), count ).Select( x => new ProductInventory() { Sku = "TestSku" + x.ToString( "D7" ) } ).ToList();
		}

		protected override IEnumerable< T > GetReportForMarketplaces< T >( string marker, ReportType reportType, List< string > marketplaces, DateTime startDate, DateTime endDate )
		{
			return this.GetReportForMarketplaces( 100000 ) as IEnumerable< T >;
		}
	}
}