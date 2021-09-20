namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Filters
{
    public class AmazonFilter
    {
        public int Limit { get; set; }
        public string NextPage { get; set; }

        public AmazonFilter(int limit, string href = null)
        {
            Limit = limit;
            NextPage = href;
        }
    }

}
