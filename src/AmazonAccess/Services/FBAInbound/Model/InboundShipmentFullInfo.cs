using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using AmazonAccess.Services.Common;

namespace AmazonAccess.Services.FBAInbound.Model
{
	public class InboundShipmentFullInfo
	{
		public string ShipmentId{ get; set; }
		public string ShipmentName{ get; set; }
		public Address ShipFromAddress{ get; set; }
		public string DestinationFulfillmentCenterId{ get; set; }
		public string ShipmentStatus{ get; set; }
		public string LabelPrepType{ get; set; }
		public string ConfirmedNeedByDate{ get; set; }
		public string BoxContentsSource{ get; set; }
		public BoxContentsFeeDetails EstimatedBoxContentsFee{ get; set; }
		public List< InboundShipmentItem > InboundShipmentItemList{ get; set; }

		public InboundShipmentFullInfo()
		{
			this.ShipFromAddress = new Address();
			this.EstimatedBoxContentsFee = new BoxContentsFeeDetails();
			this.InboundShipmentItemList = new List< InboundShipmentItem >();
		}

		public InboundShipmentFullInfo( InboundShipmentInfo inboundShipmentInfo )
		{
			this.ShipmentId = inboundShipmentInfo.ShipmentId;
			this.ShipmentName = inboundShipmentInfo.ShipmentName;
			this.ShipFromAddress = inboundShipmentInfo.ShipFromAddress;
			this.DestinationFulfillmentCenterId = inboundShipmentInfo.DestinationFulfillmentCenterId;
			this.ShipmentStatus = inboundShipmentInfo.ShipmentStatus;
			this.LabelPrepType = inboundShipmentInfo.LabelPrepType;
			this.ConfirmedNeedByDate = inboundShipmentInfo.ConfirmedNeedByDate;
			this.BoxContentsSource = inboundShipmentInfo.BoxContentsSource;
			this.EstimatedBoxContentsFee = inboundShipmentInfo.EstimatedBoxContentsFee;
			this.InboundShipmentItemList = new List< InboundShipmentItem >();
		}

		public InboundShipmentFullInfo( InboundShipmentInfo inboundShipmentInfo, List< InboundShipmentItem > inboundShipmentItemList )
		{
			this.ShipmentId = inboundShipmentInfo.ShipmentId;
			this.ShipmentName = inboundShipmentInfo.ShipmentName;
			this.ShipFromAddress = inboundShipmentInfo.ShipFromAddress;
			this.DestinationFulfillmentCenterId = inboundShipmentInfo.DestinationFulfillmentCenterId;
			this.ShipmentStatus = inboundShipmentInfo.ShipmentStatus;
			this.LabelPrepType = inboundShipmentInfo.LabelPrepType;
			this.ConfirmedNeedByDate = inboundShipmentInfo.ConfirmedNeedByDate;
			this.BoxContentsSource = inboundShipmentInfo.BoxContentsSource;
			this.EstimatedBoxContentsFee = inboundShipmentInfo.EstimatedBoxContentsFee;
			this.InboundShipmentItemList = inboundShipmentItemList;
		}
	}
}
