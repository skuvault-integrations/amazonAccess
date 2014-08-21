using System.Collections.Generic;
using System.Linq;
using AmazonAccess.Misc;
using AmazonAccess.Services.MarketplaceWebServiceOrders.Model;
using CuttingEdge.Conditions;

namespace AmazonAccess.Services.MarketplaceWebServiceOrders
{
	public class OrdersService
	{
		private readonly IMarketplaceWebServiceOrders _client;
		private readonly ListOrdersRequest _request;

		public OrdersService( IMarketplaceWebServiceOrders client, ListOrdersRequest request )
		{
			Condition.Requires( client, "client" ).IsNotNull();
			Condition.Requires( request, "request" ).IsNotNull();

			this._client = client;
			this._request = request;
		}

		public IEnumerable< ComposedOrder > LoadOrders()
		{
			var requestQuota = 6;
			var orders = new List< ComposedOrder >();
			var response = this._client.ListOrders( this._request );
			requestQuota--;

			if( response.IsSetListOrdersResult() )
			{
				var listInventorySupplyResult = response.ListOrdersResult;
				if( listInventorySupplyResult.IsSetOrders() )
				{
					orders.AddRange( listInventorySupplyResult.Orders.Order.Select( o => new ComposedOrder( o ) ).ToList() );
					this.FillOrders( orders );
				}

				if( !listInventorySupplyResult.IsSetNextToken() )
					return orders;

				var nextResponse = this._client.ListOrdersByNextToken( new ListOrdersByNextTokenRequest
				{
					SellerId = this._request.SellerId,
					NextToken = listInventorySupplyResult.NextToken
				} );

				requestQuota --;
				this.LoadNextOrdersInfoPage( nextResponse.ListOrdersByNextTokenResult, orders, requestQuota );
			}

			return orders;
		}

		private void LoadNextOrdersInfoPage( ListOrdersByNextTokenResult listInventorySupplyResult, List< ComposedOrder > orders, int requestQuota )
		{
			if( listInventorySupplyResult.IsSetOrders() )
			{
				orders.AddRange( listInventorySupplyResult.Orders.Order.Select( o => new ComposedOrder( o ) ).ToList() );
				this.FillOrders( orders );
			}

			if( !listInventorySupplyResult.IsSetNextToken() )
				return;

			if( requestQuota == 0 )
			{
				ActionPolicies.CreateApiDelay( 60 ).Wait();
				requestQuota++;
			}

			var response = this._client.ListOrdersByNextToken( new ListOrdersByNextTokenRequest
			{
				SellerId = this._request.SellerId,
				NextToken = listInventorySupplyResult.NextToken
			} );

			requestQuota--;
			this.LoadNextOrdersInfoPage( response.ListOrdersByNextTokenResult, orders, requestQuota );
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
				SellerId = this._request.SellerId
			} );

			var orderItems = itemsService.LoadOrderItems();
			foreach( var item in orderItems )
			{
				yield return item;
			}
		}
	}
}