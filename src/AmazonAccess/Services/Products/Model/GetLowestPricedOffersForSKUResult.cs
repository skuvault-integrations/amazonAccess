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
 * Get Lowest Priced Offers For SKU Result
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
	public class GetLowestPricedOffersForSKUResult: AbstractMwsObject
	{
		/// <summary>
		/// Gets and sets the MarketplaceID property.
		/// </summary>
		[ XmlAttribute( AttributeName = "MarketplaceID" ) ]
		public string MarketplaceID{ get; set; }

		/// <summary>
		/// Sets the MarketplaceID property.
		/// </summary>
		/// <param name="marketplaceID">MarketplaceID property.</param>
		/// <returns>this instance.</returns>
		public GetLowestPricedOffersForSKUResult WithMarketplaceID( string marketplaceID )
		{
			this.MarketplaceID = marketplaceID;
			return this;
		}

		/// <summary>
		/// Checks if MarketplaceID property is set.
		/// </summary>
		/// <returns>true if MarketplaceID property is set.</returns>
		public bool IsSetMarketplaceID()
		{
			return this.MarketplaceID != null;
		}

		/// <summary>
		/// Gets and sets the SKU property.
		/// </summary>
		[ XmlAttribute( AttributeName = "SKU" ) ]
		public string SKU{ get; set; }

		/// <summary>
		/// Sets the SKU property.
		/// </summary>
		/// <param name="sku">SKU property.</param>
		/// <returns>this instance.</returns>
		public GetLowestPricedOffersForSKUResult WithSKU( string sku )
		{
			this.SKU = sku;
			return this;
		}

		/// <summary>
		/// Checks if SKU property is set.
		/// </summary>
		/// <returns>true if SKU property is set.</returns>
		public bool IsSetSKU()
		{
			return this.SKU != null;
		}

		/// <summary>
		/// Gets and sets the ItemCondition property.
		/// </summary>
		[ XmlAttribute( AttributeName = "ItemCondition" ) ]
		public string ItemCondition{ get; set; }

		/// <summary>
		/// Sets the ItemCondition property.
		/// </summary>
		/// <param name="itemCondition">ItemCondition property.</param>
		/// <returns>this instance.</returns>
		public GetLowestPricedOffersForSKUResult WithItemCondition( string itemCondition )
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
		/// Gets and sets the status property.
		/// </summary>
		[ XmlAttribute( AttributeName = "status" ) ]
		public string status{ get; set; }

		/// <summary>
		/// Sets the status property.
		/// </summary>
		/// <param name="status">status property.</param>
		/// <returns>this instance.</returns>
		public GetLowestPricedOffersForSKUResult Withstatus( string status )
		{
			this.status = status;
			return this;
		}

		/// <summary>
		/// Checks if status property is set.
		/// </summary>
		/// <returns>true if status property is set.</returns>
		public bool IsSetstatus()
		{
			return this.status != null;
		}

		/// <summary>
		/// Gets and sets the Identifier property.
		/// </summary>
		[ XmlElement( ElementName = "Identifier" ) ]
		public GetLowestPricedOffersSkuIdentifier Identifier{ get; set; }

		/// <summary>
		/// Sets the Identifier property.
		/// </summary>
		/// <param name="identifier">Identifier property.</param>
		/// <returns>this instance.</returns>
		public GetLowestPricedOffersForSKUResult WithIdentifier( GetLowestPricedOffersSkuIdentifier identifier )
		{
			this.Identifier = identifier;
			return this;
		}

		/// <summary>
		/// Checks if Identifier property is set.
		/// </summary>
		/// <returns>true if Identifier property is set.</returns>
		public bool IsSetIdentifier()
		{
			return this.Identifier != null;
		}

		/// <summary>
		/// Gets and sets the Summary property.
		/// </summary>
		[ XmlElement( ElementName = "Summary" ) ]
		public Summary Summary{ get; set; }

		/// <summary>
		/// Sets the Summary property.
		/// </summary>
		/// <param name="summary">Summary property.</param>
		/// <returns>this instance.</returns>
		public GetLowestPricedOffersForSKUResult WithSummary( Summary summary )
		{
			this.Summary = summary;
			return this;
		}

		/// <summary>
		/// Checks if Summary property is set.
		/// </summary>
		/// <returns>true if Summary property is set.</returns>
		public bool IsSetSummary()
		{
			return this.Summary != null;
		}

		/// <summary>
		/// Gets and sets the Offers property.
		/// </summary>
		[ XmlElement( ElementName = "Offers" ) ]
		public SKUOfferDetailList Offers{ get; set; }

		/// <summary>
		/// Sets the Offers property.
		/// </summary>
		/// <param name="offers">Offers property.</param>
		/// <returns>this instance.</returns>
		public GetLowestPricedOffersForSKUResult WithOffers( SKUOfferDetailList offers )
		{
			this.Offers = offers;
			return this;
		}

		/// <summary>
		/// Checks if Offers property is set.
		/// </summary>
		/// <returns>true if Offers property is set.</returns>
		public bool IsSetOffers()
		{
			return this.Offers != null;
		}

		public override void ReadFragmentFrom( IMwsReader reader )
		{
			this.MarketplaceID = reader.ReadAttribute< string >( "MarketplaceID" );
			this.SKU = reader.ReadAttribute< string >( "SKU" );
			this.ItemCondition = reader.ReadAttribute< string >( "ItemCondition" );
			this.status = reader.ReadAttribute< string >( "status" );
			this.Identifier = reader.Read< GetLowestPricedOffersSkuIdentifier >( "Identifier" );
			this.Summary = reader.Read< Summary >( "Summary" );
			this.Offers = reader.Read< SKUOfferDetailList >( "Offers" );
		}

		public override void WriteFragmentTo( IMwsWriter writer )
		{
			writer.WriteAttribute( "MarketplaceID", this.MarketplaceID );
			writer.WriteAttribute( "SKU", this.SKU );
			writer.WriteAttribute( "ItemCondition", this.ItemCondition );
			writer.WriteAttribute( "status", this.status );
			writer.Write( "Identifier", this.Identifier );
			writer.Write( "Summary", this.Summary );
			writer.Write( "Offers", this.Offers );
		}

		public override void WriteTo( IMwsWriter writer )
		{
			writer.Write( "http://mws.amazonservices.com/schema/Products/2011-10-01", "GetLowestPricedOffersForSKUResult", this );
		}

		public GetLowestPricedOffersForSKUResult(): base()
		{
		}
	}
}