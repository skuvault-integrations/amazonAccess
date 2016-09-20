using System.Linq;
using AmazonAccess.Models;
using LINQtoCSV;

namespace AmazonAccessTests.Misc
{
	internal class ClientCredentialsConfig
	{
		[ CsvColumn( Name = "SellerId", FieldIndex = 1 ) ]
		public string SellerId{ get; set; }

		[ CsvColumn( Name = "MWSAuthToken", FieldIndex = 2 ) ]
		public string MwsAuthToken{ get; set; }

		[ CsvColumn( Name = "Marketplaces", FieldIndex = 3 ) ]
		public string Marketplaces{ get; set; }

		public AmazonMarketplaces ParseMarketplaces( bool ignoreNonAmazonMarketplaces = false )
		{
			var marketplaces = this.Marketplaces.Split( ';' ).Select( x => x.Split( '-' ) )
				.Select( x => x.Length == 1 ? new AmazonMarketplace( x[ 0 ] ) : new AmazonMarketplace( x[ 0 ], x[ 1 ] ) );

			return new AmazonMarketplaces( marketplaces.ToList(), ignoreNonAmazonMarketplaces );
		}
	}
}