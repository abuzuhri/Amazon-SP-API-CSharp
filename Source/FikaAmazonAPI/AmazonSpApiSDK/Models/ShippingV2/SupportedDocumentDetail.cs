using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ShippingV2 {

  /// <summary>
  /// The supported document types for a service offering.
  /// </summary>
  [DataContract]
  public class SupportedDocumentDetail {
    /// <summary>
    /// Gets or Sets Name
    /// </summary>
    [DataMember(Name="name", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "name")]
    public DocumentType Name { get; set; }

    /// <summary>
    /// When true, the supported document type is required.
    /// </summary>
    /// <value>When true, the supported document type is required.</value>
    [DataMember(Name="isMandatory", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "isMandatory")]
    public bool? IsMandatory { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class SupportedDocumentDetail {\n");
      sb.Append("  Name: ").Append(Name).Append("\n");
      sb.Append("  IsMandatory: ").Append(IsMandatory).Append("\n");
      sb.Append("}\n");
      return sb.ToString();
    }

    /// <summary>
    /// Get the JSON string presentation of the object
    /// </summary>
    /// <returns>JSON string presentation of the object</returns>
    public string ToJson() {
      return JsonConvert.SerializeObject(this, Formatting.Indented);
    }

}
}
