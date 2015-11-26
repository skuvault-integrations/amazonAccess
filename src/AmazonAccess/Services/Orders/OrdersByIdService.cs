using System.Collections.Generic;
using System.Linq;
using AmazonAccess.Misc;
using AmazonAccess.Services.Orders.Model;
using CuttingEdge.Conditions;

namespace AmazonAccess.Services.Orders
{
	public sealed class OrdersByIdService
	{
		private readonly IOrdersServiceClient _client;
		private readonly GetOrderRequest _request;
		private readonly Throttler _getOrdersByIdThrottler = new Throttler( 6, 61 );
		private readonly Throttler _orderItemsThrottler = new Throttler( 30, 2 );

		public OrdersByIdService( IOrdersServiceClient client, GetOrderRequest request )
		{
			Condition.Requires( client, "client" ).IsNotNull();
			Condition.Requires( request, "request" ).IsNotNull();

			this._client = client;
			this._request = request;
		}

		public IEnumerable< ComposedOrder > LoadOrders()
		{
			var response = ActionPolicies.Get.Get( () => this._getOrdersByIdThrottler.Execute( () => this._client.GetOrder( this._request ) ) );

			if( response.IsSetGetOrderResult() )
			{
				var ordersResult = response.GetOrderResult;
				foreach( var order in this.FillOrdersWithItems( ordersResult ) )
				{
					yield return order;
				}
			}
		}

		private IEnumerable< ComposedOrder > FillOrdersWithItems( GetOrderResult ordersResult )
		{
			if( ordersResult.IsSetOrders() )
			{
				var orders = ordersResult.Orders.Select( o => new ComposedOrder( o ) ).ToList();
				this.FillOrders( orders );
				foreach( var order in orders )
				{
					yield return order;
				}
			}
		}

		private void FillOrders( IEnumerable< ComposedOrder > orders )
		{
			foreach( var order in orders )
			{
				order.OrderItems = this.GetOrderItems( order.AmazonOrder.AmazonOrderId );
			}
		}

		private IEnumerable< OrderItem > GetOrderItems( string orderId )
		{
			var itemsService = new OrderItemsService( this._client, new ListOrderItemsRequest
			{
				AmazonOrderId = orderId,
				SellerId = this._request.SellerId,
				MWSAuthToken = this._request.MWSAuthToken
			}, this._orderItemsThrottler );

			return itemsService.LoadOrderItems();
		}
	}
}