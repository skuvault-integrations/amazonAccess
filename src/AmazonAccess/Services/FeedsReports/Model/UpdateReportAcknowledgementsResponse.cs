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
using System.Text;
using System.Xml.Serialization;
using AmazonAccess.Services.Common;

namespace AmazonAccess.Services.FeedsReports.Model
{
	[ XmlType( Namespace = "http://mws.amazonaws.com/doc/2009-01-01/" ) ]
	[ XmlRoot( Namespace = "http://mws.amazonaws.com/doc/2009-01-01/", IsNullable = false ) ]
	public class UpdateReportAcknowledgementsResponse: AbstractMwsObject, IMWSResponse
	{
		/// <summary>
		/// Gets and sets the UpdateReportAcknowledgementsResult property.
		/// </summary>
		[ XmlElement( ElementName = "UpdateReportAcknowledgementsResult" ) ]
		public UpdateReportAcknowledgementsResult UpdateReportAcknowledgementsResult{ get; set; }

		/// <summary>
		/// Sets the UpdateReportAcknowledgementsResult property
		/// </summary>
		/// <param name="updateReportAcknowledgementsResult">UpdateReportAcknowledgementsResult property</param>
		/// <returns>this instance</returns>
		public UpdateReportAcknowledgementsResponse WithUpdateReportAcknowledgementsResult( UpdateReportAcknowledgementsResult updateReportAcknowledgementsResult )
		{
			this.UpdateReportAcknowledgementsResult = updateReportAcknowledgementsResult;
			return this;
		}

		/// <summary>
		/// Checks if UpdateReportAcknowledgementsResult property is set
		/// </summary>
		/// <returns>true if UpdateReportAcknowledgementsResult property is set</returns>
		public Boolean IsSetUpdateReportAcknowledgementsResult()
		{
			return this.UpdateReportAcknowledgementsResult != null;
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
		public UpdateReportAcknowledgementsResponse WithResponseMetadata( ResponseMetadata responseMetadata )
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

		public override void ReadFragmentFrom( IMwsReader r )
		{
		}

		public override void WriteFragmentTo( IMwsWriter w )
		{
		}

		public override void WriteTo( IMwsWriter w )
		{
		}

		/// <summary>
		/// XML Representation for this object
		/// </summary>
		/// <returns>XML String</returns>
		public String ToXML()
		{
			StringBuilder xml = new StringBuilder();
			xml.Append( "<UpdateReportAcknowledgementsResponse xmlns=\"http://mws.amazonaws.com/doc/2009-01-01/\">" );
			if( this.IsSetUpdateReportAcknowledgementsResult() )
			{
				UpdateReportAcknowledgementsResult updateReportAcknowledgementsResult = this.UpdateReportAcknowledgementsResult;
				xml.Append( "<UpdateReportAcknowledgementsResult>" );
				xml.Append( updateReportAcknowledgementsResult.ToXMLFragment() );
				xml.Append( "</UpdateReportAcknowledgementsResult>" );
			}
			if( this.IsSetResponseMetadata() )
			{
				ResponseMetadata responseMetadata = this.ResponseMetadata;
				xml.Append( "<ResponseMetadata>" );
				xml.Append( responseMetadata.ToXMLFragment() );
				xml.Append( "</ResponseMetadata>" );
			}
			xml.Append( "</UpdateReportAcknowledgementsResponse>" );
			return xml.ToString();
		}

		/**
         * 
         * Escape XML special characters
         */

		private String EscapeXML( String str )
		{
			StringBuilder sb = new StringBuilder();
			foreach( Char c in str )
			{
				switch( c )
				{
					case '&':
						sb.Append( "&amp;" );
						break;
					case '<':
						sb.Append( "&lt;" );
						break;
					case '>':
						sb.Append( "&gt;" );
						break;
					case '\'':
						sb.Append( "&#039;" );
						break;
					case '"':
						sb.Append( "&quot;" );
						break;
					default:
						sb.Append( c );
						break;
				}
			}
			return sb.ToString();
		}

		public ResponseHeaderMetadata ResponseHeaderMetadata{ get; set; }
	}
}