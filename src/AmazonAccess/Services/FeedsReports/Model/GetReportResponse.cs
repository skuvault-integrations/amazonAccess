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
	public class GetReportResponse: AbstractMwsObject, IMWSResponse
	{
		/// <summary>
		/// Gets and sets the GetReportResult property.
		/// </summary>
		public GetReportResult GetReportResult{ get; set; }

		/// <summary>
		/// Sets the GetReportResult property
		/// </summary>
		/// <param name="getReportResult">GetReportResult property</param>
		/// <returns>this instance</returns>
		public GetReportResponse WithGetReportResult( GetReportResult getReportResult )
		{
			this.GetReportResult = getReportResult;
			return this;
		}

		/// <summary>
		/// Checks if GetReportResult property is set
		/// </summary>
		/// <returns>true if GetReportResult property is set</returns>
		public Boolean IsSetGetReportResult()
		{
			return this.GetReportResult != null;
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
		public GetReportResponse WithResponseMetadata( ResponseMetadata responseMetadata )
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
			if( this.ResponseHeaderMetadata != null )
			{
				this.GetReportResult = new GetReportResult { ContentMD5 = this.ResponseHeaderMetadata.ContentMD5, Result = reader.ReadAll() };
				this.ResponseMetadata = new ResponseMetadata { RequestId = this.ResponseHeaderMetadata.RequestId };
			}
		}

		public override void WriteFragmentTo( IMwsWriter writer )
		{
			writer.Write( "GetReportResult", this.GetReportResult );
			writer.Write( "ResponseMetadata", this.ResponseMetadata );
		}

		public override void WriteTo( IMwsWriter writer )
		{
			writer.Write( "http://mws.amazonaws.com/doc/2009-01-01/", "GetReportResponse", this );
		}

		public ResponseHeaderMetadata ResponseHeaderMetadata{ get; set; }
	}
}