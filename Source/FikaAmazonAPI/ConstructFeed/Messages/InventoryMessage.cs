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

        public DateTime? RestockDate { get; set; }

        public string FulfillmentLatency { get; set; }

        public InventorySwitchFulfillmentTo? SwitchFulfillmentTo { get; set; }


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
