using System.Linq;
using AmazonAccess.Models;
using LINQtoCSV;

namespace AmazonAccessTests
{
	internal class TestConfig
	{
		[ CsvColumn( Name = "AccessKeyId", FieldIndex = 1 ) ]
		public string AccessKeyId{ get; set; }

		[ CsvColumn( Name = "SecretAccessKeyId", FieldIndex = 2 ) ]
		public string SecretAccessKeyId{ get; set; }

		[ CsvColumn( Name = "SellerId", FieldIndex = 3 ) ]
		public string SellerId{ get; set; }

		[ CsvColumn( Name = "MWSAuthToken", FieldIndex = 4 ) ]
		public string MwsAuthToken{ get; set; }

		[ CsvColumn( Name = "Marketplaces", FieldIndex = 5 ) ]
		public string Marketplaces{ get; set; }

		public AmazonMarketplaces ParseMarketplaces()
		{
			var list = this.Marketplaces.Split( ';' ).ToList();
			return new AmazonMarketplaces( list );
		}
	}
}