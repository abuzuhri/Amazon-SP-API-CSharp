using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.AplusContent
{
    /// <summary>
    /// Values for the <c>includedDataSet</c> query parameter on getContentDocument and
    /// listContentDocumentAsinRelations. Not all values are accepted by every endpoint —
    /// listContentDocumentAsinRelations only accepts METADATA.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AplusIncludedDataType
    {
        CONTENTS,
        METADATA
    }
}
