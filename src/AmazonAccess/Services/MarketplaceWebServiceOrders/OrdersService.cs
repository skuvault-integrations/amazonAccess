using System.Collections.Generic;
using System.Linq;
using AmazonAccess.Misc;
using AmazonAccess.Services.MarketplaceWebServiceOrders.Model;
using CuttingEdge.Conditions;

namespace AmazonAccess.Services.MarketplaceWebServiceOrders
{
	public sealed class OrdersService
	{
		private readonly IMarketplaceWebServiceOrders _client;
		private readonly ListOrdersRequest _request;
		private readonly Throttler _getOrdersThrottler = new Throttler( 6, 61 );
		private readonly Throttler _orderItemsThrottler = new Throttler( 30, 2 );

		public OrdersService( IMarketplaceWebServiceOrders client, ListOrdersRequest request )
		{
			Condition.Requires( client, "client" ).IsNotNull();
			Condition.Requires( request, "request" ).IsNotNull();

			this._client = client;
			this._request = request;
		}

		public IEnumerable< ComposedOrder > LoadOrders()
		{
			var response = ActionPolicies.AmazonThrottlerGetPolicy.Get( () => _getOrdersThrottler.ExecuteWithTrottling( () =>
				this._client.ListOrders( this._request ) ) );

			if( response.IsSetListOrdersResult() )
			{
				var listInventorySupplyResult = response.ListOrdersResult;
				foreach( var order in this.FillOrdersWithItems( listInventorySupplyResult ) )
				{
					yield return order;
				}
	
				foreach( var order in this.LoadRestOfOrders( listInventorySupplyResult.NextToken ) )
				{
					yield return order;
				}
			}
		}

		private IEnumerable< ComposedOrder > FillOrdersWithItems( ListOrdersResult listInventorySupplyResult )
		{
			if( listInventorySupplyResult.IsSetOrders() )
			{
				var orders = listInventorySupplyResult.Orders.Select( o => new ComposedOrder( o ) ).ToList();
				this.FillOrders( orders );
				foreach( var order in orders )
				{
					yield return order;
				}
			}
		}

		private IEnumerable< ComposedOrder > LoadRestOfOrders( string nextToken )
		{
			while( !string.IsNullOrEmpty( nextToken ) )
			{
				var nextResponse = ActionPolicies.AmazonThrottlerGetPolicy.Get( () => _getOrdersThrottler.ExecuteWithTrottling( () =>
					this._client.ListOrdersByNextToken( new ListOrdersByNextTokenRequest
					{
						SellerId = this._request.SellerId,
						NextToken = nextToken,
						MWSAuthToken = this._request.MWSAuthToken
					} ) ) );

				var listInventorySupplyResult = nextResponse.ListOrdersByNextTokenResult;
				nextToken = listInventorySupplyResult.NextToken;

				if( !listInventorySupplyResult.IsSetOrders() )
					continue;
				
				var orders = listInventorySupplyResult.Orders.Select( o => new ComposedOrder( o ) ).ToList();
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
			}, _orderItemsThrottler );

			return itemsService.LoadOrderItems();
		}
	}
}