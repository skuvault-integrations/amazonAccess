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
 * Competitive Price List
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
	public class CompetitivePriceList: AbstractMwsObject
	{
		private List< CompetitivePriceType > _competitivePrice;

		/// <summary>
		/// Gets and sets the CompetitivePrice property.
		/// </summary>
		[ XmlElement( ElementName = "CompetitivePrice" ) ]
		public List< CompetitivePriceType > CompetitivePrice
		{
			get
			{
				if( this._competitivePrice == null )
					this._competitivePrice = new List< CompetitivePriceType >();
				return this._competitivePrice;
			}
			set { this._competitivePrice = value; }
		}

		/// <summary>
		/// Sets the CompetitivePrice property.
		/// </summary>
		/// <param name="competitivePrice">CompetitivePrice property.</param>
		/// <returns>this instance.</returns>
		public CompetitivePriceList WithCompetitivePrice( CompetitivePriceType[] competitivePrice )
		{
			this._competitivePrice.AddRange( competitivePrice );
			return this;
		}

		/// <summary>
		/// Checks if CompetitivePrice property is set.
		/// </summary>
		/// <returns>true if CompetitivePrice property is set.</returns>
		public bool IsSetCompetitivePrice()
		{
			return this.CompetitivePrice.Count > 0;
		}

		public override void ReadFragmentFrom( IMwsReader reader )
		{
			this._competitivePrice = reader.ReadList< CompetitivePriceType >( "CompetitivePrice" );
		}

		public override void WriteFragmentTo( IMwsWriter writer )
		{
			writer.WriteList( "CompetitivePrice", this._competitivePrice );
		}

		public override void WriteTo( IMwsWriter writer )
		{
			writer.Write( "http://mws.amazonservices.com/schema/Products/2011-10-01", "CompetitivePriceList", this );
		}

		public CompetitivePriceList(): base()
		{
		}
	}
}