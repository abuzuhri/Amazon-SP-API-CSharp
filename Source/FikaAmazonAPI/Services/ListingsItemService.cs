using System;
using System.Collections.Generic;
using System.Text;
using FikaAmazonAPI.AmazonSpApiSDK.Models.ListingsItems;
using FikaAmazonAPI.Parameter.ListingsItems;
using FikaAmazonAPI.Utils;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.Services
{
    public class ListingsItemService : RequestService
    {
        public ListingsItemService(AmazonCredential amazonCredential) : base(amazonCredential)
        {

        }

        public Item GetListingsItem(string sellerId, string sku, ParameterGetListingsItem listingsItemParameters)
        {
            if (string.IsNullOrEmpty(sellerId))
                throw new ArgumentException($"'{nameof(sellerId)}' cannot be null or empty.", nameof(sellerId));

            if (string.IsNullOrEmpty(sku))
                throw new ArgumentException($"'{nameof(sku)}' cannot be null or empty.", nameof(sku));

            if (listingsItemParameters.includedData is null)
            {
                listingsItemParameters.includedData = new List<ListingsIncludedData>();
                listingsItemParameters.includedData.Add(ListingsIncludedData.Summaries);
            }
            if (listingsItemParameters.includedData.Count == 0)
                listingsItemParameters.includedData.Add(ListingsIncludedData.Summaries);
            var queryParameters = listingsItemParameters.getParameters(AmazonCredential.Environment == Environments.Sandbox);
            CreateAuthorizedRequest(ListingsItemsApiUrls.GetListingsItem(sellerId, sku), RestSharp.Method.GET, queryParameters, parameter: listingsItemParameters);
            var response = ExecuteRequest<Item>();

            return response;
        }
    }
}
