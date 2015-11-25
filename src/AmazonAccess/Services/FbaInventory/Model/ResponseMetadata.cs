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
 * Response Metadata
 * API Version: 2010-10-01
 * Library Version: 2015-06-18
 * Generated: Thu Jun 18 19:30:05 GMT 2015
 */

using System.Xml.Serialization;
using AmazonAccess.Services.Common;

namespace AmazonAccess.Services.FbaInventory.Model
{
	[ XmlType( Namespace = "http://mws.amazonaws.com/FulfillmentInventory/2010-10-01/" ) ]
	[ XmlRoot( Namespace = "http://mws.amazonaws.com/FulfillmentInventory/2010-10-01/", IsNullable = false ) ]
	public class ResponseMetadata: AbstractMwsObject
	{
		/// <summary>
		/// Gets and sets the RequestId property.
		/// </summary>
		[ XmlElement( ElementName = "RequestId" ) ]
		public string RequestId{ get; set; }

		/// <summary>
		/// Sets the RequestId property.
		/// </summary>
		/// <param name="requestId">RequestId property.</param>
		/// <returns>this instance.</returns>
		public ResponseMetadata WithRequestId( string requestId )
		{
			this.RequestId = requestId;
			return this;
		}

		/// <summary>
		/// Checks if RequestId property is set.
		/// </summary>
		/// <returns>true if RequestId property is set.</returns>
		public bool IsSetRequestId()
		{
			return this.RequestId != null;
		}

		public override void ReadFragmentFrom( IMwsReader reader )
		{
			this.RequestId = reader.Read< string >( "RequestId" );
		}

		public override void WriteFragmentTo( IMwsWriter writer )
		{
			writer.Write( "RequestId", this.RequestId );
		}

		public override void WriteTo( IMwsWriter writer )
		{
			writer.Write( "http://mws.amazonaws.com/FulfillmentInventory/2010-10-01/", "ResponseMetadata", this );
		}

		public ResponseMetadata(): base()
		{
		}
	}
}