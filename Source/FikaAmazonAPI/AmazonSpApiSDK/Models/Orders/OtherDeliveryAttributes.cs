using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Orders
{
    /// <summary>
    /// Miscellaneous delivery attributes associated with the shipping address.
    /// </summary>
    /// <value>Miscellaneous delivery attributes associated with the shipping address.</value>

    [JsonConverter(typeof(StringEnumConverter))]

    public enum OtherDeliveryAttributes
    {

        /// <summary>
        /// Enum HASACCESSPOINT for value: HAS_ACCESS_POINT
        /// </summary>
        [EnumMember(Value = "HAS_ACCESS_POINT")]
        HASACCESSPOINT = 1,

        /// <summary>
        /// Enum PALLETENABLED for value: PALLET_ENABLED
        /// </summary>
        [EnumMember(Value = "PALLET_ENABLED")]
        PALLETENABLED = 2,

        /// <summary>
        /// Enum PALLETDISABLED for value: PALLET_DISABLED
        /// </summary>
        [EnumMember(Value = "PALLET_DISABLED")]
        PALLETDISABLED = 3
    }

}