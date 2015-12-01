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

namespace AmazonAccess.Services.FeedsReports.Model
{
	public class FeedSubmissionInfo: AbstractMwsObject
	{
		private DateTime? startedProcessingDateField;
		private DateTime? completedProcessingDateField;

		/// <summary>
		/// Gets and sets the FeedSubmissionId property.
		/// </summary>
		[ XmlElement( ElementName = "FeedSubmissionId" ) ]
		public String FeedSubmissionId{ get; set; }

		/// <summary>
		/// Sets the FeedSubmissionId property
		/// </summary>
		/// <param name="feedSubmissionId">FeedSubmissionId property</param>
		/// <returns>this instance</returns>
		public FeedSubmissionInfo WithFeedSubmissionId( String feedSubmissionId )
		{
			this.FeedSubmissionId = feedSubmissionId;
			return this;
		}

		/// <summary>
		/// Checks if FeedSubmissionId property is set
		/// </summary>
		/// <returns>true if FeedSubmissionId property is set</returns>
		public Boolean IsSetFeedSubmissionId()
		{
			return this.FeedSubmissionId != null;
		}

		/// <summary>
		/// Gets and sets the FeedType property.
		/// </summary>
		[ XmlElement( ElementName = "FeedType" ) ]
		public String FeedType{ get; set; }

		/// <summary>
		/// Sets the FeedType property
		/// </summary>
		/// <param name="feedType">FeedType property</param>
		/// <returns>this instance</returns>
		public FeedSubmissionInfo WithFeedType( String feedType )
		{
			this.FeedType = feedType;
			return this;
		}

		/// <summary>
		/// Checks if FeedType property is set
		/// </summary>
		/// <returns>true if FeedType property is set</returns>
		public Boolean IsSetFeedType()
		{
			return this.FeedType != null;
		}

		/// <summary>
		/// Gets and sets the SubmittedDate property.
		/// </summary>
		[ XmlElement( ElementName = "SubmittedDate" ) ]
		public String SubmittedDate{ get; set; }

		/// <summary>
		/// Sets the SubmittedDate property
		/// </summary>
		/// <param name="submittedDate">SubmittedDate property</param>
		/// <returns>this instance</returns>
		public FeedSubmissionInfo WithSubmittedDate( String submittedDate )
		{
			this.SubmittedDate = submittedDate;
			return this;
		}

		/// <summary>
		/// Checks if SubmittedDate property is set
		/// </summary>
		/// <returns>true if SubmittedDate property is set</returns>
		public Boolean IsSetSubmittedDate()
		{
			return this.SubmittedDate != null;
		}

		/// <summary>
		/// Gets and sets the FeedProcessingStatus property.
		/// </summary>
		[ XmlElement( ElementName = "FeedProcessingStatus" ) ]
		public String FeedProcessingStatus{ get; set; }

		/// <summary>
		/// Sets the FeedProcessingStatus property
		/// </summary>
		/// <param name="feedProcessingStatus">FeedProcessingStatus property</param>
		/// <returns>this instance</returns>
		public FeedSubmissionInfo WithFeedProcessingStatus( String feedProcessingStatus )
		{
			this.FeedProcessingStatus = feedProcessingStatus;
			return this;
		}

		/// <summary>
		/// Checks if FeedProcessingStatus property is set
		/// </summary>
		/// <returns>true if FeedProcessingStatus property is set</returns>
		public Boolean IsSetFeedProcessingStatus()
		{
			return this.FeedProcessingStatus != null;
		}

		/// <summary>
		/// Gets and sets the StartedProcessingDate property.
		/// </summary>
		[ XmlElement( ElementName = "StartedProcessingDate" ) ]
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
		public FeedSubmissionInfo WithStartedProcessingDate( DateTime startedProcessingDate )
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
		/// Gets and sets the CompletedProcessingDate property.
		/// </summary>
		[ XmlElement( ElementName = "CompletedProcessingDate" ) ]
		public DateTime CompletedProcessingDate
		{
			get { return this.completedProcessingDateField.GetValueOrDefault(); }
			set { this.completedProcessingDateField = value; }
		}

		/// <summary>
		/// Sets the CompletedProcessingDate property
		/// </summary>
		/// <param name="completedProcessingDate">CompletedProcessingDate property</param>
		/// <returns>this instance</returns>
		public FeedSubmissionInfo WithCompletedProcessingDate( DateTime completedProcessingDate )
		{
			this.completedProcessingDateField = completedProcessingDate;
			return this;
		}

		/// <summary>
		/// Checks if CompletedProcessingDate property is set
		/// </summary>
		/// <returns>true if CompletedProcessingDate property is set</returns>
		public Boolean IsSetCompletedProcessingDate()
		{
			return this.completedProcessingDateField.HasValue;
		}

		public override void ReadFragmentFrom( IMwsReader reader )
		{
			this.FeedSubmissionId = reader.Read< string >( "FeedSubmissionId" );
			this.FeedType = reader.Read< string >( "FeedType" );
			this.SubmittedDate = reader.Read< string >( "SubmittedDate" );
			this.FeedProcessingStatus = reader.Read< string >( "FeedProcessingStatus" );
			this.startedProcessingDateField = reader.Read< DateTime? >( "StartedProcessingDate" );
			this.completedProcessingDateField = reader.Read< DateTime? >( "CompletedProcessingDate" );
		}

		public override void WriteFragmentTo( IMwsWriter writer )
		{
			writer.Write( "FeedSubmissionId", this.FeedSubmissionId );
			writer.Write( "FeedType", this.FeedType );
			writer.Write( "SubmittedDate", this.SubmittedDate );
			writer.Write( "FeedProcessingStatus", this.FeedProcessingStatus );
			writer.Write( "StartedProcessingDate", this.startedProcessingDateField );
			writer.Write( "CompletedProcessingDate", this.completedProcessingDateField );
		}

		public override void WriteTo( IMwsWriter writer )
		{
			writer.Write( "http://mws.amazonaws.com/doc/2009-01-01/", "FeedSubmissionInfo", this );
		}
	}
}