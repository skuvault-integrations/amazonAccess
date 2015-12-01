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
	public class RequestReportRequest: AbstractMwsObject
	{
		private DateTime? startDateField;
		private DateTime? endDateField;
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
		public RequestReportRequest WithMarketplaceId( string[] marketplaceId )
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
		/// <param name="sellerId"></param>
		/// <returns>this instance</returns>
		public RequestReportRequest WithSellerId( String sellerId )
		{
			this.SellerId = sellerId;
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
		public RequestReportRequest WithMWSAuthToken( String mwsAuthToken )
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
		/// Gets and sets the ReportType property.
		/// </summary>
		public String ReportType{ get; set; }

		/// <summary>
		/// Sets the ReportType property
		/// </summary>
		/// <param name="reportType">ReportType property</param>
		/// <returns>this instance</returns>
		public RequestReportRequest WithReportType( String reportType )
		{
			this.ReportType = reportType;
			return this;
		}

		/// <summary>
		/// Checks if ReportType property is set
		/// </summary>
		/// <returns>true if ReportType property is set</returns>
		public Boolean IsSetReportType()
		{
			return this.ReportType != null;
		}

		/// <summary>
		/// Gets and sets the StartDate property.
		/// </summary>
		public DateTime StartDate
		{
			get { return this.startDateField.GetValueOrDefault(); }
			set { this.startDateField = value; }
		}

		/// <summary>
		/// Sets the StartDate property
		/// </summary>
		/// <param name="startDate">StartDate property</param>
		/// <returns>this instance</returns>
		public RequestReportRequest WithStartDate( DateTime startDate )
		{
			this.startDateField = startDate;
			return this;
		}

		/// <summary>
		/// Checks if StartDate property is set
		/// </summary>
		/// <returns>true if StartDate property is set</returns>
		public Boolean IsSetStartDate()
		{
			return this.startDateField.HasValue;
		}

		/// <summary>
		/// Gets and sets the EndDate property.
		/// </summary>
		public DateTime EndDate
		{
			get { return this.endDateField.GetValueOrDefault(); }
			set { this.endDateField = value; }
		}

		/// <summary>
		/// Sets the EndDate property
		/// </summary>
		/// <param name="endDate">EndDate property</param>
		/// <returns>this instance</returns>
		public RequestReportRequest WithEndDate( DateTime endDate )
		{
			this.endDateField = endDate;
			return this;
		}

		/// <summary>
		/// Checks if EndDate property is set
		/// </summary>
		/// <returns>true if EndDate property is set</returns>
		public Boolean IsSetEndDate()
		{
			return this.endDateField.HasValue;
		}

		/// <summary>
		/// Gets and set the reportOption property
		/// </summary>
		public String ReportOptions{ get; set; }

		/// <summary>
		/// Sets the reportOptions property
		/// </summary>
		/// <param name="reportOptions">Report Options property</param>
		/// <returns>this instance</returns>
		public RequestReportRequest WithReportOptions( String reportOptions )
		{
			this.ReportOptions = reportOptions;
			return this;
		}

		/// <summary>
		/// Checks if the ReportOptions property is set
		/// </summary>
		/// <returns>true if Report Options field is set</returns>
		public Boolean IsSetReportOptions()
		{
			return this.ReportOptions != null;
		}

		public override void ReadFragmentFrom( IMwsReader reader )
		{
			this.SellerId = reader.Read< string >( "SellerId" );
			this.MWSAuthToken = reader.Read< string >( "MWSAuthToken" );
			this.startDateField = reader.Read< DateTime? >( "StartDate" );
			this.endDateField = reader.Read< DateTime? >( "EndDate" );
			this.ReportType = reader.Read< string >( "ReportType" );
			this.ReportOptions = reader.Read< string >( "ReportOptions" );
			this._marketplaceId = reader.ReadList< string >( "MarketplaceId", "Id" );
		}

		public override void WriteFragmentTo( IMwsWriter writer )
		{
			writer.Write( "SellerId", this.SellerId );
			writer.Write( "MWSAuthToken", this.MWSAuthToken );
			writer.Write( "StartDate", this.startDateField );
			writer.Write( "EndDate", this.endDateField );
			writer.Write( "ReportType", this.ReportType );
			writer.Write( "ReportOptions", this.ReportOptions );
			writer.WriteList( "MarketplaceId", "Id", this._marketplaceId );
		}

		public override void WriteTo( IMwsWriter writer )
		{
			writer.Write( "http://mws.amazonaws.com/doc/2009-01-01/", "RequestReportRequest", this );
		}
	}
}