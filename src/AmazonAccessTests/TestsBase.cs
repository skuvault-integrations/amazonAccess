using System.Linq;
using AmazonAccess;
using AmazonAccess.Models;
using LINQtoCSV;
using Netco.Logging;
using NUnit.Framework;

namespace AmazonAccessTests
{
	[ TestFixture ]
	internal abstract class TestsBase
	{
		internal IAmazonFactory AmazonFactory;
		internal AppCredentialsConfig AppConfig;
		internal ClientCredentialsConfig ClientConfig;

		[ SetUp ]
		public void BaseInit()
		{
			NetcoLogger.LoggerFactory = new ConsoleLoggerFactory();
			const string appCredentialsFilePath = @"..\..\Files\AppAmazonCredentials.csv";
			const string clientCredentialsFilePath = @"..\..\Files\ClientAmazonCredentials.csv";

			var cc = new CsvContext();
			this.AppConfig = cc.Read< AppCredentialsConfig >( appCredentialsFilePath, new CsvFileDescription { FirstLineHasColumnNames = true, IgnoreUnknownColumns = true } ).FirstOrDefault();
			this.ClientConfig = cc.Read< ClientCredentialsConfig >( clientCredentialsFilePath, new CsvFileDescription { FirstLineHasColumnNames = true, IgnoreUnknownColumns = true } ).FirstOrDefault();

			if( this.AppConfig != null && this.ClientConfig != null )
			{
				this.AmazonFactory = new AmazonFactory(
					naRegionCredentials : AmazonAppCredentials.TryCreate( this.AppConfig.NaAccessKeyId, this.AppConfig.NaSecretAccessKeyId ),
					euRegionCredentials : AmazonAppCredentials.TryCreate( this.AppConfig.EuAccessKeyId, this.AppConfig.EuSecretAccessKeyId ),
					feRegionCredentials : AmazonAppCredentials.TryCreate( this.AppConfig.FeAccessKeyId, this.AppConfig.FeSecretAccessKeyId ),
					cnRegionCredentials : AmazonAppCredentials.TryCreate( this.AppConfig.CnAccessKeyId, this.AppConfig.CnSecretAccessKeyId ) );
			}
		}
	}
}