using System.Collections.Generic;
using System.Linq;
using CuttingEdge.Conditions;

namespace AmazonAccess.Models
{
	public sealed class AmazonMarketplaces
	{
		public string OrdersServiceUrl{ get; private set; }
		public string FbaInventoryServiceUrl{ get; private set; }
		public string FeedsServiceUrl{ get; private set; }
		public string SellersServiceUrl{ get; private set; }
		public readonly List< AmazonMarketplace > Marketplaces = new List< AmazonMarketplace >();

		public AmazonMarketplaces( string marketplace )
			: this( new AmazonMarketplace( marketplace ) )
		{
		}

		public AmazonMarketplaces( AmazonMarketplace marketplace )
		{
			Condition.Requires( marketplace, "marketplace" ).IsNotNull();

			this.OrdersServiceUrl = marketplace.OrdersServiceUrl;
			this.FbaInventoryServiceUrl = marketplace.FbaInventoryServiceUrl;
			this.FeedsServiceUrl = marketplace.FeedsServiceUrl;
			this.SellersServiceUrl = marketplace.SellersServiceUrl;
			this.Marketplaces.Add( marketplace );
		}

		public AmazonMarketplaces( List< string > marketplaces )
			: this( marketplaces.Select( x => new AmazonMarketplace( x ) ).ToList() )
		{
		}

		public AmazonMarketplaces( List< AmazonMarketplace > marketplaces )
		{
			Condition.Requires( marketplaces, "marketplaces" ).IsNotNull().IsNotEmpty();
			var regionsCount = marketplaces.GroupBy( x => x.Region ).Count();
			Condition.Requires( regionsCount, "marketplaces" ).IsEqualTo( 1, "All marketplaces should be in one region" );

			var marketplace = marketplaces.First();
			this.OrdersServiceUrl = marketplace.OrdersServiceUrl;
			this.FbaInventoryServiceUrl = marketplace.FbaInventoryServiceUrl;
			this.FeedsServiceUrl = marketplace.FeedsServiceUrl;
			this.SellersServiceUrl = marketplace.SellersServiceUrl;
			this.Marketplaces.AddRange( marketplaces );
		}

		public List< string > GetMarketplaceIdAsList()
		{
			return this.Marketplaces.Select( x => x.MarketplaceId ).ToList();
		}
	}
}