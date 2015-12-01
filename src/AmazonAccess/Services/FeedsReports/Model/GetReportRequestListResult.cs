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
	public class GetReportRequestListResult: AbstractMwsObject
	{
		private Boolean? hasNextField;
		private List< ReportRequestInfo > reportRequestInfoField;

		/// <summary>
		/// Gets and sets the NextToken property.
		/// </summary>
		public String NextToken{ get; set; }

		/// <summary>
		/// Sets the NextToken property
		/// </summary>
		/// <param name="nextToken">NextToken property</param>
		/// <returns>this instance</returns>
		public GetReportRequestListResult WithNextToken( String nextToken )
		{
			this.NextToken = nextToken;
			return this;
		}

		/// <summary>
		/// Checks if NextToken property is set
		/// </summary>
		/// <returns>true if NextToken property is set</returns>
		public Boolean IsSetNextToken()
		{
			return this.NextToken != null;
		}

		/// <summary>
		/// Gets and sets the HasNext property.
		/// </summary>
		public Boolean HasNext
		{
			get { return this.hasNextField.GetValueOrDefault(); }
			set { this.hasNextField = value; }
		}

		/// <summary>
		/// Sets the HasNext property
		/// </summary>
		/// <param name="hasNext">HasNext property</param>
		/// <returns>this instance</returns>
		public GetReportRequestListResult WithHasNext( Boolean hasNext )
		{
			this.hasNextField = hasNext;
			return this;
		}

		/// <summary>
		/// Checks if HasNext property is set
		/// </summary>
		/// <returns>true if HasNext property is set</returns>
		public Boolean IsSetHasNext()
		{
			return this.hasNextField.HasValue;
		}

		/// <summary>
		/// Gets and sets the ReportRequestInfo property.
		/// </summary>
		public List< ReportRequestInfo > ReportRequestInfo
		{
			get
			{
				if( this.reportRequestInfoField == null )
					this.reportRequestInfoField = new List< ReportRequestInfo >();
				return this.reportRequestInfoField;
			}
			set { this.reportRequestInfoField = value; }
		}

		/// <summary>
		/// Sets the ReportRequestInfo property
		/// </summary>
		/// <param name="list">ReportRequestInfo property</param>
		/// <returns>this instance</returns>
		public GetReportRequestListResult WithReportRequestInfo( params ReportRequestInfo[] list )
		{
			foreach( ReportRequestInfo item in list )
			{
				this.ReportRequestInfo.Add( item );
			}
			return this;
		}

		/// <summary>
		/// Checks if ReportRequestInfo property is set
		/// </summary>
		/// <returns>true if ReportRequestInfo property is set</returns>
		public Boolean IsSetReportRequestInfo()
		{
			return ( this.ReportRequestInfo.Count > 0 );
		}

		public override void ReadFragmentFrom( IMwsReader reader )
		{
			this.reportRequestInfoField = reader.ReadList< ReportRequestInfo >( "ReportRequestInfo" );
			this.NextToken = reader.Read< string >( "NextToken" );
			this.hasNextField = reader.Read< bool? >( "HasNext" );
		}

		public override void WriteFragmentTo( IMwsWriter writer )
		{
			writer.WriteList( "ReportRequestInfo", this.reportRequestInfoField );
			writer.Write( "NextToken", this.NextToken );
			writer.Write( "HasNext", this.hasNextField );
		}

		public override void WriteTo( IMwsWriter writer )
		{
			writer.Write( "http://mws.amazonaws.com/doc/2009-01-01/", "GetReportRequestListResult", this );
		}
	}
}