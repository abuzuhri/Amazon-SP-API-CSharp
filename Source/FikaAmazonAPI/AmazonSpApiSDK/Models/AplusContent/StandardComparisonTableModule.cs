using Newtonsoft.Json;
using System.Collections.Generic;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.AplusContent
{
    /// <summary>Standard product-comparison table.</summary>
    public class StandardComparisonTableModule
    {
        [JsonProperty("productColumns")]
        public List<StandardComparisonProductBlock> ProductColumns { get; set; }

        [JsonProperty("metricRowLabels")]
        public List<PlainTextItem> MetricRowLabels { get; set; }
    }
}
