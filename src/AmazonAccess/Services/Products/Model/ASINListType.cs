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
 * ASIN List Type
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
	public class ASINListType: AbstractMwsObject
	{
		private List< string > _asin;

		/// <summary>
		/// Gets and sets the ASIN property.
		/// </summary>
		[ XmlElement( ElementName = "ASIN" ) ]
		public List< string > ASIN
		{
			get
			{
				if( this._asin == null )
					this._asin = new List< string >();
				return this._asin;
			}
			set { this._asin = value; }
		}

		/// <summary>
		/// Sets the ASIN property.
		/// </summary>
		/// <param name="asin">ASIN property.</param>
		/// <returns>this instance.</returns>
		public ASINListType WithASIN( string[] asin )
		{
			this._asin.AddRange( asin );
			return this;
		}

		/// <summary>
		/// Checks if ASIN property is set.
		/// </summary>
		/// <returns>true if ASIN property is set.</returns>
		public bool IsSetASIN()
		{
			return this.ASIN.Count > 0;
		}

		public override void ReadFragmentFrom( IMwsReader reader )
		{
			this._asin = reader.ReadList< string >( "ASIN" );
		}

		public override void WriteFragmentTo( IMwsWriter writer )
		{
			writer.WriteList( "ASIN", this._asin );
		}

		public override void WriteTo( IMwsWriter writer )
		{
			writer.Write( "http://mws.amazonservices.com/schema/Products/2011-10-01", "ASINListType", this );
		}

		public ASINListType(): base()
		{
		}
	}
}