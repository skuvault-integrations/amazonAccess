using System;
using System.Xml.Serialization;

namespace AmazonAccess.Services.FeedsReports.Model.InventoryFeed
{
	[ Serializable ]
	[ XmlRoot( ElementName = "AmazonEnvelope" ) ]
	public class InventoryFeedMFN
	{
		[ XmlElement( Order = 1 ) ]
		public Header Header{ get; set; }

		[ XmlElement( Order = 2 ) ]
		public MessageType MessageType{ get; set; }

		[ XmlElement( Order = 3 ) ]
		public MessageMFN[] Message;
	}

	[ Serializable ]
	public class MessageMFN
	{
		[ XmlElement( ElementName = "MessageID" ) ]
		public int MessageId{ get; set; }

		[ XmlElement ]
		public OperationType OperationType{ get; set; }

		[ XmlElement ]
		public InventoryRemoteFulfillmentMFN Inventory{ get; set; }
	}

	[ Serializable ]
	public class InventoryRemoteFulfillmentMFN : Inventory
	{
		[ XmlElement ]
		public SwitchFulfillmentToEnum SwitchFulfillmentTo = SwitchFulfillmentToEnum.MFN;
	}

	public static class InventoryExtensions
	{
		public static InventoryRemoteFulfillmentMFN ToInventoryRemoteFulfillmentMFN( this Inventory inventory )
		{
			return new InventoryRemoteFulfillmentMFN
			{
				Sku = inventory.Sku,
				Quantity = inventory.Quantity,
				FulfillmentLatency = inventory.FulfillmentLatency
			};
		}
	}

	public enum SwitchFulfillmentToEnum
	{
		MFN,
		AFN
	}
}