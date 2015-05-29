/******************************************************************************* 
 *  Copyright 2008-2012 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"); 
 *  
 *  You may not use this file except in compliance with the License. 
 *  You may obtain a copy of the License at: http://aws.amazon.com/apache2.0
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the 
 *  specific language governing permissions and limitations under the License.
 * ***************************************************************************** 
 * 
 *  Marketplace Web Service Orders CSharp Library
 *  API Version: 2011-01-01
 * 
 */

using System;
using System.Net;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Globalization;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Runtime.Serialization;
using AmazonAccess.Misc;
using AmazonAccess.Services.MarketplaceWebServiceOrders.Model;

namespace AmazonAccess.Services.MarketplaceWebServiceOrders
{
	/**

    *
    * MarketplaceWebServiceOrdersClient is an implementation of MarketplaceWebServiceOrders
    *
    */

	public class MarketplaceWebServiceOrdersClient: IMarketplaceWebServiceOrders
	{

		private readonly String awsAccessKeyId;
		private readonly String awsSecretAccessKey;
		private readonly MarketplaceWebServiceOrdersConfig config;
		private const String REQUEST_THROTTLED_ERROR_CODE = "RequestThrottled";
		private string _sellerId = string.Empty;

		/// <summary>
		/// Constructs MarketplaceWebServiceOrdersClient with AWS Access Key ID and AWS Secret Key
		/// </summary>
		/// <param name="applicationName">Your application's name, e.g. "MyMWSApp"</param>
		/// <param name="applicationVersion">Your application's version, e.g. "1.0"</param>
		/// <param name="awsAccessKeyId">AWS Access Key ID</param>
		/// <param name="awsSecretAccessKey">AWS Secret Access Key</param>
		/// <param name="config">configuration</param>
		public MarketplaceWebServiceOrdersClient(
			String applicationName,
			String applicationVersion,
			String awsAccessKeyId,
			String awsSecretAccessKey,
			MarketplaceWebServiceOrdersConfig config )
		{
			this.awsAccessKeyId = awsAccessKeyId;
			this.awsSecretAccessKey = awsSecretAccessKey;
			this.config = config;
			ServicePointManager.Expect100Continue = false;
			ServicePointManager.UseNagleAlgorithm = false;
			config.SetUserAgent( applicationName, applicationVersion );
		}


		// Public API ------------------------------------------------------------//


		/// <summary>
		/// List Orders By Next Token 
		/// </summary>
		/// <param name="request">List Orders By Next Token  request</param>
		/// <returns>List Orders By Next Token  Response from the service</returns>
		/// <remarks>
		/// If ListOrders returns a nextToken, thus indicating that there are more orders
		/// than returned that matched the given filter criteria, ListOrdersByNextToken
		/// can be used to retrieve those other orders using that nextToken.
		/// 
		/// </remarks>
		public ListOrdersByNextTokenResponse ListOrdersByNextToken( ListOrdersByNextTokenRequest request )
		{
			this._sellerId = request.SellerId;
			return this.Invoke< ListOrdersByNextTokenResponse >( this.ConvertListOrdersByNextToken( request ) );
		}


		/// <summary>
		/// List Order Items By Next Token 
		/// </summary>
		/// <param name="request">List Order Items By Next Token  request</param>
		/// <returns>List Order Items By Next Token  Response from the service</returns>
		/// <remarks>
		/// If ListOrderItems cannot return all the order items in one go, it will
		/// provide a nextToken. That nextToken can be used with this operation to
		/// retrive the next batch of items for that order.
		/// 
		/// </remarks>
		public ListOrderItemsByNextTokenResponse ListOrderItemsByNextToken( ListOrderItemsByNextTokenRequest request )
		{
			this._sellerId = request.SellerId;
			return this.Invoke< ListOrderItemsByNextTokenResponse >( this.ConvertListOrderItemsByNextToken( request ) );
		}


		/// <summary>
		/// Get Order 
		/// </summary>
		/// <param name="request">Get Order  request</param>
		/// <returns>Get Order  Response from the service</returns>
		/// <remarks>
		/// This operation takes up to 50 order ids and returns the corresponding orders.
		/// 
		/// </remarks>
		public GetOrderResponse GetOrder( GetOrderRequest request )
		{
			this._sellerId = request.SellerId;
			return this.Invoke< GetOrderResponse >( this.ConvertGetOrder( request ) );
		}


		/// <summary>
		/// List Order Items 
		/// </summary>
		/// <param name="request">List Order Items  request</param>
		/// <returns>List Order Items  Response from the service</returns>
		/// <remarks>
		/// This operation can be used to list the items of the order indicated by the
		/// given order id (only a single Amazon order id is allowed).
		/// 
		/// </remarks>
		public ListOrderItemsResponse ListOrderItems( ListOrderItemsRequest request )
		{
			this._sellerId = request.SellerId;
			return this.Invoke< ListOrderItemsResponse >( this.ConvertListOrderItems( request ) );
		}


		/// <summary>
		/// List Orders 
		/// </summary>
		/// <param name="request">List Orders  request</param>
		/// <returns>List Orders  Response from the service</returns>
		/// <remarks>
		/// ListOrders can be used to find orders that meet the specified criteria.
		/// 
		/// </remarks>
		public ListOrdersResponse ListOrders( ListOrdersRequest request )
		{
			this._sellerId = request.SellerId;
			return this.Invoke< ListOrdersResponse >( this.ConvertListOrders( request ) );
		}


		/// <summary>
		/// Get Service Status 
		/// </summary>
		/// <param name="request">Get Service Status  request</param>
		/// <returns>Get Service Status  Response from the service</returns>
		/// <remarks>
		/// Returns the service status of a particular MWS API section. The operation
		/// takes no input.
		/// 
		/// </remarks>
		public GetServiceStatusResponse GetServiceStatus( GetServiceStatusRequest request )
		{
			return this.Invoke< GetServiceStatusResponse >( this.ConvertGetServiceStatus( request ) );
		}

		// Private API ------------------------------------------------------------//

		/**
         * Configure HttpClient with set of defaults as well as configuration
         * from MarketplaceWebServiceOrdersConfig instance
         */

		private HttpWebRequest ConfigureWebRequest( int contentLength )
		{
			var request = WebRequest.Create( this.config.ServiceURL ) as HttpWebRequest;

			if( this.config.IsSetProxyHost() )
			{
				if( request != null )
					request.Proxy = new WebProxy( this.config.ProxyHost, this.config.ProxyPort );
			}
			request.UserAgent = this.config.UserAgent;
			request.Method = "POST";
			request.Timeout = 50000;
			request.ContentType = "application/x-www-form-urlencoded; charset=utf-8";
			request.ContentLength = contentLength;

			return request;
		}

		/**
         * Invoke request and return response
         */

		private T Invoke< T >( IDictionary< String, String > parameters )
		{
			string methodName;
			if( !parameters.TryGetValue( "Action", out methodName ) )
				methodName = "Unknown";

			AmazonLogger.Log.Trace( "[amazon] Orders-{0}. Seller: {1}. Begin invoke...", methodName, this._sellerId );

			var response = default( T );
			ResponseHeaderMetadata rhm = null;
			if( String.IsNullOrEmpty( this.config.ServiceURL ) )
			{
				throw new MarketplaceWebServiceOrdersException(
					new ArgumentException(
						"Missing serviceURL configuration value. You may obtain a list of valid MWS URLs by consulting the MWS Developer's Guide, or reviewing the sample code published along side this library." ) );
			}

			/* Add required request parameters */
			this.AddRequiredParameters( parameters );

			var queryString = this.GetParametersAsString( parameters );

			var requestData = new UTF8Encoding().GetBytes( queryString );
			bool shouldRetry;
			var retries = 0;

			AmazonLogger.Log.Trace( "[amazon] Orders query string: {0}", queryString );
			do
			{
				var request = this.ConfigureWebRequest( requestData.Length );
				/* Submit the request and read response body */
				var responseBody = string.Empty;
				try
				{
					using( var requestStream = request.GetRequestStream() )
					{
						requestStream.Write( requestData, 0, requestData.Length );
					}

					AmazonLogger.Log.Trace( "[amazon] Orders-{0}. Seller {1}. Getting response.", methodName, this._sellerId );

					using( var httpResponse = request.GetResponse() as HttpWebResponse )
					{
						if( httpResponse != null )
						{
							rhm = new ResponseHeaderMetadata(
								httpResponse.GetResponseHeader( "x-mws-request-id" ),
								httpResponse.GetResponseHeader( "x-mws-response-context" ),
								httpResponse.GetResponseHeader( "x-mws-timestamp" ),
								null,
								null,
								null );

							var reader = new StreamReader( httpResponse.GetResponseStream(), Encoding.UTF8 );
							responseBody = reader.ReadToEnd();
						}

						AmazonLogger.Log.Trace( "[amazon] Orders-{0}. Seller: {1}\nResponse received: {2}", methodName, this._sellerId, responseBody );
					}

					/* Attempt to deserialize response into <Action> Response type */
					using( var responseReader = new StringReader( responseBody ) )
					{
						var serializer = new XmlSerializer( typeof( T ) );
						response = ( T )serializer.Deserialize( responseReader );

						var pi = typeof( T ).GetProperty( "ResponseHeaderMetadata" );
						pi.SetValue( response, rhm, null );
					}
					shouldRetry = false;
				}
				catch( WebException we ) // Web exception is thrown on unsucessful responses
				{
					AmazonLogger.Log.Trace( "[amazon] Orders-{0}. Seller: {1}. Exception occurred. Getting web exception message.", methodName, this._sellerId );

					HttpStatusCode statusCode;
					using( var httpErrorResponse = ( HttpWebResponse )we.Response )
					{
						if( httpErrorResponse == null )
						{
							responseBody = we.Message;
							AmazonLogger.Log.Trace( "[amazon] Orders-{0}. Seller: {1}\nWeb exception message: {2}", methodName, this._sellerId, responseBody );

							throw new MarketplaceWebServiceOrdersException( we );
						}
						statusCode = httpErrorResponse.StatusCode;
						using( var reader = new StreamReader( httpErrorResponse.GetResponseStream(), Encoding.UTF8 ) )
						{
							responseBody = reader.ReadToEnd();
							AmazonLogger.Log.Trace( "[amazon] Orders-{0}. Seller: {1}. Status code: {2}\nWeb exception message: {3}", methodName, this._sellerId, statusCode, responseBody );
						}
					}

					/* Attempt to deserialize response into ErrorResponse type */
					using( var responseReader = new StringReader( responseBody ) )
					{
						try
						{
							var serializer = new XmlSerializer( typeof( ErrorResponse ) );
							var errorResponse = ( ErrorResponse )serializer.Deserialize( responseReader );
							var error = errorResponse.Error[ 0 ];

							var retriableError = ( statusCode == HttpStatusCode.InternalServerError ||
							                       statusCode == HttpStatusCode.ServiceUnavailable );
							retriableError = retriableError &&
							                 !( REQUEST_THROTTLED_ERROR_CODE.Equals( error.Code ) );

							if( retriableError && retries < this.config.MaxErrorRetry )
							{
								shouldRetry = true;
								this.PauseOnRetry( ++retries, statusCode, rhm );
								continue;
							}

							/* Throw formatted exception with information available from the error response */
							throw new MarketplaceWebServiceOrdersException(
								error.Message,
								statusCode,
								error.Code,
								error.Type,
								errorResponse.RequestId,
								errorResponse.ToXML(),
								rhm );
						}
						catch( Exception e )
						{
							throw new AmazonOrdersException( string.Format( "Amazon WMS error for seller {0} and response {1}", this._sellerId, responseBody ), e );
						}
					}
				}
					/* Catch other exceptions, attempt to convert to formatted exception, else rethrow wrapped exception */
				catch( Exception e )
				{
					AmazonLogger.Log.Trace( "[amazon] Orders-{0}. Seller: {1}\nUndefined exception message: {2}", methodName, this._sellerId, e.Message );
					throw;
				}
			} while( shouldRetry );
			AmazonLogger.Log.Trace( "[amazon] Orders-{0}. Seller: {1}. End invoke...", methodName, this._sellerId );

			return response;
		}


	   /*
         * Exponential sleep on failed request
         */

		private void PauseOnRetry( int retries, HttpStatusCode status, ResponseHeaderMetadata rhm )
		{
			if( retries <= this.config.MaxErrorRetry )
			{
				int delay = ( int )Math.Pow( 4, retries ) * 100;
				AmazonLogger.Log.Trace( "[amazon]Orders. Pause on retry. Seller {0}", this._sellerId );
				System.Threading.Thread.Sleep( delay );
			}
			else
			{
				throw new MarketplaceWebServiceOrdersException( "Maximum number of retry attempts reached : " + ( retries - 1 ), status, rhm );
			}
		}

		/**
         * Add authentication related and version parameters
         */

		private void AddRequiredParameters( IDictionary< String, String > parameters )
		{
			parameters.Add( "AWSAccessKeyId", this.awsAccessKeyId );
			parameters.Add( "Timestamp", this.GetFormattedTimestamp() );
			parameters.Add( "Version", this.config.ServiceVersion );
			parameters.Add( "SignatureVersion", this.config.SignatureVersion );
			parameters.Add( "Signature", this.SignParameters( parameters, this.awsSecretAccessKey ) );
		}

		/**
         * Convert Dictionary of paremeters to Url encoded query string
         */

		private string GetParametersAsString( IDictionary< String, String > parameters )
		{
			var data = new StringBuilder();
			foreach( var key in parameters.Keys )
			{
				var value = parameters[ key ];
				if( value != null )
				{
					data.Append( key );
					data.Append( '=' );
					data.Append( this.UrlEncode( value, false ) );
					data.Append( '&' );
				}
			}
			var result = data.ToString();
			return result.Remove( result.Length - 1 );
		}

		/**
         * Computes RFC 2104-compliant HMAC signature for request parameters
         * Implements AWS Signature, as per following spec:
         *
         * If Signature Version is 0, it signs concatenated Action and Timestamp
         *
         * If Signature Version is 1, it performs the following:
         *
         * Sorts all  parameters (including SignatureVersion and excluding Signature,
         * the value of which is being created), ignoring case.
         *
         * Iterate over the sorted list and append the parameter name (in original case)
         * and then its value. It will not URL-encode the parameter values before
         * constructing this string. There are no separators.
         *
         * If Signature Version is 2, string to sign is based on following:
         *
         *    1. The HTTP Request Method followed by an ASCII newline (%0A)
         *    2. The HTTP Host header in the form of lowercase host, followed by an ASCII newline.
         *    3. The URL encoded HTTP absolute path component of the URI
         *       (up to but not including the query string parameters);
         *       if this is empty use a forward '/'. This parameter is followed by an ASCII newline.
         *    4. The concatenation of all query string components (names and values)
         *       as UTF-8 characters which are URL encoded as per RFC 3986
         *       (hex characters MUST be uppercase), sorted using lexicographic byte ordering.
         *       Parameter names are separated from their values by the '=' character
         *       (ASCII character 61), even if the value is empty.
         *       Pairs of parameter and values are separated by the '&' character (ASCII code 38).
         *
         */

		private String SignParameters( IDictionary< String, String > parameters, String key )
		{
			String signatureVersion = parameters[ "SignatureVersion" ];

			KeyedHashAlgorithm algorithm = new HMACSHA1();

			String stringToSign;
			if( "0".Equals( signatureVersion ) )
			{
				stringToSign = this.CalculateStringToSignV0( parameters );
			}
			else if( "1".Equals( signatureVersion ) )
			{
				stringToSign = this.CalculateStringToSignV1( parameters );
			}
			else if( "2".Equals( signatureVersion ) )
			{
				String signatureMethod = this.config.SignatureMethod;
				algorithm = KeyedHashAlgorithm.Create( signatureMethod.ToUpper() );
				parameters.Add( "SignatureMethod", signatureMethod );
				stringToSign = this.CalculateStringToSignV2( parameters );
			}
			else
			{
				throw new Exception( "Invalid Signature Version specified" );
			}

			return this.Sign( stringToSign, key, algorithm );
		}

		private String CalculateStringToSignV0( IDictionary< String, String > parameters )
		{
			var data = new StringBuilder();
			return data.Append( parameters[ "Action" ] ).Append( parameters[ "Timestamp" ] ).ToString();

		}

		private String CalculateStringToSignV1( IDictionary< String, String > parameters )
		{
			var data = new StringBuilder();
			IDictionary< String, String > sorted =
				new SortedDictionary< String, String >( parameters, StringComparer.OrdinalIgnoreCase );
			foreach( KeyValuePair< String, String > pair in sorted )
			{
				if( pair.Value != null )
				{
					data.Append( pair.Key );
					data.Append( pair.Value );
				}
			}
			return data.ToString();
		}

		private String CalculateStringToSignV2( IDictionary< String, String > parameters )
		{
			var data = new StringBuilder();
			IDictionary< String, String > sorted =
				new SortedDictionary< String, String >( parameters, StringComparer.Ordinal );
			data.Append( "POST" );
			data.Append( "\n" );
			var endpoint = new Uri( this.config.ServiceURL );

			data.Append( endpoint.Host );
			if( endpoint.Port != 80 && endpoint.Port != 443 )
			{
				data.Append( ":" );
				data.Append( endpoint.Port );
			}
			data.Append( "\n" );
			String uri = endpoint.AbsolutePath;
			if( String.IsNullOrEmpty( uri ) )
			{
				uri = "/";
			}
			data.Append( this.UrlEncode( uri, true ) );
			data.Append( "\n" );
			foreach( KeyValuePair< String, String > pair in sorted )
			{
				if( pair.Value != null )
				{
					data.Append( this.UrlEncode( pair.Key, false ) );
					data.Append( "=" );
					data.Append( this.UrlEncode( pair.Value, false ) );
					data.Append( "&" );
				}

			}

			String result = data.ToString();
			return result.Remove( result.Length - 1 );
		}

		private String UrlEncode( String data, bool path )
		{
			var encoded = new StringBuilder();
			var unreservedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~" + ( path ? "/" : "" );

			foreach( char symbol in Encoding.UTF8.GetBytes( data ) )
			{
				if( unreservedChars.IndexOf( symbol ) != -1 )
				{
					encoded.Append( symbol );
				}
				else
				{
					encoded.Append( "%" + String.Format( "{0:X2}", ( int )symbol ) );
				}
			}

			return encoded.ToString();

		}

		/**
         * Computes RFC 2104-compliant HMAC signature.
         */

		private String Sign( String data, String key, KeyedHashAlgorithm algorithm )
		{
			Encoding encoding = new UTF8Encoding();
			algorithm.Key = encoding.GetBytes( key );
			return Convert.ToBase64String( algorithm.ComputeHash(
				encoding.GetBytes( data.ToCharArray() ) ) );
		}


		/**
         * Formats date as ISO 8601 timestamp
         */

		private String GetFormattedTimestamp()
		{
			DateTime dateTime = DateTime.Now;
			return new DateTime( dateTime.Year, dateTime.Month, dateTime.Day,
				dateTime.Hour, dateTime.Minute, dateTime.Second,
				dateTime.Millisecond
				, DateTimeKind.Local
				).ToUniversalTime().ToString( "yyyy-MM-dd\\THH:mm:ss.fff\\Z",
					CultureInfo.InvariantCulture );
		}

		/**
         * Formats date as ISO 8601 timestamp
         */

		private String GetFormattedTimestamp( DateTime dateTime )
		{
			var date = dateTime.Kind != DateTimeKind.Local ? dateTime :
				new DateTime( dateTime.Year, dateTime.Month, dateTime.Day,
					dateTime.Hour, dateTime.Minute, dateTime.Second,
					dateTime.Millisecond
					, DateTimeKind.Local
					).ToUniversalTime();
			return date.ToString( "yyyy-MM-dd\\THH:mm:ss.fff\\Z", CultureInfo.InvariantCulture );
		}


		/**
         * Convert ListOrdersByNextTokenRequest to name value pairs
         */

		private IDictionary< String, String > ConvertListOrdersByNextToken( ListOrdersByNextTokenRequest request )
		{
			IDictionary< String, String > parameters = new Dictionary< String, String >();
			parameters.Add( "Action", "ListOrdersByNextToken" );
			if( request.IsSetSellerId() )
			{
				parameters.Add( "SellerId", request.SellerId );
			}
			if( request.IsSetMWSAuthToken() )
			{
				parameters.Add( "MWSAuthToken", request.MWSAuthToken );
			}
			if( request.IsSetNextToken() )
			{
				parameters.Add( "NextToken", request.NextToken );
			}

			return parameters;
		}


		/**
         * Convert ListOrderItemsByNextTokenRequest to name value pairs
         */

		private IDictionary< String, String > ConvertListOrderItemsByNextToken( ListOrderItemsByNextTokenRequest request )
		{

			IDictionary< String, String > parameters = new Dictionary< String, String >();
			parameters.Add( "Action", "ListOrderItemsByNextToken" );
			if( request.IsSetSellerId() )
			{
				parameters.Add( "SellerId", request.SellerId );
			}
			if( request.IsSetMWSAuthToken() )
			{
				parameters.Add( "MWSAuthToken", request.MWSAuthToken );
			}
			if( request.IsSetNextToken() )
			{
				parameters.Add( "NextToken", request.NextToken );
			}

			return parameters;
		}


		/**
         * Convert GetOrderRequest to name value pairs
         */

		private IDictionary< String, String > ConvertGetOrder( GetOrderRequest request )
		{
			IDictionary< String, String > parameters = new Dictionary< String, String >();
			parameters.Add( "Action", "GetOrder" );
			if( request.IsSetSellerId() )
			{
				parameters.Add( "SellerId", request.SellerId );
			}
			if( request.IsSetMWSAuthToken() )
			{
				parameters.Add( "MWSAuthToken", request.MWSAuthToken );
			}
			if( request.IsSetAmazonOrderId() )
			{
				var getOrderRequestAmazonOrderId = request.AmazonOrderId;
				var amazonOrderIdIdList = getOrderRequestAmazonOrderId;
				var amazonOrderIdIdListIndex = 1;
				foreach( var amazonOrderIdId in amazonOrderIdIdList )
				{
					parameters.Add( "AmazonOrderId" + "." + "Id" + "." + amazonOrderIdIdListIndex, amazonOrderIdId );
					amazonOrderIdIdListIndex++;
				}
			}

			return parameters;
		}


		/**
         * Convert ListOrderItemsRequest to name value pairs
         */

		private IDictionary< String, String > ConvertListOrderItems( ListOrderItemsRequest request )
		{

			IDictionary< String, String > parameters = new Dictionary< String, String >();
			parameters.Add( "Action", "ListOrderItems" );
			if( request.IsSetSellerId() )
			{
				parameters.Add( "SellerId", request.SellerId );
			}
			if( request.IsSetMWSAuthToken() )
			{
				parameters.Add( "MWSAuthToken", request.MWSAuthToken );
			}
			if( request.IsSetAmazonOrderId() )
			{
				parameters.Add( "AmazonOrderId", request.AmazonOrderId );
			}

			return parameters;
		}


		/**
         * Convert ListOrdersRequest to name value pairs
         */

		private IDictionary< String, String > ConvertListOrders( ListOrdersRequest request )
		{

			IDictionary< String, String > parameters = new Dictionary< String, String >();
			parameters.Add( "Action", "ListOrders" );
			if( request.IsSetSellerId() )
			{
				parameters.Add( "SellerId", request.SellerId );
			}
			if( request.IsSetMWSAuthToken() )
			{
				parameters.Add( "MWSAuthToken", request.MWSAuthToken );
			}
			if( request.IsSetCreatedAfter() )
			{
				parameters.Add( "CreatedAfter", this.GetFormattedTimestamp( request.CreatedAfter ) );
			}
			if( request.IsSetCreatedBefore() )
			{
				parameters.Add( "CreatedBefore", this.GetFormattedTimestamp( request.CreatedBefore ) );
			}
			if( request.IsSetLastUpdatedAfter() )
			{
				parameters.Add( "LastUpdatedAfter", this.GetFormattedTimestamp( request.LastUpdatedAfter ) );
			}
			if( request.IsSetLastUpdatedBefore() )
			{
				parameters.Add( "LastUpdatedBefore", this.GetFormattedTimestamp( request.LastUpdatedBefore ) );
			}
			if( request.IsSetOrderStatus() )
			{
				var listOrdersRequestOrderStatus = request.OrderStatus;
				var orderStatusStatusList = listOrdersRequestOrderStatus;
				var orderStatusStatusListIndex = 1;
				foreach( var orderStatusStatus in orderStatusStatusList )
				{
					parameters.Add( "OrderStatus" + "." + "Status" + "." + orderStatusStatusListIndex, orderStatusStatus + "" );
					orderStatusStatusListIndex++;
				}
			}
			if( request.IsSetMarketplaceId() )
			{
				var listOrdersRequestMarketplaceId = request.MarketplaceId;
				var marketplaceIdIdList = listOrdersRequestMarketplaceId;
				var marketplaceIdIdListIndex = 1;
				foreach( var marketplaceIdId in marketplaceIdIdList )
				{
					parameters.Add( "MarketplaceId" + "." + "Id" + "." + marketplaceIdIdListIndex, marketplaceIdId );
					marketplaceIdIdListIndex++;
				}
			}
			if( request.IsSetFulfillmentChannel() )
			{
				var listOrdersRequestFulfillmentChannel = request.FulfillmentChannel;
				var fulfillmentChannelChannelList = listOrdersRequestFulfillmentChannel;
				var fulfillmentChannelChannelListIndex = 1;
				foreach( var fulfillmentChannelChannel in fulfillmentChannelChannelList )
				{
					parameters.Add( "FulfillmentChannel" + "." + "Channel" + "." + fulfillmentChannelChannelListIndex, fulfillmentChannelChannel + "" );
					fulfillmentChannelChannelListIndex++;
				}
			}
			if( request.IsSetPaymentMethod() )
			{
				var listOrdersRequestPaymentMethod = request.PaymentMethod;
				var paymentMethodMethodList = listOrdersRequestPaymentMethod;
				var paymentMethodMethodListIndex = 1;
				foreach( var paymentMethodMethod in paymentMethodMethodList )
				{
					parameters.Add( "PaymentMethod" + "." + "Method" + "." + paymentMethodMethodListIndex, paymentMethodMethod + "" );
					paymentMethodMethodListIndex++;
				}
			}
			if( request.IsSetBuyerEmail() )
			{
				parameters.Add( "BuyerEmail", request.BuyerEmail );
			}
			if( request.IsSetSellerOrderId() )
			{
				parameters.Add( "SellerOrderId", request.SellerOrderId );
			}
			if( request.IsSetMaxResultsPerPage() )
			{
				parameters.Add( "MaxResultsPerPage", request.MaxResultsPerPage + "" );
			}
			if( request.IsSetTFMShipmentStatus() )
			{
				var listOrdersRequestTFMShipmentStatus = request.TFMShipmentStatus;
				var TFMShipmentStatusStatusList = listOrdersRequestTFMShipmentStatus;
				var TFMShipmentStatusStatusListIndex = 1;
				foreach( var TFMShipmentStatusStatus in TFMShipmentStatusStatusList )
				{
					parameters.Add( "TFMShipmentStatus" + "." + "Status" + "." + TFMShipmentStatusStatusListIndex, TFMShipmentStatusStatus );
					TFMShipmentStatusStatusListIndex++;
				}
			}

			return parameters;
		}


		/**
         * Convert GetServiceStatusRequest to name value pairs
         */

		private IDictionary< String, String > ConvertGetServiceStatus( GetServiceStatusRequest request )
		{

			IDictionary< String, String > parameters = new Dictionary< String, String >();
			parameters.Add( "Action", "GetServiceStatus" );
			if( request.IsSetSellerId() )
			{
				parameters.Add( "SellerId", request.SellerId );
			}
			if( request.IsSetMWSAuthToken() )
			{
				parameters.Add( "MWSAuthToken", request.MWSAuthToken );
			}

			return parameters;
		}
	}
}

[ Serializable ]
public class AmazonOrdersException: Exception
{
	//
	// For guidelines regarding the creation of new exception types, see
	//    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
	// and
	//    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
	//

	public AmazonOrdersException()
	{
	}

	public AmazonOrdersException( string message ): base( message )
	{
	}

	public AmazonOrdersException( string message, Exception inner ): base( message, inner )
	{
	}

	protected AmazonOrdersException(
		SerializationInfo info,
		StreamingContext context ): base( info, context )
	{
	}
}