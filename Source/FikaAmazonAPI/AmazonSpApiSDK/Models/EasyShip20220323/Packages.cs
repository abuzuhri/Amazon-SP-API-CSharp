using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.EasyShip20220323
{

    /// <summary>
    /// A list of packages.
    /// </summary>
    [DataContract]
    public class Packages
    {
        /// <summary>
        /// Gets or Sets _Packages
        /// </summary>
        [DataMember(Name = "packages", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "packages")]
        public List<Package> _Packages { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Packages {\n");
            sb.Append("  _Packages: ").Append(_Packages).Append("\n");
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
