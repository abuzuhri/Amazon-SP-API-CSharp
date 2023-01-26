using System.Collections.Generic;
using System.Xml.Serialization;

namespace FikaAmazonAPI.ConstructFeed.Messages
{
    public partial class OrderFulfillmentMessage
    {
        [XmlElement(ElementName = "AmazonOrderID")]
        public string AmazonOrderID { get; set; }
        [XmlElement(ElementName = "MerchantOrderID")]
        public string MerchantOrderID { get; set; }
        [XmlElement(ElementName = "MerchantFulfillmentID")]
        public string MerchantFulfillmentID { get; set; }
        [XmlElement(ElementName = "FulfillmentDate")]
        public string FulfillmentDate { get; set; }
        [XmlElement(ElementName = "FulfillmentData")]
        public FulfillmentData FulfillmentData { get; set; }
        [XmlElement(ElementName = "CODCollectionMethod")]
        public string CODCollectionMethod { get; set; }
        [XmlElement(ElementName = "Item")]
        public List<Item> Item { get; set; }
        [XmlElement(ElementName = "ShipFromAddress")]
        public ShipFromAddress ShipFromAddress { get; set; }
    }


    [XmlRoot(ElementName = "FulfillmentData")]
    public class FulfillmentData
    {
        [XmlElement(ElementName = "CarrierCode")]
        public string CarrierCode { get; set; }
        [XmlElement(ElementName = "CarrierName")]
        public string CarrierName { get; set; }
        [XmlElement(ElementName = "ShippingMethod")]
        public string ShippingMethod { get; set; }
        [XmlElement(ElementName = "ShipperTrackingNumber")]
        public string ShipperTrackingNumber { get; set; }
    }

    [XmlRoot(ElementName = "Item")]
    public class Item
    {
        [XmlElement(ElementName = "AmazonOrderItemCode")]
        public string AmazonOrderItemCode { get; set; }
        [XmlElement(ElementName = "MerchantOrderItemID")]
        public string MerchantOrderItemID { get; set; }
        [XmlElement(ElementName = "MerchantFulfillmentItemID")]
        public string MerchantFulfillmentItemID { get; set; }
        [XmlElement(ElementName = "Quantity")]
        public int Quantity { get; set; }
        [XmlElement(ElementName = "TransparencyCode")]
        public List<string> TransparencyCode { get; set; }
    }

    [XmlRoot(ElementName = "ShipFromAddress")]
    public class ShipFromAddress
    {
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "FormalTitle")]
        public string FormalTitle { get; set; }
        [XmlElement(ElementName = "GivenName")]
        public string GivenName { get; set; }
        [XmlElement(ElementName = "FamilyName")]
        public string FamilyName { get; set; }
        [XmlElement(ElementName = "AddressFieldOne")]
        public string AddressFieldOne { get; set; }
        [XmlElement(ElementName = "AddressFieldTwo")]
        public string AddressFieldTwo { get; set; }
        [XmlElement(ElementName = "AddressFieldThree")]
        public string AddressFieldThree { get; set; }
        [XmlElement(ElementName = "City")]
        public string City { get; set; }
        [XmlElement(ElementName = "County")]
        public string County { get; set; }
        [XmlElement(ElementName = "StateOrRegion")]
        public string StateOrRegion { get; set; }
        [XmlElement(ElementName = "PostalCode")]
        public string PostalCode { get; set; }
        [XmlElement(ElementName = "CountryCode")]
        public string CountryCode { get; set; }
        [XmlElement(ElementName = "PhoneNumber")]
        public List<string> PhoneNumber { get; set; }
        [XmlElement(ElementName = "isDefaultShipping")]
        public string IsDefaultShipping { get; set; }
        [XmlElement(ElementName = "isDefaultBilling")]
        public string IsDefaultBilling { get; set; }
        [XmlElement(ElementName = "isDefaultOneClick")]
        public string IsDefaultOneClick { get; set; }
    }



}
