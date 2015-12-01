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
	public class GetFeedSubmissionListResponse: AbstractMwsObject, IMWSResponse
	{
		/// <summary>
		/// Gets and sets the GetFeedSubmissionListResult property.
		/// </summary>
		[ XmlElement( ElementName = "GetFeedSubmissionListResult" ) ]
		public GetFeedSubmissionListResult GetFeedSubmissionListResult{ get; set; }

		/// <summary>
		/// Sets the GetFeedSubmissionListResult property
		/// </summary>
		/// <param name="getFeedSubmissionListResult">GetFeedSubmissionListResult property</param>
		/// <returns>this instance</returns>
		public GetFeedSubmissionListResponse WithGetFeedSubmissionListResult( GetFeedSubmissionListResult getFeedSubmissionListResult )
		{
			this.GetFeedSubmissionListResult = getFeedSubmissionListResult;
			return this;
		}

		/// <summary>
		/// Checks if GetFeedSubmissionListResult property is set
		/// </summary>
		/// <returns>true if GetFeedSubmissionListResult property is set</returns>
		public Boolean IsSetGetFeedSubmissionListResult()
		{
			return this.GetFeedSubmissionListResult != null;
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
		public GetFeedSubmissionListResponse WithResponseMetadata( ResponseMetadata responseMetadata )
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
			this.GetFeedSubmissionListResult = reader.Read< GetFeedSubmissionListResult >( "GetFeedSubmissionListResult" );
			this.ResponseMetadata = reader.Read< ResponseMetadata >( "ResponseMetadata" );
		}

		public override void WriteFragmentTo( IMwsWriter writer )
		{
			writer.Write( "GetFeedSubmissionListResult", this.GetFeedSubmissionListResult );
			writer.Write( "ResponseMetadata", this.ResponseMetadata );
		}

		public override void WriteTo( IMwsWriter writer )
		{
			writer.Write( "http://mws.amazonaws.com/doc/2009-01-01", "GetFeedSubmissionListResponse", this );
		}

		public ResponseHeaderMetadata ResponseHeaderMetadata{ get; set; }
	}
}