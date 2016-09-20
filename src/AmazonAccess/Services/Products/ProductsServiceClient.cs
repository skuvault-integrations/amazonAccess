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
 * Marketplace Web Service Products
 * API Version: 2011-10-01
 * Library Version: 2015-09-01
 * Generated: Thu Sep 10 06:52:19 PDT 2015
 */

using System;
using AmazonAccess.Services.Common;
using AmazonAccess.Services.Products.Model;

namespace AmazonAccess.Services.Products
{
	/// <summary>
	/// MarketplaceWebServiceProductsClient is an implementation of MarketplaceWebServiceProducts
	/// </summary>
	public class ProductsServiceClient: IProductsServiceClient
	{
		private readonly MwsConnection connection;

		/// <summary>
		/// Create client.
		/// </summary>
		/// <param name="accessKey">Access Key</param>  
		/// <param name="secretKey">Secret Key</param>
		/// <param name="serviceUrl"></param>
		public ProductsServiceClient(
			string accessKey,
			string secretKey,
			string serviceUrl )

		{
			this.connection = new MwsConnection
			{
				AwsAccessKeyId = accessKey,
				AwsSecretKeyId = secretKey,
				ServiceURL = serviceUrl
			};
		}

		public ProductsServiceClient( MwsConnection mwsConnection )
		{
			this.connection = mwsConnection;
		}

		public GetCompetitivePricingForASINResponse GetCompetitivePricingForASIN( GetCompetitivePricingForASINRequest request, string marker )
		{
			return this.connection.Call( new Request< GetCompetitivePricingForASINResponse >( "GetCompetitivePricingForASIN" ), request, marker );
		}

		public GetCompetitivePricingForSKUResponse GetCompetitivePricingForSKU( GetCompetitivePricingForSKURequest request, string marker )
		{
			return this.connection.Call( new Request< GetCompetitivePricingForSKUResponse >( "GetCompetitivePricingForSKU" ), request, marker );
		}

		public GetLowestOfferListingsForASINResponse GetLowestOfferListingsForASIN( GetLowestOfferListingsForASINRequest request, string marker )
		{
			return this.connection.Call( new Request< GetLowestOfferListingsForASINResponse >( "GetLowestOfferListingsForASIN" ), request, marker );
		}

		public GetLowestOfferListingsForSKUResponse GetLowestOfferListingsForSKU( GetLowestOfferListingsForSKURequest request, string marker )
		{
			return this.connection.Call( new Request< GetLowestOfferListingsForSKUResponse >( "GetLowestOfferListingsForSKU" ), request, marker );
		}

		public GetLowestPricedOffersForASINResponse GetLowestPricedOffersForASIN( GetLowestPricedOffersForASINRequest request, string marker )
		{
			return this.connection.Call( new Request< GetLowestPricedOffersForASINResponse >( "GetLowestPricedOffersForASIN" ), request, marker );
		}

		public GetLowestPricedOffersForSKUResponse GetLowestPricedOffersForSKU( GetLowestPricedOffersForSKURequest request, string marker )
		{
			return this.connection.Call(
				new Request< GetLowestPricedOffersForSKUResponse >( "GetLowestPricedOffersForSKU" ), request, marker );
		}

		public GetMatchingProductResponse GetMatchingProduct( GetMatchingProductRequest request, string marker )
		{
			return this.connection.Call( new Request< GetMatchingProductResponse >( "GetMatchingProduct" ), request, marker );
		}

		public GetMatchingProductForIdResponse GetMatchingProductForId( GetMatchingProductForIdRequest request, string marker )
		{
			return this.connection.Call( new Request< GetMatchingProductForIdResponse >( "GetMatchingProductForId" ), request, marker );
		}

		public GetMyPriceForASINResponse GetMyPriceForASIN( GetMyPriceForASINRequest request, string marker )
		{
			return this.connection.Call( new Request< GetMyPriceForASINResponse >( "GetMyPriceForASIN" ), request, marker );
		}

		public GetMyPriceForSKUResponse GetMyPriceForSKU( GetMyPriceForSKURequest request, string marker )
		{
			return this.connection.Call( new Request< GetMyPriceForSKUResponse >( "GetMyPriceForSKU" ), request, marker );
		}

		public GetProductCategoriesForASINResponse GetProductCategoriesForASIN( GetProductCategoriesForASINRequest request, string marker )
		{
			return this.connection.Call( new Request< GetProductCategoriesForASINResponse >( "GetProductCategoriesForASIN" ), request, marker );
		}

		public GetProductCategoriesForSKUResponse GetProductCategoriesForSKU( GetProductCategoriesForSKURequest request, string marker )
		{
			return this.connection.Call( new Request< GetProductCategoriesForSKUResponse >( "GetProductCategoriesForSKU" ), request, marker );
		}

		public GetServiceStatusResponse GetServiceStatus( GetServiceStatusRequest request, string marker )
		{
			return this.connection.Call( new Request< GetServiceStatusResponse >( "GetServiceStatus" ), request, marker );
		}

		public ListMatchingProductsResponse ListMatchingProducts( ListMatchingProductsRequest request, string marker )
		{
			return this.connection.Call( new Request< ListMatchingProductsResponse >( "ListMatchingProducts" ), request, marker );
		}

		private class Request< TResponse >: IMwsRequestType< TResponse > where TResponse : IMwsObject
		{
			public Request( string operationName )
			{
				this.OperationName = operationName;
				this.ResponseClass = typeof( TResponse );
			}

			public string OperationName{ get; private set; }
			public Type ResponseClass{ get; private set; }

			public MwsException WrapException( Exception cause )
			{
				return new MarketplaceWebServiceProductsException( cause );
			}

			public void SetResponseHeaderMetadata( IMwsObject response, MwsResponseHeaderMetadata rhmd )
			{
				( ( IMwsResponse )response ).ResponseHeaderMetadata = rhmd;
			}
		}
	}
}