﻿using System.Collections.Concurrent;
using System.Collections.Generic;
using AmazonAccess.Services.FeedsReports.ReportModel;
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
				//"4GBDGSUSB2", "PKAMZNCADIR-SMPL32", "PKAMZNCADIR-SMPL4", "TC-N7DR-TVNA", "VK16AZN", "VK16AZN_KIT", "8gbpkbx", "PKAMZNCADIR-004",
				//"testsku1",
				"testsku3",
				//"mxczxcvdsf", "1xPK8Store"
			};
			var products = new ConcurrentBag< Product >();

			var result = service.GetProductsBySkus( skus, true, product => products.Add( product ) );
			result.Should().NotBeEmpty();
		}

		[ Test ]
		public void GetActiveProducts()
		{
			var service = this.AmazonFactory.CreateService( this.ClientConfig.SellerId, this.ClientConfig.MwsAuthToken, this.ClientConfig.ParseMarketplaces() );

			var result = service.GetActiveProducts( true );
			result.Should().NotBeEmpty();
		}

		[ Test ]
		public void GetActiveProducts2()
		{
			var service = this.AmazonFactory.CreateService( this.ClientConfig.SellerId, this.ClientConfig.MwsAuthToken, this.ClientConfig.ParseMarketplaces() );
			var products = new ConcurrentBag< ProductShort >();

			service.GetActiveProducts( false, ( marketplace, product ) => products.Add( product ) );
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
		public void GetOpenProducts2()
		{
			var service = this.AmazonFactory.CreateService( this.ClientConfig.SellerId, this.ClientConfig.MwsAuthToken, this.ClientConfig.ParseMarketplaces() );
			var products = new ConcurrentBag< ProductShort >();

			service.GetOpenProducts( true, ( marketplace, product ) => products.Add( product ) );
			products.Should().NotBeEmpty();
		}
	}
}