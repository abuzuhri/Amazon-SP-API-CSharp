using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ShippingV2 {

  /// <summary>
  /// An item in a package.
  /// </summary>
  [DataContract]
  public class Item {
    /// <summary>
    /// Gets or Sets ItemValue
    /// </summary>
    [DataMember(Name="itemValue", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "itemValue", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public Currency ItemValue { get; set; }

    /// <summary>
    /// The product description of the item.
    /// </summary>
    /// <value>The product description of the item.</value>
    [DataMember(Name="description", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "description", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Description { get; set; }

    /// <summary>
    /// A unique identifier for an item provided by the client.
    /// </summary>
    /// <value>A unique identifier for an item provided by the client.</value>
    [DataMember(Name="itemIdentifier", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "itemIdentifier", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string ItemIdentifier { get; set; }

    /// <summary>
    /// The number of units. This value is required.
    /// </summary>
    /// <value>The number of units. This value is required.</value>
    [DataMember(Name="quantity", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "quantity")]
    public int Quantity { get; set; }

    /// <summary>
    /// Gets or Sets Weight
    /// </summary>
    [DataMember(Name="weight", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "weight")]
    public Weight Weight { get; set; }

        /// <summary>
        /// When true, the item qualifies as hazardous materials (hazmat). Defaults to false.
        /// </summary>
        /// <value>When true, the item qualifies as hazardous materials (hazmat). Defaults to false.</value>
        [DataMember(Name = "isHazmat", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "isHazmat")]
        public bool IsHazmat { get; set; } = false;

    /// <summary>
    /// The product type of the item.
    /// </summary>
    /// <value>The product type of the item.</value>
    [DataMember(Name="productType", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "productType", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string ProductType { get; set; }

    /// <summary>
    /// Gets or Sets InvoiceDetails
    /// </summary>
    [DataMember(Name="invoiceDetails", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "invoiceDetails", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public InvoiceDetails InvoiceDetails { get; set; }

    /// <summary>
    /// A list of unique serial numbers in an Amazon package that can be used to guarantee non-fraudulent items. The number of serial numbers in the list must be less than or equal to the quantity of items being shipped. Only applicable when channel source is Amazon.
    /// </summary>
    /// <value>A list of unique serial numbers in an Amazon package that can be used to guarantee non-fraudulent items. The number of serial numbers in the list must be less than or equal to the quantity of items being shipped. Only applicable when channel source is Amazon.</value>
    [DataMember(Name="serialNumbers", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "serialNumbers", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public List<string> SerialNumbers { get; set; }

    /// <summary>
    /// Gets or Sets DirectFulfillmentItemIdentifiers
    /// </summary>
    [DataMember(Name="directFulfillmentItemIdentifiers", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "directFulfillmentItemIdentifiers", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public DirectFulfillmentItemIdentifiers DirectFulfillmentItemIdentifiers { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class Item {\n");
      sb.Append("  ItemValue: ").Append(ItemValue).Append("\n");
      sb.Append("  Description: ").Append(Description).Append("\n");
      sb.Append("  ItemIdentifier: ").Append(ItemIdentifier).Append("\n");
      sb.Append("  Quantity: ").Append(Quantity).Append("\n");
      sb.Append("  Weight: ").Append(Weight).Append("\n");
      sb.Append("  IsHazmat: ").Append(IsHazmat).Append("\n");
      sb.Append("  ProductType: ").Append(ProductType).Append("\n");
      sb.Append("  InvoiceDetails: ").Append(InvoiceDetails).Append("\n");
      sb.Append("  SerialNumbers: ").Append(SerialNumbers).Append("\n");
      sb.Append("  DirectFulfillmentItemIdentifiers: ").Append(DirectFulfillmentItemIdentifiers).Append("\n");
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
