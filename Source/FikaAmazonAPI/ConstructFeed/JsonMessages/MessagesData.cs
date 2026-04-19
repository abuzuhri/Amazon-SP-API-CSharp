using System.Collections.Generic;

namespace FikaAmazonAPI.ConstructFeed.JsonMessages
{
    public class MessagesData
    {
        public int messageId { get; set; }
        public string sku { get; set; }
        public string operationType { get; set; }
        public string productType { get; set; }
        public IList<PatcheData> patches { get; set; }
        //public IList<attributes> attributes { get; set; }

    }
}
