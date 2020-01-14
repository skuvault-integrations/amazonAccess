/*******************************************************************************
 * Copyright 2009-2019 Amazon Services. All Rights Reserved.
 * Licensed under the Apache License, Version 2.0 (the "License"); 
 *
 * You may not use this file except in compliance with the License. 
 * You may obtain a copy of the License at: http://aws.amazon.com/apache2.0
 * This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
 * CONDITIONS OF ANY KIND, either express or implied. See the License for the 
 * specific language governing permissions and limitations under the License.
 *******************************************************************************
 * MWS Finances Service
 * API Version: 2015-05-01
 * Library Version: 2019-02-25
 * Generated: Wed Mar 13 08:17:08 PDT 2019
 */

using System;
using AmazonAccess.Services.Common;
using AmazonAccess.Services.Finances.Model;

namespace AmazonAccess.Services.Finances
{
	/// <summary>
	/// MWSFinancesServiceClient is an implementation of MWSFinancesService
	/// </summary>
	public class FinancesServiceClient : IFinancesServiceClient 
	{
		private const string libraryVersion = "2019-02-25";

		private string servicePath;

		private MwsConnection connection;

		/// <summary>
		/// Create client.
		/// </summary>
		/// <param name="accessKey">Access Key</param>
		/// <param name="secretKey">Secret Key</param>
		/// <param name="applicationName">Application Name</param>
		/// <param name="applicationVersion">Application Version</param>
		/// <param name="config">configuration</param>
		public FinancesServiceClient(
			string accessKey,
			string secretKey,
			string applicationName,
			string applicationVersion,
			FinancesServiceConfig config )
		{
			connection = config.CopyConnection();
			connection.AwsAccessKeyId = accessKey;
			connection.AwsSecretKeyId = secretKey;
			connection.ApplicationName = applicationName;
			connection.ApplicationVersion = applicationVersion;
			connection.LibraryVersion = libraryVersion;
			connection.ServicePath = config.ServicePath;

			servicePath = config.ServicePath;
		}

		/// <summary>
		/// Create client.
		/// </summary>
		/// <param name="accessKey">Access Key</param>
		/// <param name="secretKey">Secret Key</param>
		/// <param name="config">configuration</param>
		public FinancesServiceClient( String accessKey, String secretKey, FinancesServiceConfig config )
		{
			connection = config.CopyConnection();
			connection.AwsAccessKeyId = accessKey;
			connection.AwsSecretKeyId = secretKey;
			connection.LibraryVersion = libraryVersion;
			connection.ServicePath = config.ServicePath;

			servicePath = config.ServicePath;
		}

		/// <summary>
		/// Create client.
		/// </summary>
		/// <param name="accessKey">Access Key</param>
		/// <param name="secretKey">Secret Key</param>
		public FinancesServiceClient(String accessKey, String secretKey) : this(accessKey, secretKey, new FinancesServiceConfig() )
		{
		}

		/// <summary>
		/// Create client.
		/// </summary>
		/// <param name="accessKey">Access Key</param>
		/// <param name="secretKey">Secret Key</param>
		/// <param name="applicationName">Application Name</param>
		/// <param name="applicationVersion">Application Version</param>
		public FinancesServiceClient(
			String accessKey, 
			String secretKey,
			String applicationName,
			String applicationVersion ) 
			: this( accessKey, secretKey, applicationName, applicationVersion, new FinancesServiceConfig() )
		{
		}

		public ListFinancialEventGroupsResponse ListFinancialEventGroups( ListFinancialEventGroupsRequest request, string marker )
		{
			return connection.Call(
				new FinancesServiceClient.Request< ListFinancialEventGroupsResponse >( "ListFinancialEventGroups" , typeof( ListFinancialEventGroupsResponse ), servicePath ),
				request,
				marker );
		}

		public ListFinancialEventGroupsByNextTokenResponse ListFinancialEventGroupsByNextToken( ListFinancialEventGroupsByNextTokenRequest request, string marker )
		{
			return connection.Call(
				new FinancesServiceClient.Request< ListFinancialEventGroupsByNextTokenResponse >( "ListFinancialEventGroupsByNextToken", typeof( ListFinancialEventGroupsByNextTokenResponse ), servicePath ),
				request,
				marker );
		}

		public ListFinancialEventsResponse ListFinancialEvents( ListFinancialEventsRequest request, string marker )
		{
			return connection.Call(
				new FinancesServiceClient.Request< ListFinancialEventsResponse >( "ListFinancialEvents", typeof( ListFinancialEventsResponse ), servicePath ),
				request, 
				marker );
		}

		public ListFinancialEventsByNextTokenResponse ListFinancialEventsByNextToken( ListFinancialEventsByNextTokenRequest request, string marker )
		{
			return connection.Call(
				new FinancesServiceClient.Request< ListFinancialEventsByNextTokenResponse >( "ListFinancialEventsByNextToken", typeof( ListFinancialEventsByNextTokenResponse ), servicePath ),
				request,
				marker );
		}

		public GetServiceStatusResponse GetServiceStatus( GetServiceStatusRequest request, string marker )
		{
			return connection.Call(
				new FinancesServiceClient.Request< GetServiceStatusResponse >( "GetServiceStatus", typeof( GetServiceStatusResponse ), servicePath ),
				request,
				marker );
		}

		private class Request< R > : IMwsRequestType< R > where R : IMwsObject
		{
			private string operationName;
			private Type responseClass;
			private string servicePath;

			public Request( string operationName, Type responseClass, string servicePath ) {
				this.operationName = operationName;
				this.responseClass = responseClass;
				this.servicePath = servicePath;
			}

			public string ServicePath
			{
				get { return servicePath; }
			}

			public string OperationName
			{
				get { return operationName; }
			}

			public Type ResponseClass
			{
				get { return responseClass; }
			}

			public MwsException WrapException( Exception cause ) {
				return new FinancesServiceException( cause );
			}

			public void SetResponseHeaderMetadata( IMwsObject response, MwsResponseHeaderMetadata rhmd ) {
				((IMWSResponse)response).ResponseHeaderMetadata = new ResponseHeaderMetadata( rhmd );
			}
		}
	}
}
