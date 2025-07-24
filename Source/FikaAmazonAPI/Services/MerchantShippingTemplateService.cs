
using FikaAmazonAPI.AmazonSpApiSDK.Models.ProductTypes;
using FikaAmazonAPI.AmazonSpApiSDK.Models.Token;
using FikaAmazonAPI.ConstructFeed.Messages;
using FikaAmazonAPI.Parameter.ProductTypes;
using FikaAmazonAPI.Utils;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.Services
{
    public class MerchantShippingTemplateService : RequestService
    { 
        private readonly HttpClient _httpClient = new HttpClient();
        private ProductTypeService _ProductType;

        public MerchantShippingTemplateService(AmazonCredential amazonCredential, ILoggerFactory? loggerFactory) : base(amazonCredential, loggerFactory)
        {
            this._ProductType = new ProductTypeService(amazonCredential, loggerFactory);
        }


        public Dictionary<string, string> GetMerchantShippingTemplates(GetDefinitionsProductTypeParameter parameter) =>
            Task.Run(() => GetMerchantShippingTemplatesAsync(parameter)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<Dictionary<string, string>> GetMerchantShippingTemplatesAsync(GetDefinitionsProductTypeParameter parameter, CancellationToken cancellationToken = default)
        {
            var productTypeDefinition = await _ProductType.GetDefinitionsProductTypeAsync(parameter, cancellationToken);

            if (productTypeDefinition.Schema == null || string.IsNullOrEmpty(productTypeDefinition.Schema.Link.ResourceUrl))
            {
                throw new Exception("Could not retrieve schema link resource url from the Product Type Definition!");
            }

            var schemaUrl = productTypeDefinition.Schema.Link.ResourceUrl;
            var schemaJson = await _httpClient.GetStringAsync(schemaUrl);
            var schema = JObject.Parse(schemaJson);

            var shippingGroup = schema["properties"]?["merchant_shipping_group"];
            if (shippingGroup == null)
            {
                return new Dictionary<string, string>(); // Or throw an exception if this is unexpected
            }

            var valueProperties = shippingGroup["items"]?["properties"]?["value"];
            if (valueProperties == null)
            {
                return new Dictionary<string, string>();
            }

            var enums = valueProperties["enum"]?.ToObject<List<string>>();
            var enumNames = valueProperties["enumNames"]?.ToObject<List<string>>();

            if (enums == null || enumNames == null || enums.Count() != enumNames.Count())
            {
                return new Dictionary<string, string>(); // Data is not as expected
            }

            var merchantShippingGroups = Enumerable.Range(0, enums.Count()).ToDictionary(i => enumNames[i], i => enums[i]);

            return merchantShippingGroups;
        }        

        public async Task PopulateMerchantShippingGroupNamesKeysAsync(GetDefinitionsProductTypeParameter parameter, CancellationToken cancellationToken = default)
        {
            var merchantShippingGroups = await GetMerchantShippingTemplatesAsync(parameter, cancellationToken);
            MerchantShippingGroupMessage.MerchantShippingGroupNamesKeys = merchantShippingGroups;
        }
    }
} 