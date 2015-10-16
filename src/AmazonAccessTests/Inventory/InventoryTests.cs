using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using AmazonAccess;
using AmazonAccess.Models;
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
			var marketplace = new AmazonMarketplace( AmazonCountryCodeEnum.Us );
			var service = this.AmazonFactory.CreateService( this.Config.SellerId, this.Config.MwsAuthToken, marketplace );

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
			var marketplace = new AmazonMarketplace( AmazonCountryCodeEnum.Us );
			var service = this.AmazonFactory.CreateService( this.Config.SellerId, this.Config.MwsAuthToken, marketplace );

			var result = service.IsFbaInventoryReceived();
			result.Should().BeTrue();
		}

		[ Test ]
		public void GetDetailedFbaInventory()
		{
			var marketplace = new AmazonMarketplace( AmazonCountryCodeEnum.Us );
			var service = this.AmazonFactory.CreateService( this.Config.SellerId, this.Config.MwsAuthToken, marketplace );

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
			var marketplace = new AmazonMarketplace( AmazonCountryCodeEnum.Ca );
			var service = this.AmazonFactory.CreateService( this.Config.SellerId, this.Config.MwsAuthToken, marketplace );

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