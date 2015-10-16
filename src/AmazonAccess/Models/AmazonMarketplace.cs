using System;
using CuttingEdge.Conditions;
using Netco.Extensions;

namespace AmazonAccess.Models
{
	public sealed class AmazonMarketplace
	{
		public string MarketplaceId{ get; private set; }
		public string Endpoint{ get; private set; }
		public string OrdersServiceUrl{ get; private set; }
		public string FbaInventoryServiceUrl{ get; private set; }
		public string FeedsServiceUrl{ get; private set; }
		public string SellersServiceUrl{ get; private set; }
		public AmazonRegionEnum Region{ get; private set; }
		public AmazonCountryCodeEnum CountryCode{ get; private set; }

		public AmazonMarketplace( string countryCode )
			: this( countryCode.ToEnum( AmazonCountryCodeEnum.Unknown ) )
		{
		}

		public AmazonMarketplace( AmazonCountryCodeEnum countryCode )
		{
			Condition.Requires( countryCode, "countryCode" ).IsGreaterThan( AmazonCountryCodeEnum.Unknown );
			this.InitMarketplace( countryCode );
		}

		private void InitMarketplace( AmazonCountryCodeEnum countryCode )
		{
			this.CountryCode = countryCode;
			switch( countryCode )
			{
				case AmazonCountryCodeEnum.Ca:
					this.Region = AmazonRegionEnum.Na;
					this.MarketplaceId = "A2EUQ1WTGCTBG2";
					this.Endpoint = "https://mws.amazonservices.ca";
					break;
				case AmazonCountryCodeEnum.Us:
					this.Region = AmazonRegionEnum.Na;
					this.MarketplaceId = "ATVPDKIKX0DER";
					this.Endpoint = "https://mws.amazonservices.com";
					break;
				case AmazonCountryCodeEnum.Mx:
					this.Region = AmazonRegionEnum.Na;
					this.MarketplaceId = "A1AM78C64UM0Y8";
					this.Endpoint = "https://mws.amazonservices.com.mx";
					break;

				case AmazonCountryCodeEnum.De:
					this.Region = AmazonRegionEnum.Eu;
					this.MarketplaceId = "A1PA6795UKMFR9";
					this.Endpoint = "https://mws-eu.amazonservices.com";
					break;
				case AmazonCountryCodeEnum.Es:
					this.Region = AmazonRegionEnum.Eu;
					this.MarketplaceId = "A1RKKUPIHCS9HS";
					this.Endpoint = "https://mws-eu.amazonservices.com";
					break;
				case AmazonCountryCodeEnum.Fr:
					this.Region = AmazonRegionEnum.Eu;
					this.MarketplaceId = "A13V1IB3VIYZZH";
					this.Endpoint = "https://mws-eu.amazonservices.com";
					break;
				case AmazonCountryCodeEnum.In:
					this.Region = AmazonRegionEnum.Eu;
					this.MarketplaceId = "A21TJRUUN4KGV";
					this.Endpoint = "https://mws.amazonservices.in";
					break;
				case AmazonCountryCodeEnum.It:
					this.Region = AmazonRegionEnum.Eu;
					this.MarketplaceId = "APJ6JRA9NG5V4";
					this.Endpoint = "https://mws-eu.amazonservices.com";
					break;
				case AmazonCountryCodeEnum.Uk:
					this.Region = AmazonRegionEnum.Eu;
					this.MarketplaceId = "A1F83G8C2ARO7P";
					this.Endpoint = "https://mws-eu.amazonservices.com";
					break;

				case AmazonCountryCodeEnum.Jp:
					this.Region = AmazonRegionEnum.Fe;
					this.MarketplaceId = "A1VC38T7YXB528";
					this.Endpoint = "https://mws.amazonservices.jp";
					break;

				case AmazonCountryCodeEnum.Cn:
					this.Region = AmazonRegionEnum.Cn;
					this.MarketplaceId = "AAHKV2X7AFYLW";
					this.Endpoint = "https://mws.amazonservices.com.cn";
					break;
				default:
					throw new Exception( "Incorrect country code" );
			}

			this.OrdersServiceUrl = this.Endpoint + "/Orders/2013-09-01";
			this.FbaInventoryServiceUrl = this.Endpoint + "/FulfillmentInventory/2010-10-01";
			this.FeedsServiceUrl = this.Endpoint;
			this.SellersServiceUrl = this.Endpoint + "/Sellers/2011-07-01";
		}
	}

	public enum AmazonRegionEnum
	{
		Unknown,
		Na,
		Eu,
		Fe,
		Cn
	}

	public enum AmazonCountryCodeEnum
	{
		Unknown,
		Ca,
		Us,
		Mx,
		De,
		Es,
		Fr,
		In,
		It,
		Uk,
		Jp,
		Cn
	}
}