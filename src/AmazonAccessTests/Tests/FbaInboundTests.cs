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
			var inbounds = service.GetInboundShipmentsData();

			inbounds.Count().Should().BeGreaterThan( 0 );
		}
	}
}