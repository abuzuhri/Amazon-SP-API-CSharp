using System;

namespace FikaAmazonAPI.NotificationMessages
{
    public class OrderChangeNotification
    {
        public string NotificationLevel { get; set; }
        public string SellerId { get; set; }
        public string AmazonOrderId { get; set; }
        public string OrderChangeType { get; set; }
        public Orderchangetrigger OrderChangeTrigger { get; set; }
        public Summary Summary { get; set; }
    }

    public class Orderchangetrigger
    {
        public DateTime TimeOfOrderChange { get; set; }
        public string ChangeReason { get; set; }
    }

    public class Summary
    {
        public string MarketplaceId { get; set; }
        public string OrderStatus { get; set; }
        public DateTime PurchaseDate { get; set; }
        public object DestinationPostalCode { get; set; }
        public string FulfillmentType { get; set; }
        public string OrderType { get; set; }
        public object[] OrderPrograms { get; set; }
        public object[] ShippingPrograms { get; set; }
        public Orderitem[] OrderItems { get; set; }
    }

    public class Orderitem
    {
        public string OrderItemId { get; set; }
        public string SellerSKU { get; set; }
        public object SupplySourceId { get; set; }
        public int Quantity { get; set; }
    }
}