using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ShippingV2
{

  /// <summary>
  /// The tracking event type.
  /// </summary>
  [DataContract]

  /// <summary>
  /// The tracking event type.
  /// </summary>
  /// <value>The tracking event type.</value>
  [JsonConverter(typeof(StringEnumConverter))]
  public enum EventCode
  {
    /// <summary>
    /// Enum ReadyForReceive for value: ReadyForReceive
    /// </summary>
    [EnumMember(Value = "ReadyForReceive")]
    ReadyForReceive = 1,
    /// <summary>
    /// Enum PickupDone for value: PickupDone
    /// </summary>
    [EnumMember(Value = "PickupDone")]
    PickupDone = 2,
    /// <summary>
    /// Enum Delivered for value: Delivered
    /// </summary>
    [EnumMember(Value = "Delivered")]
    Delivered = 3,
    /// <summary>
    /// Enum Departed for value: Departed
    /// </summary>
    [EnumMember(Value = "Departed")]
    Departed = 4,
    /// <summary>
    /// Enum DeliveryAttempted for value: DeliveryAttempted
    /// </summary>
    [EnumMember(Value = "DeliveryAttempted")]
    DeliveryAttempted = 5,
    /// <summary>
    /// Enum Lost for value: Lost
    /// </summary>
    [EnumMember(Value = "Lost")]
    Lost = 6,
    /// <summary>
    /// Enum OutForDelivery for value: OutForDelivery
    /// </summary>
    [EnumMember(Value = "OutForDelivery")]
    OutForDelivery = 7,
    /// <summary>
    /// Enum ArrivedAtCarrierFacility for value: ArrivedAtCarrierFacility
    /// </summary>
    [EnumMember(Value = "ArrivedAtCarrierFacility")]
    ArrivedAtCarrierFacility = 8,
    /// <summary>
    /// Enum Rejected for value: Rejected
    /// </summary>
    [EnumMember(Value = "Rejected")]
    Rejected = 9,
    /// <summary>
    /// Enum Undeliverable for value: Undeliverable
    /// </summary>
    [EnumMember(Value = "Undeliverable")]
    Undeliverable = 10,
    /// <summary>
    /// Enum PickupCancelled for value: PickupCancelled
    /// </summary>
    [EnumMember(Value = "PickupCancelled")]
    PickupCancelled = 11,
    /// <summary>
    /// Enum ReturnInitiated for value: ReturnInitiated
    /// </summary>
    [EnumMember(Value = "ReturnInitiated")]
    ReturnInitiated = 12,
    /// <summary>
    /// Enum AvailableForPickup for value: AvailableForPickup
    /// </summary>
    [EnumMember(Value = "AvailableForPickup")]
    AvailableForPickup = 13,
    /// <summary>
    /// Enum RecipientRequestedAlternateDeliveryTiming for value: RecipientRequestedAlternateDeliveryTiming
    /// </summary>
    [EnumMember(Value = "RecipientRequestedAlternateDeliveryTiming")]
    RecipientRequestedAlternateDeliveryTiming = 14,
    /// <summary>
    /// Enum PackageReceivedByCarrier for value: PackageReceivedByCarrier
    /// </summary>
    [EnumMember(Value = "PackageReceivedByCarrier")]
    PackageReceivedByCarrier = 15
  }

}