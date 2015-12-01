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
using AmazonAccess.Services.Common;

namespace AmazonAccess.Services.FeedsReports.Model
{
	public class ReportInfo: AbstractMwsObject
	{
		private DateTime? availableDateField;
		private Boolean? acknowledgedField;
		private DateTime? acknowledgedDateField;

		/// <summary>
		/// Gets and sets the ReportId property.
		/// </summary>
		public String ReportId{ get; set; }

		/// <summary>
		/// Sets the ReportId property
		/// </summary>
		/// <param name="reportId">ReportId property</param>
		/// <returns>this instance</returns>
		public ReportInfo WithReportId( String reportId )
		{
			this.ReportId = reportId;
			return this;
		}

		/// <summary>
		/// Checks if ReportId property is set
		/// </summary>
		/// <returns>true if ReportId property is set</returns>
		public Boolean IsSetReportId()
		{
			return this.ReportId != null;
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
		public ReportInfo WithReportType( String reportType )
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
		/// Gets and sets the ReportRequestId property.
		/// </summary>
		public String ReportRequestId{ get; set; }

		/// <summary>
		/// Sets the ReportRequestId property
		/// </summary>
		/// <param name="reportRequestId">ReportRequestId property</param>
		/// <returns>this instance</returns>
		public ReportInfo WithReportRequestId( String reportRequestId )
		{
			this.ReportRequestId = reportRequestId;
			return this;
		}

		/// <summary>
		/// Checks if ReportRequestId property is set
		/// </summary>
		/// <returns>true if ReportRequestId property is set</returns>
		public Boolean IsSetReportRequestId()
		{
			return this.ReportRequestId != null;
		}

		/// <summary>
		/// Gets and sets the AvailableDate property.
		/// </summary>
		public DateTime AvailableDate
		{
			get { return this.availableDateField.GetValueOrDefault(); }
			set { this.availableDateField = value; }
		}

		/// <summary>
		/// Sets the AvailableDate property
		/// </summary>
		/// <param name="availableDate">AvailableDate property</param>
		/// <returns>this instance</returns>
		public ReportInfo WithAvailableDate( DateTime availableDate )
		{
			this.availableDateField = availableDate;
			return this;
		}

		/// <summary>
		/// Checks if AvailableDate property is set
		/// </summary>
		/// <returns>true if AvailableDate property is set</returns>
		public Boolean IsSetAvailableDate()
		{
			return this.availableDateField.HasValue;
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
		public ReportInfo WithAcknowledged( Boolean acknowledged )
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
		/// Gets and sets the AcknowledgedDate property.
		/// </summary>
		public DateTime AcknowledgedDate
		{
			get { return this.acknowledgedDateField.GetValueOrDefault(); }
			set { this.acknowledgedDateField = value; }
		}

		/// <summary>
		/// Sets the AcknowledgedDate property
		/// </summary>
		/// <param name="acknowledgedDate">AcknowledgedDate property</param>
		/// <returns>this instance</returns>
		public ReportInfo WithAcknowledgedDate( DateTime acknowledgedDate )
		{
			this.acknowledgedDateField = acknowledgedDate;
			return this;
		}

		/// <summary>
		/// Checks if AcknowledgedDate property is set
		/// </summary>
		/// <returns>true if AcknowledgedDate property is set</returns>
		public Boolean IsSetAcknowledgedDate()
		{
			return this.acknowledgedDateField.HasValue;
		}

		public override void ReadFragmentFrom( IMwsReader reader )
		{
			this.ReportId = reader.Read< string >( "ReportId" );
			this.ReportType = reader.Read< string >( "ReportType" );
			this.ReportRequestId = reader.Read< string >( "ReportRequestId" );
			this.availableDateField = reader.Read< DateTime? >( "AvailableDate" );
			this.acknowledgedField = reader.Read< bool? >( "Acknowledged" );
			this.acknowledgedDateField = reader.Read< DateTime? >( "AcknowledgedDate" );
		}

		public override void WriteFragmentTo( IMwsWriter writer )
		{
			writer.Write( "ReportRequestId", this.ReportId );
			writer.Write( "ReportType", this.ReportType );
			writer.Write( "ReportRequestId", this.ReportRequestId );
			writer.Write( "AvailableDate", this.availableDateField );
			writer.Write( "Acknowledged", this.acknowledgedField );
			writer.Write( "AcknowledgedDate", this.acknowledgedDateField );
		}

		public override void WriteTo( IMwsWriter writer )
		{
			writer.Write( "http://mws.amazonaws.com/doc/2009-01-01/", "ReportInfo", this );
		}
	}
}