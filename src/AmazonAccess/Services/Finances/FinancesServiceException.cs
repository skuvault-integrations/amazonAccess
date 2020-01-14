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
using System.Net;
using AmazonAccess.Services.Common;
using AmazonAccess.Services.Finances.Model;

namespace AmazonAccess.Services.Finances
{
	/// <summary>
	/// Exception thrown by MWSFinancesService operations
	/// </summary>
	public class FinancesServiceException : MwsException
	{
		public FinancesServiceException( string message, HttpStatusCode statusCode )
		: base( (int)statusCode, message, null, null, null, null ) { }

		public FinancesServiceException( string message )
		: base( 0, message, null ) { }

		public FinancesServiceException( string message, HttpStatusCode statusCode, ResponseHeaderMetadata rhmd )
		: base( (int)statusCode, message, null, null, null, rhmd ) { }

		public FinancesServiceException( Exception ex )
		: base( ex ) { }

		public FinancesServiceException( string message, Exception ex )
		: base( 0, message, ex ) { }

		public FinancesServiceException( string message, HttpStatusCode statusCode, string errorCode,
								string errorType, string requestId, string xml, ResponseHeaderMetadata rhmd )
		: base( (int)statusCode, message, errorCode, errorType, xml, rhmd ) { }

		public new ResponseHeaderMetadata ResponseHeaderMetadata
		{
			get 
			{ 
				MwsResponseHeaderMetadata baseRHMD = base.ResponseHeaderMetadata;
				
				if ( baseRHMD != null )
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

