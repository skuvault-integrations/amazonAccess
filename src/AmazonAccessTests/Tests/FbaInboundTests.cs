using System;
using System.Collections.Generic;
using System.Linq;
using AmazonAccess.Services.FBAInbound.Model;
using AmazonAccess.Services.FeedsReports.Model;
using AmazonAccessTests.Misc;
using FluentAssertions;
using NUnit.Framework;

namespace AmazonAccessTests.Tests
{
	[ TestFixture ]
	internal sealed class FbaInboundTests: TestsBase
	{
		[ SetUp ]
		public void Init()
		{
		}

		[ Test ]
		public void GetListInboundShipments()
		{
			var service = this.AmazonFactory.CreateService( this.ClientConfig.SellerId, this.ClientConfig.MwsAuthToken, this.ClientConfig.ParseMarketplaces() );
			var inbounds = service.GetListInboundShipments( null, null, new string[ 0 ], new string[ 0 ] );

			inbounds.Count().Should().BeGreaterThan( 0 );
		}

		[ Test ]
		public void CreateInboundShipments()
		{
			var service = this.AmazonFactory.CreateService( this.ClientConfig.SellerId, this.ClientConfig.MwsAuthToken, this.ClientConfig.ParseMarketplaces() );
			var dt = DateTime.Now;
			service.CreateInboundShipment(new Address("name", "line1", "city", "US") { PostalCode = "75462", StateOrProvinceCode = "AA" },
				"US",
				string.Empty,
				"AMAZON_LABEL_PREFERRED",
				new InboundShipmentPlanRequestItem[] { new InboundShipmentPlanRequestItem() { SellerSKU = "Test&amp;t&4", Quantity = 5 } }
				);

			var inbounds = service.GetListInboundShipments( dt, null, new string[ 0 ], new string[ 0 ] );
			inbounds.Count().Should().BeGreaterThan( 0 );
		}
	}
}