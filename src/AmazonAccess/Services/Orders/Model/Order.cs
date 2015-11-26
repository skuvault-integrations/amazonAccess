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
 * Order
 * API Version: 2013-09-01
 * Library Version: 2015-09-24
 * Generated: Fri Sep 25 20:06:25 GMT 2015
 */

using System;
using System.Collections.Generic;
using AmazonAccess.Services.Common;

namespace AmazonAccess.Services.Orders.Model
{
	public class Order: AbstractMwsObject
	{
		private DateTime? _purchaseDate;
		private DateTime? _lastUpdateDate;
		private decimal? _numberOfItemsShipped;
		private decimal? _numberOfItemsUnshipped;
		private List< PaymentExecutionDetailItem > _paymentExecutionDetail;
		private bool? _shippedByAmazonTFM;
		private DateTime? _earliestShipDate;
		private DateTime? _latestShipDate;
		private DateTime? _earliestDeliveryDate;
		private DateTime? _latestDeliveryDate;
		private bool? _isBusinessOrder;
		private bool? _isPrime;
		private bool? _isPremiumOrder;

		/// <summary>
		/// Gets and sets the AmazonOrderId property.
		/// </summary>
		public string AmazonOrderId{ get; set; }

		/// <summary>
		/// Sets the AmazonOrderId property.
		/// </summary>
		/// <param name="amazonOrderId">AmazonOrderId property.</param>
		/// <returns>this instance.</returns>
		public Order WithAmazonOrderId( string amazonOrderId )
		{
			this.AmazonOrderId = amazonOrderId;
			return this;
		}

		/// <summary>
		/// Checks if AmazonOrderId property is set.
		/// </summary>
		/// <returns>true if AmazonOrderId property is set.</returns>
		public bool IsSetAmazonOrderId()
		{
			return this.AmazonOrderId != null;
		}

		/// <summary>
		/// Gets and sets the SellerOrderId property.
		/// </summary>
		public string SellerOrderId{ get; set; }

		/// <summary>
		/// Sets the SellerOrderId property.
		/// </summary>
		/// <param name="sellerOrderId">SellerOrderId property.</param>
		/// <returns>this instance.</returns>
		public Order WithSellerOrderId( string sellerOrderId )
		{
			this.SellerOrderId = sellerOrderId;
			return this;
		}

		/// <summary>
		/// Checks if SellerOrderId property is set.
		/// </summary>
		/// <returns>true if SellerOrderId property is set.</returns>
		public bool IsSetSellerOrderId()
		{
			return this.SellerOrderId != null;
		}

		/// <summary>
		/// Gets and sets the PurchaseDate property.
		/// </summary>
		public DateTime PurchaseDate
		{
			get { return this._purchaseDate.GetValueOrDefault(); }
			set { this._purchaseDate = value; }
		}

		/// <summary>
		/// Sets the PurchaseDate property.
		/// </summary>
		/// <param name="purchaseDate">PurchaseDate property.</param>
		/// <returns>this instance.</returns>
		public Order WithPurchaseDate( DateTime purchaseDate )
		{
			this._purchaseDate = purchaseDate;
			return this;
		}

		/// <summary>
		/// Checks if PurchaseDate property is set.
		/// </summary>
		/// <returns>true if PurchaseDate property is set.</returns>
		public bool IsSetPurchaseDate()
		{
			return this._purchaseDate != null;
		}

		/// <summary>
		/// Gets and sets the LastUpdateDate property.
		/// </summary>
		public DateTime LastUpdateDate
		{
			get { return this._lastUpdateDate.GetValueOrDefault(); }
			set { this._lastUpdateDate = value; }
		}

		/// <summary>
		/// Sets the LastUpdateDate property.
		/// </summary>
		/// <param name="lastUpdateDate">LastUpdateDate property.</param>
		/// <returns>this instance.</returns>
		public Order WithLastUpdateDate( DateTime lastUpdateDate )
		{
			this._lastUpdateDate = lastUpdateDate;
			return this;
		}

		/// <summary>
		/// Checks if LastUpdateDate property is set.
		/// </summary>
		/// <returns>true if LastUpdateDate property is set.</returns>
		public bool IsSetLastUpdateDate()
		{
			return this._lastUpdateDate != null;
		}

		/// <summary>
		/// Gets and sets the OrderStatus property.
		/// </summary>
		public string OrderStatus{ get; set; }

		/// <summary>
		/// Sets the OrderStatus property.
		/// </summary>
		/// <param name="orderStatus">OrderStatus property.</param>
		/// <returns>this instance.</returns>
		public Order WithOrderStatus( string orderStatus )
		{
			this.OrderStatus = orderStatus;
			return this;
		}

		/// <summary>
		/// Checks if OrderStatus property is set.
		/// </summary>
		/// <returns>true if OrderStatus property is set.</returns>
		public bool IsSetOrderStatus()
		{
			return this.OrderStatus != null;
		}

		/// <summary>
		/// Gets and sets the FulfillmentChannel property.
		/// </summary>
		public string FulfillmentChannel{ get; set; }

		/// <summary>
		/// Sets the FulfillmentChannel property.
		/// </summary>
		/// <param name="fulfillmentChannel">FulfillmentChannel property.</param>
		/// <returns>this instance.</returns>
		public Order WithFulfillmentChannel( string fulfillmentChannel )
		{
			this.FulfillmentChannel = fulfillmentChannel;
			return this;
		}

		/// <summary>
		/// Checks if FulfillmentChannel property is set.
		/// </summary>
		/// <returns>true if FulfillmentChannel property is set.</returns>
		public bool IsSetFulfillmentChannel()
		{
			return this.FulfillmentChannel != null;
		}

		/// <summary>
		/// Gets and sets the SalesChannel property.
		/// </summary>
		public string SalesChannel{ get; set; }

		/// <summary>
		/// Sets the SalesChannel property.
		/// </summary>
		/// <param name="salesChannel">SalesChannel property.</param>
		/// <returns>this instance.</returns>
		public Order WithSalesChannel( string salesChannel )
		{
			this.SalesChannel = salesChannel;
			return this;
		}

		/// <summary>
		/// Checks if SalesChannel property is set.
		/// </summary>
		/// <returns>true if SalesChannel property is set.</returns>
		public bool IsSetSalesChannel()
		{
			return this.SalesChannel != null;
		}

		/// <summary>
		/// Gets and sets the OrderChannel property.
		/// </summary>
		public string OrderChannel{ get; set; }

		/// <summary>
		/// Sets the OrderChannel property.
		/// </summary>
		/// <param name="orderChannel">OrderChannel property.</param>
		/// <returns>this instance.</returns>
		public Order WithOrderChannel( string orderChannel )
		{
			this.OrderChannel = orderChannel;
			return this;
		}

		/// <summary>
		/// Checks if OrderChannel property is set.
		/// </summary>
		/// <returns>true if OrderChannel property is set.</returns>
		public bool IsSetOrderChannel()
		{
			return this.OrderChannel != null;
		}

		/// <summary>
		/// Gets and sets the ShipServiceLevel property.
		/// </summary>
		public string ShipServiceLevel{ get; set; }

		/// <summary>
		/// Sets the ShipServiceLevel property.
		/// </summary>
		/// <param name="shipServiceLevel">ShipServiceLevel property.</param>
		/// <returns>this instance.</returns>
		public Order WithShipServiceLevel( string shipServiceLevel )
		{
			this.ShipServiceLevel = shipServiceLevel;
			return this;
		}

		/// <summary>
		/// Checks if ShipServiceLevel property is set.
		/// </summary>
		/// <returns>true if ShipServiceLevel property is set.</returns>
		public bool IsSetShipServiceLevel()
		{
			return this.ShipServiceLevel != null;
		}

		/// <summary>
		/// Gets and sets the ShippingAddress property.
		/// </summary>
		public Address ShippingAddress{ get; set; }

		/// <summary>
		/// Sets the ShippingAddress property.
		/// </summary>
		/// <param name="shippingAddress">ShippingAddress property.</param>
		/// <returns>this instance.</returns>
		public Order WithShippingAddress( Address shippingAddress )
		{
			this.ShippingAddress = shippingAddress;
			return this;
		}

		/// <summary>
		/// Checks if ShippingAddress property is set.
		/// </summary>
		/// <returns>true if ShippingAddress property is set.</returns>
		public bool IsSetShippingAddress()
		{
			return this.ShippingAddress != null;
		}

		/// <summary>
		/// Gets and sets the OrderTotal property.
		/// </summary>
		public Money OrderTotal{ get; set; }

		/// <summary>
		/// Sets the OrderTotal property.
		/// </summary>
		/// <param name="orderTotal">OrderTotal property.</param>
		/// <returns>this instance.</returns>
		public Order WithOrderTotal( Money orderTotal )
		{
			this.OrderTotal = orderTotal;
			return this;
		}

		/// <summary>
		/// Checks if OrderTotal property is set.
		/// </summary>
		/// <returns>true if OrderTotal property is set.</returns>
		public bool IsSetOrderTotal()
		{
			return this.OrderTotal != null;
		}

		/// <summary>
		/// Gets and sets the NumberOfItemsShipped property.
		/// </summary>
		public decimal NumberOfItemsShipped
		{
			get { return this._numberOfItemsShipped.GetValueOrDefault(); }
			set { this._numberOfItemsShipped = value; }
		}

		/// <summary>
		/// Sets the NumberOfItemsShipped property.
		/// </summary>
		/// <param name="numberOfItemsShipped">NumberOfItemsShipped property.</param>
		/// <returns>this instance.</returns>
		public Order WithNumberOfItemsShipped( decimal numberOfItemsShipped )
		{
			this._numberOfItemsShipped = numberOfItemsShipped;
			return this;
		}

		/// <summary>
		/// Checks if NumberOfItemsShipped property is set.
		/// </summary>
		/// <returns>true if NumberOfItemsShipped property is set.</returns>
		public bool IsSetNumberOfItemsShipped()
		{
			return this._numberOfItemsShipped != null;
		}

		/// <summary>
		/// Gets and sets the NumberOfItemsUnshipped property.
		/// </summary>
		public decimal NumberOfItemsUnshipped
		{
			get { return this._numberOfItemsUnshipped.GetValueOrDefault(); }
			set { this._numberOfItemsUnshipped = value; }
		}

		/// <summary>
		/// Sets the NumberOfItemsUnshipped property.
		/// </summary>
		/// <param name="numberOfItemsUnshipped">NumberOfItemsUnshipped property.</param>
		/// <returns>this instance.</returns>
		public Order WithNumberOfItemsUnshipped( decimal numberOfItemsUnshipped )
		{
			this._numberOfItemsUnshipped = numberOfItemsUnshipped;
			return this;
		}

		/// <summary>
		/// Checks if NumberOfItemsUnshipped property is set.
		/// </summary>
		/// <returns>true if NumberOfItemsUnshipped property is set.</returns>
		public bool IsSetNumberOfItemsUnshipped()
		{
			return this._numberOfItemsUnshipped != null;
		}

		/// <summary>
		/// Gets and sets the PaymentExecutionDetail property.
		/// </summary>
		public List< PaymentExecutionDetailItem > PaymentExecutionDetail
		{
			get
			{
				if( this._paymentExecutionDetail == null )
					this._paymentExecutionDetail = new List< PaymentExecutionDetailItem >();
				return this._paymentExecutionDetail;
			}
			set { this._paymentExecutionDetail = value; }
		}

		/// <summary>
		/// Sets the PaymentExecutionDetail property.
		/// </summary>
		/// <param name="paymentExecutionDetail">PaymentExecutionDetail property.</param>
		/// <returns>this instance.</returns>
		public Order WithPaymentExecutionDetail( PaymentExecutionDetailItem[] paymentExecutionDetail )
		{
			this._paymentExecutionDetail.AddRange( paymentExecutionDetail );
			return this;
		}

		/// <summary>
		/// Checks if PaymentExecutionDetail property is set.
		/// </summary>
		/// <returns>true if PaymentExecutionDetail property is set.</returns>
		public bool IsSetPaymentExecutionDetail()
		{
			return this.PaymentExecutionDetail.Count > 0;
		}

		/// <summary>
		/// Gets and sets the PaymentMethod property.
		/// </summary>
		public string PaymentMethod{ get; set; }

		/// <summary>
		/// Sets the PaymentMethod property.
		/// </summary>
		/// <param name="paymentMethod">PaymentMethod property.</param>
		/// <returns>this instance.</returns>
		public Order WithPaymentMethod( string paymentMethod )
		{
			this.PaymentMethod = paymentMethod;
			return this;
		}

		/// <summary>
		/// Checks if PaymentMethod property is set.
		/// </summary>
		/// <returns>true if PaymentMethod property is set.</returns>
		public bool IsSetPaymentMethod()
		{
			return this.PaymentMethod != null;
		}

		/// <summary>
		/// Gets and sets the MarketplaceId property.
		/// </summary>
		public string MarketplaceId{ get; set; }

		/// <summary>
		/// Sets the MarketplaceId property.
		/// </summary>
		/// <param name="marketplaceId">MarketplaceId property.</param>
		/// <returns>this instance.</returns>
		public Order WithMarketplaceId( string marketplaceId )
		{
			this.MarketplaceId = marketplaceId;
			return this;
		}

		/// <summary>
		/// Checks if MarketplaceId property is set.
		/// </summary>
		/// <returns>true if MarketplaceId property is set.</returns>
		public bool IsSetMarketplaceId()
		{
			return this.MarketplaceId != null;
		}

		/// <summary>
		/// Gets and sets the BuyerEmail property.
		/// </summary>
		public string BuyerEmail{ get; set; }

		/// <summary>
		/// Sets the BuyerEmail property.
		/// </summary>
		/// <param name="buyerEmail">BuyerEmail property.</param>
		/// <returns>this instance.</returns>
		public Order WithBuyerEmail( string buyerEmail )
		{
			this.BuyerEmail = buyerEmail;
			return this;
		}

		/// <summary>
		/// Checks if BuyerEmail property is set.
		/// </summary>
		/// <returns>true if BuyerEmail property is set.</returns>
		public bool IsSetBuyerEmail()
		{
			return this.BuyerEmail != null;
		}

		/// <summary>
		/// Gets and sets the BuyerName property.
		/// </summary>
		public string BuyerName{ get; set; }

		/// <summary>
		/// Sets the BuyerName property.
		/// </summary>
		/// <param name="buyerName">BuyerName property.</param>
		/// <returns>this instance.</returns>
		public Order WithBuyerName( string buyerName )
		{
			this.BuyerName = buyerName;
			return this;
		}

		/// <summary>
		/// Checks if BuyerName property is set.
		/// </summary>
		/// <returns>true if BuyerName property is set.</returns>
		public bool IsSetBuyerName()
		{
			return this.BuyerName != null;
		}

		/// <summary>
		/// Gets and sets the ShipmentServiceLevelCategory property.
		/// </summary>
		public string ShipmentServiceLevelCategory{ get; set; }

		/// <summary>
		/// Sets the ShipmentServiceLevelCategory property.
		/// </summary>
		/// <param name="shipmentServiceLevelCategory">ShipmentServiceLevelCategory property.</param>
		/// <returns>this instance.</returns>
		public Order WithShipmentServiceLevelCategory( string shipmentServiceLevelCategory )
		{
			this.ShipmentServiceLevelCategory = shipmentServiceLevelCategory;
			return this;
		}

		/// <summary>
		/// Checks if ShipmentServiceLevelCategory property is set.
		/// </summary>
		/// <returns>true if ShipmentServiceLevelCategory property is set.</returns>
		public bool IsSetShipmentServiceLevelCategory()
		{
			return this.ShipmentServiceLevelCategory != null;
		}

		/// <summary>
		/// Gets and sets the ShippedByAmazonTFM property.
		/// </summary>
		public bool ShippedByAmazonTFM
		{
			get { return this._shippedByAmazonTFM.GetValueOrDefault(); }
			set { this._shippedByAmazonTFM = value; }
		}

		/// <summary>
		/// Sets the ShippedByAmazonTFM property.
		/// </summary>
		/// <param name="shippedByAmazonTFM">ShippedByAmazonTFM property.</param>
		/// <returns>this instance.</returns>
		public Order WithShippedByAmazonTFM( bool shippedByAmazonTFM )
		{
			this._shippedByAmazonTFM = shippedByAmazonTFM;
			return this;
		}

		/// <summary>
		/// Checks if ShippedByAmazonTFM property is set.
		/// </summary>
		/// <returns>true if ShippedByAmazonTFM property is set.</returns>
		public bool IsSetShippedByAmazonTFM()
		{
			return this._shippedByAmazonTFM != null;
		}

		/// <summary>
		/// Gets and sets the TFMShipmentStatus property.
		/// </summary>
		public string TFMShipmentStatus{ get; set; }

		/// <summary>
		/// Sets the TFMShipmentStatus property.
		/// </summary>
		/// <param name="tfmShipmentStatus">TFMShipmentStatus property.</param>
		/// <returns>this instance.</returns>
		public Order WithTFMShipmentStatus( string tfmShipmentStatus )
		{
			this.TFMShipmentStatus = tfmShipmentStatus;
			return this;
		}

		/// <summary>
		/// Checks if TFMShipmentStatus property is set.
		/// </summary>
		/// <returns>true if TFMShipmentStatus property is set.</returns>
		public bool IsSetTFMShipmentStatus()
		{
			return this.TFMShipmentStatus != null;
		}

		/// <summary>
		/// Gets and sets the CbaDisplayableShippingLabel property.
		/// </summary>
		public string CbaDisplayableShippingLabel{ get; set; }

		/// <summary>
		/// Sets the CbaDisplayableShippingLabel property.
		/// </summary>
		/// <param name="cbaDisplayableShippingLabel">CbaDisplayableShippingLabel property.</param>
		/// <returns>this instance.</returns>
		public Order WithCbaDisplayableShippingLabel( string cbaDisplayableShippingLabel )
		{
			this.CbaDisplayableShippingLabel = cbaDisplayableShippingLabel;
			return this;
		}

		/// <summary>
		/// Checks if CbaDisplayableShippingLabel property is set.
		/// </summary>
		/// <returns>true if CbaDisplayableShippingLabel property is set.</returns>
		public bool IsSetCbaDisplayableShippingLabel()
		{
			return this.CbaDisplayableShippingLabel != null;
		}

		/// <summary>
		/// Gets and sets the OrderType property.
		/// </summary>
		public string OrderType{ get; set; }

		/// <summary>
		/// Sets the OrderType property.
		/// </summary>
		/// <param name="orderType">OrderType property.</param>
		/// <returns>this instance.</returns>
		public Order WithOrderType( string orderType )
		{
			this.OrderType = orderType;
			return this;
		}

		/// <summary>
		/// Checks if OrderType property is set.
		/// </summary>
		/// <returns>true if OrderType property is set.</returns>
		public bool IsSetOrderType()
		{
			return this.OrderType != null;
		}

		/// <summary>
		/// Gets and sets the EarliestShipDate property.
		/// </summary>
		public DateTime EarliestShipDate
		{
			get { return this._earliestShipDate.GetValueOrDefault(); }
			set { this._earliestShipDate = value; }
		}

		/// <summary>
		/// Sets the EarliestShipDate property.
		/// </summary>
		/// <param name="earliestShipDate">EarliestShipDate property.</param>
		/// <returns>this instance.</returns>
		public Order WithEarliestShipDate( DateTime earliestShipDate )
		{
			this._earliestShipDate = earliestShipDate;
			return this;
		}

		/// <summary>
		/// Checks if EarliestShipDate property is set.
		/// </summary>
		/// <returns>true if EarliestShipDate property is set.</returns>
		public bool IsSetEarliestShipDate()
		{
			return this._earliestShipDate != null;
		}

		/// <summary>
		/// Gets and sets the LatestShipDate property.
		/// </summary>
		public DateTime LatestShipDate
		{
			get { return this._latestShipDate.GetValueOrDefault(); }
			set { this._latestShipDate = value; }
		}

		/// <summary>
		/// Sets the LatestShipDate property.
		/// </summary>
		/// <param name="latestShipDate">LatestShipDate property.</param>
		/// <returns>this instance.</returns>
		public Order WithLatestShipDate( DateTime latestShipDate )
		{
			this._latestShipDate = latestShipDate;
			return this;
		}

		/// <summary>
		/// Checks if LatestShipDate property is set.
		/// </summary>
		/// <returns>true if LatestShipDate property is set.</returns>
		public bool IsSetLatestShipDate()
		{
			return this._latestShipDate != null;
		}

		/// <summary>
		/// Gets and sets the EarliestDeliveryDate property.
		/// </summary>
		public DateTime EarliestDeliveryDate
		{
			get { return this._earliestDeliveryDate.GetValueOrDefault(); }
			set { this._earliestDeliveryDate = value; }
		}

		/// <summary>
		/// Sets the EarliestDeliveryDate property.
		/// </summary>
		/// <param name="earliestDeliveryDate">EarliestDeliveryDate property.</param>
		/// <returns>this instance.</returns>
		public Order WithEarliestDeliveryDate( DateTime earliestDeliveryDate )
		{
			this._earliestDeliveryDate = earliestDeliveryDate;
			return this;
		}

		/// <summary>
		/// Checks if EarliestDeliveryDate property is set.
		/// </summary>
		/// <returns>true if EarliestDeliveryDate property is set.</returns>
		public bool IsSetEarliestDeliveryDate()
		{
			return this._earliestDeliveryDate != null;
		}

		/// <summary>
		/// Gets and sets the LatestDeliveryDate property.
		/// </summary>
		public DateTime LatestDeliveryDate
		{
			get { return this._latestDeliveryDate.GetValueOrDefault(); }
			set { this._latestDeliveryDate = value; }
		}

		/// <summary>
		/// Sets the LatestDeliveryDate property.
		/// </summary>
		/// <param name="latestDeliveryDate">LatestDeliveryDate property.</param>
		/// <returns>this instance.</returns>
		public Order WithLatestDeliveryDate( DateTime latestDeliveryDate )
		{
			this._latestDeliveryDate = latestDeliveryDate;
			return this;
		}

		/// <summary>
		/// Checks if LatestDeliveryDate property is set.
		/// </summary>
		/// <returns>true if LatestDeliveryDate property is set.</returns>
		public bool IsSetLatestDeliveryDate()
		{
			return this._latestDeliveryDate != null;
		}

		/// <summary>
		/// Gets and sets the IsBusinessOrder property.
		/// </summary>
		public bool IsBusinessOrder
		{
			get { return this._isBusinessOrder.GetValueOrDefault(); }
			set { this._isBusinessOrder = value; }
		}

		/// <summary>
		/// Sets the IsBusinessOrder property.
		/// </summary>
		/// <param name="isBusinessOrder">IsBusinessOrder property.</param>
		/// <returns>this instance.</returns>
		public Order WithIsBusinessOrder( bool isBusinessOrder )
		{
			this._isBusinessOrder = isBusinessOrder;
			return this;
		}

		/// <summary>
		/// Checks if IsBusinessOrder property is set.
		/// </summary>
		/// <returns>true if IsBusinessOrder property is set.</returns>
		public bool IsSetIsBusinessOrder()
		{
			return this._isBusinessOrder != null;
		}

		/// <summary>
		/// Gets and sets the PurchaseOrderNumber property.
		/// </summary>
		public string PurchaseOrderNumber{ get; set; }

		/// <summary>
		/// Sets the PurchaseOrderNumber property.
		/// </summary>
		/// <param name="purchaseOrderNumber">PurchaseOrderNumber property.</param>
		/// <returns>this instance.</returns>
		public Order WithPurchaseOrderNumber( string purchaseOrderNumber )
		{
			this.PurchaseOrderNumber = purchaseOrderNumber;
			return this;
		}

		/// <summary>
		/// Checks if PurchaseOrderNumber property is set.
		/// </summary>
		/// <returns>true if PurchaseOrderNumber property is set.</returns>
		public bool IsSetPurchaseOrderNumber()
		{
			return this.PurchaseOrderNumber != null;
		}

		/// <summary>
		/// Gets and sets the IsPrime property.
		/// </summary>
		public bool IsPrime
		{
			get { return this._isPrime.GetValueOrDefault(); }
			set { this._isPrime = value; }
		}

		/// <summary>
		/// Sets the IsPrime property.
		/// </summary>
		/// <param name="isPrime">IsPrime property.</param>
		/// <returns>this instance.</returns>
		public Order WithIsPrime( bool isPrime )
		{
			this._isPrime = isPrime;
			return this;
		}

		/// <summary>
		/// Checks if IsPrime property is set.
		/// </summary>
		/// <returns>true if IsPrime property is set.</returns>
		public bool IsSetIsPrime()
		{
			return this._isPrime != null;
		}

		/// <summary>
		/// Gets and sets the IsPremiumOrder property.
		/// </summary>
		public bool IsPremiumOrder
		{
			get { return this._isPremiumOrder.GetValueOrDefault(); }
			set { this._isPremiumOrder = value; }
		}

		/// <summary>
		/// Sets the IsPremiumOrder property.
		/// </summary>
		/// <param name="isPremiumOrder">IsPremiumOrder property.</param>
		/// <returns>this instance.</returns>
		public Order WithIsPremiumOrder( bool isPremiumOrder )
		{
			this._isPremiumOrder = isPremiumOrder;
			return this;
		}

		/// <summary>
		/// Checks if IsPremiumOrder property is set.
		/// </summary>
		/// <returns>true if IsPremiumOrder property is set.</returns>
		public bool IsSetIsPremiumOrder()
		{
			return this._isPremiumOrder != null;
		}

		public override void ReadFragmentFrom( IMwsReader reader )
		{
			this.AmazonOrderId = reader.Read< string >( "AmazonOrderId" );
			this.SellerOrderId = reader.Read< string >( "SellerOrderId" );
			this._purchaseDate = reader.Read< DateTime? >( "PurchaseDate" );
			this._lastUpdateDate = reader.Read< DateTime? >( "LastUpdateDate" );
			this.OrderStatus = reader.Read< string >( "OrderStatus" );
			this.FulfillmentChannel = reader.Read< string >( "FulfillmentChannel" );
			this.SalesChannel = reader.Read< string >( "SalesChannel" );
			this.OrderChannel = reader.Read< string >( "OrderChannel" );
			this.ShipServiceLevel = reader.Read< string >( "ShipServiceLevel" );
			this.ShippingAddress = reader.Read< Address >( "ShippingAddress" );
			this.OrderTotal = reader.Read< Money >( "OrderTotal" );
			this._numberOfItemsShipped = reader.Read< decimal? >( "NumberOfItemsShipped" );
			this._numberOfItemsUnshipped = reader.Read< decimal? >( "NumberOfItemsUnshipped" );
			this._paymentExecutionDetail = reader.ReadList< PaymentExecutionDetailItem >( "PaymentExecutionDetail", "PaymentExecutionDetailItem" );
			this.PaymentMethod = reader.Read< string >( "PaymentMethod" );
			this.MarketplaceId = reader.Read< string >( "MarketplaceId" );
			this.BuyerEmail = reader.Read< string >( "BuyerEmail" );
			this.BuyerName = reader.Read< string >( "BuyerName" );
			this.ShipmentServiceLevelCategory = reader.Read< string >( "ShipmentServiceLevelCategory" );
			this._shippedByAmazonTFM = reader.Read< bool? >( "ShippedByAmazonTFM" );
			this.TFMShipmentStatus = reader.Read< string >( "TFMShipmentStatus" );
			this.CbaDisplayableShippingLabel = reader.Read< string >( "CbaDisplayableShippingLabel" );
			this.OrderType = reader.Read< string >( "OrderType" );
			this._earliestShipDate = reader.Read< DateTime? >( "EarliestShipDate" );
			this._latestShipDate = reader.Read< DateTime? >( "LatestShipDate" );
			this._earliestDeliveryDate = reader.Read< DateTime? >( "EarliestDeliveryDate" );
			this._latestDeliveryDate = reader.Read< DateTime? >( "LatestDeliveryDate" );
			this._isBusinessOrder = reader.Read< bool? >( "IsBusinessOrder" );
			this.PurchaseOrderNumber = reader.Read< string >( "PurchaseOrderNumber" );
			this._isPrime = reader.Read< bool? >( "IsPrime" );
			this._isPremiumOrder = reader.Read< bool? >( "IsPremiumOrder" );
		}

		public override void WriteFragmentTo( IMwsWriter writer )
		{
			writer.Write( "AmazonOrderId", this.AmazonOrderId );
			writer.Write( "SellerOrderId", this.SellerOrderId );
			writer.Write( "PurchaseDate", this._purchaseDate );
			writer.Write( "LastUpdateDate", this._lastUpdateDate );
			writer.Write( "OrderStatus", this.OrderStatus );
			writer.Write( "FulfillmentChannel", this.FulfillmentChannel );
			writer.Write( "SalesChannel", this.SalesChannel );
			writer.Write( "OrderChannel", this.OrderChannel );
			writer.Write( "ShipServiceLevel", this.ShipServiceLevel );
			writer.Write( "ShippingAddress", this.ShippingAddress );
			writer.Write( "OrderTotal", this.OrderTotal );
			writer.Write( "NumberOfItemsShipped", this._numberOfItemsShipped );
			writer.Write( "NumberOfItemsUnshipped", this._numberOfItemsUnshipped );
			writer.WriteList( "PaymentExecutionDetail", "PaymentExecutionDetailItem", this._paymentExecutionDetail );
			writer.Write( "PaymentMethod", this.PaymentMethod );
			writer.Write( "MarketplaceId", this.MarketplaceId );
			writer.Write( "BuyerEmail", this.BuyerEmail );
			writer.Write( "BuyerName", this.BuyerName );
			writer.Write( "ShipmentServiceLevelCategory", this.ShipmentServiceLevelCategory );
			writer.Write( "ShippedByAmazonTFM", this._shippedByAmazonTFM );
			writer.Write( "TFMShipmentStatus", this.TFMShipmentStatus );
			writer.Write( "CbaDisplayableShippingLabel", this.CbaDisplayableShippingLabel );
			writer.Write( "OrderType", this.OrderType );
			writer.Write( "EarliestShipDate", this._earliestShipDate );
			writer.Write( "LatestShipDate", this._latestShipDate );
			writer.Write( "EarliestDeliveryDate", this._earliestDeliveryDate );
			writer.Write( "LatestDeliveryDate", this._latestDeliveryDate );
			writer.Write( "IsBusinessOrder", this._isBusinessOrder );
			writer.Write( "PurchaseOrderNumber", this.PurchaseOrderNumber );
			writer.Write( "IsPrime", this._isPrime );
			writer.Write( "IsPremiumOrder", this._isPremiumOrder );
		}

		public override void WriteTo( IMwsWriter writer )
		{
			writer.Write( "https://mws.amazonservices.com/Orders/2013-09-01", "Order", this );
		}

		public Order(): base()
		{
		}
	}
}