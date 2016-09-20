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
		private readonly MwsConnection connection;

		/// <summary>
		/// Create client.
		/// </summary>
		/// <param name="accessKey">Access Key</param>  
		/// <param name="secretKey">Secret Key</param>
		/// <param name="serviceUrl"></param>
		public SellersServiceClient(
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

		public SellersServiceClient( MwsConnection mwsConnection )
		{
			this.connection = mwsConnection;
		}

		public GetServiceStatusResponse GetServiceStatus( GetServiceStatusRequest request, string marker )
		{
			return this.connection.Call( new Request< GetServiceStatusResponse >( "GetServiceStatus" ), request, marker );
		}

		public ListMarketplaceParticipationsResponse ListMarketplaceParticipations( ListMarketplaceParticipationsRequest request, string marker )
		{
			return this.connection.Call( new Request< ListMarketplaceParticipationsResponse >( "ListMarketplaceParticipations" ), request, marker );
		}

		public ListMarketplaceParticipationsByNextTokenResponse ListMarketplaceParticipationsByNextToken( ListMarketplaceParticipationsByNextTokenRequest request, string marker )
		{
			return this.connection.Call( new Request< ListMarketplaceParticipationsByNextTokenResponse >( "ListMarketplaceParticipationsByNextToken" ), request, marker );
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
				return new MarketplaceWebServiceSellersException( cause );
			}

			public void SetResponseHeaderMetadata( IMwsObject response, MwsResponseHeaderMetadata rhmd )
			{
				( ( IMwsResponse )response ).ResponseHeaderMetadata = rhmd;
			}
		}
	}
}