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
 * Get Service Status Result
 * API Version: 2011-10-01
 * Library Version: 2015-09-01
 * Generated: Thu Sep 10 06:52:19 PDT 2015
 */

using System;
using System.Xml.Serialization;
using AmazonAccess.Services.Common;

namespace AmazonAccess.Services.Products.Model
{
	[ XmlType( Namespace = "http://mws.amazonservices.com/schema/Products/2011-10-01" ) ]
	[ XmlRoot( Namespace = "http://mws.amazonservices.com/schema/Products/2011-10-01", IsNullable = false ) ]
	public class GetServiceStatusResult: AbstractMwsObject
	{
		private DateTime? _timestamp;

		/// <summary>
		/// Gets and sets the Status property.
		/// </summary>
		[ XmlElement( ElementName = "Status" ) ]
		public ServiceStatusEnum? Status{ get; set; }

		/// <summary>
		/// Sets the Status property.
		/// </summary>
		/// <param name="status">Status property.</param>
		/// <returns>this instance.</returns>
		public GetServiceStatusResult WithStatus( ServiceStatusEnum? status )
		{
			this.Status = status;
			return this;
		}

		/// <summary>
		/// Checks if Status property is set.
		/// </summary>
		/// <returns>true if Status property is set.</returns>
		public bool IsSetStatus()
		{
			return this.Status != null;
		}

		/// <summary>
		/// Gets and sets the Timestamp property.
		/// </summary>
		[ XmlElement( ElementName = "Timestamp" ) ]
		public DateTime Timestamp
		{
			get { return this._timestamp.GetValueOrDefault(); }
			set { this._timestamp = value; }
		}

		/// <summary>
		/// Sets the Timestamp property.
		/// </summary>
		/// <param name="timestamp">Timestamp property.</param>
		/// <returns>this instance.</returns>
		public GetServiceStatusResult WithTimestamp( DateTime timestamp )
		{
			this._timestamp = timestamp;
			return this;
		}

		/// <summary>
		/// Checks if Timestamp property is set.
		/// </summary>
		/// <returns>true if Timestamp property is set.</returns>
		public bool IsSetTimestamp()
		{
			return this._timestamp != null;
		}

		/// <summary>
		/// Gets and sets the MessageId property.
		/// </summary>
		[ XmlElement( ElementName = "MessageId" ) ]
		public string MessageId{ get; set; }

		/// <summary>
		/// Sets the MessageId property.
		/// </summary>
		/// <param name="messageId">MessageId property.</param>
		/// <returns>this instance.</returns>
		public GetServiceStatusResult WithMessageId( string messageId )
		{
			this.MessageId = messageId;
			return this;
		}

		/// <summary>
		/// Checks if MessageId property is set.
		/// </summary>
		/// <returns>true if MessageId property is set.</returns>
		public bool IsSetMessageId()
		{
			return this.MessageId != null;
		}

		/// <summary>
		/// Gets and sets the Messages property.
		/// </summary>
		[ XmlElement( ElementName = "Messages" ) ]
		public MessageList Messages{ get; set; }

		/// <summary>
		/// Sets the Messages property.
		/// </summary>
		/// <param name="messages">Messages property.</param>
		/// <returns>this instance.</returns>
		public GetServiceStatusResult WithMessages( MessageList messages )
		{
			this.Messages = messages;
			return this;
		}

		/// <summary>
		/// Checks if Messages property is set.
		/// </summary>
		/// <returns>true if Messages property is set.</returns>
		public bool IsSetMessages()
		{
			return this.Messages != null;
		}

		public override void ReadFragmentFrom( IMwsReader reader )
		{
			this.Status = reader.Read< ServiceStatusEnum? >( "Status" );
			this._timestamp = reader.Read< DateTime? >( "Timestamp" );
			this.MessageId = reader.Read< string >( "MessageId" );
			this.Messages = reader.Read< MessageList >( "Messages" );
		}

		public override void WriteFragmentTo( IMwsWriter writer )
		{
			writer.Write( "Status", this.Status );
			writer.Write( "Timestamp", this._timestamp );
			writer.Write( "MessageId", this.MessageId );
			writer.Write( "Messages", this.Messages );
		}

		public override void WriteTo( IMwsWriter writer )
		{
			writer.Write( "http://mws.amazonservices.com/schema/Products/2011-10-01", "GetServiceStatusResult", this );
		}

		public GetServiceStatusResult(): base()
		{
		}
	}
}