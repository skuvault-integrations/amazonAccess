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
using System.IO;
using System.Reflection;
using AmazonAccess.Services.Common;
using AmazonAccess.Services.Products.Model;

namespace AmazonAccess.Services.Products.Mock
{
	/// <summary>
	/// MarketplaceWebServiceProductsMock is the implementation of MarketplaceWebServiceProducts based
	/// on the pre-populated set of XML files that serve local data. It simulates
	/// responses from MWS.
	/// </summary>
	/// <remarks>
	/// Use this to test your application without making a call to MWS
	///
	/// Note, current Mock Service implementation does not validate requests
	/// </remarks>
	public class MarketplaceWebServiceProductsMock: IProductsServiceClient
	{
		public GetCompetitivePricingForASINResponse GetCompetitivePricingForASIN( GetCompetitivePricingForASINRequest request, string marker )
		{
			return this.newResponse< GetCompetitivePricingForASINResponse >();
		}

		public GetCompetitivePricingForSKUResponse GetCompetitivePricingForSKU( GetCompetitivePricingForSKURequest request, string marker )
		{
			return this.newResponse< GetCompetitivePricingForSKUResponse >();
		}

		public GetLowestOfferListingsForASINResponse GetLowestOfferListingsForASIN( GetLowestOfferListingsForASINRequest request, string marker )
		{
			return this.newResponse< GetLowestOfferListingsForASINResponse >();
		}

		public GetLowestOfferListingsForSKUResponse GetLowestOfferListingsForSKU( GetLowestOfferListingsForSKURequest request, string marker )
		{
			return this.newResponse< GetLowestOfferListingsForSKUResponse >();
		}

		public GetLowestPricedOffersForASINResponse GetLowestPricedOffersForASIN( GetLowestPricedOffersForASINRequest request, string marker )
		{
			return this.newResponse< GetLowestPricedOffersForASINResponse >();
		}

		public GetLowestPricedOffersForSKUResponse GetLowestPricedOffersForSKU( GetLowestPricedOffersForSKURequest request, string marker )
		{
			return this.newResponse< GetLowestPricedOffersForSKUResponse >();
		}

		public GetMatchingProductResponse GetMatchingProduct( GetMatchingProductRequest request, string marker )
		{
			return this.newResponse< GetMatchingProductResponse >();
		}

		public GetMatchingProductForIdResponse GetMatchingProductForId( GetMatchingProductForIdRequest request, string marker )
		{
			return this.newResponse< GetMatchingProductForIdResponse >();
		}

		public GetMyPriceForASINResponse GetMyPriceForASIN( GetMyPriceForASINRequest request, string marker )
		{
			return this.newResponse< GetMyPriceForASINResponse >();
		}

		public GetMyPriceForSKUResponse GetMyPriceForSKU( GetMyPriceForSKURequest request, string marker )
		{
			return this.newResponse< GetMyPriceForSKUResponse >();
		}

		public GetProductCategoriesForASINResponse GetProductCategoriesForASIN( GetProductCategoriesForASINRequest request, string marker )
		{
			return this.newResponse< GetProductCategoriesForASINResponse >();
		}

		public GetProductCategoriesForSKUResponse GetProductCategoriesForSKU( GetProductCategoriesForSKURequest request, string marker )
		{
			return this.newResponse< GetProductCategoriesForSKUResponse >();
		}

		public GetServiceStatusResponse GetServiceStatus( GetServiceStatusRequest request, string marker )
		{
			return this.newResponse< GetServiceStatusResponse >();
		}

		public ListMatchingProductsResponse ListMatchingProducts( ListMatchingProductsRequest request, string marker )
		{
			return this.newResponse< ListMatchingProductsResponse >();
		}

		private T newResponse< T >() where T : IMWSResponse
		{
			Stream xmlIn = null;
			try
			{
				xmlIn = Assembly.GetAssembly( this.GetType() ).GetManifestResourceStream( typeof( T ).FullName + ".xml" );
				StreamReader xmlInReader = new StreamReader( xmlIn );
				string xmlStr = xmlInReader.ReadToEnd();

				MwsXmlReader reader = new MwsXmlReader( xmlStr );
				T obj = ( T )Activator.CreateInstance( typeof( T ) );
				obj.ReadFragmentFrom( reader );
				obj.ResponseHeaderMetadata = new ResponseHeaderMetadata( "mockRequestId", "A,B,C", "mockTimestamp", 0d, 0d, new DateTime(), null );
				return obj;
			}
			catch( Exception e )
			{
				throw MwsUtil.Wrap( e );
			}
			finally
			{
				if( xmlIn != null )
					xmlIn.Close();
			}
		}
	}
}