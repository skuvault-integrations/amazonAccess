using System.Collections.Generic;
using AmazonAccess.Services.FbaInventoryServiceMws.Model;
using NUnit.Framework;

namespace AmazonAccessTests.Feeds
{
	[ TestFixture ]
	internal sealed class FeedsTests: TestsBase
	{
		[ SetUp ]
		public void Init()
		{
		}

		[ Test ]
		public void SubmitFeed()
		{
			var service = this.AmazonFactory.CreateService( this.ClientConfig.SellerId, this.ClientConfig.MwsAuthToken, this.ClientConfig.ParseMarketplaces() );

			var itemsList = new List< AmazonInventoryItem >();
			for( var i = 0; i < 100; i++ )
			{
				itemsList.Add( new AmazonInventoryItem { Quantity = 12, Sku = "S&amp;C-WB-Alec-Gry-7" + i } );
			}

			service.UpdateInventory( itemsList );
		}
	}
}