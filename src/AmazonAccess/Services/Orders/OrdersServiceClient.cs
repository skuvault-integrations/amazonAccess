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
		private const string libraryVersion = "2015-09-24";

		private readonly string servicePath;

		private readonly MwsConnection connection;

		/// <summary>
		/// Create client.
		/// </summary>
		/// <param name="accessKey">Access Key</param>
		/// <param name="secretKey">Secret Key</param>
		/// <param name="applicationName">Application Name</param>
		/// <param name="applicationVersion">Application Version</param>
		/// <param name="config">configuration</param>
		public OrdersServiceClient(
			string accessKey,
			string secretKey,
			string applicationName,
			string applicationVersion,
			MwsConfig config )
		{
			this.connection = config.CopyConnection();
			this.connection.AwsAccessKeyId = accessKey;
			this.connection.AwsSecretKeyId = secretKey;
			this.connection.ApplicationName = applicationName;
			this.connection.ApplicationVersion = applicationVersion;
			this.connection.LibraryVersion = libraryVersion;
			this.servicePath = config.ServicePath;
		}

		/// <summary>
		/// Create client.
		/// </summary>
		/// <param name="accessKey">Access Key</param>
		/// <param name="secretKey">Secret Key</param>
		/// <param name="config">configuration</param>
		public OrdersServiceClient( String accessKey, String secretKey, MwsConfig config )
		{
			this.connection = config.CopyConnection();
			this.connection.AwsAccessKeyId = accessKey;
			this.connection.AwsSecretKeyId = secretKey;
			this.connection.LibraryVersion = libraryVersion;
			this.servicePath = config.ServicePath;
		}

		/// <summary>
		/// Create client.
		/// </summary>
		/// <param name="accessKey">Access Key</param>
		/// <param name="secretKey">Secret Key</param>
		public OrdersServiceClient( String accessKey, String secretKey )
			: this( accessKey, secretKey, new MwsConfig() )
		{
		}

		/// <summary>
		/// Create client.
		/// </summary>
		/// <param name="accessKey">Access Key</param>
		/// <param name="secretKey">Secret Key</param>
		/// <param name="applicationName">Application Name</param>
		/// <param name="applicationVersion">Application Version</param>
		public OrdersServiceClient(
			String accessKey,
			String secretKey,
			String applicationName,
			String applicationVersion )
			: this( accessKey, secretKey, applicationName,
				applicationVersion, new MwsConfig() )
		{
		}

		public GetOrderResponse GetOrder( GetOrderRequest request )
		{
			return this.connection.Call( new Request< GetOrderResponse >( "GetOrder", this.servicePath ), request );
		}

		public GetServiceStatusResponse GetServiceStatus( GetServiceStatusRequest request )
		{
			return this.connection.Call( new Request< GetServiceStatusResponse >( "GetServiceStatus", this.servicePath ), request );
		}

		public ListOrderItemsResponse ListOrderItems( ListOrderItemsRequest request )
		{
			return this.connection.Call( new Request< ListOrderItemsResponse >( "ListOrderItems", this.servicePath ), request );
		}

		public ListOrderItemsByNextTokenResponse ListOrderItemsByNextToken( ListOrderItemsByNextTokenRequest request )
		{
			return this.connection.Call( new Request< ListOrderItemsByNextTokenResponse >( "ListOrderItemsByNextToken", this.servicePath ), request );
		}

		public ListOrdersResponse ListOrders( ListOrdersRequest request )
		{
			return this.connection.Call( new Request< ListOrdersResponse >( "ListOrders", this.servicePath ), request );
		}

		public ListOrdersByNextTokenResponse ListOrdersByNextToken( ListOrdersByNextTokenRequest request )
		{
			return this.connection.Call( new Request< ListOrdersByNextTokenResponse >( "ListOrdersByNextToken", this.servicePath ), request );
		}

		private class Request< TResponse >: IMwsRequestType< TResponse > where TResponse : IMwsObject
		{
			public Request( string operationName, string servicePath )
			{
				this.OperationName = operationName;
				this.ServicePath = servicePath;
				this.ResponseClass = typeof( TResponse );
			}

			public string ServicePath{ get; private set; }

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