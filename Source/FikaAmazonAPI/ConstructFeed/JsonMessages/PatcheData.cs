using System.Collections.Generic;

namespace FikaAmazonAPI.ConstructFeed.JsonMessages
{
    public class PatcheData
    {
        public string op { get; set; }
        public string path { get; set; }
        public IList<PatcheValueData> value { get; set; }
    }
}
