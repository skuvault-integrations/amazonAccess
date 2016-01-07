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
 * Product
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
	public class Product: AbstractMwsObject
	{
		/// <summary>
		/// Gets and sets the Identifiers property.
		/// </summary>
		[ XmlElement( ElementName = "Identifiers" ) ]
		public IdentifierType Identifiers{ get; set; }

		/// <summary>
		/// Sets the Identifiers property.
		/// </summary>
		/// <param name="identifiers">Identifiers property.</param>
		/// <returns>this instance.</returns>
		public Product WithIdentifiers( IdentifierType identifiers )
		{
			this.Identifiers = identifiers;
			return this;
		}

		/// <summary>
		/// Checks if Identifiers property is set.
		/// </summary>
		/// <returns>true if Identifiers property is set.</returns>
		public bool IsSetIdentifiers()
		{
			return this.Identifiers != null;
		}

		/// <summary>
		/// Gets and sets the AttributeSets property.
		/// </summary>
		[ XmlElement( ElementName = "AttributeSets" ) ]
		public AttributeSetList AttributeSets{ get; set; }

		/// <summary>
		/// Sets the AttributeSets property.
		/// </summary>
		/// <param name="attributeSets">AttributeSets property.</param>
		/// <returns>this instance.</returns>
		public Product WithAttributeSets( AttributeSetList attributeSets )
		{
			this.AttributeSets = attributeSets;
			return this;
		}

		/// <summary>
		/// Checks if AttributeSets property is set.
		/// </summary>
		/// <returns>true if AttributeSets property is set.</returns>
		public bool IsSetAttributeSets()
		{
			return this.AttributeSets != null;
		}

		/// <summary>
		/// Gets and sets the Relationships property.
		/// </summary>
		[ XmlElement( ElementName = "Relationships" ) ]
		public RelationshipList Relationships{ get; set; }

		/// <summary>
		/// Sets the Relationships property.
		/// </summary>
		/// <param name="relationships">Relationships property.</param>
		/// <returns>this instance.</returns>
		public Product WithRelationships( RelationshipList relationships )
		{
			this.Relationships = relationships;
			return this;
		}

		/// <summary>
		/// Checks if Relationships property is set.
		/// </summary>
		/// <returns>true if Relationships property is set.</returns>
		public bool IsSetRelationships()
		{
			return this.Relationships != null;
		}

		/// <summary>
		/// Gets and sets the CompetitivePricing property.
		/// </summary>
		[ XmlElement( ElementName = "CompetitivePricing" ) ]
		public CompetitivePricingType CompetitivePricing{ get; set; }

		/// <summary>
		/// Sets the CompetitivePricing property.
		/// </summary>
		/// <param name="competitivePricing">CompetitivePricing property.</param>
		/// <returns>this instance.</returns>
		public Product WithCompetitivePricing( CompetitivePricingType competitivePricing )
		{
			this.CompetitivePricing = competitivePricing;
			return this;
		}

		/// <summary>
		/// Checks if CompetitivePricing property is set.
		/// </summary>
		/// <returns>true if CompetitivePricing property is set.</returns>
		public bool IsSetCompetitivePricing()
		{
			return this.CompetitivePricing != null;
		}

		/// <summary>
		/// Gets and sets the SalesRankings property.
		/// </summary>
		[ XmlElement( ElementName = "SalesRankings" ) ]
		public SalesRankList SalesRankings{ get; set; }

		/// <summary>
		/// Sets the SalesRankings property.
		/// </summary>
		/// <param name="salesRankings">SalesRankings property.</param>
		/// <returns>this instance.</returns>
		public Product WithSalesRankings( SalesRankList salesRankings )
		{
			this.SalesRankings = salesRankings;
			return this;
		}

		/// <summary>
		/// Checks if SalesRankings property is set.
		/// </summary>
		/// <returns>true if SalesRankings property is set.</returns>
		public bool IsSetSalesRankings()
		{
			return this.SalesRankings != null;
		}

		/// <summary>
		/// Gets and sets the LowestOfferListings property.
		/// </summary>
		[ XmlElement( ElementName = "LowestOfferListings" ) ]
		public LowestOfferListingList LowestOfferListings{ get; set; }

		/// <summary>
		/// Sets the LowestOfferListings property.
		/// </summary>
		/// <param name="lowestOfferListings">LowestOfferListings property.</param>
		/// <returns>this instance.</returns>
		public Product WithLowestOfferListings( LowestOfferListingList lowestOfferListings )
		{
			this.LowestOfferListings = lowestOfferListings;
			return this;
		}

		/// <summary>
		/// Checks if LowestOfferListings property is set.
		/// </summary>
		/// <returns>true if LowestOfferListings property is set.</returns>
		public bool IsSetLowestOfferListings()
		{
			return this.LowestOfferListings != null;
		}

		/// <summary>
		/// Gets and sets the Offers property.
		/// </summary>
		[ XmlElement( ElementName = "Offers" ) ]
		public OffersList Offers{ get; set; }

		/// <summary>
		/// Sets the Offers property.
		/// </summary>
		/// <param name="offers">Offers property.</param>
		/// <returns>this instance.</returns>
		public Product WithOffers( OffersList offers )
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
			this.Identifiers = reader.Read< IdentifierType >( "Identifiers" );
			this.AttributeSets = reader.Read< AttributeSetList >( "AttributeSets" );
			this.Relationships = reader.Read< RelationshipList >( "Relationships" );
			this.CompetitivePricing = reader.Read< CompetitivePricingType >( "CompetitivePricing" );
			this.SalesRankings = reader.Read< SalesRankList >( "SalesRankings" );
			this.LowestOfferListings = reader.Read< LowestOfferListingList >( "LowestOfferListings" );
			this.Offers = reader.Read< OffersList >( "Offers" );
		}

		public override void WriteFragmentTo( IMwsWriter writer )
		{
			writer.Write( "Identifiers", this.Identifiers );
			writer.Write( "AttributeSets", this.AttributeSets );
			writer.Write( "Relationships", this.Relationships );
			writer.Write( "CompetitivePricing", this.CompetitivePricing );
			writer.Write( "SalesRankings", this.SalesRankings );
			writer.Write( "LowestOfferListings", this.LowestOfferListings );
			writer.Write( "Offers", this.Offers );
		}

		public override void WriteTo( IMwsWriter writer )
		{
			writer.Write( "http://mws.amazonservices.com/schema/Products/2011-10-01", "Product", this );
		}

		public Product(): base()
		{
		}
	}
}