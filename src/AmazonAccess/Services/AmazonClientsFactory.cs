using AmazonAccess.Models;
using AmazonAccess.Services.FbaInventoryServiceMws;
using AmazonAccess.Services.MarketplaceWebServiceFeeds;
using AmazonAccess.Services.MarketplaceWebServiceOrders;
using CuttingEdge.Conditions;
using MarketplaceWebService;

namespace AmazonAccess.Services
{
	public class AmazonClientsFactory : IAmazonClientsFactory
	{
		private readonly AmazonCredentials _credentials;

		public AmazonClientsFactory( AmazonCredentials credentials )
		{
			Condition.Requires( credentials, "credentials" ).IsNotNull();

			this._credentials = credentials;
		}

		public IFbaInventoryServiceMws CreateFbaInventoryClient()
		{
			var config = new FbaInventoryServiceMwsConfig { ServiceURL = "https://mws.amazonservices.com/FulfillmentInventory/2010-10-01/" };
			config.SetUserAgentHeader( "C#", "-1", "3" );

			return new FbaInventoryServiceMwsClient( this._credentials.AccessKeyId, this._credentials.SecretAccessKeyId, config );
		}

		public IMarketplaceWebService CreateFeedsReportsClient()
		{
			var config = new MarketplaceWebServiceConfig { ServiceURL = "https://mws.amazonservices.com" };
			config.SetUserAgentHeader( "C#", "-1", "3" );

			return new MarketplaceWebServiceClient( this._credentials.AccessKeyId, this._credentials.SecretAccessKeyId, config );
		}

		public IMarketplaceWebServiceOrders CreateOrdersClient( string applicationName, string applicationVersion )
		{
			var config = new MarketplaceWebServiceOrdersConfig { ServiceURL = "https://mws.amazonservices.com/Orders/2011-01-01/" };

			return new MarketplaceWebServiceOrdersClient( applicationName, applicationVersion, this._credentials.AccessKeyId, this._credentials.SecretAccessKeyId, config );
		}
	}
}