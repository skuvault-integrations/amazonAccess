using System.Collections.Generic;
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
		private readonly Dictionary< AmazonRegionCodeEnum, AmazonAppCredentials > AppCredentials = new Dictionary< AmazonRegionCodeEnum, AmazonAppCredentials >();

		public AmazonFactory( AmazonAppCredentials naRegionCredentials = null, AmazonAppCredentials euRegionCredentials = null,
			AmazonAppCredentials feRegionCredentials = null, AmazonAppCredentials cnRegionCredentials = null )
		{
			if( naRegionCredentials != null )
				this.AppCredentials.Add( AmazonRegionCodeEnum.Na, naRegionCredentials );

			if( euRegionCredentials != null )
				this.AppCredentials.Add( AmazonRegionCodeEnum.Eu, euRegionCredentials );

			if( feRegionCredentials != null )
				this.AppCredentials.Add( AmazonRegionCodeEnum.Fe, feRegionCredentials );

			if( cnRegionCredentials != null )
				this.AppCredentials.Add( AmazonRegionCodeEnum.Cn, cnRegionCredentials );
		}

		public IAmazonService CreateService( string sellerId, string mwsAuthToken, AmazonMarketplaces amazonMarketplaces )
		{
			Condition.Requires( sellerId, "sellerId" ).IsNotNullOrWhiteSpace();
			Condition.Requires( mwsAuthToken, "mwsAuthToken" ).IsNotNullOrWhiteSpace();
			Condition.Requires( amazonMarketplaces, "amazonMarketplaces" ).IsNotNull();
			Condition.Requires( this.AppCredentials.ContainsKey( amazonMarketplaces.RegionCode ), "AppCredentials" ).IsTrue( "Credentials for region are not found" );

			var credentials = this.AppCredentials[ amazonMarketplaces.RegionCode ];
			return new AmazonService( new AmazonCredentials( credentials.AccessKeyId, credentials.SecretAccessKeyId, sellerId, mwsAuthToken, amazonMarketplaces ) );
		}
	}
}