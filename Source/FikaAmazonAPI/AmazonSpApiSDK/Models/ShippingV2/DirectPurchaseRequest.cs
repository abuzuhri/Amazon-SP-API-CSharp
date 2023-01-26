using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ShippingV2 {

  /// <summary>
  /// The request schema for the directPurchaseShipment operation. When the channel type is Amazon, the shipTo address is not required and will be ignored.
  /// </summary>
  [DataContract]
  public class DirectPurchaseRequest {
    /// <summary>
    /// The address where the shipment will be delivered. For vendor orders, shipTo information is pulled directly from the Amazon order.
    /// </summary>
    /// <value>The address where the shipment will be delivered. For vendor orders, shipTo information is pulled directly from the Amazon order.</value>
    [DataMember(Name="shipTo", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "shipTo")]
    public Address ShipTo { get; set; }

    /// <summary>
    /// The address where the package will be picked up.
    /// </summary>
    /// <value>The address where the package will be picked up.</value>
    [DataMember(Name="shipFrom", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "shipFrom")]
    public Address ShipFrom { get; set; }

    /// <summary>
    /// The address where the package will be returned if it cannot be delivered.
    /// </summary>
    /// <value>The address where the package will be returned if it cannot be delivered.</value>
    [DataMember(Name="returnTo", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "returnTo")]
    public Address ReturnTo { get; set; }

    /// <summary>
    /// Gets or Sets Packages
    /// </summary>
    [DataMember(Name="packages", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "packages")]
    public PackageList Packages { get; set; }

    /// <summary>
    /// Gets or Sets ChannelDetails
    /// </summary>
    [DataMember(Name="channelDetails", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "channelDetails")]
    public ChannelDetails ChannelDetails { get; set; }

    /// <summary>
    /// The document (label) specifications requested. The default label returned is PNG DPI 203 4x6 if no label specification is provided. Requesting an invalid file format results in a failure.
    /// </summary>
    /// <value>The document (label) specifications requested. The default label returned is PNG DPI 203 4x6 if no label specification is provided. Requesting an invalid file format results in a failure.</value>
    [DataMember(Name="labelSpecifications", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "labelSpecifications")]
    public RequestedDocumentSpecification LabelSpecifications { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class DirectPurchaseRequest {\n");
      sb.Append("  ShipTo: ").Append(ShipTo).Append("\n");
      sb.Append("  ShipFrom: ").Append(ShipFrom).Append("\n");
      sb.Append("  ReturnTo: ").Append(ReturnTo).Append("\n");
      sb.Append("  Packages: ").Append(Packages).Append("\n");
      sb.Append("  ChannelDetails: ").Append(ChannelDetails).Append("\n");
      sb.Append("  LabelSpecifications: ").Append(LabelSpecifications).Append("\n");
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
