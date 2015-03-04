using CuttingEdge.Conditions;

namespace AmazonAccess.Models
{
	public sealed class AmazonCredentials
	{
		public string AccessKeyId{ get; private set; }
		public string SecretAccessKeyId{ get; private set; }
		public string SellerId{ get; private set; }
		public string MwsAuthToken{ get; private set; }
		public AmazonMarketplace AmazonMarketplace{ get; private set; }

		public AmazonCredentials( string accessKeyId, string secretAccessKeyId, string sellerId, string mwsAuthToken, AmazonMarketplace amazonMarketplace )
		{
			Condition.Requires( accessKeyId, "accessKeyId" ).IsNotNullOrWhiteSpace();
			Condition.Requires( secretAccessKeyId, "secretAccessKeyId" ).IsNotNullOrWhiteSpace();
			Condition.Requires( sellerId, "sellerId" ).IsNotNullOrWhiteSpace();
			Condition.Requires( mwsAuthToken, "mwsAuthToken" ).IsNotNullOrWhiteSpace();
			Condition.Requires( amazonMarketplace, "amazonMarketplace" ).IsNotNull();

			this.AccessKeyId = accessKeyId;
			this.SecretAccessKeyId = secretAccessKeyId;
			this.SellerId = sellerId;
			this.AmazonMarketplace = amazonMarketplace;
			this.MwsAuthToken = mwsAuthToken;
		}
	}
}