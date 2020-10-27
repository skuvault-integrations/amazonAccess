using CuttingEdge.Conditions;

namespace AmazonAccess.Models
{
	public sealed class AmazonCredentials
	{
		public string AccessKeyId{ get; private set; }
		public string SecretAccessKeyId{ get; private set; }
		public string SellerId{ get; private set; }
		public string MwsAuthToken{ get; private set; }
		public AmazonMarketplaces AmazonMarketplaces{ get; private set; }
		public bool IsMFN{ get; private set; }

		public AmazonCredentials( string accessKeyId, string secretAccessKeyId, string sellerId, string mwsAuthToken, AmazonMarketplaces amazonMarketplaces, bool isMFN = false )
		{
			Condition.Requires( accessKeyId, "accessKeyId" ).IsNotNullOrWhiteSpace();
			Condition.Requires( secretAccessKeyId, "secretAccessKeyId" ).IsNotNullOrWhiteSpace();
			Condition.Requires( sellerId, "sellerId" ).IsNotNullOrWhiteSpace();
			Condition.Requires( mwsAuthToken, "mwsAuthToken" ).IsNotNullOrWhiteSpace();
			Condition.Requires( amazonMarketplaces, "amazonMarketplaces" ).IsNotNull();

			this.AccessKeyId = accessKeyId;
			this.SecretAccessKeyId = secretAccessKeyId;
			this.SellerId = sellerId;
			this.AmazonMarketplaces = amazonMarketplaces;
			this.MwsAuthToken = mwsAuthToken;
			this.IsMFN = isMFN;
		}
	}
}