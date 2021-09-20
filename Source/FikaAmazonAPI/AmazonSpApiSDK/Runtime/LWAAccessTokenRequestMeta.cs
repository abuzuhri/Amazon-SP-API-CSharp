using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Runtime
{
    public class LWAAccessTokenRequestMeta
    {
        [JsonProperty(PropertyName = "grant_type")]
        public string GrantType { get; set; }

        [JsonProperty(PropertyName = "refresh_token")]
        public string RefreshToken { get; set; }

        [JsonProperty(PropertyName = "client_id")]
        public string ClientId { get; set; }

        [JsonProperty(PropertyName = "client_secret")]
        public string ClientSecret { get; set; }

        [JsonProperty(PropertyName = "scope")]
        public string Scope { get; set; }

        public override bool Equals(object obj)
        {
            LWAAccessTokenRequestMeta other = obj as LWAAccessTokenRequestMeta;

            return other != null &&
                GrantType == other.GrantType &&
                RefreshToken == other.RefreshToken &&
                ClientId == other.ClientId &&
                ClientSecret == other.ClientSecret &&
                Scope == other.Scope;
        }
    }
}
