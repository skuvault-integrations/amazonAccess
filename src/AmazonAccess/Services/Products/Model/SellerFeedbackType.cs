/*******************************************************************************
 * Copyright 2009-2015 Amazon Services. All Rights Reserved.
 * Licensed under the Apache License, Version 2.0 (the "License"); 
 *
 * You may not use this file except in compliance with the License. 
 * You may obtain a copy of the License at: http://aws.amazon.com/apache2.0
 * This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
 * CONDITIONS OF ANY KIND, either express or implied. See the License for the 
 * specific language governing permissions and limitations under the License.
 *******************************************************************************
 * Seller Feedback Type
 * API Version: 2011-10-01
 * Library Version: 2015-09-01
 * Generated: Thu Sep 10 06:52:19 PDT 2015
 */

using System.Xml.Serialization;
using AmazonAccess.Services.Common;

namespace AmazonAccess.Services.Products.Model
{
	[ XmlType( Namespace = "http://mws.amazonservices.com/schema/Products/2011-10-01" ) ]
	[ XmlRoot( Namespace = "http://mws.amazonservices.com/schema/Products/2011-10-01", IsNullable = false ) ]
	public class SellerFeedbackType: AbstractMwsObject
	{
		private decimal? _sellerPositiveFeedbackRating;

		/// <summary>
		/// Gets and sets the SellerPositiveFeedbackRating property.
		/// </summary>
		[ XmlElement( ElementName = "SellerPositiveFeedbackRating" ) ]
		public decimal SellerPositiveFeedbackRating
		{
			get { return this._sellerPositiveFeedbackRating.GetValueOrDefault(); }
			set { this._sellerPositiveFeedbackRating = value; }
		}

		/// <summary>
		/// Sets the SellerPositiveFeedbackRating property.
		/// </summary>
		/// <param name="sellerPositiveFeedbackRating">SellerPositiveFeedbackRating property.</param>
		/// <returns>this instance.</returns>
		public SellerFeedbackType WithSellerPositiveFeedbackRating( decimal sellerPositiveFeedbackRating )
		{
			this._sellerPositiveFeedbackRating = sellerPositiveFeedbackRating;
			return this;
		}

		/// <summary>
		/// Checks if SellerPositiveFeedbackRating property is set.
		/// </summary>
		/// <returns>true if SellerPositiveFeedbackRating property is set.</returns>
		public bool IsSetSellerPositiveFeedbackRating()
		{
			return this._sellerPositiveFeedbackRating != null;
		}

		/// <summary>
		/// Gets and sets the FeedbackCount property.
		/// </summary>
		[ XmlElement( ElementName = "FeedbackCount" ) ]
		public decimal FeedbackCount{ get; set; }

		/// <summary>
		/// Sets the FeedbackCount property.
		/// </summary>
		/// <param name="feedbackCount">FeedbackCount property.</param>
		/// <returns>this instance.</returns>
		public SellerFeedbackType WithFeedbackCount( decimal feedbackCount )
		{
			this.FeedbackCount = feedbackCount;
			return this;
		}

		/// <summary>
		/// Checks if FeedbackCount property is set.
		/// </summary>
		/// <returns>true if FeedbackCount property is set.</returns>
		public bool IsSetFeedbackCount()
		{
			return true;
		}

		public override void ReadFragmentFrom( IMwsReader reader )
		{
			this._sellerPositiveFeedbackRating = reader.Read< decimal? >( "SellerPositiveFeedbackRating" );
			this.FeedbackCount = reader.Read< decimal >( "FeedbackCount" );
		}

		public override void WriteFragmentTo( IMwsWriter writer )
		{
			writer.Write( "SellerPositiveFeedbackRating", this._sellerPositiveFeedbackRating );
			writer.Write( "FeedbackCount", this.FeedbackCount );
		}

		public override void WriteTo( IMwsWriter writer )
		{
			writer.Write( "http://mws.amazonservices.com/schema/Products/2011-10-01", "SellerFeedbackType", this );
		}

		public SellerFeedbackType(): base()
		{
		}
	}
}