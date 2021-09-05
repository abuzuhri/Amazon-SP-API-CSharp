using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace FikaAmazonAPI.ConstructFeed.Messages
{
    public partial class OfferMessage
    {
        public string SKU { get; set; }

        public StandardProductID StandardProductID { get; set; }

        public Condition Condition { get; set; }
    }
}
