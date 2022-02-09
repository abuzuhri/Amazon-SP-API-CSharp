namespace FikaAmazonAPI.NotificationMessages
{
    public partial class FbaOutboundShipmentStatusNotification
    {
        public string SellerId { get; set; }
        public string AmazonOrderId { get; set; }
        public string AmazonShipmentId { get; set; }
        public string ShipmentStatus { get; set; }
    }
}
