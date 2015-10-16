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
			{
				this.AmazonFactory = new AmazonFactory(
					naRegionCredentials : AmazonAppCredentials.TryCreate( this.Config.NaAccessKeyId, this.Config.NaSecretAccessKeyId ),
					euRegionCredentials : AmazonAppCredentials.TryCreate( this.Config.EuAccessKeyId, this.Config.EuSecretAccessKeyId ),
					feRegionCredentials : AmazonAppCredentials.TryCreate( this.Config.FeAccessKeyId, this.Config.FeSecretAccessKeyId ),
					cnRegionCredentials : AmazonAppCredentials.TryCreate( this.Config.CnAccessKeyId, this.Config.CnSecretAccessKeyId ) );
			}
		}

		[ Test ]
		public void LoadMWSAuthToken()
		{
			var service = this.AmazonFactory.CreateService( this.Config.SellerId, this.Config.MwsAuthToken, this.Config.ParseMarketplaces() );

			var token = service.GetMwsAuthToken();
			token.Should().NotBeEmpty();
		}
	}
}