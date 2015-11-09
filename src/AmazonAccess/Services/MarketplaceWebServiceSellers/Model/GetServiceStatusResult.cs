/*******************************************************************************
 * Copyright 2009-2014 Amazon Services. All Rights Reserved.
 * Licensed under the Apache License, Version 2.0 (the "License"); 
 *
 * You may not use this file except in compliance with the License. 
 * You may obtain a copy of the License at: http://aws.amazon.com/apache2.0
 * This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
 * CONDITIONS OF ANY KIND, either express or implied. See the License for the 
 * specific language governing permissions and limitations under the License.
 *******************************************************************************
 * Get Service Status Result
 * API Version: 2011-07-01
 * Library Version: 2014-09-30
 * Generated: Mon Sep 15 19:38:40 GMT 2014
 */

using System;
using System.Xml.Serialization;
using AmazonAccess.Services.Common;

namespace AmazonAccess.Services.MarketplaceWebServiceSellers.Model
{
    [XmlType(Namespace = "https://mws.amazonservices.com/Sellers/2011-07-01")]
    [XmlRoot(Namespace = "https://mws.amazonservices.com/Sellers/2011-07-01", IsNullable = false)]
    public class GetServiceStatusResult : AbstractMwsObject
    {

        private ServiceStatusEnum? _status;
        private DateTime? _timestamp;
        private string _messageId;
        private MessageList _messages;

        /// <summary>
        /// Gets and sets the Status property.
        /// </summary>
        [XmlElement(ElementName = "Status")]
        public ServiceStatusEnum Status
        {
            get { return this._status.GetValueOrDefault(); }
            set { this._status = value; }
        }

    

        /// <summary>
        /// Sets the Status property.
        /// </summary>
        /// <param name="status">Status property.</param>
        /// <returns>this instance.</returns>
        public GetServiceStatusResult WithStatus(ServiceStatusEnum status)
        {
            this._status = status;
            return this;
        }

        /// <summary>
        /// Checks if Status property is set.
        /// </summary>
        /// <returns>true if Status property is set.</returns>
        public bool IsSetStatus()
        {
            return this._status != null;
        }

        /// <summary>
        /// Gets and sets the Timestamp property.
        /// </summary>
        [XmlElement(ElementName = "Timestamp")]
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
        public GetServiceStatusResult WithTimestamp(DateTime timestamp)
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
        [XmlElement(ElementName = "MessageId")]
        public string MessageId
        {
            get { return this._messageId; }
            set { this._messageId = value; }
        }

        /// <summary>
        /// Sets the MessageId property.
        /// </summary>
        /// <param name="messageId">MessageId property.</param>
        /// <returns>this instance.</returns>
        public GetServiceStatusResult WithMessageId(string messageId)
        {
            this._messageId = messageId;
            return this;
        }

        /// <summary>
        /// Checks if MessageId property is set.
        /// </summary>
        /// <returns>true if MessageId property is set.</returns>
        public bool IsSetMessageId()
        {
            return this._messageId != null;
        }

        /// <summary>
        /// Gets and sets the Messages property.
        /// </summary>
        [XmlElement(ElementName = "Messages")]
        public MessageList Messages
        {
            get { return this._messages; }
            set { this._messages = value; }
        }

        /// <summary>
        /// Sets the Messages property.
        /// </summary>
        /// <param name="messages">Messages property.</param>
        /// <returns>this instance.</returns>
        public GetServiceStatusResult WithMessages(MessageList messages)
        {
            this._messages = messages;
            return this;
        }

        /// <summary>
        /// Checks if Messages property is set.
        /// </summary>
        /// <returns>true if Messages property is set.</returns>
        public bool IsSetMessages()
        {
            return this._messages != null;
        }


        public override void ReadFragmentFrom(IMwsReader reader)
        {
            this._status = reader.Read<ServiceStatusEnum?>("Status");
            this._timestamp = reader.Read<DateTime?>("Timestamp");
            this._messageId = reader.Read<string>("MessageId");
            this._messages = reader.Read<MessageList>("Messages");
        }

        public override void WriteFragmentTo(IMwsWriter writer)
        {
            writer.Write("Status", this._status);
            writer.Write("Timestamp", this._timestamp);
            writer.Write("MessageId", this._messageId);
            writer.Write("Messages", this._messages);
        }

        public override void WriteTo(IMwsWriter writer)
        {
            writer.Write("https://mws.amazonservices.com/Sellers/2011-07-01", "GetServiceStatusResult", this);
        }

        public GetServiceStatusResult() : base()
        {
        }
    }
}
