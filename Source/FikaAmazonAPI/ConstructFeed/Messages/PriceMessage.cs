namespace FikaAmazonAPI.ConstructFeed.Messages
{
    public class PriceMessage
    {
        public string SKU { get; set; }

        public StandardPrice StandardPrice { get; set; }

        public Sale Sale { get; set; }
    }
}
