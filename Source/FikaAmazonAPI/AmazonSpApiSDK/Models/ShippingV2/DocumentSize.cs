using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ShippingV2 {

  /// <summary>
  /// The size dimensions of the label.
  /// </summary>
  [DataContract]
  public class DocumentSize {
    /// <summary>
    /// The width of the document measured in the units specified.
    /// </summary>
    /// <value>The width of the document measured in the units specified.</value>
    [DataMember(Name="width", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "width", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public decimal? Width { get; set; }

    /// <summary>
    /// The length of the document measured in the units specified.
    /// </summary>
    /// <value>The length of the document measured in the units specified.</value>
    [DataMember(Name="length", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "length", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public decimal? Length { get; set; }

    /// <summary>
    /// The unit of measurement.
    /// </summary>
    /// <value>The unit of measurement.</value>
    [DataMember(Name="unit", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "unit", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Unit { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class DocumentSize {\n");
      sb.Append("  Width: ").Append(Width).Append("\n");
      sb.Append("  Length: ").Append(Length).Append("\n");
      sb.Append("  Unit: ").Append(Unit).Append("\n");
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
