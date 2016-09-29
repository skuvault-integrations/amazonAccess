using System;
using System.Collections.Generic;
using AmazonAccess.Misc;
using AmazonAccess.Models;
using AmazonAccess.Services.Orders.Model;
using CuttingEdge.Conditions;

namespace AmazonAccess.Services.Orders
{
	internal sealed class OrderItemsService
	{
		private readonly IOrdersServiceClient _client;
		private readonly AmazonCredentials _credentials;
		private readonly Throttler _throttler;

		public OrderItemsService( IOrdersServiceClient client, AmazonCredentials credentials, Throttler throttler )
		{
			Condition.Requires( client, "client" ).IsNotNull();
			Condition.Requires( credentials, "credentials" ).IsNotNull();
			Condition.Requires( throttler, "throttler" ).IsNotNull();

			this._client = client;
			this._credentials = credentials;
			this._throttler = throttler;
		}

		public IEnumerable< OrderItem > LoadOrderItems( string marker, string orderId )
		{
			AmazonLogger.Trace( "LoadOrderItems", this._credentials.SellerId, marker, "Begin invoke for order '{0}'", orderId );

			var request = new ListOrderItemsRequest
			{
				SellerId = this._credentials.SellerId,
				MWSAuthToken = this._credentials.MwsAuthToken,
				AmazonOrderId = orderId
			};
			var result = new List< OrderItem >();
			var response = ActionPolicies.Get.Get( () => this._throttler.Execute( () => this._client.ListOrderItems( request, marker ) ) );
			if( response.IsSetListOrderItemsResult() )
			{
				if( response.ListOrderItemsResult.IsSetOrderItems() )
					result.AddRange( response.ListOrderItemsResult.OrderItems );
				this.AddOrderItemsFromOtherPages( marker, response.ListOrderItemsResult.NextToken, result );
			}

			AmazonLogger.Trace( "LoadOrderItems", this._credentials.SellerId, marker, "End invoke for order '{0}'", orderId );
			return result;
		}

		private void AddOrderItemsFromOtherPages( string marker, string nextToken, List< OrderItem > result )
		{
			while( !string.IsNullOrEmpty( nextToken ) )
			{
				AmazonLogger.Trace( "AddOrderItemsFromOtherPages", this._credentials.SellerId, marker, "NextToken '{0}'", nextToken );

				var request = new ListOrderItemsByNextTokenRequest
				{
					SellerId = this._credentials.SellerId,
					MWSAuthToken = this._credentials.MwsAuthToken,
					NextToken = nextToken
				};
				var response = ActionPolicies.Get.Get( () => this._throttler.Execute( () => this._client.ListOrderItemsByNextToken( request, marker ) ) );
				if( response.IsSetListOrderItemsByNextTokenResult() )
				{
					if( response.ListOrderItemsByNextTokenResult.IsSetOrderItems() )
						result.AddRange( response.ListOrderItemsByNextTokenResult.OrderItems );
					nextToken = response.ListOrderItemsByNextTokenResult.NextToken;
				}
			}
		}

		public bool IsOrderItemsReceived( string marker, string orderId )
		{
			try
			{
				AmazonLogger.Trace( "IsOrderItemsReceived", this._credentials.SellerId, marker, "Begin invoke for order '{0}'", orderId );

				var request = new ListOrderItemsRequest
				{
					AmazonOrderId = orderId,
					SellerId = this._credentials.SellerId,
					MWSAuthToken = this._credentials.MwsAuthToken
				};
				var response = this._client.ListOrderItems( request, marker );
				return response.IsSetListOrderItemsResult();
			}
			catch( Exception ex )
			{
				AmazonLogger.Warn( "IsOrderItemsReceived", this._credentials.SellerId, marker, ex, "Checking order '{0}' items failed", orderId );
				return false;
			}
			finally
			{
				AmazonLogger.Trace( "IsOrderItemsReceived", this._credentials.SellerId, marker, "End invoke for order '{0}'", orderId );
			}
		}
	}
}