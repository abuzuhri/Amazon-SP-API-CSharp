using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ProductTypes
{

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class SchemaLink
    {
        /// <summary>
        /// Link to retrieve the schema.
        /// </summary>
        /// <value>Link to retrieve the schema.</value>
        [DataMember(Name = "link", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "link")]
        public Object Link { get; set; }

        /// <summary>
        /// Checksum hash of the schema (Base64 MD5). Can be used to verify schema contents, identify changes between schema versions, and for caching.
        /// </summary>
        /// <value>Checksum hash of the schema (Base64 MD5). Can be used to verify schema contents, identify changes between schema versions, and for caching.</value>
        [DataMember(Name = "checksum", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "checksum")]
        public string Checksum { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SchemaLink {\n");
            sb.Append("  Link: ").Append(Link).Append("\n");
            sb.Append("  Checksum: ").Append(Checksum).Append("\n");
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
