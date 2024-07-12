using System.Collections.Generic;
using System.Xml.Serialization;
using FikaAmazonAPI.ConstructFeed.Messages;
using static FikaAmazonAPI.ConstructFeed.BaseXML;

namespace FikaAmazonAPI.ConstructFeed.Messages
{
    public partial class OrderAdjustmentMessage
    {
        [XmlElement(ElementName = "AmazonOrderID")]
        public string AmazonOrderID { get; set; }
        [XmlElement(ElementName = "MerchantFulfillmentID")]
        public string MerchantFulfillmentID { get; set; }

        [XmlElement(ElementName = "ActionType")]
        public AdjustmentActionType ActionType { get; set; }

        [XmlElement(ElementName = "CODCollectionMethod")]
        public CODCollectionMethod CODCollectionMethod { get; set; }

        [XmlElement(ElementName = "AdjustedItem")]
        public List<AdjustedItem> AdjustedItem { get; set; }
    }

    public class AdjustedItem
    {
        [XmlElement(ElementName = "AmazonOrderItemCode")]
        public string AmazonOrderItemCode { get; set; }
        [XmlElement(ElementName = "MerchantOrderItemID")]
        public string MerchantOrderItemID { get; set; }

        [XmlElement(ElementName = "MerchantAdjustmentItemID")]
        public string MerchantAdjustmentItemID { get; set; }

        [XmlElement(ElementName = "AdjustmentReason")]
        public AdjustmentReason AdjustmentReason { get; set; }

        [XmlElement(ElementName = "ItemPriceAdjustments")]
        public List<AdjustmentBuyerPrice> ItemPriceAdjustments { get; set; }

        [XmlElement(ElementName = "PromotionAdjustments")]
        public List<PromotionAdjustments> PromotionAdjustments { get; set; }

        [XmlElement(ElementName = "DirectPaymentAdjustments")]
        public List<DirectPaymentAdjustments> DirectPaymentAdjustments { get; set; }
    }

    public class AdjustmentBuyerPrice
    {
        [XmlElement(ElementName = "Component")]
        public List<AdjustmentBuyerPriceComponent> Component { get; set; }
    }

    public class AdjustmentBuyerPriceComponent
    { 
        [XmlElement(ElementName = "Type")]
        public AdjustmentBuyerTypePrice BuyerPriceType { get; set; }

        [XmlElement(ElementName = "Amount")]
        public CurrencyAmount Amount { get; set; }
    }

    public class PromotionAdjustments
    {
        [XmlElement(ElementName = "PromotionClaimCode")]
        public string PromotionClaimCode { get; set; }

        [XmlElement(ElementName = "MerchantPromotionID")]
        public string MerchantPromotionID { get; set; }

        [XmlElement(ElementName = "Component")]
        public List<PromotionAdjustmentComponent> Component { get; set; }
    }

    public class PromotionAdjustmentComponent
    {
        [XmlElement(ElementName = "Type")]
        public PromotionApplicationType PromotionType { get; set; }

        [XmlElement(ElementName = "AdjustmentCurrencyAmount")]
        public CurrencyAmount Amount { get; set; }
    }

    public class DirectPaymentAdjustmentsComponent
    {
        [XmlElement(ElementName = "Type")]
        public string DirectPaymentType { get; set; }

        [XmlElement(ElementName = "AdjustmentCurrencyAmount")]
        public CurrencyAmount Amount { get; set; }
    }

    public class DirectPaymentAdjustments
    {
        [XmlElement(ElementName = "Component")]
        public List<DirectPaymentAdjustmentsComponent> Component { get; set; }
    }

    public enum AdjustmentActionType
    {
        Refund,
        Cancel
    }

    public enum CODCollectionMethod
    {
        DirectPayment
    }

    public enum AdjustmentReason
    {
        NoInventory,
        CustomerReturn,
        GeneralAdjustment,
        CouldNotShip,
        DifferentItem,
        Abandoned,
        CustomerCancel,
        PriceError,
        ProductOutofStock,
        CustomerAddressIncorrect,
        Exchange,
        Other,
        CarrierCreditDecision,
        RiskAssessmentInformationNotValid,
        CarrierCoverageFailure,
        TransactionRecord,
        Undeliverable,
        RefusedDelivery
    }

    public enum AdjustmentBuyerTypePrice
    {
        Principal,
        Shipping,
        Tax,
        ShippingTax,
        RestockingFee,
        RestockingFeeTax,
        GiftWrap,
        GiftWrapTax,
        Surcharge,
        ReturnShipping,
        Goodwill,
        ExportCharge,
        COD,
        CODTax,
        Other,
        FreeReplacementReturnShipping
    }

    public enum PromotionApplicationType
    {
        Principal,
        Shipping
    }
}
