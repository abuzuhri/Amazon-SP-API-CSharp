using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FikaAmazonAPI.NotificationMessages
{

    /// <summary>
    /// An explanation about the purpose of this instance.
    /// </summary>
    public partial class BuyBoxPriceElement
    {
        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        [JsonProperty("Condition")]
        public string Condition { get; set; }

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
        public BuyBoxPricePoints Points { get; set; }
    }
}
