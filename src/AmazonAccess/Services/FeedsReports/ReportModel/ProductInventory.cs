using LINQtoCSV;

namespace AmazonAccess.Services.FeedsReports.ReportModel
{
	public class ProductInventory
	{
		[ CsvColumn( Name = "sku", FieldIndex = 1 ) ]
		public string Sku{ get; set; }

		[ CsvColumn( Name = "asin", FieldIndex = 2 ) ]
		public string Asin{ get; set; }

		[ CsvColumn( Name = "price", FieldIndex = 3 ) ]
		public decimal Price{ get; set; }

		[ CsvColumn( Name = "quantity", FieldIndex = 4 ) ]
		public int? OriginalQuantity
		{
			get { return this._originalQuantity; }
			set
			{
				this._originalQuantity = value;
				if( value == null )
					return;
				this.Quantity = value.Value;
				this.IsDefaultFulfillmentChannel = true;
			}
		}

		private int? _originalQuantity{ get; set; }

		public int Quantity{ get; set; }

		public bool IsDefaultFulfillmentChannel{ get; set; }
	}
}