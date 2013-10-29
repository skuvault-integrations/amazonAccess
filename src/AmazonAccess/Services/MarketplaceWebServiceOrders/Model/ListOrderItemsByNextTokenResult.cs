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
    public class ListOrderItemsByNextTokenResult
    {
    
        private String nextTokenField;

        private String amazonOrderIdField;

        private  OrderItemList orderItemsField;

        /// <summary>
        /// Gets and sets the NextToken property.
        /// </summary>
        [XmlElement(ElementName = "NextToken")]
        public String NextToken
        {
            get { return this.nextTokenField ; }
            set { this.nextTokenField= value; }
        }



        /// <summary>
        /// Sets the NextToken property
        /// </summary>
        /// <param name="nextToken">NextToken property</param>
        /// <returns>this instance</returns>
        public ListOrderItemsByNextTokenResult WithNextToken(String nextToken)
        {
            this.nextTokenField = nextToken;
            return this;
        }



        /// <summary>
        /// Checks if NextToken property is set
        /// </summary>
        /// <returns>true if NextToken property is set</returns>
        public Boolean IsSetNextToken()
        {
            return  this.nextTokenField != null;

        }


        /// <summary>
        /// Gets and sets the AmazonOrderId property.
        /// </summary>
        [XmlElement(ElementName = "AmazonOrderId")]
        public String AmazonOrderId
        {
            get { return this.amazonOrderIdField ; }
            set { this.amazonOrderIdField= value; }
        }



        /// <summary>
        /// Sets the AmazonOrderId property
        /// </summary>
        /// <param name="amazonOrderId">AmazonOrderId property</param>
        /// <returns>this instance</returns>
        public ListOrderItemsByNextTokenResult WithAmazonOrderId(String amazonOrderId)
        {
            this.amazonOrderIdField = amazonOrderId;
            return this;
        }



        /// <summary>
        /// Checks if AmazonOrderId property is set
        /// </summary>
        /// <returns>true if AmazonOrderId property is set</returns>
        public Boolean IsSetAmazonOrderId()
        {
            return  this.amazonOrderIdField != null;

        }


        /// <summary>
        /// Gets and sets the OrderItems property.
        /// </summary>
        [XmlElement(ElementName = "OrderItems")]
        public OrderItemList OrderItems
        {
            get { return this.orderItemsField ; }
            set { this.orderItemsField = value; }
        }



        /// <summary>
        /// Sets the OrderItems property
        /// </summary>
        /// <param name="orderItems">OrderItems property</param>
        /// <returns>this instance</returns>
        public ListOrderItemsByNextTokenResult WithOrderItems(OrderItemList orderItems)
        {
            this.orderItemsField = orderItems;
            return this;
        }



        /// <summary>
        /// Checks if OrderItems property is set
        /// </summary>
        /// <returns>true if OrderItems property is set</returns>
        public Boolean IsSetOrderItems()
        {
            return this.orderItemsField != null;
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
            if (this.IsSetNextToken()) {
                xml.Append("<NextToken>");
                xml.Append(this.EscapeXML(this.NextToken));
                xml.Append("</NextToken>");
            }
            if (this.IsSetAmazonOrderId()) {
                xml.Append("<AmazonOrderId>");
                xml.Append(this.EscapeXML(this.AmazonOrderId));
                xml.Append("</AmazonOrderId>");
            }
            if (this.IsSetOrderItems()) {
                OrderItemList  orderItemsObj = this.OrderItems;
                xml.Append("<OrderItems>");
                xml.Append(orderItemsObj.ToXMLFragment());
                xml.Append("</OrderItems>");
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