using System.Collections.Generic;
using AmazonAccess.Services.FeedsReports.Model;
using AmazonAccessTests.Misc;
using NUnit.Framework;

namespace AmazonAccessTests.Tests
{
	[ TestFixture ]
	internal sealed class InventoryTests: TestsBase
	{
		[ SetUp ]
		public void Init()
		{
		}

		[ Test ]
		public void UpdateInventory()
		{
			var service = this.AmazonFactory.CreateService( this.ClientConfig.SellerId, this.ClientConfig.MwsAuthToken, this.ClientConfig.ParseMarketplaces() );

			service.UpdateInventory( new List< AmazonInventoryItem >
			{
				new AmazonInventoryItem
				{
					Quantity = 45,
					Sku = "VK16AZN_KIT",
					FulfillmentLatency = 1
				},
				new AmazonInventoryItem
				{
					Quantity = 46,
					Sku = "testsku1",
					FulfillmentLatency = 1
				},
				new AmazonInventoryItem
				{
					Quantity = 47,
					Sku = "VK16AZN",
					FulfillmentLatency = 1
				},
				new AmazonInventoryItem
				{
					Quantity = 48,
					Sku = "FakeSku",
					FulfillmentLatency = 1
				},
				new AmazonInventoryItem
				{
					Quantity = 49,
					Sku = "8gbpkbx",
					FulfillmentLatency = 1
				}
			} );
		}
	}
}