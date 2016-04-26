using System;
using System.Collections.Generic;
using System.Linq;
using AmazonAccess.Misc;
using AmazonAccess.Models;
using AmazonAccess.Services;
using AmazonAccess.Services.FbaInventory;
using AmazonAccess.Services.FbaInventory.Model;
using AmazonAccess.Services.FeedsReports;
using AmazonAccess.Services.FeedsReports.Model;
using AmazonAccess.Services.FeedsReports.ReportModel;
using AmazonAccess.Services.Orders;
using AmazonAccess.Services.Orders.Model;
using AmazonAccess.Services.Products;
using AmazonAccess.Services.Products.Model;
using AmazonAccess.Services.Sellers;
using AmazonAccess.Services.Sellers.Model;
using CuttingEdge.Conditions;
using Netco.Extensions;

namespace AmazonAccess
{
	public sealed class AmazonService: IAmazonService
	{
		private const int Updateitemslimit = 3000;
		private readonly AmazonCredentials _credentials;
		private readonly IAmazonClientsFactory _factory;

		public AmazonService( AmazonCredentials credentials )
		{
			Condition.Requires( credentials, "credentials" ).IsNotNull();

			this._credentials = credentials;
			this._factory = new AmazonClientsFactory( credentials );
		}

		#region Orders
		/// <summary>
		/// This operation takes up to 50 order ids and returns the corresponding orders.
		/// </summary>
		/// <param name="ids"></param>
		/// <param name="processOrderAction"></param>
		/// <returns></returns>
		public int GetOrdersById( List< string > ids, Action< ComposedOrder > processOrderAction )
		{
			var client = this._factory.CreateOrdersClient();
			var service = new OrdersByIdService( client, this._credentials );
			var ordersCount = service.LoadOrdersById( ids, processOrderAction, this.GetMarker() );
			return ordersCount;
		}

		public int GetOrders( DateTime dateFrom, DateTime dateTo, Action< ComposedOrder > processOrderAction )
		{
			var client = this._factory.CreateOrdersClient();
			var service = new OrdersService( client, this._credentials );
			var ordersCount = service.LoadOrders( dateFrom, dateTo, processOrderAction, this.GetMarker() );
			return ordersCount;
		}

		public bool IsOrdersReceived( DateTime? dateFrom = null, DateTime? dateTo = null )
		{
			dateFrom = dateFrom ?? DateTime.UtcNow.AddHours( -1 );
			dateTo = dateTo ?? DateTime.UtcNow.AddMinutes( -10 );

			var client = this._factory.CreateOrdersClient();
			var service = new OrdersService( client, this._credentials );
			return service.IsOrdersReceived( dateFrom.Value, dateTo.Value, this.GetMarker() );
		}
		#endregion

		#region Products	
		public Dictionary< string, List< string > > GetProductsBySkus( List< string > skus, bool skipDuplicates, Action< Product > processProductAction )
		{
			var client = this._factory.CreateProductsClient();
			var service = new ProductsBySkuService( client, this._credentials );
			return service.GetProductsBySkus( skus, skipDuplicates, processProductAction, this.GetMarker() );
		}

		public List< ProductInventory > GetProductsInventory( bool skipDuplicates )
		{
			var marker = this.GetMarker();
			AmazonLogger.Trace( "GetProductsInventory", this._credentials.SellerId, marker, "Begin invoke" );

			var client = this._factory.CreateFeedsReportsClient();
			var service = new ReportsService( client, this._credentials );
			var products = service.GetReportWithCallForEachMarketplace< ProductInventory >( ReportType.InventoryReport,
				DateTime.UtcNow.AddDays( -90 ).ToUniversalTime(), DateTime.UtcNow.ToUniversalTime(), skipDuplicates, p => p.Sku, marker );

			AmazonLogger.Trace( "GetProductsInventory", this._credentials.SellerId, marker, "End invoke" );
			return products;
		}

		public Dictionary< string, List< ProductInventory > > GetProductsInventoryByMarketplace( bool skipDuplicates )
		{
			var marker = this.GetMarker();
			AmazonLogger.Trace( "GetProductsInventoryByMarketplace", this._credentials.SellerId, marker, "Begin invoke" );

			var client = this._factory.CreateFeedsReportsClient();
			var service = new ReportsService( client, this._credentials );
			var products = service.GetReportByMarketplace< ProductInventory >( ReportType.InventoryReport,
				DateTime.UtcNow.AddDays( -90 ).ToUniversalTime(), DateTime.UtcNow.ToUniversalTime(), skipDuplicates, p => p.Sku, marker );

			AmazonLogger.Trace( "GetProductsInventoryByMarketplace", this._credentials.SellerId, marker, "End invoke" );
			return products;
		}

		/// <summary>
		/// Get Products Inventory
		/// </summary>
		/// <param name="skipDuplicates"></param>
		/// <param name="processReportAction">Marketplace and Product</param>
		public void GetProductsInventoryByMarketplace( bool skipDuplicates, Action< string, ProductInventory > processReportAction )
		{
			var marker = this.GetMarker();
			AmazonLogger.Trace( "GetProductsInventoryByMarketplace", this._credentials.SellerId, marker, "Begin invoke" );

			var client = this._factory.CreateFeedsReportsClient();
			var service = new ReportsService( client, this._credentials );
			service.GetReportByMarketplace( ReportType.InventoryReport,
				DateTime.UtcNow.AddDays( -90 ).ToUniversalTime(), DateTime.UtcNow.ToUniversalTime(), skipDuplicates, p => p.Sku, processReportAction, marker );

			AmazonLogger.Trace( "GetProductsInventoryByMarketplace", this._credentials.SellerId, marker, "End invoke" );
		}

		public List< ProductShort > GetActiveProducts( bool skipDuplicates )
		{
			var marker = this.GetMarker();
			AmazonLogger.Trace( "GetActiveProducts", this._credentials.SellerId, marker, "Begin invoke" );

			var client = this._factory.CreateFeedsReportsClient();
			var service = new ReportsService( client, this._credentials );
			var products = service.GetReportWithCallForEachMarketplace< ProductShort >( ReportType.ActiveListingsReport,
				DateTime.UtcNow.AddDays( -90 ).ToUniversalTime(), DateTime.UtcNow.ToUniversalTime(), skipDuplicates, p => p.SellerSku, marker );

			AmazonLogger.Trace( "GetActiveProducts", this._credentials.SellerId, marker, "End invoke" );
			return products;
		}

		public Dictionary< string, List< ProductShort > > GetActiveProductsByMarketplace( bool skipDuplicates )
		{
			var marker = this.GetMarker();
			AmazonLogger.Trace( "GetActiveProductsByMarketplace", this._credentials.SellerId, marker, "Begin invoke" );

			var client = this._factory.CreateFeedsReportsClient();
			var service = new ReportsService( client, this._credentials );
			var products = service.GetReportByMarketplace< ProductShort >( ReportType.ActiveListingsReport,
				DateTime.UtcNow.AddDays( -90 ).ToUniversalTime(), DateTime.UtcNow.ToUniversalTime(), skipDuplicates, p => p.SellerSku, marker );

			AmazonLogger.Trace( "GetActiveProductsByMarketplace", this._credentials.SellerId, marker, "End invoke" );
			return products;
		}

		/// <summary>
		/// Get Active Products
		/// </summary>
		/// <param name="skipDuplicates"></param>
		/// <param name="processReportAction">Marketplace and Product</param>
		public void GetActiveProductsByMarketplace( bool skipDuplicates, Action< string, ProductShort > processReportAction )
		{
			var marker = this.GetMarker();
			AmazonLogger.Trace( "GetActiveProductsByMarketplace", this._credentials.SellerId, marker, "Begin invoke" );

			var client = this._factory.CreateFeedsReportsClient();
			var service = new ReportsService( client, this._credentials );
			service.GetReportByMarketplace( ReportType.ActiveListingsReport,
				DateTime.UtcNow.AddDays( -90 ).ToUniversalTime(), DateTime.UtcNow.ToUniversalTime(), skipDuplicates, p => p.SellerSku, processReportAction, marker );

			AmazonLogger.Trace( "GetActiveProductsByMarketplace", this._credentials.SellerId, marker, "End invoke" );
		}

		public List< ProductShort > GetOpenProducts( bool skipDuplicates )
		{
			var marker = this.GetMarker();
			AmazonLogger.Trace( "GetOpenProducts", this._credentials.SellerId, marker, "Begin invoke" );

			var client = this._factory.CreateFeedsReportsClient();
			var service = new ReportsService( client, this._credentials );
			var products = service.GetReportWithCallForEachMarketplace< ProductShort >( ReportType.OpenListingsReport,
				DateTime.UtcNow.AddDays( -90 ).ToUniversalTime(), DateTime.UtcNow.ToUniversalTime(), skipDuplicates, p => p.SellerSku, marker );

			AmazonLogger.Trace( "GetOpenProducts", this._credentials.SellerId, marker, "End invoke" );
			return products;
		}

		public Dictionary< string, List< ProductShort > > GetOpenProductsByMarketplace( bool skipDuplicates )
		{
			var marker = this.GetMarker();
			AmazonLogger.Trace( "GetOpenProductsByMarketplace", this._credentials.SellerId, marker, "Begin invoke" );

			var client = this._factory.CreateFeedsReportsClient();
			var service = new ReportsService( client, this._credentials );
			var products = service.GetReportByMarketplace< ProductShort >( ReportType.OpenListingsReport,
				DateTime.UtcNow.AddDays( -90 ).ToUniversalTime(), DateTime.UtcNow.ToUniversalTime(), skipDuplicates, p => p.SellerSku, marker );

			AmazonLogger.Trace( "GetOpenProductsByMarketplace", this._credentials.SellerId, marker, "End invoke" );
			return products;
		}

		/// <summary>
		/// Get Open Products
		/// </summary>
		/// <param name="skipDuplicates"></param>
		/// <param name="processReportAction">Marketplace and Product</param>
		public void GetOpenProductsByMarketplace( bool skipDuplicates, Action< string, ProductShort > processReportAction )
		{
			var marker = this.GetMarker();
			AmazonLogger.Trace( "GetOpenProductsByMarketplace", this._credentials.SellerId, marker, "Begin invoke" );

			var client = this._factory.CreateFeedsReportsClient();
			var service = new ReportsService( client, this._credentials );
			service.GetReportByMarketplace( ReportType.OpenListingsReport,
				DateTime.UtcNow.AddDays( -90 ).ToUniversalTime(), DateTime.UtcNow.ToUniversalTime(), skipDuplicates, p => p.SellerSku, processReportAction, marker );

			AmazonLogger.Trace( "GetOpenProductsByMarketplace", this._credentials.SellerId, marker, "End invoke" );
		}
		#endregion

		#region Update inventory
		public void UpdateInventory( IEnumerable< AmazonInventoryItem > inventoryItems )
		{
			var marker = this.GetMarker();
			AmazonLogger.Trace( "UpdateInventory", this._credentials.SellerId, marker, "Begin invoke" );

			var client = this._factory.CreateFeedsReportsClient();
			var service = new FeedsService( client, this._credentials );

			var parts = inventoryItems.Slice( Updateitemslimit );
			foreach( var part in parts )
			{
				var xmlService = new InventoryFeedXmlService( part.ToList(), this._credentials.SellerId );
				var contentString = xmlService.GetDocumentString();
				service.SubmitFeed( FeedType.InventoryQuantityUpdate, contentString, marker );
			}

			AmazonLogger.Trace( "UpdateInventory", this._credentials.SellerId, marker, "End invoke" );
		}
		#endregion

		#region Get FBA inventory
		public List< InventorySupply > GetFbaInventory()
		{
			var client = this._factory.CreateFbaInventoryClient();
			var service = new FbaInventorySupplyService( client, this._credentials );
			var inventory = service.LoadFbaInventory( this.GetMarker() );
			return inventory.ToList();
		}

		public bool IsFbaInventoryReceived()
		{
			var client = this._factory.CreateFbaInventoryClient();
			var service = new FbaInventorySupplyService( client, this._credentials );
			return service.IsFbaInventoryReceived( this.GetMarker() );
		}

		public List< FbaManageInventory > GetDetailedFbaInventory()
		{
			var marker = this.GetMarker();
			AmazonLogger.Trace( "GetDetailedFbaInventory", this._credentials.SellerId, marker, "Begin invoke" );

			var client = this._factory.CreateFeedsReportsClient();
			var service = new ReportsService( client, this._credentials );
			var inventory = service.GetReportWithOneCallForAllMarketplaces< FbaManageInventory >( ReportType.FbaManageInventoryArchived,
				DateTime.UtcNow.AddDays( -90 ).ToUniversalTime(), DateTime.UtcNow.ToUniversalTime(), marker );

			AmazonLogger.Trace( "GetDetailedFbaInventory", this._credentials.SellerId, marker, "End invoke" );
			return inventory.ToList();
		}
		#endregion

		#region Sellers
		public MarketplaceParticipations GetMarketplaceParticipations()
		{
			var client = this._factory.CreateSellersClient();
			var service = new SellerMarketplaceService( client, this._credentials );
			var result = service.GetMarketplaceParticipations( this.GetMarker() );
			return result;
		}
		#endregion

		private string GetMarker()
		{
			var marker = Guid.NewGuid().ToString();
			return marker;
		}
	}
}