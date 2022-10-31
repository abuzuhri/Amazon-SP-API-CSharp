using Newtonsoft.Json;

namespace FikaAmazonAPI.NotificationMessages
{
    /// <summary>
    /// An explanation about the purpose of this instance.
    /// </summary>
    public partial class MoneyType
    {
        /// <summary>
        /// The currency amount.
        /// </summary>
        [JsonProperty("Amount")]
        public double Amount { get; set; }

        /// <summary>
        /// Three-digit currency code. In ISO 4217 format .
        /// </summary>
        [JsonProperty("CurrencyCode")]
        public string CurrencyCode { get; set; }
    }
}
