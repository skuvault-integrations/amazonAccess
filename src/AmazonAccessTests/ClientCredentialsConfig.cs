using System.Linq;
using AmazonAccess.Models;
using LINQtoCSV;

namespace AmazonAccessTests
{
	internal class ClientCredentialsConfig
	{
		[ CsvColumn( Name = "SellerId", FieldIndex = 1 ) ]
		public string SellerId{ get; set; }

		[ CsvColumn( Name = "MWSAuthToken", FieldIndex = 2 ) ]
		public string MwsAuthToken{ get; set; }

		[ CsvColumn( Name = "Marketplaces", FieldIndex = 3 ) ]
		public string Marketplaces{ get; set; }

		public AmazonMarketplaces ParseMarketplaces()
		{
			var list = this.Marketplaces.Split( ';' ).ToList();
			return new AmazonMarketplaces( list );
		}
	}
}