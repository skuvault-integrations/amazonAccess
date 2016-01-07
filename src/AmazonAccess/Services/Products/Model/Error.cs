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
 * Error
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
	public class Error: AbstractMwsObject
	{
		/// <summary>
		/// Gets and sets the Type property.
		/// </summary>
		[ XmlElement( ElementName = "Type" ) ]
		public string Type{ get; set; }

		/// <summary>
		/// Sets the Type property.
		/// </summary>
		/// <param name="type">Type property.</param>
		/// <returns>this instance.</returns>
		public Error WithType( string type )
		{
			this.Type = type;
			return this;
		}

		/// <summary>
		/// Checks if Type property is set.
		/// </summary>
		/// <returns>true if Type property is set.</returns>
		public bool IsSetType()
		{
			return this.Type != null;
		}

		/// <summary>
		/// Gets and sets the Code property.
		/// </summary>
		[ XmlElement( ElementName = "Code" ) ]
		public string Code{ get; set; }

		/// <summary>
		/// Sets the Code property.
		/// </summary>
		/// <param name="code">Code property.</param>
		/// <returns>this instance.</returns>
		public Error WithCode( string code )
		{
			this.Code = code;
			return this;
		}

		/// <summary>
		/// Checks if Code property is set.
		/// </summary>
		/// <returns>true if Code property is set.</returns>
		public bool IsSetCode()
		{
			return this.Code != null;
		}

		/// <summary>
		/// Gets and sets the Message property.
		/// </summary>
		[ XmlElement( ElementName = "Message" ) ]
		public string Message{ get; set; }

		/// <summary>
		/// Sets the Message property.
		/// </summary>
		/// <param name="message">Message property.</param>
		/// <returns>this instance.</returns>
		public Error WithMessage( string message )
		{
			this.Message = message;
			return this;
		}

		/// <summary>
		/// Checks if Message property is set.
		/// </summary>
		/// <returns>true if Message property is set.</returns>
		public bool IsSetMessage()
		{
			return this.Message != null;
		}

		/// <summary>
		/// Gets and sets the Detail property.
		/// </summary>
		[ XmlElement( ElementName = "Detail" ) ]
		public ErrorDetail Detail{ get; set; }

		/// <summary>
		/// Sets the Detail property.
		/// </summary>
		/// <param name="detail">Detail property.</param>
		/// <returns>this instance.</returns>
		public Error WithDetail( ErrorDetail detail )
		{
			this.Detail = detail;
			return this;
		}

		/// <summary>
		/// Checks if Detail property is set.
		/// </summary>
		/// <returns>true if Detail property is set.</returns>
		public bool IsSetDetail()
		{
			return this.Detail != null;
		}

		public override void ReadFragmentFrom( IMwsReader reader )
		{
			this.Type = reader.Read< string >( "Type" );
			this.Code = reader.Read< string >( "Code" );
			this.Message = reader.Read< string >( "Message" );
			this.Detail = reader.Read< ErrorDetail >( "Detail" );
		}

		public override void WriteFragmentTo( IMwsWriter writer )
		{
			writer.Write( "Type", this.Type );
			writer.Write( "Code", this.Code );
			writer.Write( "Message", this.Message );
			writer.Write( "Detail", this.Detail );
		}

		public override void WriteTo( IMwsWriter writer )
		{
			writer.Write( "http://mws.amazonservices.com/schema/Products/2011-10-01", "Error", this );
		}

		public Error(): base()
		{
		}
	}
}