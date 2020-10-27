using System;
using System.Xml.Serialization;
using AmazonAccess.Services.FbaInventory.Model;

namespace AmazonAccess.Services.FeedsReports.Model.InventoryFeed
{
	[ Serializable ]
	[ XmlRoot( ElementName = "AmazonEnvelope" ) ]
	public class InventoryFeed
	{
		[ XmlElement( Order = 1 ) ]
		public Header Header{ get; set; }

		[ XmlElement( Order = 2 ) ]
		public MessageType MessageType{ get; set; }

		[ XmlElement( Order = 3 ) ]
		public Message[] Message;
	}

	[ Serializable ]
	public class Header
	{
		[ XmlElement ]
		public string DocumentVersion{ get; set; }

		[ XmlElement ]
		public string MerchantIdentifier{ get; set; }
	}

	[ Serializable ]
	public class Message
	{
		[ XmlElement( ElementName = "MessageID" ) ]
		public int MessageId{ get; set; }

		[ XmlElement ]
		public OperationType OperationType{ get; set; }

		[ XmlElement ]
		public Inventory Inventory{ get; set; }
	}

	[ Serializable ]
	[ XmlInclude( typeof( InventoryRemoteFulfillmentMFN ) ) ]
	public class Inventory
	{
		[ XmlElement( ElementName = "SKU" ) ]
		public string Sku{ get; set; }

		[ XmlElement ]
		public int Quantity{ get; set; }

		[ XmlElement ]
		public int FulfillmentLatency{ get; set; }
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

	[ Serializable ]
	public class InventoryRemoteFulfillmentMFN : Inventory
	{
		[ XmlElement ]
		public SwitchFulfillmentToEnum SwitchFulfillmentTo = SwitchFulfillmentToEnum.MFN;

		[ XmlElement ]
		public string FulfillmentCenterID = "DEFAULT";
	}

	public enum SwitchFulfillmentToEnum
	{
		MFN,
		AFN
	}

	public enum OperationType
	{
		Unknown,
		Update
	}

	public enum MessageType
	{
		Unknown,
		Inventory
	}
}