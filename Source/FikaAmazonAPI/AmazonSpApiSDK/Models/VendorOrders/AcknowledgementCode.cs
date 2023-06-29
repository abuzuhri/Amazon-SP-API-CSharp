using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.VendorOrders
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AcknowledgementCode
    {
        /*
         *   Amazon interpretation is that the quantity stated in ACK02 will be immediatelyshipped / delivered on the stated date.
         */
        [EnumMember(Value = "Accepted")]
        Accepted,

        /*
         *  Amazon interpretation is that the quantity stated in ACK02 is back-ordered and willbe shipped / delivered on the stated date.
         */
        [EnumMember(Value = "Backordered")]
        Backordered,

        /*
         * Amazon interpretation is that the quantity stated in ACK02 will not be delivered toAmazon as part of this Purchase Order.
         * The Amazon nomenclature for this is "soft reject", meaning that the item will be reordered withnext order run. If you want to remove this item from being ordered you should use ACK code R2which will be a "hard reject", meaning that Amazon will restrict this item from being re-ordered.
         */
        [EnumMember(Value = "Rejected")]
        Rejected
    }
}
