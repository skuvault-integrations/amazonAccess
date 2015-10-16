using AmazonAccess.Models;
using CuttingEdge.Conditions;

namespace AmazonAccess
{
	public interface IAmazonFactory
	{
		IAmazonService CreateService( string sellerId, string mwsAuthToken, AmazonMarketplaces amazonMarketplaces );
	}

	public sealed class AmazonFactory: IAmazonFactory
	{
		private readonly string _accessKeyId;
		private readonly string _secretAccessKeyId;

		public AmazonFactory( string accessKeyId, string secretAccessKeyId )
		{
			Condition.Requires( accessKeyId, "accessKeyId" ).IsNotNullOrWhiteSpace();
			Condition.Requires( secretAccessKeyId, "secretAccessKeyId" ).IsNotNullOrWhiteSpace();

			this._accessKeyId = accessKeyId;
			this._secretAccessKeyId = secretAccessKeyId;
		}

		public IAmazonService CreateService( string sellerId, string mwsAuthToken, AmazonMarketplaces amazonMarketplaces )
		{
			Condition.Requires( sellerId, "sellerId" ).IsNotNullOrWhiteSpace();
			Condition.Requires( mwsAuthToken, "mwsAuthToken" ).IsNotNullOrWhiteSpace();
			Condition.Requires( amazonMarketplaces, "amazonMarketplaces" ).IsNotNull();

			return new AmazonService( new AmazonCredentials( this._accessKeyId, this._secretAccessKeyId, sellerId, mwsAuthToken, amazonMarketplaces ) );
		}
	}
}