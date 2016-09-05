using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using AmazonAccess.Models;
using AmazonAccess.Services.FbaInventory.Model;
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
			this.SaveToFile( "FbaInventory.txt", inventory );

			inventory.Count().Should().BeGreaterThan( 0 );
		}

		[ Test ]
		public void GetFbaInventoryByOneMarketplace()
		{
			var inventoryCollection = new Dictionary< string, List< InventorySupply > >();

			var marketplaces = this.ClientConfig.ParseMarketplaces();

			foreach( var amazonMarketplace in marketplaces.Marketplaces )
			{
				var fileName = string.Format( "FbaInventory_{0}-{1}.txt", amazonMarketplace.CountryCode, amazonMarketplace.MarketplaceId );
				var service = this.AmazonFactory.CreateService( this.ClientConfig.SellerId, this.ClientConfig.MwsAuthToken, new AmazonMarketplaces( amazonMarketplace ) );

				var inventory = service.GetFbaInventory();
				this.SaveToFile( fileName, inventory.ToList() );

				inventory = this.ReadFromFile< List< InventorySupply > >( fileName );
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

			var usDiff = megaJoin.Where( sku => this.IsNotEquals( sku.marketplace1, sku.marketplace2, sku.marketplace3, sku.marketplace4 ) ).ToList();
			var usDiff2 = megaJoin.Where( sku => this.IsNotEquals( sku.marketplace1, sku.marketplace2 ) ).ToList();
			var usDiff3 = megaJoin.Where( sku => this.IsNotEquals( sku.marketplace3, sku.marketplace4 ) ).ToList();
			var usDiff4 = megaJoin.Where( sku => this.IsNotEquals( sku.marketplace1, sku.marketplace3 ) ).ToList();
			var usDiff5 = megaJoin.Where( sku => this.IsNotEquals( sku.marketplace2, sku.marketplace3 ) ).ToList();
			var usDiff6 = megaJoin.Where( sku => this.IsNotEquals( sku.marketplace1, sku.marketplace4 ) ).ToList();

			var caDiff = megaJoin.Where( sku => this.IsNotEquals( sku.marketplace5, sku.marketplace6 ) ).ToList();
			var diff = megaJoin.Where( sku => this.IsNotEquals( sku.marketplace1, sku.marketplace2, sku.marketplace3, sku.marketplace4, sku.marketplace5, sku.marketplace6 ) ).ToList();

			//var usDiff = megaJoin.Where( sku => this.IsNotEquals( sku.marketplace1, sku.marketplace4 ) ).ToList();
			//var caDiff = megaJoin.Where( sku => this.IsNotEquals( sku.marketplace3, sku.marketplace5 ) ).ToList();
			//var diff = megaJoin.Where( sku => this.IsNotEquals( sku.marketplace1, sku.marketplace2, sku.marketplace3, sku.marketplace4, sku.marketplace5 ) ).ToList();
		}

		private bool IsNotEquals( params InventorySupply[] objs )
		{
			for( var i = 0; i < objs.Length; i++ )
			{
				for( var j = i + 1; j < objs.Length; j++ )
				{
					if( this.IsNotEquals( objs[ i ], objs[ j ] ) )
						return true;
				}
			}
			return false;
		}

		private bool IsNotEquals( InventorySupply obj1, InventorySupply obj2 )
		{
			return obj1.TotalSupplyQuantity != obj2.TotalSupplyQuantity || obj1.InStockSupplyQuantity != obj2.InStockSupplyQuantity;
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

		[ Test ]
		public void GetFbaMultiCountryInventory()
		{
			var service = this.AmazonFactory.CreateService( this.ClientConfig.SellerId, this.ClientConfig.MwsAuthToken, this.ClientConfig.ParseMarketplaces() );
			var inventory = service.GetFbaMultiCountryInventory();
			this.SaveToFile( "FbaMultiCountryInventory.txt", inventory );

			inventory.Count.Should().BeGreaterThan( 0 );
		}

		[ Test ]
		public void GetFbaFulfilledInventory()
		{
			var service = this.AmazonFactory.CreateService( this.ClientConfig.SellerId, this.ClientConfig.MwsAuthToken, this.ClientConfig.ParseMarketplaces() );
			var inventory = service.GetFbaFulfilledInventory();
			this.SaveToFile( "FbaFulfilledInventory.txt", inventory );

			inventory.Count.Should().BeGreaterThan( 0 );
		}
	}
}