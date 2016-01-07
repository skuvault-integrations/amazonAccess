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
 * Id List Type
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
	public class IdListType: AbstractMwsObject
	{
		private List< string > _id;

		/// <summary>
		/// Gets and sets the Id property.
		/// </summary>
		[ XmlElement( ElementName = "Id" ) ]
		public List< string > Id
		{
			get
			{
				if( this._id == null )
					this._id = new List< string >();
				return this._id;
			}
			set { this._id = value; }
		}

		/// <summary>
		/// Sets the Id property.
		/// </summary>
		/// <param name="id">Id property.</param>
		/// <returns>this instance.</returns>
		public IdListType WithId( string[] id )
		{
			this._id.AddRange( id );
			return this;
		}

		/// <summary>
		/// Checks if Id property is set.
		/// </summary>
		/// <returns>true if Id property is set.</returns>
		public bool IsSetId()
		{
			return this.Id.Count > 0;
		}

		public override void ReadFragmentFrom( IMwsReader reader )
		{
			this._id = reader.ReadList< string >( "Id" );
		}

		public override void WriteFragmentTo( IMwsWriter writer )
		{
			writer.WriteList( "Id", this._id );
		}

		public override void WriteTo( IMwsWriter writer )
		{
			writer.Write( "http://mws.amazonservices.com/schema/Products/2011-10-01", "IdListType", this );
		}

		public IdListType(): base()
		{
		}
	}
}