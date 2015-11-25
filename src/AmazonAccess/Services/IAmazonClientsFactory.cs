using AmazonAccess.Services.FbaInventory;
using AmazonAccess.Services.MarketplaceWebServiceFeedsReports;
using AmazonAccess.Services.MarketplaceWebServiceOrders;
using AmazonAccess.Services.MarketplaceWebServiceSellers;

namespace AmazonAccess.Services
{
	public interface IAmazonClientsFactory
	{
		IFbaInventoryService CreateFbaInventoryClient();
		IMarketplaceWebServiceFeedsReports CreateFeedsReportsClient();
		IMarketplaceWebServiceOrders CreateOrdersClient( string applicationName, string applicationVersion );
		IMarketplaceWebServiceSellers CreateSellersClient();
	}
}