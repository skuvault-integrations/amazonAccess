using AmazonAccess.Models;
using AmazonAccess.Services.Common;
using AmazonAccess.Services.FbaInventory;
using AmazonAccess.Services.MarketplaceWebServiceFeedsReports;
using AmazonAccess.Services.Orders;
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

		public IFbaInventoryService CreateFbaInventoryClient()
		{
			var config = new MwsConfig { ServiceURL = this._credentials.AmazonMarketplaces.FbaInventoryServiceUrl };
			config.SetUserAgentHeader( "C#", "-1", "3" );

			return new FbaInventoryServiceClient( this._credentials.AccessKeyId, this._credentials.SecretAccessKeyId, "SkuVault", "1.0", config );
		}

		public IMarketplaceWebServiceFeedsReports CreateFeedsReportsClient()
		{
			var config = new MarketplaceWebServiceFeedsReportsConfig { ServiceURL = this._credentials.AmazonMarketplaces.FeedsServiceUrl, MaxErrorRetry = 4 };
			config.SetUserAgentHeader( "C#", "-1", "3" );

			return new MarketplaceWebServiceFeedsReportsClient( this._credentials.AccessKeyId, this._credentials.SecretAccessKeyId, config );
		}

		public IOrdersServiceClient CreateOrdersClient()
		{
			var config = new MwsConfig { ServiceURL = this._credentials.AmazonMarketplaces.OrdersServiceUrl };
			config.SetUserAgentHeader( "C#", "-1", "3" );

			return new OrdersServiceClient( this._credentials.AccessKeyId, this._credentials.SecretAccessKeyId, "SkuVault", "1.0", config );
		}

		public ISellersService CreateSellersClient()
		{
			var config = new MwsConfig { ServiceURL = this._credentials.AmazonMarketplaces.SellersServiceUrl };
			config.SetUserAgentHeader( "C#", "-1", "3" );

			return new SellersServiceClient( this._credentials.AccessKeyId, this._credentials.SecretAccessKeyId, "SkuVault", "1.0", config );
		}
	}
}