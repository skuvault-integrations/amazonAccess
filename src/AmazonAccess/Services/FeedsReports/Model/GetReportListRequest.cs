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
	public class GetReportListRequest: AbstractMwsObject
	{
		private decimal? maxCountField;
		private bool? acknowledgedField;
		private DateTime? availableFromDateField;
		private DateTime? availableToDateField;
		private List< string > _marketplaceIdList;

		/// <summary>
		/// Gets and sets the MarketplaceId property.
		/// </summary>
		public List< string > MarketplaceIdListList
		{
			get
			{
				if( this._marketplaceIdList == null )
					this._marketplaceIdList = new List< string >();
				return this._marketplaceIdList;
			}
			set { this._marketplaceIdList = value; }
		}

		/// <summary>
		/// Sets the MarketplaceId property.
		/// </summary>
		/// <param name="marketplaceId">MarketplaceId property.</param>
		/// <returns>this instance.</returns>
		public GetReportListRequest WithMarketplaceId( string[] marketplaceId )
		{
			this.MarketplaceIdListList.AddRange( marketplaceId );
			return this;
		}

		/// <summary>
		/// Checks if MarketplaceId property is set.
		/// </summary>
		/// <returns>true if MarketplaceId property is set.</returns>
		public bool IsSetMarketplaceId()
		{
			return this.MarketplaceIdListList.Count > 0;
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
		public GetReportListRequest WithSeller( String seller )
		{
			this.SellerId = seller;
			return this;
		}

		/// <summary>
		/// Checks if Merchant property is set
		/// </summary>
		/// <returns>true if Seller property is set</returns>
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
		public GetReportListRequest WithMWSAuthToken( String mwsAuthToken )
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
		/// Gets and sets the MaxCount property.
		/// </summary>
		public Decimal MaxCount
		{
			get { return this.maxCountField.GetValueOrDefault(); }
			set { this.maxCountField = value; }
		}

		/// <summary>
		/// Sets the MaxCount property
		/// </summary>
		/// <param name="maxCount">MaxCount property</param>
		/// <returns>this instance</returns>
		public GetReportListRequest WithMaxCount( Decimal maxCount )
		{
			this.maxCountField = maxCount;
			return this;
		}

		/// <summary>
		/// Checks if MaxCount property is set
		/// </summary>
		/// <returns>true if MaxCount property is set</returns>
		public Boolean IsSetMaxCount()
		{
			return this.maxCountField.HasValue;
		}

		/// <summary>
		/// Gets and sets the ReportTypeList property.
		/// </summary>
		public List< String > ReportTypeList{ get; set; }

		/// <summary>
		/// Sets the ReportTypeList property
		/// </summary>
		/// <param name="reportTypeList">ReportTypeList property</param>
		/// <returns>this instance</returns>
		public GetReportListRequest WithReportTypeList( List< String > reportTypeList )
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
		/// Gets and sets the Acknowledged property.
		/// </summary>
		public Boolean Acknowledged
		{
			get { return this.acknowledgedField.GetValueOrDefault(); }
			set { this.acknowledgedField = value; }
		}

		/// <summary>
		/// Sets the Acknowledged property
		/// </summary>
		/// <param name="acknowledged">Acknowledged property</param>
		/// <returns>this instance</returns>
		public GetReportListRequest WithAcknowledged( Boolean acknowledged )
		{
			this.acknowledgedField = acknowledged;
			return this;
		}

		/// <summary>
		/// Checks if Acknowledged property is set
		/// </summary>
		/// <returns>true if Acknowledged property is set</returns>
		public Boolean IsSetAcknowledged()
		{
			return this.acknowledgedField.HasValue;
		}

		/// <summary>
		/// Gets and sets the AvailableFromDate property.
		/// </summary>
		public DateTime AvailableFromDate
		{
			get { return this.availableFromDateField.GetValueOrDefault(); }
			set { this.availableFromDateField = value; }
		}

		/// <summary>
		/// Sets the AvailableFromDate property
		/// </summary>
		/// <param name="availableFromDate">AvailableFromDate property</param>
		/// <returns>this instance</returns>
		public GetReportListRequest WithAvailableFromDate( DateTime availableFromDate )
		{
			this.availableFromDateField = availableFromDate;
			return this;
		}

		/// <summary>
		/// Checks if AvailableFromDate property is set
		/// </summary>
		/// <returns>true if AvailableFromDate property is set</returns>
		public Boolean IsSetAvailableFromDate()
		{
			return this.availableFromDateField.HasValue;
		}

		/// <summary>
		/// Gets and sets the AvailableToDate property.
		/// </summary>
		public DateTime AvailableToDate
		{
			get { return this.availableToDateField.GetValueOrDefault(); }
			set { this.availableToDateField = value; }
		}

		/// <summary>
		/// Sets the AvailableToDate property
		/// </summary>
		/// <param name="availableToDate">AvailableToDate property</param>
		/// <returns>this instance</returns>
		public GetReportListRequest WithAvailableToDate( DateTime availableToDate )
		{
			this.availableToDateField = availableToDate;
			return this;
		}

		/// <summary>
		/// Checks if AvailableToDate property is set
		/// </summary>
		/// <returns>true if AvailableToDate property is set</returns>
		public Boolean IsSetAvailableToDate()
		{
			return this.availableToDateField.HasValue;
		}

		/// <summary>
		/// Gets and sets the ReportRequestIdList property.
		/// </summary>
		public List< String > ReportRequestIdList{ get; set; }

		/// <summary>
		/// Sets the ReportRequestIdList property
		/// </summary>
		/// <param name="reportRequestIdList">ReportRequestIdList property</param>
		/// <returns>this instance</returns>
		public GetReportListRequest WithReportRequestIdList( List< String > reportRequestIdList )
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

		public override void ReadFragmentFrom( IMwsReader reader )
		{
			this.SellerId = reader.Read< string >( "SellerId" );
			this.MWSAuthToken = reader.Read< string >( "MWSAuthToken" );
			this.maxCountField = reader.Read< decimal? >( "MaxCount" );
			this.acknowledgedField = reader.Read< bool? >( "Acknowledged" );
			this.availableFromDateField = reader.Read< DateTime? >( "AvailableFromDate" );
			this.availableToDateField = reader.Read< DateTime? >( "AvailableToDate" );
			this._marketplaceIdList = reader.ReadList< string >( "MarketplaceIdList", "Id" );
			this.ReportRequestIdList = reader.ReadList< string >( "ReportRequestIdList", "Id" );
			this.ReportTypeList = reader.ReadList< string >( "ReportTypeList", "Type" );
		}

		public override void WriteFragmentTo( IMwsWriter writer )
		{
			writer.Write( "SellerId", this.SellerId );
			writer.Write( "MWSAuthToken", this.MWSAuthToken );
			writer.Write( "MaxCount", this.maxCountField );
			writer.Write( "Acknowledged", this.acknowledgedField );
			writer.Write( "AvailableFromDate", this.availableFromDateField );
			writer.Write( "AvailableToDate", this.availableToDateField );
			writer.WriteList( "MarketplaceIdList", "Id", this._marketplaceIdList );
			writer.WriteList( "ReportRequestIdList", "Id", this.ReportRequestIdList );
			writer.WriteList( "ReportTypeList", "Type", this.ReportTypeList );
		}

		public override void WriteTo( IMwsWriter writer )
		{
			writer.Write( "http://mws.amazonaws.com/doc/2009-01-01/", "GetReportListRequest", this );
		}
	}
}