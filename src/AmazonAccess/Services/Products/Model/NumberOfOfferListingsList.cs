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
 * Number Of Offer Listings List
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
	public class NumberOfOfferListingsList: AbstractMwsObject
	{
		private List< OfferListingCountType > _offerListingCount;

		/// <summary>
		/// Gets and sets the OfferListingCount property.
		/// </summary>
		[ XmlElement( ElementName = "OfferListingCount" ) ]
		public List< OfferListingCountType > OfferListingCount
		{
			get
			{
				if( this._offerListingCount == null )
					this._offerListingCount = new List< OfferListingCountType >();
				return this._offerListingCount;
			}
			set { this._offerListingCount = value; }
		}

		/// <summary>
		/// Sets the OfferListingCount property.
		/// </summary>
		/// <param name="offerListingCount">OfferListingCount property.</param>
		/// <returns>this instance.</returns>
		public NumberOfOfferListingsList WithOfferListingCount( OfferListingCountType[] offerListingCount )
		{
			this._offerListingCount.AddRange( offerListingCount );
			return this;
		}

		/// <summary>
		/// Checks if OfferListingCount property is set.
		/// </summary>
		/// <returns>true if OfferListingCount property is set.</returns>
		public bool IsSetOfferListingCount()
		{
			return this.OfferListingCount.Count > 0;
		}

		public override void ReadFragmentFrom( IMwsReader reader )
		{
			this._offerListingCount = reader.ReadList< OfferListingCountType >( "OfferListingCount" );
		}

		public override void WriteFragmentTo( IMwsWriter writer )
		{
			writer.WriteList( "OfferListingCount", this._offerListingCount );
		}

		public override void WriteTo( IMwsWriter writer )
		{
			writer.Write( "http://mws.amazonservices.com/schema/Products/2011-10-01", "NumberOfOfferListingsList", this );
		}

		public NumberOfOfferListingsList(): base()
		{
		}
	}
}