using System;
using System.Collections.Generic;
using System.Text;

namespace FikaAmazonAPI.ConstructFeed.Messages
{
    public class ProductMessage
    {
        public string SKU { get; set; }

        public StandardProductID StandardProductID { get; set; }

        public Condition Condition { get; set; }
    }
}
