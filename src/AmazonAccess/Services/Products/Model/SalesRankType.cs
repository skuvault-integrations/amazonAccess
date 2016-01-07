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
 * Sales Rank Type
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
	public class SalesRankType: AbstractMwsObject
	{
		/// <summary>
		/// Gets and sets the ProductCategoryId property.
		/// </summary>
		[ XmlElement( ElementName = "ProductCategoryId" ) ]
		public string ProductCategoryId{ get; set; }

		/// <summary>
		/// Sets the ProductCategoryId property.
		/// </summary>
		/// <param name="productCategoryId">ProductCategoryId property.</param>
		/// <returns>this instance.</returns>
		public SalesRankType WithProductCategoryId( string productCategoryId )
		{
			this.ProductCategoryId = productCategoryId;
			return this;
		}

		/// <summary>
		/// Checks if ProductCategoryId property is set.
		/// </summary>
		/// <returns>true if ProductCategoryId property is set.</returns>
		public bool IsSetProductCategoryId()
		{
			return this.ProductCategoryId != null;
		}

		/// <summary>
		/// Gets and sets the Rank property.
		/// </summary>
		[ XmlElement( ElementName = "Rank" ) ]
		public decimal Rank{ get; set; }

		/// <summary>
		/// Sets the Rank property.
		/// </summary>
		/// <param name="rank">Rank property.</param>
		/// <returns>this instance.</returns>
		public SalesRankType WithRank( decimal rank )
		{
			this.Rank = rank;
			return this;
		}

		/// <summary>
		/// Checks if Rank property is set.
		/// </summary>
		/// <returns>true if Rank property is set.</returns>
		public bool IsSetRank()
		{
			return this.Rank != null;
		}

		public override void ReadFragmentFrom( IMwsReader reader )
		{
			this.ProductCategoryId = reader.Read< string >( "ProductCategoryId" );
			this.Rank = reader.Read< decimal >( "Rank" );
		}

		public override void WriteFragmentTo( IMwsWriter writer )
		{
			writer.Write( "ProductCategoryId", this.ProductCategoryId );
			writer.Write( "Rank", this.Rank );
		}

		public override void WriteTo( IMwsWriter writer )
		{
			writer.Write( "http://mws.amazonservices.com/schema/Products/2011-10-01", "SalesRankType", this );
		}

		public SalesRankType(): base()
		{
		}
	}
}