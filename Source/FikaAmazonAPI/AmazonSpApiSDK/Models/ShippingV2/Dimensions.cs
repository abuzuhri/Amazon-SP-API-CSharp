using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ShippingV2 {

  /// <summary>
  /// A set of measurements for a three-dimensional object.
  /// </summary>
  [DataContract]
  public class Dimensions {
    /// <summary>
    /// The length of the package.
    /// </summary>
    /// <value>The length of the package.</value>
    [DataMember(Name="length", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "length")]
    public decimal? Length { get; set; }

    /// <summary>
    /// The width of the package.
    /// </summary>
    /// <value>The width of the package.</value>
    [DataMember(Name="width", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "width")]
    public decimal? Width { get; set; }

    /// <summary>
    /// The height of the package.
    /// </summary>
    /// <value>The height of the package.</value>
    [DataMember(Name="height", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "height")]
    public decimal? Height { get; set; }

    /// <summary>
    /// The unit of measurement.
    /// </summary>
    /// <value>The unit of measurement.</value>
    [DataMember(Name="unit", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "unit")]
    public string Unit { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class Dimensions {\n");
      sb.Append("  Length: ").Append(Length).Append("\n");
      sb.Append("  Width: ").Append(Width).Append("\n");
      sb.Append("  Height: ").Append(Height).Append("\n");
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
