using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ProductTypes
{

    /// <summary>
    /// A property group represents a logical grouping of schema properties that can be used for display or informational purposes.
    /// </summary>
    [DataContract]
    public class PropertyGroup
    {
        /// <summary>
        /// The display label of the property group.
        /// </summary>
        /// <value>The display label of the property group.</value>
        [DataMember(Name = "title", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        /// <summary>
        /// The description of the property group.
        /// </summary>
        /// <value>The description of the property group.</value>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// The names of the schema properties for the property group.
        /// </summary>
        /// <value>The names of the schema properties for the property group.</value>
        [DataMember(Name = "propertyNames", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "propertyNames")]
        public List<string> PropertyNames { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PropertyGroup {\n");
            sb.Append("  Title: ").Append(Title).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  PropertyNames: ").Append(PropertyNames).Append("\n");
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
