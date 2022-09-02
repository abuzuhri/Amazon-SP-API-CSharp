using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ShippingV2
{

    /// <summary>
    /// The payload for the getShipmentDocuments operation.
    /// </summary>
    [DataContract]
    public class GetShipmentDocumentsResult
    {
        /// <summary>
        /// Gets or Sets ShipmentId
        /// </summary>
        [DataMember(Name = "shipmentId", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "shipmentId")]
        public string ShipmentId { get; set; }

        /// <summary>
        /// Gets or Sets PackageDocumentDetail
        /// </summary>
        [DataMember(Name = "packageDocumentDetail", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "packageDocumentDetail")]
        public PackageDocumentDetail PackageDocumentDetail { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GetShipmentDocumentsResult {\n");
            sb.Append("  ShipmentId: ").Append(ShipmentId).Append("\n");
            sb.Append("  PackageDocumentDetail: ").Append(PackageDocumentDetail).Append("\n");
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
