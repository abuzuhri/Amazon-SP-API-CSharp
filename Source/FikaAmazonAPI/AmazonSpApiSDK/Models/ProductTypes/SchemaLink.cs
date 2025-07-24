using FikaAmazonAPI.AmazonSpApiSDK.Models.Solicitations;
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
        public SchemaLinkObject Link { get; set; }

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

    [DataContract]
    public class SchemaLinkObject
    {
        /// <summary>
        /// A URI for this object.
        /// </summary>
        /// <value>A URI for this object.</value>
        [DataMember(Name = "resource", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "resource")]
        public string ResourceUrl { get; set; }

        /// <summary>
        /// The HTTP Verb Method to use when calling the resource url.
        /// </summary>
        /// <value>The HTTP Verb Method to use when calling the resource url.</value>
        [DataMember(Name = "verb", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "verb")]
        public string Verb { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class " + nameof(SchemaLinkObject) + " {\n");
            sb.Append("  ResourceUrl: ").Append(ResourceUrl).Append("\n");
            sb.Append("  Verb: ").Append(Verb).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
