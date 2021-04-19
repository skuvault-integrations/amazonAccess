using System;
using System.Collections.Generic;
using System.Linq;
using AmazonAccess.Misc;
using AmazonAccess.Models;
using AmazonAccess.Services.Finances;
using AmazonAccess.Services.Orders.Model;
using CuttingEdge.Conditions;

namespace AmazonAccess.Services.Orders
{
	public sealed class OrdersService
	{
		private readonly IOrdersServiceClient _client;
		private readonly IFinancesServiceClient _financesServiceClient;
		private readonly AmazonCredentials _credentials;
		private readonly OrderItemsService _orderItemsService;
		private readonly FinancesService _financesService;
		private readonly Throttler _getOrdersThrottler = new Throttler( 6, 61 );
		private readonly Throttler _orderItemsThrottler = new Throttler( 30, 2 );

		public OrdersService( IOrdersServiceClient client, IFinancesServiceClient financesServiceClient, AmazonCredentials credentials )
		{
			Condition.Requires( client, "client" ).IsNotNull();
			Condition.Requires( financesServiceClient, "financesServiceClient" ).IsNotNull();
			Condition.Requires( credentials, "credentials" ).IsNotNull();

			this._client = client;
			this._financesServiceClient = financesServiceClient;
			this._credentials = credentials;
			this._orderItemsService = new OrderItemsService( this._client, this._credentials, this._orderItemsThrottler );
			this._financesService = new FinancesService( this._financesServiceClient, this._credentials );
		}

		public int LoadOrders( string marker, DateTime dateFrom, DateTime dateTo, Action< ComposedOrder > processOrderAction )
		{
			AmazonLogger.Trace( "LoadOrders", this._credentials.SellerId, marker, "Begin invoke for date range from '{0}' to '{1}'", dateFrom, dateTo );

			var request = new ListOrdersRequest
			{
				SellerId = this._credentials.SellerId,
				MWSAuthToken = this._credentials.MwsAuthToken,
				LastUpdatedAfter = dateFrom,
				LastUpdatedBefore = dateTo,
				MarketplaceId = this._credentials.AmazonMarketplaces.GetMarketplaceIdAsList()
			};
			var ordersCount = 0;
			var response = ActionPolicies.Get.Get( () => this._getOrdersThrottler.Execute( () => this._client.ListOrders( request, marker ) ) );
			if( response.IsSetListOrdersResult() )
			{
				if( response.ListOrdersResult.IsSetOrders() )
					ordersCount += this.FillAndProcessOrders( marker, response.ListOrdersResult.Orders, processOrderAction );
				ordersCount += this.AddOrdersFromOtherPages( marker, response.ListOrdersResult.NextToken, processOrderAction );
			}

			AmazonLogger.Trace( "LoadOrders", this._credentials.SellerId, marker, "End invoke for date range from '{0}' to '{1}'. Received '{2}' orders", dateFrom, dateTo, ordersCount );
			return ordersCount;
		}

		private int AddOrdersFromOtherPages( string marker, string nextToken, Action< ComposedOrder > processOrderAction )
		{
			var ordersCount = 0;
			while( !string.IsNullOrEmpty( nextToken ) )
			{
				AmazonLogger.Trace( "AddOrdersFromOtherPages", this._credentials.SellerId, marker, "NextToken '{0}'", nextToken );

				var request = new ListOrdersByNextTokenRequest
				{
					SellerId = this._credentials.SellerId,
					MWSAuthToken = this._credentials.MwsAuthToken,
					NextToken = nextToken
				};
				var response = ActionPolicies.Get.Get( () => this._getOrdersThrottler.Execute( () => this._client.ListOrdersByNextToken( request, marker ) ) );
				if( response.IsSetListOrdersByNextTokenResult() )
				{
					if( response.ListOrdersByNextTokenResult.IsSetOrders() )
						ordersCount += this.FillAndProcessOrders( marker, response.ListOrdersByNextTokenResult.Orders, processOrderAction );
					nextToken = response.ListOrdersByNextTokenResult.NextToken;
				}
			}
			return ordersCount;
		}

		private int FillAndProcessOrders( string marker, IReadOnlyCollection< Order > orders, Action< ComposedOrder > processOrderAction )
		{
			foreach( var order in orders )
			{
				var resultOrder = new ComposedOrder( order );
				resultOrder.OrderItems = this._orderItemsService.LoadOrderItems( marker, resultOrder.AmazonOrder.AmazonOrderId );
				resultOrder.OrderFees = this._financesService.LoadOrderFees( marker, resultOrder.AmazonOrder.AmazonOrderId );
				processOrderAction( resultOrder );
			}
			return orders.Count;
		}

		public bool IsOrdersReceived( string marker, DateTime dateFrom, DateTime dateTo )
		{
			try
			{
				AmazonLogger.Trace( "IsOrdersReceived", this._credentials.SellerId, marker, "Begin invoke for date range from '{0}' to '{1}'", dateFrom, dateTo );

				var request = new ListOrdersRequest
				{
					SellerId = this._credentials.SellerId,
					MWSAuthToken = this._credentials.MwsAuthToken,
					LastUpdatedAfter = dateFrom,
					LastUpdatedBefore = dateTo,
					MarketplaceId = this._credentials.AmazonMarketplaces.GetMarketplaceIdAsList()
				};
				var response = this._client.ListOrders( request, marker );
				if( !response.IsSetListOrdersResult() )
					return false;
				if( !response.ListOrdersResult.IsSetOrders() )
					return true;

				foreach( var order in response.ListOrdersResult.Orders.Take( 5 ) )
				{
					var resultOrder = new ComposedOrder( order );
					if( !this._orderItemsService.IsOrderItemsReceived( marker, resultOrder.AmazonOrder.AmazonOrderId ) )
						return false;
				}
				return true;
			}
			catch( Exception ex )
			{
				AmazonLogger.Warn( "IsOrdersReceived", this._credentials.SellerId, marker, ex, "Checking orders failed" );
				return false;
			}
			finally
			{
				AmazonLogger.Trace( "IsOrdersReceived", this._credentials.SellerId, marker, "End invoke for date range from '{0}' to '{1}'", dateFrom, dateTo );
			}
		}
	}
}