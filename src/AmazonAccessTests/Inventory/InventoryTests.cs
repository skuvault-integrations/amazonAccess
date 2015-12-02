using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using AmazonAccess.Services.FbaInventory.Model;
using AmazonAccess.Services.FeedsReports.Model;
using AmazonAccess.Services.FeedsReports.ReportModel;
using FluentAssertions;
using NUnit.Framework;

namespace AmazonAccessTests.Inventory
{
	[ TestFixture ]
	internal sealed class InventoryTests: TestsBase
	{
		[ SetUp ]
		public void Init()
		{
		}

		[ Test ]
		public void GetFbaInventory()
		{
			var service = this.AmazonFactory.CreateService( this.ClientConfig.SellerId, this.ClientConfig.MwsAuthToken, this.ClientConfig.ParseMarketplaces() );

			var inventory = service.GetFbaInventory();
			var serializer = new XmlSerializer( typeof( List< InventorySupply > ) );
			var writer = new StringWriter();
			serializer.Serialize( writer, inventory.ToList() );
			var xml = writer.GetStringBuilder().ToString();

			inventory.Count().Should().BeGreaterThan( 0 );
		}

		[ Test ]
		public void IsFbaInventoryReceived()
		{
			var service = this.AmazonFactory.CreateService( this.ClientConfig.SellerId, this.ClientConfig.MwsAuthToken, this.ClientConfig.ParseMarketplaces() );

			var result = service.IsFbaInventoryReceived();
			result.Should().BeTrue();
		}

		[ Test ]
		public void GetDetailedFbaInventory()
		{
			var service = this.AmazonFactory.CreateService( this.ClientConfig.SellerId, this.ClientConfig.MwsAuthToken, this.ClientConfig.ParseMarketplaces() );

			var inventory = service.GetDetailedFbaInventory();
			var serializer = new XmlSerializer( typeof( List< FbaManageInventory > ) );
			var writer = new StringWriter();
			serializer.Serialize( writer, inventory.ToList() );
			var xml = writer.GetStringBuilder().ToString();

			inventory.Count().Should().BeGreaterThan( 0 );
		}

		[ Test ]
		public void UpdateInventory()
		{
			var service = this.AmazonFactory.CreateService( this.ClientConfig.SellerId, this.ClientConfig.MwsAuthToken, this.ClientConfig.ParseMarketplaces() );

			service.UpdateInventory( new List< AmazonInventoryItem >
			{
				new AmazonInventoryItem
				{
					Quantity = 35,
					Sku = "VK16AZN_KIT",
					FulfillmentLatency = 1
				},
				new AmazonInventoryItem
				{
					Quantity = 36,
					Sku = "testsku1",
					FulfillmentLatency = 1
				},
				new AmazonInventoryItem
				{
					Quantity = 37,
					Sku = "VK16AZN",
					FulfillmentLatency = 1
				},
				new AmazonInventoryItem
				{
					Quantity = 38,
					Sku = "FakeSku",
					FulfillmentLatency = 1
				}
			} );
		}
	}
}