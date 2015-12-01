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
using System.Collections.Generic;
using AmazonAccess.Services.Common;

namespace AmazonAccess.Services.FeedsReports.Model
{
	public class GetReportRequestListRequest: AbstractMwsObject
	{
		private DateTime? requestedFromDateField;
		private DateTime? requestedToDateField;
		private List< string > _marketplaceId;

		/// <summary>
		/// Gets and sets the MarketplaceId property.
		/// </summary>
		public List< string > MarketplaceId
		{
			get
			{
				if( this._marketplaceId == null )
					this._marketplaceId = new List< string >();
				return this._marketplaceId;
			}
			set { this._marketplaceId = value; }
		}

		/// <summary>
		/// Sets the MarketplaceId property.
		/// </summary>
		/// <param name="marketplaceId">MarketplaceId property.</param>
		/// <returns>this instance.</returns>
		public GetReportRequestListRequest WithMarketplaceId( string[] marketplaceId )
		{
			this.MarketplaceId.AddRange( marketplaceId );
			return this;
		}

		/// <summary>
		/// Checks if MarketplaceId property is set.
		/// </summary>
		/// <returns>true if MarketplaceId property is set.</returns>
		public bool IsSetMarketplaceId()
		{
			return this.MarketplaceId.Count > 0;
		}

		/// <summary>
		/// Gets and sets the Merchant property.
		/// </summary>
		public String SellerId{ get; set; }

		/// <summary>
		/// Sets the Merchant property
		/// </summary>
		/// <param name="seller"></param>
		/// <returns>this instance</returns>
		public GetReportRequestListRequest WithSeller( String seller )
		{
			this.SellerId = seller;
			return this;
		}

		/// <summary>
		/// Checks if Merchant property is set
		/// </summary>
		/// <returns>true if Merchant property is set</returns>
		public Boolean IsSetSeller()
		{
			return this.SellerId != null;
		}

		/// <summary>
		/// Gets and sets the MWSAuthToken property.
		/// </summary>
		public String MWSAuthToken{ get; set; }

		/// <summary>
		/// Sets the MWSAuthToken property
		/// </summary>
		/// <param name="mwsAuthToken">MWSAuthToken property</param>
		/// <returns>this instance</returns>
		public GetReportRequestListRequest WithMWSAuthToken( String mwsAuthToken )
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
		public List< string > ReportRequestIdList{ get; set; }

		/// <summary>
		/// Sets the ReportRequestIdList property
		/// </summary>
		/// <param name="reportRequestIdList">ReportRequestIdList property</param>
		/// <returns>this instance</returns>
		public GetReportRequestListRequest WithReportRequestIdList( List< string > reportRequestIdList )
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
		public List< string > ReportTypeList{ get; set; }

		/// <summary>
		/// Sets the ReportTypeList property
		/// </summary>
		/// <param name="reportTypeList">ReportTypeList property</param>
		/// <returns>this instance</returns>
		public GetReportRequestListRequest WithReportTypeList( List< string > reportTypeList )
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
		public List< String > ReportProcessingStatusList{ get; set; }

		/// <summary>
		/// Sets the ReportProcessingStatusList property
		/// </summary>
		/// <param name="reportProcessingStatusList">ReportProcessingStatusList property</param>
		/// <returns>this instance</returns>
		public GetReportRequestListRequest WithReportProcessingStatusList( List< String > reportProcessingStatusList )
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
		/// Gets and sets the MaxCount property.
		/// </summary>
		public Decimal? MaxCount{ get; set; }

		/// <summary>
		/// Sets the MaxCount property
		/// </summary>
		/// <param name="maxCount">MaxCount property</param>
		/// <returns>this instance</returns>
		public GetReportRequestListRequest WithMaxCount( Int32? maxCount )
		{
			this.MaxCount = maxCount;
			return this;
		}

		/// <summary>
		/// Checks if MaxCount property is set
		/// </summary>
		/// <returns>true if MaxCount property is set</returns>
		public Boolean IsSetMaxCount()
		{
			return this.MaxCount != null;
		}

		/// <summary>
		/// Gets and sets the RequestedFromDate property.
		/// </summary>
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
		public GetReportRequestListRequest WithRequestedFromDate( DateTime requestedFromDate )
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
		public GetReportRequestListRequest WithRequestedToDate( DateTime requestedToDate )
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

		public override void ReadFragmentFrom( IMwsReader reader )
		{
			this.SellerId = reader.Read< string >( "SellerId" );
			this.MWSAuthToken = reader.Read< string >( "MWSAuthToken" );
			this.MaxCount = reader.Read< decimal? >( "MaxCount" );
			this.requestedFromDateField = reader.Read< DateTime? >( "RequestedFromDate" );
			this.requestedToDateField = reader.Read< DateTime? >( "RequestedToDate" );

			this._marketplaceId = reader.ReadList< string >( "MarketplaceId", "Id" );
			this.ReportRequestIdList = reader.ReadList< string >( "ReportRequestIdList", "Id" );
			this.ReportTypeList = reader.ReadList< string >( "ReportTypeList", "Type" );
			this.ReportProcessingStatusList = reader.ReadList< string >( "ReportProcessingStatusList", "Status" );
		}

		public override void WriteFragmentTo( IMwsWriter writer )
		{
			writer.Write( "SellerId", this.SellerId );
			writer.Write( "MWSAuthToken", this.MWSAuthToken );
			writer.Write( "MaxCount", this.MaxCount );
			writer.Write( "RequestedFromDate", this.requestedFromDateField );
			writer.Write( "RequestedToDate", this.requestedToDateField );

			writer.WriteList( "MarketplaceId", "Id", this._marketplaceId );
			writer.WriteList( "ReportRequestIdList", "Id", this.ReportRequestIdList );
			writer.WriteList( "ReportTypeList", "Type", this.ReportTypeList );
			writer.WriteList( "ReportProcessingStatusList", "Status", this.ReportProcessingStatusList );
		}

		public override void WriteTo( IMwsWriter writer )
		{
			writer.Write( "http://mws.amazonaws.com/doc/2009-01-01/", "GetReportRequestListRequest", this );
		}
	}
}