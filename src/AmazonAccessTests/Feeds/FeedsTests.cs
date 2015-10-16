using System.Collections.Generic;
using System.Linq;
using AmazonAccess;
using AmazonAccess.Services.FbaInventoryServiceMws.Model;
using LINQtoCSV;
using Netco.Logging;
using NUnit.Framework;

namespace AmazonAccessTests.Feeds
{
	[ TestFixture ]
	public sealed class FeedsTests
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
		public void SubmitFeed()
		{
			var service = this.AmazonFactory.CreateService( this.Config.SellerId, this.Config.MwsAuthToken, this.Config.ParseMarketplaces() );

			var itemsList = new List< AmazonInventoryItem >();
			for( var i = 0; i < 100; i++ )
			{
				itemsList.Add( new AmazonInventoryItem { Quantity = 12, Sku = "S&amp;C-WB-Alec-Gry-7" + i } );
			}

			service.UpdateInventory( itemsList );
		}
	}
}