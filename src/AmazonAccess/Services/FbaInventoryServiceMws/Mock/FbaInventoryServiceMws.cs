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
using System.IO;
using System.Reflection;
using System.Xml.Serialization;
using AmazonAccess.Services.FbaInventoryServiceMws.Model;

namespace AmazonAccess.Services.FbaInventoryServiceMws.Mock
{

	/// <summary>
	/// FbaInventoryServiceMwsMock is the implementation of FBAInventoryServiceMWS based
	/// on the pre-populated set of XML files that serve local data. It simulates 
	/// responses from FBA Inventory Service MWS service.
	/// </summary>
	/// <remarks>
	/// Use this to test your application without making a call to 
	/// FBA Inventory Service MWS 
	/// 
	/// Note, current Mock Service implementation does not valiadate requests
	/// </remarks>
	public class FbaInventoryServiceMwsMock : IFbaInventoryServiceMws
	{


		// Public API ------------------------------------------------------------//


		/// <summary>
		/// List Inventory Supply By Next Token 
		/// </summary>
		/// <param name="request">List Inventory Supply By Next Token  request</param>
		/// <returns>List Inventory Supply By Next Token  Response from the service</returns>
		/// <remarks>
		/// Continues pagination over a resultset of inventory data for inventory
		/// items.
		/// 
		/// This operation is used in conjunction with ListUpdatedInventorySupply.
		/// Please refer to documentation for that operation for further details.
		///   
		/// </remarks>
		public ListInventorySupplyByNextTokenResponse ListInventorySupplyByNextToken( ListInventorySupplyByNextTokenRequest request )
		{
			return this.Invoke< ListInventorySupplyByNextTokenResponse >( "ListInventorySupplyByNextTokenResponse.xml" );
		}

		/// <summary>
		/// List Inventory Supply 
		/// </summary>
		/// <param name="request">List Inventory Supply  request</param>
		/// <returns>List Inventory Supply  Response from the service</returns>
		/// <remarks>
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
		/// </remarks>
		public ListInventorySupplyResponse ListInventorySupply( ListInventorySupplyRequest request )
		{
			return this.Invoke< ListInventorySupplyResponse >( "ListInventorySupplyResponse.xml" );
		}

		/// <summary>
		/// Get Service Status 
		/// </summary>
		/// <param name="request">Get Service Status  request</param>
		/// <returns>Get Service Status  Response from the service</returns>
		/// <remarks>
		/// Gets the status of the service.
		/// Status is one of GREEN, RED representing:
		/// GREEN: This API section of the service is operating normally.
		/// RED: The service is disrupted.
		///   
		/// </remarks>
		public GetServiceStatusResponse GetServiceStatus( GetServiceStatusRequest request )
		{
			return this.Invoke< GetServiceStatusResponse >( "GetServiceStatusResponse.xml" );
		}

		// Private API ------------------------------------------------------------//

		private T Invoke< T >( String xmlResource )
		{
			var serlizer = new XmlSerializer( typeof( T ) );
			Stream xmlStream = Assembly.GetAssembly( this.GetType() ).GetManifestResourceStream( xmlResource );
			return ( T )serlizer.Deserialize( xmlStream );
		}
	}
}