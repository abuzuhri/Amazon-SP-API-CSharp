using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ShippingV2 {

  /// <summary>
  /// Shipment source channel related information.
  /// </summary>
  [DataContract]
  public class ChannelDetails {
    /// <summary>
    /// The shipment source channel type.
    /// </summary>
    /// <value>The shipment source channel type.</value>
    [DataMember(Name="channelType", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "channelType")]
    public string ChannelType { get; set; }

    /// <summary>
    /// Gets or Sets AmazonOrderDetails
    /// </summary>
    [DataMember(Name="amazonOrderDetails", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "amazonOrderDetails", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public AmazonOrderDetails AmazonOrderDetails { get; set; }

    /// <summary>
    /// Gets or Sets AmazonShipmentDetails
    /// </summary>
    [DataMember(Name="amazonShipmentDetails", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "amazonShipmentDetails", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public AmazonShipmentDetails AmazonShipmentDetails { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ChannelDetails {\n");
      sb.Append("  ChannelType: ").Append(ChannelType).Append("\n");
      sb.Append("  AmazonOrderDetails: ").Append(AmazonOrderDetails).Append("\n");
      sb.Append("  AmazonShipmentDetails: ").Append(AmazonShipmentDetails).Append("\n");
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
