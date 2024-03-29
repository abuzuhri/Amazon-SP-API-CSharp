/* 
 * Selling Partner API for Fulfillment Outbound
 *
 * The Selling Partner API for Fulfillment Outbound lets you create applications that help a seller fulfill Multi-Channel Fulfillment orders using their inventory in Amazon's fulfillment network. You can get information on both potential and existing fulfillment orders.
 *
 * OpenAPI spec version: v0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.FulfillmentOutbound
{
    /// <summary>
    /// Specifies whether the fulfillment order should ship now or have an order hold put on it.
    /// </summary>
    /// <value>Specifies whether the fulfillment order should ship now or have an order hold put on it.</value>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum FulfillmentAction
    {

        /// <summary>
        /// Enum Ship for value: Ship
        /// </summary>

        [EnumMember(Value = "Ship")]
        Ship,

        /// <summary>
        /// Enum Hold for value: Hold
        /// </summary>

        [EnumMember(Value = "Hold")]
        Hold
    }

}
