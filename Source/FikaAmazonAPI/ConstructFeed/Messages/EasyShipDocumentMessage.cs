using System.Collections.Generic;
using System.Xml.Serialization;

namespace FikaAmazonAPI.ConstructFeed.Messages
{
    /// <summary>
    /// https://developer-docs.amazon.com/sp-api/docs/easyship-api-v2022-03-23-use-case-guide#step-1-submit-an-easy-ship-feed-request
    /// </summary>
    public class EasyShipDocumentMessage : BaseMessage
    {
        public EasyShipDocumentMessage() {}
        [XmlElement(ElementName = "AmazonOrderID")]
        public string AmazonOrderID { get; set; } = null!;
        [XmlElement(ElementName = "DocumentType")]
        public List<EasyShipDocumentType> DocumentTypes { get; set; }
    }

    public enum EasyShipDocumentType
    {
        ShippingLabel,
        Invoice,
        Warranty,
    }
}
