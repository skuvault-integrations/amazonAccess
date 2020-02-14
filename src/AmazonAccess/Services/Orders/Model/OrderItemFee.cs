namespace AmazonAccess.Services.Orders.Model
{
	public class OrderItemFee
	{
		public string FeeType { get; set; }
		public decimal CurrencyAmount { get; set; }
		public string CurrencyCode { get; set; }
	}
}
