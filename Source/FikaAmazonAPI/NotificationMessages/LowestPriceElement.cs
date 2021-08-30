using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace FikaAmazonAPI.NotificationMessages
{

    /// <summary>
    /// An explanation about the purpose of this instance.
    /// </summary>
    public partial class LowestPriceElement
    {
        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        [JsonProperty("Condition")]
        public string Condition { get; set; }

        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        [JsonProperty("FulfillmentChannel")]
        public string FulfillmentChannel { get; set; }

        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        [JsonProperty("LandedPrice")]
        public AmountValue LandedPrice { get; set; }

        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        [JsonProperty("ListingPrice")]
        public AmountValue ListingPrice { get; set; }

        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        [JsonProperty("Shipping")]
        public AmountValue Shipping { get; set; }

        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        [JsonProperty("Points", NullValueHandling = NullValueHandling.Ignore)]
        public LowestPricePoints Points { get; set; }
    }
}
