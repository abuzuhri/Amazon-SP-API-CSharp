using FikaAmazonAPI.AmazonSpApiSDK.Models.CatalogItems;
using FikaAmazonAPI.Parameter.CatalogItems;
using FikaAmazonAPI.Utils;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace FikaAmazonAPI.Services
{
    public class CatalogItemService : RequestService
    {
        public CatalogItemService(AmazonCredential amazonCredential) : base(amazonCredential)
        {

        }


        public IList<Item> ListCatalogItems(ParameterListCatalogItems parameterListCatalogItems) =>
            Task.Run(() => ListCatalogItemsAsync(parameterListCatalogItems)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<IList<Item>> ListCatalogItemsAsync(ParameterListCatalogItems parameterListCatalogItems)
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

            await CreateAuthorizedRequestAsync(CategoryApiUrls.ListCatalogItems, RestSharp.Method.GET, parameter);
            var response = await ExecuteRequestAsync<ListCatalogItemsResponse>(RateLimitType.CatalogItems_ListCatalogItems);

            if (response != null && response.Payload != null && response.Payload.Items != null && response.Payload.Items.Count > 0)
                list.AddRange(response.Payload.Items);

            return list;
        }

        //[Obsolete("This method is will be deprecated in June 2022. Please use GetCatalogItem(ParameterGetCatalogItem parameterListCatalogItem) instead.")]
        public Item GetCatalogItem(string asin) =>
            Task.Run(() => GetCatalogItemAsync(asin)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<Item> GetCatalogItemAsync(string asin)
        {

            if (string.IsNullOrEmpty(asin))
                throw new InvalidDataException("asin is a required property and cannot be null");

            var param = new List<KeyValuePair<string, string>>();
            param.Add(new KeyValuePair<string, string>("MarketplaceId", AmazonCredential.MarketPlace.ID));

            await CreateAuthorizedRequestAsync(CategoryApiUrls.GetCatalogItem(asin), RestSharp.Method.GET, param);
            var response = await ExecuteRequestAsync<GetCatalogItemResponse>(RateLimitType.CatalogItems_GetCatalogItem);

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

        //    await CreateAuthorizedRequestAsync(CategoryApiUrls.GetCatalogItem202012(parameterListCatalogItem.ASIN), RestSharp.Method.GET, param);
        //    var response = await ExecuteRequestAsync<Item>();

        //    return response;
        //}

        public IList<Categories> ListCatalogCategories(string ASIN, string SellerSKU = null, string MarketPlaceID = null) =>
                    Task.Run(() => ListCatalogCategoriesAsync(ASIN, SellerSKU, MarketPlaceID)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<IList<Categories>> ListCatalogCategoriesAsync(string ASIN, string SellerSKU = null, string MarketPlaceID = null)
        {
            if (string.IsNullOrEmpty(ASIN))
                throw new InvalidDataException("ASIN is a required property and cannot be null or empty");


            var param = new List<KeyValuePair<string, string>>();
            param.Add(new KeyValuePair<string, string>("MarketplaceId", MarketPlaceID ?? AmazonCredential.MarketPlace.ID));
            param.Add(new KeyValuePair<string, string>("ASIN", ASIN));
            if (!string.IsNullOrEmpty(SellerSKU))
                param.Add(new KeyValuePair<string, string>("SellerSKU", SellerSKU));

            await CreateAuthorizedRequestAsync(CategoryApiUrls.ListCatalogCategories, RestSharp.Method.GET, param);
            var response = await ExecuteRequestAsync<ListCatalogCategoriesResponse>(RateLimitType.CatalogItems_ListCatalogCategories);

            if (response != null && response.Payload != null)
                return response.Payload;

            return null;
        }

        #region 2022-04-01

        /// <summary>
        /// Retrieves details for an item in the Amazon catalog.
        /// </summary>
        /// <param name="ASIN"></param>
        /// <param name="SellerSKU"></param>
        /// <param name="MarketPlaceID"></param>
        /// <returns></returns>
        /// <exception cref="InvalidDataException"></exception>
        public async Task<Item> GetCatalogItem202204Async(ParameterGetCatalogItem parameterGetCatalogItem)
        {
            if (string.IsNullOrEmpty(parameterGetCatalogItem.ASIN))
                throw new InvalidDataException("asin is a required property and cannot be null");

            if (parameterGetCatalogItem == null || parameterGetCatalogItem.marketplaceIds == null || parameterGetCatalogItem.marketplaceIds.Count == 0)
            {
                parameterGetCatalogItem.marketplaceIds.Add(AmazonCredential.MarketPlace.ID);
            }

            var param = parameterGetCatalogItem.getParameters();

            await CreateAuthorizedRequestAsync(CategoryApiUrls.GetCatalogItem202204(parameterGetCatalogItem.ASIN), RestSharp.Method.GET, param);
            var response = await ExecuteRequestAsync<Item>();

            return response;
        }
        #endregion
    }
}
