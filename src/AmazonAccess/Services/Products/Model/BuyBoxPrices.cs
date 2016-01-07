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
 * Buy Box Prices
 * API Version: 2011-10-01
 * Library Version: 2015-09-01
 * Generated: Thu Sep 10 06:52:19 PDT 2015
 */

using System.Collections.Generic;
using System.Xml.Serialization;
using AmazonAccess.Services.Common;

namespace AmazonAccess.Services.Products.Model
{
	[ XmlType( Namespace = "http://mws.amazonservices.com/schema/Products/2011-10-01" ) ]
	[ XmlRoot( Namespace = "http://mws.amazonservices.com/schema/Products/2011-10-01", IsNullable = false ) ]
	public class BuyBoxPrices: AbstractMwsObject
	{
		private List< BuyBoxPriceType > _buyBoxPrice;

		/// <summary>
		/// Gets and sets the BuyBoxPrice property.
		/// </summary>
		[ XmlElement( ElementName = "BuyBoxPrice" ) ]
		public List< BuyBoxPriceType > BuyBoxPrice
		{
			get
			{
				if( this._buyBoxPrice == null )
					this._buyBoxPrice = new List< BuyBoxPriceType >();
				return this._buyBoxPrice;
			}
			set { this._buyBoxPrice = value; }
		}

		/// <summary>
		/// Sets the BuyBoxPrice property.
		/// </summary>
		/// <param name="buyBoxPrice">BuyBoxPrice property.</param>
		/// <returns>this instance.</returns>
		public BuyBoxPrices WithBuyBoxPrice( BuyBoxPriceType[] buyBoxPrice )
		{
			this._buyBoxPrice.AddRange( buyBoxPrice );
			return this;
		}

		/// <summary>
		/// Checks if BuyBoxPrice property is set.
		/// </summary>
		/// <returns>true if BuyBoxPrice property is set.</returns>
		public bool IsSetBuyBoxPrice()
		{
			return this.BuyBoxPrice.Count > 0;
		}

		public override void ReadFragmentFrom( IMwsReader reader )
		{
			this._buyBoxPrice = reader.ReadList< BuyBoxPriceType >( "BuyBoxPrice" );
		}

		public override void WriteFragmentTo( IMwsWriter writer )
		{
			writer.WriteList( "BuyBoxPrice", this._buyBoxPrice );
		}

		public override void WriteTo( IMwsWriter writer )
		{
			writer.Write( "http://mws.amazonservices.com/schema/Products/2011-10-01", "BuyBoxPrices", this );
		}

		public BuyBoxPrices(): base()
		{
		}
	}
}