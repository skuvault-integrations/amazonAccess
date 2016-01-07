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
 * Offer Listing Count Type
 * API Version: 2011-10-01
 * Library Version: 2015-09-01
 * Generated: Thu Sep 10 06:52:19 PDT 2015
 */

using System.Xml.Serialization;
using AmazonAccess.Services.Common;

namespace AmazonAccess.Services.Products.Model
{
	[ XmlType( Namespace = "http://mws.amazonservices.com/schema/Products/2011-10-01" ) ]
	[ XmlRoot( Namespace = "http://mws.amazonservices.com/schema/Products/2011-10-01", IsNullable = false ) ]
	public class OfferListingCountType: AbstractMwsObject
	{
		/// <summary>
		/// Gets and sets the Value property.
		/// </summary>
		[ XmlElement( ElementName = "Value" ) ]
		public decimal Value{ get; set; }

		/// <summary>
		/// Sets the Value property.
		/// </summary>
		/// <param name="value">Value property.</param>
		/// <returns>this instance.</returns>
		public OfferListingCountType WithValue( decimal value )
		{
			this.Value = value;
			return this;
		}

		/// <summary>
		/// Checks if Value property is set.
		/// </summary>
		/// <returns>true if Value property is set.</returns>
		public bool IsSetValue()
		{
			return this.Value != null;
		}

		/// <summary>
		/// Gets and sets the condition property.
		/// </summary>
		[ XmlAttribute( AttributeName = "condition" ) ]
		public string condition{ get; set; }

		/// <summary>
		/// Sets the condition property.
		/// </summary>
		/// <param name="condition">condition property.</param>
		/// <returns>this instance.</returns>
		public OfferListingCountType Withcondition( string condition )
		{
			this.condition = condition;
			return this;
		}

		/// <summary>
		/// Checks if condition property is set.
		/// </summary>
		/// <returns>true if condition property is set.</returns>
		public bool IsSetcondition()
		{
			return this.condition != null;
		}

		public override void ReadFragmentFrom( IMwsReader reader )
		{
			this.condition = reader.ReadAttribute< string >( "condition" );
			this.Value = reader.ReadValue< decimal >();
		}

		public override void WriteFragmentTo( IMwsWriter writer )
		{
			writer.WriteAttribute( "condition", this.condition );
			writer.WriteValue( this.Value );
		}

		public override void WriteTo( IMwsWriter writer )
		{
			writer.Write( "http://mws.amazonservices.com/schema/Products/2011-10-01", "OfferListingCountType", this );
		}

		public OfferListingCountType(): base()
		{
		}
	}
}