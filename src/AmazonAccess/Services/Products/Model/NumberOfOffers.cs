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
 * Number Of Offers
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
	public class NumberOfOffers: AbstractMwsObject
	{
		private List< OfferCountType > _offerCount;

		/// <summary>
		/// Gets and sets the OfferCount property.
		/// </summary>
		[ XmlElement( ElementName = "OfferCount" ) ]
		public List< OfferCountType > OfferCount
		{
			get
			{
				if( this._offerCount == null )
					this._offerCount = new List< OfferCountType >();
				return this._offerCount;
			}
			set { this._offerCount = value; }
		}

		/// <summary>
		/// Sets the OfferCount property.
		/// </summary>
		/// <param name="offerCount">OfferCount property.</param>
		/// <returns>this instance.</returns>
		public NumberOfOffers WithOfferCount( OfferCountType[] offerCount )
		{
			this._offerCount.AddRange( offerCount );
			return this;
		}

		/// <summary>
		/// Checks if OfferCount property is set.
		/// </summary>
		/// <returns>true if OfferCount property is set.</returns>
		public bool IsSetOfferCount()
		{
			return this.OfferCount.Count > 0;
		}

		public override void ReadFragmentFrom( IMwsReader reader )
		{
			this._offerCount = reader.ReadList< OfferCountType >( "OfferCount" );
		}

		public override void WriteFragmentTo( IMwsWriter writer )
		{
			writer.WriteList( "OfferCount", this._offerCount );
		}

		public override void WriteTo( IMwsWriter writer )
		{
			writer.Write( "http://mws.amazonservices.com/schema/Products/2011-10-01", "NumberOfOffers", this );
		}

		public NumberOfOffers(): base()
		{
		}
	}
}