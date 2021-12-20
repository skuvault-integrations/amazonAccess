using System;
using CuttingEdge.Conditions;
using Netco.Extensions;

namespace AmazonAccess.Models
{
	public sealed class AmazonMarketplace : AmazonMarketplaceBasicInfo
	{
		public bool IsAmazonMarketplace{ get; private set; }
		public string OrdersServiceUrl => this.Endpoint + AmazonEndpointsRelative.Orders;
		public string ProductsServiceUrl => this.Endpoint + AmazonEndpointsRelative.Products;
		public string FbaInventoryServiceUrl => this.Endpoint + AmazonEndpointsRelative.FbaInventory;
		public string FbaInboundServiceUrl => this.Endpoint + AmazonEndpointsRelative.FbaInbound;
		public string FeedsServiceUrl => this.Endpoint;
		public string SellersServiceUrl => this.Endpoint + AmazonEndpointsRelative.Sellers;
		public string FinancesServiceUrl => this.Endpoint + AmazonEndpointsRelative.Finances;
		public AmazonCountryCodeEnum CountryCode{ get; private set; }

		public AmazonMarketplace( string countryCode, string marketplaceId = null )
			: this( countryCode.ToEnum( AmazonCountryCodeEnum.Unknown ), marketplaceId )
		{
		}

		public AmazonMarketplace( AmazonCountryCodeEnum countryCode, string marketplaceId = null )
		{
			Condition.Requires( countryCode, "countryCode" ).IsGreaterThan( AmazonCountryCodeEnum.Unknown );
			this.InitMarketplace( countryCode, marketplaceId );
		}

		public static AmazonMarketplace CreateForRegion( string region )
		{
			return CreateForRegion( region.ToEnum( AmazonRegionCodeEnum.Unknown ) );
		}

		public static AmazonMarketplace CreateForRegion( AmazonRegionCodeEnum regionCode )
		{
			Condition.Requires( regionCode, "regionCode" ).IsGreaterThan( AmazonRegionCodeEnum.Unknown );

			var countryCode = GetDefaultCountryCodeForRegion( regionCode );
			return new AmazonMarketplace( countryCode );
		}

		private static AmazonCountryCodeEnum GetDefaultCountryCodeForRegion( AmazonRegionCodeEnum regionCode )
		{
			AmazonCountryCodeEnum countryCode;
			switch( regionCode )
			{
				case AmazonRegionCodeEnum.Na:
					countryCode = AmazonCountryCodeEnum.Us;
					break;
				case AmazonRegionCodeEnum.Eu:
					countryCode = AmazonCountryCodeEnum.Uk;
					break;
				case AmazonRegionCodeEnum.Fe:
					countryCode = AmazonCountryCodeEnum.Jp;
					break;
				case AmazonRegionCodeEnum.Cn:
					countryCode = AmazonCountryCodeEnum.Cn;
					break;
				default:
					throw new Exception( "Incorrect region" );
			}
			return countryCode;
		}

		private void InitMarketplace( AmazonCountryCodeEnum countryCode, string marketplaceId )
		{
			this.CountryCode = countryCode;
			this.IsAmazonMarketplace = true;
			var marketplace = AmazonMarketplacesHelper.GetMarketplaceByCountryCode( countryCode );
			this.RegionCode = marketplace.RegionCode;
			this.MarketplaceId = marketplace.MarketplaceId;
			this.Endpoint = marketplace.Endpoint;
			
			if( !string.IsNullOrWhiteSpace( marketplaceId ) && !this.MarketplaceId.Equals( marketplaceId, StringComparison.InvariantCultureIgnoreCase ) )
			{
				this.MarketplaceId = marketplaceId;
				this.IsAmazonMarketplace = false;
			}
		}
	}

	public enum AmazonRegionCodeEnum
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
		Br,
		Ae,
		De,
		Es,
		Fr,
		In,
		It,
		Tr,
		Uk,
		Gb,
		Jp,
		Au,
		Cn,
		Nl,
		Se,
		Eg,
		Sa,
		Sg,
		Pl
	}
}