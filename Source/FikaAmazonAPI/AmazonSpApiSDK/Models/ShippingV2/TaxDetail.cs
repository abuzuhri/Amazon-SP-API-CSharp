using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ShippingV2
{

    /// <summary>
    /// Indicates the tax specifications associated with the shipment for customs compliance purposes in certain regions.
    /// </summary>
    [DataContract]
    public class TaxDetail
    {
        /// <summary>
        /// Gets or Sets TaxType
        /// </summary>
        [DataMember(Name = "taxType", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "taxType")]
        public string TaxType { get; set; }

        /// <summary>
        /// The shipper's tax registration number associated with the shipment for customs compliance purposes in certain regions.
        /// </summary>
        /// <value>The shipper's tax registration number associated with the shipment for customs compliance purposes in certain regions.</value>
        [DataMember(Name = "taxRegistrationNumber", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "taxRegistrationNumber")]
        public string TaxRegistrationNumber { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TaxDetail {\n");
            sb.Append("  TaxType: ").Append(TaxType).Append("\n");
            sb.Append("  TaxRegistrationNumber: ").Append(TaxRegistrationNumber).Append("\n");
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
