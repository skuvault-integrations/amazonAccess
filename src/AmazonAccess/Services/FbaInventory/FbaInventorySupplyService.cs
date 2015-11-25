﻿/******************************************************************************* 
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
using AmazonAccess.Misc;
using AmazonAccess.Services.FbaInventory.Model;
using CuttingEdge.Conditions;

namespace AmazonAccess.Services.FbaInventory
{
	public class FbaInventorySupplyService
	{
		private readonly IFbaInventoryService _client;
		private readonly ListInventorySupplyRequest _request;

		/// <param name="client">Instance of FBAInventoryServiceMWS client</param>
		/// <param name="request">ListInventorySupplyRequest request</param>
		public FbaInventorySupplyService( IFbaInventoryService client, ListInventorySupplyRequest request )
		{
			Condition.Requires( client, "client" ).IsNotNull();
			Condition.Requires( request, "request" ).IsNotNull();

			this._client = client;
			this._request = request;
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
		public IEnumerable< InventorySupply > LoadInventory()
		{
			var inventory = new List< InventorySupply >();
			var response = this._client.ListInventorySupply( this._request );

			if( response.IsSetListInventorySupplyResult() )
			{
				var listInventorySupplyResult = response.ListInventorySupplyResult;
				if( listInventorySupplyResult.IsSetInventorySupplyList() )
					inventory.AddRange( listInventorySupplyResult.InventorySupplyList.member );
				if( listInventorySupplyResult.IsSetNextToken() )
				{
					var nextResponse = this._client.ListInventorySupplyByNextToken( new ListInventorySupplyByNextTokenRequest
					{
						SellerId = this._request.SellerId,
						NextToken = listInventorySupplyResult.NextToken,
						MWSAuthToken = this._request.MWSAuthToken
					} );

					this.LoadNextInventoryInfoPage( nextResponse.ListInventorySupplyByNextTokenResult, inventory );
				}
			}

			return inventory;
		}

		public bool IsInventoryReceived()
		{
			try
			{
				AmazonLogger.Log.Trace( "[amazon] Checking FBA inventory for seller {0}", this._request.SellerId );
				var response = this._client.ListInventorySupply( this._request );
				AmazonLogger.Log.Trace( "[amazon] Checking FBA inventory for seller {0} finished", this._request.SellerId );
				return response.IsSetListInventorySupplyResult();
			}
			catch( Exception ex )
			{
				AmazonLogger.Log.Warn( ex, "[amazon] Checking FBA inventory for seller {0} failed", this._request.SellerId );
				return false;
			}
		}

		private void LoadNextInventoryInfoPage( ListInventorySupplyByNextTokenResult listInventorySupplyResult, List< InventorySupply > inventory )
		{
			if( listInventorySupplyResult.IsSetInventorySupplyList() )
				inventory.AddRange( listInventorySupplyResult.InventorySupplyList.member );
			if( listInventorySupplyResult.IsSetNextToken() )
			{
				var response = this._client.ListInventorySupplyByNextToken( new ListInventorySupplyByNextTokenRequest
				{
					SellerId = this._request.SellerId,
					NextToken = listInventorySupplyResult.NextToken,
					MWSAuthToken = this._request.MWSAuthToken
				} );

				this.LoadNextInventoryInfoPage( response.ListInventorySupplyByNextTokenResult, inventory );
			}
		}
	}
}