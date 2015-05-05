using System;
using System.Diagnostics;
using System.Linq;
using AmazonAccess;
using AmazonAccess.Models;
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
//			NetcoLogger.LoggerFactory = new ConsoleLoggerFactory();
			const string credentialsFilePath = @"..\..\Files\AmazonCredentials.csv";

			var cc = new CsvContext();
			this.Config = cc.Read< TestConfig >( credentialsFilePath, new CsvFileDescription { FirstLineHasColumnNames = true } ).FirstOrDefault();

			if( this.Config != null )
				this.AmazonFactory = new AmazonFactory( this.Config.AccessKeyId, this.Config.SecretAccessKeyId );
		}

		[ Test ]
		public void LoadOrders()
		{
			var marketplace = new AmazonMarketplace( AmazonCountryCodesEnum.Us );
			var service = this.AmazonFactory.CreateService( this.Config.SellerId, this.Config.MwsAuthToken, marketplace );

			var count = 0;
			var stopwatch = new Stopwatch();
			var orders = service.GetOrders( DateTime.UtcNow - TimeSpan.FromDays( 14 ), DateTime.UtcNow );
			stopwatch.Start();
			foreach( var order in orders )
			{
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
	}
}