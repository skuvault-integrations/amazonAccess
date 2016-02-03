using System.Collections.Concurrent;
using System.Collections.Generic;
using AmazonAccess.Services.Products.Model;
using FluentAssertions;
using NUnit.Framework;

namespace AmazonAccessTests.Products
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
				"testsku1", "testsku3", "mxczxcvdsf", "VK16AZN_KIT", "VK16AZN", "4GBDGSUSB2", "PKAMZNCADIR-SMPL32",
				"PKAMZNCADIR-SMPL4", "TC-N7DR-TVNA", "8gbpkbx", "1xPK8Store"
			};
			var products = new ConcurrentBag< Product >();

			var result = service.GetProductsBySkus( skus, product => products.Add( product ) );
			result.Should().BeNullOrEmpty();
		}

		[ Test ]
		public void GetActiveProducts()
		{
			var service = this.AmazonFactory.CreateService( this.ClientConfig.SellerId, this.ClientConfig.MwsAuthToken, this.ClientConfig.ParseMarketplaces() );

			var result = service.GetActiveProducts();
			result.Should().NotBeNullOrEmpty();
		}

		[ Test ]
		public void GetOpenProducts()
		{
			var service = this.AmazonFactory.CreateService( this.ClientConfig.SellerId, this.ClientConfig.MwsAuthToken, this.ClientConfig.ParseMarketplaces() );

			var result = service.GetOpenProducts();
			result.Should().NotBeNullOrEmpty();
		}
	}
}