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
	[ XmlType( Namespace = "http://mws.amazonaws.com/doc/2009-01-01/" ) ]
	[ XmlRoot( Namespace = "http://mws.amazonaws.com/doc/2009-01-01/", IsNullable = false ) ]
	public class ManageReportScheduleResponse: AbstractMwsObject, IMWSResponse
	{
		/// <summary>
		/// Gets and sets the ManageReportScheduleResult property.
		/// </summary>
		[ XmlElement( ElementName = "ManageReportScheduleResult" ) ]
		public ManageReportScheduleResult ManageReportScheduleResult{ get; set; }

		/// <summary>
		/// Sets the ManageReportScheduleResult property
		/// </summary>
		/// <param name="manageReportScheduleResult">ManageReportScheduleResult property</param>
		/// <returns>this instance</returns>
		public ManageReportScheduleResponse WithManageReportScheduleResult( ManageReportScheduleResult manageReportScheduleResult )
		{
			this.ManageReportScheduleResult = manageReportScheduleResult;
			return this;
		}

		/// <summary>
		/// Checks if ManageReportScheduleResult property is set
		/// </summary>
		/// <returns>true if ManageReportScheduleResult property is set</returns>
		public Boolean IsSetManageReportScheduleResult()
		{
			return this.ManageReportScheduleResult != null;
		}

		/// <summary>
		/// Gets and sets the ResponseMetadata property.
		/// </summary>
		[ XmlElement( ElementName = "ResponseMetadata" ) ]
		public ResponseMetadata ResponseMetadata{ get; set; }

		/// <summary>
		/// Sets the ResponseMetadata property
		/// </summary>
		/// <param name="responseMetadata">ResponseMetadata property</param>
		/// <returns>this instance</returns>
		public ManageReportScheduleResponse WithResponseMetadata( ResponseMetadata responseMetadata )
		{
			this.ResponseMetadata = responseMetadata;
			return this;
		}

		/// <summary>
		/// Checks if ResponseMetadata property is set
		/// </summary>
		/// <returns>true if ResponseMetadata property is set</returns>
		public Boolean IsSetResponseMetadata()
		{
			return this.ResponseMetadata != null;
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

		public ResponseHeaderMetadata ResponseHeaderMetadata{ get; set; }
	}
}