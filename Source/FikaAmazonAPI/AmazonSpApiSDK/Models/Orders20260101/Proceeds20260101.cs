using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Code Generated then Edited from:
/// https://github.com/amzn/selling-partner-api-models/blob/main/models/orders-api-model/orders_2026-01-01.json
/// </summary>

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Orders20260101
{
    /// <summary>
    /// Order-level proceeds. Requires includedData=PROCEEDS.
    /// </summary>
    public class OrderProceeds
    {
        [JsonProperty("grandTotal")]
        public Money GrandTotal { get; set; }
    }

    /// <summary>
    /// Order item-level proceeds with breakdown structure.
    /// Requires includedData=PROCEEDS.
    /// </summary>
    public class OrderItemProceeds
    {
        [JsonProperty("proceedsTotal")]
        public Money ProceedsTotal { get; set; }

        [JsonProperty("breakdowns")]
        public IList<ProceedsBreakdown> Breakdowns { get; set; }
    }

    /// <summary>
    /// A financial breakdown entry. Type can be: ITEM, SHIPPING, DISCOUNT, TAX, COD_FEE, GIFT_WRAP.
    /// </summary>
    public class ProceedsBreakdown
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("subtotal")]
        public Money Subtotal { get; set; }

        [JsonProperty("detailedBreakdowns")]
        public IList<DetailedBreakdown> DetailedBreakdowns { get; set; }
    }

    /// <summary>
    /// A detailed sub-breakdown. Subtype can be: ITEM, SHIPPING, DISCOUNT, COD_FEE, GIFT_WRAP.
    /// </summary>
    public class DetailedBreakdown
    {
        [JsonProperty("subtype")]
        public string Subtype { get; set; }

        [JsonProperty("value")]
        public Money Value { get; set; }
    }
}
