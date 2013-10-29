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
    public class ListOrdersResult
    {
    
        private String nextTokenField;

        private DateTime? createdBeforeField;

        private DateTime? lastUpdatedBeforeField;

        private  OrderList ordersField;

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
        public ListOrdersResult WithNextToken(String nextToken)
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
        /// Gets and sets the CreatedBefore property.
        /// </summary>
        [XmlElement(ElementName = "CreatedBefore")]
        public DateTime CreatedBefore
        {
            get { return this.createdBeforeField.GetValueOrDefault() ; }
            set { this.createdBeforeField= value; }
        }



        /// <summary>
        /// Sets the CreatedBefore property
        /// </summary>
        /// <param name="createdBefore">CreatedBefore property</param>
        /// <returns>this instance</returns>
        public ListOrdersResult WithCreatedBefore(DateTime createdBefore)
        {
            this.createdBeforeField = createdBefore;
            return this;
        }



        /// <summary>
        /// Checks if CreatedBefore property is set
        /// </summary>
        /// <returns>true if CreatedBefore property is set</returns>
        public Boolean IsSetCreatedBefore()
        {
            return  this.createdBeforeField.HasValue;

        }


        /// <summary>
        /// Gets and sets the LastUpdatedBefore property.
        /// </summary>
        [XmlElement(ElementName = "LastUpdatedBefore")]
        public DateTime LastUpdatedBefore
        {
            get { return this.lastUpdatedBeforeField.GetValueOrDefault() ; }
            set { this.lastUpdatedBeforeField= value; }
        }



        /// <summary>
        /// Sets the LastUpdatedBefore property
        /// </summary>
        /// <param name="lastUpdatedBefore">LastUpdatedBefore property</param>
        /// <returns>this instance</returns>
        public ListOrdersResult WithLastUpdatedBefore(DateTime lastUpdatedBefore)
        {
            this.lastUpdatedBeforeField = lastUpdatedBefore;
            return this;
        }



        /// <summary>
        /// Checks if LastUpdatedBefore property is set
        /// </summary>
        /// <returns>true if LastUpdatedBefore property is set</returns>
        public Boolean IsSetLastUpdatedBefore()
        {
            return  this.lastUpdatedBeforeField.HasValue;

        }


        /// <summary>
        /// Gets and sets the Orders property.
        /// </summary>
        [XmlElement(ElementName = "Orders")]
        public OrderList Orders
        {
            get { return this.ordersField ; }
            set { this.ordersField = value; }
        }



        /// <summary>
        /// Sets the Orders property
        /// </summary>
        /// <param name="orders">Orders property</param>
        /// <returns>this instance</returns>
        public ListOrdersResult WithOrders(OrderList orders)
        {
            this.ordersField = orders;
            return this;
        }



        /// <summary>
        /// Checks if Orders property is set
        /// </summary>
        /// <returns>true if Orders property is set</returns>
        public Boolean IsSetOrders()
        {
            return this.ordersField != null;
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
            if (this.IsSetCreatedBefore()) {
                xml.Append("<CreatedBefore>");
                xml.Append(this.CreatedBefore);
                xml.Append("</CreatedBefore>");
            }
            if (this.IsSetLastUpdatedBefore()) {
                xml.Append("<LastUpdatedBefore>");
                xml.Append(this.LastUpdatedBefore);
                xml.Append("</LastUpdatedBefore>");
            }
            if (this.IsSetOrders()) {
                OrderList  ordersObj = this.Orders;
                xml.Append("<Orders>");
                xml.Append(ordersObj.ToXMLFragment());
                xml.Append("</Orders>");
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