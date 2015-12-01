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
 */

using System;
using AmazonAccess.Services.Common;

namespace AmazonAccess.Services.FeedsReports.Model
{
	public class RequestReportResponse: AbstractMwsObject, IMWSResponse
	{
		/// <summary>
		/// Gets and sets the RequestReportResult property.
		/// </summary>
		public RequestReportResult RequestReportResult{ get; set; }

		/// <summary>
		/// Sets the RequestReportResult property
		/// </summary>
		/// <param name="requestReportResult">RequestReportResult property</param>
		/// <returns>this instance</returns>
		public RequestReportResponse WithRequestReportResult( RequestReportResult requestReportResult )
		{
			this.RequestReportResult = requestReportResult;
			return this;
		}

		/// <summary>
		/// Checks if RequestReportResult property is set
		/// </summary>
		/// <returns>true if RequestReportResult property is set</returns>
		public Boolean IsSetRequestReportResult()
		{
			return this.RequestReportResult != null;
		}

		/// <summary>
		/// Gets and sets the ResponseMetadata property.
		/// </summary>
		public ResponseMetadata ResponseMetadata{ get; set; }

		/// <summary>
		/// Sets the ResponseMetadata property
		/// </summary>
		/// <param name="responseMetadata">ResponseMetadata property</param>
		/// <returns>this instance</returns>
		public RequestReportResponse WithResponseMetadata( ResponseMetadata responseMetadata )
		{
			this.ResponseMetadata = responseMetadata;
			return this;
		}

		/// <summary>
		/// Checks if ResponseMetadata property is set
		/// </summary>
		/// <returns>true if ResponseMetadata property is set</returns>
		public Boolean IsSetResponseMetadata()
		{
			return this.ResponseMetadata != null;
		}

		public override void ReadFragmentFrom( IMwsReader reader )
		{
			this.RequestReportResult = reader.Read< RequestReportResult >( "RequestReportResult" );
			this.ResponseMetadata = reader.Read< ResponseMetadata >( "ResponseMetadata" );
		}

		public override void WriteFragmentTo( IMwsWriter writer )
		{
			writer.Write( "RequestReportResult", this.RequestReportResult );
			writer.Write( "ResponseMetadata", this.ResponseMetadata );
		}

		public override void WriteTo( IMwsWriter writer )
		{
			writer.Write( "http://mws.amazonaws.com/doc/2009-01-01", "RequestReportResponse", this );
		}

		public ResponseHeaderMetadata ResponseHeaderMetadata{ get; set; }
	}
}