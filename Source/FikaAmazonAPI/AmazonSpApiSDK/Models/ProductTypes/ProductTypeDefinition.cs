using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ProductTypes
{

    /// <summary>
    /// A product type definition represents the attributes and data requirements for a product type in the Amazon catalog. Product type definitions are used interchangeably between the Selling Partner API for Listings Items, Selling Partner API for Catalog Items, and JSON-based listings feeds in the Selling Partner API for Feeds.
    /// </summary>
    [DataContract]
    public class ProductTypeDefinition
    {
        /// <summary>
        /// Link to meta-schema describing the vocabulary used by the product type schema.
        /// </summary>
        /// <value>Link to meta-schema describing the vocabulary used by the product type schema.</value>
        [DataMember(Name = "metaSchema", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "metaSchema")]
        public SchemaLink MetaSchema { get; set; }

        /// <summary>
        /// Link to schema describing the attributes and requirements for the product type.
        /// </summary>
        /// <value>Link to schema describing the attributes and requirements for the product type.</value>
        [DataMember(Name = "schema", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "schema")]
        public SchemaLink Schema { get; set; }

        /// <summary>
        /// Name of the requirements set represented in this product type definition.
        /// </summary>
        /// <value>Name of the requirements set represented in this product type definition.</value>
        [DataMember(Name = "requirements", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "requirements")]
        public string Requirements { get; set; }

        /// <summary>
        /// Identifies if the required attributes for a requirements set are enforced by the product type definition schema. Non-enforced requirements enable structural validation of individual attributes without all of the required attributes being present (such as for partial updates).
        /// </summary>
        /// <value>Identifies if the required attributes for a requirements set are enforced by the product type definition schema. Non-enforced requirements enable structural validation of individual attributes without all of the required attributes being present (such as for partial updates).</value>
        [DataMember(Name = "requirementsEnforced", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "requirementsEnforced")]
        public string RequirementsEnforced { get; set; }

        /// <summary>
        /// Mapping of property group names to property groups. Property groups represent logical groupings of schema properties that can be used for display or informational purposes.
        /// </summary>
        /// <value>Mapping of property group names to property groups. Property groups represent logical groupings of schema properties that can be used for display or informational purposes.</value>
        [DataMember(Name = "propertyGroups", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "propertyGroups")]
        public Dictionary<string, PropertyGroup> PropertyGroups { get; set; }

        /// <summary>
        /// Locale of the display elements contained in the product type definition.
        /// </summary>
        /// <value>Locale of the display elements contained in the product type definition.</value>
        [DataMember(Name = "locale", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "locale")]
        public string Locale { get; set; }

        /// <summary>
        /// Amazon marketplace identifiers for which the product type definition is applicable.
        /// </summary>
        /// <value>Amazon marketplace identifiers for which the product type definition is applicable.</value>
        [DataMember(Name = "marketplaceIds", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "marketplaceIds")]
        public List<string> MarketplaceIds { get; set; }

        /// <summary>
        /// The name of the Amazon product type that this product type definition applies to.
        /// </summary>
        /// <value>The name of the Amazon product type that this product type definition applies to.</value>
        [DataMember(Name = "productType", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "productType")]
        public string ProductType { get; set; }

        /// <summary>
        /// The version details for the Amazon product type.
        /// </summary>
        /// <value>The version details for the Amazon product type.</value>
        [DataMember(Name = "productTypeVersion", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "productTypeVersion")]
        public ProductTypeVersion ProductTypeVersion { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ProductTypeDefinition {\n");
            sb.Append("  MetaSchema: ").Append(MetaSchema).Append("\n");
            sb.Append("  Schema: ").Append(Schema).Append("\n");
            sb.Append("  Requirements: ").Append(Requirements).Append("\n");
            sb.Append("  RequirementsEnforced: ").Append(RequirementsEnforced).Append("\n");
            sb.Append("  PropertyGroups: ").Append(PropertyGroups).Append("\n");
            sb.Append("  Locale: ").Append(Locale).Append("\n");
            sb.Append("  MarketplaceIds: ").Append(MarketplaceIds).Append("\n");
            sb.Append("  ProductType: ").Append(ProductType).Append("\n");
            sb.Append("  ProductTypeVersion: ").Append(ProductTypeVersion).Append("\n");
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
