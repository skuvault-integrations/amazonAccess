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
	public class GetFeedSubmissionListRequest: AbstractMwsObject
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
		public GetFeedSubmissionListRequest WithMarketplaceId( string[] marketplaceId )
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
		[ XmlElement( ElementName = "Seller" ) ]
		public String SellerId{ get; set; }

		/// <summary>
		/// Sets the Merchant property
		/// </summary>
		/// <param name="seller"></param>
		/// <returns>this instance</returns>
		public GetFeedSubmissionListRequest WithSeller( String seller )
		{
			this.SellerId = seller;
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
		public GetFeedSubmissionListRequest WithMWSAuthToken( String mwsAuthToken )
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
		/// Gets and sets the FeedSubmissionIdList property.
		/// </summary>
		[ XmlElement( ElementName = "FeedSubmissionIdList" ) ]
		public List< string > FeedSubmissionIdList{ get; set; }

		/// <summary>
		/// Sets the FeedSubmissionIdList property
		/// </summary>
		/// <param name="feedSubmissionIdList">FeedSubmissionIdList property</param>
		/// <returns>this instance</returns>
		public GetFeedSubmissionListRequest WithFeedSubmissionIdList( List< string > feedSubmissionIdList )
		{
			this.FeedSubmissionIdList = feedSubmissionIdList;
			return this;
		}

		/// <summary>
		/// Checks if FeedSubmissionIdList property is set
		/// </summary>
		/// <returns>true if FeedSubmissionIdList property is set</returns>
		public Boolean IsSetFeedSubmissionIdList()
		{
			return this.FeedSubmissionIdList != null;
		}

		/// <summary>
		/// Gets and sets the MaxCount property.
		/// </summary>
		[ XmlElement( ElementName = "MaxCount" ) ]
		public Decimal? MaxCount{ get; set; }

		/// <summary>
		/// Sets the MaxCount property
		/// </summary>
		/// <param name="maxCount">MaxCount property</param>
		/// <returns>this instance</returns>
		public GetFeedSubmissionListRequest WithMaxCount( Int32? maxCount )
		{
			this.MaxCount = maxCount;
			return this;
		}

		/// <summary>
		/// Checks if MaxCount property is set
		/// </summary>
		/// <returns>true if MaxCount property is set</returns>
		public Boolean IsSetMaxCount()
		{
			return this.MaxCount != null;
		}

		/// <summary>
		/// Gets and sets the FeedTypeList property.
		/// </summary>
		[ XmlElement( ElementName = "FeedTypeList" ) ]
		public List< string > FeedTypeList{ get; set; }

		/// <summary>
		/// Sets the FeedTypeList property
		/// </summary>
		/// <param name="feedTypeList">FeedTypeList property</param>
		/// <returns>this instance</returns>
		public GetFeedSubmissionListRequest WithFeedTypeList( List< string > feedTypeList )
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
		public List< string > FeedProcessingStatusList{ get; set; }

		/// <summary>
		/// Sets the FeedProcessingStatusList property
		/// </summary>
		/// <param name="feedProcessingStatusList">FeedProcessingStatusList property</param>
		/// <returns>this instance</returns>
		public GetFeedSubmissionListRequest WithFeedProcessingStatusList( List< string > feedProcessingStatusList )
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
		public GetFeedSubmissionListRequest WithSubmittedFromDate( DateTime submittedFromDate )
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
		public GetFeedSubmissionListRequest WithSubmittedToDate( DateTime submittedToDate )
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

		public override void ReadFragmentFrom( IMwsReader reader )
		{
			this.SellerId = reader.Read< string >( "SellerId" );
			this.MWSAuthToken = reader.Read< string >( "MWSAuthToken" );
			this.submittedFromDateField = reader.Read< DateTime? >( "SubmittedFromDate" );
			this.submittedToDateField = reader.Read< DateTime? >( "SubmittedToDate" );
			this.MaxCount = reader.Read< Decimal? >( "MaxCount" );

			this._marketplaceId = reader.ReadList< string >( "MarketplaceId", "Id" );
			this.FeedSubmissionIdList = reader.ReadList< string >( "FeedSubmissionIdList", "Id" );
			this.FeedTypeList = reader.ReadList< string >( "FeedTypeList", "Type" );
			this.FeedProcessingStatusList = reader.ReadList< string >( "FeedProcessingStatusList", "Status" );
		}

		public override void WriteFragmentTo( IMwsWriter writer )
		{
			writer.Write( "SellerId", this.SellerId );
			writer.Write( "MWSAuthToken", this.MWSAuthToken );
			writer.Write( "SubmittedFromDate", this.submittedFromDateField );
			writer.Write( "SubmittedToDate", this.submittedToDateField );
			writer.Write( "MaxCount", this.MaxCount );

			writer.WriteList( "MarketplaceId", "Id", this._marketplaceId );
			writer.WriteList( "FeedSubmissionIdList", "Id", this.FeedSubmissionIdList );
			writer.WriteList( "FeedTypeList", "Type", this.FeedTypeList );
			writer.WriteList( "FeedProcessingStatusList", "Status", this.FeedProcessingStatusList );
		}

		public override void WriteTo( IMwsWriter writer )
		{
			writer.Write( "http://mws.amazonaws.com/doc/2009-01-01/", "GetFeedSubmissionListRequest", this );
		}
	}
}