using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ShippingV2 {

  /// <summary>
  /// Item identifiers for an item in a direct fulfillment shipment.
  /// </summary>
  [DataContract]
  public class DirectFulfillmentItemIdentifiers {
    /// <summary>
    /// A unique identifier for an item provided by the client for a direct fulfillment shipment. This is only populated for direct fulfillment multi-piece shipments. It is required if a vendor wants to change the configuration of the packages in which the purchase order is shipped.
    /// </summary>
    /// <value>A unique identifier for an item provided by the client for a direct fulfillment shipment. This is only populated for direct fulfillment multi-piece shipments. It is required if a vendor wants to change the configuration of the packages in which the purchase order is shipped.</value>
    [DataMember(Name="lineItemID", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "lineItemID")]
    public string LineItemID { get; set; }

    /// <summary>
    /// A unique identifier for an item provided by the client for a direct fulfillment shipment. This is only populated if a single line item has multiple pieces. Defaults to 1.
    /// </summary>
    /// <value>A unique identifier for an item provided by the client for a direct fulfillment shipment. This is only populated if a single line item has multiple pieces. Defaults to 1.</value>
    [DataMember(Name="pieceNumber", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "pieceNumber")]
    public string PieceNumber { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class DirectFulfillmentItemIdentifiers {\n");
      sb.Append("  LineItemID: ").Append(LineItemID).Append("\n");
      sb.Append("  PieceNumber: ").Append(PieceNumber).Append("\n");
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
