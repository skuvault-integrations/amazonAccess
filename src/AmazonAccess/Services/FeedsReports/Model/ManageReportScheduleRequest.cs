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
using System.Xml.Serialization;
using AmazonAccess.Services.Common;

namespace AmazonAccess.Services.FeedsReports.Model
{
	[ XmlType( Namespace = "http://mws.amazonaws.com/doc/2009-01-01/" ) ]
	[ XmlRoot( Namespace = "http://mws.amazonaws.com/doc/2009-01-01/", IsNullable = false ) ]
	public class ManageReportScheduleRequest: AbstractMwsObject
	{
		private DateTime? scheduleDateField;
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
		public ManageReportScheduleRequest WithMarketplaceId( string[] marketplaceId )
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
		public ManageReportScheduleRequest WithSellerId( String sellerId )
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
		[ XmlElement( ElementName = "MWSAuthToken" ) ]
		public String MWSAuthToken{ get; set; }

		/// <summary>
		/// Sets the MWSAuthToken property
		/// </summary>
		/// <param name="mwsAuthToken">MWSAuthToken property</param>
		/// <returns>this instance</returns>
		public ManageReportScheduleRequest WithMWSAuthToken( String mwsAuthToken )
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
		[ XmlElement( ElementName = "ReportType" ) ]
		public String ReportType{ get; set; }

		/// <summary>
		/// Sets the ReportType property
		/// </summary>
		/// <param name="reportType">ReportType property</param>
		/// <returns>this instance</returns>
		public ManageReportScheduleRequest WithReportType( String reportType )
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
		/// Gets and sets the Schedule property.
		/// </summary>
		[ XmlElement( ElementName = "Schedule" ) ]
		public String Schedule{ get; set; }

		/// <summary>
		/// Sets the Schedule property
		/// </summary>
		/// <param name="schedule">Schedule property</param>
		/// <returns>this instance</returns>
		public ManageReportScheduleRequest WithSchedule( String schedule )
		{
			this.Schedule = schedule;
			return this;
		}

		/// <summary>
		/// Checks if Schedule property is set
		/// </summary>
		/// <returns>true if Schedule property is set</returns>
		public Boolean IsSetSchedule()
		{
			return this.Schedule != null;
		}

		/// <summary>
		/// Gets and sets the ScheduleDate property.
		/// </summary>
		[ XmlElement( ElementName = "ScheduleDate" ) ]
		public DateTime ScheduleDate
		{
			get { return this.scheduleDateField.GetValueOrDefault(); }
			set { this.scheduleDateField = value; }
		}

		/// <summary>
		/// Sets the ScheduleDate property
		/// </summary>
		/// <param name="scheduleDate">ScheduleDate property</param>
		/// <returns>this instance</returns>
		public ManageReportScheduleRequest WithScheduleDate( DateTime scheduleDate )
		{
			this.scheduleDateField = scheduleDate;
			return this;
		}

		/// <summary>
		/// Checks if ScheduleDate property is set
		/// </summary>
		/// <returns>true if ScheduleDate property is set</returns>
		public Boolean IsSetScheduleDate()
		{
			return this.scheduleDateField.HasValue;
		}

		public override void ReadFragmentFrom( IMwsReader r )
		{
			throw new NotImplementedException();
		}

		public override void WriteFragmentTo( IMwsWriter w )
		{
			throw new NotImplementedException();
		}

		public override void WriteTo( IMwsWriter w )
		{
			throw new NotImplementedException();
		}
	}
}