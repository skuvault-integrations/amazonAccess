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
 * Summary
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
	public class Summary: AbstractMwsObject
	{
		/// <summary>
		/// Gets and sets the TotalOfferCount property.
		/// </summary>
		[ XmlElement( ElementName = "TotalOfferCount" ) ]
		public decimal TotalOfferCount{ get; set; }

		/// <summary>
		/// Sets the TotalOfferCount property.
		/// </summary>
		/// <param name="totalOfferCount">TotalOfferCount property.</param>
		/// <returns>this instance.</returns>
		public Summary WithTotalOfferCount( decimal totalOfferCount )
		{
			this.TotalOfferCount = totalOfferCount;
			return this;
		}

		/// <summary>
		/// Checks if TotalOfferCount property is set.
		/// </summary>
		/// <returns>true if TotalOfferCount property is set.</returns>
		public bool IsSetTotalOfferCount()
		{
			return this.TotalOfferCount != null;
		}

		/// <summary>
		/// Gets and sets the NumberOfOffers property.
		/// </summary>
		[ XmlElement( ElementName = "NumberOfOffers" ) ]
		public NumberOfOffers NumberOfOffers{ get; set; }

		/// <summary>
		/// Sets the NumberOfOffers property.
		/// </summary>
		/// <param name="numberOfOffers">NumberOfOffers property.</param>
		/// <returns>this instance.</returns>
		public Summary WithNumberOfOffers( NumberOfOffers numberOfOffers )
		{
			this.NumberOfOffers = numberOfOffers;
			return this;
		}

		/// <summary>
		/// Checks if NumberOfOffers property is set.
		/// </summary>
		/// <returns>true if NumberOfOffers property is set.</returns>
		public bool IsSetNumberOfOffers()
		{
			return this.NumberOfOffers != null;
		}

		/// <summary>
		/// Gets and sets the LowestPrices property.
		/// </summary>
		[ XmlElement( ElementName = "LowestPrices" ) ]
		public LowestPrices LowestPrices{ get; set; }

		/// <summary>
		/// Sets the LowestPrices property.
		/// </summary>
		/// <param name="lowestPrices">LowestPrices property.</param>
		/// <returns>this instance.</returns>
		public Summary WithLowestPrices( LowestPrices lowestPrices )
		{
			this.LowestPrices = lowestPrices;
			return this;
		}

		/// <summary>
		/// Checks if LowestPrices property is set.
		/// </summary>
		/// <returns>true if LowestPrices property is set.</returns>
		public bool IsSetLowestPrices()
		{
			return this.LowestPrices != null;
		}

		/// <summary>
		/// Gets and sets the BuyBoxPrices property.
		/// </summary>
		[ XmlElement( ElementName = "BuyBoxPrices" ) ]
		public BuyBoxPrices BuyBoxPrices{ get; set; }

		/// <summary>
		/// Sets the BuyBoxPrices property.
		/// </summary>
		/// <param name="buyBoxPrices">BuyBoxPrices property.</param>
		/// <returns>this instance.</returns>
		public Summary WithBuyBoxPrices( BuyBoxPrices buyBoxPrices )
		{
			this.BuyBoxPrices = buyBoxPrices;
			return this;
		}

		/// <summary>
		/// Checks if BuyBoxPrices property is set.
		/// </summary>
		/// <returns>true if BuyBoxPrices property is set.</returns>
		public bool IsSetBuyBoxPrices()
		{
			return this.BuyBoxPrices != null;
		}

		/// <summary>
		/// Gets and sets the ListPrice property.
		/// </summary>
		[ XmlElement( ElementName = "ListPrice" ) ]
		public MoneyType ListPrice{ get; set; }

		/// <summary>
		/// Sets the ListPrice property.
		/// </summary>
		/// <param name="listPrice">ListPrice property.</param>
		/// <returns>this instance.</returns>
		public Summary WithListPrice( MoneyType listPrice )
		{
			this.ListPrice = listPrice;
			return this;
		}

		/// <summary>
		/// Checks if ListPrice property is set.
		/// </summary>
		/// <returns>true if ListPrice property is set.</returns>
		public bool IsSetListPrice()
		{
			return this.ListPrice != null;
		}

		/// <summary>
		/// Gets and sets the SuggestedLowerPricePlusShipping property.
		/// </summary>
		[ XmlElement( ElementName = "SuggestedLowerPricePlusShipping" ) ]
		public MoneyType SuggestedLowerPricePlusShipping{ get; set; }

		/// <summary>
		/// Sets the SuggestedLowerPricePlusShipping property.
		/// </summary>
		/// <param name="suggestedLowerPricePlusShipping">SuggestedLowerPricePlusShipping property.</param>
		/// <returns>this instance.</returns>
		public Summary WithSuggestedLowerPricePlusShipping( MoneyType suggestedLowerPricePlusShipping )
		{
			this.SuggestedLowerPricePlusShipping = suggestedLowerPricePlusShipping;
			return this;
		}

		/// <summary>
		/// Checks if SuggestedLowerPricePlusShipping property is set.
		/// </summary>
		/// <returns>true if SuggestedLowerPricePlusShipping property is set.</returns>
		public bool IsSetSuggestedLowerPricePlusShipping()
		{
			return this.SuggestedLowerPricePlusShipping != null;
		}

		/// <summary>
		/// Gets and sets the BuyBoxEligibleOffers property.
		/// </summary>
		[ XmlElement( ElementName = "BuyBoxEligibleOffers" ) ]
		public BuyBoxEligibleOffers BuyBoxEligibleOffers{ get; set; }

		/// <summary>
		/// Sets the BuyBoxEligibleOffers property.
		/// </summary>
		/// <param name="buyBoxEligibleOffers">BuyBoxEligibleOffers property.</param>
		/// <returns>this instance.</returns>
		public Summary WithBuyBoxEligibleOffers( BuyBoxEligibleOffers buyBoxEligibleOffers )
		{
			this.BuyBoxEligibleOffers = buyBoxEligibleOffers;
			return this;
		}

		/// <summary>
		/// Checks if BuyBoxEligibleOffers property is set.
		/// </summary>
		/// <returns>true if BuyBoxEligibleOffers property is set.</returns>
		public bool IsSetBuyBoxEligibleOffers()
		{
			return this.BuyBoxEligibleOffers != null;
		}

		public override void ReadFragmentFrom( IMwsReader reader )
		{
			this.TotalOfferCount = reader.Read< decimal >( "TotalOfferCount" );
			this.NumberOfOffers = reader.Read< NumberOfOffers >( "NumberOfOffers" );
			this.LowestPrices = reader.Read< LowestPrices >( "LowestPrices" );
			this.BuyBoxPrices = reader.Read< BuyBoxPrices >( "BuyBoxPrices" );
			this.ListPrice = reader.Read< MoneyType >( "ListPrice" );
			this.SuggestedLowerPricePlusShipping = reader.Read< MoneyType >( "SuggestedLowerPricePlusShipping" );
			this.BuyBoxEligibleOffers = reader.Read< BuyBoxEligibleOffers >( "BuyBoxEligibleOffers" );
		}

		public override void WriteFragmentTo( IMwsWriter writer )
		{
			writer.Write( "TotalOfferCount", this.TotalOfferCount );
			writer.Write( "NumberOfOffers", this.NumberOfOffers );
			writer.Write( "LowestPrices", this.LowestPrices );
			writer.Write( "BuyBoxPrices", this.BuyBoxPrices );
			writer.Write( "ListPrice", this.ListPrice );
			writer.Write( "SuggestedLowerPricePlusShipping", this.SuggestedLowerPricePlusShipping );
			writer.Write( "BuyBoxEligibleOffers", this.BuyBoxEligibleOffers );
		}

		public override void WriteTo( IMwsWriter writer )
		{
			writer.Write( "http://mws.amazonservices.com/schema/Products/2011-10-01", "Summary", this );
		}

		public Summary(): base()
		{
		}
	}
}