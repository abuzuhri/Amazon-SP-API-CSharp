using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ShippingV2
{

    /// <summary>
    /// The payload for the getRates operation.
    /// </summary>
    [DataContract]
    public class GetRatesResult
    {
        /// <summary>
        /// Gets or Sets RequestToken
        /// </summary>
        [DataMember(Name = "requestToken", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "requestToken")]
        public string RequestToken { get; set; }

        /// <summary>
        /// Gets or Sets Rates
        /// </summary>
        [DataMember(Name = "rates", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "rates")]
        public RateList Rates { get; set; }

        /// <summary>
        /// Gets or Sets IneligibleRates
        /// </summary>
        [DataMember(Name = "ineligibleRates", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "ineligibleRates")]
        public IneligibleRateList IneligibleRates { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GetRatesResult {\n");
            sb.Append("  RequestToken: ").Append(RequestToken).Append("\n");
            sb.Append("  Rates: ").Append(Rates).Append("\n");
            sb.Append("  IneligibleRates: ").Append(IneligibleRates).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Get the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

    }
}
