namespace FikaAmazonAPI.ConstructFeed.Messages
{
    public partial class ProductMessage
    {
        public string SKU { get; set; }

        public StandardProductID StandardProductID { get; set; }
        //public DescriptionData DescriptionData { get; set; }

        public Condition Condition { get; set; }
    }
}
