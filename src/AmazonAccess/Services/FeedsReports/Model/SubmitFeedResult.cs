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
using AmazonAccess.Services.Common;

namespace AmazonAccess.Services.FeedsReports.Model
{
	public class SubmitFeedResult: AbstractMwsObject
	{
		/// <summary>
		/// Gets and sets the FeedSubmissionInfo property.
		/// </summary>
		public FeedSubmissionInfo FeedSubmissionInfo{ get; set; }

		/// <summary>
		/// Sets the FeedSubmissionInfo property
		/// </summary>
		/// <param name="feedSubmissionInfo">FeedSubmissionInfo property</param>
		/// <returns>this instance</returns>
		public SubmitFeedResult WithFeedSubmissionInfo( FeedSubmissionInfo feedSubmissionInfo )
		{
			this.FeedSubmissionInfo = feedSubmissionInfo;
			return this;
		}

		/// <summary>
		/// Checks if FeedSubmissionInfo property is set
		/// </summary>
		/// <returns>true if FeedSubmissionInfo property is set</returns>
		public Boolean IsSetFeedSubmissionInfo()
		{
			return this.FeedSubmissionInfo != null;
		}

		public override void ReadFragmentFrom( IMwsReader reader )
		{
			this.FeedSubmissionInfo = reader.Read< FeedSubmissionInfo >( "FeedSubmissionInfo" );
		}

		public override void WriteFragmentTo( IMwsWriter writer )
		{
			writer.Write( "FeedSubmissionInfo", this.FeedSubmissionInfo );
		}

		public override void WriteTo( IMwsWriter writer )
		{
			writer.Write( "http://mws.amazonaws.com/doc/2009-01-01", "SubmitFeedResult", this );
		}
	}
}