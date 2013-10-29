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
    public class ListInventorySupplyByNextTokenResponse
    {
    
        private  ListInventorySupplyByNextTokenResult listInventorySupplyByNextTokenResultField;
        private  ResponseMetadata responseMetadataField;

        /// <summary>
        /// Gets and sets the ListInventorySupplyByNextTokenResult property.
        /// </summary>
        [XmlElement(ElementName = "ListInventorySupplyByNextTokenResult")]
        public ListInventorySupplyByNextTokenResult ListInventorySupplyByNextTokenResult
        {
            get { return this.listInventorySupplyByNextTokenResultField ; }
            set { this.listInventorySupplyByNextTokenResultField = value; }
        }



        /// <summary>
        /// Sets the ListInventorySupplyByNextTokenResult property
        /// </summary>
        /// <param name="listInventorySupplyByNextTokenResult">ListInventorySupplyByNextTokenResult property</param>
        /// <returns>this instance</returns>
        public ListInventorySupplyByNextTokenResponse WithListInventorySupplyByNextTokenResult(ListInventorySupplyByNextTokenResult listInventorySupplyByNextTokenResult)
        {
            this.listInventorySupplyByNextTokenResultField = listInventorySupplyByNextTokenResult;
            return this;
        }



        /// <summary>
        /// Checks if ListInventorySupplyByNextTokenResult property is set
        /// </summary>
        /// <returns>true if ListInventorySupplyByNextTokenResult property is set</returns>
        public Boolean IsSetListInventorySupplyByNextTokenResult()
        {
            return this.listInventorySupplyByNextTokenResultField != null;
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
        public ListInventorySupplyByNextTokenResponse WithResponseMetadata(ResponseMetadata responseMetadata)
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
            xml.Append("<ListInventorySupplyByNextTokenResponse xmlns=\"http://mws.amazonaws.com/FulfillmentInventory/2010-10-01/\">");
            if (this.IsSetListInventorySupplyByNextTokenResult()) {
                ListInventorySupplyByNextTokenResult  listInventorySupplyByNextTokenResult = this.ListInventorySupplyByNextTokenResult;
                xml.Append("<ListInventorySupplyByNextTokenResult>");
                xml.Append(listInventorySupplyByNextTokenResult.ToXMLFragment());
                xml.Append("</ListInventorySupplyByNextTokenResult>");
            } 
            if (this.IsSetResponseMetadata()) {
                ResponseMetadata  responseMetadata = this.ResponseMetadata;
                xml.Append("<ResponseMetadata>");
                xml.Append(responseMetadata.ToXMLFragment());
                xml.Append("</ResponseMetadata>");
            } 
            xml.Append("</ListInventorySupplyByNextTokenResponse>");
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