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
    public class ListInventorySupplyResponse
    {
    
        private  ListInventorySupplyResult listInventorySupplyResultField;
        private  ResponseMetadata responseMetadataField;

        /// <summary>
        /// Gets and sets the ListInventorySupplyResult property.
        /// </summary>
        [XmlElement(ElementName = "ListInventorySupplyResult")]
        public ListInventorySupplyResult ListInventorySupplyResult
        {
            get { return this.listInventorySupplyResultField ; }
            set { this.listInventorySupplyResultField = value; }
        }



        /// <summary>
        /// Sets the ListInventorySupplyResult property
        /// </summary>
        /// <param name="listInventorySupplyResult">ListInventorySupplyResult property</param>
        /// <returns>this instance</returns>
        public ListInventorySupplyResponse WithListInventorySupplyResult(ListInventorySupplyResult listInventorySupplyResult)
        {
            this.listInventorySupplyResultField = listInventorySupplyResult;
            return this;
        }



        /// <summary>
        /// Checks if ListInventorySupplyResult property is set
        /// </summary>
        /// <returns>true if ListInventorySupplyResult property is set</returns>
        public Boolean IsSetListInventorySupplyResult()
        {
            return this.listInventorySupplyResultField != null;
        }




        /// <summary>
        /// Gets and sets the ResponseMetadata property.
        /// </summary>
        [XmlElement(ElementName = "ResponseMetadata")]
        public ResponseMetadata ResponseMetadata
        {
            get { return this.responseMetadataField ; }
            set { this.responseMetadataField = value; }
        }



        /// <summary>
        /// Sets the ResponseMetadata property
        /// </summary>
        /// <param name="responseMetadata">ResponseMetadata property</param>
        /// <returns>this instance</returns>
        public ListInventorySupplyResponse WithResponseMetadata(ResponseMetadata responseMetadata)
        {
            this.responseMetadataField = responseMetadata;
            return this;
        }



        /// <summary>
        /// Checks if ResponseMetadata property is set
        /// </summary>
        /// <returns>true if ResponseMetadata property is set</returns>
        public Boolean IsSetResponseMetadata()
        {
            return this.responseMetadataField != null;
        }






        /// <summary>
        /// XML Representation for this object
        /// </summary>
        /// <returns>XML String</returns>

        public String ToXML() {
            StringBuilder xml = new StringBuilder();
            xml.Append("<ListInventorySupplyResponse xmlns=\"http://mws.amazonaws.com/FulfillmentInventory/2010-10-01/\">");
            if (this.IsSetListInventorySupplyResult()) {
                ListInventorySupplyResult  listInventorySupplyResult = this.ListInventorySupplyResult;
                xml.Append("<ListInventorySupplyResult>");
                xml.Append(listInventorySupplyResult.ToXMLFragment());
                xml.Append("</ListInventorySupplyResult>");
            } 
            if (this.IsSetResponseMetadata()) {
                ResponseMetadata  responseMetadata = this.ResponseMetadata;
                xml.Append("<ResponseMetadata>");
                xml.Append(responseMetadata.ToXMLFragment());
                xml.Append("</ResponseMetadata>");
            } 
            xml.Append("</ListInventorySupplyResponse>");
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