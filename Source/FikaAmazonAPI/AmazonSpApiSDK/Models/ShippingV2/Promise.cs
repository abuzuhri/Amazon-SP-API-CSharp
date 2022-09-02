using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ShippingV2 {

  /// <summary>
  /// The time windows promised for pickup and delivery events.
  /// </summary>
  [DataContract]
  public class Promise {
    /// <summary>
    /// Gets or Sets DeliveryWindow
    /// </summary>
    [DataMember(Name="deliveryWindow", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "deliveryWindow")]
    public TimeWindow DeliveryWindow { get; set; }

    /// <summary>
    /// Gets or Sets PickupWindow
    /// </summary>
    [DataMember(Name="pickupWindow", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "pickupWindow")]
    public TimeWindow PickupWindow { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class Promise {\n");
      sb.Append("  DeliveryWindow: ").Append(DeliveryWindow).Append("\n");
      sb.Append("  PickupWindow: ").Append(PickupWindow).Append("\n");
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
