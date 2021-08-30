using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace FikaAmazonAPI.NotificationMessages
{
    /// <summary>
    /// An explanation about the purpose of this instance.
    /// </summary>
    public partial class MoneyType
    {
        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        [JsonProperty("Amount")]
        public double Amount { get; set; }

        /// <summary>
        /// An explanation about the purpose of this instance.
        /// </summary>
        [JsonProperty("CurrencyCode")]
        public string CurrencyCode { get; set; }
    }
}
