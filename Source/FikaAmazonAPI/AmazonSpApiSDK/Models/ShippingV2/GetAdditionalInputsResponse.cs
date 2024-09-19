using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ShippingV2
{

    /// <summary>
    /// The response schema for the getAdditionalInputs operation.
    /// </summary>
    [DataContract]
    public class GetAdditionalInputsResponse
    {
        /// <summary>
        /// Gets or Sets Payload
        /// See: https://developer-docs.amazon.com/amazon-shipping/docs/shipping-api-v2-reference#getadditionalinputsresponse
        /// </summary>
        [DataMember(Name = "payload", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "payload", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public GetAdditionalInputsResult Payload { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GetAdditionalInputsResponse {\n");
            sb.Append("  Payload: ").Append(Payload).Append("\n");
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
