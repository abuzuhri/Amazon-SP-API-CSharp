using FikaAmazonAPI.AmazonSpApiSDK.Models.CatalogItems;
using FikaAmazonAPI.Parameter.CatalogItems;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FikaAmazonAPI.Services
{
    public class CatalogItemService : RequestService
    {
        public CatalogItemService(AmazonCredential amazonCredential) : base(amazonCredential)
        {

        }


        public IList<Item> ListCatalogItems(ParameterListCatalogItems parameterListCatalogItems)
        {
            if (string.IsNullOrEmpty(parameterListCatalogItems.MarketplaceId))
                throw new InvalidDataException("MarketplaceId is a required property and cannot be null or empty");

            List<Item> list = new List<Item>();

            var parameter = parameterListCatalogItems.getParameters();

            CreateAuthorizedRequest(CategoryApiUrls.ListCatalogItems, RestSharp.Method.GET, parameter);
            var response = ExecuteRequest<ListCatalogItemsResponse>();

            if (response != null && response.Payload != null && response.Payload.Items != null && response.Payload.Items.Count > 0)
                list.AddRange(response.Payload.Items);

            return list;
        }

        public Item GetCatalogItem(string MarketplaceId,string asin)
        {
            if(string.IsNullOrEmpty(asin))
                throw new InvalidDataException("asin is a required property and cannot be null");
            if (string.IsNullOrEmpty(MarketplaceId))
                throw new InvalidDataException("MarketplaceId is a required property and cannot be null");

            var param = new List<KeyValuePair<string, string>>();
            param.Add(new KeyValuePair<string, string>("MarketplaceId", MarketplaceId));

            CreateAuthorizedRequest(CategoryApiUrls.GetCatalogItem(asin), RestSharp.Method.GET, param);
            var response = ExecuteRequest<GetCatalogItemResponse>();

            if (response != null && response.Payload != null)
                return response.Payload;

            return null;
        }


        public IList<Categories> ListCatalogCategories(string MarketplaceId, string ASIN,string SellerSKU=null)
        {
            if (string.IsNullOrEmpty(ASIN))
                throw new InvalidDataException("ASIN is a required property and cannot be null or empty");
            if (string.IsNullOrEmpty(MarketplaceId))
                throw new InvalidDataException("MarketplaceId is a required property and cannot be null or empty");

            var param = new List<KeyValuePair<string, string>>();
            param.Add(new KeyValuePair<string, string>("MarketplaceId", MarketplaceId));
            param.Add(new KeyValuePair<string, string>("ASIN", ASIN));
            if(!string.IsNullOrEmpty(SellerSKU))
                param.Add(new KeyValuePair<string, string>("SellerSKU", SellerSKU));

            CreateAuthorizedRequest(CategoryApiUrls.ListCatalogCategories, RestSharp.Method.GET, param);
            var response = ExecuteRequest<ListCatalogCategoriesResponse>();

            if (response != null && response.Payload != null)
                return response.Payload;

            return null;
        }

    }
}
