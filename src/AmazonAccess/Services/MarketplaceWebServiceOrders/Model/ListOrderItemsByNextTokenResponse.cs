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
    public class ListOrderItemsByNextTokenResponse
    {
    
        private  ListOrderItemsByNextTokenResult listOrderItemsByNextTokenResultField;
        private  ResponseMetadata responseMetadataField;

        /// <summary>
        /// Gets and sets the ListOrderItemsByNextTokenResult property.
        /// </summary>
        [XmlElement(ElementName = "ListOrderItemsByNextTokenResult")]
        public ListOrderItemsByNextTokenResult ListOrderItemsByNextTokenResult
        {
            get { return this.listOrderItemsByNextTokenResultField ; }
            set { this.listOrderItemsByNextTokenResultField = value; }
        }



        /// <summary>
        /// Sets the ListOrderItemsByNextTokenResult property
        /// </summary>
        /// <param name="listOrderItemsByNextTokenResult">ListOrderItemsByNextTokenResult property</param>
        /// <returns>this instance</returns>
        public ListOrderItemsByNextTokenResponse WithListOrderItemsByNextTokenResult(ListOrderItemsByNextTokenResult listOrderItemsByNextTokenResult)
        {
            this.listOrderItemsByNextTokenResultField = listOrderItemsByNextTokenResult;
            return this;
        }



        /// <summary>
        /// Checks if ListOrderItemsByNextTokenResult property is set
        /// </summary>
        /// <returns>true if ListOrderItemsByNextTokenResult property is set</returns>
        public Boolean IsSetListOrderItemsByNextTokenResult()
        {
            return this.listOrderItemsByNextTokenResultField != null;
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
        public ListOrderItemsByNextTokenResponse WithResponseMetadata(ResponseMetadata responseMetadata)
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
            xml.Append("<ListOrderItemsByNextTokenResponse xmlns=\"https://mws.amazonservices.com/Orders/2011-01-01\">");
            if (this.IsSetListOrderItemsByNextTokenResult()) {
                ListOrderItemsByNextTokenResult  listOrderItemsByNextTokenResult = this.ListOrderItemsByNextTokenResult;
                xml.Append("<ListOrderItemsByNextTokenResult>");
                xml.Append(listOrderItemsByNextTokenResult.ToXMLFragment());
                xml.Append("</ListOrderItemsByNextTokenResult>");
            } 
            if (this.IsSetResponseMetadata()) {
                ResponseMetadata  responseMetadata = this.ResponseMetadata;
                xml.Append("<ResponseMetadata>");
                xml.Append(responseMetadata.ToXMLFragment());
                xml.Append("</ResponseMetadata>");
            } 
            xml.Append("</ListOrderItemsByNextTokenResponse>");
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

        private ResponseHeaderMetadata responseHeaderMetadata;
                public ResponseHeaderMetadata ResponseHeaderMetadata
        {
            get { return this.responseHeaderMetadata; }
            set { this.responseHeaderMetadata = value; }
        }



    }

}