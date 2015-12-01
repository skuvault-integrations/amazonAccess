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
	public class ReportRequestInfo: AbstractMwsObject
	{
		private DateTime? startDateField;
		private DateTime? endDateField;
		private DateTime? submittedDateField;
		private DateTime? startedProcessingDateField;
		private DateTime? completedDateField;

		/// <summary>
		/// Gets and sets the ReportRequestId property.
		/// </summary>
		public String ReportRequestId{ get; set; }

		/// <summary>
		/// Sets the ReportRequestId property
		/// </summary>
		/// <param name="reportRequestId">ReportRequestId property</param>
		/// <returns>this instance</returns>
		public ReportRequestInfo WithReportRequestId( String reportRequestId )
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
		/// Gets and sets the ReportType property.
		/// </summary>
		public String ReportType{ get; set; }

		/// <summary>
		/// Sets the ReportType property
		/// </summary>
		/// <param name="reportType">ReportType property</param>
		/// <returns>this instance</returns>
		public ReportRequestInfo WithReportType( String reportType )
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
		public ReportRequestInfo WithStartDate( DateTime startDate )
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
		public ReportRequestInfo WithEndDate( DateTime endDate )
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
		/// Gets and sets the Scheduled property.
		/// </summary>
		public Boolean Scheduled{ get; set; }

		/// <summary>
		/// Sets the Scheduled property
		/// </summary>
		/// <param name="scheduled">Scheduled property</param>
		/// <returns>this instance</returns>
		public ReportRequestInfo WithScheduled( Boolean scheduled )
		{
			this.Scheduled = scheduled;
			return this;
		}

		/// <summary>
		/// Checks if Scheduled property is set
		/// </summary>
		/// <returns>true if Scheduled property is set</returns>
		public Boolean IsSetScheduled()
		{
			return this.Scheduled != null;
		}

		/// <summary>
		/// Gets and sets the SubmittedDate property.
		/// </summary>
		public DateTime SubmittedDate
		{
			get { return this.submittedDateField.GetValueOrDefault(); }
			set { this.submittedDateField = value; }
		}

		/// <summary>
		/// Sets the SubmittedDate property
		/// </summary>
		/// <param name="submittedDate">SubmittedDate property</param>
		/// <returns>this instance</returns>
		public ReportRequestInfo WithSubmittedDate( DateTime submittedDate )
		{
			this.submittedDateField = submittedDate;
			return this;
		}

		/// <summary>
		/// Checks if SubmittedDate property is set
		/// </summary>
		/// <returns>true if SubmittedDate property is set</returns>
		public Boolean IsSetSubmittedDate()
		{
			return this.submittedDateField.HasValue;
		}

		/// <summary>
		/// Gets and sets the ReportProcessingStatus property.
		/// </summary>
		public String ReportProcessingStatus{ get; set; }

		/// <summary>
		/// Sets the ReportProcessingStatus property
		/// </summary>
		/// <param name="reportProcessingStatus">ReportProcessingStatus property</param>
		/// <returns>this instance</returns>
		public ReportRequestInfo WithReportProcessingStatus( String reportProcessingStatus )
		{
			this.ReportProcessingStatus = reportProcessingStatus;
			return this;
		}

		/// <summary>
		/// Checks if ReportProcessingStatus property is set
		/// </summary>
		/// <returns>true if ReportProcessingStatus property is set</returns>
		public Boolean IsSetReportProcessingStatus()
		{
			return this.ReportProcessingStatus != null;
		}

		/// <summary>
		/// Gets and sets the GeneratedReportId property.
		/// </summary>
		public String GeneratedReportId{ get; set; }

		/// <summary>
		/// Sets the GeneratedReportId property
		/// </summary>
		/// <param name="reportRequestId">GeneratedReportId property</param>
		/// <returns>this instance</returns>
		public ReportRequestInfo WithGeneratedReportId( String generatedReportId )
		{
			this.GeneratedReportId = generatedReportId;
			return this;
		}

		/// <summary>
		/// Checks if GeneratedReportId property is set
		/// </summary>
		/// <returns>true if GeneratedReportId property is set</returns>
		public Boolean IsSetGeneratedReportId()
		{
			return this.GeneratedReportId != null;
		}

		/// <summary>
		/// Gets and sets the StartedProcessingDate property.
		/// </summary>
		public DateTime StartedProcessingDate
		{
			get { return this.startedProcessingDateField.GetValueOrDefault(); }
			set { this.startedProcessingDateField = value; }
		}

		/// <summary>
		/// Sets the StartedProcessingDate property
		/// </summary>
		/// <param name="startedProcessingDate">StartedProcessingDate property</param>
		/// <returns>this instance</returns>
		public ReportRequestInfo WithStartedProcessingDate( DateTime startedProcessingDate )
		{
			this.startedProcessingDateField = startedProcessingDate;
			return this;
		}

		/// <summary>
		/// Checks if StartedProcessingDate property is set
		/// </summary>
		/// <returns>true if StartedProcessingDate property is set</returns>
		public Boolean IsSetStartedProcessingDate()
		{
			return this.startedProcessingDateField.HasValue;
		}

		/// <summary>
		/// Gets and sets the CompletedDate property.
		/// </summary>
		public DateTime CompletedDate
		{
			get { return this.completedDateField.GetValueOrDefault(); }
			set { this.completedDateField = value; }
		}

		/// <summary>
		/// Sets the CompletedDate property
		/// </summary>
		/// <param name="completedDate">CompletedDate property</param>
		/// <returns>this instance</returns>
		public ReportRequestInfo WithCompletedDate( DateTime completedDate )
		{
			this.completedDateField = completedDate;
			return this;
		}

		/// <summary>
		/// Checks if CompletedDate property is set
		/// </summary>
		/// <returns>true if CompletedDate property is set</returns>
		public Boolean IsSetCompletedDate()
		{
			return this.completedDateField.HasValue;
		}

		public override void ReadFragmentFrom( IMwsReader reader )
		{
			this.ReportRequestId = reader.Read< string >( "ReportRequestId" );
			this.ReportType = reader.Read< string >( "ReportType" );
			this.startDateField = reader.Read< DateTime? >( "StartDate" );
			this.endDateField = reader.Read< DateTime? >( "EndDate" );
			this.Scheduled = reader.Read< bool >( "Scheduled" );
			this.submittedDateField = reader.Read< DateTime? >( "SubmittedDate" );
			this.ReportProcessingStatus = reader.Read< string >( "ReportProcessingStatus" );
			this.GeneratedReportId = reader.Read< string >( "GeneratedReportId" );
			this.startedProcessingDateField = reader.Read< DateTime? >( "StartedProcessingDate" );
			this.completedDateField = reader.Read< DateTime? >( "CompletedDate" );
		}

		public override void WriteFragmentTo( IMwsWriter writer )
		{
			writer.Write( "ReportRequestId", this.ReportRequestId );
			writer.Write( "ReportType", this.ReportType );
			writer.Write( "StartDate", this.startDateField );
			writer.Write( "EndDate", this.endDateField );
			writer.Write( "Scheduled", this.Scheduled );
			writer.Write( "SubmittedDate", this.submittedDateField );
			writer.Write( "ReportProcessingStatus", this.ReportProcessingStatus );
			writer.Write( "GeneratedReportId", this.GeneratedReportId );
			writer.Write( "StartedProcessingDate", this.startedProcessingDateField );
			writer.Write( "CompletedDate", this.completedDateField );
		}

		public override void WriteTo( IMwsWriter writer )
		{
			writer.Write( "http://mws.amazonaws.com/doc/2009-01-01/", "ReportRequestInfo", this );
		}
	}
}