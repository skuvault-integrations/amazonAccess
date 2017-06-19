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
using System.Net;
using AmazonAccess.Services.Common;

namespace AmazonAccess.Services.FbaInbound.Model
{
	/// <summary>
	/// Exception thrown by FBAInventoryServiceMWS operations
	/// </summary>
	public class FBAInboundServiceMWSException: MwsException
	{
		public FBAInboundServiceMWSException( string message, HttpStatusCode statusCode )
			: base( ( int )statusCode, message, null, null, null, null )
		{
		}

		public FBAInboundServiceMWSException( string message )
			: base( 0, message, null )
		{
		}

		public FBAInboundServiceMWSException( string message, HttpStatusCode statusCode, MwsResponseHeaderMetadata rhmd )
			: base( ( int )statusCode, message, null, null, null, rhmd )
		{
		}

		public FBAInboundServiceMWSException( Exception ex )
			: base( ex )
		{
		}

		public FBAInboundServiceMWSException( string message, Exception ex )
			: base( 0, message, ex )
		{
		}

		/// <summary>
		/// Constructs FBAInboundServiceMWSException with information available from service
		/// </summary>
		/// <param name="message">Overview of error</param>
		/// <param name="statusCode">HTTP status code for error response</param>
		/// <param name="errorCode">Error Code returned by the service</param>
		/// <param name="errorType">Error type. Possible types:  Sender, Receiver or Unknown</param>
		/// <param name="requestId">Request ID returned by the service</param>
		/// <param name="xml">Compete xml found in response</param>
		public FBAInboundServiceMWSException( String message, HttpStatusCode statusCode, String errorCode, String errorType, String requestId, String xml )
			: base( ( int )statusCode, message, errorCode, errorType, xml, null )
		{
		}

		public FBAInboundServiceMWSException( string message, HttpStatusCode statusCode, string errorCode,
			string errorType, string requestId, string xml, MwsResponseHeaderMetadata rhmd )
			: base( ( int )statusCode, message, errorCode, errorType, xml, rhmd )
		{
		}
	}
}