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
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using AmazonAccess.Misc;

namespace AmazonAccess.Services.Common
{
	/// <summary>
	/// AWS query call implementation
	/// </summary>
	public class MwsAQCall: IMwsCall
	{
		private readonly MwsConnection connection;
		private readonly IDictionary< string, string > parameters = new SortedDictionary< string, string >( StringComparer.Ordinal );
		private readonly IDictionary< string, string > headers = new SortedDictionary< string, string >( StringComparer.Ordinal );
		private readonly MwsConnection.ServiceEndpoint serviceEndPoint;
		private Stream StreamForRequestBody;
		private string DataForRequestBody;
		private Encoding EncodingForRequestBody;

		private readonly string operationName;
		private MwsResponseHeaderMetadata ResponseHeaderMetadata;

		public MwsAQCall( MwsConnection connection, MwsConnection.ServiceEndpoint serviceEndpoint, string operationName )
		{
			this.connection = connection;
			this.serviceEndPoint = serviceEndpoint;
			this.operationName = operationName;
		}

		/// <summary>
		/// Creates a request and invokes it 
		/// </summary>
		/// <returns></returns>
		/// <exception cref="MwsException">Exceptions from invoking the request</exception>
		public IMwsReader invoke( string marker )
		{
			var sellerId = this.GetSellerId();
			marker = marker ?? Guid.NewGuid().ToString();
			var operationNameForLog = "Invoke-" + this.operationName;
			AmazonLogger.Trace( operationNameForLog, sellerId, marker, "Begin invoke" );

			this.AddRequiredParameters();
			var queryString = this.GetParametersAsString( this.parameters );

			string responseBody;
			HttpStatusCode statusCode;
			try
			{
				string requestBody;
				HttpWebRequest request;
				if( this.StreamForRequestBody != null )
				{
					request = this.connection.GetHttpClient( this.serviceEndPoint.URI, queryString, this.headers, CalculateContentMD5( this.StreamForRequestBody ) );
					this.StreamForRequestBody.Position = 0;
					using( var streamReader = new StreamReader( this.StreamForRequestBody ) )
					{
						requestBody = streamReader.ReadToEnd();
						this.WriteToRequestBody( request, this.StreamForRequestBody );
						this.StreamForRequestBody.Close();
					}
				}
				else if( !string.IsNullOrEmpty( this.DataForRequestBody ) && this.EncodingForRequestBody != null )
				{
					var bites = this.EncodingForRequestBody.GetBytes( this.DataForRequestBody );
					request = this.connection.GetHttpClient( this.serviceEndPoint.URI, queryString, this.headers, CalculateContentMD5( bites ) );
					requestBody = this.DataForRequestBody;
					this.WriteToRequestBody( request, bites );
				}
				else
				{
					request = this.connection.GetHttpClient( this.serviceEndPoint.URI, this.headers );
					requestBody = queryString;
					this.WriteToRequestBody( request, queryString );
				}

				AmazonLogger.Trace( operationNameForLog, sellerId, marker, "Getting response for request with\n--- Request URL: ---\n{0}\n--- Request body ---\n{1}",
					request.RequestUri.OriginalString, requestBody );

				string message;
				using( var httpResponse = ( HttpWebResponse )request.GetResponse() )
				{
					statusCode = httpResponse.StatusCode;
					message = httpResponse.StatusDescription;
					this.ResponseHeaderMetadata = GetResponseHeaderMetadata( httpResponse );
					using( var responseStream = httpResponse.GetResponseStream() )
					using( var reader = new StreamReader( responseStream, Encoding.UTF8 ) )
						responseBody = reader.ReadToEnd();
				}

				AmazonLogger.Trace( operationNameForLog, sellerId, marker, "Response received with StatusCode:'{0}'\n--- Response header metadata: ---\n{1} \n--- Response body: ---\n{2}",
					statusCode, this.ResponseHeaderMetadata, responseBody );

				if( statusCode != HttpStatusCode.OK )
					throw new MwsException( ( int )statusCode, message, null, null, responseBody, this.ResponseHeaderMetadata );

				try
				{
					return new MwsXmlReader( responseBody );
				}
				catch( XmlException )
				{
					return new MwsStringReader( responseBody );
				}
			}
			catch( WebException we ) // Web exception is thrown on unsuccessful responses
			{
				AmazonLogger.Trace( operationNameForLog, sellerId, marker, "Exception occurred. Getting web exception message" );

				using( var httpErrorResponse = we.Response as HttpWebResponse )
				{
					if( httpErrorResponse == null )
					{
						AmazonLogger.Trace( operationNameForLog, sellerId, marker, "Web exception message:\n{0}", we.Message );
						throw new MwsException( we );
					}

					statusCode = httpErrorResponse.StatusCode;
					using( var responseStream = httpErrorResponse.GetResponseStream() )
					using( var reader = new StreamReader( responseStream, Encoding.UTF8 ) )
					{
						responseBody = reader.ReadToEnd();
						AmazonLogger.Trace( operationNameForLog, sellerId, marker, "Web exception message with StatusCode:'{0}'\n{1}", statusCode, responseBody );
					}
				}
				throw new MwsException( ( int )statusCode, null, null, null, responseBody, null );
			}
			catch( Exception e ) // Catch other exceptions, attempt to convert to formatted exception, else rethrow wrapped exception 
			{
				AmazonLogger.Trace( operationNameForLog, sellerId, marker, "Undefined exception message:\n{0}", e.Message );
				throw new MwsException( e );
			}
		}

		private void WriteToRequestBody( HttpWebRequest request, string requestData )
		{
			var bytes = new UTF8Encoding().GetBytes( requestData );
			this.WriteToRequestBody( request, bytes );
		}

		private void WriteToRequestBody( HttpWebRequest request, byte[] requestData )
		{
			request.ContentLength = requestData.Length;
			using( var requestStream = request.GetRequestStream() )
				requestStream.Write( requestData, 0, requestData.Length );
		}

		private void WriteToRequestBody( HttpWebRequest request, Stream requestData )
		{
			using( var requestStream = request.GetRequestStream() )
			{
				requestData.Position = 0;
				this.CopyStream( requestData, requestStream );
			}
		}

		/// <summary>
		/// Extracts and assigns the response header metadata
		/// </summary>
		/// <param name="httpResponse"></param>
		/// <returns></returns>
		private static MwsResponseHeaderMetadata GetResponseHeaderMetadata( HttpWebResponse httpResponse )
		{
			var requestId = httpResponse.GetResponseHeader( "x-mws-request-id" );
			var timestamp = httpResponse.GetResponseHeader( "x-mws-timestamp" );
			var contextStr = httpResponse.GetResponseHeader( "x-mws-response-context" );
			var context = new List< string >( contextStr.Split( ',' ) );

			double? quotaMax;
			try
			{
				string quotaMaxStr = httpResponse.GetResponseHeader( "x-mws-quota-max" );
				quotaMax = Double.Parse( quotaMaxStr );
			}
			catch( Exception )
			{
				quotaMax = null;
			}

			double? quotaRemaining;
			try
			{
				string quotaRemainingStr = httpResponse.GetResponseHeader( "x-mws-quota-remaining" );
				quotaRemaining = Double.Parse( quotaRemainingStr );
			}
			catch( Exception )
			{
				quotaRemaining = null;
			}

			DateTime? quotaResetsAt;
			try
			{
				string quotaResetsAtStr = httpResponse.GetResponseHeader( "x-mws-quota-resetsOn" );
				quotaResetsAt = MwsUtil.ParseTimestamp( quotaResetsAtStr );
			}
			catch( Exception )
			{
				quotaResetsAt = null;
			}

			string contentMD5;
			try
			{
				contentMD5 = httpResponse.GetResponseHeader( "Content-MD5" );
			}
			catch( Exception )
			{
				contentMD5 = null;
			}

			return new MwsResponseHeaderMetadata( requestId, context, timestamp, quotaMax, quotaRemaining, quotaResetsAt, contentMD5 );
		}

		/// <summary>
		/// Constructs the parameters as string 
		/// </summary>
		/// <param name="parameters"></param>
		/// <returns></returns>
		private string GetParametersAsString( IDictionary< string, string > parameters )
		{
			if( parameters.Count == 0 )
				return string.Empty;
			var data = new StringBuilder();
			foreach( var key in parameters.Keys )
			{
				var value = parameters[ key ];
				if( value != null )
				{
					data.Append( key );
					data.Append( '=' );
					data.Append( MwsUtil.UrlEncode( value, false ) );
					data.Append( '&' );
				}
			}
			string result = data.ToString();
			return result.Remove( result.Length - 1 );
		}

		/// <summary>
		/// Add authentication related and version parameters
		/// </summary>
		private void AddRequiredParameters()
		{
			this.parameters.Add( "AWSAccessKeyId", this.connection.AwsAccessKeyId );
			this.parameters.Add( "Action", this.operationName );
			this.parameters.Add( "Timestamp", MwsUtil.GetFormattedTimestamp() );
			var version = this.serviceEndPoint.version ?? this.connection.ServiceVersion;
			if( !string.IsNullOrEmpty( version ) )
				this.parameters.Add( "Version", version );
			string signature = MwsUtil.SignParameters( this.serviceEndPoint.URI, this.connection.SignatureVersion, this.connection.SignatureMethod, this.parameters, this.connection.AwsSecretKeyId );
			this.parameters.Add( "Signature", signature );
		}

		private string GetParametersForLog()
		{
			var parametersForLog = this.parameters
				.Where( x => !x.Key.Equals( "SellerId", StringComparison.InvariantCultureIgnoreCase ) &&
				             !x.Key.Equals( "MWSAuthToken", StringComparison.InvariantCultureIgnoreCase ) )
				.ToDictionary( x => x.Key, x => x.Value );
			return this.GetParametersAsString( parametersForLog );
		}

		private string GetSellerId()
		{
			var sellerId = this.parameters.FirstOrDefault( x => x.Key.Equals( "SellerId", StringComparison.InvariantCultureIgnoreCase ) );
			return sellerId.Value ?? string.Empty;
		}

		private void PutValue( IDictionary< string, string > dictionary, object value, StringBuilder prefix )
		{
			if( value == null )
				return;
			if( value is IMwsObject )
			{
				prefix.Append( '.' );
				( value as IMwsObject ).WriteFragmentTo( this );
				return;
			}
			var name = prefix.ToString();
			if( value is DateTime )
			{
				dictionary.Add( name, MwsUtil.GetFormattedTimestamp( ( DateTime )value ) );
				return;
			}
			var valueStr = value.ToString();
			if( string.IsNullOrEmpty( valueStr ) )
				return;
			if( value is bool )
				valueStr = valueStr.ToLower();
			dictionary.Add( name, valueStr );
		}

		public MwsResponseHeaderMetadata GetResponseMetadataHeader()
		{
			return this.ResponseHeaderMetadata;
		}

		/** The parameter prefix */
		private readonly StringBuilder parameterPrefix = new StringBuilder();
		private readonly StringBuilder headerPrefix = new StringBuilder();

		public void Write( string name, object value )
		{
			int holdParameterPrefixLen = this.parameterPrefix.Length;
			this.parameterPrefix.Append( name );
			this.PutValue( this.parameters, value, this.parameterPrefix );
			this.parameterPrefix.Length = holdParameterPrefixLen;
		}

		public void WriteHeader( string name, object value )
		{
			int holdPrefixLen = this.headerPrefix.Length;
			this.headerPrefix.Append( name );
			this.PutValue( this.headers, value, this.headerPrefix );
			this.headerPrefix.Length = holdPrefixLen;
		}

		public void Write( string xmlNamespace, string name, IMwsObject value )
		{
			if( value != null )
				value.WriteFragmentTo( this );
		}

		public void WriteAttribute( string name, object value )
		{
			this.Write( name, value );
		}

		public void WriteList< T >( string name, string memberName, ICollection< T > list )
		{
			if( list == null )
				return;
			if( name == null && memberName == null )
				throw new ArgumentNullException( "Both name and memberName cannot be null." );
			var holdParameterPrefixLen = this.parameterPrefix.Length;
			if( name != null )
				this.parameterPrefix.Append( name );
			if( name != null && memberName != null )
				this.parameterPrefix.Append( '.' );
			if( memberName != null )
				this.parameterPrefix.Append( memberName );
			this.parameterPrefix.Append( '.' );
			int dotLen = this.parameterPrefix.Length;
			int i = 1;
			foreach( Object v in list )
			{
				this.parameterPrefix.Length = dotLen;
				this.parameterPrefix.Append( i );
				this.PutValue( this.parameters, v, this.parameterPrefix );
				i++;
			}
			this.parameterPrefix.Length = holdParameterPrefixLen;
		}

		public void WriteList< T >( string name, ICollection< T > list )
		{
			this.WriteList( null, name, list );
		}

		public void WriteAny( ICollection< XmlElement > elements )
		{
			throw new NotSupportedException( "WriteAny not supported" );
		}

		public void WriteRequestBody( Stream bodyStream )
		{
			this.StreamForRequestBody = bodyStream;
		}

		public void WriteRequestBody( string bodyData, Encoding encoding )
		{
			this.DataForRequestBody = bodyData;
			this.EncodingForRequestBody = encoding;
		}

		public void WriteValue( object value )
		{
			throw new NotSupportedException( "WriteValue not supported" );
		}

		public void BeginObject( string name )
		{
			throw new NotSupportedException( "Complex object writing not supported" );
		}

		public void close()
		{
			//nothing to do
		}

		public void EndObject( string name )
		{
			throw new NotSupportedException( "Complex object writing not supported" );
		}

		public static string CalculateContentMD5( Stream content )
		{
			var provider = new MD5CryptoServiceProvider();
			var hash = provider.ComputeHash( content );
			return Convert.ToBase64String( hash );
		}

		public static string CalculateContentMD5( byte[] content )
		{
			var provider = new MD5CryptoServiceProvider();
			var hash = provider.ComputeHash( content );
			return Convert.ToBase64String( hash );
		}

		private void CopyStream( Stream from, Stream to )
		{
			if( !from.CanRead )
				throw new ArgumentException( "from Stream must implement the Read method." );

			if( !to.CanWrite )
				throw new ArgumentException( "to Stream must implement the Write method." );

			const int SIZE = 1024 * 1024;
			var buffer = new byte[ SIZE ];

			var read = 0;
			while( ( read = from.Read( buffer, 0, buffer.Length ) ) > 0 )
				to.Write( buffer, 0, read );
		}
	}
}