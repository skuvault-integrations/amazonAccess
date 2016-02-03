using LINQtoCSV;

namespace AmazonAccess.Services.FeedsReports.ReportModel
{
	public class ProductShort
	{
		[ CsvColumn( Name = "item-name", FieldIndex = 1 ) ]
		public string ItemName{ get; set; }

		[ CsvColumn( Name = "item-description", FieldIndex = 2 ) ]
		public string ItemDescription{ get; set; }

		[ CsvColumn( Name = "listing-id", FieldIndex = 3 ) ]
		public string ListingId{ get; set; }

		[ CsvColumn( Name = "seller-sku", FieldIndex = 4 ) ]
		public string SellerSku{ get; set; }

		[ CsvColumn( Name = "price", FieldIndex = 5 ) ]
		public decimal Price{ get; set; }

		[ CsvColumn( Name = "quantity", FieldIndex = 6 ) ]
		public int Quantity{ get; set; }

		[ CsvColumn( Name = "open-date", FieldIndex = 7 ) ]
		public string OpenDate{ get; set; }

		[ CsvColumn( Name = "image-url", FieldIndex = 8 ) ]
		public string ImageUrl{ get; set; }

		[ CsvColumn( Name = "item-is-marketplace", FieldIndex = 9 ) ]
		public string ItemIsMarketplace{ get; set; }

		[ CsvColumn( Name = "product-id-type", FieldIndex = 10 ) ]
		public string ProductIdType{ get; set; }

		[ CsvColumn( Name = "zshop-shipping-fee", FieldIndex = 11 ) ]
		public string ZShopShippingFee{ get; set; }

		[ CsvColumn( Name = "item-note", FieldIndex = 12 ) ]
		public string ItemNote{ get; set; }

		[ CsvColumn( Name = "item-condition", FieldIndex = 13 ) ]
		public string ItemCondition{ get; set; }

		[ CsvColumn( Name = "zshop-category1", FieldIndex = 14 ) ]
		public string ZShopCategory1{ get; set; }

		[ CsvColumn( Name = "zshop-browse-path", FieldIndex = 15 ) ]
		public string ZShopBrowsePath{ get; set; }

		[ CsvColumn( Name = "zshop-storefront-feature", FieldIndex = 16 ) ]
		public string ZShopStorefrontFeature{ get; set; }

		[ CsvColumn( Name = "asin1", FieldIndex = 17 ) ]
		public string Asin1{ get; set; }

		[ CsvColumn( Name = "asin2", FieldIndex = 18 ) ]
		public string Asin2{ get; set; }

		[ CsvColumn( Name = "asin3", FieldIndex = 19 ) ]
		public string Asin3{ get; set; }

		[ CsvColumn( Name = "will-ship-internationally", FieldIndex = 20 ) ]
		public string WillShipInternationally{ get; set; }

		[ CsvColumn( Name = "expedited-shipping", FieldIndex = 21 ) ]
		public string ExpeditedShipping{ get; set; }

		[ CsvColumn( Name = "zshop-boldface", FieldIndex = 22 ) ]
		public string ZShopBoldface{ get; set; }

		[ CsvColumn( Name = "product-id", FieldIndex = 23 ) ]
		public string ProductId{ get; set; }

		[ CsvColumn( Name = "bid-for-featured-placement", FieldIndex = 24 ) ]
		public string BidForFeaturedPlacement{ get; set; }

		[ CsvColumn( Name = "add-delete", FieldIndex = 25 ) ]
		public string AddDelete{ get; set; }

		[ CsvColumn( Name = "pending-quantity", FieldIndex = 26 ) ]
		public string PendingQuantity{ get; set; }

		[ CsvColumn( Name = "fulfillment-channel", FieldIndex = 27 ) ]
		public string FulfillmentChannel{ get; set; }
	}
}