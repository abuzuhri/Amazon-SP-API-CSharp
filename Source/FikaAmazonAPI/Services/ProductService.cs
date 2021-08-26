using AmazonSpApiSDK.Models;
using AmazonSpApiSDK.Models.CatalogItems;
using AmazonSpApiSDK.Models.Orders;
using FikaAmazonAPI.Utils;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace FikaAmazonAPI.Services
{
    public class ProductService : RequestService
    {
        public ProductService(AmazonCredential amazonCredential) : base(amazonCredential)
        {

        }

        public ItemList GetAll(List<KeyValuePair<string, string>> queryParameters = null)
        {
            CreateAuthorizedRequest(CategoryApiUrls.Items, RestSharp.Method.GET, queryParameters);
            var response = ExecuteRequest<ListCatalogItemsResponse>();
            return response.Payload.Items;
        }
    }
}
