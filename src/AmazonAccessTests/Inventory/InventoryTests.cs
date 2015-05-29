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
			const string credentialsFilePath = @"..\..\Files\AmazonCredentials.csv";

			var cc = new CsvContext();
			this.Config = cc.Read< TestConfig >( credentialsFilePath, new CsvFileDescription { FirstLineHasColumnNames = true } ).FirstOrDefault();

			if( this.Config != null )
				this.AmazonFactory = new AmazonFactory( this.Config.AccessKeyId, this.Config.SecretAccessKeyId );
		}

		[ Test ]
		public void LoadFbaInventory()
		{
			var marketplace = new AmazonMarketplace( AmazonCountryCodesEnum.Us );
			var service = this.AmazonFactory.CreateService( this.Config.SellerId, this.Config.MwsAuthToken, marketplace );

			var inventory = service.GetFbaInventory();
			var serializer = new XmlSerializer( typeof( List< InventorySupply > ) );
			var writer = new StringWriter();
			serializer.Serialize( writer, inventory.ToList() );
			var xml = writer.GetStringBuilder().ToString();

			inventory.Count().Should().BeGreaterThan( 0 );
		}

		[ Test ]
		public void LoadDetailedFbaInventory()
		{
			var marketplace = new AmazonMarketplace( AmazonCountryCodesEnum.Us );
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
			var marketplace = new AmazonMarketplace( AmazonCountryCodesEnum.Us );
			//var service = this.AmazonFactory.CreateService( "" );
			var service = this.AmazonFactory.CreateService( "", this.Config.MwsAuthToken, marketplace );
			//var inventory = service.GetFbaInventory();

			//var item = inventory.FirstOrDefault();
			service.UpdateInventory( new List< AmazonInventoryItem >
			{
				new AmazonInventoryItem
				{
					Quantity = 33,
					Sku = "HF-FI6M-WWVD"
				}
			} );
		}
	}
}