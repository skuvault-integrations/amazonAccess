using System;
using System.Collections.Generic;
using AmazonAccess.Misc;
using AmazonAccess.Models;
using AmazonAccess.Services.Orders.Model;
using CuttingEdge.Conditions;

namespace AmazonAccess.Services.Orders
{
	public sealed class OrdersByIdService
	{
		private readonly IOrdersServiceClient _client;
		private readonly AmazonCredentials _credentials;
		private readonly OrderItemsService _orderItemsService;
		private readonly Throttler _getOrdersByIdThrottler = new Throttler( 6, 61 );
		private readonly Throttler _orderItemsThrottler = new Throttler( 30, 2 );

		public OrdersByIdService( IOrdersServiceClient client, AmazonCredentials credentials )
		{
			Condition.Requires( client, "client" ).IsNotNull();
			Condition.Requires( credentials, "credentials" ).IsNotNull();

			this._client = client;
			this._credentials = credentials;
			this._orderItemsService = new OrderItemsService( this._client, this._credentials, this._orderItemsThrottler );
		}

		public int LoadOrdersById( string marker, List< string > ids, Action< ComposedOrder > processOrderAction )
		{
			var idsStr = string.Join( ",", ids );
			AmazonLogger.Trace( "LoadOrdersById", this._credentials.SellerId, marker, "Begin invoke for ids '{0}'", idsStr );

			var request = new GetOrderRequest
			{
				SellerId = this._credentials.SellerId,
				MWSAuthToken = this._credentials.MwsAuthToken,
				AmazonOrderId = ids
			};
			var ordersCount = 0;
			var response = ActionPolicies.Get.Get( () => this._getOrdersByIdThrottler.Execute( () => this._client.GetOrder( request, marker ) ) );
			if( response.IsSetGetOrderResult() )
			{
				if( response.GetOrderResult.IsSetOrders() )
					ordersCount += this.FillAndProcessOrders( marker, response.GetOrderResult.Orders, processOrderAction );
			}

			AmazonLogger.Trace( "LoadOrdersById", this._credentials.SellerId, marker, "End invoke for ids '{0}'. Received '{1}' orders", idsStr, ordersCount );
			return ordersCount;
		}

		private int FillAndProcessOrders( string marker, IReadOnlyCollection< Order > orders, Action< ComposedOrder > processOrderAction )
		{
			foreach( var order in orders )
			{
				var resultOrder = new ComposedOrder( order );
				resultOrder.OrderItems = this._orderItemsService.LoadOrderItems( marker, resultOrder.AmazonOrder.AmazonOrderId );
				processOrderAction( resultOrder );
			}
			return orders.Count;
		}
	}
}