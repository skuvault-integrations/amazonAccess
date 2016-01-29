using System;
using System.Collections.Generic;
using AmazonAccess.Services.FbaInventory.Model;
using AmazonAccess.Services.FeedsReports.Model;
using AmazonAccess.Services.FeedsReports.ReportModel;
using AmazonAccess.Services.Orders.Model;
using AmazonAccess.Services.Products.Model;
using AmazonAccess.Services.Sellers.Model;

namespace AmazonAccess
{
	public interface IAmazonService
	{
		/// <summary>
		/// This operation takes up to 50 order ids and returns the corresponding orders.
		/// </summary>
		/// <param name="ids"></param>
		/// <param name="processOrderAction"></param>
		/// <returns></returns>
		int GetOrdersById( List< string > ids, Action< ComposedOrder > processOrderAction );

		int GetOrders( DateTime dateFrom, DateTime dateTo, Action< ComposedOrder > processOrderAction );
		bool IsOrdersReceived( DateTime? dateFrom = null, DateTime? dateTo = null );

		List< string > GetProductsBySkus( List< string > skus, Action< Product > processProductAction );
		IEnumerable< FbaManageInventory > GetProducts();

		void UpdateInventory( IEnumerable< AmazonInventoryItem > inventoryItems );

		IEnumerable< FbaManageInventory > GetDetailedFbaInventory();
		IEnumerable< InventorySupply > GetFbaInventory();
		bool IsFbaInventoryReceived();

		MarketplaceParticipations GetMarketplaceParticipations();
	}
}