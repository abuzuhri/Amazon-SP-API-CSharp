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
    /// The FulfillmentPolicy value specified when you submitted the createFulfillmentOrder operation.
    /// </summary>
    /// <value>The FulfillmentPolicy value specified when you submitted the createFulfillmentOrder operation.</value>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum FulfillmentPolicy
    {

        /// <summary>
        /// Enum FillOrKill for value: FillOrKill
        /// </summary>

        [EnumMember(Value = "FillOrKill")]
        FillOrKill,

        /// <summary>
        /// Enum FillAll for value: FillAll
        /// </summary>

        [EnumMember(Value = "FillAll")]
        FillAll,

        /// <summary>
        /// Enum FillAllAvailable for value: FillAllAvailable
        /// </summary>

        [EnumMember(Value = "FillAllAvailable")]
        FillAllAvailable
    }

}
