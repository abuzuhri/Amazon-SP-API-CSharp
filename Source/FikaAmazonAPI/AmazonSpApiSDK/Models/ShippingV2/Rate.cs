using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ShippingV2 {

  /// <summary>
  /// The details of a shipping service offering.
  /// </summary>
  [DataContract]
  public class Rate {
    /// <summary>
    /// Gets or Sets RateId
    /// </summary>
    [DataMember(Name="rateId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "rateId")]
    public string RateId { get; set; }

    /// <summary>
    /// Gets or Sets CarrierId
    /// </summary>
    [DataMember(Name="carrierId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "carrierId")]
    public string CarrierId { get; set; }

    /// <summary>
    /// Gets or Sets CarrierName
    /// </summary>
    [DataMember(Name="carrierName", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "carrierName")]
    public string CarrierName { get; set; }

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
    /// Gets or Sets BilledWeight
    /// </summary>
    [DataMember(Name="billedWeight", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "billedWeight")]
    public Weight BilledWeight { get; set; }

    /// <summary>
    /// Gets or Sets TotalCharge
    /// </summary>
    [DataMember(Name="totalCharge", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "totalCharge")]
    public Currency TotalCharge { get; set; }

    /// <summary>
    /// Gets or Sets Promise
    /// </summary>
    [DataMember(Name="promise", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "promise")]
    public Promise Promise { get; set; }

    /// <summary>
    /// Gets or Sets SupportedDocumentSpecifications
    /// </summary>
    [DataMember(Name="supportedDocumentSpecifications", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "supportedDocumentSpecifications")]
    public SupportedDocumentSpecificationList SupportedDocumentSpecifications { get; set; }

    /// <summary>
    /// Gets or Sets AvailableValueAddedServiceGroups
    /// </summary>
    [DataMember(Name="availableValueAddedServiceGroups", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "availableValueAddedServiceGroups")]
    public AvailableValueAddedServiceGroupList AvailableValueAddedServiceGroups { get; set; }

    /// <summary>
    /// When true, indicates that additional inputs are required to purchase this shipment service. You must then call the getAdditionalInputs operation to return the JSON schema to use when providing the additional inputs to the purchaseShipment operation.
    /// </summary>
    /// <value>When true, indicates that additional inputs are required to purchase this shipment service. You must then call the getAdditionalInputs operation to return the JSON schema to use when providing the additional inputs to the purchaseShipment operation.</value>
    [DataMember(Name="requiresAdditionalInputs", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "requiresAdditionalInputs")]
    public bool? RequiresAdditionalInputs { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class Rate {\n");
      sb.Append("  RateId: ").Append(RateId).Append("\n");
      sb.Append("  CarrierId: ").Append(CarrierId).Append("\n");
      sb.Append("  CarrierName: ").Append(CarrierName).Append("\n");
      sb.Append("  ServiceId: ").Append(ServiceId).Append("\n");
      sb.Append("  ServiceName: ").Append(ServiceName).Append("\n");
      sb.Append("  BilledWeight: ").Append(BilledWeight).Append("\n");
      sb.Append("  TotalCharge: ").Append(TotalCharge).Append("\n");
      sb.Append("  Promise: ").Append(Promise).Append("\n");
      sb.Append("  SupportedDocumentSpecifications: ").Append(SupportedDocumentSpecifications).Append("\n");
      sb.Append("  AvailableValueAddedServiceGroups: ").Append(AvailableValueAddedServiceGroups).Append("\n");
      sb.Append("  RequiresAdditionalInputs: ").Append(RequiresAdditionalInputs).Append("\n");
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
