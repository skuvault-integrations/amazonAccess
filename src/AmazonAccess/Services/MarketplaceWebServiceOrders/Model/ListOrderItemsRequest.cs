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

namespace AmazonAccess.Services.MarketplaceWebServiceOrders.Model
{
    [XmlType(Namespace = "https://mws.amazonservices.com/Orders/2011-01-01")]
    [XmlRoot(Namespace = "https://mws.amazonservices.com/Orders/2011-01-01", IsNullable = false)]
    public class ListOrderItemsRequest
    {
    
        private String sellerIdField;

        private String amazonOrderIdField;


        /// <summary>
        /// Gets and sets the SellerId property.
        /// </summary>
        [XmlElement(ElementName = "SellerId")]
        public String SellerId
        {
            get { return this.sellerIdField ; }
            set { this.sellerIdField= value; }
        }



        /// <summary>
        /// Sets the SellerId property
        /// </summary>
        /// <param name="sellerId">SellerId property</param>
        /// <returns>this instance</returns>
        public ListOrderItemsRequest WithSellerId(String sellerId)
        {
            this.sellerIdField = sellerId;
            return this;
        }



        /// <summary>
        /// Checks if SellerId property is set
        /// </summary>
        /// <returns>true if SellerId property is set</returns>
        public Boolean IsSetSellerId()
        {
            return  this.sellerIdField != null;

        }


        /// <summary>
        /// Gets and sets the AmazonOrderId property.
        /// </summary>
        [XmlElement(ElementName = "AmazonOrderId")]
        public String AmazonOrderId
        {
            get { return this.amazonOrderIdField ; }
            set { this.amazonOrderIdField= value; }
        }



        /// <summary>
        /// Sets the AmazonOrderId property
        /// </summary>
        /// <param name="amazonOrderId">AmazonOrderId property</param>
        /// <returns>this instance</returns>
        public ListOrderItemsRequest WithAmazonOrderId(String amazonOrderId)
        {
            this.amazonOrderIdField = amazonOrderId;
            return this;
        }



        /// <summary>
        /// Checks if AmazonOrderId property is set
        /// </summary>
        /// <returns>true if AmazonOrderId property is set</returns>
        public Boolean IsSetAmazonOrderId()
        {
            return  this.amazonOrderIdField != null;

        }





    }

}