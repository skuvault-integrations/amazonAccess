/*******************************************************************************
 * Copyright 2009-2019 Amazon Services. All Rights Reserved.
 * Licensed under the Apache License, Version 2.0 (the "License"); 
 *
 * You may not use this file except in compliance with the License. 
 * You may obtain a copy of the License at: http://aws.amazon.com/apache2.0
 * This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
 * CONDITIONS OF ANY KIND, either express or implied. See the License for the 
 * specific language governing permissions and limitations under the License.
 *******************************************************************************
 * MWS Finances Service
 * API Version: 2015-05-01
 * Library Version: 2019-02-25
 * Generated: Wed Mar 13 08:17:08 PDT 2019
 */

using AmazonAccess.Services.Finances.Model;

namespace AmazonAccess.Services.Finances
{
	/// <summary>
	/// MWSFinances is a service that provides MWS developers access to Sellers 
	/// payments data coming from all types of seller transactions 
	/// which affect the seller account balance
	/// </summary>
	public interface IFinancesServiceClient 
	{
		/// <summary>
		/// List Financial Event Groups
		/// </summary>
		/// <param name="request">ListFinancialEventGroupsRequest request.</param>
		/// <returns>ListFinancialEventGroupsResponse response</returns>
		/// <remarks>
		/// ListFinancialEventGroups can be used to find financial event groups that meet filter criteria.
		/// </remarks>
		ListFinancialEventGroupsResponse ListFinancialEventGroups( ListFinancialEventGroupsRequest request, string marker );

		/// <summary>
		/// List Financial Event Groups By Next Token
		/// </summary>
		/// <param name="request">ListFinancialEventGroupsByNextTokenRequest request.</param>
		/// <returns>ListFinancialEventGroupsByNextTokenResponse response</returns>
		/// <remarks>
		/// If ListFinancialEventGroups returns a nextToken, thus indicating that there are more groups
		/// than returned that matched the given filter criteria, ListFinancialEventGroupsByNextToken
		/// can be used to retrieve those groups using that nextToken.
		/// </remarks>
		ListFinancialEventGroupsByNextTokenResponse ListFinancialEventGroupsByNextToken( ListFinancialEventGroupsByNextTokenRequest request, string marker );

		/// <summary>
		/// List Financial Events
		/// </summary>
		/// <param name="request">ListFinancialEventsRequest request.</param>
		/// <returns>ListFinancialEventsResponse response</returns>
		/// <remarks>
		/// ListFinancialEvents can be used to find financial events that meet the specified criteria.
		/// </remarks>
		ListFinancialEventsResponse ListFinancialEvents( ListFinancialEventsRequest request, string marker );

		/// <summary>
		/// List Financial Events By Next Token
		/// </summary>
		/// <param name="request">ListFinancialEventsByNextTokenRequest request.</param>
		/// <returns>ListFinancialEventsByNextTokenResponse response</returns>
		/// <remarks>
		/// If ListFinancialEvents returns a nextToken, thus indicating that there are more financial events
		/// than returned that matched the given filter criteria, ListFinancialEventsByNextToken
		/// can be used to retrieve those events using that nextToken.
		/// </remarks>
		ListFinancialEventsByNextTokenResponse ListFinancialEventsByNextToken( ListFinancialEventsByNextTokenRequest request, string marker );

		/// <summary>
		/// Get Service Status
		/// </summary>
		/// <param name="request">GetServiceStatusRequest request.</param>
		/// <returns>GetServiceStatusResponse response</returns>
		/// <remarks>
		/// 
		/// </remarks>
		GetServiceStatusResponse GetServiceStatus( GetServiceStatusRequest request, string marker );
	}
}
