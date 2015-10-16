using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AmazonAccess;
using AmazonAccess.Services.MarketplaceWebServiceOrders.Model;
using FluentAssertions;
using LINQtoCSV;
using Netco.Logging;
using NUnit.Framework;

namespace AmazonAccessTests.Orders
{
	internal class OrdersTests
	{
		private IAmazonFactory AmazonFactory;
		private TestConfig Config;

		[ SetUp ]
		public void Init()
		{
			NetcoLogger.LoggerFactory = new ConsoleLoggerFactory();
			const string credentialsFilePath = @"..\..\Files\AmazonCredentials.csv";

			var cc = new CsvContext();
			this.Config = cc.Read< TestConfig >( credentialsFilePath, new CsvFileDescription { FirstLineHasColumnNames = true, IgnoreUnknownColumns = true } ).FirstOrDefault();

			if( this.Config != null )
				this.AmazonFactory = new AmazonFactory( this.Config.AccessKeyId, this.Config.SecretAccessKeyId );
		}

		[ Test ]
		public void LoadOrdersById()
		{
			var service = this.AmazonFactory.CreateService( this.Config.SellerId, this.Config.MwsAuthToken, this.Config.ParseMarketplaces() );

			var ids = new List< string > { "" };
			var orders = service.GetOrdersById( ids ).ToList();

			orders.Count().Should().BeGreaterThan( 0 );
		}

		[ Test ]
		public void LoadOrders()
		{
			var service = this.AmazonFactory.CreateService( this.Config.SellerId, this.Config.MwsAuthToken, this.Config.ParseMarketplaces() );

			var count = 0;
			var stopwatch = new Stopwatch();
			var orders = service.GetOrders( DateTime.UtcNow - TimeSpan.FromDays( 14 ), DateTime.UtcNow );
			//var orders = service.GetOrders( new DateTime( 2015, 5, 19, 0, 0, 0, 0, DateTimeKind.Utc ), new DateTime( 2015, 5, 22, 0, 0, 0, 0, DateTimeKind.Utc ) );
			stopwatch.Start();

			var allOrders = new List< ComposedOrder >();
			var foundOrders = new List< ComposedOrder >();
			var ids = new List< string > { "" };

			foreach( var order in orders )
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
			}
			orders.Count().Should().BeGreaterThan( 0 );
		}

		[ Test ]
		public void IsOrdersReceived()
		{
			var service = this.AmazonFactory.CreateService( this.Config.SellerId, this.Config.MwsAuthToken, this.Config.ParseMarketplaces() );

			var result = service.IsOrdersReceived( DateTime.UtcNow - TimeSpan.FromDays( 14 ), DateTime.UtcNow );
			result.Should().BeTrue();
		}
	}
}