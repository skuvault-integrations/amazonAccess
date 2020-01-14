using AmazonAccess.Misc;
using AmazonAccess.Models;
using AmazonAccess.Services.Finances.Model;
using CuttingEdge.Conditions;
using System.Linq;

namespace AmazonAccess.Services.Finances
{
	public sealed class FinancesService
	{
		private readonly IFinancesServiceClient _client;
		private readonly AmazonCredentials _credentials;
		private readonly Throttler _getOrderFeesThrottler = new Throttler( 30, 2 );

		public FinancesService( IFinancesServiceClient client, AmazonCredentials credentials )
		{
			Condition.Requires( client, "client" ).IsNotNull();
			Condition.Requires( credentials, "credentials" ).IsNotNull();

			this._client = client;
			this._credentials = credentials;
		}

		public ShipmentEvent LoadOrderFees( string marker, string orderId )
		{
			if ( string.IsNullOrWhiteSpace( orderId ) )
				return null;

			AmazonLogger.Trace( "LoadOrderFees", this._credentials.SellerId, marker, "Begin invoke for order {0} ", orderId );

			ShipmentEvent result = null;
			var request = new ListFinancialEventsRequest()
			{
				 SellerId = this._credentials.SellerId,
				 MWSAuthToken = this._credentials.MwsAuthToken,
				 AmazonOrderId = orderId
			};

			var response = ActionPolicies.Get.Get( () => this._getOrderFeesThrottler.Execute( () => this._client.ListFinancialEvents( request, marker ) ) );

			if ( response.IsSetListFinancialEventsResult() )
			{
				if ( response.ListFinancialEventsResult.IsSetFinancialEvents() )
				{
					if ( response.ListFinancialEventsResult.FinancialEvents.IsSetShipmentEventList() )
					{
						result = response.ListFinancialEventsResult.FinancialEvents.ShipmentEventList.FirstOrDefault();
					}
				}
			}

			AmazonLogger.Trace( "LoadOrderFees", this._credentials.SellerId, marker, "End invoke for order {0}", orderId );

			return result;
		}
	}
}
