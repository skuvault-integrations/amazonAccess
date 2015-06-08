namespace AmazonAccess.Models
{
	public class ReportType
	{
		public static readonly ReportType Unknown = new ReportType( string.Empty );
		public static readonly ReportType Inventory = new ReportType( "_GET_FLAT_FILE_OPEN_LISTINGS_DATA_" );
		public static readonly ReportType FbaFulfilledInventory = new ReportType( "_GET_AFN_INVENTORY_DATA_" );
		public static readonly ReportType FbaMultiCountryInventory = new ReportType( "_GET_AFN_INVENTORY_DATA_BY_COUNTRY_" );
		public static readonly ReportType FbaManageInventory = new ReportType( "_GET_FBA_MYI_UNSUPPRESSED_INVENTORY_DATA_" );
		public static readonly ReportType FbaManageInventoryArchived = new ReportType( "_GET_FBA_MYI_ALL_INVENTORY_DATA_" );
		public static readonly ReportType FbaReceivedInventory = new ReportType( "_GET_FBA_FULFILLMENT_INVENTORY_RECEIPTS_DATA_" );
		public static readonly ReportType FbaReservedInventory = new ReportType( "_GET_RESERVED_INVENTORY_DATA_" );
		public static readonly ReportType FbaInventoryEventDetail = new ReportType( "_GET_FBA_FULFILLMENT_INVENTORY_SUMMARY_DATA_" );

		private ReportType( string description )
		{
			this.Description = description;
		}

		public string Description { get; private set; }
	}
}