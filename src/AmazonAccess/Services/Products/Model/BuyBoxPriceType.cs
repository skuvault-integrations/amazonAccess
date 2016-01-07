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
 * Buy Box Price Type
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
	public class BuyBoxPriceType: AbstractMwsObject
	{
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
		public BuyBoxPriceType Withcondition( string condition )
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

		/// <summary>
		/// Gets and sets the LandedPrice property.
		/// </summary>
		[ XmlElement( ElementName = "LandedPrice" ) ]
		public MoneyType LandedPrice{ get; set; }

		/// <summary>
		/// Sets the LandedPrice property.
		/// </summary>
		/// <param name="landedPrice">LandedPrice property.</param>
		/// <returns>this instance.</returns>
		public BuyBoxPriceType WithLandedPrice( MoneyType landedPrice )
		{
			this.LandedPrice = landedPrice;
			return this;
		}

		/// <summary>
		/// Checks if LandedPrice property is set.
		/// </summary>
		/// <returns>true if LandedPrice property is set.</returns>
		public bool IsSetLandedPrice()
		{
			return this.LandedPrice != null;
		}

		/// <summary>
		/// Gets and sets the ListingPrice property.
		/// </summary>
		[ XmlElement( ElementName = "ListingPrice" ) ]
		public MoneyType ListingPrice{ get; set; }

		/// <summary>
		/// Sets the ListingPrice property.
		/// </summary>
		/// <param name="listingPrice">ListingPrice property.</param>
		/// <returns>this instance.</returns>
		public BuyBoxPriceType WithListingPrice( MoneyType listingPrice )
		{
			this.ListingPrice = listingPrice;
			return this;
		}

		/// <summary>
		/// Checks if ListingPrice property is set.
		/// </summary>
		/// <returns>true if ListingPrice property is set.</returns>
		public bool IsSetListingPrice()
		{
			return this.ListingPrice != null;
		}

		/// <summary>
		/// Gets and sets the Shipping property.
		/// </summary>
		[ XmlElement( ElementName = "Shipping" ) ]
		public MoneyType Shipping{ get; set; }

		/// <summary>
		/// Sets the Shipping property.
		/// </summary>
		/// <param name="shipping">Shipping property.</param>
		/// <returns>this instance.</returns>
		public BuyBoxPriceType WithShipping( MoneyType shipping )
		{
			this.Shipping = shipping;
			return this;
		}

		/// <summary>
		/// Checks if Shipping property is set.
		/// </summary>
		/// <returns>true if Shipping property is set.</returns>
		public bool IsSetShipping()
		{
			return this.Shipping != null;
		}

		/// <summary>
		/// Gets and sets the Points property.
		/// </summary>
		[ XmlElement( ElementName = "Points" ) ]
		public Points Points{ get; set; }

		/// <summary>
		/// Sets the Points property.
		/// </summary>
		/// <param name="points">Points property.</param>
		/// <returns>this instance.</returns>
		public BuyBoxPriceType WithPoints( Points points )
		{
			this.Points = points;
			return this;
		}

		/// <summary>
		/// Checks if Points property is set.
		/// </summary>
		/// <returns>true if Points property is set.</returns>
		public bool IsSetPoints()
		{
			return this.Points != null;
		}

		public override void ReadFragmentFrom( IMwsReader reader )
		{
			this.condition = reader.ReadAttribute< string >( "condition" );
			this.LandedPrice = reader.Read< MoneyType >( "LandedPrice" );
			this.ListingPrice = reader.Read< MoneyType >( "ListingPrice" );
			this.Shipping = reader.Read< MoneyType >( "Shipping" );
			this.Points = reader.Read< Points >( "Points" );
		}

		public override void WriteFragmentTo( IMwsWriter writer )
		{
			writer.WriteAttribute( "condition", this.condition );
			writer.Write( "LandedPrice", this.LandedPrice );
			writer.Write( "ListingPrice", this.ListingPrice );
			writer.Write( "Shipping", this.Shipping );
			writer.Write( "Points", this.Points );
		}

		public override void WriteTo( IMwsWriter writer )
		{
			writer.Write( "http://mws.amazonservices.com/schema/Products/2011-10-01", "BuyBoxPriceType", this );
		}

		public BuyBoxPriceType(): base()
		{
		}
	}
}