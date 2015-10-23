using FluentAssertions;
using NUnit.Framework;

namespace AmazonAccessTests.Sellers
{
	internal class SellersTests: TestsBase
	{
		[ SetUp ]
		public void Init()
		{
		}

		[ Test ]
		public void LoadMWSAuthToken()
		{
			var service = this.AmazonFactory.CreateService( this.ClientConfig.SellerId, this.ClientConfig.MwsAuthToken, this.ClientConfig.ParseMarketplaces() );

			var token = service.GetMwsAuthToken();
			token.Should().NotBeEmpty();
		}

		[ Test ]
		public void GetMarketplaceParticipations()
		{
			var service = this.AmazonFactory.CreateService( this.ClientConfig.SellerId, this.ClientConfig.MwsAuthToken, this.ClientConfig.ParseMarketplaces() );

			var result = service.GetMarketplaceParticipations();
			result.Should().NotBeNull();
		}
	}
}