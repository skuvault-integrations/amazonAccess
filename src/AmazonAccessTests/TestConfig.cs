using System.Linq;
using AmazonAccess.Models;
using LINQtoCSV;

namespace AmazonAccessTests
{
	internal class TestConfig
	{
		[ CsvColumn( Name = "SellerId", FieldIndex = 1 ) ]
		public string SellerId{ get; set; }

		[ CsvColumn( Name = "MWSAuthToken", FieldIndex = 2 ) ]
		public string MwsAuthToken{ get; set; }

		[ CsvColumn( Name = "Marketplaces", FieldIndex = 3 ) ]
		public string Marketplaces{ get; set; }

		[ CsvColumn( Name = "NaAccessKeyId", FieldIndex = 4 ) ]
		public string NaAccessKeyId{ get; set; }

		[ CsvColumn( Name = "NaSecretAccessKeyId", FieldIndex = 5 ) ]
		public string NaSecretAccessKeyId{ get; set; }

		[ CsvColumn( Name = "EuAccessKeyId", FieldIndex = 6 ) ]
		public string EuAccessKeyId{ get; set; }

		[ CsvColumn( Name = "EuSecretAccessKeyId", FieldIndex = 7 ) ]
		public string EuSecretAccessKeyId{ get; set; }

		[ CsvColumn( Name = "FeAccessKeyId", FieldIndex = 8 ) ]
		public string FeAccessKeyId{ get; set; }

		[ CsvColumn( Name = "FeSecretAccessKeyId", FieldIndex = 9 ) ]
		public string FeSecretAccessKeyId{ get; set; }

		[ CsvColumn( Name = "CnAccessKeyId", FieldIndex = 10 ) ]
		public string CnAccessKeyId{ get; set; }

		[ CsvColumn( Name = "CnSecretAccessKeyId", FieldIndex = 11 ) ]
		public string CnSecretAccessKeyId{ get; set; }

		public AmazonMarketplaces ParseMarketplaces()
		{
			var list = this.Marketplaces.Split( ';' ).ToList();
			return new AmazonMarketplaces( list );
		}
	}
}