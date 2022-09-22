using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ShippingV2 {

  /// <summary>
  /// Amazon shipment information.
  /// </summary>
  [DataContract]
  public class AmazonShipmentDetails {
    /// <summary>
    /// This attribute is required only for a Direct Fulfillment shipment. This is the encrypted shipment ID.
    /// </summary>
    /// <value>This attribute is required only for a Direct Fulfillment shipment. This is the encrypted shipment ID.</value>
    [DataMember(Name="shipmentId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "shipmentId")]
    public string ShipmentId { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class AmazonShipmentDetails {\n");
      sb.Append("  ShipmentId: ").Append(ShipmentId).Append("\n");
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
