/*******************************************************************************
 * Copyright 2009-2015 Amazon Services. All Rights Reserved.
 * Licensed under the Apache License, Version 2.0 (the "License"); 
 *
 * You may not use this file except in compliance with the License. 
 * You may obtain a copy of the License at: http://aws.amazon.com/apache2.0
 * This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
 * CONDITIONS OF ANY KIND, either express or implied. See the License for the 
 * specific language governing permissions and limitations under the License.
 *******************************************************************************
 * List Orders Request
 * API Version: 2013-09-01
 * Library Version: 2015-03-05
 * Generated: Tue Mar 03 22:11:26 GMT 2015
 */

using System;
using System.Collections.Generic;
using AmazonAccess.Services.Common;

namespace AmazonAccess.Services.MarketplaceWebServiceOrders.Model
{
    public class ListOrdersRequest : AbstractMwsObject
    {

        private string _sellerId;
        private string _mwsAuthToken;
        private DateTime? _createdAfter;
        private DateTime? _createdBefore;
        private DateTime? _lastUpdatedAfter;
        private DateTime? _lastUpdatedBefore;
        private List<string> _orderStatus;
        private List<string> _marketplaceId;
        private List<string> _fulfillmentChannel;
        private List<string> _paymentMethod;
        private string _buyerEmail;
        private string _sellerOrderId;
        private decimal? _maxResultsPerPage;
        private List<string> _tfmShipmentStatus;

        /// <summary>
        /// Gets and sets the SellerId property.
        /// </summary>
        public string SellerId
        {
            get { return this._sellerId; }
            set { this._sellerId = value; }
        }

        /// <summary>
        /// Sets the SellerId property.
        /// </summary>
        /// <param name="sellerId">SellerId property.</param>
        /// <returns>this instance.</returns>
        public ListOrdersRequest WithSellerId(string sellerId)
        {
            this._sellerId = sellerId;
            return this;
        }

        /// <summary>
        /// Checks if SellerId property is set.
        /// </summary>
        /// <returns>true if SellerId property is set.</returns>
        public bool IsSetSellerId()
        {
            return this._sellerId != null;
        }

        /// <summary>
        /// Gets and sets the MWSAuthToken property.
        /// </summary>
        public string MWSAuthToken
        {
            get { return this._mwsAuthToken; }
            set { this._mwsAuthToken = value; }
        }

        /// <summary>
        /// Sets the MWSAuthToken property.
        /// </summary>
        /// <param name="mwsAuthToken">MWSAuthToken property.</param>
        /// <returns>this instance.</returns>
        public ListOrdersRequest WithMWSAuthToken(string mwsAuthToken)
        {
            this._mwsAuthToken = mwsAuthToken;
            return this;
        }

        /// <summary>
        /// Checks if MWSAuthToken property is set.
        /// </summary>
        /// <returns>true if MWSAuthToken property is set.</returns>
        public bool IsSetMWSAuthToken()
        {
            return this._mwsAuthToken != null;
        }

        /// <summary>
        /// Gets and sets the CreatedAfter property.
        /// </summary>
        public DateTime CreatedAfter
        {
            get { return this._createdAfter.GetValueOrDefault(); }
            set { this._createdAfter = value; }
        }

        /// <summary>
        /// Sets the CreatedAfter property.
        /// </summary>
        /// <param name="createdAfter">CreatedAfter property.</param>
        /// <returns>this instance.</returns>
        public ListOrdersRequest WithCreatedAfter(DateTime createdAfter)
        {
            this._createdAfter = createdAfter;
            return this;
        }

        /// <summary>
        /// Checks if CreatedAfter property is set.
        /// </summary>
        /// <returns>true if CreatedAfter property is set.</returns>
        public bool IsSetCreatedAfter()
        {
            return this._createdAfter != null;
        }

        /// <summary>
        /// Gets and sets the CreatedBefore property.
        /// </summary>
        public DateTime CreatedBefore
        {
            get { return this._createdBefore.GetValueOrDefault(); }
            set { this._createdBefore = value; }
        }

        /// <summary>
        /// Sets the CreatedBefore property.
        /// </summary>
        /// <param name="createdBefore">CreatedBefore property.</param>
        /// <returns>this instance.</returns>
        public ListOrdersRequest WithCreatedBefore(DateTime createdBefore)
        {
            this._createdBefore = createdBefore;
            return this;
        }

        /// <summary>
        /// Checks if CreatedBefore property is set.
        /// </summary>
        /// <returns>true if CreatedBefore property is set.</returns>
        public bool IsSetCreatedBefore()
        {
            return this._createdBefore != null;
        }

        /// <summary>
        /// Gets and sets the LastUpdatedAfter property.
        /// </summary>
        public DateTime LastUpdatedAfter
        {
            get { return this._lastUpdatedAfter.GetValueOrDefault(); }
            set { this._lastUpdatedAfter = value; }
        }

        /// <summary>
        /// Sets the LastUpdatedAfter property.
        /// </summary>
        /// <param name="lastUpdatedAfter">LastUpdatedAfter property.</param>
        /// <returns>this instance.</returns>
        public ListOrdersRequest WithLastUpdatedAfter(DateTime lastUpdatedAfter)
        {
            this._lastUpdatedAfter = lastUpdatedAfter;
            return this;
        }

        /// <summary>
        /// Checks if LastUpdatedAfter property is set.
        /// </summary>
        /// <returns>true if LastUpdatedAfter property is set.</returns>
        public bool IsSetLastUpdatedAfter()
        {
            return this._lastUpdatedAfter != null;
        }

        /// <summary>
        /// Gets and sets the LastUpdatedBefore property.
        /// </summary>
        public DateTime LastUpdatedBefore
        {
            get { return this._lastUpdatedBefore.GetValueOrDefault(); }
            set { this._lastUpdatedBefore = value; }
        }

        /// <summary>
        /// Sets the LastUpdatedBefore property.
        /// </summary>
        /// <param name="lastUpdatedBefore">LastUpdatedBefore property.</param>
        /// <returns>this instance.</returns>
        public ListOrdersRequest WithLastUpdatedBefore(DateTime lastUpdatedBefore)
        {
            this._lastUpdatedBefore = lastUpdatedBefore;
            return this;
        }

        /// <summary>
        /// Checks if LastUpdatedBefore property is set.
        /// </summary>
        /// <returns>true if LastUpdatedBefore property is set.</returns>
        public bool IsSetLastUpdatedBefore()
        {
            return this._lastUpdatedBefore != null;
        }

        /// <summary>
        /// Gets and sets the OrderStatus property.
        /// </summary>
        public List<string> OrderStatus
        {
            get
            {
                if(this._orderStatus == null)
                {
                    this._orderStatus = new List<string>();
                }
                return this._orderStatus;
            }
            set { this._orderStatus = value; }
        }

        /// <summary>
        /// Sets the OrderStatus property.
        /// </summary>
        /// <param name="orderStatus">OrderStatus property.</param>
        /// <returns>this instance.</returns>
        public ListOrdersRequest WithOrderStatus(string[] orderStatus)
        {
            this._orderStatus.AddRange(orderStatus);
            return this;
        }

        /// <summary>
        /// Checks if OrderStatus property is set.
        /// </summary>
        /// <returns>true if OrderStatus property is set.</returns>
        public bool IsSetOrderStatus()
        {
            return this.OrderStatus.Count > 0;
        }

        /// <summary>
        /// Gets and sets the MarketplaceId property.
        /// </summary>
        public List<string> MarketplaceId
        {
            get
            {
                if(this._marketplaceId == null)
                {
                    this._marketplaceId = new List<string>();
                }
                return this._marketplaceId;
            }
            set { this._marketplaceId = value; }
        }

        /// <summary>
        /// Sets the MarketplaceId property.
        /// </summary>
        /// <param name="marketplaceId">MarketplaceId property.</param>
        /// <returns>this instance.</returns>
        public ListOrdersRequest WithMarketplaceId(string[] marketplaceId)
        {
            this._marketplaceId.AddRange(marketplaceId);
            return this;
        }

        /// <summary>
        /// Checks if MarketplaceId property is set.
        /// </summary>
        /// <returns>true if MarketplaceId property is set.</returns>
        public bool IsSetMarketplaceId()
        {
            return this.MarketplaceId.Count > 0;
        }

        /// <summary>
        /// Gets and sets the FulfillmentChannel property.
        /// </summary>
        public List<string> FulfillmentChannel
        {
            get
            {
                if(this._fulfillmentChannel == null)
                {
                    this._fulfillmentChannel = new List<string>();
                }
                return this._fulfillmentChannel;
            }
            set { this._fulfillmentChannel = value; }
        }

        /// <summary>
        /// Sets the FulfillmentChannel property.
        /// </summary>
        /// <param name="fulfillmentChannel">FulfillmentChannel property.</param>
        /// <returns>this instance.</returns>
        public ListOrdersRequest WithFulfillmentChannel(string[] fulfillmentChannel)
        {
            this._fulfillmentChannel.AddRange(fulfillmentChannel);
            return this;
        }

        /// <summary>
        /// Checks if FulfillmentChannel property is set.
        /// </summary>
        /// <returns>true if FulfillmentChannel property is set.</returns>
        public bool IsSetFulfillmentChannel()
        {
            return this.FulfillmentChannel.Count > 0;
        }

        /// <summary>
        /// Gets and sets the PaymentMethod property.
        /// </summary>
        public List<string> PaymentMethod
        {
            get
            {
                if(this._paymentMethod == null)
                {
                    this._paymentMethod = new List<string>();
                }
                return this._paymentMethod;
            }
            set { this._paymentMethod = value; }
        }

        /// <summary>
        /// Sets the PaymentMethod property.
        /// </summary>
        /// <param name="paymentMethod">PaymentMethod property.</param>
        /// <returns>this instance.</returns>
        public ListOrdersRequest WithPaymentMethod(string[] paymentMethod)
        {
            this._paymentMethod.AddRange(paymentMethod);
            return this;
        }

        /// <summary>
        /// Checks if PaymentMethod property is set.
        /// </summary>
        /// <returns>true if PaymentMethod property is set.</returns>
        public bool IsSetPaymentMethod()
        {
            return this.PaymentMethod.Count > 0;
        }

        /// <summary>
        /// Gets and sets the BuyerEmail property.
        /// </summary>
        public string BuyerEmail
        {
            get { return this._buyerEmail; }
            set { this._buyerEmail = value; }
        }

        /// <summary>
        /// Sets the BuyerEmail property.
        /// </summary>
        /// <param name="buyerEmail">BuyerEmail property.</param>
        /// <returns>this instance.</returns>
        public ListOrdersRequest WithBuyerEmail(string buyerEmail)
        {
            this._buyerEmail = buyerEmail;
            return this;
        }

        /// <summary>
        /// Checks if BuyerEmail property is set.
        /// </summary>
        /// <returns>true if BuyerEmail property is set.</returns>
        public bool IsSetBuyerEmail()
        {
            return this._buyerEmail != null;
        }

        /// <summary>
        /// Gets and sets the SellerOrderId property.
        /// </summary>
        public string SellerOrderId
        {
            get { return this._sellerOrderId; }
            set { this._sellerOrderId = value; }
        }

        /// <summary>
        /// Sets the SellerOrderId property.
        /// </summary>
        /// <param name="sellerOrderId">SellerOrderId property.</param>
        /// <returns>this instance.</returns>
        public ListOrdersRequest WithSellerOrderId(string sellerOrderId)
        {
            this._sellerOrderId = sellerOrderId;
            return this;
        }

        /// <summary>
        /// Checks if SellerOrderId property is set.
        /// </summary>
        /// <returns>true if SellerOrderId property is set.</returns>
        public bool IsSetSellerOrderId()
        {
            return this._sellerOrderId != null;
        }

        /// <summary>
        /// Gets and sets the MaxResultsPerPage property.
        /// </summary>
        public decimal MaxResultsPerPage
        {
            get { return this._maxResultsPerPage.GetValueOrDefault(); }
            set { this._maxResultsPerPage = value; }
        }

        /// <summary>
        /// Sets the MaxResultsPerPage property.
        /// </summary>
        /// <param name="maxResultsPerPage">MaxResultsPerPage property.</param>
        /// <returns>this instance.</returns>
        public ListOrdersRequest WithMaxResultsPerPage(decimal maxResultsPerPage)
        {
            this._maxResultsPerPage = maxResultsPerPage;
            return this;
        }

        /// <summary>
        /// Checks if MaxResultsPerPage property is set.
        /// </summary>
        /// <returns>true if MaxResultsPerPage property is set.</returns>
        public bool IsSetMaxResultsPerPage()
        {
            return this._maxResultsPerPage != null;
        }

        /// <summary>
        /// Gets and sets the TFMShipmentStatus property.
        /// </summary>
        public List<string> TFMShipmentStatus
        {
            get
            {
                if(this._tfmShipmentStatus == null)
                {
                    this._tfmShipmentStatus = new List<string>();
                }
                return this._tfmShipmentStatus;
            }
            set { this._tfmShipmentStatus = value; }
        }

        /// <summary>
        /// Sets the TFMShipmentStatus property.
        /// </summary>
        /// <param name="tfmShipmentStatus">TFMShipmentStatus property.</param>
        /// <returns>this instance.</returns>
        public ListOrdersRequest WithTFMShipmentStatus(string[] tfmShipmentStatus)
        {
            this._tfmShipmentStatus.AddRange(tfmShipmentStatus);
            return this;
        }

        /// <summary>
        /// Checks if TFMShipmentStatus property is set.
        /// </summary>
        /// <returns>true if TFMShipmentStatus property is set.</returns>
        public bool IsSetTFMShipmentStatus()
        {
            return this.TFMShipmentStatus.Count > 0;
        }


        public override void ReadFragmentFrom(IMwsReader reader)
        {
            this._sellerId = reader.Read<string>("SellerId");
            this._mwsAuthToken = reader.Read<string>("MWSAuthToken");
            this._createdAfter = reader.Read<DateTime?>("CreatedAfter");
            this._createdBefore = reader.Read<DateTime?>("CreatedBefore");
            this._lastUpdatedAfter = reader.Read<DateTime?>("LastUpdatedAfter");
            this._lastUpdatedBefore = reader.Read<DateTime?>("LastUpdatedBefore");
            this._orderStatus = reader.ReadList<string>("OrderStatus", "Status");
            this._marketplaceId = reader.ReadList<string>("MarketplaceId", "Id");
            this._fulfillmentChannel = reader.ReadList<string>("FulfillmentChannel", "Channel");
            this._paymentMethod = reader.ReadList<string>("PaymentMethod", "Method");
            this._buyerEmail = reader.Read<string>("BuyerEmail");
            this._sellerOrderId = reader.Read<string>("SellerOrderId");
            this._maxResultsPerPage = reader.Read<decimal?>("MaxResultsPerPage");
            this._tfmShipmentStatus = reader.ReadList<string>("TFMShipmentStatus", "Status");
        }

        public override void WriteFragmentTo(IMwsWriter writer)
        {
            writer.Write("SellerId", this._sellerId);
            writer.Write("MWSAuthToken", this._mwsAuthToken);
            writer.Write("CreatedAfter", this._createdAfter);
            writer.Write("CreatedBefore", this._createdBefore);
            writer.Write("LastUpdatedAfter", this._lastUpdatedAfter);
            writer.Write("LastUpdatedBefore", this._lastUpdatedBefore);
            writer.WriteList("OrderStatus", "Status", this._orderStatus);
            writer.WriteList("MarketplaceId", "Id", this._marketplaceId);
            writer.WriteList("FulfillmentChannel", "Channel", this._fulfillmentChannel);
            writer.WriteList("PaymentMethod", "Method", this._paymentMethod);
            writer.Write("BuyerEmail", this._buyerEmail);
            writer.Write("SellerOrderId", this._sellerOrderId);
            writer.Write("MaxResultsPerPage", this._maxResultsPerPage);
            writer.WriteList("TFMShipmentStatus", "Status", this._tfmShipmentStatus);
        }

        public override void WriteTo(IMwsWriter writer)
        {
            writer.Write("https://mws.amazonservices.com/Orders/2013-09-01", "ListOrdersRequest", this);
        }

        public ListOrdersRequest() : base()
        {
        }
    }
}
