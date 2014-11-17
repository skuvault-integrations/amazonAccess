namespace AmazonAccess.Services.FbaInventoryServiceMws.Model
{
	public class AmazonInventoryItem
	{
		public string Sku { get; set; }
		public int Quantity { get; set; }
		public int FulfillmentLatency{ get; set; }
	}
}