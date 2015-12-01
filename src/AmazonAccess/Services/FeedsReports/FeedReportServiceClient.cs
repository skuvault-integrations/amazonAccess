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
using AmazonAccess.Services.FeedsReports.Model;

namespace AmazonAccess.Services.FeedsReports
{
	public class FeedReportServiceClient: IFeedReportServiceClient
	{
		private readonly MwsConnection connection;

		/// <summary>
		/// Create client.
		/// </summary>
		/// <param name="accessKey">Access Key</param>  
		/// <param name="secretKey">Secret Key</param>
		/// <param name="serviceUrl"></param>
		public FeedReportServiceClient(
			string accessKey,
			string secretKey,
			string serviceUrl )

		{
			this.connection = new MwsConnection
			{
				AwsAccessKeyId = accessKey,
				AwsSecretKeyId = secretKey,
				ServiceURL = serviceUrl
			};
		}

		public FeedReportServiceClient( MwsConnection mwsConnection )
		{
			this.connection = mwsConnection;
		}

		/// <summary>
		/// Get Report 
		/// </summary>
		/// <param name="request">Get Report  request</param>
		/// <param name="marker"></param>
		/// <returns>Get Report  Response from the service</returns>
		/// <remarks>
		/// The GetReport operation returns the contents of a report. Reports can potentially be
		/// very large (>100MB) which is why we only return one report at a time, and in a
		/// streaming fashion.
		/// 
		/// </remarks>
		public GetReportResponse GetReport( GetReportRequest request, string marker )
		{
			return this.connection.Call( new Request< GetReportResponse >( "GetReport" ), request, marker );
		}

		/// <summary>
		/// Get Report Schedule Count 
		/// </summary>
		/// <param name="request">Get Report Schedule Count  request</param>
		/// <param name="marker"></param>
		/// <returns>Get Report Schedule Count  Response from the service</returns>
		/// <remarks>
		/// returns the number of report schedules
		/// 
		/// </remarks>
		public GetReportScheduleCountResponse GetReportScheduleCount( GetReportScheduleCountRequest request, string marker )
		{
			return this.connection.Call( new Request< GetReportScheduleCountResponse >( "GetReportScheduleCount" ), request, marker );
		}

		/// <summary>
		/// Get Report Request List By Next Token 
		/// </summary>
		/// <param name="request">Get Report Request List By Next Token  request</param>
		/// <param name="marker"></param>
		/// <returns>Get Report Request List By Next Token  Response from the service</returns>
		/// <remarks>
		/// retrieve the next batch of list items and if there are more items to retrieve
		/// 
		/// </remarks>
		public GetReportRequestListByNextTokenResponse GetReportRequestListByNextToken( GetReportRequestListByNextTokenRequest request, string marker )
		{
			return this.connection.Call( new Request< GetReportRequestListByNextTokenResponse >( "GetReportRequestListByNextToken" ), request, marker );
		}

		/// <summary>
		/// Update Report Acknowledgements 
		/// </summary>
		/// <param name="request">Update Report Acknowledgements  request</param>
		/// <param name="marker"></param>
		/// <returns>Update Report Acknowledgements  Response from the service</returns>
		/// <remarks>
		/// The UpdateReportAcknowledgements operation updates the acknowledged status of one or more reports.
		/// 
		/// </remarks>
		public UpdateReportAcknowledgementsResponse UpdateReportAcknowledgements( UpdateReportAcknowledgementsRequest request, string marker )
		{
			return this.connection.Call( new Request< UpdateReportAcknowledgementsResponse >( "UpdateReportAcknowledgements" ), request, marker );
		}

		/// <summary>
		/// Submit Feed 
		/// </summary>
		/// <param name="request">Submit Feed  request</param>
		/// <param name="marker"></param>
		/// <returns>Submit Feed  Response from the service</returns>
		/// <remarks>
		/// Uploads a file for processing together with the necessary
		/// metadata to process the file, such as which type of feed it is.
		/// PurgeAndReplace if true means that your existing e.g. inventory is
		/// wiped out and replace with the contents of this feed - use with
		/// caution (the default is false).
		/// 
		/// </remarks>
		public SubmitFeedResponse SubmitFeed( SubmitFeedRequest request, string marker )
		{
			return this.connection.Call( new Request< SubmitFeedResponse >( "SubmitFeed" ), request, marker );
		}

		/// <summary>
		/// Get Report Count 
		/// </summary>
		/// <param name="request">Get Report Count  request</param>
		/// <param name="marker"></param>
		/// <returns>Get Report Count  Response from the service</returns>
		/// <remarks>
		/// returns a count of reports matching your criteria;
		/// by default, the number of reports generated in the last 90 days,
		/// regardless of acknowledgement status
		/// 
		/// </remarks>
		public GetReportCountResponse GetReportCount( GetReportCountRequest request, string marker )
		{
			return this.connection.Call( new Request< GetReportCountResponse >( "GetReportCount" ), request, marker );
		}

		/// <summary>
		/// Get Feed Submission List By Next Token 
		/// </summary>
		/// <param name="request">Get Feed Submission List By Next Token  request</param>
		/// <param name="marker"></param>
		/// <returns>Get Feed Submission List By Next Token  Response from the service</returns>
		/// <remarks>
		/// retrieve the next batch of list items and if there are more items to retrieve
		/// 
		/// </remarks>
		public GetFeedSubmissionListByNextTokenResponse GetFeedSubmissionListByNextToken( GetFeedSubmissionListByNextTokenRequest request, string marker )
		{
			return this.connection.Call( new Request< GetFeedSubmissionListByNextTokenResponse >( "GetFeedSubmissionListByNextToken" ), request, marker );
		}

		/// <summary>
		/// Cancel Feed Submissions 
		/// </summary>
		/// <param name="request">Cancel Feed Submissions  request</param>
		/// <param name="marker"></param>
		/// <returns>Cancel Feed Submissions  Response from the service</returns>
		/// <remarks>
		/// cancels feed submissions - by default all of the submissions of the
		/// last 30 days that have not started processing
		/// 
		/// </remarks>
		public CancelFeedSubmissionsResponse CancelFeedSubmissions( CancelFeedSubmissionsRequest request, string marker )
		{
			return this.connection.Call( new Request< CancelFeedSubmissionsResponse >( "CancelFeedSubmissions" ), request, marker );
		}

		/// <summary>
		/// Request Report 
		/// </summary>
		/// <param name="request">Request Report  request</param>
		/// <param name="marker"></param>
		/// <returns>Request Report  Response from the service</returns>
		/// <remarks>
		/// requests the generation of a report
		/// 
		/// </remarks>
		public RequestReportResponse RequestReport( RequestReportRequest request, string marker )
		{
			return this.connection.Call( new Request< RequestReportResponse >( "RequestReport" ), request, marker );
		}

		/// <summary>
		/// Get Feed Submission Count 
		/// </summary>
		/// <param name="request">Get Feed Submission Count  request</param>
		/// <param name="marker"></param>
		/// <returns>Get Feed Submission Count  Response from the service</returns>
		/// <remarks>
		/// returns the number of feeds matching all of the specified criteria
		/// 
		/// </remarks>
		public GetFeedSubmissionCountResponse GetFeedSubmissionCount( GetFeedSubmissionCountRequest request, string marker )
		{
			return this.connection.Call( new Request< GetFeedSubmissionCountResponse >( "GetFeedSubmissionCount" ), request, marker );
		}

		/// <summary>
		/// Cancel Report Requests 
		/// </summary>
		/// <param name="request">Cancel Report Requests  request</param>
		/// <param name="marker"></param>
		/// <returns>Cancel Report Requests  Response from the service</returns>
		/// <remarks>
		/// cancels report requests that have not yet started processing,
		/// by default all those within the last 90 days
		/// 
		/// </remarks>
		public CancelReportRequestsResponse CancelReportRequests( CancelReportRequestsRequest request, string marker )
		{
			return this.connection.Call( new Request< CancelReportRequestsResponse >( "CancelReportRequests" ), request, marker );
		}

		/// <summary>
		/// Get Report List 
		/// </summary>
		/// <param name="request">Get Report List  request</param>
		/// <param name="marker"></param>
		/// <returns>Get Report List  Response from the service</returns>
		/// <remarks>
		/// returns a list of reports; by default the most recent ten reports,
		/// regardless of their acknowledgement status
		/// 
		/// </remarks>
		public GetReportListResponse GetReportList( GetReportListRequest request, string marker )
		{
			return this.connection.Call( new Request< GetReportListResponse >( "GetReportList" ), request, marker );
		}

		/// <summary>
		/// Get Feed Submission Result 
		/// </summary>
		/// <param name="request">Get Feed Submission Result  request</param>
		/// <param name="marker"></param>
		/// <returns>Get Feed Submission Result  Response from the service</returns>
		/// <remarks>
		/// retrieves the feed processing report
		/// 
		/// </remarks>
		public GetFeedSubmissionResultResponse GetFeedSubmissionResult( GetFeedSubmissionResultRequest request, string marker )
		{
			return this.connection.Call( new Request< GetFeedSubmissionResultResponse >( "GetFeedSubmissionResult" ), request, marker );
		}

		/// <summary>
		/// Get Feed Submission List 
		/// </summary>
		/// <param name="request">Get Feed Submission List  request</param>
		/// <param name="marker"></param>
		/// <returns>Get Feed Submission List  Response from the service</returns>
		/// <remarks>
		/// returns a list of feed submission identifiers and their associated metadata
		/// 
		/// </remarks>
		public GetFeedSubmissionListResponse GetFeedSubmissionList( GetFeedSubmissionListRequest request, string marker )
		{
			return this.connection.Call( new Request< GetFeedSubmissionListResponse >( "GetFeedSubmissionList" ), request, marker );
		}

		/// <summary>
		/// Get Report Request List 
		/// </summary>
		/// <param name="request">Get Report Request List  request</param>
		/// <param name="marker"></param>
		/// <returns>Get Report Request List  Response from the service</returns>
		/// <remarks>
		/// returns a list of report requests ids and their associated metadata
		/// 
		/// </remarks>
		public GetReportRequestListResponse GetReportRequestList( GetReportRequestListRequest request, string marker )
		{
			return this.connection.Call( new Request< GetReportRequestListResponse >( "GetReportRequestList" ), request, marker );
		}

		/// <summary>
		/// Get Report Schedule List By Next Token 
		/// </summary>
		/// <param name="request">Get Report Schedule List By Next Token  request</param>
		/// <param name="marker"></param>
		/// <returns>Get Report Schedule List By Next Token  Response from the service</returns>
		/// <remarks>
		/// retrieve the next batch of list items and if there are more items to retrieve
		/// 
		/// </remarks>
		public GetReportScheduleListByNextTokenResponse GetReportScheduleListByNextToken( GetReportScheduleListByNextTokenRequest request, string marker )
		{
			return this.connection.Call( new Request< GetReportScheduleListByNextTokenResponse >( "GetReportScheduleListByNextToken" ), request, marker );
		}

		/// <summary>
		/// Get Report List By Next Token 
		/// </summary>
		/// <param name="request">Get Report List By Next Token  request</param>
		/// <param name="marker"></param>
		/// <returns>Get Report List By Next Token  Response from the service</returns>
		/// <remarks>
		/// retrieve the next batch of list items and if there are more items to retrieve
		/// 
		/// </remarks>
		public GetReportListByNextTokenResponse GetReportListByNextToken( GetReportListByNextTokenRequest request, string marker )
		{
			return this.connection.Call( new Request< GetReportListByNextTokenResponse >( "GetReportListByNextToken" ), request, marker );
		}

		/// <summary>
		/// Manage Report Schedule 
		/// </summary>
		/// <param name="request">Manage Report Schedule  request</param>
		/// <param name="marker"></param>
		/// <returns>Manage Report Schedule  Response from the service</returns>
		/// <remarks>
		/// Creates, updates, or deletes a report schedule
		/// for a given report type, such as order reports in particular.
		/// 
		/// </remarks>
		public ManageReportScheduleResponse ManageReportSchedule( ManageReportScheduleRequest request, string marker )
		{
			return this.connection.Call( new Request< ManageReportScheduleResponse >( "ManageReportSchedule" ), request, marker );
		}

		/// <summary>
		/// Get Report Request Count 
		/// </summary>
		/// <param name="request">Get Report Request Count  request</param>
		/// <param name="marker"></param>
		/// <returns>Get Report Request Count  Response from the service</returns>
		/// <remarks>
		/// returns a count of report requests; by default all the report
		/// requests in the last 90 days
		/// 
		/// </remarks>
		public GetReportRequestCountResponse GetReportRequestCount( GetReportRequestCountRequest request, string marker )
		{
			return this.connection.Call( new Request< GetReportRequestCountResponse >( "GetReportRequestCount" ), request, marker );
		}

		/// <summary>
		/// Get Report Schedule List 
		/// </summary>
		/// <param name="request">Get Report Schedule List  request</param>
		/// <param name="marker"></param>
		/// <returns>Get Report Schedule List  Response from the service</returns>
		/// <remarks>
		/// returns the list of report schedules
		/// 
		/// </remarks>
		public GetReportScheduleListResponse GetReportScheduleList( GetReportScheduleListRequest request, string marker )
		{
			return this.connection.Call( new Request< GetReportScheduleListResponse >( "GetReportScheduleList" ), request, marker );
		}

		private class Request< TResponse >: IMwsRequestType< TResponse > where TResponse : IMwsObject
		{
			public Request( string operationName )
			{
				this.OperationName = operationName;
				this.ResponseClass = typeof( TResponse );
			}

			public string OperationName{ get; private set; }
			public Type ResponseClass{ get; private set; }

			public MwsException WrapException( Exception cause )
			{
				return new FeedReportServiceException( cause );
			}

			public void SetResponseHeaderMetadata( IMwsObject response, MwsResponseHeaderMetadata rhmd )
			{
				( ( IMWSResponse )response ).ResponseHeaderMetadata = new ResponseHeaderMetadata( rhmd );
			}
		}
	}
}