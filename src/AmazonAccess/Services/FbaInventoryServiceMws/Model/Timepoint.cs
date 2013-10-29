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
    public class Timepoint
    {
    
        private String timepointTypeField;

        private DateTime? dateTimeField;


        /// <summary>
        /// Gets and sets the TimepointType property.
        /// </summary>
        [XmlElement(ElementName = "TimepointType")]
        public String TimepointType
        {
            get { return this.timepointTypeField ; }
            set { this.timepointTypeField= value; }
        }



        /// <summary>
        /// Sets the TimepointType property
        /// </summary>
        /// <param name="timepointType">TimepointType property</param>
        /// <returns>this instance</returns>
        public Timepoint WithTimepointType(String timepointType)
        {
            this.timepointTypeField = timepointType;
            return this;
        }



        /// <summary>
        /// Checks if TimepointType property is set
        /// </summary>
        /// <returns>true if TimepointType property is set</returns>
        public Boolean IsSetTimepointType()
        {
            return  this.timepointTypeField != null;

        }


        /// <summary>
        /// Gets and sets the DateTime property.
        /// </summary>
        [XmlElement(ElementName = "DateTime")]
        public DateTime DateTime
        {
            get { return this.dateTimeField.GetValueOrDefault() ; }
            set { this.dateTimeField= value; }
        }



        /// <summary>
        /// Sets the DateTime property
        /// </summary>
        /// <param name="dateTime">DateTime property</param>
        /// <returns>this instance</returns>
        public Timepoint WithDateTime(DateTime dateTime)
        {
            this.dateTimeField = dateTime;
            return this;
        }



        /// <summary>
        /// Checks if DateTime property is set
        /// </summary>
        /// <returns>true if DateTime property is set</returns>
        public Boolean IsSetDateTime()
        {
            return  this.dateTimeField.HasValue;

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
            if (this.IsSetTimepointType()) {
                xml.Append("<TimepointType>");
                xml.Append(this.EscapeXML(this.TimepointType));
                xml.Append("</TimepointType>");
            }
            if (this.IsSetDateTime()) {
                xml.Append("<DateTime>");
                xml.Append(this.DateTime);
                xml.Append("</DateTime>");
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