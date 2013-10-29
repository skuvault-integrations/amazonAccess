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
    public class Order
    {
    
        private String amazonOrderIdField;

        private String sellerOrderIdField;

        private DateTime? purchaseDateField;

        private DateTime? lastUpdateDateField;

        private OrderStatusEnum? orderStatusField;

        private FulfillmentChannelEnum? fulfillmentChannelField;

        private String salesChannelField;

        private String orderChannelField;

        private String shipServiceLevelField;

        private  Address shippingAddressField;
        private  Money orderTotalField;
        private Decimal? numberOfItemsShippedField;

        private Decimal? numberOfItemsUnshippedField;

        private  PaymentExecutionDetailItemList paymentExecutionDetailField;
        private PaymentMethodEnum? paymentMethodField;

        private String marketplaceIdField;

        private String buyerEmailField;

        private String buyerNameField;

        private String shipmentServiceLevelCategoryField;

        private Boolean? shippedByAmazonTFMField;

        private String TFMShipmentStatusField;
        
        private String cbaDisplayableShippingLabelField;
        
        private String orderTypeField;
        
        private DateTime? earliestShipDateField;
        
        private DateTime? latestShipDateField;


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
        public Order WithAmazonOrderId(String amazonOrderId)
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
        public Order WithSellerOrderId(String sellerOrderId)
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
        /// Gets and sets the PurchaseDate property.
        /// </summary>
        [XmlElement(ElementName = "PurchaseDate")]
        public DateTime PurchaseDate
        {
            get { return this.purchaseDateField.GetValueOrDefault() ; }
            set { this.purchaseDateField= value; }
        }



        /// <summary>
        /// Sets the PurchaseDate property
        /// </summary>
        /// <param name="purchaseDate">PurchaseDate property</param>
        /// <returns>this instance</returns>
        public Order WithPurchaseDate(DateTime purchaseDate)
        {
            this.purchaseDateField = purchaseDate;
            return this;
        }



        /// <summary>
        /// Checks if PurchaseDate property is set
        /// </summary>
        /// <returns>true if PurchaseDate property is set</returns>
        public Boolean IsSetPurchaseDate()
        {
            return  this.purchaseDateField.HasValue;

        }


        /// <summary>
        /// Gets and sets the LastUpdateDate property.
        /// </summary>
        [XmlElement(ElementName = "LastUpdateDate")]
        public DateTime LastUpdateDate
        {
            get { return this.lastUpdateDateField.GetValueOrDefault() ; }
            set { this.lastUpdateDateField= value; }
        }



        /// <summary>
        /// Sets the LastUpdateDate property
        /// </summary>
        /// <param name="lastUpdateDate">LastUpdateDate property</param>
        /// <returns>this instance</returns>
        public Order WithLastUpdateDate(DateTime lastUpdateDate)
        {
            this.lastUpdateDateField = lastUpdateDate;
            return this;
        }



        /// <summary>
        /// Checks if LastUpdateDate property is set
        /// </summary>
        /// <returns>true if LastUpdateDate property is set</returns>
        public Boolean IsSetLastUpdateDate()
        {
            return  this.lastUpdateDateField.HasValue;

        }


        /// <summary>
        /// Gets and sets the OrderStatus property.
        /// </summary>
        [XmlElement(ElementName = "OrderStatus")]
        public OrderStatusEnum OrderStatus
        {
            get { return this.orderStatusField.GetValueOrDefault() ; }
            set { this.orderStatusField= value; }
        }



        /// <summary>
        /// Sets the OrderStatus property
        /// </summary>
        /// <param name="orderStatus">OrderStatus property</param>
        /// <returns>this instance</returns>
        public Order WithOrderStatus(OrderStatusEnum orderStatus)
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
            return this.orderStatusField.HasValue;

        }


        /// <summary>
        /// Gets and sets the FulfillmentChannel property.
        /// </summary>
        [XmlElement(ElementName = "FulfillmentChannel")]
        public FulfillmentChannelEnum FulfillmentChannel
        {
            get { return this.fulfillmentChannelField.GetValueOrDefault() ; }
            set { this.fulfillmentChannelField= value; }
        }



        /// <summary>
        /// Sets the FulfillmentChannel property
        /// </summary>
        /// <param name="fulfillmentChannel">FulfillmentChannel property</param>
        /// <returns>this instance</returns>
        public Order WithFulfillmentChannel(FulfillmentChannelEnum fulfillmentChannel)
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
            return this.fulfillmentChannelField.HasValue;

        }


        /// <summary>
        /// Gets and sets the SalesChannel property.
        /// </summary>
        [XmlElement(ElementName = "SalesChannel")]
        public String SalesChannel
        {
            get { return this.salesChannelField ; }
            set { this.salesChannelField= value; }
        }



        /// <summary>
        /// Sets the SalesChannel property
        /// </summary>
        /// <param name="salesChannel">SalesChannel property</param>
        /// <returns>this instance</returns>
        public Order WithSalesChannel(String salesChannel)
        {
            this.salesChannelField = salesChannel;
            return this;
        }



        /// <summary>
        /// Checks if SalesChannel property is set
        /// </summary>
        /// <returns>true if SalesChannel property is set</returns>
        public Boolean IsSetSalesChannel()
        {
            return  this.salesChannelField != null;

        }


        /// <summary>
        /// Gets and sets the OrderChannel property.
        /// </summary>
        [XmlElement(ElementName = "OrderChannel")]
        public String OrderChannel
        {
            get { return this.orderChannelField ; }
            set { this.orderChannelField= value; }
        }



        /// <summary>
        /// Sets the OrderChannel property
        /// </summary>
        /// <param name="orderChannel">OrderChannel property</param>
        /// <returns>this instance</returns>
        public Order WithOrderChannel(String orderChannel)
        {
            this.orderChannelField = orderChannel;
            return this;
        }



        /// <summary>
        /// Checks if OrderChannel property is set
        /// </summary>
        /// <returns>true if OrderChannel property is set</returns>
        public Boolean IsSetOrderChannel()
        {
            return  this.orderChannelField != null;

        }


        /// <summary>
        /// Gets and sets the ShipServiceLevel property.
        /// </summary>
        [XmlElement(ElementName = "ShipServiceLevel")]
        public String ShipServiceLevel
        {
            get { return this.shipServiceLevelField ; }
            set { this.shipServiceLevelField= value; }
        }



        /// <summary>
        /// Sets the ShipServiceLevel property
        /// </summary>
        /// <param name="shipServiceLevel">ShipServiceLevel property</param>
        /// <returns>this instance</returns>
        public Order WithShipServiceLevel(String shipServiceLevel)
        {
            this.shipServiceLevelField = shipServiceLevel;
            return this;
        }



        /// <summary>
        /// Checks if ShipServiceLevel property is set
        /// </summary>
        /// <returns>true if ShipServiceLevel property is set</returns>
        public Boolean IsSetShipServiceLevel()
        {
            return  this.shipServiceLevelField != null;

        }


        /// <summary>
        /// Gets and sets the ShippingAddress property.
        /// </summary>
        [XmlElement(ElementName = "ShippingAddress")]
        public Address ShippingAddress
        {
            get { return this.shippingAddressField ; }
            set { this.shippingAddressField = value; }
        }



        /// <summary>
        /// Sets the ShippingAddress property
        /// </summary>
        /// <param name="shippingAddress">ShippingAddress property</param>
        /// <returns>this instance</returns>
        public Order WithShippingAddress(Address shippingAddress)
        {
            this.shippingAddressField = shippingAddress;
            return this;
        }



        /// <summary>
        /// Checks if ShippingAddress property is set
        /// </summary>
        /// <returns>true if ShippingAddress property is set</returns>
        public Boolean IsSetShippingAddress()
        {
            return this.shippingAddressField != null;
        }




        /// <summary>
        /// Gets and sets the OrderTotal property.
        /// </summary>
        [XmlElement(ElementName = "OrderTotal")]
        public Money OrderTotal
        {
            get { return this.orderTotalField ; }
            set { this.orderTotalField = value; }
        }



        /// <summary>
        /// Sets the OrderTotal property
        /// </summary>
        /// <param name="orderTotal">OrderTotal property</param>
        /// <returns>this instance</returns>
        public Order WithOrderTotal(Money orderTotal)
        {
            this.orderTotalField = orderTotal;
            return this;
        }



        /// <summary>
        /// Checks if OrderTotal property is set
        /// </summary>
        /// <returns>true if OrderTotal property is set</returns>
        public Boolean IsSetOrderTotal()
        {
            return this.orderTotalField != null;
        }




        /// <summary>
        /// Gets and sets the NumberOfItemsShipped property.
        /// </summary>
        [XmlElement(ElementName = "NumberOfItemsShipped")]
        public Decimal NumberOfItemsShipped
        {
            get { return this.numberOfItemsShippedField.GetValueOrDefault() ; }
            set { this.numberOfItemsShippedField= value; }
        }



        /// <summary>
        /// Sets the NumberOfItemsShipped property
        /// </summary>
        /// <param name="numberOfItemsShipped">NumberOfItemsShipped property</param>
        /// <returns>this instance</returns>
        public Order WithNumberOfItemsShipped(Decimal numberOfItemsShipped)
        {
            this.numberOfItemsShippedField = numberOfItemsShipped;
            return this;
        }



        /// <summary>
        /// Checks if NumberOfItemsShipped property is set
        /// </summary>
        /// <returns>true if NumberOfItemsShipped property is set</returns>
        public Boolean IsSetNumberOfItemsShipped()
        {
            return  this.numberOfItemsShippedField.HasValue;

        }


        /// <summary>
        /// Gets and sets the NumberOfItemsUnshipped property.
        /// </summary>
        [XmlElement(ElementName = "NumberOfItemsUnshipped")]
        public Decimal NumberOfItemsUnshipped
        {
            get { return this.numberOfItemsUnshippedField.GetValueOrDefault() ; }
            set { this.numberOfItemsUnshippedField= value; }
        }



        /// <summary>
        /// Sets the NumberOfItemsUnshipped property
        /// </summary>
        /// <param name="numberOfItemsUnshipped">NumberOfItemsUnshipped property</param>
        /// <returns>this instance</returns>
        public Order WithNumberOfItemsUnshipped(Decimal numberOfItemsUnshipped)
        {
            this.numberOfItemsUnshippedField = numberOfItemsUnshipped;
            return this;
        }



        /// <summary>
        /// Checks if NumberOfItemsUnshipped property is set
        /// </summary>
        /// <returns>true if NumberOfItemsUnshipped property is set</returns>
        public Boolean IsSetNumberOfItemsUnshipped()
        {
            return  this.numberOfItemsUnshippedField.HasValue;

        }


        /// <summary>
        /// Gets and sets the PaymentExecutionDetail property.
        /// </summary>
        [XmlElement(ElementName = "PaymentExecutionDetail")]
        public PaymentExecutionDetailItemList PaymentExecutionDetail
        {
            get { return this.paymentExecutionDetailField ; }
            set { this.paymentExecutionDetailField = value; }
        }



        /// <summary>
        /// Sets the PaymentExecutionDetail property
        /// </summary>
        /// <param name="paymentExecutionDetail">PaymentExecutionDetail property</param>
        /// <returns>this instance</returns>
        public Order WithPaymentExecutionDetail(PaymentExecutionDetailItemList paymentExecutionDetail)
        {
            this.paymentExecutionDetailField = paymentExecutionDetail;
            return this;
        }



        /// <summary>
        /// Checks if PaymentExecutionDetail property is set
        /// </summary>
        /// <returns>true if PaymentExecutionDetail property is set</returns>
        public Boolean IsSetPaymentExecutionDetail()
        {
            return this.paymentExecutionDetailField != null;
        }




        /// <summary>
        /// Gets and sets the PaymentMethod property.
        /// </summary>
        [XmlElement(ElementName = "PaymentMethod")]
        public PaymentMethodEnum PaymentMethod
        {
            get { return this.paymentMethodField.GetValueOrDefault() ; }
            set { this.paymentMethodField= value; }
        }



        /// <summary>
        /// Sets the PaymentMethod property
        /// </summary>
        /// <param name="paymentMethod">PaymentMethod property</param>
        /// <returns>this instance</returns>
        public Order WithPaymentMethod(PaymentMethodEnum paymentMethod)
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
            return this.paymentMethodField.HasValue;

        }


        /// <summary>
        /// Gets and sets the MarketplaceId property.
        /// </summary>
        [XmlElement(ElementName = "MarketplaceId")]
        public String MarketplaceId
        {
            get { return this.marketplaceIdField ; }
            set { this.marketplaceIdField= value; }
        }



        /// <summary>
        /// Sets the MarketplaceId property
        /// </summary>
        /// <param name="marketplaceId">MarketplaceId property</param>
        /// <returns>this instance</returns>
        public Order WithMarketplaceId(String marketplaceId)
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
            return  this.marketplaceIdField != null;

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
        public Order WithBuyerEmail(String buyerEmail)
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
        /// Gets and sets the BuyerName property.
        /// </summary>
        [XmlElement(ElementName = "BuyerName")]
        public String BuyerName
        {
            get { return this.buyerNameField ; }
            set { this.buyerNameField= value; }
        }



        /// <summary>
        /// Sets the BuyerName property
        /// </summary>
        /// <param name="buyerName">BuyerName property</param>
        /// <returns>this instance</returns>
        public Order WithBuyerName(String buyerName)
        {
            this.buyerNameField = buyerName;
            return this;
        }



        /// <summary>
        /// Checks if BuyerName property is set
        /// </summary>
        /// <returns>true if BuyerName property is set</returns>
        public Boolean IsSetBuyerName()
        {
            return  this.buyerNameField != null;

        }


        /// <summary>
        /// Gets and sets the ShipmentServiceLevelCategory property.
        /// </summary>
        [XmlElement(ElementName = "ShipmentServiceLevelCategory")]
        public String ShipmentServiceLevelCategory
        {
            get { return this.shipmentServiceLevelCategoryField ; }
            set { this.shipmentServiceLevelCategoryField= value; }
        }



        /// <summary>
        /// Sets the ShipmentServiceLevelCategory property
        /// </summary>
        /// <param name="shipmentServiceLevelCategory">ShipmentServiceLevelCategory property</param>
        /// <returns>this instance</returns>
        public Order WithShipmentServiceLevelCategory(String shipmentServiceLevelCategory)
        {
            this.shipmentServiceLevelCategoryField = shipmentServiceLevelCategory;
            return this;
        }



        /// <summary>
        /// Checks if ShipmentServiceLevelCategory property is set
        /// </summary>
        /// <returns>true if ShipmentServiceLevelCategory property is set</returns>
        public Boolean IsSetShipmentServiceLevelCategory()
        {
            return  this.shipmentServiceLevelCategoryField != null;

        }


        /// <summary>
        /// Gets and sets the ShippedByAmazonTFM property.
        /// </summary>
        [XmlElement(ElementName = "ShippedByAmazonTFM")]
        public Boolean ShippedByAmazonTFM
        {
            get { return this.shippedByAmazonTFMField.GetValueOrDefault() ; }
            set { this.shippedByAmazonTFMField= value; }
        }



        /// <summary>
        /// Sets the ShippedByAmazonTFM property
        /// </summary>
        /// <param name="shippedByAmazonTFM">ShippedByAmazonTFM property</param>
        /// <returns>this instance</returns>
        public Order WithShippedByAmazonTFM(Boolean shippedByAmazonTFM)
        {
            this.shippedByAmazonTFMField = shippedByAmazonTFM;
            return this;
        }



        /// <summary>
        /// Checks if ShippedByAmazonTFM property is set
        /// </summary>
        /// <returns>true if ShippedByAmazonTFM property is set</returns>
        public Boolean IsSetShippedByAmazonTFM()
        {
            return  this.shippedByAmazonTFMField.HasValue;

        }


        /// <summary>
        /// Gets and sets the TFMShipmentStatus property.
        /// </summary>
        [XmlElement(ElementName = "TFMShipmentStatus")]
        public String TFMShipmentStatus
        {
            get { return this.TFMShipmentStatusField ; }
            set { this.TFMShipmentStatusField= value; }
        }



        /// <summary>
        /// Sets the TFMShipmentStatus property
        /// </summary>
        /// <param name="TFMShipmentStatus">TFMShipmentStatus property</param>
        /// <returns>this instance</returns>
        public Order WithTFMShipmentStatus(String TFMShipmentStatus)
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
            return  this.TFMShipmentStatusField != null;

        }



        /// <summary>
        /// Gets and sets the CbaDisplayableShippingLabel property.
        /// </summary>
        [XmlElement(ElementName = "CbaDisplayableShippingLabel")]
        public String CbaDisplayableShippingLabel
        {
            get { return this.cbaDisplayableShippingLabelField; }
            set { this.cbaDisplayableShippingLabelField = value; }
        }

        /// <summary>
        /// Sets the CbaDisplayableShippingLabel property
        /// </summary>
        /// <param name="CbaDisplayableShippingLabel">CbaDisplayableShippingLabel property</param>
        /// <returns>this instance</returns>
        public Order WithCbaDisplayableShippingLabel(String CbaDisplayableShippingLabel)
        {
            this.cbaDisplayableShippingLabelField = CbaDisplayableShippingLabel;
            return this;
        }

        /// <summary>
        /// Checks if CbaDisplayableShippingLabel property is set
        /// </summary>
        /// <returns>true if CbaDisplayableShippingLabel property is set</returns>
        public Boolean IsSetCbaDisplayableShippingLabel()
        {
            return  this.cbaDisplayableShippingLabelField != null;
        }



        /// <summary>
        /// Gets and sets the OrderType property.
        /// </summary>
        [XmlElement(ElementName = "OrderType")]
        public String OrderType
        {
            get { return this.orderTypeField ; }
            set { this.orderTypeField = value; }
        }

        /// <summary>
        /// Sets the OrderType property
        /// </summary>
        /// <param name="OrderType">OrderType property</param>
        /// <returns>this instance</returns>
        public Order WithOrderType(String OrderType)
        {
            this.orderTypeField = OrderType;
            return this;
        }

        /// <summary>
        /// Checks if OrderType property is set
        /// </summary>
        /// <returns>true if OrderType property is set</returns>
        public Boolean IsSetOrderType()
        {
            return  this.orderTypeField != null;
        }


        /// <summary>
        /// Gets and sets the EarliestShipDate property.
        /// </summary>
        [XmlElement(ElementName = "EarliestShipDate")]
        public DateTime? EarliestShipDate
        {
            get { return this.earliestShipDateField ; }
            set { this.earliestShipDateField = value; }
        }

        /// <summary>
        /// Sets the EarliestShipDate property
        /// </summary>
        /// <param name="earliestShipDate">EarliestShipDate property</param>
        /// <returns>this instance</returns>
        public Order WithEarliestShipDate(DateTime earliestShipDate)
        {
            this.earliestShipDateField = earliestShipDate;
            return this;
        }

        /// <summary>
        /// Checks if EarliestShipDate property is set
        /// </summary>
        /// <returns>true if EarliestShipDate property is set</returns>
        public Boolean IsSetEarliestShipDate()
        {
            return  this.earliestShipDateField != null;
        }


        /// <summary>
        /// Gets and sets the LatestShipDate property.
        /// </summary>
        [XmlElement(ElementName = "LatestShipDate")]
        public DateTime? LatestShipDate
        {
            get { return this.latestShipDateField ; }
            set { this.latestShipDateField = value; }
        }

        /// <summary>
        /// Sets the LatestShipDate property
        /// </summary>
        /// <param name="latestShipDate">LatestShipDate property</param>
        /// <returns>this instance</returns>
        public Order WithLatestShipDate(DateTime latestShipDate)
        {
            this.latestShipDateField = latestShipDate;
            return this;
        }

        /// <summary>
        /// Checks if LatestShipDate property is set
        /// </summary>
        /// <returns>true if LatestShipDate property is set</returns>
        public Boolean IsSetLatestShipDate()
        {
            return  this.latestShipDateField != null;
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
            if (this.IsSetAmazonOrderId()) {
                xml.Append("<AmazonOrderId>");
                xml.Append(this.EscapeXML(this.AmazonOrderId));
                xml.Append("</AmazonOrderId>");
            }
            if (this.IsSetSellerOrderId()) {
                xml.Append("<SellerOrderId>");
                xml.Append(this.EscapeXML(this.SellerOrderId));
                xml.Append("</SellerOrderId>");
            }
            if (this.IsSetPurchaseDate()) {
                xml.Append("<PurchaseDate>");
                xml.Append(this.PurchaseDate);
                xml.Append("</PurchaseDate>");
            }
            if (this.IsSetLastUpdateDate()) {
                xml.Append("<LastUpdateDate>");
                xml.Append(this.LastUpdateDate);
                xml.Append("</LastUpdateDate>");
            }
            if (this.IsSetOrderStatus()) {
                xml.Append("<OrderStatus>");
                xml.Append(this.OrderStatus);
                xml.Append("</OrderStatus>");
            }
            if (this.IsSetFulfillmentChannel()) {
                xml.Append("<FulfillmentChannel>");
                xml.Append(this.FulfillmentChannel);
                xml.Append("</FulfillmentChannel>");
            }
            if (this.IsSetSalesChannel()) {
                xml.Append("<SalesChannel>");
                xml.Append(this.EscapeXML(this.SalesChannel));
                xml.Append("</SalesChannel>");
            }
            if (this.IsSetOrderChannel()) {
                xml.Append("<OrderChannel>");
                xml.Append(this.EscapeXML(this.OrderChannel));
                xml.Append("</OrderChannel>");
            }
            if (this.IsSetShipServiceLevel()) {
                xml.Append("<ShipServiceLevel>");
                xml.Append(this.EscapeXML(this.ShipServiceLevel));
                xml.Append("</ShipServiceLevel>");
            }
            if (this.IsSetShippingAddress()) {
                Address  shippingAddressObj = this.ShippingAddress;
                xml.Append("<ShippingAddress>");
                xml.Append(shippingAddressObj.ToXMLFragment());
                xml.Append("</ShippingAddress>");
            } 
            if (this.IsSetOrderTotal()) {
                Money  orderTotalObj = this.OrderTotal;
                xml.Append("<OrderTotal>");
                xml.Append(orderTotalObj.ToXMLFragment());
                xml.Append("</OrderTotal>");
            } 
            if (this.IsSetNumberOfItemsShipped()) {
                xml.Append("<NumberOfItemsShipped>");
                xml.Append(this.NumberOfItemsShipped);
                xml.Append("</NumberOfItemsShipped>");
            }
            if (this.IsSetNumberOfItemsUnshipped()) {
                xml.Append("<NumberOfItemsUnshipped>");
                xml.Append(this.NumberOfItemsUnshipped);
                xml.Append("</NumberOfItemsUnshipped>");
            }
            if (this.IsSetPaymentExecutionDetail()) {
                PaymentExecutionDetailItemList  paymentExecutionDetailObj = this.PaymentExecutionDetail;
                xml.Append("<PaymentExecutionDetail>");
                xml.Append(paymentExecutionDetailObj.ToXMLFragment());
                xml.Append("</PaymentExecutionDetail>");
            } 
            if (this.IsSetPaymentMethod()) {
                xml.Append("<PaymentMethod>");
                xml.Append(this.PaymentMethod);
                xml.Append("</PaymentMethod>");
            }
            if (this.IsSetMarketplaceId()) {
                xml.Append("<MarketplaceId>");
                xml.Append(this.EscapeXML(this.MarketplaceId));
                xml.Append("</MarketplaceId>");
            }
            if (this.IsSetBuyerEmail()) {
                xml.Append("<BuyerEmail>");
                xml.Append(this.EscapeXML(this.BuyerEmail));
                xml.Append("</BuyerEmail>");
            }
            if (this.IsSetBuyerName()) {
                xml.Append("<BuyerName>");
                xml.Append(this.EscapeXML(this.BuyerName));
                xml.Append("</BuyerName>");
            }
            if (this.IsSetShipmentServiceLevelCategory()) {
                xml.Append("<ShipmentServiceLevelCategory>");
                xml.Append(this.EscapeXML(this.ShipmentServiceLevelCategory));
                xml.Append("</ShipmentServiceLevelCategory>");
            }
            if (this.IsSetShippedByAmazonTFM()) {
                xml.Append("<ShippedByAmazonTFM>");
                xml.Append(this.ShippedByAmazonTFM);
                xml.Append("</ShippedByAmazonTFM>");
            }
            if (this.IsSetTFMShipmentStatus()) {
                xml.Append("<TFMShipmentStatus>");
                xml.Append(this.EscapeXML(this.TFMShipmentStatus));
                xml.Append("</TFMShipmentStatus>");
            }
            if (this.IsSetCbaDisplayableShippingLabel()) {
                xml.Append("<CbaDisplayableShippingLabel>");
                xml.Append(this.EscapeXML(this.CbaDisplayableShippingLabel));
                xml.Append("</CbaDisplayableShippingLabel>");
            }
            if (this.IsSetOrderType()) {
                xml.Append("<OrderType>");
                xml.Append(this.EscapeXML(this.OrderType));
                xml.Append("</OrderType>");
            }
            if (this.IsSetEarliestShipDate()) {
                xml.Append("<EarliestShipDate>");
                xml.Append(this.EarliestShipDate);
                xml.Append("</EarliestShipDate>");
            }
            if (this.IsSetLatestShipDate()) {
                xml.Append("<LatestShipDate>");
                xml.Append(this.LatestShipDate);
                xml.Append("</LatestShipDate>");
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

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            if (this.IsSetAmazonOrderId())
            {
                result.Append("Order ID: ");
                result.AppendLine(this.AmazonOrderId);
            }
            if (this.IsSetFulfillmentChannel())
            {
                result.Append("FulfillmentChannel:");
                result.AppendLine(this.FulfillmentChannel.ToString());
            }
            if (this.IsSetNumberOfItemsShipped())
            {
                result.Append("Number of Items Shipped: ");
                result.AppendLine(this.NumberOfItemsShipped.ToString());
            }
            if (this.IsSetNumberOfItemsUnshipped())
            {
                result.Append("Number of Items Not Shipped: ");
                result.AppendLine(this.NumberOfItemsShipped.ToString());
            }
            if (this.IsSetLastUpdateDate())
            {
                result.Append("Last Update Date: ");
                result.AppendLine(this.LastUpdateDate.ToString());
            }
            if (this.IsSetOrderChannel())
            {
                result.Append("Order Channel: ");
                result.AppendLine(this.OrderChannel);
            }
            if (this.IsSetOrderStatus())
            {
                result.Append("Order Status: ");
                result.AppendLine(this.OrderStatus.ToString());
            }
            if (this.IsSetOrderTotal())
            {
                result.Append("Order Total: ");
                result.AppendLine(this.OrderTotal.ToString());
            }
            if (this.IsSetPurchaseDate())
            {
                result.Append("Purchase Date: ");
                result.AppendLine(this.PurchaseDate.ToString());
            }
            if (this.IsSetSalesChannel())
            {
                result.Append("Sales Channel: ");
                result.AppendLine(this.SalesChannel);
            }
            if (this.IsSetSellerOrderId())
            {
                result.Append("Seller Order Id: ");
                result.AppendLine(this.SellerOrderId);
            }
            if (this.IsSetShipServiceLevel())
            {
                result.Append("Ship Service Level: ");
                result.AppendLine(this.ShipServiceLevel);
            }
            if (this.IsSetPaymentExecutionDetail()) {
                result.Append("Payment Execution Detail: ");
                result.Append(this.PaymentExecutionDetail);
            }
            if (this.IsSetPaymentMethod()) {
                result.Append("Payment Method: ");
                result.Append(this.PaymentMethod);
            }
            if (this.IsSetMarketplaceId())
            {
                result.Append("Marketplace Id: ");
                result.AppendLine(this.MarketplaceId);
            }
            if (this.IsSetBuyerEmail())
            {
                result.Append("Buyer Email: ");
                result.AppendLine(this.BuyerEmail);
            }
            if (this.IsSetShipServiceLevel())
            {
                result.Append("Buyer Name: ");
                result.AppendLine(this.BuyerName);
            }
            if (this.IsSetShipmentServiceLevelCategory())
            {
                result.Append("Shipment Service Level Category: ");
                result.AppendLine(this.ShipmentServiceLevelCategory);
            }
            if (this.IsSetCbaDisplayableShippingLabel()) {
                result.Append("CbaDisplayableShippingLabel: ");
                result.AppendLine(this.CbaDisplayableShippingLabel);
            }
            if (this.IsSetOrderType()) {
                result.Append("OrderType: ");
                result.AppendLine(this.OrderType);
            }
            if (this.IsSetEarliestShipDate()) {
                result.Append("EarliestShipDate: ");
                result.AppendLine(this.EarliestShipDate.ToString());
            }
            if (this.IsSetLatestShipDate()) {
                result.Append("LatestShipDate: ");
                result.AppendLine(this.LatestShipDate.ToString());
            }
            return result.ToString();
        }

    }

}