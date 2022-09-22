using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ShippingV2
{

    /// <summary>
    /// The post-purchase details of a package that will be shipped using a shipping service.
    /// </summary>
    [DataContract]
    public class PackageDocumentDetail
    {
        /// <summary>
        /// Gets or Sets PackageClientReferenceId
        /// </summary>
        [DataMember(Name = "packageClientReferenceId", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "packageClientReferenceId")]
        public string PackageClientReferenceId { get; set; }

        /// <summary>
        /// Gets or Sets PackageDocuments
        /// </summary>
        [DataMember(Name = "packageDocuments", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "packageDocuments")]
        public PackageDocumentList PackageDocuments { get; set; }

        /// <summary>
        /// Gets or Sets TrackingId
        /// </summary>
        [DataMember(Name = "trackingId", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "trackingId")]
        public string TrackingId { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PackageDocumentDetail {\n");
            sb.Append("  PackageClientReferenceId: ").Append(PackageClientReferenceId).Append("\n");
            sb.Append("  PackageDocuments: ").Append(PackageDocuments).Append("\n");
            sb.Append("  TrackingId: ").Append(TrackingId).Append("\n");
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
