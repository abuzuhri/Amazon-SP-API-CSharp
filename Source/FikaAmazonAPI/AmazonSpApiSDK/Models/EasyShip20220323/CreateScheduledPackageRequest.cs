using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.EasyShip20220323
{

    /// <summary>
    /// The request schema for the &#x60;createScheduledPackage&#x60; operation.
    /// </summary>
    [DataContract]
    public class CreateScheduledPackageRequest
    {
        /// <summary>
        /// Gets or Sets AmazonOrderId
        /// </summary>
        [DataMember(Name = "amazonOrderId", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "amazonOrderId")]
        public string AmazonOrderId { get; set; }

        /// <summary>
        /// Gets or Sets MarketplaceId
        /// </summary>
        [DataMember(Name = "marketplaceId", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "marketplaceId")]
        public string MarketplaceId { get; set; }

        /// <summary>
        /// Gets or Sets PackageDetails
        /// </summary>
        [DataMember(Name = "packageDetails", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "packageDetails")]
        public PackageDetails PackageDetails { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CreateScheduledPackageRequest {\n");
            sb.Append("  AmazonOrderId: ").Append(AmazonOrderId).Append("\n");
            sb.Append("  MarketplaceId: ").Append(MarketplaceId).Append("\n");
            sb.Append("  PackageDetails: ").Append(PackageDetails).Append("\n");
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
