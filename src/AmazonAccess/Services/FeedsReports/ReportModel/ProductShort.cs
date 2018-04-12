using LINQtoCSV;

namespace AmazonAccess.Services.FeedsReports.ReportModel
{
	public class ProductShort
	{
		public string ItemName{ get; set; }
		public string ItemDescription{ get; set; }
		public string SellerSku{ get; set; }
		public decimal Price{ get; set; }
		public int Quantity{ get; set; }
		public string ItemNote{ get; set; }
		public string ProductId{ get; set; }

		public ProductShort() { }

		public ProductShort( string itemName, string itemDescription, string sellerSku, decimal price, int quantity, string itemNote, string productId )
		{
			this.ItemName = itemName;
			this.ItemDescription = itemDescription;
			this.SellerSku = sellerSku;
			this.Price = price;
			this.Quantity = quantity;
			this.ItemNote = itemNote;
			this.ProductId = productId;
		}

		public static ProductShort FromProductShortEn( ProductShortEn obj )
		{
			return new ProductShort( obj.ItemName, obj.ItemDescription, obj.SellerSku, obj.Price, obj.Quantity, obj.ItemNote, obj.ProductId );
		}

		public static ProductShort FromProductShortJp( ProductShortJp obj )
		{
			return new ProductShort( obj.ItemName, obj.ItemDescription, obj.SellerSku, obj.Price, obj.Quantity, string.Empty, obj.ProductId );
		}
	}

	public class ProductShortEn
	{
		[ CsvColumn( Name = "item-name", FieldIndex = 1 ) ]
		public string ItemName{ get; set; }

		[ CsvColumn( Name = "item-description", FieldIndex = 2 ) ]
		public string ItemDescription{ get; set; }

		[ CsvColumn( Name = "seller-sku", FieldIndex = 4 ) ]
		public string SellerSku{ get; set; }

		[ CsvColumn( Name = "price", FieldIndex = 5 ) ]
		public decimal Price{ get; set; }

		[ CsvColumn( Name = "quantity", FieldIndex = 6 ) ]
		public int Quantity{ get; set; }

		[ CsvColumn( Name = "item-note", FieldIndex = 12 ) ]
		public string ItemNote{ get; set; }

		[ CsvColumn( Name = "product-id", FieldIndex = 23 ) ]
		public string ProductId{ get; set; }
	}

	public class ProductShortJp
	{
		[ CsvColumn( Name = "商品名", FieldIndex = 1 ) ]
		public string ItemName{ get; set; }

		[ CsvColumn( Name = "コンディション説明", FieldIndex = 8 ) ]
		public string ItemDescription{ get; set; }

		[ CsvColumn( Name = "出品者SKU", FieldIndex = 3 ) ]
		public string SellerSku{ get; set; }

		[ CsvColumn( Name = "価格", FieldIndex = 4 ) ]
		public decimal Price{ get; set; }

		[ CsvColumn( Name = "数量", FieldIndex = 5 ) ]
		public int Quantity{ get; set; }

		[ CsvColumn( Name = "商品ID", FieldIndex = 12 ) ]
		public string ProductId{ get; set; }
	}
}