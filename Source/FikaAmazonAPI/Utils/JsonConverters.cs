namespace FikaAmazonAPI.Utils
{
    class Iso8601DateTimeConverter : Newtonsoft.Json.Converters.IsoDateTimeConverter
    {
        public Iso8601DateTimeConverter()
        {
            base.DateTimeFormat = "yyyy-MM-ddTHH:mm:ssZ";
        }
    }
}