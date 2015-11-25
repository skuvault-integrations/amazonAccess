using AmazonAccess.Services.FbaInventory;
using AmazonAccess.Services.MarketplaceWebServiceFeedsReports;
using AmazonAccess.Services.MarketplaceWebServiceOrders;
using AmazonAccess.Services.Sellers;

namespace AmazonAccess.Services
{
	public interface IAmazonClientsFactory
	{
		IFbaInventoryService CreateFbaInventoryClient();
		IMarketplaceWebServiceFeedsReports CreateFeedsReportsClient();
		IMarketplaceWebServiceOrders CreateOrdersClient( string applicationName, string applicationVersion );
		ISellersService CreateSellersClient();
	}
}