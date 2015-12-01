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
	public class GetReportListResult: AbstractMwsObject
	{
		private Boolean? hasNextField;
		private List< ReportInfo > reportInfoField;

		/// <summary>
		/// Gets and sets the NextToken property.
		/// </summary>
		public String NextToken{ get; set; }

		/// <summary>
		/// Sets the NextToken property
		/// </summary>
		/// <param name="nextToken">NextToken property</param>
		/// <returns>this instance</returns>
		public GetReportListResult WithNextToken( String nextToken )
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
		public GetReportListResult WithHasNext( Boolean hasNext )
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
		/// Gets and sets the ReportInfo property.
		/// </summary>
		public List< ReportInfo > ReportInfo
		{
			get
			{
				if( this.reportInfoField == null )
					this.reportInfoField = new List< ReportInfo >();
				return this.reportInfoField;
			}
			set { this.reportInfoField = value; }
		}

		/// <summary>
		/// Sets the ReportInfo property
		/// </summary>
		/// <param name="list">ReportInfo property</param>
		/// <returns>this instance</returns>
		public GetReportListResult WithReportInfo( params ReportInfo[] list )
		{
			foreach( ReportInfo item in list )
			{
				this.ReportInfo.Add( item );
			}
			return this;
		}

		/// <summary>
		/// Checks if ReportInfo property is set
		/// </summary>
		/// <returns>true if ReportInfo property is set</returns>
		public Boolean IsSetReportInfo()
		{
			return ( this.ReportInfo.Count > 0 );
		}

		public override void ReadFragmentFrom( IMwsReader reader )
		{
			this.reportInfoField = reader.ReadList< ReportInfo >( "ReportInfo" );
			this.NextToken = reader.Read< string >( "NextToken" );
			this.hasNextField = reader.Read< bool? >( "HasNext" );
		}

		public override void WriteFragmentTo( IMwsWriter writer )
		{
			writer.WriteList( "ReportInfo", this.reportInfoField );
			writer.Write( "NextToken", this.NextToken );
			writer.Write( "HasNext", this.hasNextField );
		}

		public override void WriteTo( IMwsWriter writer )
		{
			writer.Write( "http://mws.amazonaws.com/doc/2009-01-01/", "GetReportListResult", this );
		}
	}
}