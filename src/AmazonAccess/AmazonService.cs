﻿using System;
using System.Collections.Generic;
using System.Linq;
using AmazonAccess.Misc;
using AmazonAccess.Models;
using AmazonAccess.Services;
using AmazonAccess.Services.FbaInventory;
using AmazonAccess.Services.FbaInventory.Model;
using AmazonAccess.Services.MarketplaceWebServiceFeedsReports;
using AmazonAccess.Services.MarketplaceWebServiceFeedsReports.Model;
using AmazonAccess.Services.MarketplaceWebServiceFeedsReports.ReportModel;
using AmazonAccess.Services.Orders;
using AmazonAccess.Services.Orders.Model;
using AmazonAccess.Services.Sellers;
using AmazonAccess.Services.Sellers.Model;
using CuttingEdge.Conditions;

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

		#region update inventory
		public void UpdateInventory( IEnumerable< AmazonInventoryItem > inventoryItems )
		{
			var client = this._factory.CreateFeedsReportsClient();

			AmazonLogger.Log.Trace( "[amazon] Updating inventory for seller {0}", this._credentials.SellerId );

			if( inventoryItems.Count() > Updateitemslimit )
			{
				var partsCount = inventoryItems.Count() / Updateitemslimit + 1;
				var parts = inventoryItems.Split( partsCount );

				foreach( var part in parts )
				{
					this.SubmitInventoryUpdateRequest( client, part );
				}
			}
			else
				this.SubmitInventoryUpdateRequest( client, inventoryItems );

			AmazonLogger.Log.Trace( "[amazon] Inventory for seller {0} loaded", this._credentials.SellerId );
		}

		private SubmitFeedRequest InitInventoryFeedRequest( IEnumerable< AmazonInventoryItem > inventoryItems )
		{
			var xmlService = new InventoryFeedXmlService( inventoryItems, this._credentials.SellerId );
			var contentString = xmlService.GetDocumentString();
			var contentStream = xmlService.GetDocumentStream();

			AmazonLogger.Log.Trace( "[amazon] Inventory document for seller {0}\n{1}", this._credentials.SellerId, contentString );

			var request = new SubmitFeedRequest
			{
				MarketplaceIdList = new IdList { Id = this._credentials.AmazonMarketplaces.GetMarketplaceIdAsList() },
				Merchant = this._credentials.SellerId,
				FeedType = FeedType.InventoryQuantityUpdate.Description,
				FeedContent = contentStream,
				ContentMD5 = MarketplaceWebServiceFeedsReportsClient.CalculateContentMD5( contentStream ),
				MWSAuthToken = this._credentials.MwsAuthToken
			};

			return request;
		}

		private void SubmitInventoryUpdateRequest( IMarketplaceWebServiceFeedsReports client, IEnumerable< AmazonInventoryItem > inventoryItems )
		{
			var request = this.InitInventoryFeedRequest( inventoryItems );
			var service = new FeedsService( client );

			ActionPolicies.Submit.Do( () =>
			{
				service.SubmitFeed( request );
				request.FeedContent.Close();
				ActionPolicies.CreateApiDelay( 2 ).Wait();
			} );
		}
		#endregion

		#region Get FBA inventory
		public IEnumerable< InventorySupply > GetFbaInventory()
		{
			var client = this._factory.CreateFbaInventoryClient();
			var service = new FbaInventorySupplyService( client, this._credentials );
			var inventory = service.LoadFbaInventory( this.GetMarker() );
			return inventory;
		}

		public bool IsFbaInventoryReceived()
		{
			var client = this._factory.CreateFbaInventoryClient();
			var service = new FbaInventorySupplyService( client, this._credentials );
			return service.IsFbaInventoryReceived( this.GetMarker() );
		}

		public IEnumerable< FbaManageInventory > GetDetailedFbaInventory()
		{
			var inventory = new List< FbaManageInventory >();

			ActionPolicies.Get.Do( () =>
			{
				var client = this._factory.CreateFeedsReportsClient();
				var service = new ReportsService( client, this._credentials );

				AmazonLogger.Log.Trace( "[amazon] Loading Detailed FBA inventory for seller {0}", this._credentials.SellerId );

				inventory.AddRange( service.GetReport< FbaManageInventory >(
					ReportType.FbaManageInventoryArchived,
					DateTime.UtcNow.AddDays( -90 ).ToUniversalTime(),
					DateTime.UtcNow.ToUniversalTime() ) );

				AmazonLogger.Log.Trace( "[amazon] Detailed FBA inventiry for seller {0} loaded", this._credentials.SellerId );
			} );

			return inventory;
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