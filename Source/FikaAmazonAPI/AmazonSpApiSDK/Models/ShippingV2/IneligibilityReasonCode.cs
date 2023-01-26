using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ShippingV2
{

    /// <summary>
    /// Reasons that make a shipment service offering ineligible.

    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum IneligibilityReasonCode
    {
        NO_COVERAGE,
        PICKUP_SLOT_RESTRICTION,
        UNSUPPORTED_VAS,
        VAS_COMBINATION_RESTRICTION,
        SIZE_RESTRICTIONS,
        WEIGHT_RESTRICTIONS,
        LATE_DELIVERY,
        PROGRAM_CONSTRAINTS,
        TERMS_AND_CONDITIONS_NOT_ACCEPTED,
        UNKNOWN
    }
}