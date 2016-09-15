using LINQtoCSV;

namespace AmazonAccess.Services.FeedsReports.ReportModel
{
	public class FbaReservedInventory
	{
		[ CsvColumn( Name = "sku", FieldIndex = 1 ) ]
		public string SKU{ get; set; }

		[ CsvColumn( Name = "fnsku", FieldIndex = 2 ) ]
		public string FnSKU{ get; set; }

		[ CsvColumn( Name = "asin", FieldIndex = 3 ) ]
		public string Asin{ get; set; }

		[ CsvColumn( Name = "product-name", FieldIndex = 4 ) ]
		public string ProductName{ get; set; }

		[ CsvColumn( Name = "reserved_qty", FieldIndex = 5 ) ]
		public int ReservedQty{ get; set; }

		[ CsvColumn( Name = "reserved_customerorders", FieldIndex = 6 ) ]
		public int ReservedCustomerOrders{ get; set; }

		[ CsvColumn( Name = "reserved_fc-transfers", FieldIndex = 7 ) ]
		public int ReservedFcTransfers{ get; set; }

		[ CsvColumn( Name = "reserved_fc-processing", FieldIndex = 8 ) ]
		public int ReservedFcProcessing{ get; set; }
	}
}