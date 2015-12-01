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
	public class GetReportCountRequest: AbstractMwsObject
	{
		private Boolean? acknowledgedField;
		private DateTime? availableFromDateField;
		private DateTime? availableToDateField;
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
		public GetReportCountRequest WithMarketplaceId( string[] marketplaceId )
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
		public GetReportCountRequest WithSellerId( String sellerId )
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
		public GetReportCountRequest WithMWSAuthToken( String mwsAuthToken )
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
		/// Gets and sets the ReportTypeList property.
		/// </summary>
		[ XmlElement( ElementName = "ReportTypeList" ) ]
		public TypeList ReportTypeList{ get; set; }

		/// <summary>
		/// Sets the ReportTypeList property
		/// </summary>
		/// <param name="reportTypeList">ReportTypeList property</param>
		/// <returns>this instance</returns>
		public GetReportCountRequest WithReportTypeList( TypeList reportTypeList )
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
		[ XmlElement( ElementName = "Acknowledged" ) ]
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
		public GetReportCountRequest WithAcknowledged( Boolean acknowledged )
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
		[ XmlElement( ElementName = "AvailableFromDate" ) ]
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
		public GetReportCountRequest WithAvailableFromDate( DateTime availableFromDate )
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
		[ XmlElement( ElementName = "AvailableToDate" ) ]
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
		public GetReportCountRequest WithAvailableToDate( DateTime availableToDate )
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