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
	public class CancelReportRequestsRequest: AbstractMwsObject
	{
		private DateTime? requestedFromDateField;

		private DateTime? requestedToDateField;

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
		public CancelReportRequestsRequest WithMarketplace( String marketplace )
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
		public CancelReportRequestsRequest WithMerchant( String merchant )
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
		public CancelReportRequestsRequest WithMWSAuthToken( String mwsAuthToken )
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
		/// Gets and sets the ReportRequestIdList property.
		/// </summary>
		[ XmlElement( ElementName = "ReportRequestIdList" ) ]
		public IdList ReportRequestIdList{ get; set; }

		/// <summary>
		/// Sets the ReportRequestIdList property
		/// </summary>
		/// <param name="reportRequestIdList">ReportRequestIdList property</param>
		/// <returns>this instance</returns>
		public CancelReportRequestsRequest WithReportRequestIdList( IdList reportRequestIdList )
		{
			this.ReportRequestIdList = reportRequestIdList;
			return this;
		}

		/// <summary>
		/// Checks if ReportRequestIdList property is set
		/// </summary>
		/// <returns>true if ReportRequestIdList property is set</returns>
		public Boolean IsSetReportRequestIdList()
		{
			return this.ReportRequestIdList != null;
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
		public CancelReportRequestsRequest WithReportTypeList( TypeList reportTypeList )
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

		/// <summary>
		/// Gets and sets the ReportProcessingStatusList property.
		/// </summary>
		[ XmlElement( ElementName = "ReportProcessingStatusList" ) ]
		public StatusList ReportProcessingStatusList{ get; set; }

		/// <summary>
		/// Sets the ReportProcessingStatusList property
		/// </summary>
		/// <param name="reportProcessingStatusList">ReportProcessingStatusList property</param>
		/// <returns>this instance</returns>
		public CancelReportRequestsRequest WithReportProcessingStatusList( StatusList reportProcessingStatusList )
		{
			this.ReportProcessingStatusList = reportProcessingStatusList;
			return this;
		}

		/// <summary>
		/// Checks if ReportProcessingStatusList property is set
		/// </summary>
		/// <returns>true if ReportProcessingStatusList property is set</returns>
		public Boolean IsSetReportProcessingStatusList()
		{
			return this.ReportProcessingStatusList != null;
		}

		/// <summary>
		/// Gets and sets the RequestedFromDate property.
		/// </summary>
		[ XmlElement( ElementName = "RequestedFromDate" ) ]
		public DateTime RequestedFromDate
		{
			get { return this.requestedFromDateField.GetValueOrDefault(); }
			set { this.requestedFromDateField = value; }
		}

		/// <summary>
		/// Sets the RequestedFromDate property
		/// </summary>
		/// <param name="requestedFromDate">RequestedFromDate property</param>
		/// <returns>this instance</returns>
		public CancelReportRequestsRequest WithRequestedFromDate( DateTime requestedFromDate )
		{
			this.requestedFromDateField = requestedFromDate;
			return this;
		}

		/// <summary>
		/// Checks if RequestedFromDate property is set
		/// </summary>
		/// <returns>true if RequestedFromDate property is set</returns>
		public Boolean IsSetRequestedFromDate()
		{
			return this.requestedFromDateField.HasValue;
		}

		/// <summary>
		/// Gets and sets the RequestedToDate property.
		/// </summary>
		[ XmlElement( ElementName = "RequestedToDate" ) ]
		public DateTime RequestedToDate
		{
			get { return this.requestedToDateField.GetValueOrDefault(); }
			set { this.requestedToDateField = value; }
		}

		/// <summary>
		/// Sets the RequestedToDate property
		/// </summary>
		/// <param name="requestedToDate">RequestedToDate property</param>
		/// <returns>this instance</returns>
		public CancelReportRequestsRequest WithRequestedToDate( DateTime requestedToDate )
		{
			this.requestedToDateField = requestedToDate;
			return this;
		}

		/// <summary>
		/// Checks if RequestedToDate property is set
		/// </summary>
		/// <returns>true if RequestedToDate property is set</returns>
		public Boolean IsSetRequestedToDate()
		{
			return this.requestedToDateField.HasValue;
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