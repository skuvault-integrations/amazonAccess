/*******************************************************************************
 * Copyright 2009-2015 Amazon Services. All Rights Reserved.
 * Licensed under the Apache License, Version 2.0 (the "License"); 
 *
 * You may not use this file except in compliance with the License. 
 * You may obtain a copy of the License at: http://aws.amazon.com/apache2.0
 * This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
 * CONDITIONS OF ANY KIND, either express or implied. See the License for the 
 * specific language governing permissions and limitations under the License.
 *******************************************************************************
 * Marketplace Web Service Orders
 * API Version: 2013-09-01
 * Library Version: 2015-09-24
 * Generated: Fri Sep 25 20:06:25 GMT 2015
 */

using System;
using AmazonAccess.Services.Common;
using AmazonAccess.Services.Orders.Model;

namespace AmazonAccess.Services.Orders
{
	/// <summary>
	/// MarketplaceWebServiceOrdersClient is an implementation of MarketplaceWebServiceOrders
	/// </summary>
	public class OrdersServiceClient: IOrdersServiceClient
	{
		private readonly MwsConnection connection;

		/// <summary>
		/// Create client.
		/// </summary>
		/// <param name="accessKey">Access Key</param>  
		/// <param name="secretKey">Secret Key</param>
		/// <param name="serviceUrl"></param>
		public OrdersServiceClient(
			string accessKey,
			string secretKey,
			string serviceUrl )

		{
			this.connection = new MwsConnection
			{
				AwsAccessKeyId = accessKey,
				AwsSecretKeyId = secretKey,
				ServiceURL = serviceUrl
			};
		}

		public OrdersServiceClient( MwsConnection mwsConnection )
		{
			this.connection = mwsConnection;
		}

		public GetOrderResponse GetOrder( GetOrderRequest request, string marker )
		{
			return this.connection.Call( new Request< GetOrderResponse >( "GetOrder" ), request, marker );
		}

		public GetServiceStatusResponse GetServiceStatus( GetServiceStatusRequest request, string marker )
		{
			return this.connection.Call( new Request< GetServiceStatusResponse >( "GetServiceStatus" ), request, marker );
		}

		public ListOrderItemsResponse ListOrderItems( ListOrderItemsRequest request, string marker )
		{
			return this.connection.Call( new Request< ListOrderItemsResponse >( "ListOrderItems" ), request, marker );
		}

		public ListOrderItemsByNextTokenResponse ListOrderItemsByNextToken( ListOrderItemsByNextTokenRequest request, string marker )
		{
			return this.connection.Call( new Request< ListOrderItemsByNextTokenResponse >( "ListOrderItemsByNextToken" ), request, marker );
		}

		public ListOrdersResponse ListOrders( ListOrdersRequest request, string marker )
		{
			return this.connection.Call( new Request< ListOrdersResponse >( "ListOrders" ), request, marker );
		}

		public ListOrdersByNextTokenResponse ListOrdersByNextToken( ListOrdersByNextTokenRequest request, string marker )
		{
			return this.connection.Call( new Request< ListOrdersByNextTokenResponse >( "ListOrdersByNextToken" ), request, marker );
		}

		private class Request< TResponse >: IMwsRequestType< TResponse > where TResponse : IMwsObject
		{
			public Request( string operationName )
			{
				this.OperationName = operationName;
				this.ResponseClass = typeof( TResponse );
			}

			public string OperationName{ get; private set; }
			public Type ResponseClass{ get; private set; }

			public MwsException WrapException( Exception cause )
			{
				return new MarketplaceWebServiceOrdersException( cause );
			}

			public void SetResponseHeaderMetadata( IMwsObject response, MwsResponseHeaderMetadata rhmd )
			{
				( ( IMWSResponse )response ).ResponseHeaderMetadata = new ResponseHeaderMetadata( rhmd );
			}
		}
	}
}