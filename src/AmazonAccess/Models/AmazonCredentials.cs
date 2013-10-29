using System.Collections.Generic;
using CuttingEdge.Conditions;

namespace AmazonAccess.Models
{
	public class AmazonCredentials
	{
		public string AccessKeyId { get; private set; }
		public string SecretAccessKeyId { get; private set; }
		public string SellerId { get; private set; }
		public List< string > MarketplaceIds { get; private set; }

		public AmazonCredentials( string accessKeyId, string secretAccessKeyId, string sellerId )
		{
			Condition.Requires( accessKeyId, "accessKeyId" ).IsNotNullOrWhiteSpace();
			Condition.Requires( secretAccessKeyId, "secretAccessKeyId" ).IsNotNullOrWhiteSpace();
			Condition.Requires( sellerId, "sellerId" ).IsNotNullOrWhiteSpace();

			this.AccessKeyId = accessKeyId;
			this.SecretAccessKeyId = secretAccessKeyId;
			this.SellerId = sellerId;

			//countries ids. Only USA support for now
			this.MarketplaceIds = new List< string > { "ATVPDKIKX0DER" };
		}
	}
}