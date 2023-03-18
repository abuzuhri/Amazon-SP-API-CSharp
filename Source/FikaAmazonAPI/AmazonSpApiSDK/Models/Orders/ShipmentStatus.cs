using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Orders
{
    /// <summary>
    /// The shipment status to apply.
    /// </summary>
    /// <value>The shipment status to apply.</value>

    [JsonConverter(typeof(StringEnumConverter))]

    public enum ShipmentStatus
    {

        /// <summary>
        /// Enum ReadyForPickup for value: ReadyForPickup
        /// </summary>
        [EnumMember(Value = "ReadyForPickup")]
        ReadyForPickup = 1,

        /// <summary>
        /// Enum PickedUp for value: PickedUp
        /// </summary>
        [EnumMember(Value = "PickedUp")]
        PickedUp = 2,

        /// <summary>
        /// Enum RefusedPickup for value: RefusedPickup
        /// </summary>
        [EnumMember(Value = "RefusedPickup")]
        RefusedPickup = 3
    }

}