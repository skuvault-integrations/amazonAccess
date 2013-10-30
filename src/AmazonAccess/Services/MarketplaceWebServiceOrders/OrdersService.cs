using System.Collections.Generic;
using System.Linq;
using AmazonAccess.Exceptions;
using AmazonAccess.Services.MarketplaceWebServiceOrders.Model;
using CuttingEdge.Conditions;
using Netco.Logging;

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
			var orders = new List< ComposedOrder >();

			try
			{
				var response = this._client.ListOrders( this._request );
				if( response.IsSetListOrdersResult() )
				{
					var listInventorySupplyResult = response.ListOrdersResult;
					if( listInventorySupplyResult.IsSetOrders() )
						orders.AddRange( listInventorySupplyResult.Orders.Order.Select( o => new ComposedOrder( o ) ).ToList() );
					if( listInventorySupplyResult.IsSetNextToken() )
					{
						var nextResponse = this._client.ListOrdersByNextToken( new ListOrdersByNextTokenRequest
							{
								SellerId = this._request.SellerId,
								NextToken = listInventorySupplyResult.NextToken
							} );

						this.LoadNextOrdersInfoPage( nextResponse.ListOrdersByNextTokenResult, orders );
					}
				}
			}
			catch( MarketplaceWebServiceOrdersException ex )
			{
				this.Log().Info( string.Concat( "Caught Exception: ", ex.Message ) );
				this.Log().Info( string.Concat( "Response Status Code: ", ex.StatusCode ) );
				this.Log().Info( string.Concat( "Error Code: ", ex.ErrorCode ) );
				this.Log().Info( string.Concat( "Error Type: ", ex.ErrorType ) );
				this.Log().Info( string.Concat( "Request ID: ", ex.RequestId ) );

				throw new AmazonException( ex.Message );
			}

			this.GetOrderItems( orders );

			return orders;
		}

		private void LoadNextOrdersInfoPage( ListOrdersByNextTokenResult listInventorySupplyResult, List< ComposedOrder > orders )
		{
			if( listInventorySupplyResult.IsSetOrders() )
				orders.AddRange( listInventorySupplyResult.Orders.Order.Select( o => new ComposedOrder( o ) ).ToList() );
			if( listInventorySupplyResult.IsSetNextToken() )
			{
				var response = this._client.ListOrdersByNextToken( new ListOrdersByNextTokenRequest
					{
						SellerId = this._request.SellerId,
						NextToken = listInventorySupplyResult.NextToken
					} );

				this.LoadNextOrdersInfoPage( response.ListOrdersByNextTokenResult, orders );
			}
		}

		private void GetOrderItems( IEnumerable< ComposedOrder > orders )
		{
			foreach( var order in orders )
			{
				var itemsService = new OrderItemsService( this._client, new ListOrderItemsRequest
					{
						AmazonOrderId = order.AmazonOrder.AmazonOrderId,
						SellerId = this._request.SellerId
					} );
				order.OrderItems = itemsService.LoadOrderItems();
			}
		}
	}
}