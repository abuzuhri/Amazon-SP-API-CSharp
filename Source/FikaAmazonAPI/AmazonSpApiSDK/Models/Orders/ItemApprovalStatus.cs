using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Orders
{
    /// <summary>
    /// Defines the possible status of an order item approval.
    /// </summary>
    /// <value>Defines the possible status of an order item approval.</value>

    [JsonConverter(typeof(StringEnumConverter))]

    public enum ItemApprovalStatus
    {

        /// <summary>
        /// Enum PENDINGSELLINGPARTNERAPPROVAL for value: PENDING_SELLING_PARTNER_APPROVAL
        /// </summary>
        [EnumMember(Value = "PENDING_SELLING_PARTNER_APPROVAL")]
        PENDINGSELLINGPARTNERAPPROVAL = 1,

        /// <summary>
        /// Enum PROCESSINGSELLINGPARTNERAPPROVAL for value: PROCESSING_SELLING_PARTNER_APPROVAL
        /// </summary>
        [EnumMember(Value = "PROCESSING_SELLING_PARTNER_APPROVAL")]
        PROCESSINGSELLINGPARTNERAPPROVAL = 2,

        /// <summary>
        /// Enum PENDINGAMAZONAPPROVAL for value: PENDING_AMAZON_APPROVAL
        /// </summary>
        [EnumMember(Value = "PENDING_AMAZON_APPROVAL")]
        PENDINGAMAZONAPPROVAL = 3,

        /// <summary>
        /// Enum APPROVED for value: APPROVED
        /// </summary>
        [EnumMember(Value = "APPROVED")]
        APPROVED = 4,

        /// <summary>
        /// Enum APPROVEDWITHCHANGES for value: APPROVED_WITH_CHANGES
        /// </summary>
        [EnumMember(Value = "APPROVED_WITH_CHANGES")]
        APPROVEDWITHCHANGES = 5,

        /// <summary>
        /// Enum DECLINED for value: DECLINED
        /// </summary>
        [EnumMember(Value = "DECLINED")]
        DECLINED = 6
    }

}
