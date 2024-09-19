using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ShippingV2
{
    [DataContract]
    public class GetAdditionalInputsRequest
    {
        /// <summary>
        /// The request token returned in the response to the getRates operation.
        /// </summary>
        [DataMember(Name = "requestToken", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "requestToken")]
        public string RequestToken { get; set; }

        /// <summary>
        /// The rate identifier for the shipping offering (rate) returned in the response to the getRates operation.
        /// </summary>
        [DataMember(Name = "rateId", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "rateId")]
        public string RateId { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class " + nameof(GetAdditionalInputsRequest) + " {\n");
            sb.Append($"  {nameof(RequestToken)}: ").Append(RequestToken).Append("\n");
            sb.Append($"  {nameof(RateId)}: ").Append(RateId).Append("\n");
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
