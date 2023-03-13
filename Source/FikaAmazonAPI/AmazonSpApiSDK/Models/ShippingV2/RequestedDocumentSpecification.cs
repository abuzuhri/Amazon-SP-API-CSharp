using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ShippingV2
{

    /// <summary>
    /// The document specifications requested. For calls to the purchaseShipment operation, the shipment purchase fails if the specified document specifications are not among those returned in the response to the getRates operation.
    /// </summary>
    [DataContract]
    public class RequestedDocumentSpecification
    {
        /// <summary>
        /// Gets or Sets Format
        /// </summary>
        [DataMember(Name = "format", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "format")]
        public DocumentFormat Format { get; set; }

        /// <summary>
        /// Gets or Sets Size
        /// </summary>
        [DataMember(Name = "size", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "size")]
        public DocumentSize Size { get; set; }

        /// <summary>
        /// The document specifications requested. For calls to the purchaseShipment operation, the shipment purchase fails if the specified document specifications are not among those returned in the response to the getRates operation.
        /// </summary>
        [DataMember(Name = "dpi", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "dpi")]
        public int Dpi { get; set; }

        /// <summary>
        /// Gets or Sets PageLayout
        /// </summary>
        [DataMember(Name = "pageLayout", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "pageLayout")]
        public string PageLayout { get; set; }

        /// <summary>
        /// Gets or Sets NeedFileJoining
        /// </summary>
        [DataMember(Name = "needFileJoining", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "needFileJoining")]
        public bool NeedFileJoining { get; set; }

        /// <summary>
        /// A list of the document types requested.
        /// </summary>
        /// <value>A list of the document types requested.</value>
        [DataMember(Name = "requestedDocumentTypes", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "requestedDocumentTypes")]
        public List<DocumentType> RequestedDocumentTypes { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class RequestedDocumentSpecification {\n");
            sb.Append("  Format: ").Append(Format).Append("\n");
            sb.Append("  Size: ").Append(Size).Append("\n");
            sb.Append("  Dpi: ").Append(Dpi).Append("\n");
            sb.Append("  PageLayout: ").Append(PageLayout).Append("\n");
            sb.Append("  NeedFileJoining: ").Append(NeedFileJoining).Append("\n");
            sb.Append("  RequestedDocumentTypes: ").Append(RequestedDocumentTypes).Append("\n");
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
