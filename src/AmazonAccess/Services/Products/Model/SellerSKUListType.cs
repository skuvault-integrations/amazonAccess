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
 * Seller SKU List Type
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
	public class SellerSKUListType: AbstractMwsObject
	{
		private List< string > _sellerSKU;

		/// <summary>
		/// Gets and sets the SellerSKU property.
		/// </summary>
		[ XmlElement( ElementName = "SellerSKU" ) ]
		public List< string > SellerSKU
		{
			get
			{
				if( this._sellerSKU == null )
					this._sellerSKU = new List< string >();
				return this._sellerSKU;
			}
			set { this._sellerSKU = value; }
		}

		/// <summary>
		/// Sets the SellerSKU property.
		/// </summary>
		/// <param name="sellerSKU">SellerSKU property.</param>
		/// <returns>this instance.</returns>
		public SellerSKUListType WithSellerSKU( string[] sellerSKU )
		{
			this._sellerSKU.AddRange( sellerSKU );
			return this;
		}

		/// <summary>
		/// Checks if SellerSKU property is set.
		/// </summary>
		/// <returns>true if SellerSKU property is set.</returns>
		public bool IsSetSellerSKU()
		{
			return this.SellerSKU.Count > 0;
		}

		public override void ReadFragmentFrom( IMwsReader reader )
		{
			this._sellerSKU = reader.ReadList< string >( "SellerSKU" );
		}

		public override void WriteFragmentTo( IMwsWriter writer )
		{
			writer.WriteList( "SellerSKU", this._sellerSKU );
		}

		public override void WriteTo( IMwsWriter writer )
		{
			writer.Write( "http://mws.amazonservices.com/schema/Products/2011-10-01", "SellerSKUListType", this );
		}

		public SellerSKUListType(): base()
		{
		}
	}
}