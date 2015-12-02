using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using AmazonAccess.Services.FeedsReports.Model;
using AmazonAccess.Services.FeedsReports.Model.AmazonEnvelope.InventoryFeed;
using CuttingEdge.Conditions;

namespace AmazonAccess.Services.FeedsReports
{
	public class InventoryFeedXmlService
	{
		private readonly List< AmazonInventoryItem > _inventoryItems;
		public readonly InventoryFeed _document;

		public InventoryFeedXmlService( List< AmazonInventoryItem > inventoryItems, string sellerId )
		{
			Condition.Requires( inventoryItems, "inventoryItems" ).IsNotEmpty();
			Condition.Requires( sellerId, "sellerId" ).IsNotNull();

			this._inventoryItems = inventoryItems;
			this._document = this.CreateDocument( sellerId );
		}

		public Stream GetDocumentStream()
		{
			var ser = new XmlSerializer( typeof( InventoryFeed ) );
			var stream = new MemoryStream();
			ser.Serialize( stream, this._document );
			stream.Position = 0;

			return stream;
		}

		public string GetDocumentString()
		{
			using( var stream = this.GetDocumentStream() )
			{
				var streamReader = new StreamReader( stream );
				return streamReader.ReadToEnd();
			}

			//var ser = new XmlSerializer( typeof( InventoryFeed ) );
			//var stringWriter = new StringWriter();
			//ser.Serialize( stringWriter, this._document );
			//var str = stringWriter.ToString();
			//return str;
		}

		private InventoryFeed CreateDocument( string sellerId )
		{
			var document = new InventoryFeed
			{
				Header = new Header { MerchantIdentifier = sellerId, DocumentVersion = "1.01" },
				MessageType = MessageType.Inventory,
				Message = new Message[ this._inventoryItems.Count ]
			};

			this.CreateMessageNodes( document );

			return document;
		}

		private void CreateMessageNodes( InventoryFeed document )
		{
			for( var i = 0; i < this._inventoryItems.Count; i++ )
			{
				var item = this._inventoryItems[ i ];
				var message = new Message
				{
					OperationType = OperationType.Update,
					MessageId = i + 1,
					Inventory = new Inventory
					{
						Quantity = item.Quantity,
						Sku = item.Sku,
						FulfillmentLatency = item.FulfillmentLatency
					}
				};
				document.Message[ i ] = message;
			}
		}
	}
}