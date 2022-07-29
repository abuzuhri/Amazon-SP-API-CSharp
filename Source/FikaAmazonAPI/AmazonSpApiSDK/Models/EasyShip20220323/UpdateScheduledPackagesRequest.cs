using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.EasyShip20220323
{

    /// <summary>
    /// The request schema for the &#x60;updateScheduledPackages&#x60; operation.
    /// </summary>
    [DataContract]
    public class UpdateScheduledPackagesRequest
    {
        /// <summary>
        /// Gets or Sets MarketplaceId
        /// </summary>
        [DataMember(Name = "marketplaceId", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "marketplaceId")]
        public string MarketplaceId { get; set; }

        /// <summary>
        /// Gets or Sets UpdatePackageDetailsList
        /// </summary>
        [DataMember(Name = "updatePackageDetailsList", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "updatePackageDetailsList")]
        public UpdatePackageDetailsList UpdatePackageDetailsList { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class UpdateScheduledPackagesRequest {\n");
            sb.Append("  MarketplaceId: ").Append(MarketplaceId).Append("\n");
            sb.Append("  UpdatePackageDetailsList: ").Append(UpdatePackageDetailsList).Append("\n");
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
