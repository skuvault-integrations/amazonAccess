using AmazonAccess.Models;
using CuttingEdge.Conditions;

namespace AmazonAccess
{
	public interface IAmazonFactory
	{
		IAmazonService CreateService( string sellerId );
	}

	public sealed class AmazonFactory: IAmazonFactory
	{
		private readonly string _accessKeyId;
		private readonly string _secretAccessKeyId;
		private readonly AmazonMarketplace _amazonMarketplace;

		public AmazonFactory( string accessKeyId, string secretAccessKeyId, AmazonMarketplace amazonMarketplace )
		{
			Condition.Requires( accessKeyId, "accessKeyId" ).IsNotNullOrWhiteSpace();
			Condition.Requires( secretAccessKeyId, "secretAccessKeyId" ).IsNotNullOrWhiteSpace();
			Condition.Requires( amazonMarketplace, "amazonMarketplace" ).IsNotNull();

			this._accessKeyId = accessKeyId;
			this._secretAccessKeyId = secretAccessKeyId;
			this._amazonMarketplace = amazonMarketplace;
		}

		public IAmazonService CreateService( string sellerId )
		{
			Condition.Requires( sellerId, "sellerId" ).IsNotNullOrWhiteSpace();

			return new AmazonService( new AmazonCredentials( this._accessKeyId, this._secretAccessKeyId, sellerId, this._amazonMarketplace ) );
		}
	}
}