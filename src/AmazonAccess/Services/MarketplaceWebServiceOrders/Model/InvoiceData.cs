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
    public class InvoiceData
    {
    
        private String invoiceRequirementField;

        private String buyerSelectedInvoiceCategoryField;

        private String invoiceTitleField;

        private String invoiceInformationField;


        /// <summary>
        /// Gets and sets the InvoiceRequirement property.
        /// </summary>
        [XmlElement(ElementName = "InvoiceRequirement")]
        public String InvoiceRequirement
        {
            get { return this.invoiceRequirementField ; }
            set { this.invoiceRequirementField= value; }
        }



        /// <summary>
        /// Sets the InvoiceRequirement property
        /// </summary>
        /// <param name="invoiceRequirement">InvoiceRequirement property</param>
        /// <returns>this instance</returns>
        public InvoiceData WithInvoiceRequirement(String invoiceRequirement)
        {
            this.invoiceRequirementField = invoiceRequirement;
            return this;
        }



        /// <summary>
        /// Checks if InvoiceRequirement property is set
        /// </summary>
        /// <returns>true if InvoiceRequirement property is set</returns>
        public Boolean IsSetInvoiceRequirement()
        {
            return  this.invoiceRequirementField != null;

        }


        /// <summary>
        /// Gets and sets the BuyerSelectedInvoiceCategory property.
        /// </summary>
        [XmlElement(ElementName = "BuyerSelectedInvoiceCategory")]
        public String BuyerSelectedInvoiceCategory
        {
            get { return this.buyerSelectedInvoiceCategoryField ; }
            set { this.buyerSelectedInvoiceCategoryField= value; }
        }



        /// <summary>
        /// Sets the BuyerSelectedInvoiceCategory property
        /// </summary>
        /// <param name="buyerSelectedInvoiceCategory">BuyerSelectedInvoiceCategory property</param>
        /// <returns>this instance</returns>
        public InvoiceData WithBuyerSelectedInvoiceCategory(String buyerSelectedInvoiceCategory)
        {
            this.buyerSelectedInvoiceCategoryField = buyerSelectedInvoiceCategory;
            return this;
        }



        /// <summary>
        /// Checks if BuyerSelectedInvoiceCategory property is set
        /// </summary>
        /// <returns>true if BuyerSelectedInvoiceCategory property is set</returns>
        public Boolean IsSetBuyerSelectedInvoiceCategory()
        {
            return  this.buyerSelectedInvoiceCategoryField != null;

        }


        /// <summary>
        /// Gets and sets the InvoiceTitle property.
        /// </summary>
        [XmlElement(ElementName = "InvoiceTitle")]
        public String InvoiceTitle
        {
            get { return this.invoiceTitleField ; }
            set { this.invoiceTitleField= value; }
        }



        /// <summary>
        /// Sets the InvoiceTitle property
        /// </summary>
        /// <param name="invoiceTitle">InvoiceTitle property</param>
        /// <returns>this instance</returns>
        public InvoiceData WithInvoiceTitle(String invoiceTitle)
        {
            this.invoiceTitleField = invoiceTitle;
            return this;
        }



        /// <summary>
        /// Checks if InvoiceTitle property is set
        /// </summary>
        /// <returns>true if InvoiceTitle property is set</returns>
        public Boolean IsSetInvoiceTitle()
        {
            return  this.invoiceTitleField != null;

        }


        /// <summary>
        /// Gets and sets the InvoiceInformation property.
        /// </summary>
        [XmlElement(ElementName = "InvoiceInformation")]
        public String InvoiceInformation
        {
            get { return this.invoiceInformationField ; }
            set { this.invoiceInformationField= value; }
        }



        /// <summary>
        /// Sets the InvoiceInformation property
        /// </summary>
        /// <param name="invoiceInformation">InvoiceInformation property</param>
        /// <returns>this instance</returns>
        public InvoiceData WithInvoiceInformation(String invoiceInformation)
        {
            this.invoiceInformationField = invoiceInformation;
            return this;
        }



        /// <summary>
        /// Checks if InvoiceInformation property is set
        /// </summary>
        /// <returns>true if InvoiceInformation property is set</returns>
        public Boolean IsSetInvoiceInformation()
        {
            return  this.invoiceInformationField != null;

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
            if (this.IsSetInvoiceRequirement()) {
                xml.Append("<InvoiceRequirement>");
                xml.Append(this.EscapeXML(this.InvoiceRequirement));
                xml.Append("</InvoiceRequirement>");
            }
            if (this.IsSetBuyerSelectedInvoiceCategory()) {
                xml.Append("<BuyerSelectedInvoiceCategory>");
                xml.Append(this.EscapeXML(this.BuyerSelectedInvoiceCategory));
                xml.Append("</BuyerSelectedInvoiceCategory>");
            }
            if (this.IsSetInvoiceTitle()) {
                xml.Append("<InvoiceTitle>");
                xml.Append(this.EscapeXML(this.InvoiceTitle));
                xml.Append("</InvoiceTitle>");
            }
            if (this.IsSetInvoiceInformation()) {
                xml.Append("<InvoiceInformation>");
                xml.Append(this.EscapeXML(this.InvoiceInformation));
                xml.Append("</InvoiceInformation>");
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