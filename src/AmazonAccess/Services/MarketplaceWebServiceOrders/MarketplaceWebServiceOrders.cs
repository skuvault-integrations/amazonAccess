/******************************************************************************* 
 *  Copyright 2008-2012 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"); 
 *  
 *  You may not use this file except in compliance with the License. 
 *  You may obtain a copy of the License at: http://aws.amazon.com/apache2.0
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the 
 *  specific language governing permissions and limitations under the License.
 * ***************************************************************************** 
 * 
 *  Marketplace Web Service Orders CSharp Library
 *  API Version: 2011-01-01
 * 
 */

using AmazonAccess.Services.MarketplaceWebServiceOrders.Model;

namespace AmazonAccess.Services.MarketplaceWebServiceOrders
{
    /// <summary>
    /// This contains the Order Retrieval API section of the Marketplace Web Service.
    /// 
    /// </summary>
    public interface IMarketplaceWebServiceOrders
    {
                
        /// <summary>
        /// List Orders By Next Token 
        /// </summary>
        /// <param name="request">List Orders By Next Token  request</param>
        /// <returns>List Orders By Next Token  Response from the service</returns>
        /// <remarks>
        /// If ListOrders returns a nextToken, thus indicating that there are more orders
        /// than returned that matched the given filter criteria, ListOrdersByNextToken
        /// can be used to retrieve those other orders using that nextToken.
        ///   
        /// </remarks>
        ListOrdersByNextTokenResponse ListOrdersByNextToken(ListOrdersByNextTokenRequest request);

                
        /// <summary>
        /// List Order Items By Next Token 
        /// </summary>
        /// <param name="request">List Order Items By Next Token  request</param>
        /// <returns>List Order Items By Next Token  Response from the service</returns>
        /// <remarks>
        /// If ListOrderItems cannot return all the order items in one go, it will
        /// provide a nextToken. That nextToken can be used with this operation to
        /// retrive the next batch of items for that order.
        ///   
        /// </remarks>
        ListOrderItemsByNextTokenResponse ListOrderItemsByNextToken(ListOrderItemsByNextTokenRequest request);

                
        /// <summary>
        /// Get Order 
        /// </summary>
        /// <param name="request">Get Order  request</param>
        /// <returns>Get Order  Response from the service</returns>
        /// <remarks>
        /// This operation takes up to 50 order ids and returns the corresponding orders.
        ///   
        /// </remarks>
        GetOrderResponse GetOrder(GetOrderRequest request);

                
        /// <summary>
        /// List Order Items 
        /// </summary>
        /// <param name="request">List Order Items  request</param>
        /// <returns>List Order Items  Response from the service</returns>
        /// <remarks>
        /// This operation can be used to list the items of the order indicated by the
        /// given order id (only a single Amazon order id is allowed).
        ///   
        /// </remarks>
        ListOrderItemsResponse ListOrderItems(ListOrderItemsRequest request);

                
        /// <summary>
        /// List Orders 
        /// </summary>
        /// <param name="request">List Orders  request</param>
        /// <returns>List Orders  Response from the service</returns>
        /// <remarks>
        /// ListOrders can be used to find orders that meet the specified criteria.
        ///   
        /// </remarks>
        ListOrdersResponse ListOrders(ListOrdersRequest request);

                
        /// <summary>
        /// Get Service Status 
        /// </summary>
        /// <param name="request">Get Service Status  request</param>
        /// <returns>Get Service Status  Response from the service</returns>
        /// <remarks>
        /// Returns the service status of a particular MWS API section. The operation
        /// takes no input.
        ///   
        /// </remarks>
        GetServiceStatusResponse GetServiceStatus(GetServiceStatusRequest request);

    }
}