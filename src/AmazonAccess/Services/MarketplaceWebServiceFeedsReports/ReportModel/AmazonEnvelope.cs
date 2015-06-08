using System;
using System.Xml.Serialization;

namespace AmazonAccess.Services.MarketplaceWebServiceFeedsReports.ReportModel
{
	[ Serializable ]
	[ XmlRoot ]
	public class AmazonEnvelope
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

		[ XmlElement ]
		public ProcessingReport ProcessingReport{ get; set; }
	}

	[ Serializable ]
	public class Inventory
	{
		[ XmlElement( ElementName = "SKU" ) ]
		public string Sku{ get; set; }

		[ XmlElement ]
		public int Quantity{ get; set; }

		[ XmlElement ]
		public int FulfillmentLatency{ get; set; }
	}

	[ Serializable ]
	public class ProcessingReport
	{
		[ XmlElement( ElementName = "DocumentTransactionID" ) ]
		public string DocumentTransactionId{ get; set; }

		[ XmlElement ]
		public StatusCode StatusCode{ get; set; }

		[ XmlElement ]
		public ProcessingSummary ProcessingSummary{ get; set; }

		[ XmlElement ]
		public Result[] Result;
	}

	[ Serializable ]
	public class ProcessingSummary
	{
		[ XmlElement ]
		public int MessagesProcessed{ get; set; }

		[ XmlElement ]
		public int MessagesSuccessful{ get; set; }

		[ XmlElement ]
		public int MessagesWithError{ get; set; }

		[ XmlElement ]
		public int MessagesWithWarning{ get; set; }
	}

	[ Serializable ]
	public class Result
	{
		[ XmlElement( ElementName = "MessageID" ) ]
		public int MessageId{ get; set; }

		[ XmlElement ]
		public string ResultCode{ get; set; }

		[ XmlElement ]
		public int ResultMessageCode{ get; set; }

		[ XmlElement ]
		public string ResultDescription{ get; set; }

		[ XmlElement ]
		public AdditionalInfo AdditionalInfo{ get; set; }
	}

	[ Serializable ]
	public class AdditionalInfo
	{
		[ XmlElement( ElementName = "SKU" ) ]
		public string Sku{ get; set; }
	}

	public enum OperationType
	{
		Unknown,
		Update
	}

	public enum MessageType
	{
		Unknown,
		Inventory,
		ProcessingReport
	}

	public enum StatusCode
	{
		Unknown,
		Complete
	}
}