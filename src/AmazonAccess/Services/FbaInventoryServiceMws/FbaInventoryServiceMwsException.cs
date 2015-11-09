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
 * FBA Inventory Service MWS
 * API Version: 2010-10-01
 * Library Version: 2014-09-30
 * Generated: Fri Sep 26 16:01:24 GMT 2014
 */

using System;
using System.Net;
using AmazonAccess.Services.FbaInventoryServiceMws.Model;
using AmazonAccess.Services.Common;

namespace AmazonAccess.Services.FbaInventoryServiceMws
{

	/// <summary>
	/// Exception thrown by FBAInventoryServiceMWS operations
	/// </summary>
	public class FbaInventoryServiceMwsException: MwsException
	{

		public FbaInventoryServiceMwsException( string message, HttpStatusCode statusCode )
			: base( ( int )statusCode, message, null, null, null, null )
		{
		}

		public FbaInventoryServiceMwsException( string message )
			: base( 0, message, null )
		{
		}

		public FbaInventoryServiceMwsException( string message, HttpStatusCode statusCode, ResponseHeaderMetadata rhmd )
			: base( ( int )statusCode, message, null, null, null, rhmd )
		{
		}

		public FbaInventoryServiceMwsException( Exception ex )
			: base( ex )
		{
		}

		public FbaInventoryServiceMwsException( string message, Exception ex )
			: base( 0, message, ex )
		{
		}

		/// <summary>
		/// Constructs FBAInventoryServiceMWSException with information available from service
		/// </summary>
		/// <param name="message">Overview of error</param>
		/// <param name="statusCode">HTTP status code for error response</param>
		/// <param name="errorCode">Error Code returned by the service</param>
		/// <param name="errorType">Error type. Possible types:  Sender, Receiver or Unknown</param>
		/// <param name="requestId">Request ID returned by the service</param>
		/// <param name="xml">Compete xml found in response</param>
		public FbaInventoryServiceMwsException( String message, HttpStatusCode statusCode, String errorCode, String errorType, String requestId, String xml )
			: base( ( int )statusCode, message, errorCode, errorType, xml, null )
		{
		}

		public FbaInventoryServiceMwsException( string message, HttpStatusCode statusCode, string errorCode,
			string errorType, string requestId, string xml, ResponseHeaderMetadata rhmd )
			: base( ( int )statusCode, message, errorCode, errorType, xml, rhmd )
		{
		}

		public new ResponseHeaderMetadata ResponseHeaderMetadata
		{
			get
			{
				MwsResponseHeaderMetadata baseRHMD = base.ResponseHeaderMetadata;
				if( baseRHMD != null )
				{
					return new ResponseHeaderMetadata( baseRHMD );
				}
				else
				{
					return null;
				}
			}
		}

	}

}