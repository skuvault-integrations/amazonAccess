/******************************************************************************* 
 *  Copyright 2009 Amazon Services.
 *  Licensed under the Apache License, Version 2.0 (the "License"); 
 *  
 *  You may not use this file except in compliance with the License. 
 *  You may obtain a copy of the License at: http://aws.amazon.com/apache2.0
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the 
 *  specific language governing permissions and limitations under the License.
 * ***************************************************************************** 
 * 
 *  Marketplace Web Service CSharp Library
 *  API Version: 2009-01-01
 *  Generated: Mon Mar 16 17:31:42 PDT 2009 
 * 
 */

using System;
using System.Xml.Serialization;
using AmazonAccess.Services.Common;
using AmazonAccess.Services.FeedsReports.Attributes;

namespace AmazonAccess.Services.FeedsReports.Model
{
	[ XmlType( Namespace = "http://mws.amazonaws.com/doc/2009-01-01/" ) ]
	[ XmlRoot( Namespace = "http://mws.amazonaws.com/doc/2009-01-01/", IsNullable = false ) ]
	[ MarketplaceWebService( RequestType = RequestType.DEFAULT, ResponseType = ResponseType.DEFAULT ) ]
	public class GetReportScheduleCountRequest: AbstractMwsObject
	{
		/// <summary>
		/// Gets and sets the Marketplace property.
		/// </summary>
		[ XmlElement( ElementName = "Marketplace" ) ]
		[ Obsolete( "Not used anymore. MWS ignores this parameter, but it is left in here for backwards compatibility." ) ]
		public String Marketplace{ get; set; }

		/// <summary>
		/// Sets the Marketplace property
		/// </summary>
		/// <param name="marketplace">Marketplace property</param>
		/// <returns>this instance</returns>
		[ Obsolete( "Not used anymore. MWS ignores this parameter, but it is left in here for backwards compatibility." ) ]
		public GetReportScheduleCountRequest WithMarketplace( String marketplace )
		{
			this.Marketplace = marketplace;
			return this;
		}

		/// <summary>
		/// Checks if Marketplace property is set
		/// </summary>
		/// <returns>true if Marketplace property is set</returns>
		[ Obsolete( "Not used anymore. MWS ignores this parameter, but it is left in here for backwards compatibility." ) ]
		public Boolean IsSetMarketplace()
		{
			return this.Marketplace != null;
		}

		/// <summary>
		/// Gets and sets the Merchant property.
		/// </summary>
		[ XmlElement( ElementName = "Merchant" ) ]
		public String Merchant{ get; set; }

		/// <summary>
		/// Sets the Merchant property
		/// </summary>
		/// <param name="merchant">Merchant property</param>
		/// <returns>this instance</returns>
		public GetReportScheduleCountRequest WithMerchant( String merchant )
		{
			this.Merchant = merchant;
			return this;
		}

		/// <summary>
		/// Checks if Merchant property is set
		/// </summary>
		/// <returns>true if Merchant property is set</returns>
		public Boolean IsSetMerchant()
		{
			return this.Merchant != null;
		}

		/// <summary>
		/// Gets and sets the MWSAuthToken property.
		/// </summary>
		[ XmlElement( ElementName = "MWSAuthToken" ) ]
		public String MWSAuthToken{ get; set; }

		/// <summary>
		/// Sets the MWSAuthToken property
		/// </summary>
		/// <param name="mwsAuthToken">MWSAuthToken property</param>
		/// <returns>this instance</returns>
		public GetReportScheduleCountRequest WithMWSAuthToken( String mwsAuthToken )
		{
			this.MWSAuthToken = mwsAuthToken;
			return this;
		}

		/// <summary>
		/// Checks if MWSAuthToken property is set
		/// </summary>
		/// <returns>true if MWSAuthToken property is set</returns>
		public Boolean IsSetMWSAuthToken()
		{
			return this.MWSAuthToken != null;
		}

		/// <summary>
		/// Gets and sets the ReportTypeList property.
		/// </summary>
		[ XmlElement( ElementName = "ReportTypeList" ) ]
		public TypeList ReportTypeList{ get; set; }

		/// <summary>
		/// Sets the ReportTypeList property
		/// </summary>
		/// <param name="reportTypeList">ReportTypeList property</param>
		/// <returns>this instance</returns>
		public GetReportScheduleCountRequest WithReportTypeList( TypeList reportTypeList )
		{
			this.ReportTypeList = reportTypeList;
			return this;
		}

		/// <summary>
		/// Checks if ReportTypeList property is set
		/// </summary>
		/// <returns>true if ReportTypeList property is set</returns>
		public Boolean IsSetReportTypeList()
		{
			return this.ReportTypeList != null;
		}

		public override void ReadFragmentFrom( IMwsReader r )
		{
		}

		public override void WriteFragmentTo( IMwsWriter w )
		{
		}

		public override void WriteTo( IMwsWriter w )
		{
		}
	}
}