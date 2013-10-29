/******************************************************************************* 
 *  Copyright 2009 Amazon Services. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"); 
 *  
 *  You may not use this file except in compliance with the License. 
 *  You may obtain a copy of the License at: http://aws.amazon.com/apache2.0
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the 
 *  specific language governing permissions and limitations under the License.
 * ***************************************************************************** 
 * 
 *  FBA Inventory Service MWS CSharp Library
 *  API Version: 2010-10-01
 *  Generated: Fri Oct 22 09:53:30 UTC 2010 
 * 
 */

using System;
using System.Xml.Serialization;

namespace AmazonAccess.Services.FbaInventoryServiceMws.Model
{
	[ XmlType( Namespace = "http://mws.amazonaws.com/FulfillmentInventory/2010-10-01/" ) ]
	[ XmlRoot( Namespace = "http://mws.amazonaws.com/FulfillmentInventory/2010-10-01/", IsNullable = false ) ]
	public class GetServiceStatusRequest
	{

		private String sellerIdField;

		private String marketplaceField;


		/// <summary>
		/// Gets and sets the SellerId property.
		/// </summary>
		[ XmlElement( ElementName = "SellerId" ) ]
		public String SellerId
		{
			get { return this.sellerIdField; }
			set { this.sellerIdField = value; }
		}



		/// <summary>
		/// Sets the SellerId property
		/// </summary>
		/// <param name="sellerId">SellerId property</param>
		/// <returns>this instance</returns>
		public GetServiceStatusRequest WithSellerId( String sellerId )
		{
			this.sellerIdField = sellerId;
			return this;
		}



		/// <summary>
		/// Checks if SellerId property is set
		/// </summary>
		/// <returns>true if SellerId property is set</returns>
		public Boolean IsSetSellerId()
		{
			return this.sellerIdField != null;

		}


		/// <summary>
		/// Gets and sets the Marketplace property.
		/// </summary>
		[ XmlElement( ElementName = "Marketplace" ) ]
		public String Marketplace
		{
			get { return this.marketplaceField; }
			set { this.marketplaceField = value; }
		}



		/// <summary>
		/// Sets the Marketplace property
		/// </summary>
		/// <param name="marketplace">Marketplace property</param>
		/// <returns>this instance</returns>
		public GetServiceStatusRequest WithMarketplace( String marketplace )
		{
			this.marketplaceField = marketplace;
			return this;
		}



		/// <summary>
		/// Checks if Marketplace property is set
		/// </summary>
		/// <returns>true if Marketplace property is set</returns>
		public Boolean IsSetMarketplace()
		{
			return this.marketplaceField != null;

		}
	}
}