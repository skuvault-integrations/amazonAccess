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
using System.Xml.Serialization;
using AmazonAccess.Services.Common;

namespace AmazonAccess.Services.FeedsReports.Model
{
	public class GetFeedSubmissionResultResponse: AbstractMwsObject, IMwsResponse
	{
		/// <summary>
		/// Gets and sets the GetFeedSubmissionResultResult property.
		/// </summary>
		[ XmlElement( ElementName = "GetFeedSubmissionResultResult" ) ]
		public GetFeedSubmissionResultResult GetFeedSubmissionResultResult{ get; set; }

		/// <summary>
		/// Sets the GetFeedSubmissionResultResult property
		/// </summary>
		/// <param name="getFeedSubmissionResultResult">GetFeedSubmissionResultResult property</param>
		/// <returns>this instance</returns>
		public GetFeedSubmissionResultResponse WithGetFeedSubmissionResultResult( GetFeedSubmissionResultResult getFeedSubmissionResultResult )
		{
			this.GetFeedSubmissionResultResult = getFeedSubmissionResultResult;
			return this;
		}

		/// <summary>
		/// Checks if GetFeedSubmissionResultResult property is set
		/// </summary>
		/// <returns>true if GetFeedSubmissionResultResult property is set</returns>
		public Boolean IsSetGetFeedSubmissionResultResult()
		{
			return this.GetFeedSubmissionResultResult != null;
		}

		/// <summary>
		/// Gets and sets the ResponseMetadata property.
		/// </summary>
		[ XmlElement( ElementName = "ResponseMetadata" ) ]
		public ResponseMetadata ResponseMetadata{ get; set; }

		/// <summary>
		/// Sets the ResponseMetadata property
		/// </summary>
		/// <param name="responseMetadata">ResponseMetadata property</param>
		/// <returns>this instance</returns>
		public GetFeedSubmissionResultResponse WithResponseMetadata( ResponseMetadata responseMetadata )
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
				this.GetFeedSubmissionResultResult = new GetFeedSubmissionResultResult { ContentMD5 = this.ResponseHeaderMetadata.ContentMD5, Result = reader.ReadAll() };
				this.ResponseMetadata = new ResponseMetadata { RequestId = this.ResponseHeaderMetadata.RequestId };
			}
		}

		public override void WriteFragmentTo( IMwsWriter writer )
		{
			writer.Write( "GetFeedSubmissionResultResult", this.GetFeedSubmissionResultResult );
			writer.Write( "ResponseMetadata", this.ResponseMetadata );
		}

		public override void WriteTo( IMwsWriter writer )
		{
			writer.Write( "http://mws.amazonaws.com/doc/2009-01-01", "GetFeedSubmissionResultResponse", this );
		}

		public MwsResponseHeaderMetadata ResponseHeaderMetadata{ get; set; }
	}
}