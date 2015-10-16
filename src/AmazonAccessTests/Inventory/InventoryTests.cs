using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using AmazonAccess;
using AmazonAccess.Services.FbaInventoryServiceMws.Model;
using AmazonAccess.Services.MarketplaceWebServiceFeedsReports.ReportModel;
using FluentAssertions;
using LINQtoCSV;
using Netco.Logging;
using NUnit.Framework;

namespace AmazonAccessTests.Inventory
{
	[ TestFixture ]
	public sealed class InventoryTests
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
		public void GetFbaInventory()
		{
			var service = this.AmazonFactory.CreateService( this.Config.SellerId, this.Config.MwsAuthToken, this.Config.ParseMarketplaces() );

			var inventory = service.GetFbaInventory();
			var serializer = new XmlSerializer( typeof( List< InventorySupply > ) );
			var writer = new StringWriter();
			serializer.Serialize( writer, inventory.ToList() );
			var xml = writer.GetStringBuilder().ToString();

			inventory.Count().Should().BeGreaterThan( 0 );
		}

		[ Test ]
		public void IsFbaInventoryReceived()
		{
			var service = this.AmazonFactory.CreateService( this.Config.SellerId, this.Config.MwsAuthToken, this.Config.ParseMarketplaces() );

			var result = service.IsFbaInventoryReceived();
			result.Should().BeTrue();
		}

		[ Test ]
		public void GetDetailedFbaInventory()
		{
			var service = this.AmazonFactory.CreateService( this.Config.SellerId, this.Config.MwsAuthToken, this.Config.ParseMarketplaces() );

			var inventory = service.GetDetailedFbaInventory();
			var serializer = new XmlSerializer( typeof( List< FbaManageInventory > ) );
			var writer = new StringWriter();
			serializer.Serialize( writer, inventory.ToList() );
			var xml = writer.GetStringBuilder().ToString();

			inventory.Count().Should().BeGreaterThan( 0 );
		}

		[ Test ]
		public void UpdateInventory()
		{
			var service = this.AmazonFactory.CreateService( this.Config.SellerId, this.Config.MwsAuthToken, this.Config.ParseMarketplaces() );

			service.UpdateInventory( new List< AmazonInventoryItem >
			{
				new AmazonInventoryItem
				{
					Quantity = 25,
					Sku = "TC-N7DR-TVNA",
					FulfillmentLatency = 1
				}
			} );
		}
	}
}