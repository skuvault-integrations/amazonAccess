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
 * Marketplace Web Service Sellers
 * API Version: 2011-07-01
 * Library Version: 2015-06-18
 * Generated: Thu Jun 18 20:37:46 GMT 2015
 */

using System;
using AmazonAccess.Services.Common;
using AmazonAccess.Services.Sellers.Model;

namespace AmazonAccess.Services.Sellers
{
	/// <summary>
	/// MarketplaceWebServiceSellersClient is an implementation of MarketplaceWebServiceSellers
	/// </summary>
	public class SellersServiceClient: ISellersServiceClient
	{
		private const string libraryVersion = "2015-06-18";

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
		public SellersServiceClient(
			string applicationName,
			string applicationVersion,
			string accessKey,
			string secretKey,
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
		public SellersServiceClient( String accessKey, String secretKey, MwsConfig config )
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
		public SellersServiceClient( String accessKey, String secretKey )
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
		public SellersServiceClient(
			String accessKey,
			String secretKey,
			String applicationName,
			String applicationVersion )
			: this( accessKey, secretKey, applicationName,
				applicationVersion, new MwsConfig() )
		{
		}

		public GetServiceStatusResponse GetServiceStatus( GetServiceStatusRequest request, string marker )
		{
			return this.connection.Call( new Request< GetServiceStatusResponse >( "GetServiceStatus", this.servicePath ), request, marker );
		}

		public ListMarketplaceParticipationsResponse ListMarketplaceParticipations( ListMarketplaceParticipationsRequest request, string marker )
		{
			return this.connection.Call( new Request< ListMarketplaceParticipationsResponse >( "ListMarketplaceParticipations", this.servicePath ), request, marker );
		}

		public ListMarketplaceParticipationsByNextTokenResponse ListMarketplaceParticipationsByNextToken( ListMarketplaceParticipationsByNextTokenRequest request, string marker )
		{
			return this.connection.Call( new Request< ListMarketplaceParticipationsByNextTokenResponse >( "ListMarketplaceParticipationsByNextToken", this.servicePath ), request, marker );
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
				return new MarketplaceWebServiceSellersException( cause );
			}

			public void SetResponseHeaderMetadata( IMwsObject response, MwsResponseHeaderMetadata rhmd )
			{
				( ( IMWSResponse )response ).ResponseHeaderMetadata = new ResponseHeaderMetadata( rhmd );
			}
		}
	}
}