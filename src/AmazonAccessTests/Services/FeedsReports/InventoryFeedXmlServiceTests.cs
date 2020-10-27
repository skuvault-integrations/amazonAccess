using System.Collections.Generic;
using AmazonAccess.Services.FeedsReports;
using AmazonAccess.Services.FeedsReports.Model;
using FluentAssertions;
using NUnit.Framework;

namespace AmazonAccessTests.Services.FeedsReports
{
	[ TestFixture ]
	public class InventoryFeedXmlServiceTests
	{
		[ Test ]
		public void WhenInventoryFeedXmlServiceGetDocumentStringIsCalled_ThenReturnsCorrectItemDetails()
		{
			const string sku = "testSku1";
			const int quantity = 123;
			const int fulfillmentLatency = 3;
			var inventoryItems = new List< AmazonInventoryItem >
			{
				new AmazonInventoryItem
				{
					Sku = sku,
					Quantity = quantity,
					FulfillmentLatency = fulfillmentLatency
				}
			};
			const string sellerId = "1234";

			var feedService = new InventoryFeedXmlService( inventoryItems, sellerId, true );
			var result = feedService.GetDocumentString();

			var expectedXML = "<?xml version=\"1.0\"?>\r\n<AmazonEnvelope xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">\r\n  " + 
				$"<Header>\r\n    <DocumentVersion>1.01</DocumentVersion>\r\n    <MerchantIdentifier>{sellerId}</MerchantIdentifier>\r\n  </Header>\r\n  " + 
				"<MessageType>Inventory</MessageType>\r\n  <Message>\r\n    <MessageID>1</MessageID>\r\n    <OperationType>Update</OperationType>\r\n    " + 
				$"<Inventory xsi:type=\"InventoryRemoteFulfillmentMFN\">\r\n      <SKU>{sku}</SKU>\r\n      <Quantity>{quantity}</Quantity>\r\n      <FulfillmentLatency>{fulfillmentLatency}</FulfillmentLatency>\r\n      " + 
				"<SwitchFulfillmentTo>MFN</SwitchFulfillmentTo>\r\n      <FulfillmentCenterID>DEFAULT</FulfillmentCenterID>\r\n    </Inventory>\r\n  </Message>\r\n</AmazonEnvelope>";
			result.Should().Be( expectedXML );
		}

		[ Test ]
		public void GivenInventoryFeedXmlServiceInstantiatedWithMFN_WhenGetDocumentStringIsCalled_ThenReturnsMFN()
		{
			var inventoryItems = new List< AmazonInventoryItem >
			{
				new AmazonInventoryItem
				{
					Sku = "testSku1",
					Quantity = 123,
					FulfillmentLatency = 3
				}
			};
			var mfnXml = "<SwitchFulfillmentTo>MFN</SwitchFulfillmentTo>\r\n      <FulfillmentCenterID>DEFAULT</FulfillmentCenterID>";

			var feedService = new InventoryFeedXmlService( inventoryItems, sellerId: "1234", sellerIsMFN: true );
			var result = feedService.GetDocumentString();

			result.Should().Contain( mfnXml );
		}

		[ Test ]
		public void GivenInventoryFeedXmlServiceInstantiatedWithoutMFN_WhenGetDocumentStringIsCalled_ThenDoesntReturnMFN()
		{
			var inventoryItems = new List< AmazonInventoryItem >
			{
				new AmazonInventoryItem
				{
					Sku = "testSku1",
					Quantity = 123,
					FulfillmentLatency = 3
				}
			};

			var feedService = new InventoryFeedXmlService( inventoryItems, sellerId: "1234", sellerIsMFN: false );
			var result = feedService.GetDocumentString();

			result.Should().NotContain( "SwitchFulfillmentTo" );
			result.Should().NotContain( "FulfillmentCenterID" );
		}
	}
}
