using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ProductTypes
{

    /// <summary>
    /// A list of Amazon product types with definitions available.
    /// </summary>
    [DataContract]
    public class ProductTypeList
    {
        /// <summary>
        /// Gets or Sets ProductTypes
        /// </summary>
        [DataMember(Name = "productTypes", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "productTypes")]
        public List<ProductType> ProductTypes { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ProductTypeList {\n");
            sb.Append("  ProductTypes: ").Append(ProductTypes).Append("\n");
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
