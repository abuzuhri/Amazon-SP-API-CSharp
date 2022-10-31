using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.VendorOrders
{
    public class Constants
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum PoItemState
        {
            Cancelled
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum PurchaseOrderState
        {
            New,
            Acknowledged,
            Closed
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum PurchaseOrderStatus
        {
            OPEN,
            CLOSED
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum ItemConfirmationStatus
        {
            ACCEPTED,
            PARTIALLY_ACCEPTED,
            REJECTED,
            UNCONFIRMED
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum ItemReceiveStatus
        {
            NOT_RECEIVED,
            PARTIALLY_RECEIVED,
            RECEIVED
        }

    }
}
