using AmazonAccess.Services.MarketplaceWebServiceSellers.Model;
using CuttingEdge.Conditions;

namespace AmazonAccess.Services.MarketplaceWebServiceSellers
{
	public class SellerAuthTokenService
	{
		private readonly IMarketplaceWebServiceSellers _client;
		private readonly GetAuthTokenRequest _request;

		public SellerAuthTokenService( IMarketplaceWebServiceSellers client, GetAuthTokenRequest request )
		{
			Condition.Requires( client, "client" ).IsNotNull();
			Condition.Requires( request, "request" ).IsNotNull();

			this._client = client;
			this._request = request;
		}

		public string GetToken()
		{
			var response = this._client.GetAuthToken( this._request );
			return response.GetAuthTokenResult.MWSAuthToken;
		}
	}
}