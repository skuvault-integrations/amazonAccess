using AmazonAccess.Services.FbaInventoryServiceMws;
using AmazonAccess.Services.MarketplaceWebServiceFeeds;
using AmazonAccess.Services.MarketplaceWebServiceOrders;
using MarketplaceWebService;

namespace AmazonAccess.Services
{
	public interface IAmazonClientsFactory
	{
		IFbaInventoryServiceMws CreateFbaInventoryClient();
		IMarketplaceWebServiceFeeds CreateFeedsReportsClient();
		IMarketplaceWebServiceOrders CreateOrdersClient( string applicationName, string applicationVersion );
	}
}