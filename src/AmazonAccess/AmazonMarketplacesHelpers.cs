using System;
using System.Collections.Generic;
using System.Linq;
using AmazonAccess.Models;

namespace AmazonAccess
{
	/// <summary>
	/// See https://docs.developer.amazonservices.com/en_US/dev_guide/DG_Endpoints.html
	/// for a list of marketplaces Amazon supports.
	/// </summary>
	public static class AmazonMarketplacesHelpers
	{
		internal static readonly Dictionary< AmazonCountryCodeEnum, AmazonMarketplaceBasicInfo > AmazonMarketplaces = new Dictionary< AmazonCountryCodeEnum, AmazonMarketplaceBasicInfo >
		{
			// Americas Region (Amazon Refers to as "North America"
			{
				AmazonCountryCodeEnum.Ca,
				new AmazonMarketplaceBasicInfo
				{
					RegionCode = AmazonRegionCodeEnum.Na,
					MarketplaceId = "A2EUQ1WTGCTBG2",
					Endpoint = "https://mws.amazonservices.ca"
				}
			},
			{
				AmazonCountryCodeEnum.Us,
				new AmazonMarketplaceBasicInfo
				{
					RegionCode = AmazonRegionCodeEnum.Na,
					MarketplaceId = "ATVPDKIKX0DER",
					Endpoint = "https://mws.amazonservices.com"
				}
			},
			{
				AmazonCountryCodeEnum.Mx,
				new AmazonMarketplaceBasicInfo
				{
					RegionCode = AmazonRegionCodeEnum.Na,
					MarketplaceId = "A1AM78C64UM0Y8",
					Endpoint = "https://mws.amazonservices.com.mx",
				}
			},
			{
				AmazonCountryCodeEnum.Br,
				new AmazonMarketplaceBasicInfo
				{
					RegionCode = AmazonRegionCodeEnum.Na,
					MarketplaceId = "A2Q3Y263D00KWC",
					Endpoint = "https://mws.amazonservices.com",
				}
			},
			// EU Region
			{
				AmazonCountryCodeEnum.Ae,
				new AmazonMarketplaceBasicInfo
				{
					RegionCode = AmazonRegionCodeEnum.Eu,
					MarketplaceId = "A2VIGQ35RCS4UG",
					Endpoint = "https://mws.amazonservices.ae",
				}
			},
			{
				AmazonCountryCodeEnum.De,
				new AmazonMarketplaceBasicInfo
				{
					RegionCode = AmazonRegionCodeEnum.Eu,
					MarketplaceId = "A1PA6795UKMFR9",
					Endpoint = "https://mws-eu.amazonservices.com",
				}
			},
			{
				AmazonCountryCodeEnum.Es,
				new AmazonMarketplaceBasicInfo
				{
					RegionCode = AmazonRegionCodeEnum.Eu,
					MarketplaceId = "A1RKKUPIHCS9HS",
					Endpoint = "https://mws-eu.amazonservices.com",
				}
			},
			{
				AmazonCountryCodeEnum.Fr,
				new AmazonMarketplaceBasicInfo
				{
					RegionCode = AmazonRegionCodeEnum.Eu,
					MarketplaceId = "A13V1IB3VIYZZH",
					Endpoint = "https://mws-eu.amazonservices.com",
				}
			},
			{
				AmazonCountryCodeEnum.In,
				new AmazonMarketplaceBasicInfo
				{
					RegionCode = AmazonRegionCodeEnum.Eu,
					MarketplaceId = "A21TJRUUN4KGV",
					Endpoint = "https://mws.amazonservices.in",
				}
			},
			{
				AmazonCountryCodeEnum.It,
				new AmazonMarketplaceBasicInfo
				{
					RegionCode = AmazonRegionCodeEnum.Eu,
					MarketplaceId = "APJ6JRA9NG5V4",
					Endpoint = "https://mws-eu.amazonservices.com",
				}
			},
			{
				AmazonCountryCodeEnum.Tr,
				new AmazonMarketplaceBasicInfo
				{
					RegionCode = AmazonRegionCodeEnum.Eu,
					MarketplaceId = "A33AVAJ2PDY3EV",
					Endpoint = "https://mws-eu.amazonservices.com",
				}
			},
			{
				AmazonCountryCodeEnum.Uk,
				GetMarketplaceGB()
			},
			{
				AmazonCountryCodeEnum.Gb,
				GetMarketplaceGB()
			},
			{
				AmazonCountryCodeEnum.Nl,
				new AmazonMarketplaceBasicInfo
				{
					RegionCode = AmazonRegionCodeEnum.Eu,
					MarketplaceId = "A1805IZSGTT6HS",
					Endpoint = "https://mws-eu.amazonservices.com",
				}
			},
			{
				AmazonCountryCodeEnum.Se,
				new AmazonMarketplaceBasicInfo
				{
					RegionCode = AmazonRegionCodeEnum.Eu,
					MarketplaceId = "A2NODRKZP88ZB9",
					Endpoint = "https://mws-eu.amazonservices.com",
				}
			},
			{
				AmazonCountryCodeEnum.Sa,
				new AmazonMarketplaceBasicInfo
				{
					RegionCode = AmazonRegionCodeEnum.Eu,
					MarketplaceId = "A17E79C6D8DWNP",
					Endpoint = "https://mws-eu.amazonservices.com",
				}
			},
			{
				AmazonCountryCodeEnum.Eg,
				new AmazonMarketplaceBasicInfo
				{
					RegionCode = AmazonRegionCodeEnum.Eu,
					MarketplaceId = "ARBP9OOSHTCHU",
					Endpoint = "https://mws-eu.amazonservices.com",
				}
			},
			{
				AmazonCountryCodeEnum.Pl,
				new AmazonMarketplaceBasicInfo
				{
					RegionCode = AmazonRegionCodeEnum.Eu,
					MarketplaceId = "A1C3SOZRARQ6R3",
					Endpoint = "https://mws-eu.amazonservices.com",
				}
			},
			// Far-East Region
			{
				AmazonCountryCodeEnum.Au,
				new AmazonMarketplaceBasicInfo
				{
					RegionCode = AmazonRegionCodeEnum.Fe,
					MarketplaceId = "A39IBJ37TRP1C6",
					Endpoint = "https://mws.amazonservices.com.au",
				}
			},
			{
				AmazonCountryCodeEnum.Jp,
				new AmazonMarketplaceBasicInfo
				{
					RegionCode = AmazonRegionCodeEnum.Fe,
					MarketplaceId = "A1VC38T7YXB528",
					Endpoint = "https://mws.amazonservices.jp",
				}
			},
			{
				AmazonCountryCodeEnum.Sg,
				new AmazonMarketplaceBasicInfo
				{
					RegionCode = AmazonRegionCodeEnum.Fe,
					MarketplaceId = "A19VAU5U5O7RUS",
					Endpoint = "https://mws-fe.amazonservices.com",
				}
			},
			{
				AmazonCountryCodeEnum.Cn,
				new AmazonMarketplaceBasicInfo
				{
					RegionCode = AmazonRegionCodeEnum.Cn,
					MarketplaceId = "AAHKV2X7AFYLW",
					Endpoint = "https://mws.amazonservices.com.cn",
				} 
			}
		};

		private static AmazonMarketplaceBasicInfo GetMarketplaceGB() => new AmazonMarketplaceBasicInfo
		{
			RegionCode = AmazonRegionCodeEnum.Eu,
			MarketplaceId = "A1F83G8C2ARO7P",
			Endpoint = "https://mws-eu.amazonservices.com",
		};

		public static bool IsAmazonMarketplace( string marketplaceId )
		{
			return AmazonMarketplaces.Any( m => m.Value.MarketplaceId == marketplaceId );
		}
	}
	
	public class AmazonMarketplaceBasicInfo
	{
		public AmazonRegionCodeEnum RegionCode { get; set; }
		public string MarketplaceId { get; set; }
		public string Endpoint { get; set; }
		
		internal void PopulateMarketplaceByCountryCode( AmazonCountryCodeEnum countryCode )
		{
			AmazonMarketplaceBasicInfo populatedMarketplace;
			if ( !AmazonMarketplacesHelpers.AmazonMarketplaces.TryGetValue( countryCode, out populatedMarketplace ) )
			{
				throw new Exception( $"Incorrect country code: {countryCode}" );
			}
			this.RegionCode = populatedMarketplace.RegionCode;
			this.MarketplaceId = populatedMarketplace.MarketplaceId;
			this.Endpoint = populatedMarketplace.Endpoint;
		}
	}
}