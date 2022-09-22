using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ShippingV2
{

    /// <summary>
    /// Document specification that is supported for a service offering.
    /// </summary>
    [DataContract]
    public class SupportedDocumentSpecification
    {
        /// <summary>
        /// Gets or Sets Format
        /// </summary>
        [DataMember(Name = "format", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "format")]
        public string Format { get; set; }

        /// <summary>
        /// Gets or Sets Size
        /// </summary>
        [DataMember(Name = "size", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "size")]
        public DocumentSize Size { get; set; }

        /// <summary>
        /// Gets or Sets PrintOptions
        /// </summary>
        [DataMember(Name = "printOptions", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "printOptions")]
        public PrintOptionList PrintOptions { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SupportedDocumentSpecification {\n");
            sb.Append("  Format: ").Append(Format).Append("\n");
            sb.Append("  Size: ").Append(Size).Append("\n");
            sb.Append("  PrintOptions: ").Append(PrintOptions).Append("\n");
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
