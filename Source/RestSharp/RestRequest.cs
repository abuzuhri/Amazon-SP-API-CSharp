using System.Collections.Generic;
using System.Linq;

namespace FikaAmazonAPI.RestSharp
{
    public class RestRequest
    {
        public string Resource { get; }
        public Method Method { get; }
        public List<Parameter> Parameters { get; } = new List<Parameter>();
        public string JsonBody { get; private set; }

        public RestRequest(string resource, Method method)
        {
            Resource = resource;
            Method = method;
        }

        public void AddQueryParameter(string name, string value) =>
            Parameters.Add(new Parameter { Name = name, Value = value, Type = ParameterType.QueryString });

        public void AddOrUpdateHeader(string name, string value)
        {
            var existing = Parameters.FirstOrDefault(p => p.Type == ParameterType.HttpHeader && p.Name == name);
            if (existing != null) existing.Value = value;
            else Parameters.Add(new Parameter { Name = name, Value = value, Type = ParameterType.HttpHeader });
        }

        public void AddJsonBody(string json) => JsonBody = json;

        public void RemoveParameter(string name)
        {
            Parameters.RemoveAll(p => p.Name == name);
        }
    }
}
