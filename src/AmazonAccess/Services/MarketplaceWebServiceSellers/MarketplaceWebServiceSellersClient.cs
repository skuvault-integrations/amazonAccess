/*******************************************************************************
 * Copyright 2009-2014 Amazon Services. All Rights Reserved.
 * Licensed under the Apache License, Version 2.0 (the "License"); 
 *
 * You may not use this file except in compliance with the License. 
 * You may obtain a copy of the License at: http://aws.amazon.com/apache2.0
 * This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
 * CONDITIONS OF ANY KIND, either express or implied. See the License for the 
 * specific language governing permissions and limitations under the License.
 *******************************************************************************
 * Marketplace Web Service Sellers
 * API Version: 2011-07-01
 * Library Version: 2014-09-30
 * Generated: Mon Sep 15 19:38:40 GMT 2014
 */

using System;
using AmazonAccess.Services.MarketplaceWebServiceSellers.Model;
using AmazonAccess.Services.Utils;

namespace AmazonAccess.Services.MarketplaceWebServiceSellers
{

	/// <summary>
	/// MarketplaceWebServiceSellersClient is an implementation of MarketplaceWebServiceSellers
	/// </summary>
	public class MarketplaceWebServiceSellersClient: IMarketplaceWebServiceSellers
	{
		private const string LibraryVersion = "2014-09-30";
		private readonly string servicePath;
		private readonly MwsConnection connection;

		/// <summary>
		/// Create client.
		/// </summary>
		/// <param name="applicationName">Application Name</param>
		/// <param name="applicationVersion">Application Version</param>        
		/// <param name="accessKey">Access Key</param>  
		/// <param name="secretKey">Secret Key</param>
		/// <param name="config">configuration</param>
		public MarketplaceWebServiceSellersClient(
			string applicationName,
			string applicationVersion,
			string accessKey,
			string secretKey,
			MarketplaceWebServiceSellersConfig config )


		{
			this.connection = config.CopyConnection();
			this.connection.AwsAccessKeyId = accessKey;
			this.connection.AwsSecretKeyId = secretKey;
			this.connection.ApplicationName = applicationName;
			this.connection.ApplicationVersion = applicationVersion;
			this.connection.LibraryVersion = LibraryVersion;
			this.servicePath = config.ServicePath;
		}

		/// <summary>
		/// Create client.
		/// </summary>
		/// <param name="accessKey">Access Key</param>
		/// <param name="secretKey">Secret Key</param>
		/// <param name="config">configuration</param>
		public MarketplaceWebServiceSellersClient( String accessKey, String secretKey, MarketplaceWebServiceSellersConfig config )
		{
			this.connection = config.CopyConnection();
			this.connection.AwsAccessKeyId = accessKey;
			this.connection.AwsSecretKeyId = secretKey;
			this.connection.LibraryVersion = LibraryVersion;
			this.servicePath = config.ServicePath;
		}

		/// <summary>
		/// Create client.
		/// </summary>
		/// <param name="accessKey">Access Key</param>
		/// <param name="secretKey">Secret Key</param>
		public MarketplaceWebServiceSellersClient( String accessKey, String secretKey )
			: this( accessKey, secretKey, new MarketplaceWebServiceSellersConfig() )
		{
		}

		/// <summary>
		/// Create client.
		/// </summary>
		/// <param name="accessKey">Access Key</param>
		/// <param name="secretKey">Secret Key</param>
		/// <param name="applicationName">Application Name</param>
		/// <param name="applicationVersion">Application Version</param>
		public MarketplaceWebServiceSellersClient(
			String accessKey,
			String secretKey,
			String applicationName,
			String applicationVersion )
			: this( accessKey, secretKey, applicationName,
				applicationVersion, new MarketplaceWebServiceSellersConfig() )
		{
		}

		public GetServiceStatusResponse GetServiceStatus( GetServiceStatusRequest request )
		{
			return this.connection.Call(
				new Request< GetServiceStatusResponse >( "GetServiceStatus", typeof( GetServiceStatusResponse ), this.servicePath ),
				request );
		}

		public ListMarketplaceParticipationsResponse ListMarketplaceParticipations( ListMarketplaceParticipationsRequest request )
		{
			return this.connection.Call(
				new Request< ListMarketplaceParticipationsResponse >( "ListMarketplaceParticipations", typeof( ListMarketplaceParticipationsResponse ), this.servicePath ),
				request );
		}

		public ListMarketplaceParticipationsByNextTokenResponse ListMarketplaceParticipationsByNextToken( ListMarketplaceParticipationsByNextTokenRequest request )
		{
			return this.connection.Call(
				new Request< ListMarketplaceParticipationsByNextTokenResponse >( "ListMarketplaceParticipationsByNextToken", typeof( ListMarketplaceParticipationsByNextTokenResponse ), this.servicePath ),
				request );
		}

		public GetAuthTokenResponse GetAuthToken( GetAuthTokenRequest request )
		{
			return this.connection.Call(
				new Request< GetAuthTokenResponse >( "GetAuthToken", typeof( GetAuthTokenResponse ), this.servicePath ),
				request );
		}

		private class Request< R >: IMwsRequestType< R > where R : IMwsObject
		{
			private readonly string operationName;
			private readonly Type responseClass;
			private readonly string servicePath;

			public Request( string operationName, Type responseClass, string servicePath )
			{
				this.operationName = operationName;
				this.responseClass = responseClass;
				this.servicePath = servicePath;
			}

			public string ServicePath
			{
				get { return this.servicePath; }
			}

			public string OperationName
			{
				get { return this.operationName; }
			}

			public Type ResponseClass
			{
				get { return this.responseClass; }
			}

			public MwsException WrapException( Exception cause )
			{
				return new MarketplaceWebServiceSellersException( cause );
			}

			public void SetResponseHeaderMetadata( IMwsObject response, MwsResponseHeaderMetadata rhmd )
			{
				( ( IMWSResponse )response ).ResponseHeaderMetadata = new ResponseHeaderMetadata( rhmd );
			}
		}
	}
}