using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ShippingV2
{

  /// <summary>
  /// A tracking event.
  /// </summary>
  [DataContract]
  public partial class Event : IEquatable<Event>, IValidatableObject
  {
    /// <summary>
    /// Gets or Sets EventCode
    /// </summary>
    [DataMember(Name = "eventCode", EmitDefaultValue = false)]
    [JsonProperty(PropertyName = "eventCode")]
    public EventCode EventCode { get; set; }

    /// <summary>
    /// Gets or Sets Location
    /// </summary>
    [DataMember(Name = "location", EmitDefaultValue = false)]
    [JsonProperty(PropertyName = "location")]
    public Location Location { get; set; }

    /// <summary>
    /// The ISO 8601 formatted timestamp of the event.
    /// </summary>
    /// <value>The ISO 8601 formatted timestamp of the event.</value>
    [DataMember(Name = "eventTime", EmitDefaultValue = false)]
    [JsonProperty(PropertyName = "eventTime")]
    public DateTime? EventTime { get; set; }

    /// <summary>
    /// Gets or Sets ShipmentType
    /// </summary>
    [DataMember(Name = "shipmentType", EmitDefaultValue = false)]
    [JsonProperty(PropertyName = "shipmentType", NullValueHandling = NullValueHandling.Ignore)]
    public ShipmentType? ShipmentType { get; set; }


    /// <summary>
    /// Returns the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()
    {
      var sb = new StringBuilder();
      sb.Append("class Event {\n");
      sb.Append("  EventCode: ").Append(EventCode).Append("\n");
      sb.Append("  Location: ").Append(Location).Append("\n");
      sb.Append("  EventTime: ").Append(EventTime).Append("\n");
      sb.Append("  ShipmentType: ").Append(ShipmentType).Append("\n");
      sb.Append("}\n");
      return sb.ToString();
    }

    /// <summary>
    /// Returns true if objects are equal
    /// </summary>
    /// <param name="input">Object to be compared</param>
    /// <returns>Boolean</returns>
    public override bool Equals(object input)
    {
      return this.Equals(input as Event);
    }

    /// <summary>
    /// Returns true if ModelEvent instances are equal
    /// </summary>
    /// <param name="input">Instance of ModelEvent to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(Event input)
    {
      if (input == null)
        return false;

      return
          (
              this.EventCode == input.EventCode ||
              (this.EventCode != null &&
              this.EventCode.Equals(input.EventCode))
          ) &&
          (
              this.Location == input.Location ||
              (this.Location != null &&
              this.Location.Equals(input.Location))
          ) &&
          (
              this.EventTime == input.EventTime ||
              (this.EventTime != null &&
              this.EventTime.Equals(input.EventTime))
          ) &&
          (
              this.ShipmentType == input.ShipmentType ||
              (this.ShipmentType != null &&
              this.ShipmentType.Equals(input.ShipmentType))
          );
    }

    /// <summary>
    /// Gets the hash code
    /// </summary>
    /// <returns>Hash code</returns>
    public override int GetHashCode()
    {
      unchecked // Overflow is fine, just wrap
      {
        int hashCode = 41;
        if (this.EventCode != null)
          hashCode = hashCode * 59 + this.EventCode.GetHashCode();
        if (this.Location != null)
          hashCode = hashCode * 59 + this.Location.GetHashCode();
        if (this.EventTime != null)
          hashCode = hashCode * 59 + this.EventTime.GetHashCode();
        if (this.ShipmentType != null)
          hashCode = hashCode * 59 + this.ShipmentType.GetHashCode();
        return hashCode;
      }
    }

    /// <summary>
    /// To validate all properties of the instance
    /// </summary>
    /// <param name="validationContext">Validation context</param>
    /// <returns>Validation Result</returns>
    IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
    {
      yield break;
    }

    /// <summary>
    /// Get the JSON string presentation of the object
    /// </summary>
    /// <returns>JSON string presentation of the object</returns>
    public string ToJson()
    {
      return JsonConvert.SerializeObject(this, Formatting.Indented);
    }

  }
}
