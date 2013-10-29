/******************************************************************************* 
 *  Copyright 2009 Amazon Services. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"); 
 *  
 *  You may not use this file except in compliance with the License. 
 *  You may obtain a copy of the License at: http://aws.amazon.com/apache2.0
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the 
 *  specific language governing permissions and limitations under the License.
 * ***************************************************************************** 
 * 
 *  FBA Inventory Service MWS CSharp Library
 *  API Version: 2010-10-01
 *  Generated: Fri Oct 22 09:53:30 UTC 2010 
 * 
 */

using System;
using System.Xml.Serialization;
using System.Text;

namespace AmazonAccess.Services.FbaInventoryServiceMws.Model
{
    [XmlType(Namespace = "http://mws.amazonaws.com/FulfillmentInventory/2010-10-01/")]
    [XmlRoot(Namespace = "http://mws.amazonaws.com/FulfillmentInventory/2010-10-01/", IsNullable = false)]
    public class ListInventorySupplyByNextTokenResult
    {
    
        private  InventorySupplyList inventorySupplyListField;
        private String nextTokenField;


        /// <summary>
        /// Gets and sets the InventorySupplyList property.
        /// </summary>
        [XmlElement(ElementName = "InventorySupplyList")]
        public InventorySupplyList InventorySupplyList
        {
            get { return this.inventorySupplyListField ; }
            set { this.inventorySupplyListField = value; }
        }



        /// <summary>
        /// Sets the InventorySupplyList property
        /// </summary>
        /// <param name="inventorySupplyList">InventorySupplyList property</param>
        /// <returns>this instance</returns>
        public ListInventorySupplyByNextTokenResult WithInventorySupplyList(InventorySupplyList inventorySupplyList)
        {
            this.inventorySupplyListField = inventorySupplyList;
            return this;
        }



        /// <summary>
        /// Checks if InventorySupplyList property is set
        /// </summary>
        /// <returns>true if InventorySupplyList property is set</returns>
        public Boolean IsSetInventorySupplyList()
        {
            return this.inventorySupplyListField != null;
        }




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
        public ListInventorySupplyByNextTokenResult WithNextToken(String nextToken)
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
        /// XML fragment representation of this object
        /// </summary>
        /// <returns>XML fragment for this object.</returns>
        /// <remarks>
        /// Name for outer tag expected to be set by calling method. 
        /// This fragment returns inner properties representation only
        /// </remarks>


        protected internal String ToXMLFragment() {
            StringBuilder xml = new StringBuilder();
            if (this.IsSetInventorySupplyList()) {
                InventorySupplyList  inventorySupplyListObj = this.InventorySupplyList;
                xml.Append("<InventorySupplyList>");
                xml.Append(inventorySupplyListObj.ToXMLFragment());
                xml.Append("</InventorySupplyList>");
            } 
            if (this.IsSetNextToken()) {
                xml.Append("<NextToken>");
                xml.Append(this.EscapeXML(this.NextToken));
                xml.Append("</NextToken>");
            }
            return xml.ToString();
        }

        /**
         * 
         * Escape XML special characters
         */
        private String EscapeXML(String str) {
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