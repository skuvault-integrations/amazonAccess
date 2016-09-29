using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AmazonAccess.Services.Orders.Model;
using AmazonAccessTests.Misc;
using FluentAssertions;
using NUnit.Framework;

namespace AmazonAccessTests.Tests
{
	internal class OrdersTests: TestsBase
	{
		[ SetUp ]
		public void Init()
		{
		}

		[ Test ]
		public void LoadOrdersById()
		{
			var service = this.AmazonFactory.CreateService( this.ClientConfig.SellerId, this.ClientConfig.MwsAuthToken, this.ClientConfig.ParseMarketplaces() );

			var ids = new List< string > { "" };
			var allOrders = new List< ComposedOrder >();
			var ordersCount = service.GetOrdersById( ids, o =>
			{
				allOrders.Add( o );
			} );

			allOrders.Count().Should().BeGreaterThan( 0 );
			allOrders.Count().Should().Be( ordersCount );
		}

		[ Test ]
		public void LoadOrders()
		{
			var service = this.AmazonFactory.CreateService( this.ClientConfig.SellerId, this.ClientConfig.MwsAuthToken, this.ClientConfig.ParseMarketplaces() );

			var allOrders = new List< ComposedOrder >();
			var foundOrders = new List< ComposedOrder >();
			var ids = new List< string > { "" };
			var count = 0;

			var stopwatch = new Stopwatch();
			stopwatch.Start();

			//var ordersCount = service.GetOrders( new DateTime( 2015, 5, 19, 0, 0, 0, 0, DateTimeKind.Utc ), new DateTime( 2015, 5, 22, 0, 0, 0, 0, DateTimeKind.Utc ), order =>
			var ordersCount = service.GetOrders( DateTime.UtcNow - TimeSpan.FromDays( 3 ), DateTime.UtcNow, order =>
			{
				allOrders.Add( order );
				//if( ids.Any( o => o.Equals( order.AmazonOrder.AmazonOrderId, StringComparison.InvariantCultureIgnoreCase ) ) )
				//	foundOrders.Add( order );

				count++;
				if( count == 100 )
				{
					Console.WriteLine( "Got 100 orders in {0}", stopwatch.Elapsed );
					count = 0;
					stopwatch.Restart();
				}
			} );

			var marketplaces = allOrders.GroupBy( x => x.AmazonOrder.MarketplaceId ).ToList();
			allOrders.Count().Should().BeGreaterThan( 0 );
			allOrders.Count().Should().Be( ordersCount );
		}

		[ Test ]
		public void IsOrdersReceived()
		{
			var service = this.AmazonFactory.CreateService( this.ClientConfig.SellerId, this.ClientConfig.MwsAuthToken, this.ClientConfig.ParseMarketplaces() );

			var result = service.TryGetOrders( DateTime.UtcNow - TimeSpan.FromDays( 14 ), DateTime.UtcNow );
			result.Should().BeTrue();
		}
	}
}