using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.EasyShip20220323
{

    /// <summary>
    /// The dimensions of the scheduled package.
    /// </summary>
    [DataContract]
    public class Dimensions
    {
        /// <summary>
        /// The length dimension.
        /// </summary>
        /// <value>The length dimension.</value>
        [DataMember(Name = "length", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "length")]
        public decimal Length { get; set; }

        /// <summary>
        /// The width dimension.
        /// </summary>
        /// <value>The width dimension.</value>
        [DataMember(Name = "width", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "width")]
        public decimal Width { get; set; }

        /// <summary>
        /// The height dimension.
        /// </summary>
        /// <value>The height dimension.</value>
        [DataMember(Name = "height", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "height")]
        public decimal Height { get; set; }

        /// <summary>
        /// Gets or Sets Unit
        /// </summary>
        [DataMember(Name = "unit", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "unit")]
        public string Unit { get; set; }

        /// <summary>
        /// Identifier for custom package dimensions.
        /// </summary>
        /// <value>Identifier for custom package dimensions.</value>
        [DataMember(Name = "identifier", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "identifier")]
        public string Identifier { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Dimensions {\n");
            sb.Append("  Length: ").Append(Length).Append("\n");
            sb.Append("  Width: ").Append(Width).Append("\n");
            sb.Append("  Height: ").Append(Height).Append("\n");
            sb.Append("  Unit: ").Append(Unit).Append("\n");
            sb.Append("  Identifier: ").Append(Identifier).Append("\n");
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
