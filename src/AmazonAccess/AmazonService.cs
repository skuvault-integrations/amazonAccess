﻿using System;
using System.Collections.Generic;
using System.Linq;
using AmazonAccess.Misc;
using AmazonAccess.Models;
using AmazonAccess.Services;
using AmazonAccess.Services.FbaInbound;
using AmazonAccess.Services.FbaInventory;
using AmazonAccess.Services.FbaInventory.Model;
using AmazonAccess.Services.FBAInbound.Model;
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
using Address = AmazonAccess.Services.FBAInbound.Model.Address;
using AmazonAccess.Services.Finances.Model;
using AmazonAccess.Services.Finances;

namespace AmazonAccess
{
	public sealed class AmazonService: IAmazonService
	{
		private const int Updateitemslimit = 3000;
		private const int CreateInboundShipmentLimit = 200;
		private const string InboundShipmentStatus = "WORKING";
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
			var ordersCount = service.LoadOrdersById( this.GetMarker(), ids, processOrderAction );
			return ordersCount;
		}

		public bool TryGetOrders( DateTime? dateFrom = null, DateTime? dateTo = null )
		{
			dateFrom = dateFrom ?? DateTime.UtcNow.AddHours( -1 );
			dateTo = dateTo ?? DateTime.UtcNow.AddMinutes( -10 );

			var client = this._factory.CreateOrdersClient();
			var financesServiceClient = this._factory.CreateFinancesServiceClient();
			var service = new OrdersService( client, financesServiceClient, this._credentials );
			return service.IsOrdersReceived( this.GetMarker(), dateFrom.Value, dateTo.Value );
		}

		public int GetOrders( DateTime dateFrom, DateTime dateTo, Action< ComposedOrder > processOrderAction )
		{
			var client = this._factory.CreateOrdersClient();
			var financesServiceClient = this._factory.CreateFinancesServiceClient();
			var service = new OrdersService( client, financesServiceClient, this._credentials );
			var ordersCount = service.LoadOrders( this.GetMarker(), dateFrom, dateTo, processOrderAction );
			return ordersCount;
		}

		public IEnumerable< FbaShipmentItemData > GetFbaShipments( DateTime dateFrom, DateTime dateTo, string marker = null )
		{
			if ( marker == null )
				marker = this.GetMarker();

			AmazonLogger.Trace( "GetFbaShipments", this._credentials.SellerId, marker, "Begin invoke" );

			var client = this._factory.CreateFeedsReportsClient();
			var service = new ReportsService( client, this._credentials );
			var fbaShipments = service.GetReportForAllMarketplaces< FbaShipmentItemData >( marker, ReportType.FbaShipmentsData, dateFrom, dateTo );

			AmazonLogger.Trace( "GetFbaShipments", this._credentials.SellerId, marker, "End invoke" );
			return fbaShipments.ToList();
		}
		#endregion

		#region Products	
		public Dictionary< AmazonMarketplace, List< string > > GetProductsBySkus( List< string > skus, bool skipDuplicates, Action< Product > processProductAction )
		{
			var client = this._factory.CreateProductsClient();
			var service = new ProductsBySkuService( client, this._credentials );
			return service.GetProductsBySkus( this.GetMarker(), skus, skipDuplicates, processProductAction );
		}

		public bool TryGetProductsInventory()
		{
			var marker = this.GetMarker();
			AmazonLogger.Trace( "TryGetProductsInventory", this._credentials.SellerId, marker, "Begin invoke" );

			var client = this._factory.CreateFeedsReportsClient();
			var service = new ReportsService( client, this._credentials );
			var products = service.TryGetReportForEachMarketplace( marker, ReportType.InventoryReport, DateTime.UtcNow.AddDays( -90 ).ToUniversalTime(), DateTime.UtcNow.ToUniversalTime() );

			AmazonLogger.Trace( "TryGetProductsInventory", this._credentials.SellerId, marker, "End invoke" );
			return products;
		}

		public List< ProductInventory > GetProductsInventory( bool skipDuplicates )
		{
			var marker = this.GetMarker();
			AmazonLogger.Trace( "GetProductsInventory", this._credentials.SellerId, marker, "Begin invoke" );

			var client = this._factory.CreateFeedsReportsClient();
			var service = new ReportsService( client, this._credentials );
			//var products = service.GetReportForEachMarketplaceAndJoin<ProductInventory>(marker, ReportType.InventoryReport, 
			//	DateTime.UtcNow.AddDays(-90).ToUniversalTime(), DateTime.UtcNow.ToUniversalTime(), skipDuplicates, (pr => pr.Sku));
			var products = skipDuplicates ?
				service.GetReportForEachMarketplaceAndJoinForProductInventorySkipDuplicates( marker, DateTime.UtcNow.AddDays( -90 ).ToUniversalTime(), DateTime.UtcNow.ToUniversalTime() ) :
				service.GetReportForEachMarketplaceAndJoinForProductInventoryNotSkipDuplicates( marker, DateTime.UtcNow.AddDays( -90 ).ToUniversalTime(), DateTime.UtcNow.ToUniversalTime() );

			AmazonLogger.Trace( "GetProductsInventory", this._credentials.SellerId, marker, "End invoke" );
			return products;
		}

		public Dictionary< AmazonMarketplace, List< ProductInventory > > GetProductsInventoryByMarketplace( bool skipDuplicates )
		{
			var marker = this.GetMarker();
			AmazonLogger.Trace( "GetProductsInventoryByMarketplace", this._credentials.SellerId, marker, "Begin invoke" );

			var client = this._factory.CreateFeedsReportsClient();
			var service = new ReportsService( client, this._credentials );
			var products = service.GetReportForEachMarketplace< ProductInventory >( marker, ReportType.InventoryReport,
				DateTime.UtcNow.AddDays( -90 ).ToUniversalTime(), DateTime.UtcNow.ToUniversalTime(), skipDuplicates, p => p.Sku );

			AmazonLogger.Trace( "GetProductsInventoryByMarketplace", this._credentials.SellerId, marker, "End invoke" );
			return products;
		}

		/// <summary>
		/// Get Products Inventory
		/// </summary>
		/// <param name="skipDuplicates"></param>
		/// <param name="processReportAction">Marketplace and Product</param>
		public void GetProductsInventoryByMarketplace( bool skipDuplicates, Action< AmazonMarketplace, ProductInventory > processReportAction )
		{
			var marker = this.GetMarker();
			AmazonLogger.Trace( "GetProductsInventoryByMarketplace", this._credentials.SellerId, marker, "Begin invoke" );

			var client = this._factory.CreateFeedsReportsClient();
			var service = new ReportsService( client, this._credentials );
			service.GetReportForEachMarketplace( marker, ReportType.InventoryReport,
				DateTime.UtcNow.AddDays( -90 ).ToUniversalTime(), DateTime.UtcNow.ToUniversalTime(), skipDuplicates, p => p.Sku, processReportAction );

			AmazonLogger.Trace( "GetProductsInventoryByMarketplace", this._credentials.SellerId, marker, "End invoke" );
		}

		public bool TryGetActiveProducts()
		{
			var marker = this.GetMarker();
			AmazonLogger.Trace( "TryGetActiveProducts", this._credentials.SellerId, marker, "Begin invoke" );

			var client = this._factory.CreateFeedsReportsClient();
			var service = new ReportsService( client, this._credentials );
			var products = service.TryGetReportForEachMarketplace( marker, ReportType.ActiveListingsReport, DateTime.UtcNow.AddDays( -90 ).ToUniversalTime(), DateTime.UtcNow.ToUniversalTime() );

			AmazonLogger.Trace( "TryGetActiveProducts", this._credentials.SellerId, marker, "End invoke" );
			return products;
		}

		public List< ProductShort > GetActiveProducts( bool skipDuplicates )
		{
			var marker = this.GetMarker();
			AmazonLogger.Trace( "GetActiveProducts", this._credentials.SellerId, marker, "Begin invoke" );

			var client = this._factory.CreateFeedsReportsClient();
			var service = new ReportsService( client, this._credentials );
			var products = service.GetReportForEachMarketplaceAndJoin< ProductShort >( marker, ReportType.ActiveListingsReport,
				DateTime.UtcNow.AddDays( -90 ).ToUniversalTime(), DateTime.UtcNow.ToUniversalTime(), skipDuplicates, p => p.SellerSku );

			AmazonLogger.Trace( "GetActiveProducts", this._credentials.SellerId, marker, "End invoke" );
			return products;
		}

		public Dictionary< AmazonMarketplace, List< ProductShort > > GetActiveProductsByMarketplace( bool skipDuplicates )
		{
			var marker = this.GetMarker();
			AmazonLogger.Trace( "GetActiveProductsByMarketplace", this._credentials.SellerId, marker, "Begin invoke" );

			var client = this._factory.CreateFeedsReportsClient();
			var service = new ReportsService( client, this._credentials );
			var products = service.GetReportForEachMarketplace< ProductShort >( marker, ReportType.ActiveListingsReport,
				DateTime.UtcNow.AddDays( -90 ).ToUniversalTime(), DateTime.UtcNow.ToUniversalTime(), skipDuplicates, p => p.SellerSku );

			AmazonLogger.Trace( "GetActiveProductsByMarketplace", this._credentials.SellerId, marker, "End invoke" );
			return products;
		}

		/// <summary>
		/// Get Active Products
		/// </summary>
		/// <param name="skipDuplicates"></param>
		/// <param name="processReportAction">Marketplace and Product</param>
		public void GetActiveProductsByMarketplace( bool skipDuplicates, Action< AmazonMarketplace, ProductShort > processReportAction )
		{
			var marker = this.GetMarker();
			AmazonLogger.Trace( "GetActiveProductsByMarketplace", this._credentials.SellerId, marker, "Begin invoke" );

			var client = this._factory.CreateFeedsReportsClient();
			var service = new ReportsService( client, this._credentials );
			service.GetReportForEachMarketplace( marker, ReportType.ActiveListingsReport,
				DateTime.UtcNow.AddDays( -90 ).ToUniversalTime(), DateTime.UtcNow.ToUniversalTime(), skipDuplicates, p => p.SellerSku, processReportAction );

			AmazonLogger.Trace( "GetActiveProductsByMarketplace", this._credentials.SellerId, marker, "End invoke" );
		}

		public List< ProductShort > GetOpenProducts( bool skipDuplicates )
		{
			var marker = this.GetMarker();
			AmazonLogger.Trace( "GetOpenProducts", this._credentials.SellerId, marker, "Begin invoke" );

			var client = this._factory.CreateFeedsReportsClient();
			var service = new ReportsService( client, this._credentials );
			var products = service.GetReportForEachMarketplaceAndJoin< ProductShort >( marker, ReportType.OpenListingsReport,
				DateTime.UtcNow.AddDays( -90 ).ToUniversalTime(), DateTime.UtcNow.ToUniversalTime(), skipDuplicates, p => p.SellerSku );

			AmazonLogger.Trace( "GetOpenProducts", this._credentials.SellerId, marker, "End invoke" );
			return products;
		}

		public Dictionary< AmazonMarketplace, List< ProductShort > > GetOpenProductsByMarketplace( bool skipDuplicates )
		{
			var marker = this.GetMarker();
			AmazonLogger.Trace( "GetOpenProductsByMarketplace", this._credentials.SellerId, marker, "Begin invoke" );

			var client = this._factory.CreateFeedsReportsClient();
			var service = new ReportsService( client, this._credentials );
			var products = service.GetReportForEachMarketplace< ProductShort >( marker, ReportType.OpenListingsReport,
				DateTime.UtcNow.AddDays( -90 ).ToUniversalTime(), DateTime.UtcNow.ToUniversalTime(), skipDuplicates, p => p.SellerSku );

			AmazonLogger.Trace( "GetOpenProductsByMarketplace", this._credentials.SellerId, marker, "End invoke" );
			return products;
		}

		/// <summary>
		/// Get Open Products
		/// </summary>
		/// <param name="skipDuplicates"></param>
		/// <param name="processReportAction">Marketplace and Product</param>
		public void GetOpenProductsByMarketplace( bool skipDuplicates, Action< AmazonMarketplace, ProductShort > processReportAction )
		{
			var marker = this.GetMarker();
			AmazonLogger.Trace( "GetOpenProductsByMarketplace", this._credentials.SellerId, marker, "Begin invoke" );

			var client = this._factory.CreateFeedsReportsClient();
			var service = new ReportsService( client, this._credentials );
			service.GetReportForEachMarketplace( marker, ReportType.OpenListingsReport,
				DateTime.UtcNow.AddDays( -90 ).ToUniversalTime(), DateTime.UtcNow.ToUniversalTime(), skipDuplicates, p => p.SellerSku, processReportAction );

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
				service.SubmitFeed( marker, FeedType.InventoryQuantityUpdate, contentString );
			}

			AmazonLogger.Trace( "UpdateInventory", this._credentials.SellerId, marker, "End invoke" );
		}
		#endregion

		#region Get FBA inventory
		public bool TryGetFbaInventory()
		{
			var client = this._factory.CreateFbaInventoryClient();
			var service = new FbaInventorySupplyService( client, this._credentials );
			return service.IsFbaInventoryReceived( this.GetMarker() );
		}

		public List< InventorySupply > GetFbaInventory()
		{
			var client = this._factory.CreateFbaInventoryClient();
			var service = new FbaInventorySupplyService( client, this._credentials );
			var inventory = service.LoadFbaInventory( this.GetMarker() );
			return inventory.ToList();
		}

		public bool TryGetDetailedFbaInventory( bool includeArchived = true, bool dontSendMarketplaces = false )
		{
			var marker = this.GetMarker();
			var operationName = includeArchived ? "TryGetDetailedFbaInventoryArchived" : "TryGetDetailedFbaInventory";
			AmazonLogger.Trace( operationName, this._credentials.SellerId, marker, "Begin invoke" );

			var client = this._factory.CreateFeedsReportsClient();
			var service = new ReportsService( client, this._credentials );
			var reportType = includeArchived ? ReportType.FbaManageInventoryArchived : ReportType.FbaManageInventory;
			var result = service.TryGetReportForAllMarketplaces( marker, reportType, DateTime.UtcNow.AddDays( -90 ), DateTime.UtcNow, dontSendMarketplaces );

			AmazonLogger.Trace( operationName, this._credentials.SellerId, marker, "End invoke" );
			return result;
		}

		public List< FbaManageInventory > GetDetailedFbaInventory( bool includeArchived = true, bool dontSendMarketplaces = false )
		{
			var marker = this.GetMarker();
			var operationName = includeArchived ? "GetDetailedFbaInventoryArchived" : "GetDetailedFbaInventory";
			AmazonLogger.Trace( operationName, this._credentials.SellerId, marker, "Begin invoke" );

			var client = this._factory.CreateFeedsReportsClient();
			var service = new ReportsService( client, this._credentials );
			var reportType = includeArchived ? ReportType.FbaManageInventoryArchived : ReportType.FbaManageInventory;
			var inventory = service.GetReportForAllMarketplaces< FbaManageInventory >( marker, reportType, DateTime.UtcNow.AddDays( -90 ), DateTime.UtcNow, dontSendMarketplaces );

			AmazonLogger.Trace( operationName, this._credentials.SellerId, marker, "End invoke" );
			return inventory.ToList();
		}

		public bool TryGetDetailedFbaInventoryByMarketplace( bool includeArchived = true )
		{
			var marker = this.GetMarker();
			var operationName = includeArchived ? "TryGetDetailedFbaInventoryByMarketplaceArchived" : "TryGetDetailedFbaInventoryByMarketplace";
			AmazonLogger.Trace( operationName, this._credentials.SellerId, marker, "Begin invoke" );

			var client = this._factory.CreateFeedsReportsClient();
			var service = new ReportsService( client, this._credentials );
			var reportType = includeArchived ? ReportType.FbaManageInventoryArchived : ReportType.FbaManageInventory;
			var inventory = service.TryGetReportForEachMarketplace( marker, reportType, DateTime.UtcNow.AddDays( -90 ), DateTime.UtcNow );

			AmazonLogger.Trace( operationName, this._credentials.SellerId, marker, "End invoke" );
			return inventory;
		}

		public Dictionary< AmazonMarketplace, List< FbaManageInventory > > GetDetailedFbaInventoryByMarketplace( bool includeArchived = true )
		{
			var marker = this.GetMarker();
			var operationName = includeArchived ? "GetDetailedFbaInventoryByMarketplaceArchived" : "GetDetailedFbaInventoryByMarketplace";
			AmazonLogger.Trace( operationName, this._credentials.SellerId, marker, "Begin invoke" );

			var client = this._factory.CreateFeedsReportsClient();
			var service = new ReportsService( client, this._credentials );
			var reportType = includeArchived ? ReportType.FbaManageInventoryArchived : ReportType.FbaManageInventory;
			var inventory = service.GetReportForEachMarketplace< FbaManageInventory >( marker, reportType, DateTime.UtcNow.AddDays( -90 ), DateTime.UtcNow, false, x => x.SKU );

			AmazonLogger.Trace( operationName, this._credentials.SellerId, marker, "End invoke" );
			return inventory;
		}

		public bool TryGetFbaReservedInventory( bool dontSendMarketplaces = false )
		{
			var marker = this.GetMarker();
			AmazonLogger.Trace( "TryGetFbaReservedInventory", this._credentials.SellerId, marker, "Begin invoke" );

			var client = this._factory.CreateFeedsReportsClient();
			var service = new ReportsService( client, this._credentials );
			var result = service.TryGetReportForAllMarketplaces( marker, ReportType.FbaReservedInventory, DateTime.UtcNow.AddDays( -90 ), DateTime.UtcNow, dontSendMarketplaces );

			AmazonLogger.Trace( "TryGetFbaReservedInventory", this._credentials.SellerId, marker, "End invoke" );
			return result;
		}

		public List< FbaReservedInventory > GetFbaReservedInventory( bool dontSendMarketplaces = false )
		{
			var marker = this.GetMarker();
			AmazonLogger.Trace( "GetFbaReservedInventory", this._credentials.SellerId, marker, "Begin invoke" );

			var client = this._factory.CreateFeedsReportsClient();
			var service = new ReportsService( client, this._credentials );
			var inventory = service.GetReportForAllMarketplaces< FbaReservedInventory >( marker, ReportType.FbaReservedInventory, DateTime.UtcNow.AddDays( -90 ), DateTime.UtcNow, dontSendMarketplaces );

			AmazonLogger.Trace( "GetFbaReservedInventory", this._credentials.SellerId, marker, "End invoke" );
			return inventory.ToList();
		}

		public bool TryGetFbaReservedInventoryByMarketplace()
		{
			var marker = this.GetMarker();
			AmazonLogger.Trace( "TryGetFbaReservedInventoryByMarketplace", this._credentials.SellerId, marker, "Begin invoke" );

			var client = this._factory.CreateFeedsReportsClient();
			var service = new ReportsService( client, this._credentials );
			var inventory = service.TryGetReportForEachMarketplace( marker, ReportType.FbaReservedInventory, DateTime.UtcNow.AddDays( -90 ), DateTime.UtcNow );

			AmazonLogger.Trace( "TryGetFbaReservedInventoryByMarketplace", this._credentials.SellerId, marker, "End invoke" );
			return inventory;
		}

		public Dictionary< AmazonMarketplace, List< FbaReservedInventory > > GetFbaReservedInventoryByMarketplace()
		{
			var marker = this.GetMarker();
			AmazonLogger.Trace( "GetFbaReservedInventoryByMarketplace", this._credentials.SellerId, marker, "Begin invoke" );

			var client = this._factory.CreateFeedsReportsClient();
			var service = new ReportsService( client, this._credentials );
			var inventory = service.GetReportForEachMarketplace< FbaReservedInventory >( marker, ReportType.FbaReservedInventory, DateTime.UtcNow.AddDays( -90 ), DateTime.UtcNow, false, x => x.SKU );

			AmazonLogger.Trace( "GetFbaReservedInventoryByMarketplace", this._credentials.SellerId, marker, "End invoke" );
			return inventory;
		}

		public List< FbaMultiCountryInventory > GetFbaMultiCountryInventory( bool dontSendMarketplaces = false )
		{
			var marker = this.GetMarker();
			AmazonLogger.Trace( "GetFbaMultiCountryInventory", this._credentials.SellerId, marker, "Begin invoke" );

			var client = this._factory.CreateFeedsReportsClient();
			var service = new ReportsService( client, this._credentials );
			var inventory = service.GetReportForAllMarketplaces< FbaMultiCountryInventory >( marker, ReportType.FbaMultiCountryInventory, DateTime.UtcNow.AddDays( -90 ), DateTime.UtcNow, dontSendMarketplaces );

			AmazonLogger.Trace( "GetFbaMultiCountryInventory", this._credentials.SellerId, marker, "End invoke" );
			return inventory.ToList();
		}

		public List< FbaFulfilledInventory > GetFbaFulfilledInventory( bool dontSendMarketplaces = false )
		{
			var marker = this.GetMarker();
			AmazonLogger.Trace( "GetFbaFulfilledInventory", this._credentials.SellerId, marker, "Begin invoke" );

			var client = this._factory.CreateFeedsReportsClient();
			var service = new ReportsService( client, this._credentials );
			var inventory = service.GetReportForAllMarketplaces< FbaFulfilledInventory >( marker, ReportType.FbaFulfilledInventory, DateTime.UtcNow.AddDays( -90 ), DateTime.UtcNow, dontSendMarketplaces );

			AmazonLogger.Trace( "GetFbaFulfilledInventory", this._credentials.SellerId, marker, "End invoke" );
			return inventory.ToList();
		}
		#endregion

		#region Create an inbound shipment
		public bool CreateInboundShipment( Address shipFromAddress, 
			string shipToCountryCode, 
			string shipToCountrySubdivisionCode, 
			string labelPrepPreference, 
			IEnumerable< InboundShipmentPlanRequestItem > items )
		{
			var marker = this.GetMarker();
			AmazonLogger.Trace( "CreateInboundShipment", this._credentials.SellerId, marker, "Begin invoke" );

			var client = this._factory.CreateFbaInboundClient();
			var service = new FbaInboundService( client, this._credentials );

			var parts = items.Slice( CreateInboundShipmentLimit );
			var plans = new List< InboundShipmentPlan >();
			foreach( var part in parts )
			{
				var partInboundShipmentPlanRequestItem = new InboundShipmentPlanRequestItemList
				{
					member = new List< InboundShipmentPlanRequestItem >( part )
				};
				var partPlans = service.CreateInboundShipmentPlan(shipFromAddress, 
					shipToCountryCode,
					shipToCountrySubdivisionCode,
					labelPrepPreference,
					partInboundShipmentPlanRequestItem,
					marker );
				foreach( var plan in partPlans)
				{
					var existingPlan = FindExistingInboundShipmentPlan( plans, plan );
					
					if( existingPlan != null )
					{
						service.UpdateInboundShipment( existingPlan.ShipmentId, 
							null,
							ConvertShipmentPlanItemListToShipmentItemList( plan.Items.member, items ),
							marker );
					}
					else
					{
						service.CreateInboundShipment( plan.ShipmentId, 
							new InboundShipmentHeader()
							{
								ShipmentName = $"SV-{shipToCountryCode}-{DateTime.Now:yyyyMMddHHmmss}",
								ShipFromAddress = shipFromAddress,
								LabelPrepPreference = labelPrepPreference,
								ShipmentStatus = InboundShipmentStatus,
								DestinationFulfillmentCenterId = plan.DestinationFulfillmentCenterId
							},
							ConvertShipmentPlanItemListToShipmentItemList( plan.Items.member, items ),
							marker );
						plans.Add( plan );
					}
				}
			}

			AmazonLogger.Trace( "CreateInboundShipment", this._credentials.SellerId, marker, "End invoke" );
			return true;
		}

		private static InboundShipmentPlan FindExistingInboundShipmentPlan( IEnumerable< InboundShipmentPlan > plans, InboundShipmentPlan newPlan )
		{
			return plans.FirstOrDefault( plan =>
				string.Equals( plan.DestinationFulfillmentCenterId, newPlan.DestinationFulfillmentCenterId, StringComparison.InvariantCultureIgnoreCase ) &&
				string.Equals( plan.LabelPrepType, newPlan.LabelPrepType ) );
		}

		private static InboundShipmentItemList ConvertShipmentPlanItemListToShipmentItemList( IEnumerable< InboundShipmentPlanItem > list, IEnumerable <InboundShipmentPlanRequestItem>  request )
		{
			var result = new InboundShipmentItemList { member = new List< InboundShipmentItem >( ) };
			foreach( var item in list )
			{
				PrepDetailsList prepDetailsListCopy = null;
				if(item.PrepDetailsList != null)
					prepDetailsListCopy = new PrepDetailsList() { PrepDetails = new List<PrepDetails>(item.PrepDetailsList.PrepDetails) };
				result.member.Add( new InboundShipmentItem()
				{
					SellerSKU = item.SellerSKU,
					QuantityShipped = item.Quantity,
					QuantityInCase = request.FirstOrDefault( r => r.SellerSKU == item.SellerSKU )?.QuantityInCase ?? 0,
					PrepDetailsList = prepDetailsListCopy
				} );
			}
			return result;
		}
		#endregion

		#region Get FBA Inbound
		public List< InboundShipmentFullInfo > GetListInboundShipments( DateTime? dateFrom, DateTime? dateTo, string[] shipmentStatusListForReceive, string[] shipmentStatusListForReceiveItems )
		{
			var client = this._factory.CreateFbaInboundClient();
			var service = new FbaInboundService( client, this._credentials );
			return service.GetInboundShipmentsData(
				this.GetMarker(),
				dateFrom ?? DateTime.MinValue,
				dateTo ?? DateTime.UtcNow,
				shipmentStatusListForReceive.Any() ? shipmentStatusListForReceive.ToList() : this.GetAllShipmentStatusList().ToList(),
				shipmentStatusListForReceiveItems.Any() ? shipmentStatusListForReceiveItems.ToList() : this.GetShipmentStatusListForReceiveItems().ToList() );
		}

		public ShipmentEvent GetOrderFees( string marker, string orderId )
		{
			var client = this._factory.CreateFinancesServiceClient();
			var service = new FinancesService( client, this._credentials );

			return service.LoadOrderFees( marker, orderId );
		}

		public IEnumerable< string > GetAllShipmentStatusList()
		{
			yield return "WORKING";
			yield return "SHIPPED";
			yield return "IN_TRANSIT";
			yield return "DELIVERED";
			yield return "CHECKED_IN";
			yield return "RECEIVING";
			yield return "CLOSED";
			yield return "CANCELLED";
			yield return "DELETED";
			yield return "ERROR";
			yield return "READY_TO_SHIP";
		}

		private IEnumerable< string > GetShipmentStatusListForReceiveItems()
		{
			yield return "WORKING";
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