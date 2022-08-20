using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ShippingV2 {

  /// <summary>
  /// Detailed information for an ineligible shipping service offering.
  /// </summary>
  [DataContract]
  public class IneligibleRate {
    /// <summary>
    /// Gets or Sets ServiceId
    /// </summary>
    [DataMember(Name="serviceId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "serviceId")]
    public string ServiceId { get; set; }

    /// <summary>
    /// Gets or Sets ServiceName
    /// </summary>
    [DataMember(Name="serviceName", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "serviceName")]
    public string ServiceName { get; set; }

    /// <summary>
    /// Gets or Sets CarrierName
    /// </summary>
    [DataMember(Name="carrierName", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "carrierName")]
    public string CarrierName { get; set; }

    /// <summary>
    /// Gets or Sets CarrierId
    /// </summary>
    [DataMember(Name="carrierId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "carrierId")]
    public string CarrierId { get; set; }

    /// <summary>
    /// A list of reasons why a shipping service offering is ineligible.
    /// </summary>
    /// <value>A list of reasons why a shipping service offering is ineligible.</value>
    [DataMember(Name="ineligibilityReasons", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "ineligibilityReasons")]
    public List<IneligibilityReason> IneligibilityReasons { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class IneligibleRate {\n");
      sb.Append("  ServiceId: ").Append(ServiceId).Append("\n");
      sb.Append("  ServiceName: ").Append(ServiceName).Append("\n");
      sb.Append("  CarrierName: ").Append(CarrierName).Append("\n");
      sb.Append("  CarrierId: ").Append(CarrierId).Append("\n");
      sb.Append("  IneligibilityReasons: ").Append(IneligibilityReasons).Append("\n");
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
