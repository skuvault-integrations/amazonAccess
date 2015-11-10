using AmazonAccess.Misc;
using AmazonAccess.Models;
using AmazonAccess.Services.MarketplaceWebServiceSellers.Model;
using CuttingEdge.Conditions;

namespace AmazonAccess.Services.MarketplaceWebServiceSellers
{
	public class SellerMarketplaceService
	{
		private readonly IMarketplaceWebServiceSellers _client;
		private readonly AmazonCredentials _credentials;
		private readonly Throttler _throttler = new Throttler( 15, 61 );

		public SellerMarketplaceService( IMarketplaceWebServiceSellers client, AmazonCredentials credentials )
		{
			Condition.Requires( client, "client" ).IsNotNull();
			Condition.Requires( credentials, "credentials" ).IsNotNull();

			this._client = client;
			this._credentials = credentials;
		}

		public MarketplaceParticipations GetMarketplaceParticipations()
		{
			var request = new ListMarketplaceParticipationsRequest
			{
				SellerId = this._credentials.SellerId,
				MWSAuthToken = this._credentials.MwsAuthToken
			};
			var result = new MarketplaceParticipations();
			var response = ActionPolicies.Get.Get( () => this._throttler.Execute( () => this._client.ListMarketplaceParticipations( request ) ) );
			if( !response.IsSetListMarketplaceParticipationsResult() )
				return result;

			result.Add( response.ListMarketplaceParticipationsResult.ListMarketplaces, response.ListMarketplaceParticipationsResult.ListParticipations );
			this.AddMarketplaceParticipationsFromOtherPages( response.ListMarketplaceParticipationsResult.NextToken, result );
			return result;
		}

		private void AddMarketplaceParticipationsFromOtherPages( string nextToken, MarketplaceParticipations result )
		{
			while( !string.IsNullOrEmpty( nextToken ) )
			{
				var request = new ListMarketplaceParticipationsByNextTokenRequest
				{
					SellerId = this._credentials.SellerId,
					MWSAuthToken = this._credentials.MwsAuthToken,
					NextToken = nextToken
				};
				var response = ActionPolicies.Get.Get( () => this._throttler.Execute( () => this._client.ListMarketplaceParticipationsByNextToken( request ) ) );
				if( !response.IsSetListMarketplaceParticipationsByNextTokenResult() )
					return;

				result.Add( response.ListMarketplaceParticipationsByNextTokenResult.ListMarketplaces, response.ListMarketplaceParticipationsByNextTokenResult.ListParticipations );
				nextToken = response.ListMarketplaceParticipationsByNextTokenResult.NextToken;
			}
		}
	}
}