using LINQtoCSV;

namespace AmazonAccess.Services.FeedsReports.ReportModel
{
	public class FbaManageInventory
	{
		[ CsvColumn( Name = "sku", FieldIndex = 1 ) ]
		public string SKU{ get; set; }

		[ CsvColumn( Name = "fnsku", FieldIndex = 2 ) ]
		public string FnSKU{ get; set; }

		[ CsvColumn( Name = "asin", FieldIndex = 3 ) ]
		public string Asin{ get; set; }

		[ CsvColumn( Name = "product-name", FieldIndex = 4, CanBeNull = true ) ]
		public string ProductName{ get; set; }

		[ CsvColumn( Name = "condition", FieldIndex = 5 ) ]
		public string Condition{ get; set; }

		[ CsvColumn( Name = "your-price", FieldIndex = 6, CanBeNull = true ) ]
		public decimal YourPrice{ get; set; }

		[ CsvColumn( Name = "mfn-listing-exists", FieldIndex = 7, CanBeNull = true ) ]
		public string MfnListingExists{ get; set; }

		[ CsvColumn( Name = "mfn-fulfillable-quantity", FieldIndex = 8, CanBeNull = true ) ]
		public int MfnFulfillableQuantity{ get; set; }

		[ CsvColumn( Name = "afn-listing-exists", FieldIndex = 9 ) ]
		public string AfnListingExists{ get; set; }

		[ CsvColumn( Name = "afn-warehouse-quantity", FieldIndex = 10, CanBeNull = true ) ]
		public int AfnWarehouseQuantity{ get; set; }

		[ CsvColumn( Name = "afn-fulfillable-quantity", FieldIndex = 11 ) ]
		public int AfnFulfillableQuantity{ get; set; }

		[ CsvColumn( Name = "afn-unsellable-quantity", FieldIndex = 12 ) ]
		public int AfnUnsellableQuantity{ get; set; }

		[ CsvColumn( Name = "afn-reserved-quantity", FieldIndex = 13 ) ]
		public int AfnReservedQuantity{ get; set; }

		[ CsvColumn( Name = "afn-total-quantity", FieldIndex = 14 ) ]
		public int AfnTotalQuantity{ get; set; }

		[ CsvColumn( Name = "per-unit-volume", FieldIndex = 15, CanBeNull = true ) ]
		public decimal PerUnitVolume{ get; set; }

		[ CsvColumn( Name = "afn-inbound-working-quantity", FieldIndex = 16 ) ]
		public int AfnInboundWorkingQuantity{ get; set; }

		[ CsvColumn( Name = "afn-inbound-shipped-quantity", FieldIndex = 17 ) ]
		public int AfnInboundShippedQuantity{ get; set; }

		[ CsvColumn( Name = "afn-inbound-receiving-quantity", FieldIndex = 18 ) ]
		public int AfnInboundReceivingQuantity{ get; set; }

		[ CsvColumn( Name = "afn-researching-quantity", FieldIndex = 19 ) ]
		public int AfnResearchingQuantity { get; set; }

		[ CsvColumn( Name = "afn-reserved-future-supply", FieldIndex = 20 ) ]
		public int AfnReservedFutureSupply { get; set; }

		[ CsvColumn( Name = "afn-future-supply-buyable", FieldIndex = 21 ) ]
		public int AfnFutureSupplyBuyable { get; set; }
	}
}