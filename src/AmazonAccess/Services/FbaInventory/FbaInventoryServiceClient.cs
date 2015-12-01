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
 * FBA Inventory Service MWS
 * API Version: 2010-10-01
 * Library Version: 2015-06-18
 * Generated: Thu Jun 18 19:30:05 GMT 2015
 */

using System;
using AmazonAccess.Services.Common;
using AmazonAccess.Services.FbaInventory.Model;

namespace AmazonAccess.Services.FbaInventory
{
	/// <summary>
	/// FBAInventoryServiceMWSClient is an implementation of FBAInventoryServiceMWS
	/// </summary>
	public class FbaInventoryServiceClient: IFbaInventoryServiceClient
	{
		private readonly MwsConnection connection;

		/// <summary>
		/// Create client.
		/// </summary>
		/// <param name="accessKey">Access Key</param>  
		/// <param name="secretKey">Secret Key</param>
		/// <param name="serviceUrl"></param>
		public FbaInventoryServiceClient(
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

		public FbaInventoryServiceClient( MwsConnection mwsConnection )
		{
			this.connection = mwsConnection;
		}

		public GetServiceStatusResponse GetServiceStatus( GetServiceStatusRequest request, string marker )
		{
			return this.connection.Call( new Request< GetServiceStatusResponse >( "GetServiceStatus" ), request, marker );
		}

		public ListInventorySupplyResponse ListInventorySupply( ListInventorySupplyRequest request, string marker )
		{
			return this.connection.Call( new Request< ListInventorySupplyResponse >( "ListInventorySupply" ), request, marker );
		}

		public ListInventorySupplyByNextTokenResponse ListInventorySupplyByNextToken( ListInventorySupplyByNextTokenRequest request, string marker )
		{
			return this.connection.Call( new Request< ListInventorySupplyByNextTokenResponse >( "ListInventorySupplyByNextToken" ), request, marker );
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
				return new FBAInventoryServiceMWSException( cause );
			}

			public void SetResponseHeaderMetadata( IMwsObject response, MwsResponseHeaderMetadata rhmd )
			{
				( ( IMWSResponse )response ).ResponseHeaderMetadata = new ResponseHeaderMetadata( rhmd );
			}
		}
	}
}