using System;

namespace FikaAmazonAPI.NotificationMessages
{
    public partial class FulfillmentOrderStatusNotification
    {
        public string SellerId { get; set; }
        public string EventType { get; set; }
        public DateTimeOffset StatusUpdatedDateTime { get; set; }
        public string SellerFulfillmentOrderId { get; set; }
        public string FulfillmentOrderStatus { get; set; }
        public FulfillmentShipment FulfillmentShipment { get; set; }
        public FulfillmentReturnItem FulfillmentReturnItem { get; set; }
    }

}
