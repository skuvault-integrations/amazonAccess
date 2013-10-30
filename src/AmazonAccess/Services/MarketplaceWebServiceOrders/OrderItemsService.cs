using System.Collections.Generic;
using AmazonAccess.Exceptions;
using AmazonAccess.Services.MarketplaceWebServiceOrders.Model;
using CuttingEdge.Conditions;
using Netco.Logging;

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
			try
			{
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