using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.EasyShip20220323
{

    /// <summary>
    /// The request schema for the &#x60;listHandoverSlots&#x60; operation.
    /// </summary>
    [DataContract]
    public class ListHandoverSlotsRequest
    {
        /// <summary>
        /// Gets or Sets MarketplaceId
        /// </summary>
        [DataMember(Name = "marketplaceId", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "marketplaceId")]
        public string MarketplaceId { get; set; }

        /// <summary>
        /// Gets or Sets AmazonOrderId
        /// </summary>
        [DataMember(Name = "amazonOrderId", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "amazonOrderId")]
        public string AmazonOrderId { get; set; }

        /// <summary>
        /// Gets or Sets PackageDimensions
        /// </summary>
        [DataMember(Name = "packageDimensions", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "packageDimensions")]
        public Dimensions PackageDimensions { get; set; }

        /// <summary>
        /// Gets or Sets PackageWeight
        /// </summary>
        [DataMember(Name = "packageWeight", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "packageWeight")]
        public Weight PackageWeight { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ListHandoverSlotsRequest {\n");
            sb.Append("  MarketplaceId: ").Append(MarketplaceId).Append("\n");
            sb.Append("  AmazonOrderId: ").Append(AmazonOrderId).Append("\n");
            sb.Append("  PackageDimensions: ").Append(PackageDimensions).Append("\n");
            sb.Append("  PackageWeight: ").Append(PackageWeight).Append("\n");
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
