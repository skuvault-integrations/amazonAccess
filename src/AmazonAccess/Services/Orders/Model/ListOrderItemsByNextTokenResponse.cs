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
 * List Order Items By Next Token Response
 * API Version: 2013-09-01
 * Library Version: 2015-09-24
 * Generated: Fri Sep 25 20:06:25 GMT 2015
 */

using AmazonAccess.Services.Common;

namespace AmazonAccess.Services.Orders.Model
{
	public class ListOrderItemsByNextTokenResponse: AbstractMwsObject, IMwsResponse
	{
		/// <summary>
		/// Gets and sets the ListOrderItemsByNextTokenResult property.
		/// </summary>
		public ListOrderItemsByNextTokenResult ListOrderItemsByNextTokenResult{ get; set; }

		/// <summary>
		/// Sets the ListOrderItemsByNextTokenResult property.
		/// </summary>
		/// <param name="listOrderItemsByNextTokenResult">ListOrderItemsByNextTokenResult property.</param>
		/// <returns>this instance.</returns>
		public ListOrderItemsByNextTokenResponse WithListOrderItemsByNextTokenResult( ListOrderItemsByNextTokenResult listOrderItemsByNextTokenResult )
		{
			this.ListOrderItemsByNextTokenResult = listOrderItemsByNextTokenResult;
			return this;
		}

		/// <summary>
		/// Checks if ListOrderItemsByNextTokenResult property is set.
		/// </summary>
		/// <returns>true if ListOrderItemsByNextTokenResult property is set.</returns>
		public bool IsSetListOrderItemsByNextTokenResult()
		{
			return this.ListOrderItemsByNextTokenResult != null;
		}

		/// <summary>
		/// Gets and sets the ResponseMetadata property.
		/// </summary>
		public ResponseMetadata ResponseMetadata{ get; set; }

		/// <summary>
		/// Sets the ResponseMetadata property.
		/// </summary>
		/// <param name="responseMetadata">ResponseMetadata property.</param>
		/// <returns>this instance.</returns>
		public ListOrderItemsByNextTokenResponse WithResponseMetadata( ResponseMetadata responseMetadata )
		{
			this.ResponseMetadata = responseMetadata;
			return this;
		}

		/// <summary>
		/// Checks if ResponseMetadata property is set.
		/// </summary>
		/// <returns>true if ResponseMetadata property is set.</returns>
		public bool IsSetResponseMetadata()
		{
			return this.ResponseMetadata != null;
		}

		/// <summary>
		/// Gets and sets the ResponseHeaderMetadata property.
		/// </summary>
		public MwsResponseHeaderMetadata ResponseHeaderMetadata{ get; set; }

		/// <summary>
		/// Sets the ResponseHeaderMetadata property.
		/// </summary>
		/// <param name="responseHeaderMetadata">ResponseHeaderMetadata property.</param>
		/// <returns>this instance.</returns>
		public ListOrderItemsByNextTokenResponse WithResponseHeaderMetadata( MwsResponseHeaderMetadata responseHeaderMetadata )
		{
			this.ResponseHeaderMetadata = responseHeaderMetadata;
			return this;
		}

		/// <summary>
		/// Checks if ResponseHeaderMetadata property is set.
		/// </summary>
		/// <returns>true if ResponseHeaderMetadata property is set.</returns>
		public bool IsSetResponseHeaderMetadata()
		{
			return this.ResponseHeaderMetadata != null;
		}

		public override void ReadFragmentFrom( IMwsReader reader )
		{
			this.ListOrderItemsByNextTokenResult = reader.Read< ListOrderItemsByNextTokenResult >( "ListOrderItemsByNextTokenResult" );
			this.ResponseMetadata = reader.Read< ResponseMetadata >( "ResponseMetadata" );
		}

		public override void WriteFragmentTo( IMwsWriter writer )
		{
			writer.Write( "ListOrderItemsByNextTokenResult", this.ListOrderItemsByNextTokenResult );
			writer.Write( "ResponseMetadata", this.ResponseMetadata );
		}

		public override void WriteTo( IMwsWriter writer )
		{
			writer.Write( "https://mws.amazonservices.com/Orders/2013-09-01", "ListOrderItemsByNextTokenResponse", this );
		}

		public ListOrderItemsByNextTokenResponse(): base()
		{
		}
	}
}