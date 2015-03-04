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
using MarketplaceWebServiceOrders.Model;

namespace AmazonAccess.Services.MarketplaceWebServiceOrders.Model
{
    [XmlType(Namespace = "https://mws.amazonservices.com/Orders/2011-01-01")]
    [XmlRoot(Namespace = "https://mws.amazonservices.com/Orders/2011-01-01", IsNullable = false)]
    public class OrderItemList
    {
    
        private  List<OrderItem> orderItemField;


        /// <summary>
        /// Gets and sets the OrderItem property.
        /// </summary>
        [XmlElement(ElementName = "OrderItem")]
        public List<OrderItem> OrderItem
        {
            get
            {
                if (this.orderItemField == null)
                {
                    this.orderItemField = new List<OrderItem>();
                }
                return this.orderItemField;
            }
            set { this.orderItemField =  value; }
        }



        /// <summary>
        /// Sets the OrderItem property
        /// </summary>
        /// <param name="list">OrderItem property</param>
        /// <returns>this instance</returns>
        public OrderItemList WithOrderItem(params OrderItem[] list)
        {
            foreach (OrderItem item in list)
            {
                this.OrderItem.Add(item);
            }
            return this;
        }          
 


        /// <summary>
        /// Checks if OrderItem property is set
        /// </summary>
        /// <returns>true if OrderItem property is set</returns>
        public Boolean IsSetOrderItem()
        {
            return (this.OrderItem.Count > 0);
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
            List<OrderItem> orderItemObjList = this.OrderItem;
            foreach (OrderItem orderItemObj in orderItemObjList) {
                xml.Append("<OrderItem>");
                xml.Append(orderItemObj.ToXMLFragment());
                xml.Append("</OrderItem>");
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