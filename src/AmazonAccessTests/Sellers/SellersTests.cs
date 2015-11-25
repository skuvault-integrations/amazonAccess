using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AmazonAccess.Models;
using AmazonAccess.Services.Sellers.Model;
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
		public void GetMarketplaceParticipations()
		{
			var service = this.AmazonFactory.CreateService( this.ClientConfig.SellerId, this.ClientConfig.MwsAuthToken, this.ClientConfig.ParseMarketplaces() );

			var result = service.GetMarketplaceParticipations();
			result.Should().NotBeNull();
		}

		[ Test ]
		public async Task GetMarketplaceParticipationsThrottlerTest()
		{
			var service = this.AmazonFactory.CreateService( this.ClientConfig.SellerId, this.ClientConfig.MwsAuthToken, this.ClientConfig.ParseMarketplaces() );

			var taskts = new List< Task< MarketplaceParticipations > >();
			for( var i = 0; i < 16; i++ )
			{
				var task = new Task< MarketplaceParticipations >( () => service.GetMarketplaceParticipations() );
				task.Start();
				taskts.Add( task );
			}
			await Task.WhenAll( taskts );

			var result = service.GetMarketplaceParticipations();
			result.Should().NotBeNull();
		}

		[ Test ]
		public void GetMarketplaceParticipationsForRegion()
		{
			var service = this.AmazonFactory.CreateService( this.ClientConfig.SellerId, this.ClientConfig.MwsAuthToken,
				new AmazonMarketplaces( AmazonMarketplace.CreateForRegion( AmazonRegionCodeEnum.Na ) ) );

			var result = service.GetMarketplaceParticipations();
			result.Should().NotBeNull();
		}
	}
}