﻿using System.Collections.Generic;
using System.Linq;
using AmazonAccess;
using AmazonAccess.Models;
using AmazonAccess.Services.FbaInventoryServiceMws.Model;
using LINQtoCSV;
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
			const string credentialsFilePath = @"..\..\Files\AmazonCredentials.csv";

			var cc = new CsvContext();
			this.Config = cc.Read< TestConfig >( credentialsFilePath, new CsvFileDescription { FirstLineHasColumnNames = true } ).FirstOrDefault();

			if( this.Config != null )
				this.AmazonFactory = new AmazonFactory( this.Config.AccessKeyId, this.Config.SecretAccessKeyId );
		}

		[ Test ]
		public void SubmitFeed()
		{
			var marketplace = new AmazonMarketplace( AmazonCountryCodesEnum.Us );
			var service = this.AmazonFactory.CreateService( this.Config.SellerId, this.Config.MwsAuthToken, marketplace );

			var itemsList = new List< AmazonInventoryItem >();
			for( var i = 0; i < 100; i++ )
			{
				itemsList.Add( new AmazonInventoryItem { Quantity = 12, Sku = "S&amp;C-WB-Alec-Gry-7" + i } );
			}

			service.UpdateInventory( itemsList );
		}
	}
}