using System;
using System.Collections;
using System.Collections.Generic;
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
		[ TestCaseSource( typeof( TestDataSource ), nameof( TestDataSource.TestCases ) ) ]
		public void ReportServicetest( IEnumerable< IEnumerable< ProductInventory > > stubs, List< ProductInventory > result )
		{
			//a
			var reportsServiceStubCurrent = new ReportsServiceStub( new FeedsReportsServiceClient( "a", "s", "http://qwe.ru" ), new AmazonCredentials( "qwe", "secret", "seller", "mws", new AmazonMarketplaces( new List< string > { "us", "ca", "mx" } ) ) );
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

		public class TestDataSource
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
					).SetName( "Marketplaces-Intercepted" );
					yield return new TestCaseData( new List< List< ProductInventory > >
						{
							new List< ProductInventory > { new ProductInventory() { Sku = "sku1" }, new ProductInventory() { Sku = "sku2" }, new ProductInventory() { Sku = "sku3" } },
							new List< ProductInventory > { new ProductInventory() { Sku = "sku1" }, new ProductInventory() { Sku = "sku2" }, new ProductInventory() { Sku = "sku3" } },
							new List< ProductInventory > { new ProductInventory() { Sku = "sku1" }, new ProductInventory() { Sku = "sku2" }, new ProductInventory() { Sku = "sku3" } },
						},
						new List< ProductInventory >() { new ProductInventory() { Sku = "sku1" }, new ProductInventory() { Sku = "sku2" }, new ProductInventory() { Sku = "sku3" } }
					).SetName( "Marketplaces-The-Same" );
					;
					yield return new TestCaseData( new List< List< ProductInventory > >
						{
							new List< ProductInventory > { new ProductInventory() { Sku = "sku1" }, new ProductInventory() { Sku = "sku2" }, new ProductInventory() { Sku = "sku3" } },
							new List< ProductInventory > { new ProductInventory() { Sku = "sku4" }, new ProductInventory() { Sku = "sku5" }, new ProductInventory() { Sku = "sku6" } },
							new List< ProductInventory > { new ProductInventory() { Sku = "sku7" }, new ProductInventory() { Sku = "sku8" }, new ProductInventory() { Sku = "sku9" } },
						},
						new List< ProductInventory >() { new ProductInventory() { Sku = "sku1" }, new ProductInventory() { Sku = "sku2" }, new ProductInventory() { Sku = "sku3" }, new ProductInventory() { Sku = "sku4" }, new ProductInventory() { Sku = "sku5" }, new ProductInventory() { Sku = "sku6" }, new ProductInventory() { Sku = "sku7" }, new ProductInventory() { Sku = "sku8" }, new ProductInventory() { Sku = "sku9" } }
					).SetName( "Marketplaces-Unique" );
					;
				}
			}
		}
	}

	public class ReportsServiceStub: ReportsService
	{
		private int callCount = 0;
		public List< IEnumerable< ProductInventory > > inventories = new List< IEnumerable< ProductInventory > >();

		public ReportsServiceStub( IFeedsReportsServiceClient client, AmazonCredentials credentials ): base( client, credentials )
		{
		}

		protected override IEnumerable< T > GetReportForMarketplaces< T >( string marker, ReportType reportType, List< string > marketplaces, DateTime startDate, DateTime endDate )
		{
			return this.inventories[ this.callCount++ % this.inventories.Count ] as IEnumerable< T >;
		}
	}
}