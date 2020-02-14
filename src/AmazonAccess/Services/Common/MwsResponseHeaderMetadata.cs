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
using System.Net.Mime;
using System.Text;

namespace AmazonAccess.Services.Common
{
	/// <summary>
	/// Response header metadata
	/// </summary>
	public class MwsResponseHeaderMetadata
	{
		private readonly List< string > responseContext;

		public MwsResponseHeaderMetadata( string requestId,
			List< string > responseContext,
			DateTime? timestamp,
			decimal? quotaMax,
			decimal? quotaRemaining,
			DateTime? quotaResetsAt,
			DateTime? amzDate,
			DateTime? date,
			string connection,
			string contentLength,
			string contentType,
			string contentMd5 )
		{
			this.RequestId = requestId;
			this.Timestamp = timestamp;
			this.responseContext = responseContext;

			this.QuotaMax = quotaMax;
			this.QuotaRemaining = quotaRemaining;
			this.QuotaResetsAt = quotaResetsAt;

			this.AmzDate = amzDate;
			this.Date = date;
			this.Connection = connection;
			this.ContentLength = contentLength;
			this.ContentType = string.IsNullOrEmpty( contentType ) ? new ContentType() : new ContentType( contentType.ToLower() );
			this.ContentMD5 = contentMd5;
		}

		public MwsResponseHeaderMetadata( string requestId,
			string responseContext,
			DateTime? timestamp,
			decimal? quotaMax,
			decimal? quotaRemaining,
			DateTime? quotaResetsAt,
			DateTime? amzDate,
			DateTime? date,
			string connection,
			string contentLength,
			string contentType,
			string contentMd5 )
			: this( requestId,
				responseContext != null ? new List< string >( responseContext.Split( ',' ) ) : new List< string >(),
				timestamp,
				quotaMax,
				quotaRemaining,
				quotaResetsAt,
				amzDate,
				date,
				connection,
				contentLength,
				contentType,
				contentMd5 )
		{
		}

		public MwsResponseHeaderMetadata( string requestId, List< string > responseContext, DateTime? timestamp )
			: this( requestId, responseContext, timestamp, null, null, null, null, null, null, null, null, null )
		{
		}

		public MwsResponseHeaderMetadata( string requestId, string responseContext, DateTime? timestamp )
			: this( requestId, responseContext != null ? new List< string >( responseContext.Split( ',' ) ) : new List< string >(), timestamp )
		{
		}

		public MwsResponseHeaderMetadata( string requestId, string responseContext, DateTime? timestamp, decimal? quotaMax, decimal? quotaRemaining, DateTime? quotaResetsAt )
			: this( requestId, responseContext != null ? new List< string >( responseContext.Split( ',' ) ) : new List< string >(), timestamp, quotaMax, quotaRemaining, quotaResetsAt, null, null, null, null, null, null )
		{
		}

		public string RequestId{ get; private set; }

		public string ResponseContext
		{
			get { return string.Join( ", ", this.responseContext.ToArray() ); }
		}

		public DateTime? Timestamp{ get; private set; }

		/// <summary>
		/// Gets the max quota allowed for a quota period 
		/// (from the x-mws-quota-max header)
		/// </summary>
		public decimal? QuotaMax{ get; private set; }

		/// <summary>
		/// Gets the quota remaining within this quota period 
		/// (from the x-mws-quota-remaining header)
		/// </summary>
		public decimal? QuotaRemaining{ get; private set; }

		/// <summary>
		/// Gets the time that this quota period ends
		/// (from the x-mws-quota-resetsOn header)
		/// </summary>
		public DateTime? QuotaResetsAt{ get; private set; }

		public DateTime? AmzDate{ get; private set; }
		public DateTime? Date{ get; private set; }
		public string Connection{ get; private set; }
		public string ContentLength{ get; private set; }
		public ContentType ContentType{ get; private set; }
		public string ContentMD5{ get; private set; }

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append( "RequestId : " ).Append( this.RequestId ).Append( "\n" );
			sb.Append( "ResponseContext : " ).Append( this.ResponseContext ).Append( "\n" );
			sb.Append( "Timestamp : " ).Append( this.Timestamp?.ToUniversalTime() ).Append( "\n" );
			sb.Append( "QuotaMax : " ).Append( this.QuotaMax ).Append( "\n" );
			sb.Append( "QuotaRemaining : " ).Append( this.QuotaRemaining ).Append( "\n" );
			sb.Append( "QuotaResetsAt : " ).Append( this.QuotaResetsAt?.ToUniversalTime() ).Append( "\n" );
			sb.Append( "AmzDate : " ).Append( this.AmzDate?.ToUniversalTime() ).Append( "\n" );
			sb.Append( "Date : " ).Append( this.Date?.ToUniversalTime() ).Append( "\n" );
			sb.Append( "Connection : " ).Append( this.Connection ).Append( "\n" );
			sb.Append( "ContentLength : " ).Append( this.ContentLength ).Append( "\n" );
			sb.Append( "ContentType : " ).Append( this.ContentType ).Append( "\n" );
			sb.Append( "ContentMD5 : " ).Append( this.ContentMD5 );
			return sb.ToString();
		}
	}
}