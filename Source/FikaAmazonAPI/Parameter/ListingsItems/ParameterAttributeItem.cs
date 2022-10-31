namespace FikaAmazonAPI.Parameter.ListingsItems
{
    public class ParameterAttributeItem
    {
        public string value { get; set; }

        public string language_tag { get; set; }

        public string marketplace_id { get; set; }

        // todo: Work out a generic way of doing this
        // don't serialize null properties
        public bool ShouldSerializelanguage_tag()
        {
            return (language_tag != null);
        }
    }
}
