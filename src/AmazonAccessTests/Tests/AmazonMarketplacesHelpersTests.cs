using AmazonAccess;
using FluentAssertions;
using NUnit.Framework;

namespace AmazonAccessTests.Tests
{
    public class AmazonMarketplacesHelperTests
    {
        [ Test ]
		public void IsAmazonMarketplace_WhenValidAmazonMarketplaceId_ThenShouldBeTrue()
		{
			string validMarketplaceId = "APJ6JRA9NG5V4";	//Italy
			
			var result = AmazonMarketplacesHelpers.IsAmazonMarketplace( validMarketplaceId );
			
			result.Should().BeTrue();
		}

        [ Test ]
		public void IsAmazonMarketplace_WhenInvalidAmazonMarketplaceId_ThenShouldBeFalse()
		{
			string invalidMarketplaceId = "NOT A MARKETPLACE";
			
			var result = AmazonMarketplacesHelpers.IsAmazonMarketplace( invalidMarketplaceId );
			
			result.Should().BeFalse();
		}
    }
}