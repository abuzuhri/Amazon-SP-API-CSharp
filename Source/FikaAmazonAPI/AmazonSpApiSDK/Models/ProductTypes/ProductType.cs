using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ProductTypes
{

    /// <summary>
    /// An Amazon product type with a definition available.
    /// </summary>
    [DataContract]
    public class ProductType
    {
        /// <summary>
        /// The name of the Amazon product type.
        /// </summary>
        /// <value>The name of the Amazon product type.</value>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// The Amazon marketplace identifiers for which the product type definition is available.
        /// </summary>
        /// <value>The Amazon marketplace identifiers for which the product type definition is available.</value>
        [DataMember(Name = "marketplaceIds", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "marketplaceIds")]
        public List<string> MarketplaceIds { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ProductType {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  MarketplaceIds: ").Append(MarketplaceIds).Append("\n");
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
