/******************************************************************************* 
 *  Copyright 2009 Amazon Services.
 *  Licensed under the Apache License, Version 2.0 (the "License"); 
 *  
 *  You may not use this file except in compliance with the License. 
 *  You may obtain a copy of the License at: http://aws.amazon.com/apache2.0
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the 
 *  specific language governing permissions and limitations under the License.
 * ***************************************************************************** 
 * 
 *  Marketplace Web Service CSharp Library
 *  API Version: 2009-01-01
 *  Generated: Mon Mar 16 17:31:42 PDT 2009 
 * 
 */

using System;
using System.Net;
using AmazonAccess.Services.Common;

namespace AmazonAccess.Services.FeedsReports.Model
{
	/// <summary>
	/// Exception thrown by MarketplaceWebServiceSellers operations
	/// </summary>
	public class FeedReportServiceException: MwsException
	{
		public FeedReportServiceException( string message, HttpStatusCode statusCode )
			: base( ( int )statusCode, message, null, null, null, null )
		{
		}

		public FeedReportServiceException( string message )
			: base( 0, message, null )
		{
		}

		public FeedReportServiceException( string message, HttpStatusCode statusCode, ResponseHeaderMetadata rhmd )
			: base( ( int )statusCode, message, null, null, null, rhmd )
		{
		}

		public FeedReportServiceException( Exception ex )
			: base( ex )
		{
		}

		public FeedReportServiceException( string message, Exception ex )
			: base( 0, message, ex )
		{
		}

		public FeedReportServiceException( string message, HttpStatusCode statusCode, string errorCode,
			string errorType, string requestId, string xml, ResponseHeaderMetadata rhmd )
			: base( ( int )statusCode, message, errorCode, errorType, xml, rhmd )
		{
		}

		public FeedReportServiceException( string message, HttpStatusCode statusCode, string errorCode,
			string errorType, string requestId, string xml )
			: base( ( int )statusCode, message, errorCode, errorType, xml, null )
		{
		}

		public FeedReportServiceException( string message, HttpStatusCode statusCode, Exception cause,
			string xml )
			: this( message, statusCode, null, null, null, xml, cause )
		{
		}

		public FeedReportServiceException( string message, HttpStatusCode statusCode, string errorCode,
			string errorType, string requestId, string xml, Exception cause )
			: base( ( int )statusCode, message, errorCode, errorType, xml, null, cause )
		{
		}

		public new ResponseHeaderMetadata ResponseHeaderMetadata
		{
			get
			{
				MwsResponseHeaderMetadata baseRHMD = base.ResponseHeaderMetadata;
				if( baseRHMD != null )
					return new ResponseHeaderMetadata( baseRHMD );
				else
					return null;
			}
		}
	}
}