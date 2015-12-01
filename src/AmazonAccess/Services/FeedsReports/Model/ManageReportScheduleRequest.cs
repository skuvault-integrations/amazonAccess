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
	public class ManageReportScheduleRequest: AbstractMwsObject
	{
		private DateTime? scheduleDateField;

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
		public ManageReportScheduleRequest WithMarketplace( String marketplace )
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
		public ManageReportScheduleRequest WithMerchant( String merchant )
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
		}

		public override void WriteFragmentTo( IMwsWriter w )
		{
		}

		public override void WriteTo( IMwsWriter w )
		{
		}
	}
}