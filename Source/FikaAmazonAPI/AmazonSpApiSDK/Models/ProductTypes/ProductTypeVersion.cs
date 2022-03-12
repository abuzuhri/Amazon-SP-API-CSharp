using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ProductTypes
{

    /// <summary>
    /// The version details for an Amazon product type.
    /// </summary>
    [DataContract]
    public class ProductTypeVersion
    {
        /// <summary>
        /// Version identifier.
        /// </summary>
        /// <value>Version identifier.</value>
        [DataMember(Name = "version", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "version")]
        public string Version { get; set; }

        /// <summary>
        /// When true, the version indicated by the version identifier is the latest available for the Amazon product type.
        /// </summary>
        /// <value>When true, the version indicated by the version identifier is the latest available for the Amazon product type.</value>
        [DataMember(Name = "latest", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "latest")]
        public bool? Latest { get; set; }

        /// <summary>
        /// When true, the version indicated by the version identifier is the prerelease (release candidate) for the Amazon product type.
        /// </summary>
        /// <value>When true, the version indicated by the version identifier is the prerelease (release candidate) for the Amazon product type.</value>
        [DataMember(Name = "releaseCandidate", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "releaseCandidate")]
        public bool? ReleaseCandidate { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ProductTypeVersion {\n");
            sb.Append("  Version: ").Append(Version).Append("\n");
            sb.Append("  Latest: ").Append(Latest).Append("\n");
            sb.Append("  ReleaseCandidate: ").Append(ReleaseCandidate).Append("\n");
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
