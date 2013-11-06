using System.Collections.Generic;
using AmazonAccess.Services.MarketplaceWebServiceOrders.Model;
using CuttingEdge.Conditions;

namespace AmazonAccess.Services.MarketplaceWebServiceOrders
{
	internal class OrderItemsService
	{
		private readonly IMarketplaceWebServiceOrders _client;
		private readonly ListOrderItemsRequest _request;

		public OrderItemsService( IMarketplaceWebServiceOrders client, ListOrderItemsRequest request )
		{
			Condition.Requires( client, "client" ).IsNotNull();
			Condition.Requires( request, "request" ).IsNotNull();

			this._client = client;
			this._request = request;
		}

		public List< OrderItem > LoadOrderItems()
		{
			var orderItems = new List< OrderItem >();
			var response = this._client.ListOrderItems( this._request );
			if( response.IsSetListOrderItemsResult() )
			{
				var listInventorySupplyResult = response.ListOrderItemsResult;
				if( listInventorySupplyResult.IsSetOrderItems() )
					orderItems.AddRange( listInventorySupplyResult.OrderItems.OrderItem );
				if( listInventorySupplyResult.IsSetNextToken() )
				{
					var nextResponse = this._client.ListOrderItemsByNextToken( new ListOrderItemsByNextTokenRequest
						{
							SellerId = this._request.SellerId,
							NextToken = listInventorySupplyResult.NextToken
						} );

					this.LoadNextOrderItemsInfoPage( nextResponse.ListOrderItemsByNextTokenResult, orderItems );
				}
			}

			return orderItems;
		}

		private void LoadNextOrderItemsInfoPage( ListOrderItemsByNextTokenResult listOrderItemsSupplyResult, List< OrderItem > orderItems )
		{
			if( listOrderItemsSupplyResult.IsSetOrderItems() )
				orderItems.AddRange( listOrderItemsSupplyResult.OrderItems.OrderItem );
			if( listOrderItemsSupplyResult.IsSetNextToken() )
			{
				var response = this._client.ListOrderItemsByNextToken( new ListOrderItemsByNextTokenRequest
					{
						SellerId = this._request.SellerId,
						NextToken = listOrderItemsSupplyResult.NextToken
					} );

				this.LoadNextOrderItemsInfoPage( response.ListOrderItemsByNextTokenResult, orderItems );
			}
		}
	}
}