using AmazonAccess.Services.FbaInventoryServiceMws;
using AmazonAccess.Services.MarketplaceWebServiceOrders;
using MarketplaceWebService;

namespace AmazonAccess.Services
{
	public interface IAmazonClientsFactory
	{
		IFbaInventoryServiceMws CreateFbaInventoryClient();
		IMarketplaceWebService CreateFeedsReportsClient();
		IMarketplaceWebServiceOrders CreateOrdersClient( string applicationName, string applicationVersion );
	}
}