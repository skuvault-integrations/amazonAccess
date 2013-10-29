namespace AmazonAccess.Models
{
	public class ReportType
	{
		public static readonly ReportType Unknown = new ReportType( string.Empty );
		public static readonly ReportType Inventory = new ReportType( "_GET_FLAT_FILE_OPEN_LISTINGS_DATA_" );

		private ReportType( string description )
		{
			this.Description = description;
		}

		public string Description { get; private set; }
	}
}