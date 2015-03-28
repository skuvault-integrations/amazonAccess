using System;
using System.Collections.Generic;
using System.Linq;
using AmazonAccess.Misc;
using AmazonAccess.Models;
using AmazonAccess.Services;
using AmazonAccess.Services.FbaInventoryServiceMws;
using AmazonAccess.Services.FbaInventoryServiceMws.Model;
using AmazonAccess.Services.MarketplaceWebServiceFeeds;
using AmazonAccess.Services.MarketplaceWebServiceOrders;
using AmazonAccess.Services.MarketplaceWebServiceOrders.Model;
using AmazonAccess.Services.MarketplaceWebServiceSellers;
using AmazonAccess.Services.MarketplaceWebServiceSellers.Model;
using CuttingEdge.Conditions;
using MarketplaceWebService.Model;

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
		public IEnumerable< ComposedOrder > GetOrders( DateTime dateFrom, DateTime dateTo )
		{
			var client = this._factory.CreateOrdersClient( "SkuVault", "1.0" );
			var request = new ListOrdersRequest
			{
				SellerId = this._credentials.SellerId,
				LastUpdatedAfter = dateFrom,
				//LastUpdatedBefore = dateTo,
				MarketplaceId = this._credentials.AmazonMarketplace.GetMarketplaceIdAsList(),
				MWSAuthToken = this._credentials.MwsAuthToken
			};

			AmazonLogger.Log.Trace( "[amazon] Loading orders for seller {0}", this._credentials.SellerId );

			var service = new OrdersService( client, request );
			foreach( var order in service.LoadOrders() )
			{
				yield return order;
			}

			AmazonLogger.Log.Trace( "[amazon] Orders for seller {0} loaded", this._credentials.SellerId );
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
				MarketplaceIdList = new IdList { Id = this._credentials.AmazonMarketplace.GetMarketplaceIdAsList() },
				Merchant = this._credentials.SellerId,
				FeedType = FeedType.InventoryQuantityUpdate.Description,
				FeedContent = contentStream,
				ContentMD5 = MarketplaceWebServiceFeedsClient.CalculateContentMD5( contentStream ),
				MWSAuthToken = this._credentials.MwsAuthToken
			};

			return request;
		}

		private void SubmitInventoryUpdateRequest( IMarketplaceWebServiceFeeds client, IEnumerable< AmazonInventoryItem > inventoryItems )
		{
			var request = this.InitInventoryFeedRequest( inventoryItems );
			var service = new FeedsService();

			ActionPolicies.AmazonSubmitPolicy.Do( () =>
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
					QueryStartDateTime = DateTime.MinValue,
					ResponseGroup = "Detailed",
					MWSAuthToken = this._credentials.MwsAuthToken
				};
				var service = new InventorySupplyService( client, request );

				AmazonLogger.Log.Trace( "[amazon] Loading FBA inventory for seller {0}", this._credentials.SellerId );

				inventory.AddRange( service.LoadInventory() );

				AmazonLogger.Log.Trace( "[amazon] FBA inventiry for seller {0} loaded", this._credentials.SellerId );
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

		#region Sellers
		public string GetMwsAuthToken()
		{
			var token = string.Empty;
			ActionPolicies.AmazonGetPolicy.Do( () =>
			{
				var client = this._factory.CreateSellersClient();
				var request = new GetAuthTokenRequest
				{
					SellerId = this._credentials.SellerId,
				};
				var service = new SellersService( client, request );
				try
				{
					token = service.GetToken();
				}
				catch( MarketplaceWebServiceSellersException x )
				{
					if( !x.Message.Contains( "Invalid seller id" ) ) // ignore error with invalid seller id, rethrow on other issues
						throw;
				}
			} );
			return token;
		}
		#endregion
	}
}