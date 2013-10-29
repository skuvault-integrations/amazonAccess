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
    public class ListOrdersRequest
    {
    
        private String sellerIdField;

        private DateTime? createdAfterField;

        private DateTime? createdBeforeField;

        private DateTime? lastUpdatedAfterField;

        private DateTime? lastUpdatedBeforeField;

        private  OrderStatusList orderStatusField;
        private  MarketplaceIdList marketplaceIdField;
        private  FulfillmentChannelList fulfillmentChannelField;
        private  PaymentMethodList paymentMethodField;
        private String buyerEmailField;

        private String sellerOrderIdField;

        private MaxResults maxResultsPerPageField;

        private  TFMShipmentStatusList TFMShipmentStatusField;

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
        public ListOrdersRequest WithSellerId(String sellerId)
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
        /// Gets and sets the CreatedAfter property.
        /// </summary>
        [XmlElement(ElementName = "CreatedAfter")]
        public DateTime CreatedAfter
        {
            get { return this.createdAfterField.GetValueOrDefault() ; }
            set { this.createdAfterField= value; }
        }



        /// <summary>
        /// Sets the CreatedAfter property
        /// </summary>
        /// <param name="createdAfter">CreatedAfter property</param>
        /// <returns>this instance</returns>
        public ListOrdersRequest WithCreatedAfter(DateTime createdAfter)
        {
            this.createdAfterField = createdAfter;
            return this;
        }



        /// <summary>
        /// Checks if CreatedAfter property is set
        /// </summary>
        /// <returns>true if CreatedAfter property is set</returns>
        public Boolean IsSetCreatedAfter()
        {
            return  this.createdAfterField.HasValue;

        }


        /// <summary>
        /// Gets and sets the CreatedBefore property.
        /// </summary>
        [XmlElement(ElementName = "CreatedBefore")]
        public DateTime CreatedBefore
        {
            get { return this.createdBeforeField.GetValueOrDefault() ; }
            set { this.createdBeforeField= value; }
        }



        /// <summary>
        /// Sets the CreatedBefore property
        /// </summary>
        /// <param name="createdBefore">CreatedBefore property</param>
        /// <returns>this instance</returns>
        public ListOrdersRequest WithCreatedBefore(DateTime createdBefore)
        {
            this.createdBeforeField = createdBefore;
            return this;
        }



        /// <summary>
        /// Checks if CreatedBefore property is set
        /// </summary>
        /// <returns>true if CreatedBefore property is set</returns>
        public Boolean IsSetCreatedBefore()
        {
            return  this.createdBeforeField.HasValue;

        }


        /// <summary>
        /// Gets and sets the LastUpdatedAfter property.
        /// </summary>
        [XmlElement(ElementName = "LastUpdatedAfter")]
        public DateTime LastUpdatedAfter
        {
            get { return this.lastUpdatedAfterField.GetValueOrDefault() ; }
            set { this.lastUpdatedAfterField= value; }
        }



        /// <summary>
        /// Sets the LastUpdatedAfter property
        /// </summary>
        /// <param name="lastUpdatedAfter">LastUpdatedAfter property</param>
        /// <returns>this instance</returns>
        public ListOrdersRequest WithLastUpdatedAfter(DateTime lastUpdatedAfter)
        {
            this.lastUpdatedAfterField = lastUpdatedAfter;
            return this;
        }



        /// <summary>
        /// Checks if LastUpdatedAfter property is set
        /// </summary>
        /// <returns>true if LastUpdatedAfter property is set</returns>
        public Boolean IsSetLastUpdatedAfter()
        {
            return  this.lastUpdatedAfterField.HasValue;

        }


        /// <summary>
        /// Gets and sets the LastUpdatedBefore property.
        /// </summary>
        [XmlElement(ElementName = "LastUpdatedBefore")]
        public DateTime LastUpdatedBefore
        {
            get { return this.lastUpdatedBeforeField.GetValueOrDefault() ; }
            set { this.lastUpdatedBeforeField= value; }
        }



        /// <summary>
        /// Sets the LastUpdatedBefore property
        /// </summary>
        /// <param name="lastUpdatedBefore">LastUpdatedBefore property</param>
        /// <returns>this instance</returns>
        public ListOrdersRequest WithLastUpdatedBefore(DateTime lastUpdatedBefore)
        {
            this.lastUpdatedBeforeField = lastUpdatedBefore;
            return this;
        }



        /// <summary>
        /// Checks if LastUpdatedBefore property is set
        /// </summary>
        /// <returns>true if LastUpdatedBefore property is set</returns>
        public Boolean IsSetLastUpdatedBefore()
        {
            return  this.lastUpdatedBeforeField.HasValue;

        }


        /// <summary>
        /// Gets and sets the OrderStatus property.
        /// </summary>
        [XmlElement(ElementName = "OrderStatus")]
        public OrderStatusList OrderStatus
        {
            get { return this.orderStatusField ; }
            set { this.orderStatusField = value; }
        }



        /// <summary>
        /// Sets the OrderStatus property
        /// </summary>
        /// <param name="orderStatus">OrderStatus property</param>
        /// <returns>this instance</returns>
        public ListOrdersRequest WithOrderStatus(OrderStatusList orderStatus)
        {
            this.orderStatusField = orderStatus;
            return this;
        }



        /// <summary>
        /// Checks if OrderStatus property is set
        /// </summary>
        /// <returns>true if OrderStatus property is set</returns>
        public Boolean IsSetOrderStatus()
        {
            return this.orderStatusField != null;
        }




        /// <summary>
        /// Gets and sets the MarketplaceId property.
        /// </summary>
        [XmlElement(ElementName = "MarketplaceId")]
        public MarketplaceIdList MarketplaceId
        {
            get { return this.marketplaceIdField ; }
            set { this.marketplaceIdField = value; }
        }



        /// <summary>
        /// Sets the MarketplaceId property
        /// </summary>
        /// <param name="marketplaceId">MarketplaceId property</param>
        /// <returns>this instance</returns>
        public ListOrdersRequest WithMarketplaceId(MarketplaceIdList marketplaceId)
        {
            this.marketplaceIdField = marketplaceId;
            return this;
        }



        /// <summary>
        /// Checks if MarketplaceId property is set
        /// </summary>
        /// <returns>true if MarketplaceId property is set</returns>
        public Boolean IsSetMarketplaceId()
        {
            return this.marketplaceIdField != null;
        }




        /// <summary>
        /// Gets and sets the FulfillmentChannel property.
        /// </summary>
        [XmlElement(ElementName = "FulfillmentChannel")]
        public FulfillmentChannelList FulfillmentChannel
        {
            get { return this.fulfillmentChannelField ; }
            set { this.fulfillmentChannelField = value; }
        }



        /// <summary>
        /// Sets the FulfillmentChannel property
        /// </summary>
        /// <param name="fulfillmentChannel">FulfillmentChannel property</param>
        /// <returns>this instance</returns>
        public ListOrdersRequest WithFulfillmentChannel(FulfillmentChannelList fulfillmentChannel)
        {
            this.fulfillmentChannelField = fulfillmentChannel;
            return this;
        }



        /// <summary>
        /// Checks if FulfillmentChannel property is set
        /// </summary>
        /// <returns>true if FulfillmentChannel property is set</returns>
        public Boolean IsSetFulfillmentChannel()
        {
            return this.fulfillmentChannelField != null;
        }




        /// <summary>
        /// Gets and sets the PaymentMethod property.
        /// </summary>
        [XmlElement(ElementName = "PaymentMethod")]
        public PaymentMethodList PaymentMethod
        {
            get { return this.paymentMethodField ; }
            set { this.paymentMethodField = value; }
        }



        /// <summary>
        /// Sets the PaymentMethod property
        /// </summary>
        /// <param name="paymentMethod">PaymentMethod property</param>
        /// <returns>this instance</returns>
        public ListOrdersRequest WithPaymentMethod(PaymentMethodList paymentMethod)
        {
            this.paymentMethodField = paymentMethod;
            return this;
        }



        /// <summary>
        /// Checks if PaymentMethod property is set
        /// </summary>
        /// <returns>true if PaymentMethod property is set</returns>
        public Boolean IsSetPaymentMethod()
        {
            return this.paymentMethodField != null;
        }




        /// <summary>
        /// Gets and sets the BuyerEmail property.
        /// </summary>
        [XmlElement(ElementName = "BuyerEmail")]
        public String BuyerEmail
        {
            get { return this.buyerEmailField ; }
            set { this.buyerEmailField= value; }
        }



        /// <summary>
        /// Sets the BuyerEmail property
        /// </summary>
        /// <param name="buyerEmail">BuyerEmail property</param>
        /// <returns>this instance</returns>
        public ListOrdersRequest WithBuyerEmail(String buyerEmail)
        {
            this.buyerEmailField = buyerEmail;
            return this;
        }



        /// <summary>
        /// Checks if BuyerEmail property is set
        /// </summary>
        /// <returns>true if BuyerEmail property is set</returns>
        public Boolean IsSetBuyerEmail()
        {
            return  this.buyerEmailField != null;

        }


        /// <summary>
        /// Gets and sets the SellerOrderId property.
        /// </summary>
        [XmlElement(ElementName = "SellerOrderId")]
        public String SellerOrderId
        {
            get { return this.sellerOrderIdField ; }
            set { this.sellerOrderIdField= value; }
        }



        /// <summary>
        /// Sets the SellerOrderId property
        /// </summary>
        /// <param name="sellerOrderId">SellerOrderId property</param>
        /// <returns>this instance</returns>
        public ListOrdersRequest WithSellerOrderId(String sellerOrderId)
        {
            this.sellerOrderIdField = sellerOrderId;
            return this;
        }



        /// <summary>
        /// Checks if SellerOrderId property is set
        /// </summary>
        /// <returns>true if SellerOrderId property is set</returns>
        public Boolean IsSetSellerOrderId()
        {
            return  this.sellerOrderIdField != null;

        }


        /// <summary>
        /// Gets and sets the MaxResultsPerPage property.
        /// </summary>
        [XmlElement(ElementName = "MaxResultsPerPage")]
        public MaxResults MaxResultsPerPage
        {
            get { return this.maxResultsPerPageField ; }
            set { this.maxResultsPerPageField= value; }
        }



        /// <summary>
        /// Sets the MaxResultsPerPage property
        /// </summary>
        /// <param name="maxResultsPerPage">MaxResultsPerPage property</param>
        /// <returns>this instance</returns>
        public ListOrdersRequest WithMaxResultsPerPage(MaxResults maxResultsPerPage)
        {
            this.maxResultsPerPageField = maxResultsPerPage;
            return this;
        }



        /// <summary>
        /// Checks if MaxResultsPerPage property is set
        /// </summary>
        /// <returns>true if MaxResultsPerPage property is set</returns>
        public Boolean IsSetMaxResultsPerPage()
        {
            return this.maxResultsPerPageField != null;

        }


        /// <summary>
        /// Gets and sets the TFMShipmentStatus property.
        /// </summary>
        [XmlElement(ElementName = "TFMShipmentStatus")]
        public TFMShipmentStatusList TFMShipmentStatus
        {
            get { return this.TFMShipmentStatusField ; }
            set { this.TFMShipmentStatusField = value; }
        }



        /// <summary>
        /// Sets the TFMShipmentStatus property
        /// </summary>
        /// <param name="TFMShipmentStatus">TFMShipmentStatus property</param>
        /// <returns>this instance</returns>
        public ListOrdersRequest WithTFMShipmentStatus(TFMShipmentStatusList TFMShipmentStatus)
        {
            this.TFMShipmentStatusField = TFMShipmentStatus;
            return this;
        }



        /// <summary>
        /// Checks if TFMShipmentStatus property is set
        /// </summary>
        /// <returns>true if TFMShipmentStatus property is set</returns>
        public Boolean IsSetTFMShipmentStatus()
        {
            return this.TFMShipmentStatusField != null;
        }







    }

}