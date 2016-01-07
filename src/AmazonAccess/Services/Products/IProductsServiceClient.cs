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

using AmazonAccess.Services.Products.Model;

namespace AmazonAccess.Services.Products
{
	/// <summary>
	/// This is the Products API section of the Marketplace Web Service.
	/// </summary>
	public interface IProductsServiceClient
	{
		/// <summary>
		/// Get Competitive Pricing For ASIN
		/// </summary>
		/// <param name="request">GetCompetitivePricingForASINRequest request.</param>
		/// <returns>GetCompetitivePricingForASINResponse response</returns>
		/// <remarks>
		/// Gets competitive pricing and related information for a product identified by
		/// the MarketplaceId and ASIN.
		/// </remarks>
		GetCompetitivePricingForASINResponse GetCompetitivePricingForASIN( GetCompetitivePricingForASINRequest request, string marker );

		/// <summary>
		/// Get Competitive Pricing For SKU
		/// </summary>
		/// <param name="request">GetCompetitivePricingForSKURequest request.</param>
		/// <returns>GetCompetitivePricingForSKUResponse response</returns>
		/// <remarks>
		/// Gets competitive pricing and related information for a product identified by
		/// the SellerId and SKU.
		/// </remarks>
		GetCompetitivePricingForSKUResponse GetCompetitivePricingForSKU( GetCompetitivePricingForSKURequest request, string marker );

		/// <summary>
		/// Get Lowest Offer Listings For ASIN
		/// </summary>
		/// <param name="request">GetLowestOfferListingsForASINRequest request.</param>
		/// <returns>GetLowestOfferListingsForASINResponse response</returns>
		/// <remarks>
		/// Gets some of the lowest prices based on the product identified by the given
		/// MarketplaceId and ASIN.
		/// </remarks>
		GetLowestOfferListingsForASINResponse GetLowestOfferListingsForASIN( GetLowestOfferListingsForASINRequest request, string marker );

		/// <summary>
		/// Get Lowest Offer Listings For SKU
		/// </summary>
		/// <param name="request">GetLowestOfferListingsForSKURequest request.</param>
		/// <returns>GetLowestOfferListingsForSKUResponse response</returns>
		/// <remarks>
		/// Gets some of the lowest prices based on the product identified by the given
		/// SellerId and SKU.
		/// </remarks>
		GetLowestOfferListingsForSKUResponse GetLowestOfferListingsForSKU( GetLowestOfferListingsForSKURequest request, string marker );

		/// <summary>
		/// Get Lowest Priced Offers For ASIN
		/// </summary>
		/// <param name="request">GetLowestPricedOffersForASINRequest request.</param>
		/// <returns>GetLowestPricedOffersForASINResponse response</returns>
		/// <remarks>
		/// Retrieves the lowest priced offers based on the product identified by the given
		///     ASIN.
		/// </remarks>
		GetLowestPricedOffersForASINResponse GetLowestPricedOffersForASIN( GetLowestPricedOffersForASINRequest request, string marker );

		/// <summary>
		/// Get Lowest Priced Offers For SKU
		/// </summary>
		/// <param name="request">GetLowestPricedOffersForSKURequest request.</param>
		/// <returns>GetLowestPricedOffersForSKUResponse response</returns>
		/// <remarks>
		/// Retrieves the lowest priced offers based on the product identified by the given
		///     SellerId and SKU.
		/// </remarks>
		GetLowestPricedOffersForSKUResponse GetLowestPricedOffersForSKU( GetLowestPricedOffersForSKURequest request, string marker );

		/// <summary>
		/// Get Matching Product
		/// </summary>
		/// <param name="request">GetMatchingProductRequest request.</param>
		/// <returns>GetMatchingProductResponse response</returns>
		/// <remarks>
		/// GetMatchingProduct will return the details (attributes) for the
		/// given ASIN.
		/// </remarks>
		GetMatchingProductResponse GetMatchingProduct( GetMatchingProductRequest request, string marker );

		/// <summary>
		/// Get Matching Product For Id
		/// </summary>
		/// <param name="request">GetMatchingProductForIdRequest request.</param>
		/// <returns>GetMatchingProductForIdResponse response</returns>
		/// <remarks>
		/// GetMatchingProduct will return the details (attributes) for the
		/// given Identifier list. Identifer type can be one of [SKU|ASIN|UPC|EAN|ISBN|GTIN|JAN]
		/// </remarks>
		GetMatchingProductForIdResponse GetMatchingProductForId( GetMatchingProductForIdRequest request, string marker );

		/// <summary>
		/// Get My Price For ASIN
		/// </summary>
		/// <param name="request">GetMyPriceForASINRequest request.</param>
		/// <returns>GetMyPriceForASINResponse response</returns>
		/// <remarks>
		/// <!-- Wrong doc in current code -->
		/// </remarks>
		GetMyPriceForASINResponse GetMyPriceForASIN( GetMyPriceForASINRequest request, string marker );

		/// <summary>
		/// Get My Price For SKU
		/// </summary>
		/// <param name="request">GetMyPriceForSKURequest request.</param>
		/// <returns>GetMyPriceForSKUResponse response</returns>
		/// <remarks>
		/// <!-- Wrong doc in current code -->
		/// </remarks>
		GetMyPriceForSKUResponse GetMyPriceForSKU( GetMyPriceForSKURequest request, string marker );

		/// <summary>
		/// Get Product Categories For ASIN
		/// </summary>
		/// <param name="request">GetProductCategoriesForASINRequest request.</param>
		/// <returns>GetProductCategoriesForASINResponse response</returns>
		/// <remarks>
		/// Gets categories information for a product identified by
		/// the MarketplaceId and ASIN.
		/// </remarks>
		GetProductCategoriesForASINResponse GetProductCategoriesForASIN( GetProductCategoriesForASINRequest request, string marker );

		/// <summary>
		/// Get Product Categories For SKU
		/// </summary>
		/// <param name="request">GetProductCategoriesForSKURequest request.</param>
		/// <returns>GetProductCategoriesForSKUResponse response</returns>
		/// <remarks>
		/// Gets categories information for a product identified by
		/// the SellerId and SKU.
		/// </remarks>
		GetProductCategoriesForSKUResponse GetProductCategoriesForSKU( GetProductCategoriesForSKURequest request, string marker );

		/// <summary>
		/// Get Service Status
		/// </summary>
		/// <param name="request">GetServiceStatusRequest request.</param>
		/// <returns>GetServiceStatusResponse response</returns>
		/// <remarks>
		/// Returns the service status of a particular MWS API section. The operation
		/// takes no input.
		/// All API sections within the API are required to implement this operation.
		/// </remarks>
		GetServiceStatusResponse GetServiceStatus( GetServiceStatusRequest request, string marker );

		/// <summary>
		/// List Matching Products
		/// </summary>
		/// <param name="request">ListMatchingProductsRequest request.</param>
		/// <returns>ListMatchingProductsResponse response</returns>
		/// <remarks>
		/// ListMatchingProducts can be used to
		/// find products that match the given criteria.
		/// </remarks>
		ListMatchingProductsResponse ListMatchingProducts( ListMatchingProductsRequest request, string marker );
	}
}