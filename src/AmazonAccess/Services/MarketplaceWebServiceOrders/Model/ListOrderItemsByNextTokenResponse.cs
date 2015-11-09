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
 * Library Version: 2015-03-05
 * Generated: Tue Mar 03 22:11:26 GMT 2015
 */

using System.Xml.Serialization;
using AmazonAccess.Services.Common;

namespace AmazonAccess.Services.MarketplaceWebServiceOrders.Model
{
	[ XmlRoot( Namespace = "https://mws.amazonservices.com/Orders/2013-09-01", IsNullable = false ) ]
	public class ListOrderItemsByNextTokenResponse: AbstractMwsObject, IMwsResponse
	{

		private ListOrderItemsByNextTokenResult _listOrderItemsByNextTokenResult;
		private ResponseMetadata _responseMetadata;
		private ResponseHeaderMetadata _responseHeaderMetadata;

		/// <summary>
		/// Gets and sets the ListOrderItemsByNextTokenResult property.
		/// </summary>
		public ListOrderItemsByNextTokenResult ListOrderItemsByNextTokenResult
		{
			get { return this._listOrderItemsByNextTokenResult; }
			set { this._listOrderItemsByNextTokenResult = value; }
		}

		/// <summary>
		/// Sets the ListOrderItemsByNextTokenResult property.
		/// </summary>
		/// <param name="listOrderItemsByNextTokenResult">ListOrderItemsByNextTokenResult property.</param>
		/// <returns>this instance.</returns>
		public ListOrderItemsByNextTokenResponse WithListOrderItemsByNextTokenResult( ListOrderItemsByNextTokenResult listOrderItemsByNextTokenResult )
		{
			this._listOrderItemsByNextTokenResult = listOrderItemsByNextTokenResult;
			return this;
		}

		/// <summary>
		/// Checks if ListOrderItemsByNextTokenResult property is set.
		/// </summary>
		/// <returns>true if ListOrderItemsByNextTokenResult property is set.</returns>
		public bool IsSetListOrderItemsByNextTokenResult()
		{
			return this._listOrderItemsByNextTokenResult != null;
		}

		/// <summary>
		/// Gets and sets the ResponseMetadata property.
		/// </summary>
		public ResponseMetadata ResponseMetadata
		{
			get { return this._responseMetadata; }
			set { this._responseMetadata = value; }
		}

		/// <summary>
		/// Sets the ResponseMetadata property.
		/// </summary>
		/// <param name="responseMetadata">ResponseMetadata property.</param>
		/// <returns>this instance.</returns>
		public ListOrderItemsByNextTokenResponse WithResponseMetadata( ResponseMetadata responseMetadata )
		{
			this._responseMetadata = responseMetadata;
			return this;
		}

		/// <summary>
		/// Checks if ResponseMetadata property is set.
		/// </summary>
		/// <returns>true if ResponseMetadata property is set.</returns>
		public bool IsSetResponseMetadata()
		{
			return this._responseMetadata != null;
		}

		/// <summary>
		/// Gets and sets the ResponseHeaderMetadata property.
		/// </summary>
		public ResponseHeaderMetadata ResponseHeaderMetadata
		{
			get { return this._responseHeaderMetadata; }
			set { this._responseHeaderMetadata = value; }
		}

		/// <summary>
		/// Sets the ResponseHeaderMetadata property.
		/// </summary>
		/// <param name="responseHeaderMetadata">ResponseHeaderMetadata property.</param>
		/// <returns>this instance.</returns>
		public ListOrderItemsByNextTokenResponse WithResponseHeaderMetadata( ResponseHeaderMetadata responseHeaderMetadata )
		{
			this._responseHeaderMetadata = responseHeaderMetadata;
			return this;
		}

		/// <summary>
		/// Checks if ResponseHeaderMetadata property is set.
		/// </summary>
		/// <returns>true if ResponseHeaderMetadata property is set.</returns>
		public bool IsSetResponseHeaderMetadata()
		{
			return this._responseHeaderMetadata != null;
		}


		public override void ReadFragmentFrom( IMwsReader reader )
		{
			this._listOrderItemsByNextTokenResult = reader.Read< ListOrderItemsByNextTokenResult >( "ListOrderItemsByNextTokenResult" );
			this._responseMetadata = reader.Read< ResponseMetadata >( "ResponseMetadata" );
		}

		public override void WriteFragmentTo( IMwsWriter writer )
		{
			writer.Write( "ListOrderItemsByNextTokenResult", this._listOrderItemsByNextTokenResult );
			writer.Write( "ResponseMetadata", this._responseMetadata );
		}

		public override void WriteTo( IMwsWriter writer )
		{
			writer.Write( "https://mws.amazonservices.com/Orders/2013-09-01", "ListOrderItemsByNextTokenResponse", this );
		}
	}
}