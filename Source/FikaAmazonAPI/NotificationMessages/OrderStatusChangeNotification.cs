using Newtonsoft.Json;

namespace FikaAmazonAPI.NotificationMessages
{
    public class OrderStatusChangeNotification
    {
        [JsonProperty("SellerId")]
        public string SellerId { get; set; }

        [JsonProperty("MarketplaceId")]
        public string MarketplaceId { get; set; }

        [JsonProperty("AmazonOrderId")]
        public string AmazonOrderId { get; set; }

        [JsonProperty("PurchaseDate")]
        public long? PurchaseDate { get; set; }

        [JsonProperty("OrderStatus")]
        public string OrderStatus { get; set; }

        [JsonProperty("DestinationPostalCode")]
        public object DestinationPostalCode { get; set; }

        [JsonProperty("SupplySourceId")]
        public object SupplySourceId { get; set; }

        [JsonProperty("OrderItemId")]
        public string OrderItemId { get; set; }

        [JsonProperty("SellerSKU")]
        public string SellerSku { get; set; }

        [JsonProperty("Quantity")]
        public int Quantity { get; set; }

        [JsonProperty("FulfillmentChannel")]
        public string FulfillmentChannel { get; set; }
    }
}