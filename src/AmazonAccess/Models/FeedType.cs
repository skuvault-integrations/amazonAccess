namespace AmazonAccess.Models
{
	public class FeedType
	{
		public static readonly FeedType Unknown = new FeedType( string.Empty );
		public static readonly FeedType InventoryQuantityUpdate = new FeedType( "_POST_INVENTORY_AVAILABILITY_DATA_" );

		private FeedType( string description )
		{
			this.Description = description;
		}

		public string Description { get; private set; }
	}
}