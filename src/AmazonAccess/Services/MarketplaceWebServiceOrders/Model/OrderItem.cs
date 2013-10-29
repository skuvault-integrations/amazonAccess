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
    public class OrderItem
    {
    
        private String ASINField;

        private String sellerSKUField;

        private String orderItemIdField;

        private String titleField;

        private Decimal? quantityOrderedField;

        private Decimal? quantityShippedField;

        private  Money itemPriceField;
        private  Money shippingPriceField;
        private  Money giftWrapPriceField;
        private  Money itemTaxField;
        private  Money shippingTaxField;
        private  Money giftWrapTaxField;
        private  Money shippingDiscountField;
        private  Money promotionDiscountField;
        private  PromotionIdList promotionIdsField;
        private  Money CODFeeField;
        private  Money CODFeeDiscountField;
        private String giftMessageTextField;

        private String giftWrapLevelField;

        private  InvoiceData invoiceDataField;
        
        private String conditionNoteField;
        private String conditionIdField;
        private String conditionSubtypeIdField;
        private String scheduledDeliveryStartDateField;
        private String scheduledDeliveryEndDateField; 

        /// <summary>
        /// Gets and sets the ASIN property.
        /// </summary>
        [XmlElement(ElementName = "ASIN")]
        public String ASIN
        {
            get { return this.ASINField ; }
            set { this.ASINField= value; }
        }



        /// <summary>
        /// Sets the ASIN property
        /// </summary>
        /// <param name="ASIN">ASIN property</param>
        /// <returns>this instance</returns>
        public OrderItem WithASIN(String ASIN)
        {
            this.ASINField = ASIN;
            return this;
        }



        /// <summary>
        /// Checks if ASIN property is set
        /// </summary>
        /// <returns>true if ASIN property is set</returns>
        public Boolean IsSetASIN()
        {
            return  this.ASINField != null;

        }


        /// <summary>
        /// Gets and sets the SellerSKU property.
        /// </summary>
        [XmlElement(ElementName = "SellerSKU")]
        public String SellerSKU
        {
            get { return this.sellerSKUField ; }
            set { this.sellerSKUField= value; }
        }



        /// <summary>
        /// Sets the SellerSKU property
        /// </summary>
        /// <param name="sellerSKU">SellerSKU property</param>
        /// <returns>this instance</returns>
        public OrderItem WithSellerSKU(String sellerSKU)
        {
            this.sellerSKUField = sellerSKU;
            return this;
        }



        /// <summary>
        /// Checks if SellerSKU property is set
        /// </summary>
        /// <returns>true if SellerSKU property is set</returns>
        public Boolean IsSetSellerSKU()
        {
            return  this.sellerSKUField != null;

        }


        /// <summary>
        /// Gets and sets the OrderItemId property.
        /// </summary>
        [XmlElement(ElementName = "OrderItemId")]
        public String OrderItemId
        {
            get { return this.orderItemIdField ; }
            set { this.orderItemIdField= value; }
        }



        /// <summary>
        /// Sets the OrderItemId property
        /// </summary>
        /// <param name="orderItemId">OrderItemId property</param>
        /// <returns>this instance</returns>
        public OrderItem WithOrderItemId(String orderItemId)
        {
            this.orderItemIdField = orderItemId;
            return this;
        }



        /// <summary>
        /// Checks if OrderItemId property is set
        /// </summary>
        /// <returns>true if OrderItemId property is set</returns>
        public Boolean IsSetOrderItemId()
        {
            return  this.orderItemIdField != null;

        }


        /// <summary>
        /// Gets and sets the Title property.
        /// </summary>
        [XmlElement(ElementName = "Title")]
        public String Title
        {
            get { return this.titleField ; }
            set { this.titleField= value; }
        }



        /// <summary>
        /// Sets the Title property
        /// </summary>
        /// <param name="title">Title property</param>
        /// <returns>this instance</returns>
        public OrderItem WithTitle(String title)
        {
            this.titleField = title;
            return this;
        }



        /// <summary>
        /// Checks if Title property is set
        /// </summary>
        /// <returns>true if Title property is set</returns>
        public Boolean IsSetTitle()
        {
            return  this.titleField != null;

        }


        /// <summary>
        /// Gets and sets the QuantityOrdered property.
        /// </summary>
        [XmlElement(ElementName = "QuantityOrdered")]
        public Decimal QuantityOrdered
        {
            get { return this.quantityOrderedField.GetValueOrDefault() ; }
            set { this.quantityOrderedField= value; }
        }



        /// <summary>
        /// Sets the QuantityOrdered property
        /// </summary>
        /// <param name="quantityOrdered">QuantityOrdered property</param>
        /// <returns>this instance</returns>
        public OrderItem WithQuantityOrdered(Decimal quantityOrdered)
        {
            this.quantityOrderedField = quantityOrdered;
            return this;
        }



        /// <summary>
        /// Checks if QuantityOrdered property is set
        /// </summary>
        /// <returns>true if QuantityOrdered property is set</returns>
        public Boolean IsSetQuantityOrdered()
        {
            return  this.quantityOrderedField.HasValue;

        }


        /// <summary>
        /// Gets and sets the QuantityShipped property.
        /// </summary>
        [XmlElement(ElementName = "QuantityShipped")]
        public Decimal QuantityShipped
        {
            get { return this.quantityShippedField.GetValueOrDefault() ; }
            set { this.quantityShippedField= value; }
        }



        /// <summary>
        /// Sets the QuantityShipped property
        /// </summary>
        /// <param name="quantityShipped">QuantityShipped property</param>
        /// <returns>this instance</returns>
        public OrderItem WithQuantityShipped(Decimal quantityShipped)
        {
            this.quantityShippedField = quantityShipped;
            return this;
        }



        /// <summary>
        /// Checks if QuantityShipped property is set
        /// </summary>
        /// <returns>true if QuantityShipped property is set</returns>
        public Boolean IsSetQuantityShipped()
        {
            return  this.quantityShippedField.HasValue;

        }


        /// <summary>
        /// Gets and sets the ItemPrice property.
        /// </summary>
        [XmlElement(ElementName = "ItemPrice")]
        public Money ItemPrice
        {
            get { return this.itemPriceField ; }
            set { this.itemPriceField = value; }
        }



        /// <summary>
        /// Sets the ItemPrice property
        /// </summary>
        /// <param name="itemPrice">ItemPrice property</param>
        /// <returns>this instance</returns>
        public OrderItem WithItemPrice(Money itemPrice)
        {
            this.itemPriceField = itemPrice;
            return this;
        }



        /// <summary>
        /// Checks if ItemPrice property is set
        /// </summary>
        /// <returns>true if ItemPrice property is set</returns>
        public Boolean IsSetItemPrice()
        {
            return this.itemPriceField != null;
        }




        /// <summary>
        /// Gets and sets the ShippingPrice property.
        /// </summary>
        [XmlElement(ElementName = "ShippingPrice")]
        public Money ShippingPrice
        {
            get { return this.shippingPriceField ; }
            set { this.shippingPriceField = value; }
        }



        /// <summary>
        /// Sets the ShippingPrice property
        /// </summary>
        /// <param name="shippingPrice">ShippingPrice property</param>
        /// <returns>this instance</returns>
        public OrderItem WithShippingPrice(Money shippingPrice)
        {
            this.shippingPriceField = shippingPrice;
            return this;
        }



        /// <summary>
        /// Checks if ShippingPrice property is set
        /// </summary>
        /// <returns>true if ShippingPrice property is set</returns>
        public Boolean IsSetShippingPrice()
        {
            return this.shippingPriceField != null;
        }




        /// <summary>
        /// Gets and sets the GiftWrapPrice property.
        /// </summary>
        [XmlElement(ElementName = "GiftWrapPrice")]
        public Money GiftWrapPrice
        {
            get { return this.giftWrapPriceField ; }
            set { this.giftWrapPriceField = value; }
        }



        /// <summary>
        /// Sets the GiftWrapPrice property
        /// </summary>
        /// <param name="giftWrapPrice">GiftWrapPrice property</param>
        /// <returns>this instance</returns>
        public OrderItem WithGiftWrapPrice(Money giftWrapPrice)
        {
            this.giftWrapPriceField = giftWrapPrice;
            return this;
        }



        /// <summary>
        /// Checks if GiftWrapPrice property is set
        /// </summary>
        /// <returns>true if GiftWrapPrice property is set</returns>
        public Boolean IsSetGiftWrapPrice()
        {
            return this.giftWrapPriceField != null;
        }




        /// <summary>
        /// Gets and sets the ItemTax property.
        /// </summary>
        [XmlElement(ElementName = "ItemTax")]
        public Money ItemTax
        {
            get { return this.itemTaxField ; }
            set { this.itemTaxField = value; }
        }



        /// <summary>
        /// Sets the ItemTax property
        /// </summary>
        /// <param name="itemTax">ItemTax property</param>
        /// <returns>this instance</returns>
        public OrderItem WithItemTax(Money itemTax)
        {
            this.itemTaxField = itemTax;
            return this;
        }



        /// <summary>
        /// Checks if ItemTax property is set
        /// </summary>
        /// <returns>true if ItemTax property is set</returns>
        public Boolean IsSetItemTax()
        {
            return this.itemTaxField != null;
        }




        /// <summary>
        /// Gets and sets the ShippingTax property.
        /// </summary>
        [XmlElement(ElementName = "ShippingTax")]
        public Money ShippingTax
        {
            get { return this.shippingTaxField ; }
            set { this.shippingTaxField = value; }
        }



        /// <summary>
        /// Sets the ShippingTax property
        /// </summary>
        /// <param name="shippingTax">ShippingTax property</param>
        /// <returns>this instance</returns>
        public OrderItem WithShippingTax(Money shippingTax)
        {
            this.shippingTaxField = shippingTax;
            return this;
        }



        /// <summary>
        /// Checks if ShippingTax property is set
        /// </summary>
        /// <returns>true if ShippingTax property is set</returns>
        public Boolean IsSetShippingTax()
        {
            return this.shippingTaxField != null;
        }




        /// <summary>
        /// Gets and sets the GiftWrapTax property.
        /// </summary>
        [XmlElement(ElementName = "GiftWrapTax")]
        public Money GiftWrapTax
        {
            get { return this.giftWrapTaxField ; }
            set { this.giftWrapTaxField = value; }
        }



        /// <summary>
        /// Sets the GiftWrapTax property
        /// </summary>
        /// <param name="giftWrapTax">GiftWrapTax property</param>
        /// <returns>this instance</returns>
        public OrderItem WithGiftWrapTax(Money giftWrapTax)
        {
            this.giftWrapTaxField = giftWrapTax;
            return this;
        }



        /// <summary>
        /// Checks if GiftWrapTax property is set
        /// </summary>
        /// <returns>true if GiftWrapTax property is set</returns>
        public Boolean IsSetGiftWrapTax()
        {
            return this.giftWrapTaxField != null;
        }




        /// <summary>
        /// Gets and sets the ShippingDiscount property.
        /// </summary>
        [XmlElement(ElementName = "ShippingDiscount")]
        public Money ShippingDiscount
        {
            get { return this.shippingDiscountField ; }
            set { this.shippingDiscountField = value; }
        }



        /// <summary>
        /// Sets the ShippingDiscount property
        /// </summary>
        /// <param name="shippingDiscount">ShippingDiscount property</param>
        /// <returns>this instance</returns>
        public OrderItem WithShippingDiscount(Money shippingDiscount)
        {
            this.shippingDiscountField = shippingDiscount;
            return this;
        }



        /// <summary>
        /// Checks if ShippingDiscount property is set
        /// </summary>
        /// <returns>true if ShippingDiscount property is set</returns>
        public Boolean IsSetShippingDiscount()
        {
            return this.shippingDiscountField != null;
        }




        /// <summary>
        /// Gets and sets the PromotionDiscount property.
        /// </summary>
        [XmlElement(ElementName = "PromotionDiscount")]
        public Money PromotionDiscount
        {
            get { return this.promotionDiscountField ; }
            set { this.promotionDiscountField = value; }
        }



        /// <summary>
        /// Sets the PromotionDiscount property
        /// </summary>
        /// <param name="promotionDiscount">PromotionDiscount property</param>
        /// <returns>this instance</returns>
        public OrderItem WithPromotionDiscount(Money promotionDiscount)
        {
            this.promotionDiscountField = promotionDiscount;
            return this;
        }



        /// <summary>
        /// Checks if PromotionDiscount property is set
        /// </summary>
        /// <returns>true if PromotionDiscount property is set</returns>
        public Boolean IsSetPromotionDiscount()
        {
            return this.promotionDiscountField != null;
        }




        /// <summary>
        /// Gets and sets the PromotionIds property.
        /// </summary>
        [XmlElement(ElementName = "PromotionIds")]
        public PromotionIdList PromotionIds
        {
            get { return this.promotionIdsField ; }
            set { this.promotionIdsField = value; }
        }



        /// <summary>
        /// Sets the PromotionIds property
        /// </summary>
        /// <param name="promotionIds">PromotionIds property</param>
        /// <returns>this instance</returns>
        public OrderItem WithPromotionIds(PromotionIdList promotionIds)
        {
            this.promotionIdsField = promotionIds;
            return this;
        }



        /// <summary>
        /// Checks if PromotionIds property is set
        /// </summary>
        /// <returns>true if PromotionIds property is set</returns>
        public Boolean IsSetPromotionIds()
        {
            return this.promotionIdsField != null;
        }




        /// <summary>
        /// Gets and sets the CODFee property.
        /// </summary>
        [XmlElement(ElementName = "CODFee")]
        public Money CODFee
        {
            get { return this.CODFeeField ; }
            set { this.CODFeeField = value; }
        }



        /// <summary>
        /// Sets the CODFee property
        /// </summary>
        /// <param name="CODFee">CODFee property</param>
        /// <returns>this instance</returns>
        public OrderItem WithCODFee(Money CODFee)
        {
            this.CODFeeField = CODFee;
            return this;
        }



        /// <summary>
        /// Checks if CODFee property is set
        /// </summary>
        /// <returns>true if CODFee property is set</returns>
        public Boolean IsSetCODFee()
        {
            return this.CODFeeField != null;
        }




        /// <summary>
        /// Gets and sets the CODFeeDiscount property.
        /// </summary>
        [XmlElement(ElementName = "CODFeeDiscount")]
        public Money CODFeeDiscount
        {
            get { return this.CODFeeDiscountField ; }
            set { this.CODFeeDiscountField = value; }
        }



        /// <summary>
        /// Sets the CODFeeDiscount property
        /// </summary>
        /// <param name="CODFeeDiscount">CODFeeDiscount property</param>
        /// <returns>this instance</returns>
        public OrderItem WithCODFeeDiscount(Money CODFeeDiscount)
        {
            this.CODFeeDiscountField = CODFeeDiscount;
            return this;
        }



        /// <summary>
        /// Checks if CODFeeDiscount property is set
        /// </summary>
        /// <returns>true if CODFeeDiscount property is set</returns>
        public Boolean IsSetCODFeeDiscount()
        {
            return this.CODFeeDiscountField != null;
        }




        /// <summary>
        /// Gets and sets the GiftMessageText property.
        /// </summary>
        [XmlElement(ElementName = "GiftMessageText")]
        public String GiftMessageText
        {
            get { return this.giftMessageTextField ; }
            set { this.giftMessageTextField= value; }
        }



        /// <summary>
        /// Sets the GiftMessageText property
        /// </summary>
        /// <param name="giftMessageText">GiftMessageText property</param>
        /// <returns>this instance</returns>
        public OrderItem WithGiftMessageText(String giftMessageText)
        {
            this.giftMessageTextField = giftMessageText;
            return this;
        }



        /// <summary>
        /// Checks if GiftMessageText property is set
        /// </summary>
        /// <returns>true if GiftMessageText property is set</returns>
        public Boolean IsSetGiftMessageText()
        {
            return  this.giftMessageTextField != null;

        }


        /// <summary>
        /// Gets and sets the GiftWrapLevel property.
        /// </summary>
        [XmlElement(ElementName = "GiftWrapLevel")]
        public String GiftWrapLevel
        {
            get { return this.giftWrapLevelField ; }
            set { this.giftWrapLevelField= value; }
        }



        /// <summary>
        /// Sets the GiftWrapLevel property
        /// </summary>
        /// <param name="giftWrapLevel">GiftWrapLevel property</param>
        /// <returns>this instance</returns>
        public OrderItem WithGiftWrapLevel(String giftWrapLevel)
        {
            this.giftWrapLevelField = giftWrapLevel;
            return this;
        }



        /// <summary>
        /// Checks if GiftWrapLevel property is set
        /// </summary>
        /// <returns>true if GiftWrapLevel property is set</returns>
        public Boolean IsSetGiftWrapLevel()
        {
            return  this.giftWrapLevelField != null;

        }


        /// <summary>
        /// Gets and sets the InvoiceData property.
        /// </summary>
        [XmlElement(ElementName = "InvoiceData")]
        public InvoiceData InvoiceData
        {
            get { return this.invoiceDataField ; }
            set { this.invoiceDataField = value; }
        }



        /// <summary>
        /// Sets the InvoiceData property
        /// </summary>
        /// <param name="invoiceData">InvoiceData property</param>
        /// <returns>this instance</returns>
        public OrderItem WithInvoiceData(InvoiceData invoiceData)
        {
            this.invoiceDataField = invoiceData;
            return this;
        }



        /// <summary>
        /// Checks if InvoiceData property is set
        /// </summary>
        /// <returns>true if InvoiceData property is set</returns>
        public Boolean IsSetInvoiceData()
        {
            return this.invoiceDataField != null;
        }



        /// <summary>
        /// Gets and sets the ConditionNote property.
        /// </summary>
        [XmlElement(ElementName = "ConditionNote")]
        public String ConditionNote
        {
            get { return this.conditionNoteField ; }
            set { this.conditionNoteField = value; }
        }

        /// <summary>
        /// Sets the ConditionNote property
        /// </summary>
        /// <param name="conditionNote">ConditionNote property</param>
        /// <returns>this instance</returns>
        public OrderItem WithConditionNote(String conditionNote)
        {
            this.conditionNoteField = conditionNote;
            return this;
        }

        /// <summary>
        /// Checks if ConditionNote property is set
        /// </summary>
        /// <returns>true if ConditionNote property is set</returns>
        public Boolean IsSetConditionNote()
        {
            return this.conditionNoteField != null;
        }


        /// <summary>
        /// Gets and sets the ConditionId property.
        /// </summary>
        [XmlElement(ElementName = "ConditionId")]
        public String ConditionId
        {
            get { return this.conditionIdField ; }
            set { this.conditionIdField = value; }
        }

        /// <summary>
        /// Sets the ConditionId property
        /// </summary>
        /// <param name="conditionId">ConditionId property</param>
        /// <returns>this instance</returns>
        public OrderItem WithConditionId(String conditionId)
        {
            this.conditionIdField = conditionId;
            return this;
        }

        /// <summary>
        /// Checks if ConditionId property is set
        /// </summary>
        /// <returns>true if ConditionId property is set</returns>
        public Boolean IsSetConditionId()
        {
            return this.conditionIdField != null;
        }



        /// <summary>
        /// Gets and sets the ConditionSubtypeId property.
        /// </summary>
        [XmlElement(ElementName = "ConditionSubtypeId")]
        public String ConditionSubtypeId
        {
            get { return this.conditionSubtypeIdField ; }
            set { this.conditionSubtypeIdField = value; }
        }

        /// <summary>
        /// Sets the ConditionSubtypeId property
        /// </summary>
        /// <param name="conditionSubtypeId">ConditionSubtypeId property</param>
        /// <returns>this instance</returns>
        public OrderItem WithConditionSubtypeId(String conditionSubtypeId)
        {
            this.conditionSubtypeIdField = conditionSubtypeId;
            return this;
        }

        /// <summary>
        /// Checks if ConditionSubtypeId property is set
        /// </summary>
        /// <returns>true if ConditionSubtypeId property is set</returns>
        public Boolean IsSetConditionSubtypeId()
        {
            return this.conditionSubtypeIdField != null;
        }



        /// <summary>
        /// Gets and sets the ScheduledDeliveryStartDate property.
        /// </summary>
        [XmlElement(ElementName = "ScheduledDeliveryStartDate")]
        public String ScheduledDeliveryStartDate
        {
            get { return this.scheduledDeliveryStartDateField ; }
            set { this.scheduledDeliveryStartDateField = value; }
        }

        /// <summary>
        /// Sets the ScheduledDeliveryStartDate property
        /// </summary>
        /// <param name="scheduledDeliveryStartDate">ScheduledDeliveryStartDate property</param>
        /// <returns>this instance</returns>
        public OrderItem WithScheduledDeliveryStartData(String scheduledDeliveryStartDate)
        {
            this.scheduledDeliveryStartDateField = scheduledDeliveryStartDate;
            return this;
        }

        /// <summary>
        /// Checks if ScheduledDeliveryStartDate property is set
        /// </summary>
        /// <returns>true if ScheduledDeliveryStartDate property is set</returns>
        public Boolean IsSetScheduledDeliveryStartDate()
        {
            return this.scheduledDeliveryStartDateField != null;
        }


        /// <summary>
        /// Gets and sets the ScheduledDeliveryEndDate property.
        /// </summary>
        [XmlElement(ElementName = "ScheduledDeliveryEndDate")]
        public String ScheduledDeliveryEndDate
        {
            get { return this.scheduledDeliveryEndDateField ; }
            set { this.scheduledDeliveryEndDateField = value; }
        }

        /// <summary>
        /// Sets the ScheduledDeliveryEndDate property
        /// </summary>
        /// <param name="scheduledDeliveryEndDate">ScheduledDeliveryEndDate property</param>
        /// <returns>this instance</returns>
        public OrderItem WithScheduledDeliveryEndDate(String scheduledDeliveryEndDate)
        {
            this.scheduledDeliveryEndDateField = scheduledDeliveryEndDate;
            return this;
        }

        /// <summary>
        /// Checks if ScheduledDeliveryEndDate property is set
        /// </summary>
        /// <returns>true if ScheduledDeliveryEndDate property is set</returns>
        public Boolean IsSetScheduledDeliveryEndDate()
        {
            return this.scheduledDeliveryEndDateField != null;
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
            if (this.IsSetASIN()) {
                xml.Append("<ASIN>");
                xml.Append(this.EscapeXML(this.ASIN));
                xml.Append("</ASIN>");
            }
            if (this.IsSetSellerSKU()) {
                xml.Append("<SellerSKU>");
                xml.Append(this.EscapeXML(this.SellerSKU));
                xml.Append("</SellerSKU>");
            }
            if (this.IsSetOrderItemId()) {
                xml.Append("<OrderItemId>");
                xml.Append(this.EscapeXML(this.OrderItemId));
                xml.Append("</OrderItemId>");
            }
            if (this.IsSetTitle()) {
                xml.Append("<Title>");
                xml.Append(this.EscapeXML(this.Title));
                xml.Append("</Title>");
            }
            if (this.IsSetQuantityOrdered()) {
                xml.Append("<QuantityOrdered>");
                xml.Append(this.QuantityOrdered);
                xml.Append("</QuantityOrdered>");
            }
            if (this.IsSetQuantityShipped()) {
                xml.Append("<QuantityShipped>");
                xml.Append(this.QuantityShipped);
                xml.Append("</QuantityShipped>");
            }
            if (this.IsSetItemPrice()) {
                Money  itemPriceObj = this.ItemPrice;
                xml.Append("<ItemPrice>");
                xml.Append(itemPriceObj.ToXMLFragment());
                xml.Append("</ItemPrice>");
            } 
            if (this.IsSetShippingPrice()) {
                Money  shippingPriceObj = this.ShippingPrice;
                xml.Append("<ShippingPrice>");
                xml.Append(shippingPriceObj.ToXMLFragment());
                xml.Append("</ShippingPrice>");
            } 
            if (this.IsSetGiftWrapPrice()) {
                Money  giftWrapPriceObj = this.GiftWrapPrice;
                xml.Append("<GiftWrapPrice>");
                xml.Append(giftWrapPriceObj.ToXMLFragment());
                xml.Append("</GiftWrapPrice>");
            } 
            if (this.IsSetItemTax()) {
                Money  itemTaxObj = this.ItemTax;
                xml.Append("<ItemTax>");
                xml.Append(itemTaxObj.ToXMLFragment());
                xml.Append("</ItemTax>");
            } 
            if (this.IsSetShippingTax()) {
                Money  shippingTaxObj = this.ShippingTax;
                xml.Append("<ShippingTax>");
                xml.Append(shippingTaxObj.ToXMLFragment());
                xml.Append("</ShippingTax>");
            } 
            if (this.IsSetGiftWrapTax()) {
                Money  giftWrapTaxObj = this.GiftWrapTax;
                xml.Append("<GiftWrapTax>");
                xml.Append(giftWrapTaxObj.ToXMLFragment());
                xml.Append("</GiftWrapTax>");
            } 
            if (this.IsSetShippingDiscount()) {
                Money  shippingDiscountObj = this.ShippingDiscount;
                xml.Append("<ShippingDiscount>");
                xml.Append(shippingDiscountObj.ToXMLFragment());
                xml.Append("</ShippingDiscount>");
            } 
            if (this.IsSetPromotionDiscount()) {
                Money  promotionDiscountObj = this.PromotionDiscount;
                xml.Append("<PromotionDiscount>");
                xml.Append(promotionDiscountObj.ToXMLFragment());
                xml.Append("</PromotionDiscount>");
            } 
            if (this.IsSetPromotionIds()) {
                PromotionIdList  promotionIdsObj = this.PromotionIds;
                xml.Append("<PromotionIds>");
                xml.Append(promotionIdsObj.ToXMLFragment());
                xml.Append("</PromotionIds>");
            } 
            if (this.IsSetCODFee()) {
                Money  CODFeeObj = this.CODFee;
                xml.Append("<CODFee>");
                xml.Append(CODFeeObj.ToXMLFragment());
                xml.Append("</CODFee>");
            } 
            if (this.IsSetCODFeeDiscount()) {
                Money  CODFeeDiscountObj = this.CODFeeDiscount;
                xml.Append("<CODFeeDiscount>");
                xml.Append(CODFeeDiscountObj.ToXMLFragment());
                xml.Append("</CODFeeDiscount>");
            } 
            if (this.IsSetGiftMessageText()) {
                xml.Append("<GiftMessageText>");
                xml.Append(this.EscapeXML(this.GiftMessageText));
                xml.Append("</GiftMessageText>");
            }
            if (this.IsSetGiftWrapLevel()) {
                xml.Append("<GiftWrapLevel>");
                xml.Append(this.EscapeXML(this.GiftWrapLevel));
                xml.Append("</GiftWrapLevel>");
            }
            if (this.IsSetInvoiceData()) {
                InvoiceData  invoiceDataObj = this.InvoiceData;
                xml.Append("<InvoiceData>");
                xml.Append(invoiceDataObj.ToXMLFragment());
                xml.Append("</InvoiceData>");
            } 
            if (this.IsSetConditionNote()) {
                xml.Append("<ConditionNote>");
                xml.Append(this.EscapeXML(this.ConditionNote));
                xml.Append("</ConditionNote>");
            }
            if (this.IsSetConditionId()) {
                xml.Append("<ConditionId>");
                xml.Append(this.EscapeXML(this.ConditionId));
                xml.Append("</ConditionId>");
            }
            if (this.IsSetConditionSubtypeId()) {
                xml.Append("<ConditionSubtypeId>");
                xml.Append(this.EscapeXML(this.ConditionSubtypeId));
                xml.Append("</ConditionSubtypeId>");
            }
            if (this.IsSetScheduledDeliveryStartDate()) {
                xml.Append("<ScheduledDeliveryStartDate>");
                xml.Append(this.EscapeXML(this.ScheduledDeliveryStartDate));
                xml.Append("</ScheduledDeliveryStartDate>");
            }
            if (this.IsSetScheduledDeliveryEndDate()) {
                xml.Append("<ScheduledDeliveryEndDate>");
                xml.Append(this.EscapeXML(this.ScheduledDeliveryEndDate));
                xml.Append("</ScheduledDeliveryEndDate>");
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
            if (this.IsSetTitle())
            {
                result.Append("Title: ");
                result.AppendLine(this.Title);
            }
            if (this.IsSetASIN())
            {
                result.Append("ASIN: ");
                result.AppendLine(this.ASIN);
            }
            if (this.IsSetSellerSKU())
            {
                result.Append("SKU: ");
                result.AppendLine(this.SellerSKU);
            } 
            if (this.IsSetItemPrice())
            {
                result.Append("Price: ");
                result.AppendLine(this.ItemPrice.ToString());
            }
            if (this.IsSetItemTax())
            {
                result.Append("Item Tax: ");
                result.AppendLine(this.ItemTax.ToString());
            }
            if (this.IsSetPromotionDiscount())
            {
                result.Append("Promotions Discount: ");
                result.AppendLine(this.PromotionDiscount.ToString());
            }
            if (this.IsSetPromotionIds())
            {
                if (this.PromotionIds.PromotionId != null)
                {
                    foreach (string promotionId in this.PromotionIds.PromotionId)
                    {
                        result.Append("\tPromotion Id: ");
                        result.AppendLine(promotionId);
                    }
                }
            }
            if (this.IsSetShippingDiscount())
            {
                result.Append("Shipping Discount: ");
                result.AppendLine(this.ShippingDiscount.ToString());
            }
            if (this.IsSetQuantityOrdered())
            {
                result.Append("Quantity: ");
                result.AppendLine(this.QuantityOrdered.ToString());
            }
            if (this.IsSetQuantityShipped())
            {
                result.Append("Quantity Shipped: ");
                result.AppendLine(this.QuantityShipped.ToString());
            }
            if (this.IsSetCODFee())
            {
                result.Append("COD Fee: ");
                result.AppendLine(this.CODFee.ToString());
            }
            if (this.IsSetCODFeeDiscount())
            {
                result.Append("COD Fee Discount: ");
                result.AppendLine(this.CODFeeDiscount.ToString());
            }
            if (this.IsSetGiftMessageText())
            {
                result.Append("Gift Message Text: ");
                result.AppendLine(this.GiftMessageText);
            }
            if (this.IsSetGiftWrapPrice())
            {
                result.Append("Gift Wrap Price: ");
                result.AppendLine(this.GiftWrapPrice.ToString());
            }
            if (this.IsSetGiftWrapLevel())
            {
                result.Append("Gift Wrap Level: ");
                result.AppendLine(this.GiftWrapLevel.ToString());
            }
            if (this.IsSetConditionNote()) {
                result.Append("ConditionNote: ");
                result.AppendLine(this.EscapeXML(this.ConditionNote));
            }
            if (this.IsSetConditionId()) {
                result.Append("ConditionId: ");
                result.AppendLine(this.EscapeXML(this.ConditionId));
            }
            if (this.IsSetConditionSubtypeId()) {
                result.Append("ConditionSubtypeId: ");
                result.AppendLine(this.EscapeXML(this.ConditionSubtypeId));
            }
            if (this.IsSetScheduledDeliveryStartDate()) {
                result.Append("ScheduledDeliveryStartDate: ");
                result.AppendLine(this.EscapeXML(this.ScheduledDeliveryStartDate));
            }
            if (this.IsSetScheduledDeliveryEndDate()) {
                result.Append("ScheduledDeliveryEndDate: ");
                result.AppendLine(this.EscapeXML(this.ScheduledDeliveryEndDate));
            }
            return result.ToString();
        }


    }

}