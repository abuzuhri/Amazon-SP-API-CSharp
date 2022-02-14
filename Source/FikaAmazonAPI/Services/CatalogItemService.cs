using FikaAmazonAPI.AmazonSpApiSDK.Models.CatalogItems;
using FikaAmazonAPI.Parameter.CatalogItems;
using FikaAmazonAPI.Utils;
using System.Collections.Generic;
using System.IO;

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
                parameterListCatalogItems.MarketplaceId = AmazonCredential.MarketPlace.ID;

            if (
                string.IsNullOrEmpty(parameterListCatalogItems.Query) &&
                string.IsNullOrEmpty(parameterListCatalogItems.SellerSKU) &&
                string.IsNullOrEmpty(parameterListCatalogItems.UPC) &&
                string.IsNullOrEmpty(parameterListCatalogItems.EAN) &&
                string.IsNullOrEmpty(parameterListCatalogItems.ISBN) &&
                string.IsNullOrEmpty(parameterListCatalogItems.JAN)
                )
                throw new InvalidDataException("At least one of Query, SellerSKU, UPC, EAN, ISBN, JAN is also required and cannot be null or empty");

            List<Item> list = new List<Item>();

            var parameter = parameterListCatalogItems.getParameters();

            CreateAuthorizedRequest(CategoryApiUrls.ListCatalogItems, RestSharp.Method.GET, parameter);
            var response = ExecuteRequest<ListCatalogItemsResponse>(RateLimitType.CatalogItems_ListCatalogItems);

            if (response != null && response.Payload != null && response.Payload.Items != null && response.Payload.Items.Count > 0)
                list.AddRange(response.Payload.Items);

            return list;
        }

        //[Obsolete("This method is will be deprecated in June 2022. Please use GetCatalogItem(ParameterGetCatalogItem parameterListCatalogItem) instead.")]
        public Item GetCatalogItem(string asin)
        {

            if (string.IsNullOrEmpty(asin))
                throw new InvalidDataException("asin is a required property and cannot be null");

            var param = new List<KeyValuePair<string, string>>();
            param.Add(new KeyValuePair<string, string>("MarketplaceId", AmazonCredential.MarketPlace.ID));

            CreateAuthorizedRequest(CategoryApiUrls.GetCatalogItem(asin), RestSharp.Method.GET, param);
            var response = ExecuteRequest<GetCatalogItemResponse>(RateLimitType.CatalogItems_GetCatalogItem);

            if (response != null && response.Payload != null)
                return response.Payload;

            return null;
        }

        //public Item GetCatalogItem(ParameterGetCatalogItem parameterListCatalogItem)
        //{

        //    if (string.IsNullOrEmpty(parameterListCatalogItem.ASIN))
        //        throw new InvalidDataException("asin is a required property and cannot be null");

        //    if (parameterListCatalogItem == null || parameterListCatalogItem.MarketplaceIds == null || parameterListCatalogItem.MarketplaceIds.Count == 0)
        //    {
        //        parameterListCatalogItem.MarketplaceIds.Add(MarketPlace.ID);
        //    }

        //    var param = parameterListCatalogItem.getParameters();

        //    CreateAuthorizedRequest(CategoryApiUrls.GetCatalogItem202012(parameterListCatalogItem.ASIN), RestSharp.Method.GET, param);
        //    var response = ExecuteRequest<Item>();

        //    return response;
        //}

        public IList<Categories> ListCatalogCategories(string ASIN,string SellerSKU=null,string MarketPlaceID = null)
        {
            if (string.IsNullOrEmpty(ASIN))
                throw new InvalidDataException("ASIN is a required property and cannot be null or empty");


            var param = new List<KeyValuePair<string, string>>();
            param.Add(new KeyValuePair<string, string>("MarketplaceId", MarketPlaceID ?? AmazonCredential.MarketPlace.ID));
            param.Add(new KeyValuePair<string, string>("ASIN", ASIN));
            if(!string.IsNullOrEmpty(SellerSKU))
                param.Add(new KeyValuePair<string, string>("SellerSKU", SellerSKU));

            CreateAuthorizedRequest(CategoryApiUrls.ListCatalogCategories, RestSharp.Method.GET, param);
            var response = ExecuteRequest<ListCatalogCategoriesResponse>(RateLimitType.CatalogItems_ListCatalogCategories);

            if (response != null && response.Payload != null)
                return response.Payload;

            return null;
        }

    }
}
