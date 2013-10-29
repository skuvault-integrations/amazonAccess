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
    public class GetServiceStatusResult
    {
    
        private String statusField;

        private DateTime? timestampField;


        /// <summary>
        /// Gets and sets the Status property.
        /// </summary>
        [XmlElement(ElementName = "Status")]
        public String Status
        {
            get { return this.statusField ; }
            set { this.statusField= value; }
        }



        /// <summary>
        /// Sets the Status property
        /// </summary>
        /// <param name="status">Status property</param>
        /// <returns>this instance</returns>
        public GetServiceStatusResult WithStatus(String status)
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
            return  this.statusField != null;

        }


        /// <summary>
        /// Gets and sets the Timestamp property.
        /// </summary>
        [XmlElement(ElementName = "Timestamp")]
        public DateTime Timestamp
        {
            get { return this.timestampField.GetValueOrDefault(DateTime.Now) ; }
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
                xml.Append(this.EscapeXML(this.Status));
                xml.Append("</Status>");
            }
            if (this.IsSetTimestamp()) {
                xml.Append("<Timestamp>");
                xml.Append(this.Timestamp);
                xml.Append("</Timestamp>");
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