using System.Collections.Generic;

namespace FikaAmazonAPI.ConstructFeed.JsonMessages
{
    public class PriceData
    {
        public IList<SchedulePriceData> schedule { get; set; }
    }
    public class SchedulePriceData
    {
        public decimal value_with_tax { get; set; }
    }
}
