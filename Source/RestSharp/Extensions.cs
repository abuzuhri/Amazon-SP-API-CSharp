using System.Collections.Generic;
using System.Linq;

namespace RestSharp
{
    public static class RestSharpExtensions
    {
        public static void RemoveParameter(this IList<Parameter> parameters, string name)
        {
            var items = parameters.Where(p => p.Name == name).ToList();
            foreach (var item in items)
                parameters.Remove(item);
        }
    }
}

namespace RestSharp.Serializers.NewtonsoftJson
{
    public static class RestClientExtensions
    {
        public static RestSharp.RestClient UseNewtonsoftJson(this RestSharp.RestClient client) => client;
    }
}
