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
	public class GetFeedSubmissionResultRequest: AbstractMwsObject
	{
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
		public GetFeedSubmissionResultRequest WithMarketplaceId( string[] marketplaceId )
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
		[ XmlElement( ElementName = "Merchant" ) ]
		public String SellerId{ get; set; }

		/// <summary>
		/// Sets the Merchant property
		/// </summary>
		/// <param name="seller">Merchant property</param>
		/// <returns>this instance</returns>
		public GetFeedSubmissionResultRequest WithSeller( String seller )
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
		public GetFeedSubmissionResultRequest WithMWSAuthToken( String mwsAuthToken )
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
		/// Gets and sets the FeedSubmissionId property.
		/// </summary>
		[ XmlElement( ElementName = "FeedSubmissionId" ) ]
		public String FeedSubmissionId{ get; set; }

		/// <summary>
		/// Sets the FeedSubmissionId property
		/// </summary>
		/// <param name="feedSubmissionId">FeedSubmissionId property</param>
		/// <returns>this instance</returns>
		public GetFeedSubmissionResultRequest WithFeedSubmissionId( String feedSubmissionId )
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

		public override void ReadFragmentFrom( IMwsReader reader )
		{
			this.SellerId = reader.Read< string >( "SellerId" );
			this.MWSAuthToken = reader.Read< string >( "MWSAuthToken" );
			this.FeedSubmissionId = reader.Read< string >( "FeedSubmissionId" );
			this._marketplaceId = reader.ReadList< string >( "MarketplaceId", "Id" );
		}

		public override void WriteFragmentTo( IMwsWriter writer )
		{
			writer.Write( "SellerId", this.SellerId );
			writer.Write( "MWSAuthToken", this.MWSAuthToken );
			writer.Write( "FeedSubmissionId", this.FeedSubmissionId );
			writer.WriteList( "MarketplaceId", "Id", this._marketplaceId );
		}

		public override void WriteTo( IMwsWriter writer )
		{
			writer.Write( "http://mws.amazonaws.com/doc/2009-01-01/", "GetFeedSubmissionResultRequest", this );
		}
	}
}