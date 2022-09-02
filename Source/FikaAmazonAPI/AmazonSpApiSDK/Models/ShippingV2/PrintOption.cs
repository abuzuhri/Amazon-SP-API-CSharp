using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ShippingV2
{

    /// <summary>
    /// The format options available for a label.
    /// </summary>
    [DataContract]
    public class PrintOption
    {
        /// <summary>
        /// A list of the supported DPI options for a document.
        /// </summary>
        /// <value>A list of the supported DPI options for a document.</value>
        [DataMember(Name = "supportedDPIs", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "supportedDPIs")]
        public List<int> SupportedDPIs { get; set; }

        /// <summary>
        /// A list of the supported page layout options for a document.
        /// </summary>
        /// <value>A list of the supported page layout options for a document.</value>
        [DataMember(Name = "supportedPageLayouts", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "supportedPageLayouts")]
        public List<string> SupportedPageLayouts { get; set; }

        /// <summary>
        /// A list of the supported needFileJoining boolean values for a document.
        /// </summary>
        /// <value>A list of the supported needFileJoining boolean values for a document.</value>
        [DataMember(Name = "supportedFileJoiningOptions", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "supportedFileJoiningOptions")]
        public List<bool> SupportedFileJoiningOptions { get; set; }

        /// <summary>
        /// A list of the supported documented details.
        /// </summary>
        /// <value>A list of the supported documented details.</value>
        [DataMember(Name = "supportedDocumentDetails", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "supportedDocumentDetails")]
        public List<SupportedDocumentDetail> SupportedDocumentDetails { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PrintOption {\n");
            sb.Append("  SupportedDPIs: ").Append(SupportedDPIs).Append("\n");
            sb.Append("  SupportedPageLayouts: ").Append(SupportedPageLayouts).Append("\n");
            sb.Append("  SupportedFileJoiningOptions: ").Append(SupportedFileJoiningOptions).Append("\n");
            sb.Append("  SupportedDocumentDetails: ").Append(SupportedDocumentDetails).Append("\n");
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
