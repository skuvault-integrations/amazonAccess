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
 * Get Matching Product For Id Result
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
	public class GetMatchingProductForIdResult: AbstractMwsObject
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
		public GetMatchingProductForIdResult WithProducts( ProductList products )
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

		/// <summary>
		/// Gets and sets the Error property.
		/// </summary>
		[ XmlElement( ElementName = "Error" ) ]
		public Error Error{ get; set; }

		/// <summary>
		/// Sets the Error property.
		/// </summary>
		/// <param name="error">Error property.</param>
		/// <returns>this instance.</returns>
		public GetMatchingProductForIdResult WithError( Error error )
		{
			this.Error = error;
			return this;
		}

		/// <summary>
		/// Checks if Error property is set.
		/// </summary>
		/// <returns>true if Error property is set.</returns>
		public bool IsSetError()
		{
			return this.Error != null;
		}

		/// <summary>
		/// Gets and sets the Id property.
		/// </summary>
		[ XmlAttribute( AttributeName = "Id" ) ]
		public string Id{ get; set; }

		/// <summary>
		/// Sets the Id property.
		/// </summary>
		/// <param name="id">Id property.</param>
		/// <returns>this instance.</returns>
		public GetMatchingProductForIdResult WithId( string id )
		{
			this.Id = id;
			return this;
		}

		/// <summary>
		/// Checks if Id property is set.
		/// </summary>
		/// <returns>true if Id property is set.</returns>
		public bool IsSetId()
		{
			return this.Id != null;
		}

		/// <summary>
		/// Gets and sets the IdType property.
		/// </summary>
		[ XmlAttribute( AttributeName = "IdType" ) ]
		public string IdType{ get; set; }

		/// <summary>
		/// Sets the IdType property.
		/// </summary>
		/// <param name="idType">IdType property.</param>
		/// <returns>this instance.</returns>
		public GetMatchingProductForIdResult WithIdType( string idType )
		{
			this.IdType = idType;
			return this;
		}

		/// <summary>
		/// Checks if IdType property is set.
		/// </summary>
		/// <returns>true if IdType property is set.</returns>
		public bool IsSetIdType()
		{
			return this.IdType != null;
		}

		/// <summary>
		/// Gets and sets the status property.
		/// </summary>
		[ XmlAttribute( AttributeName = "status" ) ]
		public string status{ get; set; }

		/// <summary>
		/// Sets the status property.
		/// </summary>
		/// <param name="status">status property.</param>
		/// <returns>this instance.</returns>
		public GetMatchingProductForIdResult Withstatus( string status )
		{
			this.status = status;
			return this;
		}

		/// <summary>
		/// Checks if status property is set.
		/// </summary>
		/// <returns>true if status property is set.</returns>
		public bool IsSetstatus()
		{
			return this.status != null;
		}

		public override void ReadFragmentFrom( IMwsReader reader )
		{
			this.Id = reader.ReadAttribute< string >( "Id" );
			this.IdType = reader.ReadAttribute< string >( "IdType" );
			this.status = reader.ReadAttribute< string >( "status" );
			this.Products = reader.Read< ProductList >( "Products" );
			this.Error = reader.Read< Error >( "Error" );
		}

		public override void WriteFragmentTo( IMwsWriter writer )
		{
			writer.WriteAttribute( "Id", this.Id );
			writer.WriteAttribute( "IdType", this.IdType );
			writer.WriteAttribute( "status", this.status );
			writer.Write( "Products", this.Products );
			writer.Write( "Error", this.Error );
		}

		public override void WriteTo( IMwsWriter writer )
		{
			writer.Write( "http://mws.amazonservices.com/schema/Products/2011-10-01", "GetMatchingProductForIdResult", this );
		}

		public GetMatchingProductForIdResult(): base()
		{
		}
	}
}