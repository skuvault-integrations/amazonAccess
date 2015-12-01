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
	public class RequestReportResult: AbstractMwsObject
	{
		/// <summary>
		/// Gets and sets the ReportRequestInfo property.
		/// </summary>
		public ReportRequestInfo ReportRequestInfo{ get; set; }

		/// <summary>
		/// Sets the ReportRequestInfo property
		/// </summary>
		/// <param name="reportRequestInfo">ReportRequestInfo property</param>
		/// <returns>this instance</returns>
		public RequestReportResult WithReportRequestInfo( ReportRequestInfo reportRequestInfo )
		{
			this.ReportRequestInfo = reportRequestInfo;
			return this;
		}

		/// <summary>
		/// Checks if ReportRequestInfo property is set
		/// </summary>
		/// <returns>true if ReportRequestInfo property is set</returns>
		public Boolean IsSetReportRequestInfo()
		{
			return this.ReportRequestInfo != null;
		}

		public override void ReadFragmentFrom( IMwsReader reader )
		{
			this.ReportRequestInfo = reader.Read< ReportRequestInfo >( "ReportRequestInfo" );
		}

		public override void WriteFragmentTo( IMwsWriter writer )
		{
			writer.Write( "ReportRequestInfo", this.ReportRequestInfo );
		}

		public override void WriteTo( IMwsWriter writer )
		{
			writer.Write( "http://mws.amazonaws.com/doc/2009-01-01", "RequestReportResult", this );
		}
	}
}