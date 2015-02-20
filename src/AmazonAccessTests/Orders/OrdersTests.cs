using System;
using System.Linq;
using AmazonAccess;
using AmazonAccess.Models;
using FluentAssertions;
using LINQtoCSV;
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
			const string credentialsFilePath = @"..\..\Files\AmazonCredentials.csv";

			var cc = new CsvContext();
			this.Config = cc.Read< TestConfig >( credentialsFilePath, new CsvFileDescription { FirstLineHasColumnNames = true } ).FirstOrDefault();

			if( this.Config != null )
				this.AmazonFactory = new AmazonFactory( this.Config.AccessKeyId, this.Config.SecretAccessKeyId );
		}

		[ Test ]
		public void LoadOrders()
		{
			var marketplace = new AmazonMarketplace( CountryCodesEnum.Us );
			var service = this.AmazonFactory.CreateService( this.Config.SellerId, marketplace );

			var orders = service.GetOrders( DateTime.UtcNow - TimeSpan.FromDays( 2 ), DateTime.UtcNow );
			orders.Count().Should().BeGreaterThan( 0 );
		}
	}
}