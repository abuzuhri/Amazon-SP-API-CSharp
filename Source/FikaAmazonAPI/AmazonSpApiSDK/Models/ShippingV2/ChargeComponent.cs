using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ShippingV2 {

  /// <summary>
  /// The type and amount of a charge applied on a package.
  /// </summary>
  [DataContract]
  public class ChargeComponent {
    /// <summary>
    /// Gets or Sets Amount
    /// </summary>
    [DataMember(Name="amount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "amount")]
    public Currency Amount { get; set; }

    /// <summary>
    /// The type of charge.
    /// </summary>
    /// <value>The type of charge.</value>
    [DataMember(Name="chargeType", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "chargeType")]
    public string ChargeType { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ChargeComponent {\n");
      sb.Append("  Amount: ").Append(Amount).Append("\n");
      sb.Append("  ChargeType: ").Append(ChargeType).Append("\n");
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
