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
	public class GetFeedSubmissionCountRequest: AbstractMwsObject
	{
		private DateTime? submittedFromDateField;
		private DateTime? submittedToDateField;
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
		public GetFeedSubmissionCountRequest WithMarketplaceId( string[] marketplaceId )
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
		public GetFeedSubmissionCountRequest WithSellerId( String sellerId )
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
		public GetFeedSubmissionCountRequest WithMWSAuthToken( String mwsAuthToken )
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
		/// Gets and sets the FeedTypeList property.
		/// </summary>
		[ XmlElement( ElementName = "FeedTypeList" ) ]
		public TypeList FeedTypeList{ get; set; }

		/// <summary>
		/// Sets the FeedTypeList property
		/// </summary>
		/// <param name="feedTypeList">FeedTypeList property</param>
		/// <returns>this instance</returns>
		public GetFeedSubmissionCountRequest WithFeedTypeList( TypeList feedTypeList )
		{
			this.FeedTypeList = feedTypeList;
			return this;
		}

		/// <summary>
		/// Checks if FeedTypeList property is set
		/// </summary>
		/// <returns>true if FeedTypeList property is set</returns>
		public Boolean IsSetFeedTypeList()
		{
			return this.FeedTypeList != null;
		}

		/// <summary>
		/// Gets and sets the FeedProcessingStatusList property.
		/// </summary>
		[ XmlElement( ElementName = "FeedProcessingStatusList" ) ]
		public StatusList FeedProcessingStatusList{ get; set; }

		/// <summary>
		/// Sets the FeedProcessingStatusList property
		/// </summary>
		/// <param name="feedProcessingStatusList">FeedProcessingStatusList property</param>
		/// <returns>this instance</returns>
		public GetFeedSubmissionCountRequest WithFeedProcessingStatusList( StatusList feedProcessingStatusList )
		{
			this.FeedProcessingStatusList = feedProcessingStatusList;
			return this;
		}

		/// <summary>
		/// Checks if FeedProcessingStatusList property is set
		/// </summary>
		/// <returns>true if FeedProcessingStatusList property is set</returns>
		public Boolean IsSetFeedProcessingStatusList()
		{
			return this.FeedProcessingStatusList != null;
		}

		/// <summary>
		/// Gets and sets the SubmittedFromDate property.
		/// </summary>
		[ XmlElement( ElementName = "SubmittedFromDate" ) ]
		public DateTime SubmittedFromDate
		{
			get { return this.submittedFromDateField.GetValueOrDefault(); }
			set { this.submittedFromDateField = value; }
		}

		/// <summary>
		/// Sets the SubmittedFromDate property
		/// </summary>
		/// <param name="submittedFromDate">SubmittedFromDate property</param>
		/// <returns>this instance</returns>
		public GetFeedSubmissionCountRequest WithSubmittedFromDate( DateTime submittedFromDate )
		{
			this.submittedFromDateField = submittedFromDate;
			return this;
		}

		/// <summary>
		/// Checks if SubmittedFromDate property is set
		/// </summary>
		/// <returns>true if SubmittedFromDate property is set</returns>
		public Boolean IsSetSubmittedFromDate()
		{
			return this.submittedFromDateField.HasValue;
		}

		/// <summary>
		/// Gets and sets the SubmittedToDate property.
		/// </summary>
		[ XmlElement( ElementName = "SubmittedToDate" ) ]
		public DateTime SubmittedToDate
		{
			get { return this.submittedToDateField.GetValueOrDefault(); }
			set { this.submittedToDateField = value; }
		}

		/// <summary>
		/// Sets the SubmittedToDate property
		/// </summary>
		/// <param name="submittedToDate">SubmittedToDate property</param>
		/// <returns>this instance</returns>
		public GetFeedSubmissionCountRequest WithSubmittedToDate( DateTime submittedToDate )
		{
			this.submittedToDateField = submittedToDate;
			return this;
		}

		/// <summary>
		/// Checks if SubmittedToDate property is set
		/// </summary>
		/// <returns>true if SubmittedToDate property is set</returns>
		public Boolean IsSetSubmittedToDate()
		{
			return this.submittedToDateField.HasValue;
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