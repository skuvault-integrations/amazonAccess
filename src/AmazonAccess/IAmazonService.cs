using System;
using System.Collections.Generic;
using AmazonAccess.Models;
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
		/// Is Orders Received
		/// </summary>
		/// <param name="dateFrom"></param>
		/// <param name="dateTo"></param>
		/// <returns></returns>
		bool TryGetOrders( DateTime? dateFrom = null, DateTime? dateTo = null );

		/// <summary>
		/// Get Orders
		/// </summary>
		/// <param name="dateFrom"></param>
		/// <param name="dateTo"></param>
		/// <param name="processOrderAction">Order</param>
		/// <returns></returns>
		int GetOrders( DateTime dateFrom, DateTime dateTo, Action< ComposedOrder > processOrderAction );

		/// <summary>
		/// Get Products By Skus
		/// </summary>
		/// <param name="skus"></param>
		/// <param name="skipDuplicates"></param>
		/// <param name="processProductAction">Product</param>
		/// <returns>Marketplace and Product SKUs</returns>
		Dictionary< AmazonMarketplace, List< string > > GetProductsBySkus( List< string > skus, bool skipDuplicates, Action< Product > processProductAction );

		/// <summary>
		/// Try Get Products Inventory
		/// </summary>
		/// <returns></returns>
		bool TryGetProductsInventory();

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
		Dictionary< AmazonMarketplace, List< ProductInventory > > GetProductsInventoryByMarketplace( bool skipDuplicates );

		/// <summary>
		/// Get Products Inventory
		/// </summary>
		/// <param name="skipDuplicates"></param>
		/// <param name="processReportAction">Marketplace and Product</param>
		void GetProductsInventoryByMarketplace( bool skipDuplicates, Action< AmazonMarketplace, ProductInventory > processReportAction );

		/// <summary>
		/// Try Get Active Products
		/// </summary>
		/// <returns></returns>
		bool TryGetActiveProducts();

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
		Dictionary< AmazonMarketplace, List< ProductShort > > GetActiveProductsByMarketplace( bool skipDuplicates );

		/// <summary>
		/// Get Active Products
		/// </summary>
		/// <param name="skipDuplicates"></param>
		/// <param name="processReportAction">Marketplace and Product</param>
		void GetActiveProductsByMarketplace( bool skipDuplicates, Action< AmazonMarketplace, ProductShort > processReportAction );

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
		Dictionary< AmazonMarketplace, List< ProductShort > > GetOpenProductsByMarketplace( bool skipDuplicates );

		/// <summary>
		/// Get Open Products
		/// </summary>
		/// <param name="skipDuplicates"></param>
		/// <param name="processReportAction">Marketplace and Product</param>
		void GetOpenProductsByMarketplace( bool skipDuplicates, Action< AmazonMarketplace, ProductShort > processReportAction );

		/// <summary>
		/// Update Inventory
		/// </summary>
		/// <param name="inventoryItems"></param>
		void UpdateInventory( IEnumerable< AmazonInventoryItem > inventoryItems );

		/// <summary>
		/// Is Fba Inventory Received (not using reports API)
		/// </summary>
		/// <returns></returns>
		bool TryGetFbaInventory();

		/// <summary>
		/// Get Fba Inventory (not using reports API)
		/// </summary>
		/// <returns></returns>
		List< InventorySupply > GetFbaInventory();

		/// <summary>
		/// Try Get Detailed Fba Inventory using reports API
		/// </summary>
		/// <param name="includeArchived">Include archived</param>
		/// <param name="dontSendMarketplaces">Amazon will use home marketplace</param>
		/// <returns></returns>
		bool TryGetDetailedFbaInventory( bool includeArchived = true, bool dontSendMarketplaces = false );

		/// <summary>
		/// Get Detailed Fba Inventory using reports API (returns inventory for each marketplace only in NA region)
		/// </summary>
		/// <param name="includeArchived">Include archived</param>
		/// <param name="dontSendMarketplaces">Amazon will use home marketplace</param>
		/// <returns></returns>
		List< FbaManageInventory > GetDetailedFbaInventory( bool includeArchived = true, bool dontSendMarketplaces = false );

		/// <summary>
		/// Try Get Detailed Fba Inventory by Marketplace using reports API
		/// </summary>
		/// <param name="includeArchived">Include archived</param>
		/// <returns></returns>
		bool TryGetDetailedFbaInventoryByMarketplace( bool includeArchived = true );

		/// <summary>
		/// Get Detailed Fba Inventory by Marketplace using reports API (returns inventory for each marketplace only in NA region)
		/// </summary>
		/// <param name="includeArchived"></param>
		/// <returns></returns>
		Dictionary< AmazonMarketplace, List< FbaManageInventory > > GetDetailedFbaInventoryByMarketplace( bool includeArchived = true );

		/// <summary>
		/// Try Get Fba Reserved Inventory
		/// </summary>
		/// <param name="dontSendMarketplaces"></param>
		/// <returns></returns>
		bool TryGetFbaReservedInventory( bool dontSendMarketplaces = false );

		/// <summary>
		/// Get Fba Reserved Inventory (returns inventory for each marketplace only in NA region)
		/// </summary>
		/// <param name="dontSendMarketplaces">Amazon will use home marketplace</param>
		/// <returns></returns>
		List< FbaReservedInventory > GetFbaReservedInventory( bool dontSendMarketplaces = false );

		/// <summary>
		/// Try Get Fba Reserved Inventory by Marketplace
		/// </summary>
		/// <returns></returns>
		bool TryGetFbaReservedInventoryByMarketplace();

		/// <summary>
		/// Get Fba Reserved Inventory by Marketplace (returns inventory for each marketplace only in NA region)
		/// </summary>
		/// <returns></returns>
		Dictionary< AmazonMarketplace, List< FbaReservedInventory > > GetFbaReservedInventoryByMarketplace();

		/// <summary>
		/// Get Fba Multi-Country Inventory Report (returns inventory for all marketplaces)
		/// </summary>
		/// <param name="dontSendMarketplaces">Amazon will use home marketplace</param>
		/// <returns></returns>
		List< FbaMultiCountryInventory > GetFbaMultiCountryInventory( bool dontSendMarketplaces = false );

		/// <summary>
		/// Get Fba Fulfilled Inventory Report (returns inventory for all marketplaces)
		/// </summary>
		/// <param name="dontSendMarketplaces">Amazon will use home marketplace</param>
		/// <returns></returns>
		List< FbaFulfilledInventory > GetFbaFulfilledInventory( bool dontSendMarketplaces = false );

		MarketplaceParticipations GetMarketplaceParticipations();
	}
}