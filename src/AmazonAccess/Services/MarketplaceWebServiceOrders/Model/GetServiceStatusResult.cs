/******************************************************************************* 
 *  Copyright 2008-2012 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"); 
 *  
 *  You may not use this file except in compliance with the License. 
 *  You may obtain a copy of the License at: http://aws.amazon.com/apache2.0
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the 
 *  specific language governing permissions and limitations under the License.
 * ***************************************************************************** 
 * 
 *  Marketplace Web Service Orders CSharp Library
 *  API Version: 2011-01-01
 * 
 */

using System;
using System.Xml.Serialization;
using System.Text;

namespace AmazonAccess.Services.MarketplaceWebServiceOrders.Model
{
    [XmlType(Namespace = "https://mws.amazonservices.com/Orders/2011-01-01")]
    [XmlRoot(Namespace = "https://mws.amazonservices.com/Orders/2011-01-01", IsNullable = false)]
    public class GetServiceStatusResult
    {
    
        private ServiceStatusEnum? statusField;

        private DateTime? timestampField;

        private String messageIdField;

        private  MessageList messagesField;

        /// <summary>
        /// Gets and sets the Status property.
        /// </summary>
        [XmlElement(ElementName = "Status")]
        public ServiceStatusEnum Status
        {
            get { return this.statusField.GetValueOrDefault() ; }
            set { this.statusField= value; }
        }



        /// <summary>
        /// Sets the Status property
        /// </summary>
        /// <param name="status">Status property</param>
        /// <returns>this instance</returns>
        public GetServiceStatusResult WithStatus(ServiceStatusEnum status)
        {
            this.statusField = status;
            return this;
        }



        /// <summary>
        /// Checks if Status property is set
        /// </summary>
        /// <returns>true if Status property is set</returns>
        public Boolean IsSetStatus()
        {
            return this.statusField.HasValue;

        }


        /// <summary>
        /// Gets and sets the Timestamp property.
        /// </summary>
        [XmlElement(ElementName = "Timestamp")]
        public DateTime Timestamp
        {
            get { return this.timestampField.GetValueOrDefault() ; }
            set { this.timestampField= value; }
        }



        /// <summary>
        /// Sets the Timestamp property
        /// </summary>
        /// <param name="timestamp">Timestamp property</param>
        /// <returns>this instance</returns>
        public GetServiceStatusResult WithTimestamp(DateTime timestamp)
        {
            this.timestampField = timestamp;
            return this;
        }



        /// <summary>
        /// Checks if Timestamp property is set
        /// </summary>
        /// <returns>true if Timestamp property is set</returns>
        public Boolean IsSetTimestamp()
        {
            return  this.timestampField.HasValue;

        }


        /// <summary>
        /// Gets and sets the MessageId property.
        /// </summary>
        [XmlElement(ElementName = "MessageId")]
        public String MessageId
        {
            get { return this.messageIdField ; }
            set { this.messageIdField= value; }
        }



        /// <summary>
        /// Sets the MessageId property
        /// </summary>
        /// <param name="messageId">MessageId property</param>
        /// <returns>this instance</returns>
        public GetServiceStatusResult WithMessageId(String messageId)
        {
            this.messageIdField = messageId;
            return this;
        }



        /// <summary>
        /// Checks if MessageId property is set
        /// </summary>
        /// <returns>true if MessageId property is set</returns>
        public Boolean IsSetMessageId()
        {
            return  this.messageIdField != null;

        }


        /// <summary>
        /// Gets and sets the Messages property.
        /// </summary>
        [XmlElement(ElementName = "Messages")]
        public MessageList Messages
        {
            get { return this.messagesField ; }
            set { this.messagesField = value; }
        }



        /// <summary>
        /// Sets the Messages property
        /// </summary>
        /// <param name="messages">Messages property</param>
        /// <returns>this instance</returns>
        public GetServiceStatusResult WithMessages(MessageList messages)
        {
            this.messagesField = messages;
            return this;
        }



        /// <summary>
        /// Checks if Messages property is set
        /// </summary>
        /// <returns>true if Messages property is set</returns>
        public Boolean IsSetMessages()
        {
            return this.messagesField != null;
        }






        /// <summary>
        /// XML fragment representation of this object
        /// </summary>
        /// <returns>XML fragment for this object.</returns>
        /// <remarks>
        /// Name for outer tag expected to be set by calling method. 
        /// This fragment returns inner properties representation only
        /// </remarks>


        protected internal String ToXMLFragment() {
            StringBuilder xml = new StringBuilder();
            if (this.IsSetStatus()) {
                xml.Append("<Status>");
                xml.Append(this.Status);
                xml.Append("</Status>");
            }
            if (this.IsSetTimestamp()) {
                xml.Append("<Timestamp>");
                xml.Append(this.Timestamp);
                xml.Append("</Timestamp>");
            }
            if (this.IsSetMessageId()) {
                xml.Append("<MessageId>");
                xml.Append(this.EscapeXML(this.MessageId));
                xml.Append("</MessageId>");
            }
            if (this.IsSetMessages()) {
                MessageList  messagesObj = this.Messages;
                xml.Append("<Messages>");
                xml.Append(messagesObj.ToXMLFragment());
                xml.Append("</Messages>");
            } 
            return xml.ToString();
        }

        /**
         * 
         * Escape XML special characters
         */
        private String EscapeXML(String str) {
            if (str == null)
                return "null";
            StringBuilder sb = new StringBuilder();
            foreach (Char c in str)
            {
                switch (c) {
                case '&':
                    sb.Append("&amp;");
                    break;
                case '<':
                    sb.Append("&lt;");
                    break;
                case '>':
                    sb.Append("&gt;");
                    break;
                case '\'':
                    sb.Append("&#039;");
                    break;
                case '"':
                    sb.Append("&quot;");
                    break;
                default:
                    sb.Append(c);
                    break;
                }
            }
            return sb.ToString();
        }



    }

}