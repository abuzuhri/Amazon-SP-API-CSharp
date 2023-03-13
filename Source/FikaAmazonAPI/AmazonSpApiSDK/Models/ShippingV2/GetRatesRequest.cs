using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ShippingV2 {

  /// <summary>
  /// The request schema for the getRates operation. When the channelType is Amazon, the shipTo address is not required and will be ignored.
  /// </summary>
  [DataContract]
  public class GetRatesRequest {
    /// <summary>
    /// The ship to address.
    /// </summary>
    /// <value>The ship to address.</value>
    [DataMember(Name="shipTo", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "shipTo", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public Address ShipTo { get; set; }

    /// <summary>
    /// The ship from address.
    /// </summary>
    /// <value>The ship from address.</value>
    [DataMember(Name="shipFrom", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "shipFrom")]
    public Address ShipFrom { get; set; }

    /// <summary>
    /// The return to address.
    /// </summary>
    /// <value>The return to address.</value>
    [DataMember(Name="returnTo", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "returnTo", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public Address ReturnTo { get; set; }

    /// <summary>
    /// The ship date and time (the requested pickup). This defaults to the current date and time.
    /// </summary>
    /// <value>The ship date and time (the requested pickup). This defaults to the current date and time.</value>
    [DataMember(Name="shipDate", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "shipDate", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public DateTime? ShipDate { get; set; }

    /// <summary>
    /// Gets or Sets Packages
    /// </summary>
    [DataMember(Name="packages", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "packages")]
    public PackageList Packages { get; set; }

    /// <summary>
    /// Gets or Sets ValueAddedServices
    /// </summary>
    [DataMember(Name="valueAddedServices", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "valueAddedServices", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public ValueAddedServiceDetails ValueAddedServices { get; set; }

    /// <summary>
    /// Gets or Sets TaxDetails
    /// </summary>
    [DataMember(Name="taxDetails", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "taxDetails", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public TaxDetailList TaxDetails { get; set; }

    /// <summary>
    /// Gets or Sets ChannelDetails
    /// </summary>
    [DataMember(Name="channelDetails", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "channelDetails")]
    public ChannelDetails ChannelDetails { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class GetRatesRequest {\n");
      sb.Append("  ShipTo: ").Append(ShipTo).Append("\n");
      sb.Append("  ShipFrom: ").Append(ShipFrom).Append("\n");
      sb.Append("  ReturnTo: ").Append(ReturnTo).Append("\n");
      sb.Append("  ShipDate: ").Append(ShipDate).Append("\n");
      sb.Append("  Packages: ").Append(Packages).Append("\n");
      sb.Append("  ValueAddedServices: ").Append(ValueAddedServices).Append("\n");
      sb.Append("  TaxDetails: ").Append(TaxDetails).Append("\n");
      sb.Append("  ChannelDetails: ").Append(ChannelDetails).Append("\n");
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
