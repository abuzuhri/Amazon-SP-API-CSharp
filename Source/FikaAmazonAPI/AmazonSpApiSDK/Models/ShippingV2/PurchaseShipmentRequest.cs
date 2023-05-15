using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ShippingV2
{

    /// <summary>
    /// The request schema for the purchaseShipment operation.
    /// </summary>
    [DataContract]
    public class PurchaseShipmentRequest
    {
        /// <summary>
        /// Gets or Sets RequestToken
        /// </summary>
        [DataMember(Name = "requestToken", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "requestToken", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string RequestToken { get; set; }

        /// <summary>
        /// Gets or Sets RateId
        /// </summary>
        [DataMember(Name = "rateId", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "rateId")]
        public string RateId { get; set; }

        /// <summary>
        /// Gets or Sets RequestedDocumentSpecification
        /// </summary>
        [DataMember(Name = "requestedDocumentSpecification", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "requestedDocumentSpecification", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public RequestedDocumentSpecification RequestedDocumentSpecification { get; set; }

        /// <summary>
        /// Gets or Sets RequestedValueAddedServices
        /// </summary>
        [DataMember(Name = "requestedValueAddedServices", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "requestedValueAddedServices", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public RequestedValueAddedServiceList RequestedValueAddedServices { get; set; }

        /// <summary>
        /// The additional inputs required to purchase a shipping offering, in JSON format. The JSON provided here must adhere to the JSON schema that is returned in the response to the getAdditionalInputs operation.  Additional inputs are only required when indicated by the requiresAdditionalInputs property in the response to the getRates operation.
        /// </summary>
        /// <value>The additional inputs required to purchase a shipping offering, in JSON format. The JSON provided here must adhere to the JSON schema that is returned in the response to the getAdditionalInputs operation.  Additional inputs are only required when indicated by the requiresAdditionalInputs property in the response to the getRates operation.</value>
        [DataMember(Name = "additionalInputs", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "additionalInputs", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Dictionary<string, Object> AdditionalInputs { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PurchaseShipmentRequest {\n");
            sb.Append("  RequestToken: ").Append(RequestToken).Append("\n");
            sb.Append("  RateId: ").Append(RateId).Append("\n");
            sb.Append("  RequestedDocumentSpecification: ").Append(RequestedDocumentSpecification).Append("\n");
            sb.Append("  RequestedValueAddedServices: ").Append(RequestedValueAddedServices).Append("\n");
            sb.Append("  AdditionalInputs: ").Append(AdditionalInputs).Append("\n");
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
