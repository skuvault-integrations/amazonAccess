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
		/// <param name="processOrderAction">Order</param>
		/// <returns></returns>
		int GetOrdersById( List< string > ids, Action< ComposedOrder > processOrderAction );

		/// <summary>
		/// Get Orders
		/// </summary>
		/// <param name="dateFrom"></param>
		/// <param name="dateTo"></param>
		/// <param name="processOrderAction">Order</param>
		/// <returns></returns>
		int GetOrders( DateTime dateFrom, DateTime dateTo, Action< ComposedOrder > processOrderAction );

		/// <summary>
		/// Is Orders Received
		/// </summary>
		/// <param name="dateFrom"></param>
		/// <param name="dateTo"></param>
		/// <returns></returns>
		bool IsOrdersReceived( DateTime? dateFrom = null, DateTime? dateTo = null );

		/// <summary>
		/// Get Products By Skus
		/// </summary>
		/// <param name="skus"></param>
		/// <param name="skipDuplicates"></param>
		/// <param name="processProductAction">Product</param>
		/// <returns>Marketplace and Product SKUs</returns>
		Dictionary< string, List< string > > GetProductsBySkus( List< string > skus, bool skipDuplicates, Action< Product > processProductAction );

		/// <summary>
		/// Get Products Inventory
		/// </summary>
		/// <param name="skipDuplicates"></param>
		/// <returns>Marketplace and Products</returns>
		List< ProductInventory > GetProductsInventory( bool skipDuplicates );

		/// <summary>
		/// Get Products Inventory
		/// </summary>
		/// <param name="skipDuplicates"></param>
		/// <returns>Marketplace and Products</returns>
		Dictionary< string, List< ProductInventory > > GetProductsInventoryByMarketplace( bool skipDuplicates );

		/// <summary>
		/// Get Products Inventory
		/// </summary>
		/// <param name="skipDuplicates"></param>
		/// <param name="processReportAction">Marketplace and Product</param>
		void GetProductsInventoryByMarketplace( bool skipDuplicates, Action< string, ProductInventory > processReportAction );

		/// <summary>
		/// Get Active Products
		/// </summary>
		/// <param name="skipDuplicates"></param>
		/// <returns>Marketplace and Products</returns>
		List< ProductShort > GetActiveProducts( bool skipDuplicates );

		/// <summary>
		/// Get Active Products
		/// </summary>
		/// <param name="skipDuplicates"></param>
		/// <returns>Marketplace and Products</returns>
		Dictionary< string, List< ProductShort > > GetActiveProductsByMarketplace( bool skipDuplicates );

		/// <summary>
		/// Get Active Products
		/// </summary>
		/// <param name="skipDuplicates"></param>
		/// <param name="processReportAction">Marketplace and Product</param>
		void GetActiveProductsByMarketplace( bool skipDuplicates, Action< string, ProductShort > processReportAction );

		/// <summary>
		/// Get Open Products
		/// </summary>
		/// <param name="skipDuplicates"></param>
		/// <returns>Marketplace and Products</returns>
		List< ProductShort > GetOpenProducts( bool skipDuplicates );

		/// <summary>
		/// Get Open Products
		/// </summary>
		/// <param name="skipDuplicates"></param>
		/// <returns>Marketplace and Products</returns>
		Dictionary< string, List< ProductShort > > GetOpenProductsByMarketplace( bool skipDuplicates );

		/// <summary>
		/// Get Open Products
		/// </summary>
		/// <param name="skipDuplicates"></param>
		/// <param name="processReportAction">Marketplace and Product</param>
		void GetOpenProductsByMarketplace( bool skipDuplicates, Action< string, ProductShort > processReportAction );

		void UpdateInventory( IEnumerable< AmazonInventoryItem > inventoryItems );

		List< FbaManageInventory > GetDetailedFbaInventory();
		List< InventorySupply > GetFbaInventory();
		bool IsFbaInventoryReceived();

		MarketplaceParticipations GetMarketplaceParticipations();
	}
}