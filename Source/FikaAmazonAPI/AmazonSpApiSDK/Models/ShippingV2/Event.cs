using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ShippingV2 {

  /// <summary>
  /// A tracking event.
  /// </summary>
  [DataContract]
  public class Event {
    /// <summary>
    /// Gets or Sets EventCode
    /// </summary>
    [DataMember(Name="eventCode", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "eventCode")]
    public EventCode EventCode { get; set; }

    /// <summary>
    /// Gets or Sets Location
    /// </summary>
    [DataMember(Name="location", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "location")]
    public Location Location { get; set; }

    /// <summary>
    /// The ISO 8601 formatted timestamp of the event.
    /// </summary>
    /// <value>The ISO 8601 formatted timestamp of the event.</value>
    [DataMember(Name="eventTime", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "eventTime")]
    public DateTime? EventTime { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class Event {\n");
      sb.Append("  EventCode: ").Append(EventCode).Append("\n");
      sb.Append("  Location: ").Append(Location).Append("\n");
      sb.Append("  EventTime: ").Append(EventTime).Append("\n");
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
