using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ShippingV2 {

  /// <summary>
  /// The value-added services available for purchase with a shipping service offering.
  /// </summary>
  [DataContract]
  public class AvailableValueAddedServiceGroup {
    /// <summary>
    /// The type of the value-added service group.
    /// </summary>
    /// <value>The type of the value-added service group.</value>
    [DataMember(Name="groupId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "groupId")]
    public string GroupId { get; set; }

    /// <summary>
    /// The name of the value-added service group.
    /// </summary>
    /// <value>The name of the value-added service group.</value>
    [DataMember(Name="groupDescription", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "groupDescription")]
    public string GroupDescription { get; set; }

    /// <summary>
    /// When true, one or more of the value-added services listed must be specified.
    /// </summary>
    /// <value>When true, one or more of the value-added services listed must be specified.</value>
    [DataMember(Name="isRequired", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "isRequired")]
    public bool? IsRequired { get; set; }

    /// <summary>
    /// A list of optional value-added services available for purchase with a shipping service offering.
    /// </summary>
    /// <value>A list of optional value-added services available for purchase with a shipping service offering.</value>
    [DataMember(Name="valueAddedServices", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "valueAddedServices")]
    public List<ValueAddedService> ValueAddedServices { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class AvailableValueAddedServiceGroup {\n");
      sb.Append("  GroupId: ").Append(GroupId).Append("\n");
      sb.Append("  GroupDescription: ").Append(GroupDescription).Append("\n");
      sb.Append("  IsRequired: ").Append(IsRequired).Append("\n");
      sb.Append("  ValueAddedServices: ").Append(ValueAddedServices).Append("\n");
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
