using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Code Generated then Edited from:
/// https://github.com/amzn/selling-partner-api-models/blob/main/models/orders-api-model/orders_2026-01-01.json
/// </summary>

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Orders20260101
{
    /// <summary>
    /// Represents an order item in the Orders API v2026-01-01.
    /// </summary>
    public class OrderItem20260101
    {
        [JsonProperty("orderItemId")]
        public string OrderItemId { get; set; }

        [JsonProperty("quantityOrdered")]
        public int? QuantityOrdered { get; set; }

        [JsonProperty("product")]
        public Product Product { get; set; }

        [JsonProperty("programs")]
        public IList<string> Programs { get; set; }

        [JsonProperty("fulfillment")]
        public OrderItemFulfillment Fulfillment { get; set; }

        [JsonProperty("proceeds")]
        public OrderItemProceeds Proceeds { get; set; }

        [JsonProperty("expense")]
        public OrderItemExpense Expense { get; set; }

        [JsonProperty("promotion")]
        public OrderItemPromotion Promotion { get; set; }

        [JsonProperty("cancellation")]
        public OrderItemCancellation Cancellation { get; set; }

        [JsonProperty("measurement")]
        public object Measurement { get; set; }
    }

    public class Product
    {
        [JsonProperty("asin")]
        public string Asin { get; set; }

        [JsonProperty("sellerSku")]
        public string SellerSku { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("condition")]
        public ProductCondition Condition { get; set; }

        [JsonProperty("price")]
        public ProductPrice Price { get; set; }

        [JsonProperty("customization")]
        public ProductCustomization Customization { get; set; }

        [JsonProperty("serialNumbers")]
        public IList<string> SerialNumbers { get; set; }
    }

    public class ProductCondition
    {
        [JsonProperty("conditionType")]
        public string ConditionType { get; set; }

        [JsonProperty("conditionSubtype")]
        public string ConditionSubtype { get; set; }

        [JsonProperty("conditionNote")]
        public string ConditionNote { get; set; }
    }

    public class ProductPrice
    {
        [JsonProperty("unitPrice")]
        public Money UnitPrice { get; set; }

        [JsonProperty("priceDesignation")]
        public string PriceDesignation { get; set; }
    }

    public class ProductCustomization
    {
        [JsonProperty("customizedUrl")]
        public string CustomizedUrl { get; set; }
    }

    public class OrderItemExpense
    {
        [JsonProperty("pointsCost")]
        public PointsCost PointsCost { get; set; }
    }

    public class PointsCost
    {
        [JsonProperty("pointsGranted")]
        public PointsGranted PointsGranted { get; set; }
    }

    public class PointsGranted
    {
        [JsonProperty("pointsNumber")]
        public int? PointsNumber { get; set; }

        [JsonProperty("pointsMonetaryValue")]
        public Money PointsMonetaryValue { get; set; }
    }

    public class OrderItemPromotion
    {
        [JsonProperty("breakdowns")]
        public IList<PromotionBreakdown> Breakdowns { get; set; }
    }

    public class PromotionBreakdown
    {
        [JsonProperty("promotionId")]
        public string PromotionId { get; set; }
    }

    public class OrderItemCancellation
    {
        [JsonProperty("requester")]
        public string Requester { get; set; }

        [JsonProperty("cancelReason")]
        public string CancelReason { get; set; }
    }
}
