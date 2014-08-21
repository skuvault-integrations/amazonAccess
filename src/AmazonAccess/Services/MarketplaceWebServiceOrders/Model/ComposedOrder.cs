using System.Collections.Generic;

namespace AmazonAccess.Services.MarketplaceWebServiceOrders.Model
{
	public class ComposedOrder
	{
		public Order AmazonOrder { get; private set; }
		public IEnumerable< OrderItem > OrderItems { get; set; }

		public ComposedOrder( Order amazonOrder )
		{
			this.AmazonOrder = amazonOrder;
			this.OrderItems = new List< OrderItem >();
		}
	}
}