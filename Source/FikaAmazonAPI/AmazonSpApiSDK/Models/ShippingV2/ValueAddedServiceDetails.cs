using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ShippingV2 {

  /// <summary>
  /// A collection of supported value-added services.
  /// </summary>
  [DataContract]
  public class ValueAddedServiceDetails {
    /// <summary>
    /// Gets or Sets CollectOnDelivery
    /// </summary>
    [DataMember(Name="collectOnDelivery", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "collectOnDelivery")]
    public CollectOnDelivery CollectOnDelivery { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ValueAddedServiceDetails {\n");
      sb.Append("  CollectOnDelivery: ").Append(CollectOnDelivery).Append("\n");
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
