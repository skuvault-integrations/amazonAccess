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
 * List Inventory Supply By Next Token Request
 * API Version: 2010-10-01
 * Library Version: 2015-06-18
 * Generated: Thu Jun 18 19:30:05 GMT 2015
 */

using System.Xml.Serialization;
using AmazonAccess.Services.Common;

namespace AmazonAccess.Services.FbaInventory.Model
{
	[ XmlType( Namespace = "http://mws.amazonaws.com/FulfillmentInventory/2010-10-01/" ) ]
	[ XmlRoot( Namespace = "http://mws.amazonaws.com/FulfillmentInventory/2010-10-01/", IsNullable = false ) ]
	public class ListInventorySupplyByNextTokenRequest: AbstractMwsObject
	{
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
		public ListInventorySupplyByNextTokenRequest WithSellerId( string sellerId )
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
		/// Gets and sets the MWSAuthToken property.
		/// </summary>
		[ XmlElement( ElementName = "MWSAuthToken" ) ]
		public string MWSAuthToken{ get; set; }

		/// <summary>
		/// Sets the MWSAuthToken property.
		/// </summary>
		/// <param name="mwsAuthToken">MWSAuthToken property.</param>
		/// <returns>this instance.</returns>
		public ListInventorySupplyByNextTokenRequest WithMWSAuthToken( string mwsAuthToken )
		{
			this.MWSAuthToken = mwsAuthToken;
			return this;
		}

		/// <summary>
		/// Checks if MWSAuthToken property is set.
		/// </summary>
		/// <returns>true if MWSAuthToken property is set.</returns>
		public bool IsSetMWSAuthToken()
		{
			return this.MWSAuthToken != null;
		}

		/// <summary>
		/// Gets and sets the Marketplace property.
		/// </summary>
		[ XmlElement( ElementName = "Marketplace" ) ]
		public string Marketplace{ get; set; }

		/// <summary>
		/// Sets the Marketplace property.
		/// </summary>
		/// <param name="marketplace">Marketplace property.</param>
		/// <returns>this instance.</returns>
		public ListInventorySupplyByNextTokenRequest WithMarketplace( string marketplace )
		{
			this.Marketplace = marketplace;
			return this;
		}

		/// <summary>
		/// Checks if Marketplace property is set.
		/// </summary>
		/// <returns>true if Marketplace property is set.</returns>
		public bool IsSetMarketplace()
		{
			return this.Marketplace != null;
		}

		/// <summary>
		/// Gets and sets the SupplyRegion property.
		/// </summary>
		[ XmlElement( ElementName = "SupplyRegion" ) ]
		public string SupplyRegion{ get; set; }

		/// <summary>
		/// Sets the SupplyRegion property.
		/// </summary>
		/// <param name="supplyRegion">SupplyRegion property.</param>
		/// <returns>this instance.</returns>
		public ListInventorySupplyByNextTokenRequest WithSupplyRegion( string supplyRegion )
		{
			this.SupplyRegion = supplyRegion;
			return this;
		}

		/// <summary>
		/// Checks if SupplyRegion property is set.
		/// </summary>
		/// <returns>true if SupplyRegion property is set.</returns>
		public bool IsSetSupplyRegion()
		{
			return this.SupplyRegion != null;
		}

		/// <summary>
		/// Gets and sets the NextToken property.
		/// </summary>
		[ XmlElement( ElementName = "NextToken" ) ]
		public string NextToken{ get; set; }

		/// <summary>
		/// Sets the NextToken property.
		/// </summary>
		/// <param name="nextToken">NextToken property.</param>
		/// <returns>this instance.</returns>
		public ListInventorySupplyByNextTokenRequest WithNextToken( string nextToken )
		{
			this.NextToken = nextToken;
			return this;
		}

		/// <summary>
		/// Checks if NextToken property is set.
		/// </summary>
		/// <returns>true if NextToken property is set.</returns>
		public bool IsSetNextToken()
		{
			return this.NextToken != null;
		}

		public override void ReadFragmentFrom( IMwsReader reader )
		{
			this.SellerId = reader.Read< string >( "SellerId" );
			this.MWSAuthToken = reader.Read< string >( "MWSAuthToken" );
			this.Marketplace = reader.Read< string >( "Marketplace" );
			this.SupplyRegion = reader.Read< string >( "SupplyRegion" );
			this.NextToken = reader.Read< string >( "NextToken" );
		}

		public override void WriteFragmentTo( IMwsWriter writer )
		{
			writer.Write( "SellerId", this.SellerId );
			writer.Write( "MWSAuthToken", this.MWSAuthToken );
			writer.Write( "Marketplace", this.Marketplace );
			writer.Write( "SupplyRegion", this.SupplyRegion );
			writer.Write( "NextToken", this.NextToken );
		}

		public override void WriteTo( IMwsWriter writer )
		{
			writer.Write( "http://mws.amazonaws.com/FulfillmentInventory/2010-10-01/", "ListInventorySupplyByNextTokenRequest", this );
		}

		public ListInventorySupplyByNextTokenRequest(): base()
		{
		}
	}
}