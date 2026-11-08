using FikaAmazonAPI.AmazonSpApiSDK.Models.Finances;
using Newtonsoft.Json;

namespace Tests
{
    [TestFixture]
    public class FinancialEventsTests
    {
        private const string PayloadWithRemovalShipment = @"{
            ""RemovalShipmentEventList"": [
                {
                    ""PostedDate"": ""2024-06-18T10:15:00Z"",
                    ""OrderId"": ""ABC123xyz"",
                    ""TransactionType"": ""WHOLESALE_LIQUIDATION"",
                    ""RemovalShipmentItemList"": [
                        {
                            ""RemovalShipmentItemId"": ""item-1"",
                            ""TaxCollectionModel"": ""Standard"",
                            ""FulfillmentNetworkSKU"": ""X000TEST01"",
                            ""Quantity"": 2,
                            ""Revenue"": { ""CurrencyCode"": ""GBP"", ""CurrencyAmount"": 3.50 },
                            ""FeeAmount"": { ""CurrencyCode"": ""GBP"", ""CurrencyAmount"": -1.25 },
                            ""TaxAmount"": { ""CurrencyCode"": ""GBP"", ""CurrencyAmount"": 0.70 },
                            ""TaxWithheld"": { ""CurrencyCode"": ""GBP"", ""CurrencyAmount"": 0.00 }
                        }
                    ]
                }
            ]
        }";

        [Test]
        public void Deserialise_RemovalShipmentEventList_IsPopulated()
        {
            // Act
            var events = JsonConvert.DeserializeObject<FinancialEvents>(PayloadWithRemovalShipment);

            // Assert
            Assert.That(events.RemovalShipmentEventList, Is.Not.Null);
            Assert.That(events.RemovalShipmentEventList, Has.Count.EqualTo(1));

            var removal = events.RemovalShipmentEventList[0];
            Assert.That(removal.OrderId, Is.EqualTo("ABC123xyz"));
            Assert.That(removal.TransactionType, Is.EqualTo("WHOLESALE_LIQUIDATION"));
            Assert.That(removal.PostedDate, Is.Not.Null);
            Assert.That(removal.RemovalShipmentItemList, Has.Count.EqualTo(1));

            var item = removal.RemovalShipmentItemList[0];
            Assert.That(item.FulfillmentNetworkSKU, Is.EqualTo("X000TEST01"));
            Assert.That(item.Quantity, Is.EqualTo(2));
            Assert.That(item.FeeAmount.CurrencyAmount, Is.EqualTo(-1.25m));
            Assert.That(item.FeeAmount.CurrencyCode, Is.EqualTo("GBP"));
        }

        [Test]
        public void Serialise_RemovalShipmentEventList_RoundTrips()
        {
            // Arrange
            var original = JsonConvert.DeserializeObject<FinancialEvents>(PayloadWithRemovalShipment);

            // Act
            var roundTripped = JsonConvert.DeserializeObject<FinancialEvents>(original.ToJson());

            // Assert
            Assert.That(roundTripped.RemovalShipmentEventList, Has.Count.EqualTo(1));
            Assert.That(roundTripped.RemovalShipmentEventList[0].OrderId, Is.EqualTo("ABC123xyz"));
            Assert.That(roundTripped.RemovalShipmentEventList[0].RemovalShipmentItemList[0].FeeAmount.CurrencyAmount, Is.EqualTo(-1.25m));
        }

        [Test]
        public void Equals_DiffersOnlyByRemovalShipmentEventList_IsFalse()
        {
            // Arrange
            var withRemoval = JsonConvert.DeserializeObject<FinancialEvents>(PayloadWithRemovalShipment);
            var withoutRemoval = new FinancialEvents();

            // Act / Assert
            Assert.That(withRemoval.Equals(withoutRemoval), Is.False);
            Assert.That(withoutRemoval.Equals(withRemoval), Is.False);
        }
    }
}
