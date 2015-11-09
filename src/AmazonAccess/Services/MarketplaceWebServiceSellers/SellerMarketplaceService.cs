using AmazonAccess.Misc;
using AmazonAccess.Services.MarketplaceWebServiceSellers.Model;
using CuttingEdge.Conditions;

namespace AmazonAccess.Services.MarketplaceWebServiceSellers
{
	public class SellerMarketplaceService
	{
		private readonly IMarketplaceWebServiceSellers _client;
		private readonly ListMarketplaceParticipationsRequest _request;
		private readonly Throttler _throttler = new Throttler( 15, 61 );

		public SellerMarketplaceService( IMarketplaceWebServiceSellers client, ListMarketplaceParticipationsRequest request )
		{
			Condition.Requires( client, "client" ).IsNotNull();
			Condition.Requires( request, "request" ).IsNotNull();

			this._client = client;
			this._request = request;
		}

		public MarketplaceParticipations GetMarketplaceParticipations()
		{
			var result = new MarketplaceParticipations();
			var response = ActionPolicies.Get.Get( () => this._throttler.Execute( () => this._client.ListMarketplaceParticipations( this._request ) ) );
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
					SellerId = this._request.SellerId,
					MWSAuthToken = this._request.MWSAuthToken,
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