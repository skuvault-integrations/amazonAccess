using AmazonAccess.Services.FbaInventory;
using AmazonAccess.Services.FeedsReports;
using AmazonAccess.Services.Orders;
using AmazonAccess.Services.Sellers;

namespace AmazonAccess.Services
{
	public interface IAmazonClientsFactory
	{
		IFbaInventoryServiceClient CreateFbaInventoryClient();
		IFeedsReportsServiceClient CreateFeedsReportsClient();
		IOrdersServiceClient CreateOrdersClient();
		ISellersServiceClient CreateSellersClient();
	}
}