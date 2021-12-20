using System;
using AmazonAccess.Models;
using FluentAssertions;
using NUnit.Framework;

namespace AmazonAccessTests.Models
{
    public class AmazonMarketplaceTests
    {
        [ Test ]
        //These tests that the marketplace mapping logic (the "switch" in class AmazonMarketplace > InitMarketplace)
        //  is unchanged once it's moved to class AmazonMarketplacesHelper > GetMarketplaceByCountryCode
        //Can be deleted after the refactoring, since it doesn't verify return values independently of constants in AmazonMarketplacesHelper 
        public void CreateAmazonMarketplace_ShouldSetCorrectMarketplaceBaseFieldValues([Values(
            AmazonCountryCodeEnum.Us, AmazonCountryCodeEnum.Ca, AmazonCountryCodeEnum.Mx,
            AmazonCountryCodeEnum.Br, AmazonCountryCodeEnum.Ae, AmazonCountryCodeEnum.De, AmazonCountryCodeEnum.Es,
            AmazonCountryCodeEnum.Fr, AmazonCountryCodeEnum.In, AmazonCountryCodeEnum.It, AmazonCountryCodeEnum.Tr,
            AmazonCountryCodeEnum.Uk, AmazonCountryCodeEnum.Gb, AmazonCountryCodeEnum.Jp, AmazonCountryCodeEnum.Au,
            AmazonCountryCodeEnum.Cn, AmazonCountryCodeEnum.Nl, AmazonCountryCodeEnum.Se, AmazonCountryCodeEnum.Eg,
            AmazonCountryCodeEnum.Sa, AmazonCountryCodeEnum.Sg, AmazonCountryCodeEnum.Pl
        )] AmazonCountryCodeEnum countryCode )
        {
            var result = new AmazonMarketplace( countryCode );
            
            result.CountryCode.Should().Be( countryCode );
            var amazonSupportedMarketplace = AmazonMarketplacesHelper.AmazonMarketplaces[ countryCode ];
            result.RegionCode.Should().Be( amazonSupportedMarketplace.RegionCode );
            result.MarketplaceId.Should().Be( amazonSupportedMarketplace.MarketplaceId );
            result.Endpoint.Should().Be( amazonSupportedMarketplace.Endpoint );
            result.IsAmazonMarketplace.Should().BeTrue();
            result.OrdersServiceUrl.Should().Be( result.Endpoint + AmazonEndpointsRelative.Orders );
            result.ProductsServiceUrl.Should().Be( result.Endpoint + AmazonEndpointsRelative.Products );
            result.FbaInventoryServiceUrl.Should().Be( result.Endpoint + AmazonEndpointsRelative.FbaInventory );
            result.FbaInboundServiceUrl.Should().Be( result.Endpoint + AmazonEndpointsRelative.FbaInbound );
            result.FeedsServiceUrl.Should().Be( result.Endpoint );
            result.SellersServiceUrl.Should().Be( result.Endpoint + AmazonEndpointsRelative.Sellers );
            result.FinancesServiceUrl.Should().Be( result.Endpoint + AmazonEndpointsRelative.Finances );
        }

        [ Test ]
        public void CreateAmazonMarketplace_WhenCountryIsUnknown_ShouldThrow()
        {
            var action = new Action(() => {
                new AmazonMarketplace( AmazonCountryCodeEnum.Unknown );
            });
            
            action.ShouldThrow< Exception >( "Incorrect country code" );
        }
        
        [ Test ]
        public void CreateAmazonMarketplace_WhenPassedInCountryCodeAndMarketplaceIdDontMatch_ShouldReturnIsAmazonMarketplaceFalse()
        {
            var marketplaceIdNotUS = "NOT US";
            
            var result = new AmazonMarketplace( AmazonCountryCodeEnum.Us, marketplaceIdNotUS );
            
            result.IsAmazonMarketplace.Should().BeFalse();
        }
    }
}