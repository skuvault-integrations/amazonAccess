using AmazonAccess.Models;
using LINQtoCSV;
using Netco.Extensions;

namespace AmazonAccess.Services.FeedsReports.ReportModel
{
	public class FbaMultiCountryInventory
	{
		[ CsvColumn( Name = "seller-sku", FieldIndex = 1 ) ]
		public string SKU{ get; set; }

		[ CsvColumn( Name = "fulfillment-channel-sku", FieldIndex = 2 ) ]
		public string FnSKU{ get; set; }

		[ CsvColumn( Name = "asin", FieldIndex = 3 ) ]
		public string Asin{ get; set; }

		[ CsvColumn( Name = "condition-type", FieldIndex = 4 ) ]
		public string Condition{ get; set; }

		[ CsvColumn( Name = "country", FieldIndex = 5 ) ]
		public string CountryCodeStr{ get; set; }

		[ CsvColumn( Name = "quantity-for-local-fulfillment", FieldIndex = 6 ) ]
		public string QuantityForLocalFulfillment{ get; set; }

		public AmazonCountryCodeEnum CountryCode
		{
			get { return this.CountryCodeStr.ToEnum( AmazonCountryCodeEnum.Unknown ); }
		}
	}
}