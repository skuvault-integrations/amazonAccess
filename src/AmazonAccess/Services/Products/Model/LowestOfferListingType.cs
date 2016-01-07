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
 * Lowest Offer Listing Type
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
	public class LowestOfferListingType: AbstractMwsObject
	{
		private decimal? _numberOfOfferListingsConsidered;

		/// <summary>
		/// Gets and sets the Qualifiers property.
		/// </summary>
		[ XmlElement( ElementName = "Qualifiers" ) ]
		public QualifiersType Qualifiers{ get; set; }

		/// <summary>
		/// Sets the Qualifiers property.
		/// </summary>
		/// <param name="qualifiers">Qualifiers property.</param>
		/// <returns>this instance.</returns>
		public LowestOfferListingType WithQualifiers( QualifiersType qualifiers )
		{
			this.Qualifiers = qualifiers;
			return this;
		}

		/// <summary>
		/// Checks if Qualifiers property is set.
		/// </summary>
		/// <returns>true if Qualifiers property is set.</returns>
		public bool IsSetQualifiers()
		{
			return this.Qualifiers != null;
		}

		/// <summary>
		/// Gets and sets the NumberOfOfferListingsConsidered property.
		/// </summary>
		[ XmlElement( ElementName = "NumberOfOfferListingsConsidered" ) ]
		public decimal NumberOfOfferListingsConsidered
		{
			get { return this._numberOfOfferListingsConsidered.GetValueOrDefault(); }
			set { this._numberOfOfferListingsConsidered = value; }
		}

		/// <summary>
		/// Sets the NumberOfOfferListingsConsidered property.
		/// </summary>
		/// <param name="numberOfOfferListingsConsidered">NumberOfOfferListingsConsidered property.</param>
		/// <returns>this instance.</returns>
		public LowestOfferListingType WithNumberOfOfferListingsConsidered( decimal numberOfOfferListingsConsidered )
		{
			this._numberOfOfferListingsConsidered = numberOfOfferListingsConsidered;
			return this;
		}

		/// <summary>
		/// Checks if NumberOfOfferListingsConsidered property is set.
		/// </summary>
		/// <returns>true if NumberOfOfferListingsConsidered property is set.</returns>
		public bool IsSetNumberOfOfferListingsConsidered()
		{
			return this._numberOfOfferListingsConsidered != null;
		}

		/// <summary>
		/// Gets and sets the SellerFeedbackCount property.
		/// </summary>
		[ XmlElement( ElementName = "SellerFeedbackCount" ) ]
		public decimal SellerFeedbackCount{ get; set; }

		/// <summary>
		/// Sets the SellerFeedbackCount property.
		/// </summary>
		/// <param name="sellerFeedbackCount">SellerFeedbackCount property.</param>
		/// <returns>this instance.</returns>
		public LowestOfferListingType WithSellerFeedbackCount( decimal sellerFeedbackCount )
		{
			this.SellerFeedbackCount = sellerFeedbackCount;
			return this;
		}

		/// <summary>
		/// Checks if SellerFeedbackCount property is set.
		/// </summary>
		/// <returns>true if SellerFeedbackCount property is set.</returns>
		public bool IsSetSellerFeedbackCount()
		{
			return this.SellerFeedbackCount != null;
		}

		/// <summary>
		/// Gets and sets the Price property.
		/// </summary>
		[ XmlElement( ElementName = "Price" ) ]
		public PriceType Price{ get; set; }

		/// <summary>
		/// Sets the Price property.
		/// </summary>
		/// <param name="price">Price property.</param>
		/// <returns>this instance.</returns>
		public LowestOfferListingType WithPrice( PriceType price )
		{
			this.Price = price;
			return this;
		}

		/// <summary>
		/// Checks if Price property is set.
		/// </summary>
		/// <returns>true if Price property is set.</returns>
		public bool IsSetPrice()
		{
			return this.Price != null;
		}

		/// <summary>
		/// Gets and sets the MultipleOffersAtLowestPrice property.
		/// </summary>
		[ XmlElement( ElementName = "MultipleOffersAtLowestPrice" ) ]
		public string MultipleOffersAtLowestPrice{ get; set; }

		/// <summary>
		/// Sets the MultipleOffersAtLowestPrice property.
		/// </summary>
		/// <param name="multipleOffersAtLowestPrice">MultipleOffersAtLowestPrice property.</param>
		/// <returns>this instance.</returns>
		public LowestOfferListingType WithMultipleOffersAtLowestPrice( string multipleOffersAtLowestPrice )
		{
			this.MultipleOffersAtLowestPrice = multipleOffersAtLowestPrice;
			return this;
		}

		/// <summary>
		/// Checks if MultipleOffersAtLowestPrice property is set.
		/// </summary>
		/// <returns>true if MultipleOffersAtLowestPrice property is set.</returns>
		public bool IsSetMultipleOffersAtLowestPrice()
		{
			return this.MultipleOffersAtLowestPrice != null;
		}

		public override void ReadFragmentFrom( IMwsReader reader )
		{
			this.Qualifiers = reader.Read< QualifiersType >( "Qualifiers" );
			this._numberOfOfferListingsConsidered = reader.Read< decimal? >( "NumberOfOfferListingsConsidered" );
			this.SellerFeedbackCount = reader.Read< decimal >( "SellerFeedbackCount" );
			this.Price = reader.Read< PriceType >( "Price" );
			this.MultipleOffersAtLowestPrice = reader.Read< string >( "MultipleOffersAtLowestPrice" );
		}

		public override void WriteFragmentTo( IMwsWriter writer )
		{
			writer.Write( "Qualifiers", this.Qualifiers );
			writer.Write( "NumberOfOfferListingsConsidered", this._numberOfOfferListingsConsidered );
			writer.Write( "SellerFeedbackCount", this.SellerFeedbackCount );
			writer.Write( "Price", this.Price );
			writer.Write( "MultipleOffersAtLowestPrice", this.MultipleOffersAtLowestPrice );
		}

		public override void WriteTo( IMwsWriter writer )
		{
			writer.Write( "http://mws.amazonservices.com/schema/Products/2011-10-01", "LowestOfferListingType", this );
		}

		public LowestOfferListingType(): base()
		{
		}
	}
}