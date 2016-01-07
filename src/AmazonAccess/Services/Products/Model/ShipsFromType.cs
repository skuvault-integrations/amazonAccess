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
 * Ships From Type
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
	public class ShipsFromType: AbstractMwsObject
	{
		/// <summary>
		/// Gets and sets the State property.
		/// </summary>
		[ XmlElement( ElementName = "State" ) ]
		public string State{ get; set; }

		/// <summary>
		/// Sets the State property.
		/// </summary>
		/// <param name="state">State property.</param>
		/// <returns>this instance.</returns>
		public ShipsFromType WithState( string state )
		{
			this.State = state;
			return this;
		}

		/// <summary>
		/// Checks if State property is set.
		/// </summary>
		/// <returns>true if State property is set.</returns>
		public bool IsSetState()
		{
			return this.State != null;
		}

		/// <summary>
		/// Gets and sets the Country property.
		/// </summary>
		[ XmlElement( ElementName = "Country" ) ]
		public string Country{ get; set; }

		/// <summary>
		/// Sets the Country property.
		/// </summary>
		/// <param name="country">Country property.</param>
		/// <returns>this instance.</returns>
		public ShipsFromType WithCountry( string country )
		{
			this.Country = country;
			return this;
		}

		/// <summary>
		/// Checks if Country property is set.
		/// </summary>
		/// <returns>true if Country property is set.</returns>
		public bool IsSetCountry()
		{
			return this.Country != null;
		}

		public override void ReadFragmentFrom( IMwsReader reader )
		{
			this.State = reader.Read< string >( "State" );
			this.Country = reader.Read< string >( "Country" );
		}

		public override void WriteFragmentTo( IMwsWriter writer )
		{
			writer.Write( "State", this.State );
			writer.Write( "Country", this.Country );
		}

		public override void WriteTo( IMwsWriter writer )
		{
			writer.Write( "http://mws.amazonservices.com/schema/Products/2011-10-01", "ShipsFromType", this );
		}

		public ShipsFromType(): base()
		{
		}
	}
}