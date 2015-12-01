/******************************************************************************* 
 *  Copyright 2008-2012 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
 * 
 */

using System;
using AmazonAccess.Services.Common;

namespace AmazonAccess.Services.FeedsReports.Model
{
	public class ResponseHeaderMetadata: MwsResponseHeaderMetadata
	{
		public ResponseHeaderMetadata( string requestId, string responseContext, string timestamp, double? quotaMax, double? quotaRemaining, DateTime? quotaResetsAt, string contentMD5 )
			: base( requestId, responseContext, timestamp, quotaMax, quotaRemaining, quotaResetsAt, contentMD5 )
		{
		}

		public ResponseHeaderMetadata()
			: base( null, "", null, null, null, null, null )
		{
		}

		public ResponseHeaderMetadata( MwsResponseHeaderMetadata rhmd )
			: base( rhmd )
		{
		}
	}
}