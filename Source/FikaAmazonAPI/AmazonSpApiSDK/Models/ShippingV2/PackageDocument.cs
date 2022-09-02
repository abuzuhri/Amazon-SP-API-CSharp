using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ShippingV2
{

    /// <summary>
    /// A document related to a package.
    /// </summary>
    [DataContract]
    public class PackageDocument
    {
        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "type")]
        public DocumentType Type { get; set; }

        /// <summary>
        /// Gets or Sets Format
        /// </summary>
        [DataMember(Name = "format", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "format")]
        public string Format { get; set; }

        /// <summary>
        /// Gets or Sets Contents
        /// </summary>
        [DataMember(Name = "contents", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "contents")]
        public string Contents { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PackageDocument {\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Format: ").Append(Format).Append("\n");
            sb.Append("  Contents: ").Append(Contents).Append("\n");
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
