using Newtonsoft.Json;
using System.Collections.Generic;

namespace FikaAmazonAPI.NotificationMessages
{
    public class NotificationPayload
    {
        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        [JsonProperty("anyOfferChangedNotification")]
        public AnyOfferChangedNotification AnyOfferChangedNotification { get; set; }
        
        [JsonProperty("b2bAnyOfferChangedNotification")]
        public B2BAnyOfferChangedNotification B2BAnyOfferChangedNotification { get; set; }
        
        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        [JsonProperty("feePromotionNotification")]
        public FeePromotionNotification FeePromotionNotification { get; set; }

        [JsonProperty("fbaOutboundShipmentStatusNotification")]
        public FbaOutboundShipmentStatusNotification FbaOutboundShipmentStatusNotification { get; set; }

        [JsonProperty("fulfillmentOrderStatusNotification")]
        public FulfillmentOrderStatusNotification FulfillmentOrderStatusNotification { get; set; }

        [JsonProperty("MFNOrderStatusChangeNotification")]
        public MfnOrderStatusChangeNotification MfnOrderStatusChangeNotification { get; set; }

        [JsonProperty("OrderNotification")]
        public OrderNotification OrderNotification { get; set; }

        [JsonProperty("reportProcessingFinishedNotification")]
        public ReportProcessingFinishedNotification ReportProcessingFinishedNotification { get; set; }

        [JsonProperty("feedProcessingFinishedNotification")]
        public FeedProcessingFinishedNotification FeedProcessingFinishedNotification { get; set; }

        [JsonProperty("OrderStatusChangeNotification")]
        public OrderStatusChangeNotification OrderStatusChangeNotification { get; set; }
        
        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        public string Asin { get; set; }

        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        public List<object> AttributesChanged { get; set; }

        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        public string BrandName { get; set; }

        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        public string MarketplaceId { get; set; }
        public string PreviousProductType { get; set; }
        public string CurrentProductType { get; set; }
    }
}
