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

using AmazonAccess.Services.Common;
using AmazonAccess.Services.Finances.Model;
using System;
using System.IO;
using System.Reflection;

namespace AmazonAccess.Services.Finances.Mock
{
	/// <summary>
	/// MWSFinancesServiceMock is the implementation of MWSFinancesService based
	/// on the pre-populated set of XML files that serve local data. It simulates
	/// responses from MWS.
	/// </summary>
	/// <remarks>
	/// Use this to test your application without making a call to MWS
	///
	/// Note, current Mock Service implementation does not validate requests
	/// </remarks>
	public class MWSFinancesServiceMock : IFinancesServiceClient
	{
		public ListFinancialEventGroupsResponse ListFinancialEventGroups( ListFinancialEventGroupsRequest request, string marker )
		{
			return NewResponse< ListFinancialEventGroupsResponse >();
		}

		public ListFinancialEventGroupsByNextTokenResponse ListFinancialEventGroupsByNextToken( ListFinancialEventGroupsByNextTokenRequest request, string marker )
		{
			return NewResponse< ListFinancialEventGroupsByNextTokenResponse >();
		}

		public ListFinancialEventsResponse ListFinancialEvents( ListFinancialEventsRequest request, string marker )
		{
			return NewResponse< ListFinancialEventsResponse >();
		}

		public ListFinancialEventsByNextTokenResponse ListFinancialEventsByNextToken( ListFinancialEventsByNextTokenRequest request, string marker )
		{
			return NewResponse< ListFinancialEventsByNextTokenResponse >();
		}

		public GetServiceStatusResponse GetServiceStatus( GetServiceStatusRequest request, string marker )
		{
			return NewResponse< GetServiceStatusResponse >();
		}

		private T NewResponse< T >() where T : IMWSResponse {
			Stream xmlIn = null;
			
			try 
			{
				xmlIn = Assembly.GetAssembly( this.GetType() ).GetManifestResourceStream( typeof( T ).FullName + ".xml" );
				StreamReader xmlInReader = new StreamReader( xmlIn );
				string xmlStr = xmlInReader.ReadToEnd();

				MwsXmlReader reader = new MwsXmlReader( xmlStr );
				T obj = (T) Activator.CreateInstance( typeof( T ) );
				obj.ReadFragmentFrom( reader );
				obj.ResponseHeaderMetadata = new ResponseHeaderMetadata( "mockRequestId", "A,B,C", "mockTimestamp", 0d, 0d, new DateTime() );
				return obj;
			}
			catch ( Exception e )
			{
				throw MwsUtil.Wrap( e );
			}
			finally
			{
				if ( xmlIn != null ) 
				{ 
					xmlIn.Close(); 
				}
			}
		}
	}
}