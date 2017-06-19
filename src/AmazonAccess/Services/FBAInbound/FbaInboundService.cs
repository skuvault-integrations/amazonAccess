/******************************************************************************* 
 *  Copyright 2009 Amazon Services. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"); 
 *  
 *  You may not use this file except in compliance with the License. 
 *  You may obtain a copy of the License at: http://aws.amazon.com/apache2.0
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the 
 *  specific language governing permissions and limitations under the License.
 * ***************************************************************************** 
 * 
 *  FBA Inventory Service MWS CSharp Library
 *  API Version: 2010-10-01
 *  Generated: Fri Oct 22 09:53:30 UTC 2010 
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using AmazonAccess.Misc;
using AmazonAccess.Models;
using AmazonAccess.Services.FbaInventory;
using AmazonAccess.Services.FbaInventory.Model;
using AmazonAccess.Services.FBAInbound;
using AmazonAccess.Services.FBAInbound.Model;
using CuttingEdge.Conditions;

namespace AmazonAccess.Services.FbaInbound
{
	public class FbaInboundService
	{
		private readonly IFbaInboundServiceClient _client;
		private readonly AmazonCredentials _credentials;
		private readonly Throttler _throttler = new Throttler( 30, 1 );

		/// <param name="client">Instance of FBAInventoryServiceMWS client</param>
		/// <param name="credentials">credentials</param>
		public FbaInboundService( IFbaInboundServiceClient client, AmazonCredentials credentials )
		{
			Condition.Requires( client, "client" ).IsNotNull();
			Condition.Requires( credentials, "credentials" ).IsNotNull();

			this._client = client;
			this._credentials = credentials;
		}

		/// <summary>
		/// Get information about the supply of seller-owned inventory in
		/// Amazon's fulfillment network. "Supply" is inventory that is available
		/// for fulfilling (a.k.a. Multi-Channel Fulfillment) orders. In general
		/// this includes all sellable inventory that has been received by Amazon,
		/// that is not reserved for existing orders or for internal FC processes,
		/// and also inventory expected to be received from inbound shipments.
		/// This operation provides 2 typical usages by setting different
		/// ListInventorySupplyRequest value:
		/// 
		/// 1. Set value to SellerSkus and not set value to QueryStartDateTime,
		/// this operation will return all sellable inventory that has been received
		/// by Amazon's fulfillment network for these SellerSkus.
		/// 2. Not set value to SellerSkus and set value to QueryStartDateTime,
		/// This operation will return information about the supply of all seller-owned
		/// inventory in Amazon's fulfillment network, for inventory items that may have had
		/// recent changes in inventory levels. It provides the most efficient mechanism
		/// for clients to maintain local copies of inventory supply data.
		/// Only 1 of these 2 parameters (SellerSkus and QueryStartDateTime) can be set value for 1 request.
		/// If both with values or neither with values, an exception will be thrown.
		/// This operation is used with ListInventorySupplyByNextToken
		/// to paginate over the resultset. Begin pagination by invoking the
		/// ListInventorySupply operation, and retrieve the first set of
		/// results. If more results are available,continuing iteratively requesting further
		/// pages results by invoking the ListInventorySupplyByNextToken operation (each time
		/// passing in the NextToken value from the previous result), until the returned NextToken
		/// is null, indicating no further results are available.
		/// 
		/// </summary>
		public IEnumerable< InboundShipmentInfo > GetListInboundShipments( string marker )
		{
			AmazonLogger.Trace( "ListInboundShipments", this._credentials.SellerId, marker, "Begin invoke" );

			var marketplaces = this._credentials.AmazonMarketplaces.GetMarketplaceIdAsList();
			var request = new ListInboundShipmentsRequest
			{
				SellerId = this._credentials.SellerId,
				MWSAuthToken = this._credentials.MwsAuthToken,
				ShipmentStatusList = new ShipmentStatusList() { member = new List< string >() { "WORKING" } }
			};
			var result = new List< InboundShipmentInfo >();
			var response = ActionPolicies.Get.Get( () => this._throttler.Execute( () => this._client.ListInboundShipments( request, marker ) ) );
			if( response.IsSetListInboundShipmentsResult() )
			{
				if( response.ListInboundShipmentsResult.IsSetShipmentData() )
					result.AddRange( response.ListInboundShipmentsResult.ShipmentData.member );
				this.AddFbaInventoryFromOtherPages( marker, response.ListInboundShipmentsResult.NextToken, result );
			}

			AmazonLogger.Trace( "LoadFbaInventory", this._credentials.SellerId, marker, "End invoke" );
			return result;
		}

		private void AddFbaInventoryFromOtherPages( string marker, string nextToken, List< InboundShipmentInfo > result )
		{
			while( !string.IsNullOrEmpty( nextToken ) )
			{
				AmazonLogger.Trace( "AddFbaInboundFromOtherPages", this._credentials.SellerId, marker, "NextToken:{0}", nextToken );

				var request = new ListInboundShipmentsByNextTokenRequest
				{
					SellerId = this._credentials.SellerId,
					MWSAuthToken = this._credentials.MwsAuthToken,
					NextToken = nextToken
				};
				var response = ActionPolicies.Get.Get( () => this._throttler.Execute( () => this._client.ListInboundShipmentsByNextToken( request, marker ) ) );
				if( response.IsSetListInboundShipmentsByNextTokenResult() )
				{
					if( response.ListInboundShipmentsByNextTokenResult.IsSetShipmentData() )
						result.AddRange( response.ListInboundShipmentsByNextTokenResult.ShipmentData.member );
					nextToken = response.ListInboundShipmentsByNextTokenResult.NextToken;
				}
			}
		}
	}
}