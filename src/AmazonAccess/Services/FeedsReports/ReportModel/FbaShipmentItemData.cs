using LINQtoCSV;
using System;

namespace AmazonAccess.Services.FeedsReports.ReportModel
{
	public class FbaShipmentItemData
	{
		[ CsvColumn( Name = "amazon-order-id", FieldIndex = 1 ) ]
		public string AmazonOrderId{ get; set; }

		[ CsvColumn( Name = "merchant-order-id", FieldIndex = 2 ) ]
		public string MerchantOrderId { get; set; }

		[ CsvColumn( Name = "shipment-id", FieldIndex = 3 ) ]
		public string ShipmentId { get; set; }

		[ CsvColumn( Name = "shipment-item-id", FieldIndex = 4 ) ]
		public string ShipmentItemId { get; set; }

		[ CsvColumn( Name = "amazon-order-item-id", FieldIndex = 5 ) ]
		public string AmazonOrderItemId { get; set; }

		[ CsvColumn( Name = "merchant-order-item-id", FieldIndex = 6 ) ]
		public string MerchantOrderItemId { get; set; }

		[ CsvColumn( Name = "purchase-date", FieldIndex = 7 ) ]
		public DateTime? PurchaseDate { get; set; }

		[ CsvColumn( Name = "payments-date", FieldIndex = 8 ) ]
		public DateTime? PaymentsDate { get; set; }

		[ CsvColumn( Name = "shipment-date", FieldIndex = 9 ) ]
		public DateTime? ShipmentDate { get; set; }

		[ CsvColumn( Name = "reporting-date", FieldIndex = 10 ) ]
		public DateTime? ReportingDate { get; set; }

		[ CsvColumn( Name = "buyer-email", FieldIndex = 11 ) ]
		public string BuyerEmail { get; set; }

		[ CsvColumn( Name = "buyer-name", FieldIndex = 12 ) ]
		public string BuyerName { get; set; }

		[ CsvColumn( Name = "buyer-phone-number", FieldIndex = 13 ) ]
		public string BuyerPhoneNumber { get; set; }

		[ CsvColumn( Name = "sku", FieldIndex = 14 ) ]
		public string Sku { get; set; }

		[ CsvColumn( Name = "product-name", FieldIndex = 15 ) ]
		public string ProductName { get; set; }

		[ CsvColumn( Name = "quantity-shipped", FieldIndex = 16 ) ]
		public int? QuantityShipped { get; set; }

		[ CsvColumn( Name = "currency", FieldIndex = 17 ) ]
		public string Currency { get; set; }

		[ CsvColumn( Name = "item-price", FieldIndex = 18 ) ]
		public decimal? ItemPrice { get; set; }

		[ CsvColumn( Name = "item-tax", FieldIndex = 19 ) ]
		public decimal? ItemTax { get; set; }

		[ CsvColumn( Name = "shipping-price", FieldIndex = 20 ) ]
		public decimal? ShippingPrice { get; set; }

		[ CsvColumn( Name = "shipping-tax", FieldIndex = 21 ) ]
		public decimal? ShippingTax { get; set; }

		[ CsvColumn( Name = "gift-wrap-price", FieldIndex = 22 ) ]
		public decimal? GiftWrapPrice { get; set; }

		[ CsvColumn( Name = "gift-wrap-tax", FieldIndex = 23 ) ]
		public decimal? GiftWrapTax { get; set; }

		[ CsvColumn( Name = "ship-service-level", FieldIndex = 24 ) ]
		public string ShipServiceLevel { get; set; }

		[ CsvColumn( Name = "recipient-name", FieldIndex = 25 ) ]
		public string RecipientName { get; set; }

		[ CsvColumn( Name = "ship-address-1", FieldIndex = 26 ) ]
		public string ShipAddress1 { get; set; }

		[ CsvColumn( Name = "ship-address-2", FieldIndex = 27 ) ]
		public string ShipAddress2 { get; set; }

		[ CsvColumn( Name = "ship-address-3", FieldIndex = 28 ) ]
		public string ShipAddress3 { get; set; }

		[ CsvColumn( Name = "ship-city", FieldIndex = 29 ) ]
		public string ShipCity { get; set; }

		[ CsvColumn( Name = "ship-state", FieldIndex = 30 ) ]
		public string ShipState { get; set; }

		[ CsvColumn( Name = "ship-postal-code", FieldIndex = 31 ) ]
		public string ShipPostalCode { get; set; }

		[ CsvColumn( Name = "ship-country", FieldIndex = 32 ) ]
		public string ShipCountry { get; set; }

		[ CsvColumn( Name = "ship-phone-number", FieldIndex = 33 ) ]
		public string ShipPhoneNumber { get; set; }

		[ CsvColumn( Name = "bill-address-1", FieldIndex = 34 ) ]
		public string BillAddress1 { get; set; }

		[ CsvColumn( Name = "bill-address-2", FieldIndex = 35 ) ]
		public string BillAddress2 { get; set; }

		[ CsvColumn( Name = "bill-address-3", FieldIndex = 36 ) ]
		public string BillAddress3 { get; set; }

		[ CsvColumn( Name = "bill-city", FieldIndex = 37 ) ]
		public string BillCity { get; set; }

		[ CsvColumn( Name = "bill-state", FieldIndex = 38 ) ]
		public string BillState { get; set; }

		[ CsvColumn( Name = "bill-postal-code", FieldIndex = 39 ) ]
		public string BillPostalCode { get; set; }

		[ CsvColumn( Name = "bill-country", FieldIndex = 40 ) ]
		public string BillCountry { get; set; }

		[ CsvColumn( Name = "item-promotion-discount", FieldIndex = 41 ) ]
		public decimal? ItemPromotionDiscount { get; set; }

		[ CsvColumn( Name = "ship-promotion-discount", FieldIndex = 42 ) ]
		public decimal? ShipPromotionDiscount { get; set; }

		[ CsvColumn( Name = "carrier", FieldIndex = 43 ) ]
		public string Carrier { get; set; }

		[ CsvColumn( Name = "tracking-number", FieldIndex = 44 ) ]
		public string TrackingNumber { get; set; }

		[ CsvColumn( Name = "estimated-arrival-date", FieldIndex = 45 ) ]
		public DateTime? EstimatedArrivalDate { get; set; }

		[ CsvColumn( Name = "fulfillment-center-id", FieldIndex = 46 ) ]
		public string FulfillmentCenterId { get; set; }

		[ CsvColumn( Name = "fulfillment-channel", FieldIndex = 47 ) ]
		public string FulfillmentChannel { get; set; }

		[ CsvColumn( Name = "sales-channel", FieldIndex = 48 ) ]
		public string SalesChannel { get; set; }
	}
}