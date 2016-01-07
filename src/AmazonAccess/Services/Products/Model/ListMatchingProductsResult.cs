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
 * List Matching Products Result
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
	public class ListMatchingProductsResult: AbstractMwsObject
	{
		/// <summary>
		/// Gets and sets the Products property.
		/// </summary>
		[ XmlElement( ElementName = "Products" ) ]
		public ProductList Products{ get; set; }

		/// <summary>
		/// Sets the Products property.
		/// </summary>
		/// <param name="products">Products property.</param>
		/// <returns>this instance.</returns>
		public ListMatchingProductsResult WithProducts( ProductList products )
		{
			this.Products = products;
			return this;
		}

		/// <summary>
		/// Checks if Products property is set.
		/// </summary>
		/// <returns>true if Products property is set.</returns>
		public bool IsSetProducts()
		{
			return this.Products != null;
		}

		public override void ReadFragmentFrom( IMwsReader reader )
		{
			this.Products = reader.Read< ProductList >( "Products" );
		}

		public override void WriteFragmentTo( IMwsWriter writer )
		{
			writer.Write( "Products", this.Products );
		}

		public override void WriteTo( IMwsWriter writer )
		{
			writer.Write( "http://mws.amazonservices.com/schema/Products/2011-10-01", "ListMatchingProductsResult", this );
		}

		public ListMatchingProductsResult(): base()
		{
		}
	}
}