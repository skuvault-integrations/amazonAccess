/******************************************************************************* 
 * Copyright 2009-2012 Amazon Services. All Rights Reserved.
 * Licensed under the Apache License, Version 2.0 (the "License"); 
 *
 * You may not use this file except in compliance with the License. 
 * You may obtain a copy of the License at: http://aws.amazon.com/apache2.0
 * This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
 * CONDITIONS OF ANY KIND, either express or implied. See the License for the 
 * specific language governing permissions and limitations under the License.
 *******************************************************************************
 * Marketplace Web Service Runtime Client Library
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace AmazonAccess.Services.Common
{
	/// <summary>
	/// Response header metadata
	/// </summary>
	public class MwsResponseHeaderMetadata
	{
		private readonly List< string > responseContext;

		public MwsResponseHeaderMetadata( string requestId, List< string > responseContext, string timestamp, double? quotaMax, double? quotaRemaining, DateTime? quotaResetsAt )
		{
			this.RequestId = requestId;
			this.Timestamp = timestamp;
			this.responseContext = responseContext;

			this.QuotaMax = quotaMax;
			this.QuotaRemaining = quotaRemaining;
			this.QuotaResetsAt = quotaResetsAt;
		}

		public MwsResponseHeaderMetadata( string requestId, string responseContext, string timestamp, double? quotaMax, double? quotaRemaining, DateTime? quotaResetsAt )
			: this( requestId, responseContext != null ? new List< string >( responseContext.Split( ',' ) ) : new List< string >(), timestamp, quotaMax, quotaRemaining, quotaResetsAt )
		{
		}

		public MwsResponseHeaderMetadata( string requestId, List< string > responseContext, string timestamp )
			: this( requestId, responseContext, timestamp, null, null, null )
		{
		}

		public MwsResponseHeaderMetadata( string requestId, string responseContext, string timestamp )
			: this( requestId, responseContext != null ? new List< string >( responseContext.Split( ',' ) ) : new List< string >(), timestamp )
		{
		}

		public MwsResponseHeaderMetadata( MwsResponseHeaderMetadata rhmd )
			: this( rhmd.RequestId, rhmd.ResponseContext, rhmd.Timestamp, rhmd.QuotaMax, rhmd.QuotaRemaining, rhmd.QuotaResetsAt )
		{
		}

		public string RequestId{ get; private set; }

		public string ResponseContext
		{
			get { return string.Join( ", ", this.responseContext.ToArray() ); }
		}

		public string Timestamp{ get; private set; }

		/// <summary>
		/// Gets the max quota allowed for a quota period 
		/// (from the x-mws-quota-max header)
		/// </summary>
		public double? QuotaMax{ get; private set; }

		/// <summary>
		/// Gets the quota remaining within this quota period 
		/// (from the x-mws-quota-remaining header)
		/// </summary>
		public double? QuotaRemaining{ get; private set; }

		/// <summary>
		/// Gets the time that this quota period ends
		/// (from the x-mws-quota-resetsOn header)
		/// </summary>
		public DateTime? QuotaResetsAt{ get; private set; }

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append( "requestId : " ).Append( this.RequestId ).Append( "\n" );
			sb.Append( "responseContext : " ).Append( this.ResponseContext ).Append( "\n" );
			sb.Append( "timestamp : " ).Append( this.Timestamp ).Append( "\n" );
			sb.Append( "quotaMax : " ).Append( this.QuotaMax ).Append( "\n" );
			sb.Append( "quotaRemaining : " ).Append( this.QuotaRemaining ).Append( "\n" );
			sb.Append( "quotaResetsAt : " ).Append( this.QuotaResetsAt );
			return sb.ToString();
		}
	}
}