using System;
using System.Xml.Serialization;

namespace FikaAmazonAPI.ConstructFeed.Messages
{
    public class InventoryMessage
    {

        public string SKU { get; set; }

        public string FulfillmentCenterID { get; set; }
        public bool? Available { get; set; }
        public InventoryLookup? Lookup { get; set; }
        public int? Quantity { get; set; }
        [XmlElement(DataType = "date")]
        public DateTime? RestockDate { get; set; }

        public string FulfillmentLatency { get; set; }

        public InventorySwitchFulfillmentTo? SwitchFulfillmentTo { get; set; }

        /// <summary>
        /// Used by JSON_LISTINGS_FEED only. The Amazon marketplace ID this update targets.
        /// Optional; recommended for sellers operating in more than one marketplace so each
        /// availability record disambiguates which marketplace it applies to. Ignored by XML feeds.
        /// </summary>
        [XmlIgnore]
        public string MarketplaceID { get; set; }

        /// <summary>
        /// Used by JSON_LISTINGS_FEED only. Override for the fulfillment_availability
        /// fulfillment_channel_code value. Defaults to "DEFAULT" (merchant fulfilled). Ignored by XML feeds.
        /// </summary>
        [XmlIgnore]
        public string FulfillmentChannelCode { get; set; }

        /// <summary>
        /// Used by JSON_LISTINGS_FEED only. Override for the productType field on the message.
        /// Defaults to "PRODUCT" which works for inventory-only fulfillment_availability patches;
        /// set this to a specific product type when Amazon requires it. Ignored by XML feeds.
        /// </summary>
        [XmlIgnore]
        public string ProductType { get; set; }


        [XmlIgnore]
        public bool FulfillmentCenterIDSpecified { get { return !string.IsNullOrEmpty(FulfillmentCenterID); } }
        [XmlIgnore] 
        public bool FulfillmentLatencySpecified { get { return !string.IsNullOrEmpty(FulfillmentLatency); } }
        [XmlIgnore] 
        public bool AvailableSpecified { get { return Available.HasValue; } }
        [XmlIgnore] 
        public bool LookupSpecified { get { return Lookup.HasValue; } }
        [XmlIgnore] 
        public bool QuantitySpecified { get { return Quantity.HasValue; } }
        [XmlIgnore] 
        public bool RestockDateSpecified { get { return RestockDate.HasValue; } }
        [XmlIgnore] 
        public bool SwitchFulfillmentToSpecified { get { return SwitchFulfillmentTo.HasValue; } }

    }
    public enum InventoryLookup
    {

        /// <remarks/>
        FulfillmentNetwork,
    }
    public enum InventorySwitchFulfillmentTo
    {

        /// <remarks/>
        MFN,

        /// <remarks/>
        AFN,
    }
}
