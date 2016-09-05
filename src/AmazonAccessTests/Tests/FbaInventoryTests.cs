using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using AmazonAccess.Models;
using AmazonAccess.Services.FbaInventory.Model;
using AmazonAccess.Services.FeedsReports.ReportModel;
using AmazonAccessTests.Misc;
using FluentAssertions;
using NUnit.Framework;

namespace AmazonAccessTests.Tests
{
	[ TestFixture ]
	internal sealed class FbaInventoryTests: TestsBase
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

			inventory.Count().Should().BeGreaterThan( 0 );
		}

		[ Test ]
		public void GetFbaInventoryByOneMarketplace()
		{
			var inventoryCollection = new Dictionary< string, List< InventorySupply > >();

			var marketplaces = this.ClientConfig.ParseMarketplaces();

			foreach( var amazonMarketplace in marketplaces.Marketplaces )
			{
				var service = this.AmazonFactory.CreateService( this.ClientConfig.SellerId, this.ClientConfig.MwsAuthToken, new AmazonMarketplaces( amazonMarketplace ) );
				var inventory = service.GetFbaInventory();
				this.SaveToFile( "FbaInventory_" + amazonMarketplace.MarketplaceId + ".txt", inventory.ToList() );

				inventory = this.ReadFromFile< List< InventorySupply > >( "FbaInventory_" + amazonMarketplace.MarketplaceId + ".txt" );
				inventoryCollection.Add( amazonMarketplace.MarketplaceId, inventory );

				//inventory.Count().Should().BeGreaterThan( 0 );
			}

			var megaJoin = ( from marketplace1 in inventoryCollection[ marketplaces.Marketplaces[ 0 ].MarketplaceId ]
				join marketplace2 in inventoryCollection[ marketplaces.Marketplaces[ 1 ].MarketplaceId ] on marketplace1.SellerSKU equals marketplace2.SellerSKU
				join marketplace3 in inventoryCollection[ marketplaces.Marketplaces[ 2 ].MarketplaceId ] on marketplace1.SellerSKU equals marketplace3.SellerSKU
				join marketplace4 in inventoryCollection[ marketplaces.Marketplaces[ 3 ].MarketplaceId ] on marketplace1.SellerSKU equals marketplace4.SellerSKU
				join marketplace5 in inventoryCollection[ marketplaces.Marketplaces[ 4 ].MarketplaceId ] on marketplace1.SellerSKU equals marketplace5.SellerSKU
				join marketplace6 in inventoryCollection[ marketplaces.Marketplaces[ 5 ].MarketplaceId ] on marketplace1.SellerSKU equals marketplace6.SellerSKU
				select new { marketplace1, marketplace2, marketplace3, marketplace4, marketplace5, marketplace6 } ).ToList();

			var diff = megaJoin.Where( x =>
				x.marketplace1.TotalSupplyQuantity != x.marketplace2.TotalSupplyQuantity ||
				x.marketplace1.TotalSupplyQuantity != x.marketplace3.TotalSupplyQuantity ||
				x.marketplace1.TotalSupplyQuantity != x.marketplace4.TotalSupplyQuantity ||
				x.marketplace1.TotalSupplyQuantity != x.marketplace5.TotalSupplyQuantity ||
				x.marketplace1.TotalSupplyQuantity != x.marketplace6.TotalSupplyQuantity ||
				x.marketplace2.TotalSupplyQuantity != x.marketplace3.TotalSupplyQuantity ||
				x.marketplace2.TotalSupplyQuantity != x.marketplace4.TotalSupplyQuantity ||
				x.marketplace2.TotalSupplyQuantity != x.marketplace5.TotalSupplyQuantity ||
				x.marketplace2.TotalSupplyQuantity != x.marketplace6.TotalSupplyQuantity ||
				x.marketplace3.TotalSupplyQuantity != x.marketplace4.TotalSupplyQuantity ||
				x.marketplace3.TotalSupplyQuantity != x.marketplace5.TotalSupplyQuantity ||
				x.marketplace3.TotalSupplyQuantity != x.marketplace6.TotalSupplyQuantity ||
				x.marketplace4.TotalSupplyQuantity != x.marketplace5.TotalSupplyQuantity ||
				x.marketplace4.TotalSupplyQuantity != x.marketplace6.TotalSupplyQuantity ||
				x.marketplace5.TotalSupplyQuantity != x.marketplace6.TotalSupplyQuantity
				).ToList();
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

			inventory.Count.Should().BeGreaterThan( 0 );
		}

		[ Test ]
		public void GetDetailedFbaInventoryWithArchived()
		{
			var service = this.AmazonFactory.CreateService( this.ClientConfig.SellerId, this.ClientConfig.MwsAuthToken, this.ClientConfig.ParseMarketplaces() );
			var inventory = service.GetDetailedFbaInventory( true );

			inventory.Count.Should().BeGreaterThan( 0 );
		}
	}
}