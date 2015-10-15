using System;
using System.Collections.Generic;
using AmazonAccess.Services.FbaInventoryServiceMws.Model;
using AmazonAccess.Services.MarketplaceWebServiceFeedsReports.ReportModel;
using AmazonAccess.Services.MarketplaceWebServiceOrders.Model;

namespace AmazonAccess
{
	public interface IAmazonService
	{
		/// <summary>
		/// This operation takes up to 50 order ids and returns the corresponding orders.
		/// </summary>
		/// <param name="ids"></param>
		/// <returns></returns>
		IEnumerable< ComposedOrder > GetOrdersById( List< string > ids );

		IEnumerable< ComposedOrder > GetOrders( DateTime dateFrom, DateTime dateTo );
		//Task<IEnumerable<ComposedOrder>> GetOrdersAsync(DateTime dateFrom, DateTime dateTo);

		bool IsOrdersReceived( DateTime? dateFrom = null, DateTime? dateTo = null );

		void UpdateInventory( IEnumerable< AmazonInventoryItem > inventoryItems );
		//Task<IList<ProductUpdateQtyResult>> UpdateInventoryAsync(IEnumerable<ProductQuantityParams> products);

		IEnumerable< InventorySupply > GetFbaInventory();
		bool IsFbaInventoryReceived();
		
		IEnumerable< FbaManageInventory > GetDetailedFbaInventory();

		string GetMwsAuthToken();
	}
}