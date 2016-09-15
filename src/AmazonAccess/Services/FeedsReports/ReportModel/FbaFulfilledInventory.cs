using LINQtoCSV;

namespace AmazonAccess.Services.FeedsReports.ReportModel
{
	public class FbaFulfilledInventory
	{
		[ CsvColumn( Name = "seller-sku", FieldIndex = 1 ) ]
		public string SKU{ get; set; }

		[ CsvColumn( Name = "fulfillment-channel-sku", FieldIndex = 2 ) ]
		public string FnSKU{ get; set; }

		[ CsvColumn( Name = "asin", FieldIndex = 3 ) ]
		public string Asin{ get; set; }

		[ CsvColumn( Name = "condition-type", FieldIndex = 4 ) ]
		public string Condition{ get; set; }

		[ CsvColumn( Name = "Warehouse-Condition-code", FieldIndex = 5 ) ]
		public string WarehouseConditionCode{ get; set; }

		[ CsvColumn( Name = "Quantity Available", FieldIndex = 6 ) ]
		public int QuantityAvailable{ get; set; }
	}
}