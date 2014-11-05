using System;
using System.Xml.Serialization;

namespace AmazonAccess.Services.MarketplaceWebServiceFeeds.Model
{
	[ Serializable ]
	[ XmlRoot ]
	public class AmazonEnvelope
	{
		[ XmlElement( Order = 1 ) ]
		public Header Header { get; set; }

		[ XmlElement( Order = 2 ) ]
		public MessageType MessageType { get; set; }

		[ XmlElement( Order = 3 ) ]
		public Message[] Message;
	}

	[ Serializable ]
	public class Header
	{
		//<DocumentVersion>1.01</DocumentVersion>
		//<MerchantIdentifier>A7I0VA9RRJTE8</MerchantIdentifier>
		[ XmlElement ]
		public string DocumentVersion { get; set; }

		[ XmlElement ]
		public string MerchantIdentifier { get; set; }
	}

	[ Serializable ]
	public class Message
	{
		//<MessageID>2</MessageID>
		//<OperationType>Update</OperationType>
		//<Inventory>
		[ XmlElement( ElementName = "MessageID" ) ]
		public int MessageId { get; set; }

		[ XmlElement ]
		public OperationType OperationType { get; set; }

		[ XmlElement ]
		public Inventory Inventory { get; set; }
	}

	[ Serializable ]
	public class Inventory
	{
		//<SKU>memaAZARAKnewhappyNVWT XL</SKU>
		//<Quantity>8</Quantity>
		//<FulfillmentLatency>1</FulfillmentLatency>
		[ XmlElement( ElementName = "SKU" ) ]
		public string Sku { get; set; }

		[ XmlElement ]
		public int Quantity { get; set; }

		//[ XmlElement ]
		//public int FulfillmentLatency { get; set; }
	}

	public enum OperationType
	{
		Unknown,
		Update,
		PartialUpdate
	}

	public enum MessageType
	{
		Unknown,
		Inventory
	}
}