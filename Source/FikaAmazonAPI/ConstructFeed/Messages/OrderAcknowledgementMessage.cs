using System.Collections.Generic;
using System.Xml.Serialization;

namespace FikaAmazonAPI.ConstructFeed.Messages
{
    public partial class OrderAcknowledgementMessage
    {
        [XmlElement(ElementName = "AmazonOrderID")]
        public string AmazonOrderID;

        [XmlElement(ElementName = "MerchantOrderID")]
        public string MerchantOrderID;

        [XmlElement(ElementName = "StatusCode")]
        public OrderAcknowledgementStatusCode StatusCode;

        [XmlElement(ElementName = "Item")]
        public List<OrderAcknowledgementItem> Item;
    }

    public class OrderAcknowledgementItem
    {

        [XmlElement(ElementName = "AmazonOrderItemCode")]
        public string AmazonOrderItemCode;

        [XmlElement(ElementName = "MerchantOrderItemID")]
        public string MerchantOrderItemID;

        [XmlElement(ElementName = "CancelReason")]
        public OrderAcknowledgementItemCancelReason CancelReason;

        [XmlElement(ElementName = "Quantity")]
        public string Quantity;

        [XmlIgnore()]
        public bool CancelReasonSpecified;
    }

    public enum OrderAcknowledgementStatusCode
    {
        Success,
        Failure,
    }

    public enum OrderAcknowledgementItemCancelReason
    {
        NoInventory,
        ShippingAddressUndeliverable,
        CustomerExchange,
        BuyerCanceled,
        GeneralAdjustment,
        CarrierCreditDecision,
        RiskAssessmentInformationNotValid,
        CarrierCoverageFailure,
        CustomerReturn,
        MerchandiseNotReceived,
        CannotVerifyInformation,
        PricingError,
        RejectOrder,
        WeatherDelay,
    }
}
