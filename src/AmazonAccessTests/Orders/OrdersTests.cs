using System;
using System.Linq;
using AmazonAccess;
using FluentAssertions;
using NUnit.Framework;

namespace AmazonAccessTests.Orders
{
	internal class OrdersTests
	{
		private readonly IAmazonFactory AmazonFactory = new AmazonFactory( "", "" );

		[ Test ]
		public void LoadOrders()
		{
			var service = this.AmazonFactory.CreateService( "" );

			var orders = service.GetOrders( DateTime.UtcNow - TimeSpan.FromDays( 2 ), DateTime.UtcNow );
			orders.Count().Should().BeGreaterThan( 0 );
		}
	}
}