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
    public class InventorySupplyDetail
    {
    
        private Decimal? quantityField;

        private String supplyTypeField;

        private  Timepoint earliestAvailableToPickField;
        private  Timepoint latestAvailableToPickField;

        /// <summary>
        /// Gets and sets the Quantity property.
        /// </summary>
        [XmlElement(ElementName = "Quantity")]
        public Decimal Quantity
        {
            get { return this.quantityField.GetValueOrDefault() ; }
            set { this.quantityField= value; }
        }



        /// <summary>
        /// Sets the Quantity property
        /// </summary>
        /// <param name="quantity">Quantity property</param>
        /// <returns>this instance</returns>
        public InventorySupplyDetail WithQuantity(Decimal quantity)
        {
            this.quantityField = quantity;
            return this;
        }



        /// <summary>
        /// Checks if Quantity property is set
        /// </summary>
        /// <returns>true if Quantity property is set</returns>
        public Boolean IsSetQuantity()
        {
            return  this.quantityField.HasValue;

        }


        /// <summary>
        /// Gets and sets the SupplyType property.
        /// </summary>
        [XmlElement(ElementName = "SupplyType")]
        public String SupplyType
        {
            get { return this.supplyTypeField ; }
            set { this.supplyTypeField= value; }
        }



        /// <summary>
        /// Sets the SupplyType property
        /// </summary>
        /// <param name="supplyType">SupplyType property</param>
        /// <returns>this instance</returns>
        public InventorySupplyDetail WithSupplyType(String supplyType)
        {
            this.supplyTypeField = supplyType;
            return this;
        }



        /// <summary>
        /// Checks if SupplyType property is set
        /// </summary>
        /// <returns>true if SupplyType property is set</returns>
        public Boolean IsSetSupplyType()
        {
            return  this.supplyTypeField != null;

        }


        /// <summary>
        /// Gets and sets the EarliestAvailableToPick property.
        /// </summary>
        [XmlElement(ElementName = "EarliestAvailableToPick")]
        public Timepoint EarliestAvailableToPick
        {
            get { return this.earliestAvailableToPickField ; }
            set { this.earliestAvailableToPickField = value; }
        }



        /// <summary>
        /// Sets the EarliestAvailableToPick property
        /// </summary>
        /// <param name="earliestAvailableToPick">EarliestAvailableToPick property</param>
        /// <returns>this instance</returns>
        public InventorySupplyDetail WithEarliestAvailableToPick(Timepoint earliestAvailableToPick)
        {
            this.earliestAvailableToPickField = earliestAvailableToPick;
            return this;
        }



        /// <summary>
        /// Checks if EarliestAvailableToPick property is set
        /// </summary>
        /// <returns>true if EarliestAvailableToPick property is set</returns>
        public Boolean IsSetEarliestAvailableToPick()
        {
            return this.earliestAvailableToPickField != null;
        }




        /// <summary>
        /// Gets and sets the LatestAvailableToPick property.
        /// </summary>
        [XmlElement(ElementName = "LatestAvailableToPick")]
        public Timepoint LatestAvailableToPick
        {
            get { return this.latestAvailableToPickField ; }
            set { this.latestAvailableToPickField = value; }
        }



        /// <summary>
        /// Sets the LatestAvailableToPick property
        /// </summary>
        /// <param name="latestAvailableToPick">LatestAvailableToPick property</param>
        /// <returns>this instance</returns>
        public InventorySupplyDetail WithLatestAvailableToPick(Timepoint latestAvailableToPick)
        {
            this.latestAvailableToPickField = latestAvailableToPick;
            return this;
        }



        /// <summary>
        /// Checks if LatestAvailableToPick property is set
        /// </summary>
        /// <returns>true if LatestAvailableToPick property is set</returns>
        public Boolean IsSetLatestAvailableToPick()
        {
            return this.latestAvailableToPickField != null;
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
            if (this.IsSetQuantity()) {
                xml.Append("<Quantity>");
                xml.Append(this.Quantity);
                xml.Append("</Quantity>");
            }
            if (this.IsSetSupplyType()) {
                xml.Append("<SupplyType>");
                xml.Append(this.EscapeXML(this.SupplyType));
                xml.Append("</SupplyType>");
            }
            if (this.IsSetEarliestAvailableToPick()) {
                Timepoint  earliestAvailableToPickObj = this.EarliestAvailableToPick;
                xml.Append("<EarliestAvailableToPick>");
                xml.Append(earliestAvailableToPickObj.ToXMLFragment());
                xml.Append("</EarliestAvailableToPick>");
            } 
            if (this.IsSetLatestAvailableToPick()) {
                Timepoint  latestAvailableToPickObj = this.LatestAvailableToPick;
                xml.Append("<LatestAvailableToPick>");
                xml.Append(latestAvailableToPickObj.ToXMLFragment());
                xml.Append("</LatestAvailableToPick>");
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