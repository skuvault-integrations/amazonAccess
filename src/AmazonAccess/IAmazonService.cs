using System;
using System.Collections.Generic;
using AmazonAccess.Services.FbaInventoryServiceMws.Model;
using AmazonAccess.Services.MarketplaceWebServiceOrders.Model;

namespace AmazonAccess
{
	public interface IAmazonService
	{
		IEnumerable< ComposedOrder > GetOrders( DateTime dateFrom, DateTime dateTo );
		//Task<IEnumerable<ComposedOrder>> GetOrdersAsync(DateTime dateFrom, DateTime dateTo);

		void UpdateInventory( IEnumerable< AmazonInventoryItem > inventoryItems );
		//Task<IList<ProductUpdateQtyResult>> UpdateInventoryAsync(IEnumerable<ProductQuantityParams> products);

		IEnumerable< InventorySupply > GetInventory();
		//Task<IEnumerable<InventorySupply>> GetInventoryAsync();

		IEnumerable< InventorySupply > GetFbaInventory();
	}
}