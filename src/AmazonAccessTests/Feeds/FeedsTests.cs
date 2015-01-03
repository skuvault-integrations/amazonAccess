using System.Collections.Generic;
using AmazonAccess;
using AmazonAccess.Services.FbaInventoryServiceMws.Model;
using NUnit.Framework;

namespace AmazonAccessTests.Feeds
{
	[ TestFixture ]
	public sealed class FeedsTests
	{
		private readonly IAmazonFactory AmazonFactory = new AmazonFactory("", "");

		[ Test ]
		public void SubmitFeed()
		{
			var service = this.AmazonFactory.CreateService( "" );

			var itemsList = new List< AmazonInventoryItem >();
			for( var i = 0; i < 100; i++ )
			{
				itemsList.Add(new AmazonInventoryItem { Quantity = 12, Sku = "S&amp;C-WB-Alec-Gry-7" + i });
			}

			service.UpdateInventory( itemsList );
		}
	}
}