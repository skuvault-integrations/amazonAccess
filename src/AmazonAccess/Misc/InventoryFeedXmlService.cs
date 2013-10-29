using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using AmazonAccess.Services.FbaInventoryServiceMws.Model;
using AmazonAccess.Services.MarketplaceWebServiceFeeds.Model;
using CuttingEdge.Conditions;

namespace AmazonAccess.Misc
{
	public class InventoryFeedXmlService
	{
		private readonly List< AmazonInventoryItem > _inventoryItems;
		public readonly AmazonEnvelope _document;

		public InventoryFeedXmlService( IEnumerable< AmazonInventoryItem > inventoryItems, string sellerId )
		{
			Condition.Requires( inventoryItems, "inventoryItems" ).IsNotEmpty();
			Condition.Requires( sellerId, "sellerId" ).IsNotNull();

			this._inventoryItems = inventoryItems.ToList();
			this._document = this.CreateDocument( sellerId );
		}

		public Stream GetDocumentStream()
		{
			var stream = new MemoryStream();
			var ser = new XmlSerializer( typeof( AmazonEnvelope ) );

			ser.Serialize( stream, _document );
			stream.Position = 0;

			return stream;
		}

		private AmazonEnvelope CreateDocument( string sellerId )
		{
			var document = new AmazonEnvelope
				{
					Header = new Header { MerchantIdentifier = sellerId, DocumentVersion = "1.01" },
					MessageType = MessageType.Inventory,
					Message = new Message[ this._inventoryItems.Count() ]
				};

			this.CreateMessageNodes( document );

			return document;
		}

		private void CreateMessageNodes( AmazonEnvelope document )
		{
			for( var i = 0; i < this._inventoryItems.Count(); i++ )
			{
				var message = new Message
					{
						OperationType = OperationType.Update,
						MessageId = i + 1,
						Inventory = new Inventory
							{
								FulfillmentLatency = 1,
								Quantity = this._inventoryItems[ i ].Quantity,
								Sku = this._inventoryItems[ i ].Sku
							}
					};
				document.Message[ i ] = message;
			}
		}
	}
}