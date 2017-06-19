using System;
using AmazonAccess.Models;
using AmazonAccess.Services.Common;
using AmazonAccess.Services.FbaInventory;
using AmazonAccess.Services.FBAInbound;
using AmazonAccess.Services.FeedsReports;
using AmazonAccess.Services.Orders;
using AmazonAccess.Services.Products;
using AmazonAccess.Services.Sellers;
using CuttingEdge.Conditions;

namespace AmazonAccess.Services
{
	public sealed class AmazonClientsFactory: IAmazonClientsFactory
	{
		private readonly AmazonCredentials _credentials;

		public AmazonClientsFactory( AmazonCredentials credentials )
		{
			Condition.Requires( credentials, "credentials" ).IsNotNull();

			this._credentials = credentials;
		}

		public IFbaInventoryServiceClient CreateFbaInventoryClient()
		{
			var connection = new MwsConnection
			{
				AwsAccessKeyId = this._credentials.AccessKeyId,
				AwsSecretKeyId = this._credentials.SecretAccessKeyId,
				ServiceURL = this._credentials.AmazonMarketplaces.FbaInventoryServiceUrl
			};
			connection.SetUserAgent( "SkuVault", "1.0", "C#" );
			return new FbaInventoryServiceClient( connection );
		}

		public IFbaInboundServiceClient CreateFbaInboundClient()
		{
			var connection = new MwsConnection
			{
				AwsAccessKeyId = this._credentials.AccessKeyId,
				AwsSecretKeyId = this._credentials.SecretAccessKeyId,
				ServiceURL = this._credentials.AmazonMarketplaces.FbaInboundServiceUrl
			};
			connection.SetUserAgent( "SkuVault", "1.0", "C#" );
			return new FbaInboundServiceClient( connection );
		}

		public IFeedsReportsServiceClient CreateFeedsReportsClient()
		{
			var connection = new MwsConnection
			{
				AwsAccessKeyId = this._credentials.AccessKeyId,
				AwsSecretKeyId = this._credentials.SecretAccessKeyId,
				ServiceURL = this._credentials.AmazonMarketplaces.FeedsServiceUrl,
				ServiceVersion = "2009-01-01"
			};
			connection.SetUserAgent( "SkuVault", "1.0", "C#" );
			return new FeedsReportsServiceClient( connection );
		}

		public IOrdersServiceClient CreateOrdersClient()
		{
			var connection = new MwsConnection
			{
				AwsAccessKeyId = this._credentials.AccessKeyId,
				AwsSecretKeyId = this._credentials.SecretAccessKeyId,
				ServiceURL = this._credentials.AmazonMarketplaces.OrdersServiceUrl
			};
			connection.SetUserAgent( "SkuVault", "1.0", "C#" );
			return new OrdersServiceClient( connection );
		}

		public IProductsServiceClient CreateProductsClient()
		{
			var connection = new MwsConnection
			{
				AwsAccessKeyId = this._credentials.AccessKeyId,
				AwsSecretKeyId = this._credentials.SecretAccessKeyId,
				ServiceURL = this._credentials.AmazonMarketplaces.ProductsServiceUrl
			};
			connection.SetUserAgent( "SkuVault", "1.0", "C#" );
			return new ProductsServiceClient( connection );
		}

		public ISellersServiceClient CreateSellersClient()
		{
			var connection = new MwsConnection
			{
				AwsAccessKeyId = this._credentials.AccessKeyId,
				AwsSecretKeyId = this._credentials.SecretAccessKeyId,
				ServiceURL = this._credentials.AmazonMarketplaces.SellersServiceUrl
			};
			connection.SetUserAgent( "SkuVault", "1.0", "C#" );
			return new SellersServiceClient( connection );
		}
	}
}