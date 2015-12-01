using System;
using System.Xml.Serialization;

namespace AmazonAccess.Services.FeedsReports.Model.AmazonEnvelope.FeedSubmissionResult
{
	[ Serializable ]
	[ XmlRoot( ElementName = "AmazonEnvelope" ) ]
	public class FeedSubmissionResult
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
		public ProcessingReport ProcessingReport{ get; set; }
	}

	[ Serializable ]
	public class ProcessingReport
	{
		[ XmlElement ]
		public ProcessingReportType ProcessingReportType{ get; set; }

		[ XmlElement( ElementName = "DocumentTransactionID" ) ]
		public string DocumentTransactionId{ get; set; }

		[ XmlElement ]
		public StatusCode StatusCode{ get; set; }

		[ XmlElement ]
		public ProcessingSummary ProcessingSummary{ get; set; }

		[ XmlElement ]
		public Result[] Result;

		[ XmlElement ]
		public Summary Summary{ get; set; }
	}

	[ Serializable ]
	public class Summary
	{
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

	public enum MessageType
	{
		Unknown,
		Inventory,
		ProcessingReport
	}

	public enum ProcessingReportType
	{
		Unknown,
		Inventory
	}

	public enum StatusCode
	{
		Unknown,
		Complete
	}
}