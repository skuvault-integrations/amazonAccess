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
		private readonly Dictionary< AmazonRegionEnum, AmazonAppCredentials > AppCredentials = new Dictionary< AmazonRegionEnum, AmazonAppCredentials >();

		public AmazonFactory( AmazonAppCredentials naRegionCredentials = null, AmazonAppCredentials euRegionCredentials = null,
			AmazonAppCredentials feRegionCredentials = null, AmazonAppCredentials cnRegionCredentials = null )
		{
			if( naRegionCredentials != null )
				this.AppCredentials.Add( AmazonRegionEnum.Na, naRegionCredentials );

			if( euRegionCredentials != null )
				this.AppCredentials.Add( AmazonRegionEnum.Eu, euRegionCredentials );

			if( feRegionCredentials != null )
				this.AppCredentials.Add( AmazonRegionEnum.Fe, feRegionCredentials );

			if( cnRegionCredentials != null )
				this.AppCredentials.Add( AmazonRegionEnum.Cn, cnRegionCredentials );
		}

		public IAmazonService CreateService( string sellerId, string mwsAuthToken, AmazonMarketplaces amazonMarketplaces )
		{
			Condition.Requires( sellerId, "sellerId" ).IsNotNullOrWhiteSpace();
			Condition.Requires( mwsAuthToken, "mwsAuthToken" ).IsNotNullOrWhiteSpace();
			Condition.Requires( amazonMarketplaces, "amazonMarketplaces" ).IsNotNull();
			Condition.Requires( this.AppCredentials.ContainsKey( amazonMarketplaces.Region ), "AppCredentials" ).IsTrue( "Credentials for region are not found" );

			var credentials = this.AppCredentials[ amazonMarketplaces.Region ];
			return new AmazonService( new AmazonCredentials( credentials.AccessKeyId, credentials.SecretAccessKeyId, sellerId, mwsAuthToken, amazonMarketplaces ) );
		}
	}
}