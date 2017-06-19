/*******************************************************************************
 * Copyright 2009-2016 Amazon Services. All Rights Reserved.
 * Licensed under the Apache License, Version 2.0 (the "License"); 
 *
 * You may not use this file except in compliance with the License. 
 * You may obtain a copy of the License at: http://aws.amazon.com/apache2.0
 * This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
 * CONDITIONS OF ANY KIND, either express or implied. See the License for the 
 * specific language governing permissions and limitations under the License.
 *******************************************************************************
 * FBA Inbound Service MWS
 * API Version: 2010-10-01
 * Library Version: 2016-10-05
 * Generated: Wed Oct 05 06:15:39 PDT 2016
 */

using System;
using AmazonAccess.Services.Common;
using AmazonAccess.Services.FbaInbound.Model;
using AmazonAccess.Services.FBAInbound.Model;

namespace AmazonAccess.Services.FBAInbound
{
	/// <summary>
	/// FBAInboundServiceMWSClient is an implementation of FBAInboundServiceMWS
	/// </summary>
	public class FbaInboundServiceClient: IFbaInboundServiceClient
	{
		private readonly MwsConnection connection;

		/// <summary>
		/// Create client.
		/// </summary>
		/// <param name="accessKey">Access Key</param>  
		/// <param name="secretKey">Secret Key</param>
		/// <param name="serviceUrl"></param>
		public FbaInboundServiceClient(
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

		public FbaInboundServiceClient( MwsConnection mwsConnection )
		{
			this.connection = mwsConnection;
		}

		public ConfirmPreorderResponse ConfirmPreorder( ConfirmPreorderRequest request, string marker )
		{
			return this.connection.Call( new Request< ConfirmPreorderResponse >( "ConfirmPreorder" ), request, marker );
		}

		public ConfirmTransportRequestResponse ConfirmTransportRequest( ConfirmTransportInputRequest request, string marker )
		{
			return this.connection.Call( new Request< ConfirmTransportRequestResponse >( "ConfirmTransportRequest" ), request, marker );
		}

		public CreateInboundShipmentResponse CreateInboundShipment( CreateInboundShipmentRequest request, string marker )
		{
			return this.connection.Call( new Request< CreateInboundShipmentResponse >( "CreateInboundShipment" ), request, marker );
		}

		public CreateInboundShipmentPlanResponse CreateInboundShipmentPlan( CreateInboundShipmentPlanRequest request, string marker )
		{
			return this.connection.Call( new Request< CreateInboundShipmentPlanResponse >( "CreateInboundShipmentPlan" ), request, marker );
		}

		public EstimateTransportRequestResponse EstimateTransportRequest( EstimateTransportInputRequest request, string marker )
		{
			return this.connection.Call( new Request< EstimateTransportRequestResponse >( "EstimateTransportRequest" ), request, marker );
		}

		public GetBillOfLadingResponse GetBillOfLading( GetBillOfLadingRequest request, string marker )
		{
			return this.connection.Call( new Request< GetBillOfLadingResponse >( "GetBillOfLading" ), request, marker );
		}

		//public GetInboundGuidanceForASINResponse GetInboundGuidanceForASIN( GetInboundGuidanceForASINRequest request, string marker )
		//{
		//	return this.connection.Call( new Request< GetInboundGuidanceForASINResponse >( "GetInboundGuidanceForASIN" ), request, marker );
		//}

		public GetInboundGuidanceForSKUResponse GetInboundGuidanceForSKU( GetInboundGuidanceForSKURequest request, string marker )
		{
			return this.connection.Call( new Request< GetInboundGuidanceForSKUResponse >( "GetInboundGuidanceForSKU" ), request, marker );
		}

		public GetPackageLabelsResponse GetPackageLabels( GetPackageLabelsRequest request, string marker )
		{
			return this.connection.Call( new Request< GetPackageLabelsResponse >( "GetPackageLabels" ), request, marker );
		}

		public GetPalletLabelsResponse GetPalletLabels( GetPalletLabelsRequest request, string marker )
		{
			return this.connection.Call( new Request< GetPalletLabelsResponse >( "GetPalletLabels" ), request, marker );
		}

		public GetPreorderInfoResponse GetPreorderInfo( GetPreorderInfoRequest request, string marker )
		{
			return this.connection.Call( new Request< GetPreorderInfoResponse >( "GetPreorderInfo" ), request, marker );
		}

		public GetPrepInstructionsForASINResponse GetPrepInstructionsForASIN( GetPrepInstructionsForASINRequest request, string marker )
		{
			return this.connection.Call( new Request< GetPrepInstructionsForASINResponse >( "GetPrepInstructionsForASIN" ), request, marker );
		}

		public GetPrepInstructionsForSKUResponse GetPrepInstructionsForSKU( GetPrepInstructionsForSKURequest request, string marker )
		{
			return this.connection.Call( new Request< GetPrepInstructionsForSKUResponse >( "GetPrepInstructionsForSKU" ), request, marker );
		}

		public GetServiceStatusResponse GetServiceStatus( GetServiceStatusRequest request, string marker )
		{
			return this.connection.Call( new Request< GetServiceStatusResponse >( "GetServiceStatus" ), request, marker );
		}

		public GetTransportContentResponse GetTransportContent( GetTransportContentRequest request, string marker )
		{
			return this.connection.Call( new Request< GetTransportContentResponse >( "GetTransportContent" ), request, marker );
		}

		public GetUniquePackageLabelsResponse GetUniquePackageLabels( GetUniquePackageLabelsRequest request, string marker )
		{
			return this.connection.Call( new Request< GetUniquePackageLabelsResponse >( "GetUniquePackageLabels" ), request, marker );
		}

		public ListInboundShipmentItemsResponse ListInboundShipmentItems( ListInboundShipmentItemsRequest request, string marker )
		{
			return this.connection.Call( new Request< ListInboundShipmentItemsResponse >( "ListInboundShipmentItems" ), request, marker );
		}

		public ListInboundShipmentItemsByNextTokenResponse ListInboundShipmentItemsByNextToken( ListInboundShipmentItemsByNextTokenRequest request, string marker )
		{
			return this.connection.Call( new Request< ListInboundShipmentItemsByNextTokenResponse >( "ListInboundShipmentItemsByNextToken" ), request, marker );
		}

		public ListInboundShipmentsResponse ListInboundShipments( ListInboundShipmentsRequest request, string marker )
		{
			return this.connection.Call( new Request< ListInboundShipmentsResponse >( "ListInboundShipments" ), request, marker );
		}

		public ListInboundShipmentsByNextTokenResponse ListInboundShipmentsByNextToken( ListInboundShipmentsByNextTokenRequest request, string marker )
		{
			return this.connection.Call( new Request< ListInboundShipmentsByNextTokenResponse >( "ListInboundShipmentsByNextToken" ), request, marker );
		}

		public PutTransportContentResponse PutTransportContent( PutTransportContentRequest request, string marker )
		{
			return this.connection.Call( new Request< PutTransportContentResponse >( "PutTransportContent" ), request, marker );
		}

		public UpdateInboundShipmentResponse UpdateInboundShipment( UpdateInboundShipmentRequest request, string marker )
		{
			return this.connection.Call( new Request< UpdateInboundShipmentResponse >( "UpdateInboundShipment" ), request, marker );
		}

		public VoidTransportRequestResponse VoidTransportRequest( VoidTransportInputRequest request, string marker )
		{
			return this.connection.Call( new Request< VoidTransportRequestResponse >( "VoidTransportRequest" ), request, marker );
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
				return new FBAInboundServiceMWSException( cause );
			}

			public void SetResponseHeaderMetadata( IMwsObject response, MwsResponseHeaderMetadata rhmd )
			{
				( ( IMwsResponse )response ).ResponseHeaderMetadata = rhmd;
			}
		}
	}
}
