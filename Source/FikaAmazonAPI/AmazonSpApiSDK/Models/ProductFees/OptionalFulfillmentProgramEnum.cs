using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.ProductFees
{
    /// <summary>
    /// An optional enrollment program to return the estimated fees when the offer is fulfilled by Amazon (IsAmazonFulfilled is set to true).
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum OptionalFulfillmentProgramEnum
    {
        /// <summary>
        /// Returns the standard Amazon fulfillment fees for the offer. This is the default.
        /// </summary>
        [EnumMember(Value = "FBA_CORE")]
        FBA_CORE,

        /// <summary>
        /// Returns the FBA Small and Light (SNL) fees for the offer. The SNL program offers reduced fulfillment costs on qualified items. To check item eligibility for the SNL program, use the getSmallAndLightEligibilityBySellerSKU operation of the FBA Small And Light API.
        /// </summary>
        [EnumMember(Value = "FBA_SNL")]
        FBA_SNL,

        /// <summary>
        /// Returns the cross-border European Fulfillment Network fees across EU countries for the offer.
        /// </summary>
        [EnumMember(Value = "FBA_EFN")]
        FBA_EFN
    }
}
