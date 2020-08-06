using AmazonAccess.Misc;
using AmazonAccess.Services.FeedsReports.ReportModel;
using AmazonAccessTests.Misc;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.IO;
using System.Linq;

namespace AmazonAccessTests.Tests
{
	[ TestFixture ]
	sealed class FbaShipmentsTests : TestsBase
	{
		[ Test ]
		public void ReadFbaShipmentsData()
		{
			var data = File.ReadAllText( @"..\..\Files\FBA_shipments_example.csv" );
			var shipmentsData = new AmazonCsvReader().ParseReport< FbaShipmentItemData >( data ).ToList();

			shipmentsData.Should().NotBeNull();
			shipmentsData.Count.Should().BeGreaterThan( 1 );
		}

		[ Test ]
		public void GetFbaShipments()
		{
			var service = this.AmazonFactory.CreateService( this.ClientConfig.SellerId, this.ClientConfig.MwsAuthToken, this.ClientConfig.ParseMarketplaces() );
			var shipments = service.GetFbaShipments( DateTime.UtcNow.AddDays( -1 ), DateTime.UtcNow );
			
			shipments.Count().Should().BeGreaterThan( 0 );
		}
	}
}