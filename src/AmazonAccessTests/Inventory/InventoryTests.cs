using System.Collections.Generic;
using System.Linq;
using AmazonAccess;
using AmazonAccess.Models;
using AmazonAccess.Services.FbaInventoryServiceMws.Model;
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
		public void LoadInventory()
		{
			var marketplace = new AmazonMarketplace( AmazonCountryCodesEnum.Us );
			var service = this.AmazonFactory.CreateService( this.Config.SellerId, marketplace );

			var inventory = service.GetInventory();
			inventory.Count().Should().BeGreaterThan( 0 );
		}

		[ Test ]
		public void LoadFbaInventory()
		{
			var marketplace = new AmazonMarketplace( AmazonCountryCodesEnum.Us );
			var service = this.AmazonFactory.CreateService( this.Config.SellerId, marketplace );

			var inventory = service.GetFbaInventory();
			inventory.Count().Should().BeGreaterThan( 0 );
		}

		[ Test ]
		public void UpdateInventory()
		{
			var marketplace = new AmazonMarketplace( AmazonCountryCodesEnum.Us );
			//var service = this.AmazonFactory.CreateService( "" );
			var service = this.AmazonFactory.CreateService( "", marketplace );
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