using System.Collections.Generic;
using AmazonAccess.Misc;
using MarketplaceWebServiceOrders.Model;

namespace AmazonAccess.Services.MarketplaceWebServiceOrders
{
	internal sealed class OrderItemsService
	{
		private readonly IMarketplaceWebServiceOrders _client;
		private readonly ListOrderItemsRequest _request;

		public OrderItemsService( IMarketplaceWebServiceOrders client, ListOrderItemsRequest request )
		{
			this._client = client;
			this._request = request;
		}

		public IEnumerable< OrderItem > LoadOrderItems()
		{
			var orderItems = new List< OrderItem >();
			var response = this._client.ListOrderItems( this._request );
			ActionPolicies.CreateApiDelay( 2 ).Wait();

			AmazonLogger.Log.Trace( "[amazon]Loading order items for seller {0}", this._request.SellerId );

			if( response.IsSetListOrderItemsResult() )
			{
				var listInventorySupplyResult = response.ListOrderItemsResult;
				if( listInventorySupplyResult.IsSetOrderItems() )
					orderItems.AddRange( listInventorySupplyResult.OrderItems );
				if( listInventorySupplyResult.IsSetNextToken() )
				{
					var nextResponse = this._client.ListOrderItemsByNextToken( new ListOrderItemsByNextTokenRequest
					{
						SellerId = this._request.SellerId,
						NextToken = listInventorySupplyResult.NextToken,
						MWSAuthToken = this._request.MWSAuthToken
					} );

					this.LoadNextOrderItemsInfoPage( nextResponse.ListOrderItemsByNextTokenResult, orderItems );
					ActionPolicies.CreateApiDelay( 2 ).Wait();
				}
			}

			AmazonLogger.Log.Trace( "[amazon] Order items for seller {0} loaded", this._request.SellerId );

			return orderItems;
		}

		private void LoadNextOrderItemsInfoPage( ListOrderItemsByNextTokenResult listOrderItemsSupplyResult, List< OrderItem > orderItems )
		{
			if( listOrderItemsSupplyResult.IsSetOrderItems() )
				orderItems.AddRange( listOrderItemsSupplyResult.OrderItems );

			if( listOrderItemsSupplyResult.IsSetNextToken() )
			{
				var response = this._client.ListOrderItemsByNextToken( new ListOrderItemsByNextTokenRequest
				{
					SellerId = this._request.SellerId,
					NextToken = listOrderItemsSupplyResult.NextToken,
					MWSAuthToken = this._request.MWSAuthToken
				} );

				this.LoadNextOrderItemsInfoPage( response.ListOrderItemsByNextTokenResult, orderItems );
				ActionPolicies.CreateApiDelay( 2 ).Wait();
			}
		}
	}
}