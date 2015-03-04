namespace AmazonAccess.Services.FbaInventoryServiceMws.Model
{
	public sealed class AmazonInventoryItem
	{
		public string Sku { get; set; }
		public int Quantity { get; set; }
		public int FulfillmentLatency{ get; set; }
	}
}