using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Restrictions
{

    /// <summary>
    /// A link to resources related to a listing restriction.
    /// </summary>
    [DataContract]
    public class Link
    {
        /// <summary>
        /// The URI of the related resource.
        /// </summary>
        /// <value>The URI of the related resource.</value>
        [DataMember(Name = "resource", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "resource")]
        public string Resource { get; set; }

        /// <summary>
        /// The HTTP verb used to interact with the related resource.
        /// </summary>
        /// <value>The HTTP verb used to interact with the related resource.</value>
        [DataMember(Name = "verb", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "verb")]
        public string Verb { get; set; }

        /// <summary>
        /// The title of the related resource.
        /// </summary>
        /// <value>The title of the related resource.</value>
        [DataMember(Name = "title", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        /// <summary>
        /// The media type of the related resource.
        /// </summary>
        /// <value>The media type of the related resource.</value>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Link {\n");
            sb.Append("  Resource: ").Append(Resource).Append("\n");
            sb.Append("  Verb: ").Append(Verb).Append("\n");
            sb.Append("  Title: ").Append(Title).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
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
