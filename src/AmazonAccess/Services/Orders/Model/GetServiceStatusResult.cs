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
 * API Version: 2013-09-01
 * Library Version: 2015-09-24
 * Generated: Fri Sep 25 20:06:25 GMT 2015
 */

using System;
using System.Collections.Generic;
using AmazonAccess.Services.Common;

namespace AmazonAccess.Services.Orders.Model
{
	public class GetServiceStatusResult: AbstractMwsObject
	{
		private DateTime? _timestamp;
		private List< Message > _messages;

		/// <summary>
		/// Gets and sets the Status property.
		/// </summary>
		public string Status{ get; set; }

		/// <summary>
		/// Sets the Status property.
		/// </summary>
		/// <param name="status">Status property.</param>
		/// <returns>this instance.</returns>
		public GetServiceStatusResult WithStatus( string status )
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
		public List< Message > Messages
		{
			get
			{
				if( this._messages == null )
					this._messages = new List< Message >();
				return this._messages;
			}
			set { this._messages = value; }
		}

		/// <summary>
		/// Sets the Messages property.
		/// </summary>
		/// <param name="messages">Messages property.</param>
		/// <returns>this instance.</returns>
		public GetServiceStatusResult WithMessages( Message[] messages )
		{
			this._messages.AddRange( messages );
			return this;
		}

		/// <summary>
		/// Checks if Messages property is set.
		/// </summary>
		/// <returns>true if Messages property is set.</returns>
		public bool IsSetMessages()
		{
			return this.Messages.Count > 0;
		}

		public override void ReadFragmentFrom( IMwsReader reader )
		{
			this.Status = reader.Read< string >( "Status" );
			this._timestamp = reader.Read< DateTime? >( "Timestamp" );
			this.MessageId = reader.Read< string >( "MessageId" );
			this._messages = reader.ReadList< Message >( "Messages", "Message" );
		}

		public override void WriteFragmentTo( IMwsWriter writer )
		{
			writer.Write( "Status", this.Status );
			writer.Write( "Timestamp", this._timestamp );
			writer.Write( "MessageId", this.MessageId );
			writer.WriteList( "Messages", "Message", this._messages );
		}

		public override void WriteTo( IMwsWriter writer )
		{
			writer.Write( "https://mws.amazonservices.com/Orders/2013-09-01", "GetServiceStatusResult", this );
		}

		public GetServiceStatusResult(): base()
		{
		}
	}
}