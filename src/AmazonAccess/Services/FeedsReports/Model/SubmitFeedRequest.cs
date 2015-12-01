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
using System.Text;
using AmazonAccess.Services.Common;

namespace AmazonAccess.Services.FeedsReports.Model
{
	public class SubmitFeedRequest: AbstractMwsObject
	{
		private Boolean? purgeAndReplaceField;

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
		public SubmitFeedRequest WithMarketplaceId( string[] marketplaceId )
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
		/// <param name="seller">Merchant property</param>
		/// <returns>this instance</returns>
		public SubmitFeedRequest WithSeller( String seller )
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
		public String MWSAuthToken{ get; set; }

		/// <summary>
		/// Sets the MWSAuthToken property
		/// </summary>
		/// <param name="mwsAuthToken">MWSAuthToken property</param>
		/// <returns>this instance</returns>
		public SubmitFeedRequest WithMWSAuthToken( String mwsAuthToken )
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
		/// Gets and sets the FeedContent property.
		/// </summary>
		public string FeedContent{ get; set; }

		/// <summary>
		/// Sets the FeedContent property
		/// </summary>
		/// <param name="feedContent">FeedContent property</param>
		/// <returns>this instance</returns>
		public SubmitFeedRequest WithFeedContent( string feedContent )
		{
			this.FeedContent = feedContent;
			return this;
		}

		/// <summary>
		/// Checks if FeedContent property is set
		/// </summary>
		/// <returns>true if FeedContent property is set</returns>
		public Boolean IsSetFeedContent()
		{
			return this.FeedContent != null;
		}

		/// <summary>
		/// Gets and sets the FeedType property.
		/// </summary>
		public String FeedType{ get; set; }

		/// <summary>
		/// Sets the FeedType property
		/// </summary>
		/// <param name="feedType">FeedType property</param>
		/// <returns>this instance</returns>
		public SubmitFeedRequest WithFeedType( String feedType )
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
		/// Gets and sets the PurgeAndReplace property.
		/// </summary>
		public Boolean PurgeAndReplace
		{
			get { return this.purgeAndReplaceField.GetValueOrDefault(); }
			set { this.purgeAndReplaceField = value; }
		}

		/// <summary>
		/// Sets the PurgeAndReplace property
		/// </summary>
		/// <param name="purgeAndReplace">PurgeAndReplace property</param>
		/// <returns>this instance</returns>
		public SubmitFeedRequest WithPurgeAndReplace( Boolean purgeAndReplace )
		{
			this.purgeAndReplaceField = purgeAndReplace;
			return this;
		}

		/// <summary>
		/// Checks if PurgeAndReplace property is set
		/// </summary>
		/// <returns>true if PurgeAndReplace property is set</returns>
		public Boolean IsSetPurgeAndReplace()
		{
			return this.purgeAndReplaceField.HasValue;
		}

		public override void ReadFragmentFrom( IMwsReader reader )
		{
			this.SellerId = reader.Read< string >( "SellerId" );
			this.MWSAuthToken = reader.Read< string >( "MWSAuthToken" );
			this.FeedType = reader.Read< string >( "FeedType" );
			this.purgeAndReplaceField = reader.Read< bool? >( "PurgeAndReplace" );
			this._marketplaceId = reader.ReadList< string >( "MarketplaceId", "Id" );
		}

		public override void WriteFragmentTo( IMwsWriter writer )
		{
			writer.Write( "SellerId", this.SellerId );
			writer.Write( "MWSAuthToken", this.MWSAuthToken );
			writer.Write( "FeedType", this.FeedType );
			writer.Write( "PurgeAndReplace", this.purgeAndReplaceField );
			writer.WriteList( "MarketplaceId", "Id", this._marketplaceId );
			writer.WriteRequestBody( this.FeedContent, Encoding.UTF8 );
		}

		public override void WriteTo( IMwsWriter writer )
		{
			writer.Write( "http://mws.amazonaws.com/doc/2009-01-01/", "SubmitFeedRequest", this );
		}
	}
}