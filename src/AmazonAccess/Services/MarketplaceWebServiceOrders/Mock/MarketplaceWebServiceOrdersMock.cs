/*******************************************************************************
 * Copyright 2009-2015 Amazon Services. All Rights Reserved.
 * Licensed under the Apache License, Version 2.0 (the "License"); 
 *
 * You may not use this file except in compliance with the License. 
 * You may obtain a copy of the License at: http://aws.amazon.com/apache2.0
 * This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
 * CONDITIONS OF ANY KIND, either express or implied. See the License for the 
 * specific language governing permissions and limitations under the License.
 *******************************************************************************
 * Marketplace Web Service Orders
 * API Version: 2013-09-01
 * Library Version: 2015-02-13
 * Generated: Tue Feb 10 22:00:52 UTC 2015
 */

using System;
using System.IO;
using System.Reflection;
using AmazonAccess.Services.MarketplaceWebServiceOrders.Model;
using AmazonAccess.Services.Utils;

namespace AmazonAccess.Services.MarketplaceWebServiceOrders.Mock
{

    /// <summary>
    /// MarketplaceWebServiceOrdersMock is the implementation of MarketplaceWebServiceOrders based
    /// on the pre-populated set of XML files that serve local data. It simulates
    /// responses from MWS.
    /// </summary>
    /// <remarks>
    /// Use this to test your application without making a call to MWS
    ///
    /// Note, current Mock Service implementation does not validate requests
    /// </remarks>
    public class MarketplaceWebServiceOrdersMock : IMarketplaceWebServiceOrders
    {

        public GetOrderResponse GetOrder(GetOrderRequest request)
        {
            return this.newResponse<GetOrderResponse>();
        }

        public GetServiceStatusResponse GetServiceStatus(GetServiceStatusRequest request)
        {
            return this.newResponse<GetServiceStatusResponse>();
        }

        public ListOrderItemsResponse ListOrderItems(ListOrderItemsRequest request)
        {
            return this.newResponse<ListOrderItemsResponse>();
        }

        public ListOrderItemsByNextTokenResponse ListOrderItemsByNextToken(ListOrderItemsByNextTokenRequest request)
        {
            return this.newResponse<ListOrderItemsByNextTokenResponse>();
        }

        public ListOrdersResponse ListOrders(ListOrdersRequest request)
        {
            return this.newResponse<ListOrdersResponse>();
        }

        public ListOrdersByNextTokenResponse ListOrdersByNextToken(ListOrdersByNextTokenRequest request)
        {
            return this.newResponse<ListOrdersByNextTokenResponse>();
        }

        private T newResponse<T>() where T : IMwsResponse {
            Stream xmlIn = null;
            try {
                xmlIn = Assembly.GetAssembly(this.GetType()).GetManifestResourceStream(typeof(T).FullName + ".xml");
                StreamReader xmlInReader = new StreamReader(xmlIn);
                string xmlStr = xmlInReader.ReadToEnd();

                MwsXmlReader reader = new MwsXmlReader(xmlStr);
                T obj = (T) Activator.CreateInstance(typeof(T));
                obj.ReadFragmentFrom(reader);
                obj.ResponseHeaderMetadata = new ResponseHeaderMetadata("mockRequestId", "A,B,C", "mockTimestamp", 0d, 0d, new DateTime());
                return obj;
            }
            catch (Exception e)
            {
                throw MwsUtil.Wrap(e);
            }
            finally
            {
                if (xmlIn != null) { xmlIn.Close(); }
            }
        }
    }
}
