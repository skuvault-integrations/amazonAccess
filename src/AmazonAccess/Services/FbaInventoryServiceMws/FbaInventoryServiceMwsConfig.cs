/******************************************************************************* 
 *  Copyright 2009 Amazon Services. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"); 
 *  
 *  You may not use this file except in compliance with the License. 
 *  You may obtain a copy of the License at: http://aws.amazon.com/apache2.0
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the 
 *  specific language governing permissions and limitations under the License.
 * ***************************************************************************** 
 * 
 *  FBA Inventory Service MWS CSharp Library
 *  API Version: 2010-10-01
 *  Generated: Fri Oct 22 09:53:30 UTC 2010 
 * 
 */

using System;
using System.Text;
using System.Text.RegularExpressions;

namespace AmazonAccess.Services.FbaInventoryServiceMws
{
	/// <summary>
	/// Configuration for accessing FBA Inventory Service MWS  service
	/// </summary>
	public class FbaInventoryServiceMwsConfig
	{
		private String serviceVersion = "2010-10-01";
		private String _serviceUrl;
		private String _userAgent;
		private String _signatureVersion = "2";
		private String _signatureMethod = "HmacSHA256";
		private String _proxyHost;
		private int _proxyPort = -1;
		private int _maxErrorRetry = 3;

		/// <summary>
		/// Gets Service Version
		/// </summary>
		public String ServiceVersion
		{
			get { return this.serviceVersion; }
		}

		/// <summary>
		/// Gets and sets of the signatureMethod property.
		/// </summary>
		public String SignatureMethod
		{
			get { return this._signatureMethod; }
			set { this._signatureMethod = value; }
		}

		/// <summary>
		/// Sets the SignatureMethod property
		/// </summary>
		/// <param name="signatureMethod">SignatureMethod property</param>
		/// <returns>this instance</returns>
		public FbaInventoryServiceMwsConfig WithSignatureMethod( String signatureMethod )
		{
			this._signatureMethod = signatureMethod;
			return this;
		}


		/// <summary>
		/// Checks if SignatureMethod property is set
		/// </summary>
		/// <returns>true if SignatureMethod property is set</returns>
		public Boolean IsSetSignatureMethod()
		{
			return this._signatureMethod != null;
		}

		/// <summary>
		/// Gets and sets of the SignatureVersion property.
		/// </summary>
		public String SignatureVersion
		{
			get { return this._signatureVersion; }
			set { this._signatureVersion = value; }
		}

		/// <summary>
		/// Sets the SignatureVersion property
		/// </summary>
		/// <param name="signatureVersion">SignatureVersion property</param>
		/// <returns>this instance</returns>
		public FbaInventoryServiceMwsConfig WithSignatureVersion( String signatureVersion )
		{
			this._signatureVersion = signatureVersion;
			return this;
		}

		/// <summary>
		/// Checks if SignatureVersion property is set
		/// </summary>
		/// <returns>true if SignatureVersion property is set</returns>
		public Boolean IsSetSignatureVersion()
		{
			return this._signatureVersion != null;
		}

		/// <summary>
		/// Gets and sets of the UserAgent property.
		/// </summary>
		public String UserAgent
		{
			get { return this._userAgent; }
		}

		/// <summary>
		/// Sets the UserAgent property
		/// </summary>
		/// <param name="userAgent">UserAgent property</param>
		/// <returns>this instance</returns>
		public FbaInventoryServiceMwsConfig WithUserAgent( String userAgent )
		{
			this._userAgent = userAgent;
			return this;
		}

		/// <summary>
		/// Checks if UserAgent property is set
		/// </summary>
		/// <returns>true if UserAgent property is set</returns>
		public Boolean IsSetUserAgent()
		{
			return this._userAgent != null;
		}

		/// <summary>
		/// Gets and sets of the ServiceURL property.
		/// </summary>
		public String ServiceURL
		{
			get { return this._serviceUrl; }
			set { this._serviceUrl = value; }
		}

		/// <summary>
		/// Sets the ServiceURL property
		/// </summary>
		/// <param name="serviceUrl">ServiceURL property</param>
		/// <returns>this instance</returns>
		public FbaInventoryServiceMwsConfig WithServiceURL( String serviceUrl )
		{
			this._serviceUrl = serviceUrl;
			return this;
		}

		/// <summary>
		/// Checks if ServiceURL property is set
		/// </summary>
		/// <returns>true if ServiceURL property is set</returns>
		public Boolean IsSetServiceURL()
		{
			return this._serviceUrl != null;
		}

		/// <summary>
		/// Gets and sets of the ProxyHost property.
		/// </summary>
		public String ProxyHost
		{
			get { return this._proxyHost; }
			set { this._proxyHost = value; }
		}

		/// <summary>
		/// Sets the ProxyHost property
		/// </summary>
		/// <param name="proxyHost">ProxyHost property</param>
		/// <returns>this instance</returns>
		public FbaInventoryServiceMwsConfig WithProxyHost( String proxyHost )
		{
			this._proxyHost = proxyHost;
			return this;
		}

		/// <summary>
		/// Checks if ProxyHost property is set
		/// </summary>
		/// <returns>true if ProxyHost property is set</returns>
		public Boolean IsSetProxyHost()
		{
			return this._proxyHost != null;
		}

		/// <summary>
		/// Gets and sets of the ProxyPort property.
		/// </summary>
		public int ProxyPort
		{
			get { return this._proxyPort; }
			set { this._proxyPort = value; }
		}

		/// <summary>
		/// Sets the ProxyPort property
		/// </summary>
		/// <param name="proxyPort">ProxyPort property</param>
		/// <returns>this instance</returns>
		public FbaInventoryServiceMwsConfig WithProxyPort( int proxyPort )
		{
			this._proxyPort = proxyPort;
			return this;
		}

		/// <summary>
		/// Checks if ProxyPort property is set
		/// </summary>
		/// <returns>true if ProxyPort property is set</returns>
		public Boolean IsSetProxyPort()
		{
			return this._proxyPort != -1;
		}

		/// <summary>
		/// Gets and sets of the MaxErrorRetry property.
		/// </summary>
		public int MaxErrorRetry
		{
			get { return this._maxErrorRetry; }
			set { this._maxErrorRetry = value; }
		}

		/// <summary>
		/// Sets the MaxErrorRetry property
		/// </summary>
		/// <param name="maxErrorRetry">MaxErrorRetry property</param>
		/// <returns>this instance</returns>
		public FbaInventoryServiceMwsConfig WithMaxErrorRetry( int maxErrorRetry )
		{
			this._maxErrorRetry = maxErrorRetry;
			return this;
		}

		/// <summary>
		/// Checks if MaxErrorRetry property is set
		/// </summary>
		/// <returns>true if MaxErrorRetry property is set</returns>
		public Boolean IsSetMaxErrorRetry()
		{
			return this._maxErrorRetry != -1;
		}

		public void SetUserAgentHeader(
			string applicationName,
			string applicationVersion,
			string programmingLanguage,
			params string[] additionalNameValuePairs )
		{
			if( applicationName == null )
			{
				throw new ArgumentNullException( "applicationName cannot be null." );
			}

			if( applicationVersion == null )
			{
				throw new ArgumentNullException( "applicationVersion cannot be null." );
			}

			if( programmingLanguage == null )
			{
				throw new ArgumentNullException( "programmingLanguage cannot be null." );
			}

			if( additionalNameValuePairs.Length % 2 != 0 )
			{
				throw new ArgumentException( "Every name must have a corresponding value." );
			}

			var sb = new StringBuilder();

			sb.Append( QuoteApplicationName( applicationName ) );
			sb.Append( "/" );
			sb.Append( QuoteApplicationVersion( applicationVersion ) );
			sb.Append( " (" );
			sb.Append( "Language=" );
			sb.Append( QuoteAttributeValue( programmingLanguage ) );

			int i = 0;
			while( i < additionalNameValuePairs.Length )
			{
				string name = additionalNameValuePairs[ i ];
				string value = additionalNameValuePairs[ ++i ];
				sb.Append( "; " );
				sb.Append( QuoteAttributeName( name ) );
				sb.Append( "=" );
				sb.Append( QuoteAttributeValue( value ) );

				i++;
			}

			sb.Append( ")" );

			this._userAgent = sb.ToString();
		}

		/// <summary>
		/// Replace all whitespace characters by a single space.
		/// </summary>
		public static string Clean( string s )
		{
			// matched character sequences are passed to a MatchEvaluator
			// delegate. The returned string from the delegate replaces
			// the matched sequence.
			return Regex.Replace( s, @" {2,}|\s", delegate
				{
					return " ";
				} );
		}

		/// <summary>
		/// Collapse whitespace, and escape the following characters are escaped:
		/// '\', and '/'.
		/// </summary>
		public static string QuoteApplicationName( string s )
		{
			return Clean( s ).Replace( @"\", @"\\" ).Replace( "@/", @"\/" );
		}

		/// <summary>
		/// Collapse whitespace, and escape the following characters are escaped:
		/// '\', and '('.
		/// </summary>
		public static string QuoteApplicationVersion( string s )
		{
			return Clean( s ).Replace( @"\", @"\\" ).Replace( @"(", @"\(" );
		}

		/// <summary>
		/// Collapse whitespace, and escape the following characters are escaped:
		/// '\', and '='.
		/// </summary>
		public static string QuoteAttributeName( string s )
		{
			return Clean( s ).Replace( @"\", @"\\" ).Replace( @"=", @"\=" );
		}

		/// <summary>
		/// Collapse whitespace, and escape the following characters are escaped:
		/// ')', '\', and ';'.
		/// </summary>
		public static string QuoteAttributeValue( string s )
		{
			return Clean( s ).Replace( @"\", @"\\" ).Replace( @";", @"\;" ).Replace( @")", @"\)" );
		}
	}
}