using System.Collections.Generic;
using CuttingEdge.Conditions;

namespace AmazonAccess.Models
{
	public sealed class AmazonMarketplace
	{
		public string MarketplaceId{ get; private set; }
		public string FbaInventoryServiceUrl{ get; private set; }
		public string FeedsServiceUrl{ get; private set; }
		public string OrdersServiceUrl{ get; private set; }
		private readonly AmazonCountryCodesEnum _countryCode;

		public readonly Dictionary< AmazonCountryCodesEnum, AmazonMarketplace > Marketplaces = new Dictionary< AmazonCountryCodesEnum, AmazonMarketplace >
		{
			{ AmazonCountryCodesEnum.Us, new AmazonMarketplace( "ATVPDKIKX0DER", "https://mws.amazonservices.com/Orders/2011-01-01/", "https://mws.amazonservices.com/FulfillmentInventory/2010-10-01/", "https://mws.amazonservices.com" ) },
			{ AmazonCountryCodesEnum.Uk, new AmazonMarketplace( "A1F83G8C2ARO7P", "https://mws-eu.amazonservices.com/Orders/2011-01-01/", "https://mws-eu.amazonservices.com/FulfillmentInventory/2010-10-01/", "https://mws-eu.amazonservices.com" ) },
			{ AmazonCountryCodesEnum.Fr, new AmazonMarketplace( "A13V1IB3VIYZZH", "https://mws-eu.amazonservices.com/Orders/2011-01-01/", "https://mws-eu.amazonservices.com/FulfillmentInventory/2010-10-01/", "https://mws-eu.amazonservices.com" ) },
			{ AmazonCountryCodesEnum.Ca, new AmazonMarketplace( "A2EUQ1WTGCTBG2", "https://mws.amazonservices.ca/Orders/2011-01-01/", "https://mws.amazonservices.ca/FulfillmentInventory/2010-10-01/", "https://mws.amazonservices.ca" ) }

		};

		public AmazonMarketplace( AmazonCountryCodesEnum countryCode )
		{
			Condition.Requires( countryCode, "countryCode" ).IsGreaterThan( AmazonCountryCodesEnum.Unknown );

			this._countryCode = countryCode;
		}

		private AmazonMarketplace( string marketplaceId, string ordersServiceUrl, string fbaInventoryServiceUrl, string feedsServiceUrl )
		{
			this.MarketplaceId = marketplaceId;
			this.OrdersServiceUrl = ordersServiceUrl;
			this.FbaInventoryServiceUrl = fbaInventoryServiceUrl;
			this.FeedsServiceUrl = feedsServiceUrl;
		}

		public List< string > GetMarketplaceIdAsList()
		{
			return new List< string > { this.Marketplaces[ this._countryCode ].MarketplaceId };
		}
	}

	public enum AmazonCountryCodesEnum
	{
		Unknown,
		Us,
		Uk,
		Ca,
		Fr
	}
}