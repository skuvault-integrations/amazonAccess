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
using System.Collections.Generic;
using System.Text;

namespace AmazonAccess.Services.MarketplaceWebServiceOrders.Model
{
    [XmlType(Namespace = "https://mws.amazonservices.com/Orders/2011-01-01")]
    [XmlRoot(Namespace = "https://mws.amazonservices.com/Orders/2011-01-01", IsNullable = false)]
    public class FulfillmentChannelList
    {
    
        private List<FulfillmentChannelEnum> channelField;


        /// <summary>
        /// Gets and sets the Channel property.
        /// </summary>
        [XmlElement(ElementName = "Channel")]
        public List<FulfillmentChannelEnum> Channel
        {
            get
            {
                if (this.channelField == null)
                {
                    this.channelField = new List<FulfillmentChannelEnum>();
                }
                return this.channelField;
            }
            set { this.channelField =  value; }
        }



        /// <summary>
        /// Sets the Channel property
        /// </summary>
        /// <param name="list">Channel property</param>
        /// <returns>this instance</returns>
        public FulfillmentChannelList WithChannel(params FulfillmentChannelEnum[] list)
        {
            foreach (FulfillmentChannelEnum item in list)
            {
                this.Channel.Add(item);
            }
            return this;
        }          
 


        /// <summary>
        /// Checks of Channel property is set
        /// </summary>
        /// <returns>true if Channel property is set</returns>
        public Boolean IsSetChannel()
        {
            return (this.Channel.Count > 0);
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
            List<FulfillmentChannelEnum> channelObjList  =  this.Channel;
            foreach (FulfillmentChannelEnum channelObj in channelObjList) { 
                xml.Append("<Channel>");
                xml.Append(channelObj);
                xml.Append("</Channel>");
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