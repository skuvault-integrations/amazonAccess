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
using System.IO;
using System.Reflection;
using AmazonAccess.Services.Common;
using AmazonAccess.Services.FeedsReports.Model;

namespace AmazonAccess.Services.FeedsReports.Mock
{
	/// <summary>
	/// MarketplaceWebServiceMock is the implementation of MarketplaceWebService based
	/// on the pre-populated set of XML files that serve local data. It simulates 
	/// responses from Marketplace Web Service service.
	/// </summary>
	/// <remarks>
	/// Use this to test your application without making a call to 
	/// Marketplace Web Service 
	/// 
	/// Note, current Mock Service implementation does not valiadate requests
	/// </remarks>
	public class MarketplaceWebServiceMock: IFeedsReportsServiceClient
	{
		// Public API ------------------------------------------------------------//

		/// <summary>
		/// Get Report 
		/// </summary>
		/// <param name="request">Get Report  request</param>
		/// <returns>Get Report  Response from the service</returns>
		/// <remarks>
		/// The GetReport operation returns the contents of a report. Reports can potentially be
		/// very large (>100MB) which is why we only return one report at a time, and in a
		/// streaming fashion.
		///   
		/// </remarks>
		public GetReportResponse GetReport( GetReportRequest request, string marker )
		{
			return this.newResponse< GetReportResponse >();
		}

		/// <summary>
		/// Get Report Schedule Count 
		/// </summary>
		/// <param name="request">Get Report Schedule Count  request</param>
		/// <returns>Get Report Schedule Count  Response from the service</returns>
		/// <remarks>
		/// returns the number of report schedules
		///   
		/// </remarks>
		public GetReportScheduleCountResponse GetReportScheduleCount( GetReportScheduleCountRequest request, string marker )
		{
			return this.newResponse< GetReportScheduleCountResponse >();
		}

		/// <summary>
		/// Get Report Request List By Next Token 
		/// </summary>
		/// <param name="request">Get Report Request List By Next Token  request</param>
		/// <returns>Get Report Request List By Next Token  Response from the service</returns>
		/// <remarks>
		/// retrieve the next batch of list items and if there are more items to retrieve
		///   
		/// </remarks>
		public GetReportRequestListByNextTokenResponse GetReportRequestListByNextToken( GetReportRequestListByNextTokenRequest request, string marker )
		{
			return this.newResponse< GetReportRequestListByNextTokenResponse >();
		}

		/// <summary>
		/// Update Report Acknowledgements 
		/// </summary>
		/// <param name="request">Update Report Acknowledgements  request</param>
		/// <returns>Update Report Acknowledgements  Response from the service</returns>
		/// <remarks>
		/// The UpdateReportAcknowledgements operation updates the acknowledged status of one or more reports.
		///   
		/// </remarks>
		public UpdateReportAcknowledgementsResponse UpdateReportAcknowledgements( UpdateReportAcknowledgementsRequest request, string marker )
		{
			return this.newResponse< UpdateReportAcknowledgementsResponse >();
		}

		/// <summary>
		/// Submit Feed 
		/// </summary>
		/// <param name="request">Submit Feed  request</param>
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
			return this.newResponse< SubmitFeedResponse >();
		}

		/// <summary>
		/// Get Report Count 
		/// </summary>
		/// <param name="request">Get Report Count  request</param>
		/// <returns>Get Report Count  Response from the service</returns>
		/// <remarks>
		/// returns a count of reports matching your criteria;
		/// by default, the number of reports generated in the last 90 days,
		/// regardless of acknowledgement status
		///   
		/// </remarks>
		public GetReportCountResponse GetReportCount( GetReportCountRequest request, string marker )
		{
			return this.newResponse< GetReportCountResponse >();
		}

		/// <summary>
		/// Get Feed Submission List By Next Token 
		/// </summary>
		/// <param name="request">Get Feed Submission List By Next Token  request</param>
		/// <returns>Get Feed Submission List By Next Token  Response from the service</returns>
		/// <remarks>
		/// retrieve the next batch of list items and if there are more items to retrieve
		///   
		/// </remarks>
		public GetFeedSubmissionListByNextTokenResponse GetFeedSubmissionListByNextToken( GetFeedSubmissionListByNextTokenRequest request, string marker )
		{
			return this.newResponse< GetFeedSubmissionListByNextTokenResponse >();
		}

		/// <summary>
		/// Cancel Feed Submissions 
		/// </summary>
		/// <param name="request">Cancel Feed Submissions  request</param>
		/// <returns>Cancel Feed Submissions  Response from the service</returns>
		/// <remarks>
		/// cancels feed submissions - by default all of the submissions of the
		/// last 30 days that have not started processing
		///   
		/// </remarks>
		public CancelFeedSubmissionsResponse CancelFeedSubmissions( CancelFeedSubmissionsRequest request, string marker )
		{
			return this.newResponse< CancelFeedSubmissionsResponse >();
		}

		/// <summary>
		/// Request Report 
		/// </summary>
		/// <param name="request">Request Report  request</param>
		/// <returns>Request Report  Response from the service</returns>
		/// <remarks>
		/// requests the generation of a report
		///   
		/// </remarks>
		public RequestReportResponse RequestReport( RequestReportRequest request, string marker )
		{
			return this.newResponse< RequestReportResponse >();
		}

		/// <summary>
		/// Get Feed Submission Count 
		/// </summary>
		/// <param name="request">Get Feed Submission Count  request</param>
		/// <returns>Get Feed Submission Count  Response from the service</returns>
		/// <remarks>
		/// returns the number of feeds matching all of the specified criteria
		///   
		/// </remarks>
		public GetFeedSubmissionCountResponse GetFeedSubmissionCount( GetFeedSubmissionCountRequest request, string marker )
		{
			return this.newResponse< GetFeedSubmissionCountResponse >();
		}

		/// <summary>
		/// Cancel Report Requests 
		/// </summary>
		/// <param name="request">Cancel Report Requests  request</param>
		/// <returns>Cancel Report Requests  Response from the service</returns>
		/// <remarks>
		/// cancels report requests that have not yet started processing,
		/// by default all those within the last 90 days
		///   
		/// </remarks>
		public CancelReportRequestsResponse CancelReportRequests( CancelReportRequestsRequest request, string marker )
		{
			return this.newResponse< CancelReportRequestsResponse >();
		}

		/// <summary>
		/// Get Report List 
		/// </summary>
		/// <param name="request">Get Report List  request</param>
		/// <returns>Get Report List  Response from the service</returns>
		/// <remarks>
		/// returns a list of reports; by default the most recent ten reports,
		/// regardless of their acknowledgement status
		///   
		/// </remarks>
		public GetReportListResponse GetReportList( GetReportListRequest request, string marker )
		{
			return this.newResponse< GetReportListResponse >();
		}

		/// <summary>
		/// Get Feed Submission Result 
		/// </summary>
		/// <param name="request">Get Feed Submission Result  request</param>
		/// <returns>Get Feed Submission Result  Response from the service</returns>
		/// <remarks>
		/// retrieves the feed processing report
		///   
		/// </remarks>
		public GetFeedSubmissionResultResponse GetFeedSubmissionResult( GetFeedSubmissionResultRequest request, string marker )
		{
			return this.newResponse< GetFeedSubmissionResultResponse >();
		}

		/// <summary>
		/// Get Feed Submission List 
		/// </summary>
		/// <param name="request">Get Feed Submission List  request</param>
		/// <returns>Get Feed Submission List  Response from the service</returns>
		/// <remarks>
		/// returns a list of feed submission identifiers and their associated metadata
		///   
		/// </remarks>
		public GetFeedSubmissionListResponse GetFeedSubmissionList( GetFeedSubmissionListRequest request, string marker )
		{
			return this.newResponse< GetFeedSubmissionListResponse >();
		}

		/// <summary>
		/// Get Report Request List 
		/// </summary>
		/// <param name="request">Get Report Request List  request</param>
		/// <returns>Get Report Request List  Response from the service</returns>
		/// <remarks>
		/// returns a list of report requests ids and their associated metadata
		///   
		/// </remarks>
		public GetReportRequestListResponse GetReportRequestList( GetReportRequestListRequest request, string marker )
		{
			return this.newResponse< GetReportRequestListResponse >();
		}

		/// <summary>
		/// Get Report Schedule List By Next Token 
		/// </summary>
		/// <param name="request">Get Report Schedule List By Next Token  request</param>
		/// <returns>Get Report Schedule List By Next Token  Response from the service</returns>
		/// <remarks>
		/// retrieve the next batch of list items and if there are more items to retrieve
		///   
		/// </remarks>
		public GetReportScheduleListByNextTokenResponse GetReportScheduleListByNextToken( GetReportScheduleListByNextTokenRequest request, string marker )
		{
			return this.newResponse< GetReportScheduleListByNextTokenResponse >();
		}

		/// <summary>
		/// Get Report List By Next Token 
		/// </summary>
		/// <param name="request">Get Report List By Next Token  request</param>
		/// <returns>Get Report List By Next Token  Response from the service</returns>
		/// <remarks>
		/// retrieve the next batch of list items and if there are more items to retrieve
		///   
		/// </remarks>
		public GetReportListByNextTokenResponse GetReportListByNextToken( GetReportListByNextTokenRequest request, string marker )
		{
			return this.newResponse< GetReportListByNextTokenResponse >();
		}

		/// <summary>
		/// Manage Report Schedule 
		/// </summary>
		/// <param name="request">Manage Report Schedule  request</param>
		/// <returns>Manage Report Schedule  Response from the service</returns>
		/// <remarks>
		/// Creates, updates, or deletes a report schedule
		/// for a given report type, such as order reports in particular.
		///   
		/// </remarks>
		public ManageReportScheduleResponse ManageReportSchedule( ManageReportScheduleRequest request, string marker )
		{
			return this.newResponse< ManageReportScheduleResponse >();
		}

		/// <summary>
		/// Get Report Request Count 
		/// </summary>
		/// <param name="request">Get Report Request Count  request</param>
		/// <returns>Get Report Request Count  Response from the service</returns>
		/// <remarks>
		/// returns a count of report requests; by default all the report
		/// requests in the last 90 days
		///   
		/// </remarks>
		public GetReportRequestCountResponse GetReportRequestCount( GetReportRequestCountRequest request, string marker )
		{
			return this.newResponse< GetReportRequestCountResponse >();
		}

		/// <summary>
		/// Get Report Schedule List 
		/// </summary>
		/// <param name="request">Get Report Schedule List  request</param>
		/// <returns>Get Report Schedule List  Response from the service</returns>
		/// <remarks>
		/// returns the list of report schedules
		///   
		/// </remarks>
		public GetReportScheduleListResponse GetReportScheduleList( GetReportScheduleListRequest request, string marker )
		{
			return this.newResponse< GetReportScheduleListResponse >();
		}

		private T newResponse< T >() where T : IMwsResponse
		{
			Stream xmlIn = null;
			try
			{
				xmlIn = Assembly.GetAssembly( this.GetType() ).GetManifestResourceStream( typeof( T ).FullName + ".xml" );
				StreamReader xmlInReader = new StreamReader( xmlIn );
				string xmlStr = xmlInReader.ReadToEnd();

				MwsXmlReader reader = new MwsXmlReader( xmlStr );
				T obj = ( T )Activator.CreateInstance( typeof( T ) );
				obj.ReadFragmentFrom( reader );
				obj.ResponseHeaderMetadata = new MwsResponseHeaderMetadata( "mockRequestId", "A,B,C", DateTime.UtcNow );
				return obj;
			}
			catch( Exception e )
			{
				throw MwsUtil.Wrap( e );
			}
			finally
			{
				if( xmlIn != null )
					xmlIn.Close();
			}
		}
	}
}