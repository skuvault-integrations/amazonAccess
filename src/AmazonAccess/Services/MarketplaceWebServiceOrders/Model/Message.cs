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
    public class Message
    {
    
        private String localeField;

        private String textField;


        /// <summary>
        /// Gets and sets the Locale property.
        /// </summary>
        [XmlElement(ElementName = "Locale")]
        public String Locale
        {
            get { return this.localeField ; }
            set { this.localeField= value; }
        }



        /// <summary>
        /// Sets the Locale property
        /// </summary>
        /// <param name="locale">Locale property</param>
        /// <returns>this instance</returns>
        public Message WithLocale(String locale)
        {
            this.localeField = locale;
            return this;
        }



        /// <summary>
        /// Checks if Locale property is set
        /// </summary>
        /// <returns>true if Locale property is set</returns>
        public Boolean IsSetLocale()
        {
            return  this.localeField != null;

        }


        /// <summary>
        /// Gets and sets the Text property.
        /// </summary>
        [XmlElement(ElementName = "Text")]
        public String Text
        {
            get { return this.textField ; }
            set { this.textField= value; }
        }



        /// <summary>
        /// Sets the Text property
        /// </summary>
        /// <param name="text">Text property</param>
        /// <returns>this instance</returns>
        public Message WithText(String text)
        {
            this.textField = text;
            return this;
        }



        /// <summary>
        /// Checks if Text property is set
        /// </summary>
        /// <returns>true if Text property is set</returns>
        public Boolean IsSetText()
        {
            return  this.textField != null;

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
            if (this.IsSetLocale()) {
                xml.Append("<Locale>");
                xml.Append(this.EscapeXML(this.Locale));
                xml.Append("</Locale>");
            }
            if (this.IsSetText()) {
                xml.Append("<Text>");
                xml.Append(this.EscapeXML(this.Text));
                xml.Append("</Text>");
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