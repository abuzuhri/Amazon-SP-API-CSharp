using System.Collections.Generic;
using Newtonsoft.Json;


namespace FikaAmazonAPI.NotificationMessages
{
    /// <summary>
    /// An explanation about the purpose of this instance.
    /// </summary>
    public partial class AnyOfferChangedNotification
    {
        /// <summary>
        /// Required. The seller identifier for the offer.
        /// </summary>
        [JsonProperty("SellerId")]
        public string SellerId { get; set; }

        /// <summary>
        /// Required. The event that caused the notification to be sent. 
        /// </summary>
        [JsonProperty("OfferChangeTrigger")]
        public OfferChangeTriggerB2C OfferChangeTrigger { get; set; }

        /// <summary>
        /// Required. Information about the product that had the offer change. The information in this summary applies to all conditions of the product. 
        /// </summary>
        [JsonProperty("Summary")]
        public SummaryB2C Summary { get; set; }

        /// <summary>
        /// Required. The top 20 competitive offers for the item and condition that triggered the notification. 
        /// </summary>
        [JsonProperty("Offers")]
        public List<OfferB2C> Offers { get; set; }
    }

}