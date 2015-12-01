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
 * FBA Inventory Service MWS
 * API Version: 2010-10-01
 * Library Version: 2015-06-18
 * Generated: Thu Jun 18 19:30:05 GMT 2015
 */

using System;
using System.IO;
using System.Reflection;
using AmazonAccess.Services.Common;
using AmazonAccess.Services.FbaInventory.Model;

namespace AmazonAccess.Services.FbaInventory.Mock
{
	/// <summary>
	/// FBAInventoryServiceMWSMock is the implementation of FBAInventoryServiceMWS based
	/// on the pre-populated set of XML files that serve local data. It simulates
	/// responses from MWS.
	/// </summary>
	/// <remarks>
	/// Use this to test your application without making a call to MWS
	///
	/// Note, current Mock Service implementation does not validate requests
	/// </remarks>
	public class FBAInventoryServiceMWSMock: IFbaInventoryServiceClient
	{
		public GetServiceStatusResponse GetServiceStatus( GetServiceStatusRequest request, string marker )
		{
			return this.newResponse< GetServiceStatusResponse >();
		}

		public ListInventorySupplyResponse ListInventorySupply( ListInventorySupplyRequest request, string marker )
		{
			return this.newResponse< ListInventorySupplyResponse >();
		}

		public ListInventorySupplyByNextTokenResponse ListInventorySupplyByNextToken( ListInventorySupplyByNextTokenRequest request, string marker )
		{
			return this.newResponse< ListInventorySupplyByNextTokenResponse >();
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