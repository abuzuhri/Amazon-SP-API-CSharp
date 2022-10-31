using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ShippingV2
{

    /// <summary>
    /// The payload for the purchaseShipment operation.
    /// </summary>
    [DataContract]
    public class PurchaseShipmentResult
    {
        /// <summary>
        /// Gets or Sets ShipmentId
        /// </summary>
        [DataMember(Name = "shipmentId", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "shipmentId")]
        public string ShipmentId { get; set; }

        /// <summary>
        /// Gets or Sets PackageDocumentDetails
        /// </summary>
        [DataMember(Name = "packageDocumentDetails", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "packageDocumentDetails")]
        public PackageDocumentDetailList PackageDocumentDetails { get; set; }

        /// <summary>
        /// Gets or Sets Promise
        /// </summary>
        [DataMember(Name = "promise", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "promise")]
        public Promise Promise { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PurchaseShipmentResult {\n");
            sb.Append("  ShipmentId: ").Append(ShipmentId).Append("\n");
            sb.Append("  PackageDocumentDetails: ").Append(PackageDocumentDetails).Append("\n");
            sb.Append("  Promise: ").Append(Promise).Append("\n");
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
