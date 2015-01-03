using System.Collections.Generic;
using System.Linq;
using AmazonAccess;
using AmazonAccess.Services.FbaInventoryServiceMws.Model;
using FluentAssertions;
using NUnit.Framework;

namespace AmazonAccessTests.Inventory
{
	[ TestFixture ]
	public sealed class InventoryTests
	{
		private readonly IAmazonFactory AmazonFactory = new AmazonFactory( "", "" );

		[ Test ]
		public void LoadInventory()
		{
			var service = this.AmazonFactory.CreateService( "" );

			var inventory = service.GetInventory();
			inventory.Count().Should().BeGreaterThan( 0 );
		}

		[ Test ]
		public void UpdateInventory()
		{
			//var service = this.AmazonFactory.CreateService( "" );
			var service = this.AmazonFactory.CreateService( "" );
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