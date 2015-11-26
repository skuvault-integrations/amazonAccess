using AmazonAccess.Services.FbaInventory;
using AmazonAccess.Services.MarketplaceWebServiceFeedsReports;
using AmazonAccess.Services.Orders;
using AmazonAccess.Services.Sellers;

namespace AmazonAccess.Services
{
	public interface IAmazonClientsFactory
	{
		IFbaInventoryService CreateFbaInventoryClient();
		IMarketplaceWebServiceFeedsReports CreateFeedsReportsClient();
		IOrdersServiceClient CreateOrdersClient();
		ISellersService CreateSellersClient();
	}
}