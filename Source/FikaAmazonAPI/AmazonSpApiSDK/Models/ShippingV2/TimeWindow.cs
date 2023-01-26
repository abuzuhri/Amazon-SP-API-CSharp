using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ShippingV2 {

  /// <summary>
  /// The start and end time that specifies the time interval of an event.
  /// </summary>
  [DataContract]
  public class TimeWindow {
    /// <summary>
    /// The start time of the time window.
    /// </summary>
    /// <value>The start time of the time window.</value>
    [DataMember(Name="startTime", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "startTime")]
    public DateTime? StartTime { get; set; }

    /// <summary>
    /// The end time of the time window.
    /// </summary>
    /// <value>The end time of the time window.</value>
    [DataMember(Name="endTime", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "endTime")]
    public DateTime? EndTime { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class TimeWindow {\n");
      sb.Append("  StartTime: ").Append(StartTime).Append("\n");
      sb.Append("  EndTime: ").Append(EndTime).Append("\n");
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
