using System.Collections.Generic;
using System.Linq;
using CuttingEdge.Conditions;

namespace AmazonAccess.Models
{
	public sealed class AmazonMarketplaces
	{
		public AmazonRegionCodeEnum RegionCode{ get; private set; }
		public string OrdersServiceUrl{ get; private set; }
		public string ProductsServiceUrl{ get; private set; }
		public string FbaInventoryServiceUrl{ get; private set; }
		public string FbaInboundServiceUrl{ get; private set; }
		public string FeedsServiceUrl{ get; private set; }
		public string SellersServiceUrl{ get; private set; }
		public List< AmazonMarketplace > Marketplaces{ get; private set; }

		private void Init( List< AmazonMarketplace > marketplaces )
		{
			var marketplace = marketplaces.First();
			this.RegionCode = marketplace.RegionCode;
			this.OrdersServiceUrl = marketplace.OrdersServiceUrl;
			this.ProductsServiceUrl = marketplace.ProductsServiceUrl;
			this.FbaInventoryServiceUrl = marketplace.FbaInventoryServiceUrl;
			this.FbaInboundServiceUrl = marketplace.FbaInboundServiceUrl;
			this.FeedsServiceUrl = marketplace.FeedsServiceUrl;
			this.SellersServiceUrl = marketplace.SellersServiceUrl;
			this.Marketplaces = marketplaces;
		}

		private AmazonMarketplaces( List< AmazonMarketplace > marketplaces )
		{
			this.Init( marketplaces );
		}

		public AmazonMarketplaces( string countryCode )
			: this( new AmazonMarketplace( countryCode ) )
		{
		}

		public AmazonMarketplaces( AmazonMarketplace marketplace )
		{
			Condition.Requires( marketplace, "marketplace" ).IsNotNull();
			this.Init( new List< AmazonMarketplace > { marketplace } );
		}

		public AmazonMarketplaces( List< string > countryCodes )
			: this( countryCodes.Select( x => new AmazonMarketplace( x ) ).ToList(), true )
		{
		}

		public AmazonMarketplaces( List< AmazonMarketplace > marketplaces, bool ignoreNonAmazonMarketplaces = false )
		{
			Condition.Requires( marketplaces, "marketplaces" ).IsNotNull();

			if( ignoreNonAmazonMarketplaces )
				marketplaces = marketplaces.Where( x => x.IsAmazonMarketplace ).ToList();
			Condition.Requires( marketplaces, "marketplaces" ).IsNotEmpty();

			var regionsCount = marketplaces.GroupBy( x => x.RegionCode ).Count();
			Condition.Requires( regionsCount, "marketplaces" ).IsEqualTo( 1, "Found marketplaces from different regions" );

			var duplicates = marketplaces.GroupBy( x => x.MarketplaceId ).Any( x => x.Count() > 1 );
			Condition.Requires( duplicates, "marketplaces" ).IsEqualTo( false, "Found duplicates of marketplaces" );

			this.Init( marketplaces );
		}

		public static AmazonMarketplaces TryCreate( List< AmazonMarketplace > marketplaces, bool ignoreNonAmazonMarketplaces = false )
		{
			if( marketplaces == null )
				return null;

			if( ignoreNonAmazonMarketplaces )
				marketplaces = marketplaces.Where( x => x.IsAmazonMarketplace ).ToList();
			if( marketplaces.Count == 0 )
				return null;

			var regionsCount = marketplaces.GroupBy( x => x.RegionCode ).Count();
			if( regionsCount != 1 )
				return null;

			var duplicates = marketplaces.GroupBy( x => x.MarketplaceId ).Any( x => x.Count() > 1 );
			if( duplicates )
				return null;

			return new AmazonMarketplaces( marketplaces );
		}

		public List< string > GetMarketplaceIdAsList()
		{
			var marketplaceIds = this.Marketplaces.Select( x => x.MarketplaceId ).ToList();
			return marketplaceIds;
		}
	}
}