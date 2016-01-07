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
 * ASIN Identifier
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
	public class ASINIdentifier: AbstractMwsObject
	{
		/// <summary>
		/// Gets and sets the MarketplaceId property.
		/// </summary>
		[ XmlElement( ElementName = "MarketplaceId" ) ]
		public string MarketplaceId{ get; set; }

		/// <summary>
		/// Sets the MarketplaceId property.
		/// </summary>
		/// <param name="marketplaceId">MarketplaceId property.</param>
		/// <returns>this instance.</returns>
		public ASINIdentifier WithMarketplaceId( string marketplaceId )
		{
			this.MarketplaceId = marketplaceId;
			return this;
		}

		/// <summary>
		/// Checks if MarketplaceId property is set.
		/// </summary>
		/// <returns>true if MarketplaceId property is set.</returns>
		public bool IsSetMarketplaceId()
		{
			return this.MarketplaceId != null;
		}

		/// <summary>
		/// Gets and sets the ASIN property.
		/// </summary>
		[ XmlElement( ElementName = "ASIN" ) ]
		public string ASIN{ get; set; }

		/// <summary>
		/// Sets the ASIN property.
		/// </summary>
		/// <param name="asin">ASIN property.</param>
		/// <returns>this instance.</returns>
		public ASINIdentifier WithASIN( string asin )
		{
			this.ASIN = asin;
			return this;
		}

		/// <summary>
		/// Checks if ASIN property is set.
		/// </summary>
		/// <returns>true if ASIN property is set.</returns>
		public bool IsSetASIN()
		{
			return this.ASIN != null;
		}

		public override void ReadFragmentFrom( IMwsReader reader )
		{
			this.MarketplaceId = reader.Read< string >( "MarketplaceId" );
			this.ASIN = reader.Read< string >( "ASIN" );
		}

		public override void WriteFragmentTo( IMwsWriter writer )
		{
			writer.Write( "MarketplaceId", this.MarketplaceId );
			writer.Write( "ASIN", this.ASIN );
		}

		public override void WriteTo( IMwsWriter writer )
		{
			writer.Write( "http://mws.amazonservices.com/schema/Products/2011-10-01", "ASINIdentifier", this );
		}

		public ASINIdentifier(): base()
		{
		}
	}
}