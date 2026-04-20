namespace FikaAmazonAPI.RestSharp
{
    public class Parameter
    {
        public string Name { get; set; }
        public object Value { get; set; }
        public ParameterType Type { get; set; }
    }

    public class HeaderParameter : Parameter {}
}
