using System;
using System.Collections.Generic;

namespace FikaAmazonAPI.NotificationMessages
{
    public partial class FulfillmentShipment
    {
        public string FulfillmentShipmentStatus { get; set; }
        public string AmazonShipmentId { get; set; }
        public DateTimeOffset EstimatedArrivalDateTime { get; set; }
        public Info Info { get; set; }
        public List<Info> FulfillmentShipmentPackages { get; set; }
    }
}
