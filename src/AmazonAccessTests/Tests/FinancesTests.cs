using AmazonAccessTests.Misc;
using FluentAssertions;
using NUnit.Framework;
using System.Linq;

namespace AmazonAccessTests.Tests
{
	class FinancesTests : TestsBase
	{
		private const string testOrderId = "114-5387419-3951443";

		[ SetUp ]
		public void Init()
		{
		}

		[ Test ]
		public void LoadOrderFees()
		{
			var service = this.AmazonFactory.CreateService( this.ClientConfig.SellerId, this.ClientConfig.MwsAuthToken, this.ClientConfig.ParseMarketplaces() );

			var orderFees = service.GetOrderFees( string.Empty, testOrderId );

			orderFees.Should().NotBeNull();
			orderFees.ShipmentItemList.Should().NotBeNullOrEmpty();
			orderFees.ShipmentItemList.First().ItemFeeList.Should().NotBeNullOrEmpty();
		}
	}
}
