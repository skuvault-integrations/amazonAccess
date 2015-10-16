using System.Linq;
using AmazonAccess;
using AmazonAccess.Models;
using FluentAssertions;
using LINQtoCSV;
using Netco.Logging;
using NUnit.Framework;

namespace AmazonAccessTests.Sellers
{
	internal class SellersTests
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
		public void LoadMWSAuthToken()
		{
			var marketplace = new AmazonMarketplace( AmazonCountryCodeEnum.Us );
			var service = this.AmazonFactory.CreateService( this.Config.SellerId, this.Config.MwsAuthToken, marketplace );

			var token = service.GetMwsAuthToken();
			token.Should().NotBeEmpty();
		}
	}
}