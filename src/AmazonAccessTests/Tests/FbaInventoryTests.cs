using System.Collections.Generic;
using System.Linq;
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
			List< InventorySupply > inventory = null;
			//inventory = service.GetFbaInventory();
			//this.SaveToFile( "FbaInventory.txt", inventory );
			inventory = this.ReadFromFile< List< InventorySupply > >( "FbaInventory.txt" );
			var notEmpty = inventory.Where( x => this.IsNotEmpty( x ) ).ToList();

			inventory.Count().Should().BeGreaterThan( 0 );
		}

		[ Test ]
		public void GetFbaInventoryByOneMarketplace()
		{
			var inventoryList = new List< List< InventorySupply > >();
			var inventoryDic = new Dictionary< string, List< InventorySupply > >();
			var notEmptyDic = new Dictionary< string, List< InventorySupply > >();

			var marketplaces = this.ClientConfig.ParseMarketplaces();
			
			foreach( var amazonMarketplace in marketplaces.Marketplaces )
			{
				List< InventorySupply > inventory = null;
				var name = string.Format( "{0}-{1}", amazonMarketplace.CountryCode, amazonMarketplace.MarketplaceId );
				var fileName = string.Format( "FbaInventory_{0}.txt", name );
				var service = this.AmazonFactory.CreateService( this.ClientConfig.SellerId, this.ClientConfig.MwsAuthToken, new AmazonMarketplaces( amazonMarketplace ) );

				inventory = service.GetFbaInventory();
				this.SaveToFile( fileName, inventory.ToList() );

				inventory = this.ReadFromFile< List< InventorySupply > >( fileName );
				inventoryList.Add( inventory );
				inventoryDic.Add( name, inventory );
				notEmptyDic.Add( name, inventory.Where( x => this.IsNotEmpty( x ) ).ToList() );

				//inventory.Count().Should().BeGreaterThan( 0 );
			}

			var megaJoin = ( from marketplace0 in inventoryList[ 0 ]
				join marketplace1 in inventoryList[ 1 ] on marketplace0.SellerSKU equals marketplace1.SellerSKU
				join marketplace2 in inventoryList[ 2 ] on marketplace0.SellerSKU equals marketplace2.SellerSKU
				join marketplace3 in inventoryList[ 3 ] on marketplace0.SellerSKU equals marketplace3.SellerSKU
				join marketplace4 in inventoryList[ 4 ] on marketplace0.SellerSKU equals marketplace4.SellerSKU
				join marketplace5 in inventoryList[ 5 ] on marketplace0.SellerSKU equals marketplace5.SellerSKU
				join marketplace6 in inventoryList[ 6 ] on marketplace0.SellerSKU equals marketplace6.SellerSKU
				join marketplace7 in inventoryList[ 7 ] on marketplace0.SellerSKU equals marketplace7.SellerSKU
				select new { marketplace0, marketplace1, marketplace2, marketplace3, marketplace4, marketplace5, marketplace6, marketplace7 } ).ToList();

			var usDiff = megaJoin.Where( sku => this.IsNotEquals( sku.marketplace0, sku.marketplace2, sku.marketplace6 ) ).ToList();
			//var usDiff2 = megaJoin.Where( sku => this.IsNotEquals( sku.marketplace1, sku.marketplace2 ) ).ToList();
			//var usDiff3 = megaJoin.Where( sku => this.IsNotEquals( sku.marketplace3, sku.marketplace4 ) ).ToList();
			//var usDiff4 = megaJoin.Where( sku => this.IsNotEquals( sku.marketplace1, sku.marketplace3 ) ).ToList();
			//var usDiff5 = megaJoin.Where( sku => this.IsNotEquals( sku.marketplace2, sku.marketplace3 ) ).ToList();
			//var usDiff6 = megaJoin.Where( sku => this.IsNotEquals( sku.marketplace1, sku.marketplace4 ) ).ToList();

			var caDiff = megaJoin.Where( sku => this.IsNotEquals( sku.marketplace3, sku.marketplace7 ) ).ToList();
			//var diff = megaJoin.Where( sku => this.IsNotEquals( sku.marketplace1, sku.marketplace2, sku.marketplace3, sku.marketplace4, sku.marketplace5, sku.marketplace6 ) ).ToList();

			//var usDiff = megaJoin.Where( sku => this.IsNotEquals( sku.marketplace1, sku.marketplace4 ) ).ToList();
			//var caDiff = megaJoin.Where( sku => this.IsNotEquals( sku.marketplace3, sku.marketplace5 ) ).ToList();
			//var diff = megaJoin.Where( sku => this.IsNotEquals( sku.marketplace1, sku.marketplace2, sku.marketplace3, sku.marketplace4, sku.marketplace5 ) ).ToList();

			var someItems = inventoryList[ 0 ].Where( x => !inventoryList[ 6 ].Any( x2 => x2.SellerSKU.Equals( x.SellerSKU ) ) ).ToList();
			var someItems2 = inventoryList[ 6 ].Where( x => !inventoryList[ 0 ].Any( x2 => x2.SellerSKU.Equals( x.SellerSKU ) ) ).ToList();
			this.SaveToFile( "someItems.txt", someItems );
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

		#region Misc
		private bool IsNotEmpty( params InventorySupply[] objs )
		{
			return objs.Any( obj => obj.TotalSupplyQuantity > 0 || obj.InStockSupplyQuantity > 0 );
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
		#endregion
	}
}