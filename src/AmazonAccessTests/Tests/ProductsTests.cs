using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using AmazonAccess.Services.FeedsReports.ReportModel;
using AmazonAccess.Services.Products.Model;
using AmazonAccessTests.Misc;
using FluentAssertions;
using NUnit.Framework;

namespace AmazonAccessTests.Tests
{
	internal class ProductsTests: TestsBase
	{
		[ SetUp ]
		public void Init()
		{
		}

		[ Test ]
		public void GetProductsBySkus()
		{
			var service = this.AmazonFactory.CreateService( this.ClientConfig.SellerId, this.ClientConfig.MwsAuthToken, this.ClientConfig.ParseMarketplaces() );

			var skus = new List< string >
			{
				//"4GBDGSUSB2", "PKAMZNCADIR-SMPL32", "PKAMZNCADIR-SMPL4", "TC-N7DR-TVNA", "VK16AZN", "VK16AZN_KIT", "8gbpkbx", "PKAMZNCADIR-004",
				"testsku1",
				"testsku3",
				"mxczxcvdsf",
				"HC-063B-DJDU",
				//"1xPK8Store"
			};
			var products = new ConcurrentBag< Product >();

			var result = service.GetProductsBySkus( skus, false, product => products.Add( product ) );
			result.Should().NotBeEmpty();
		}

		[ Test ]
		public void GetProductsInventory()
		{
			var service = this.AmazonFactory.CreateService( this.ClientConfig.SellerId, this.ClientConfig.MwsAuthToken, this.ClientConfig.ParseMarketplaces( true ) );

			var result = service.GetProductsInventory( true );

			var rrr = result.Where( x => x.IsDefaultFulfillmentChannel ).ToList();
			var rrr2 = result.Where( x => !x.IsDefaultFulfillmentChannel ).ToList();
			result.Should().NotBeEmpty();
		}

		[ Test ]
		public void GetProductsInventoryByMarketplace()
		{
			var service = this.AmazonFactory.CreateService( this.ClientConfig.SellerId, this.ClientConfig.MwsAuthToken, this.ClientConfig.ParseMarketplaces() );

			var result = service.GetProductsInventoryByMarketplace( false );
			result.Should().NotBeEmpty();
		}

		[ Test ]
		public void GetProductsInventoryByMarketplace2()
		{
			var service = this.AmazonFactory.CreateService( this.ClientConfig.SellerId, this.ClientConfig.MwsAuthToken, this.ClientConfig.ParseMarketplaces() );
			var products = new ConcurrentBag< ProductInventory >();

			service.GetProductsInventoryByMarketplace( false, ( marketplace, product ) => products.Add( product ) );
			products.Should().NotBeEmpty();
		}

		[ Test ]
		public void GetActiveProducts()
		{
			var service = this.AmazonFactory.CreateService( this.ClientConfig.SellerId, this.ClientConfig.MwsAuthToken, this.ClientConfig.ParseMarketplaces() );

			var result = service.GetActiveProducts( false );
			result.Should().NotBeEmpty();
		}

		[ Test ]
		public void GetActiveProductsByMarketplace()
		{
			var service = this.AmazonFactory.CreateService( this.ClientConfig.SellerId, this.ClientConfig.MwsAuthToken, this.ClientConfig.ParseMarketplaces( true ) );

			var result = service.GetActiveProductsByMarketplace( false );
			foreach( var marketplace in result )
			{
				this.SaveToFile( $"GetActiveProductsByMarketplace_2_{marketplace.Key.MarketplaceId}.txt", marketplace.Value );
			}
			
			result.Should().NotBeEmpty();
		}

		[ Test ]
		public void GetActiveProductsByMarketplace2()
		{
			var service = this.AmazonFactory.CreateService( this.ClientConfig.SellerId, this.ClientConfig.MwsAuthToken, this.ClientConfig.ParseMarketplaces() );
			var products = new ConcurrentBag< ProductShort >();

			service.GetActiveProductsByMarketplace( false, ( marketplace, product ) => products.Add( product ) );
			products.Should().NotBeEmpty();
		}

		[ Test ]
		public void GetOpenProducts()
		{
			var service = this.AmazonFactory.CreateService( this.ClientConfig.SellerId, this.ClientConfig.MwsAuthToken, this.ClientConfig.ParseMarketplaces() );

			var result = service.GetOpenProducts( false );
			result.Should().NotBeEmpty();
		}

		[ Test ]
		public void GetOpenProductsByMarketplace()
		{
			var service = this.AmazonFactory.CreateService( this.ClientConfig.SellerId, this.ClientConfig.MwsAuthToken, this.ClientConfig.ParseMarketplaces() );

			var result = service.GetOpenProductsByMarketplace( false );
			result.Should().NotBeEmpty();
		}

		[ Test ]
		public void GetOpenProductsByMarketplace2()
		{
			var service = this.AmazonFactory.CreateService( this.ClientConfig.SellerId, this.ClientConfig.MwsAuthToken, this.ClientConfig.ParseMarketplaces() );
			var products = new ConcurrentBag< ProductShort >();

			service.GetOpenProductsByMarketplace( true, ( marketplace, product ) => products.Add( product ) );
			products.Should().NotBeEmpty();
		}

		[ Test ]
		public void FindProductsDiff()
		{
			var marketplaces = new List< string > { "2_A2EUQ1WTGCTBG2", "2_ATVPDKIKX0DER", "ATVPDKIKX0DER" };

			var products = new Dictionary< string, List< ProductShort > >();
			foreach( var marketplace in marketplaces )
			{
				var pr = this.ReadFromFile< List< ProductShort > >( $"GetActiveProductsByMarketplace_{marketplace}.txt" );
				products.Add( marketplace, pr );
			}

			var existsInNa = GetUniqueProducts( products, "2_ATVPDKIKX0DER", "ATVPDKIKX0DER", true );
			var existsInEu = GetUniqueProducts( products, "ATVPDKIKX0DER", "2_ATVPDKIKX0DER", true );
			var existsInBoth = GetUniqueProducts( products, "2_ATVPDKIKX0DER", "ATVPDKIKX0DER", false );

			products[ "2_ATVPDKIKX0DER" ].AddRange( products[ "2_A2EUQ1WTGCTBG2" ] );

			var existsInNa2 = GetUniqueProducts( products, "2_ATVPDKIKX0DER", "ATVPDKIKX0DER", true );
			var existsInEu2 = GetUniqueProducts( products, "ATVPDKIKX0DER", "2_ATVPDKIKX0DER", true );
			var existsInBoth2 = GetUniqueProducts( products, "2_ATVPDKIKX0DER", "ATVPDKIKX0DER", false );
		}

		private List< ProductShort > GetUniqueProducts( Dictionary< string, List< ProductShort > > products, string marketplace1, string marketplace2, bool isExistOnlyInFirst )
		{
			return ( from na in products[ marketplace1 ]
				join eu in products[ marketplace2 ] on na.SellerSku equals eu.SellerSku into eu
				where eu.Any() != isExistOnlyInFirst
				select na ).ToList();
		}
	}
}