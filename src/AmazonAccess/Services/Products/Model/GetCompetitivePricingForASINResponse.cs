/*******************************************************************************
 * Copyright 2009-2015 Amazon Services. All Rights Reserved.
 * Licensed under the Apache License, Version 2.0 (the "License"); 
 *
 * You may not use this file except in compliance with the License. 
 * You may obtain a copy of the License at: http://aws.amazon.com/apache2.0
 * This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
 * CONDITIONS OF ANY KIND, either express or implied. See the License for the 
 * specific language governing permissions and limitations under the License.
 *******************************************************************************
 * Get Competitive Pricing For ASIN Response
 * API Version: 2011-10-01
 * Library Version: 2015-09-01
 * Generated: Thu Sep 10 06:52:19 PDT 2015
 */

using System.Collections.Generic;
using System.Xml.Serialization;
using AmazonAccess.Services.Common;

namespace AmazonAccess.Services.Products.Model
{
	[ XmlType( Namespace = "http://mws.amazonservices.com/schema/Products/2011-10-01" ) ]
	[ XmlRoot( Namespace = "http://mws.amazonservices.com/schema/Products/2011-10-01", IsNullable = false ) ]
	public class GetCompetitivePricingForASINResponse: AbstractMwsObject, IMwsResponse
	{
		private List< GetCompetitivePricingForASINResult > _getCompetitivePricingForASINResult;

		/// <summary>
		/// Gets and sets the GetCompetitivePricingForASINResult property.
		/// </summary>
		[ XmlElement( ElementName = "GetCompetitivePricingForASINResult" ) ]
		public List< GetCompetitivePricingForASINResult > GetCompetitivePricingForASINResult
		{
			get
			{
				if( this._getCompetitivePricingForASINResult == null )
					this._getCompetitivePricingForASINResult = new List< GetCompetitivePricingForASINResult >();
				return this._getCompetitivePricingForASINResult;
			}
			set { this._getCompetitivePricingForASINResult = value; }
		}

		/// <summary>
		/// Sets the GetCompetitivePricingForASINResult property.
		/// </summary>
		/// <param name="getCompetitivePricingForASINResult">GetCompetitivePricingForASINResult property.</param>
		/// <returns>this instance.</returns>
		public GetCompetitivePricingForASINResponse WithGetCompetitivePricingForASINResult( GetCompetitivePricingForASINResult[] getCompetitivePricingForASINResult )
		{
			this._getCompetitivePricingForASINResult.AddRange( getCompetitivePricingForASINResult );
			return this;
		}

		/// <summary>
		/// Checks if GetCompetitivePricingForASINResult property is set.
		/// </summary>
		/// <returns>true if GetCompetitivePricingForASINResult property is set.</returns>
		public bool IsSetGetCompetitivePricingForASINResult()
		{
			return this.GetCompetitivePricingForASINResult.Count > 0;
		}

		/// <summary>
		/// Gets and sets the ResponseMetadata property.
		/// </summary>
		[ XmlElement( ElementName = "ResponseMetadata" ) ]
		public ResponseMetadata ResponseMetadata{ get; set; }

		/// <summary>
		/// Sets the ResponseMetadata property.
		/// </summary>
		/// <param name="responseMetadata">ResponseMetadata property.</param>
		/// <returns>this instance.</returns>
		public GetCompetitivePricingForASINResponse WithResponseMetadata( ResponseMetadata responseMetadata )
		{
			this.ResponseMetadata = responseMetadata;
			return this;
		}

		/// <summary>
		/// Checks if ResponseMetadata property is set.
		/// </summary>
		/// <returns>true if ResponseMetadata property is set.</returns>
		public bool IsSetResponseMetadata()
		{
			return this.ResponseMetadata != null;
		}

		/// <summary>
		/// Gets and sets the ResponseHeaderMetadata property.
		/// </summary>
		[ XmlElement( ElementName = "ResponseHeaderMetadata" ) ]
		public MwsResponseHeaderMetadata ResponseHeaderMetadata{ get; set; }

		/// <summary>
		/// Sets the ResponseHeaderMetadata property.
		/// </summary>
		/// <param name="responseHeaderMetadata">ResponseHeaderMetadata property.</param>
		/// <returns>this instance.</returns>
		public GetCompetitivePricingForASINResponse WithResponseHeaderMetadata( MwsResponseHeaderMetadata responseHeaderMetadata )
		{
			this.ResponseHeaderMetadata = responseHeaderMetadata;
			return this;
		}

		/// <summary>
		/// Checks if ResponseHeaderMetadata property is set.
		/// </summary>
		/// <returns>true if ResponseHeaderMetadata property is set.</returns>
		public bool IsSetResponseHeaderMetadata()
		{
			return this.ResponseHeaderMetadata != null;
		}

		public override void ReadFragmentFrom( IMwsReader reader )
		{
			this._getCompetitivePricingForASINResult = reader.ReadList< GetCompetitivePricingForASINResult >( "GetCompetitivePricingForASINResult" );
			this.ResponseMetadata = reader.Read< ResponseMetadata >( "ResponseMetadata" );
		}

		public override void WriteFragmentTo( IMwsWriter writer )
		{
			writer.WriteList( "GetCompetitivePricingForASINResult", this._getCompetitivePricingForASINResult );
			writer.Write( "ResponseMetadata", this.ResponseMetadata );
		}

		public override void WriteTo( IMwsWriter writer )
		{
			writer.Write( "http://mws.amazonservices.com/schema/Products/2011-10-01", "GetCompetitivePricingForASINResponse", this );
		}

		public GetCompetitivePricingForASINResponse(): base()
		{
		}
	}
}