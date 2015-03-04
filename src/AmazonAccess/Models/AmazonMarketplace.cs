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
		public string SellersServiceUrl{ get; private set; }
		private readonly AmazonCountryCodesEnum _countryCode;

		public AmazonMarketplace( AmazonCountryCodesEnum countryCode )
		{
			Condition.Requires( countryCode, "countryCode" ).IsGreaterThan( AmazonCountryCodesEnum.Unknown );

			this._countryCode = countryCode;
			this.InitMarketplace();
		}

		private void InitMarketplace()
		{
			switch( this._countryCode )
			{
				case AmazonCountryCodesEnum.Us:
					this.MarketplaceId = "ATVPDKIKX0DER";
					this.OrdersServiceUrl = "https://mws.amazonservices.com/Orders/2011-01-01/";
					this.FbaInventoryServiceUrl = "https://mws.amazonservices.com/FulfillmentInventory/2010-10-01/";
					this.FeedsServiceUrl = "https://mws.amazonservices.com";
					this.SellersServiceUrl = "https://mws.amazonservices.com/Sellers/2011-07-01/";
					break;
				case AmazonCountryCodesEnum.Uk:
					this.MarketplaceId = "A1F83G8C2ARO7P";
					this.OrdersServiceUrl = "https://mws-eu.amazonservices.com/Orders/2011-01-01/";
					this.FbaInventoryServiceUrl = "https://mws-eu.amazonservices.com/FulfillmentInventory/2010-10-01/";
					this.FeedsServiceUrl = "https://mws-eu.amazonservices.com";
					this.SellersServiceUrl = "https://mws-eu.amazonservices.com/Sellers/2011-07-01/";
					break;
				case AmazonCountryCodesEnum.Fr:
					this.MarketplaceId = "A13V1IB3VIYZZH";
					this.OrdersServiceUrl = "https://mws-eu.amazonservices.com/Orders/2011-01-01/";
					this.FbaInventoryServiceUrl = "https://mws-eu.amazonservices.com/FulfillmentInventory/2010-10-01/";
					this.FeedsServiceUrl = "https://mws-eu.amazonservices.com";
					this.SellersServiceUrl = "https://mws-eu.amazonservices.com/Sellers/2011-07-01/";
					break;
				case AmazonCountryCodesEnum.Ca:
					this.MarketplaceId = "A2EUQ1WTGCTBG2";
					this.OrdersServiceUrl = "https://mws.amazonservices.ca/Orders/2011-01-01/";
					this.FbaInventoryServiceUrl = "https://mws.amazonservices.ca/FulfillmentInventory/2010-10-01/";
					this.FeedsServiceUrl = "https://mws.amazonservices.ca";
					this.SellersServiceUrl = "https://mws.amazonservices.ca/Sellers/2011-07-01/";
					break;
			}
		}

		public List< string > GetMarketplaceIdAsList()
		{
			return new List< string > { this.MarketplaceId };
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