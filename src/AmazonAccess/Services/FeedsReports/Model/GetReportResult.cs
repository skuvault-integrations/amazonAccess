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
using AmazonAccess.Services.Common;

namespace AmazonAccess.Services.FeedsReports.Model
{
	public class GetReportResult: AbstractMwsObject
	{
		public String ContentMD5{ get; set; }

		public Boolean IsSetContentMD5()
		{
			return this.ContentMD5 != null;
		}

		//Non Amazon field
		public String Result{ get; set; }

		public Boolean IsSetResult()
		{
			return this.Result != null;
		}

		public override void ReadFragmentFrom( IMwsReader reader )
		{
			this.ContentMD5 = reader.Read< String >( "ContentMD5" );
		}

		public override void WriteFragmentTo( IMwsWriter writer )
		{
			writer.Write( "ContentMD5", this.ContentMD5 );
		}

		public override void WriteTo( IMwsWriter writer )
		{
			writer.Write( "http://mws.amazonaws.com/doc/2009-01-01", "GetReportResult", this );
		}
	}
}