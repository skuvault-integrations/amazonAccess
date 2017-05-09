using System;
using System.Collections;
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

		[ Test ]
		[ TestCaseSource( typeof( testDataSource ), nameof( testDataSource.TestCases ) ) ]
		public void ReportServicetest2( IEnumerable< IEnumerable< ProductInventory > > stubs, List< ProductInventory > result )
		{
			//a
			var reportsServiceStubCurrent = new ReportsServiceStub2( new FeedsReportsServiceClient( "a", "s", "http://qwe.ru" ), new AmazonCredentials( "qwe", "secret", "seller", "mws", new AmazonMarketplaces( new List< string > { "us", "ca", "mx" } ) ) );
			foreach( var stub in stubs )
				reportsServiceStubCurrent.inventories.Add( stub );

			//a
			var methodResCurrent = new List< ProductInventory >();
			reportsServiceStubCurrent.GetReportForEachMarketplace< ProductInventory >( "marker", ReportType.InventoryReport, DateTime.Now, DateTime.Now, true, p => p.Sku, ( x, y ) => methodResCurrent.AddRange( y ) );

			//a
			methodResCurrent = methodResCurrent.OrderBy( x => x.Sku ).ToList();
			for( var i = 0; i < result.Count; i++ )
				result[ i ].ShouldBeEquivalentTo( methodResCurrent[ i ] );
			result.Count.Should().Be( methodResCurrent.Count );
		}

		public class testDataSource
		{
			public static IEnumerable TestCases
			{
				get
				{
					yield return new TestCaseData( new List< List< ProductInventory > >
						{
							new List< ProductInventory > { new ProductInventory() { Sku = "sku1" }, new ProductInventory() { Sku = "sku2" }, new ProductInventory() { Sku = "sku3" } },
							new List< ProductInventory > { new ProductInventory() { Sku = "sku2" }, new ProductInventory() { Sku = "sku3" }, new ProductInventory() { Sku = "sku4" } },
							new List< ProductInventory > { new ProductInventory() { Sku = "sku3" }, new ProductInventory() { Sku = "sku4" }, new ProductInventory() { Sku = "sku5" } }
						},
						new List< ProductInventory >() { new ProductInventory() { Sku = "sku1" }, new ProductInventory() { Sku = "sku2" }, new ProductInventory() { Sku = "sku3" }, new ProductInventory() { Sku = "sku4" }, new ProductInventory() { Sku = "sku5" } }
					);
					yield return new TestCaseData( new List< List< ProductInventory > >
						{
							new List< ProductInventory > { new ProductInventory() { Sku = "sku1" }, new ProductInventory() { Sku = "sku2" }, new ProductInventory() { Sku = "sku3" } },
							new List< ProductInventory > { new ProductInventory() { Sku = "sku1" }, new ProductInventory() { Sku = "sku2" }, new ProductInventory() { Sku = "sku3" } },
							new List< ProductInventory > { new ProductInventory() { Sku = "sku1" }, new ProductInventory() { Sku = "sku2" }, new ProductInventory() { Sku = "sku3" } },
						},
						new List< ProductInventory >() { new ProductInventory() { Sku = "sku1" }, new ProductInventory() { Sku = "sku2" }, new ProductInventory() { Sku = "sku3" } }
					);
					yield return new TestCaseData( new List< List< ProductInventory > >
						{
							new List< ProductInventory > { new ProductInventory() { Sku = "sku1" }, new ProductInventory() { Sku = "sku2" }, new ProductInventory() { Sku = "sku3" } },
							new List< ProductInventory > { new ProductInventory() { Sku = "sku4" }, new ProductInventory() { Sku = "sku5" }, new ProductInventory() { Sku = "sku6" } },
							new List< ProductInventory > { new ProductInventory() { Sku = "sku7" }, new ProductInventory() { Sku = "sku8" }, new ProductInventory() { Sku = "sku9" } },
						},
						new List< ProductInventory >() { new ProductInventory() { Sku = "sku1" }, new ProductInventory() { Sku = "sku2" }, new ProductInventory() { Sku = "sku3" }, new ProductInventory() { Sku = "sku4" }, new ProductInventory() { Sku = "sku5" }, new ProductInventory() { Sku = "sku6" }, new ProductInventory() { Sku = "sku7" }, new ProductInventory() { Sku = "sku8" }, new ProductInventory() { Sku = "sku9" } }
					);
				}
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

	public class ReportsServiceStub2: ReportsService
	{
		private int callCount = 0;
		public List< IEnumerable< ProductInventory > > inventories = new List< IEnumerable< ProductInventory > >();

		public ReportsServiceStub2( IFeedsReportsServiceClient client, AmazonCredentials credentials ): base( client, credentials )
		{
		}

		protected override IEnumerable< T > GetReportForMarketplaces< T >( string marker, ReportType reportType, List< string > marketplaces, DateTime startDate, DateTime endDate )
		{
			return this.inventories[ this.callCount++ % this.inventories.Count ] as IEnumerable< T >;
		}
	}
}