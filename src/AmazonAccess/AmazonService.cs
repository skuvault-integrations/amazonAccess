using System;
using System.Collections.Generic;
using System.Linq;
using AmazonAccess.Misc;
using AmazonAccess.Models;
using AmazonAccess.Services;
using AmazonAccess.Services.FbaInventoryServiceMws;
using AmazonAccess.Services.FbaInventoryServiceMws.Model;
using AmazonAccess.Services.MarketplaceWebServiceFeeds;
using AmazonAccess.Services.MarketplaceWebServiceFeeds.Model;
using AmazonAccess.Services.MarketplaceWebServiceOrders;
using AmazonAccess.Services.MarketplaceWebServiceOrders.Model;
using CuttingEdge.Conditions;
using MarketplaceWebService;

namespace AmazonAccess
{
	public sealed class AmazonService : IAmazonService
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
		public IEnumerable< ComposedOrder > GetOrders( DateTime dateFrom, DateTime dateTo )
		{
			var orders = new List< ComposedOrder >();

			ActionPolicies.AmazonGetPolicy.Do( () =>
			{
				var client = this._factory.CreateOrdersClient( "SkuVault", "1.0" );
				var request = new ListOrdersRequest
				{
					SellerId = this._credentials.SellerId,
					LastUpdatedAfter = dateFrom,
					//LastUpdatedBefore = dateTo,
					MarketplaceId = new MarketplaceIdList { Id = this._credentials.MarketplaceIds }
				};
				var service = new OrdersService( client, request );
				orders.AddRange( service.LoadOrders() );
			} );

			return orders;
		}
		#endregion

		#region update inventory
		public void UpdateInventory( IEnumerable< AmazonInventoryItem > inventoryItems )
		{
			var client = this._factory.CreateFeedsReportsClient();
			if( inventoryItems.Count() > Updateitemslimit )
			{
				var partsCount = inventoryItems.Count() / Updateitemslimit + 1;
				var parts = inventoryItems.Split( partsCount );

				foreach( var part in parts )
					this.SubmitInventoryUpdateRequest( client, part );
			}
			else
			{
				this.SubmitInventoryUpdateRequest( client, inventoryItems );
			}
		}

		private SubmitFeedRequest InitInventoryFeedRequest( IEnumerable< AmazonInventoryItem > inventoryItems )
		{
			var xmlService = new InventoryFeedXmlService( inventoryItems, this._credentials.SellerId );
			var contentStream = xmlService.GetDocumentStream();

			var request = new SubmitFeedRequest
			{
				MarketplaceIdList = new IdList { Id = this._credentials.MarketplaceIds },
				Merchant = this._credentials.SellerId,
				FeedType = FeedType.InventoryQuantityUpdate.Description,
				FeedContent = contentStream,
				ContentMD5 = MarketplaceWebServiceClient.CalculateContentMD5( contentStream )
			};

			return request;
		}

		private void SubmitInventoryUpdateRequest( IMarketplaceWebService client, IEnumerable< AmazonInventoryItem > inventoryItems )
		{
			var request = this.InitInventoryFeedRequest( inventoryItems );
			var service = new FeedsService();

			ActionPolicies.AmazonGetPolicy.Do( () =>
			{
				service.SubmitFeed( client, request );
				request.FeedContent.Close();
				ActionPolicies.CreateApiDelay( 2 ).Wait();
			} );
		}
		#endregion

		#region Get inventory
		public IEnumerable< InventorySupply > GetFbaInventory()
		{
			var inventory = new List< InventorySupply >();

			ActionPolicies.AmazonGetPolicy.Do( () =>
			{
				var client = this._factory.CreateFbaInventoryClient();
				var request = new ListInventorySupplyRequest
				{
					SellerId = this._credentials.SellerId,
					QueryStartDateTime = DateTime.MinValue
				};
				var service = new InventorySupplyService( client, request );
				inventory.AddRange( service.LoadInventory() );
			} );

			return inventory;
		}

		public IEnumerable< InventorySupply > GetInventory()
		{
			//var client = this._factory.CreateFeedsReportsClient();
			//var service = new ReportsService();

			//service.GetInventoryReport( client );

			return null;
		}
		#endregion
	}
}