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
 * Offer Type
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
	public class OfferType: AbstractMwsObject
	{
		/// <summary>
		/// Gets and sets the BuyingPrice property.
		/// </summary>
		[ XmlElement( ElementName = "BuyingPrice" ) ]
		public PriceType BuyingPrice{ get; set; }

		/// <summary>
		/// Sets the BuyingPrice property.
		/// </summary>
		/// <param name="buyingPrice">BuyingPrice property.</param>
		/// <returns>this instance.</returns>
		public OfferType WithBuyingPrice( PriceType buyingPrice )
		{
			this.BuyingPrice = buyingPrice;
			return this;
		}

		/// <summary>
		/// Checks if BuyingPrice property is set.
		/// </summary>
		/// <returns>true if BuyingPrice property is set.</returns>
		public bool IsSetBuyingPrice()
		{
			return this.BuyingPrice != null;
		}

		/// <summary>
		/// Gets and sets the RegularPrice property.
		/// </summary>
		[ XmlElement( ElementName = "RegularPrice" ) ]
		public MoneyType RegularPrice{ get; set; }

		/// <summary>
		/// Sets the RegularPrice property.
		/// </summary>
		/// <param name="regularPrice">RegularPrice property.</param>
		/// <returns>this instance.</returns>
		public OfferType WithRegularPrice( MoneyType regularPrice )
		{
			this.RegularPrice = regularPrice;
			return this;
		}

		/// <summary>
		/// Checks if RegularPrice property is set.
		/// </summary>
		/// <returns>true if RegularPrice property is set.</returns>
		public bool IsSetRegularPrice()
		{
			return this.RegularPrice != null;
		}

		/// <summary>
		/// Gets and sets the FulfillmentChannel property.
		/// </summary>
		[ XmlElement( ElementName = "FulfillmentChannel" ) ]
		public string FulfillmentChannel{ get; set; }

		/// <summary>
		/// Sets the FulfillmentChannel property.
		/// </summary>
		/// <param name="fulfillmentChannel">FulfillmentChannel property.</param>
		/// <returns>this instance.</returns>
		public OfferType WithFulfillmentChannel( string fulfillmentChannel )
		{
			this.FulfillmentChannel = fulfillmentChannel;
			return this;
		}

		/// <summary>
		/// Checks if FulfillmentChannel property is set.
		/// </summary>
		/// <returns>true if FulfillmentChannel property is set.</returns>
		public bool IsSetFulfillmentChannel()
		{
			return this.FulfillmentChannel != null;
		}

		/// <summary>
		/// Gets and sets the ItemCondition property.
		/// </summary>
		[ XmlElement( ElementName = "ItemCondition" ) ]
		public string ItemCondition{ get; set; }

		/// <summary>
		/// Sets the ItemCondition property.
		/// </summary>
		/// <param name="itemCondition">ItemCondition property.</param>
		/// <returns>this instance.</returns>
		public OfferType WithItemCondition( string itemCondition )
		{
			this.ItemCondition = itemCondition;
			return this;
		}

		/// <summary>
		/// Checks if ItemCondition property is set.
		/// </summary>
		/// <returns>true if ItemCondition property is set.</returns>
		public bool IsSetItemCondition()
		{
			return this.ItemCondition != null;
		}

		/// <summary>
		/// Gets and sets the ItemSubCondition property.
		/// </summary>
		[ XmlElement( ElementName = "ItemSubCondition" ) ]
		public string ItemSubCondition{ get; set; }

		/// <summary>
		/// Sets the ItemSubCondition property.
		/// </summary>
		/// <param name="itemSubCondition">ItemSubCondition property.</param>
		/// <returns>this instance.</returns>
		public OfferType WithItemSubCondition( string itemSubCondition )
		{
			this.ItemSubCondition = itemSubCondition;
			return this;
		}

		/// <summary>
		/// Checks if ItemSubCondition property is set.
		/// </summary>
		/// <returns>true if ItemSubCondition property is set.</returns>
		public bool IsSetItemSubCondition()
		{
			return this.ItemSubCondition != null;
		}

		/// <summary>
		/// Gets and sets the SellerId property.
		/// </summary>
		[ XmlElement( ElementName = "SellerId" ) ]
		public string SellerId{ get; set; }

		/// <summary>
		/// Sets the SellerId property.
		/// </summary>
		/// <param name="sellerId">SellerId property.</param>
		/// <returns>this instance.</returns>
		public OfferType WithSellerId( string sellerId )
		{
			this.SellerId = sellerId;
			return this;
		}

		/// <summary>
		/// Checks if SellerId property is set.
		/// </summary>
		/// <returns>true if SellerId property is set.</returns>
		public bool IsSetSellerId()
		{
			return this.SellerId != null;
		}

		/// <summary>
		/// Gets and sets the SellerSKU property.
		/// </summary>
		[ XmlElement( ElementName = "SellerSKU" ) ]
		public string SellerSKU{ get; set; }

		/// <summary>
		/// Sets the SellerSKU property.
		/// </summary>
		/// <param name="sellerSKU">SellerSKU property.</param>
		/// <returns>this instance.</returns>
		public OfferType WithSellerSKU( string sellerSKU )
		{
			this.SellerSKU = sellerSKU;
			return this;
		}

		/// <summary>
		/// Checks if SellerSKU property is set.
		/// </summary>
		/// <returns>true if SellerSKU property is set.</returns>
		public bool IsSetSellerSKU()
		{
			return this.SellerSKU != null;
		}

		public override void ReadFragmentFrom( IMwsReader reader )
		{
			this.BuyingPrice = reader.Read< PriceType >( "BuyingPrice" );
			this.RegularPrice = reader.Read< MoneyType >( "RegularPrice" );
			this.FulfillmentChannel = reader.Read< string >( "FulfillmentChannel" );
			this.ItemCondition = reader.Read< string >( "ItemCondition" );
			this.ItemSubCondition = reader.Read< string >( "ItemSubCondition" );
			this.SellerId = reader.Read< string >( "SellerId" );
			this.SellerSKU = reader.Read< string >( "SellerSKU" );
		}

		public override void WriteFragmentTo( IMwsWriter writer )
		{
			writer.Write( "BuyingPrice", this.BuyingPrice );
			writer.Write( "RegularPrice", this.RegularPrice );
			writer.Write( "FulfillmentChannel", this.FulfillmentChannel );
			writer.Write( "ItemCondition", this.ItemCondition );
			writer.Write( "ItemSubCondition", this.ItemSubCondition );
			writer.Write( "SellerId", this.SellerId );
			writer.Write( "SellerSKU", this.SellerSKU );
		}

		public override void WriteTo( IMwsWriter writer )
		{
			writer.Write( "http://mws.amazonservices.com/schema/Products/2011-10-01", "OfferType", this );
		}

		public OfferType(): base()
		{
		}
	}
}