using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ShippingV2 {

  /// <summary>
  /// Shipment type.
  /// </summary>
  /// <value>Shipment type.</value>
  [JsonConverter(typeof(StringEnumConverter))]
  public enum ShipmentType
  {

    [EnumMember(Value = "FORWARD")]
    FORWARD = 1,

    [EnumMember(Value = "RETURNS")]
    RETURNS = 2
  }

}

