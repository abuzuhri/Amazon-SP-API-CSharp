using System.Collections.Generic;

namespace FikaAmazonAPI.ConstructFeed.JsonMessages
{
    public class PatcheValueData
    {
        public string value { get; set; }
        public string language_tag { get; set; }
        public string marketplace_id { get; set; }
        public string fulfillment_channel_code { get; set; }
        public int? quantity { get; set; }
        public int? lead_time_to_ship_max_days { get; set; }
        public string currency { get; set; }
        public IList<PriceData> our_price { get; set; }
        public IList<PriceData> minimum_seller_allowed_price { get; set; }
        public IList<PriceData> maximum_seller_allowed_price { get; set; }
    }
}
