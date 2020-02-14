using AmazonAccess.Services.FbaInventory;
using AmazonAccess.Services.FBAInbound;
using AmazonAccess.Services.FeedsReports;
using AmazonAccess.Services.Orders;
using AmazonAccess.Services.Products;
using AmazonAccess.Services.Sellers;
using AmazonAccess.Services.Finances;

namespace AmazonAccess.Services
{
	public interface IAmazonClientsFactory
	{
		IFbaInventoryServiceClient CreateFbaInventoryClient();
		IFeedsReportsServiceClient CreateFeedsReportsClient();
		IOrdersServiceClient CreateOrdersClient();
		IProductsServiceClient CreateProductsClient();
		ISellersServiceClient CreateSellersClient();
		IFbaInboundServiceClient CreateFbaInboundClient();
		IFinancesServiceClient CreateFinancesServiceClient();
	}
}