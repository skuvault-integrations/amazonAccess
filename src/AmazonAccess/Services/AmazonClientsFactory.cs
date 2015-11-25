using AmazonAccess.Models;
using AmazonAccess.Services.Common;
using AmazonAccess.Services.FbaInventoryServiceMws;
using AmazonAccess.Services.MarketplaceWebServiceFeedsReports;
using AmazonAccess.Services.MarketplaceWebServiceOrders;
using AmazonAccess.Services.MarketplaceWebServiceSellers;
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

		public IFbaInventoryServiceMws CreateFbaInventoryClient()
		{
			var config = new FbaInventoryServiceMwsConfig { ServiceURL = this._credentials.AmazonMarketplaces.FbaInventoryServiceUrl };
			config.SetUserAgentHeader( "C#", "-1", "3" );

			return new FbaInventoryServiceMwsClient( this._credentials.AccessKeyId, this._credentials.SecretAccessKeyId, config );
		}

		public IMarketplaceWebServiceFeedsReports CreateFeedsReportsClient()
		{
			var config = new MarketplaceWebServiceFeedsReportsConfig { ServiceURL = this._credentials.AmazonMarketplaces.FeedsServiceUrl, MaxErrorRetry = 4 };
			config.SetUserAgentHeader( "C#", "-1", "3" );

			return new MarketplaceWebServiceFeedsReportsClient( this._credentials.AccessKeyId, this._credentials.SecretAccessKeyId, config );
		}

		public IMarketplaceWebServiceOrders CreateOrdersClient( string applicationName, string applicationVersion )
		{
			var config = new MarketplaceWebServiceOrdersConfig { ServiceURL = this._credentials.AmazonMarketplaces.OrdersServiceUrl };

			return new MarketplaceWebServiceOrdersClient( applicationName, applicationVersion, this._credentials.AccessKeyId, this._credentials.SecretAccessKeyId, config );
		}

		public IMarketplaceWebServiceSellers CreateSellersClient()
		{
			var config = new MwsConfig { ServiceURL = this._credentials.AmazonMarketplaces.SellersServiceUrl };
			config.SetUserAgentHeader( "C#", "-1", "3" );

			return new MarketplaceWebServiceSellersClient( this._credentials.AccessKeyId, this._credentials.SecretAccessKeyId, config );
		}
	}
}