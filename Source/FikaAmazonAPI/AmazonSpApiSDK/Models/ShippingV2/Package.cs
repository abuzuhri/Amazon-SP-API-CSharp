using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ShippingV2 {

  /// <summary>
  /// A package to be shipped through a shipping service offering.
  /// </summary>
  [DataContract]
  public class Package {
    /// <summary>
    /// Gets or Sets Dimensions
    /// </summary>
    [DataMember(Name="dimensions", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "dimensions")]
    public Dimensions Dimensions { get; set; }

    /// <summary>
    /// Gets or Sets Weight
    /// </summary>
    [DataMember(Name="weight", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "weight")]
    public Weight Weight { get; set; }

    /// <summary>
    /// Gets or Sets InsuredValue
    /// </summary>
    [DataMember(Name="insuredValue", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "insuredValue")]
    public Currency InsuredValue { get; set; }

    /// <summary>
    /// When true, the package contains hazardous materials. Defaults to false.
    /// </summary>
    /// <value>When true, the package contains hazardous materials. Defaults to false.</value>
    [DataMember(Name="isHazmat", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "isHazmat", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool? IsHazmat { get; set; }

    /// <summary>
    /// The seller name displayed on the label.
    /// </summary>
    /// <value>The seller name displayed on the label.</value>
    [DataMember(Name="sellerDisplayName", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "sellerDisplayName", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string SellerDisplayName { get; set; }

    /// <summary>
    /// Gets or Sets Charges
    /// </summary>
    [DataMember(Name="charges", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "charges", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public ChargeList Charges { get; set; }

    /// <summary>
    /// Gets or Sets PackageClientReferenceId
    /// </summary>
    [DataMember(Name="packageClientReferenceId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "packageClientReferenceId")]
    public string PackageClientReferenceId { get; set; }

    /// <summary>
    /// Gets or Sets Items
    /// </summary>
    [DataMember(Name="items", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "items")]
    public ItemList Items { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class Package {\n");
      sb.Append("  Dimensions: ").Append(Dimensions).Append("\n");
      sb.Append("  Weight: ").Append(Weight).Append("\n");
      sb.Append("  InsuredValue: ").Append(InsuredValue).Append("\n");
      sb.Append("  IsHazmat: ").Append(IsHazmat).Append("\n");
      sb.Append("  SellerDisplayName: ").Append(SellerDisplayName).Append("\n");
      sb.Append("  Charges: ").Append(Charges).Append("\n");
      sb.Append("  PackageClientReferenceId: ").Append(PackageClientReferenceId).Append("\n");
      sb.Append("  Items: ").Append(Items).Append("\n");
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
