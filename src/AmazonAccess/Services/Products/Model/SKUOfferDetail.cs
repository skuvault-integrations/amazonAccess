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
 * SKU Offer Detail
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
	public class SKUOfferDetail: AbstractMwsObject
	{
		private bool? _isBuyBoxWinner;
		private bool? _isFeaturedMerchant;

		/// <summary>
		/// Gets and sets the MyOffer property.
		/// </summary>
		[ XmlElement( ElementName = "MyOffer" ) ]
		public bool MyOffer{ get; set; }

		/// <summary>
		/// Sets the MyOffer property.
		/// </summary>
		/// <param name="myOffer">MyOffer property.</param>
		/// <returns>this instance.</returns>
		public SKUOfferDetail WithMyOffer( bool myOffer )
		{
			this.MyOffer = myOffer;
			return this;
		}

		/// <summary>
		/// Checks if MyOffer property is set.
		/// </summary>
		/// <returns>true if MyOffer property is set.</returns>
		public bool IsSetMyOffer()
		{
			return this.MyOffer != null;
		}

		/// <summary>
		/// Gets and sets the SubCondition property.
		/// </summary>
		[ XmlElement( ElementName = "SubCondition" ) ]
		public string SubCondition{ get; set; }

		/// <summary>
		/// Sets the SubCondition property.
		/// </summary>
		/// <param name="subCondition">SubCondition property.</param>
		/// <returns>this instance.</returns>
		public SKUOfferDetail WithSubCondition( string subCondition )
		{
			this.SubCondition = subCondition;
			return this;
		}

		/// <summary>
		/// Checks if SubCondition property is set.
		/// </summary>
		/// <returns>true if SubCondition property is set.</returns>
		public bool IsSetSubCondition()
		{
			return this.SubCondition != null;
		}

		/// <summary>
		/// Gets and sets the SellerFeedbackRating property.
		/// </summary>
		[ XmlElement( ElementName = "SellerFeedbackRating" ) ]
		public SellerFeedbackType SellerFeedbackRating{ get; set; }

		/// <summary>
		/// Sets the SellerFeedbackRating property.
		/// </summary>
		/// <param name="sellerFeedbackRating">SellerFeedbackRating property.</param>
		/// <returns>this instance.</returns>
		public SKUOfferDetail WithSellerFeedbackRating( SellerFeedbackType sellerFeedbackRating )
		{
			this.SellerFeedbackRating = sellerFeedbackRating;
			return this;
		}

		/// <summary>
		/// Checks if SellerFeedbackRating property is set.
		/// </summary>
		/// <returns>true if SellerFeedbackRating property is set.</returns>
		public bool IsSetSellerFeedbackRating()
		{
			return this.SellerFeedbackRating != null;
		}

		/// <summary>
		/// Gets and sets the ShippingTime property.
		/// </summary>
		[ XmlElement( ElementName = "ShippingTime" ) ]
		public DetailedShippingTimeType ShippingTime{ get; set; }

		/// <summary>
		/// Sets the ShippingTime property.
		/// </summary>
		/// <param name="shippingTime">ShippingTime property.</param>
		/// <returns>this instance.</returns>
		public SKUOfferDetail WithShippingTime( DetailedShippingTimeType shippingTime )
		{
			this.ShippingTime = shippingTime;
			return this;
		}

		/// <summary>
		/// Checks if ShippingTime property is set.
		/// </summary>
		/// <returns>true if ShippingTime property is set.</returns>
		public bool IsSetShippingTime()
		{
			return this.ShippingTime != null;
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
		public SKUOfferDetail WithListingPrice( MoneyType listingPrice )
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
		/// Gets and sets the Points property.
		/// </summary>
		[ XmlElement( ElementName = "Points" ) ]
		public Points Points{ get; set; }

		/// <summary>
		/// Sets the Points property.
		/// </summary>
		/// <param name="points">Points property.</param>
		/// <returns>this instance.</returns>
		public SKUOfferDetail WithPoints( Points points )
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
		public SKUOfferDetail WithShipping( MoneyType shipping )
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
		/// Gets and sets the ShipsFrom property.
		/// </summary>
		[ XmlElement( ElementName = "ShipsFrom" ) ]
		public ShipsFromType ShipsFrom{ get; set; }

		/// <summary>
		/// Sets the ShipsFrom property.
		/// </summary>
		/// <param name="shipsFrom">ShipsFrom property.</param>
		/// <returns>this instance.</returns>
		public SKUOfferDetail WithShipsFrom( ShipsFromType shipsFrom )
		{
			this.ShipsFrom = shipsFrom;
			return this;
		}

		/// <summary>
		/// Checks if ShipsFrom property is set.
		/// </summary>
		/// <returns>true if ShipsFrom property is set.</returns>
		public bool IsSetShipsFrom()
		{
			return this.ShipsFrom != null;
		}

		/// <summary>
		/// Gets and sets the IsFulfilledByAmazon property.
		/// </summary>
		[ XmlElement( ElementName = "IsFulfilledByAmazon" ) ]
		public bool IsFulfilledByAmazon{ get; set; }

		/// <summary>
		/// Sets the IsFulfilledByAmazon property.
		/// </summary>
		/// <param name="isFulfilledByAmazon">IsFulfilledByAmazon property.</param>
		/// <returns>this instance.</returns>
		public SKUOfferDetail WithIsFulfilledByAmazon( bool isFulfilledByAmazon )
		{
			this.IsFulfilledByAmazon = isFulfilledByAmazon;
			return this;
		}

		/// <summary>
		/// Checks if IsFulfilledByAmazon property is set.
		/// </summary>
		/// <returns>true if IsFulfilledByAmazon property is set.</returns>
		public bool IsSetIsFulfilledByAmazon()
		{
			return this.IsFulfilledByAmazon != null;
		}

		/// <summary>
		/// Gets and sets the IsBuyBoxWinner property.
		/// </summary>
		[ XmlElement( ElementName = "IsBuyBoxWinner" ) ]
		public bool IsBuyBoxWinner
		{
			get { return this._isBuyBoxWinner.GetValueOrDefault(); }
			set { this._isBuyBoxWinner = value; }
		}

		/// <summary>
		/// Sets the IsBuyBoxWinner property.
		/// </summary>
		/// <param name="isBuyBoxWinner">IsBuyBoxWinner property.</param>
		/// <returns>this instance.</returns>
		public SKUOfferDetail WithIsBuyBoxWinner( bool isBuyBoxWinner )
		{
			this._isBuyBoxWinner = isBuyBoxWinner;
			return this;
		}

		/// <summary>
		/// Checks if IsBuyBoxWinner property is set.
		/// </summary>
		/// <returns>true if IsBuyBoxWinner property is set.</returns>
		public bool IsSetIsBuyBoxWinner()
		{
			return this._isBuyBoxWinner != null;
		}

		/// <summary>
		/// Gets and sets the IsFeaturedMerchant property.
		/// </summary>
		[ XmlElement( ElementName = "IsFeaturedMerchant" ) ]
		public bool IsFeaturedMerchant
		{
			get { return this._isFeaturedMerchant.GetValueOrDefault(); }
			set { this._isFeaturedMerchant = value; }
		}

		/// <summary>
		/// Sets the IsFeaturedMerchant property.
		/// </summary>
		/// <param name="isFeaturedMerchant">IsFeaturedMerchant property.</param>
		/// <returns>this instance.</returns>
		public SKUOfferDetail WithIsFeaturedMerchant( bool isFeaturedMerchant )
		{
			this._isFeaturedMerchant = isFeaturedMerchant;
			return this;
		}

		/// <summary>
		/// Checks if IsFeaturedMerchant property is set.
		/// </summary>
		/// <returns>true if IsFeaturedMerchant property is set.</returns>
		public bool IsSetIsFeaturedMerchant()
		{
			return this._isFeaturedMerchant != null;
		}

		public override void ReadFragmentFrom( IMwsReader reader )
		{
			this.MyOffer = reader.Read< bool >( "MyOffer" );
			this.SubCondition = reader.Read< string >( "SubCondition" );
			this.SellerFeedbackRating = reader.Read< SellerFeedbackType >( "SellerFeedbackRating" );
			this.ShippingTime = reader.Read< DetailedShippingTimeType >( "ShippingTime" );
			this.ListingPrice = reader.Read< MoneyType >( "ListingPrice" );
			this.Points = reader.Read< Points >( "Points" );
			this.Shipping = reader.Read< MoneyType >( "Shipping" );
			this.ShipsFrom = reader.Read< ShipsFromType >( "ShipsFrom" );
			this.IsFulfilledByAmazon = reader.Read< bool >( "IsFulfilledByAmazon" );
			this._isBuyBoxWinner = reader.Read< bool? >( "IsBuyBoxWinner" );
			this._isFeaturedMerchant = reader.Read< bool? >( "IsFeaturedMerchant" );
		}

		public override void WriteFragmentTo( IMwsWriter writer )
		{
			writer.Write( "MyOffer", this.MyOffer );
			writer.Write( "SubCondition", this.SubCondition );
			writer.Write( "SellerFeedbackRating", this.SellerFeedbackRating );
			writer.Write( "ShippingTime", this.ShippingTime );
			writer.Write( "ListingPrice", this.ListingPrice );
			writer.Write( "Points", this.Points );
			writer.Write( "Shipping", this.Shipping );
			writer.Write( "ShipsFrom", this.ShipsFrom );
			writer.Write( "IsFulfilledByAmazon", this.IsFulfilledByAmazon );
			writer.Write( "IsBuyBoxWinner", this._isBuyBoxWinner );
			writer.Write( "IsFeaturedMerchant", this._isFeaturedMerchant );
		}

		public override void WriteTo( IMwsWriter writer )
		{
			writer.Write( "http://mws.amazonservices.com/schema/Products/2011-10-01", "SKUOfferDetail", this );
		}

		public SKUOfferDetail(): base()
		{
		}
	}
}