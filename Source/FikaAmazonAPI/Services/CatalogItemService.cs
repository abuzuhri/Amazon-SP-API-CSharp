using FikaAmazonAPI.AmazonSpApiSDK.Models.CatalogItems;
using FikaAmazonAPI.AmazonSpApiSDK.Models.CatalogItems.V20220401;
using FikaAmazonAPI.Parameter.CatalogItems;
using FikaAmazonAPI.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Item = FikaAmazonAPI.AmazonSpApiSDK.Models.CatalogItems.Item;

namespace FikaAmazonAPI.Services
{
    public class CatalogItemService : RequestService
    {
        public CatalogItemService(AmazonCredential amazonCredential) : base(amazonCredential)
        {

        }

        [Obsolete("This method deprecated in June 2022. Please use SearchCatalogItems202204 instead.", false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public IList<Item> ListCatalogItems(ParameterListCatalogItems parameterListCatalogItems) =>
            Task.Run(() => ListCatalogItemsAsync(parameterListCatalogItems)).ConfigureAwait(false).GetAwaiter().GetResult();

        [Obsolete("This method deprecated in June 2022. Please use SearchCatalogItems202204Async instead.", false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
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

            await CreateAuthorizedRequestAsync(CategoryApiUrls.ListCatalogItems, RestSharp.Method.Get, parameter);
            var response = await ExecuteRequestAsync<ListCatalogItemsResponse>(RateLimitType.CatalogItems_ListCatalogItems);

            if (response != null && response.Payload != null && response.Payload.Items != null && response.Payload.Items.Count > 0)
                list.AddRange(response.Payload.Items);

            return list;
        }
        public String GetCatalogItemJson(string asin) =>
            Task.Run(() => GetCatalogItemAsyncJson(asin)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<String> GetCatalogItemAsyncJson(string asin)
        {

            if (string.IsNullOrEmpty(asin))
                throw new InvalidDataException("asin is a required property and cannot be null");

            var param = new List<KeyValuePair<string, string>>();
            param.Add(new KeyValuePair<string, string>("MarketplaceId", AmazonCredential.MarketPlace.ID));

            await CreateAuthorizedRequestAsync(CategoryApiUrls.GetCatalogItem(asin), RestSharp.Method.Get, param);
            var response = await ExecuteRequestAsync<GetCatalogItemResponse>(RateLimitType.CatalogItems_GetCatalogItem);

            if (response != null && response.Payload != null)
                return response.Payload.ToJson();

            return null;
        }
        [Obsolete("This method deprecated in June 2022. Please use GetCatalogItem(ParameterGetCatalogItem parameterListCatalogItem) instead.", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public Item GetCatalogItem(string asin) =>
            Task.Run(() => GetCatalogItemAsync(asin)).ConfigureAwait(false).GetAwaiter().GetResult();
        [Obsolete("This method deprecated in June 2022. Please use GetCatalogItem(ParameterGetCatalogItem parameterListCatalogItem) instead.", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public async Task<Item> GetCatalogItemAsync(string asin)
        {

            if (string.IsNullOrEmpty(asin))
                throw new InvalidDataException("asin is a required property and cannot be null");

            var param = new List<KeyValuePair<string, string>>();
            param.Add(new KeyValuePair<string, string>("MarketplaceId", AmazonCredential.MarketPlace.ID));

            await CreateAuthorizedRequestAsync(CategoryApiUrls.GetCatalogItem(asin), RestSharp.Method.Get, param);
            var response = await ExecuteRequestAsync<GetCatalogItemResponse>(RateLimitType.CatalogItems_GetCatalogItem);

            if (response != null && response.Payload != null)
                return response.Payload;

            return null;
        }


        public IList<Categories> ListCatalogCategories(string ASIN, string SellerSKU = null, string MarketPlaceID = null) =>
                    Task.Run(() => ListCatalogCategoriesAsync(ASIN, SellerSKU, MarketPlaceID)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<IList<Categories>> ListCatalogCategoriesAsync(string ASIN, string SellerSKU = null, string MarketPlaceID = null, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(ASIN))
                throw new InvalidDataException("ASIN is a required property and cannot be null or empty");


            var param = new List<KeyValuePair<string, string>>();
            param.Add(new KeyValuePair<string, string>("MarketplaceId", MarketPlaceID ?? AmazonCredential.MarketPlace.ID));
            param.Add(new KeyValuePair<string, string>("ASIN", ASIN));
            if (!string.IsNullOrEmpty(SellerSKU))
                param.Add(new KeyValuePair<string, string>("SellerSKU", SellerSKU));

            await CreateAuthorizedRequestAsync(CategoryApiUrls.ListCatalogCategories, RestSharp.Method.Get, param, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<ListCatalogCategoriesResponse>(RateLimitType.CatalogItems_ListCatalogCategories, cancellationToken);

            if (response != null && response.Payload != null)
                return response.Payload;

            return null;
        }

        #region 2022-04-01

        public AmazonSpApiSDK.Models.CatalogItems.V20220401.Item GetCatalogItem202204(ParameterGetCatalogItem parameterGetCatalogItem) =>
                    Task.Run(() => GetCatalogItem202204Async(parameterGetCatalogItem)).ConfigureAwait(false).GetAwaiter().GetResult();


        /// <summary>
        /// Retrieves details for an item in the Amazon catalog.
        /// </summary>
        public async Task<AmazonSpApiSDK.Models.CatalogItems.V20220401.Item> GetCatalogItem202204Async(ParameterGetCatalogItem parameterGetCatalogItem, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(parameterGetCatalogItem.ASIN))
                throw new InvalidDataException("asin is a required property and cannot be null");

            if (parameterGetCatalogItem == null || parameterGetCatalogItem.marketplaceIds == null || parameterGetCatalogItem.marketplaceIds.Count == 0)
            {
                parameterGetCatalogItem.marketplaceIds.Add(AmazonCredential.MarketPlace.ID);
            }

            var param = parameterGetCatalogItem.getParameters();

            await CreateAuthorizedRequestAsync(CategoryApiUrls.GetCatalogItem202204(parameterGetCatalogItem.ASIN), RestSharp.Method.Get, param, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<AmazonSpApiSDK.Models.CatalogItems.V20220401.Item>(RateLimitType.CatalogItems20220401_GetCatalogItem, cancellationToken);

            return response;
        }


        public IList<AmazonSpApiSDK.Models.CatalogItems.V20220401.Item> SearchCatalogItems202204(ParameterSearchCatalogItems202204 parameterSearchCatalogItems) =>
            Task.Run(() => SearchCatalogItems202204Async(parameterSearchCatalogItems)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<IList<AmazonSpApiSDK.Models.CatalogItems.V20220401.Item>> SearchCatalogItems202204Async(ParameterSearchCatalogItems202204 parameter, CancellationToken cancellationToken = default)
        {
            if (parameter.identifiers != null && parameter.identifiers.Count > 20)
                throw new InvalidDataException("identifiers max count 20");

            if (parameter.identifiers != null && parameter.identifiersType == null)
                throw new InvalidDataException("identifiersType required when identifiers are provided.");

            if (parameter.marketplaceIds == null || parameter.marketplaceIds.Count == 0)
            {
                parameter.marketplaceIds.Add(AmazonCredential.MarketPlace.ID);
            }

            List<AmazonSpApiSDK.Models.CatalogItems.V20220401.Item> list = new List<AmazonSpApiSDK.Models.CatalogItems.V20220401.Item>();

            var param = parameter.getParameters();

            await CreateAuthorizedRequestAsync(CategoryApiUrls.SearchCatalogItems202204, RestSharp.Method.Get, param, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<ItemSearchResults>(RateLimitType.CatalogItems20220401_SearchCatalogItems, cancellationToken);
            list.AddRange(response.Items);
            var totalPages = 1;
            if (response.Pagination != null && !string.IsNullOrEmpty(response.Pagination.NextToken))
            {
                var nextToken = response.Pagination.NextToken;
                while (!string.IsNullOrEmpty(nextToken) && (!parameter.maxPages.HasValue || totalPages < parameter.maxPages.Value))
                {
					parameter.pageToken = nextToken;
                    var getItemNextPage = await SearchCatalogItemsByNextToken202204Async(parameter, cancellationToken);
                    list.AddRange(getItemNextPage.Items);
                    nextToken = getItemNextPage.Pagination?.NextToken;
                    totalPages++;
                }
            }
            return list;
        }

        private async Task<ItemSearchResults> SearchCatalogItemsByNextToken202204Async(ParameterSearchCatalogItems202204 parameter, CancellationToken cancellationToken = default)
        {

            List<AmazonSpApiSDK.Models.CatalogItems.V20220401.Item> list = new List<AmazonSpApiSDK.Models.CatalogItems.V20220401.Item>();

            var param = parameter.getParameters();

            await CreateAuthorizedRequestAsync(CategoryApiUrls.SearchCatalogItems202204, RestSharp.Method.Get, param, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<ItemSearchResults>(RateLimitType.CatalogItems20220401_SearchCatalogItems, cancellationToken);
        }
        #endregion
    }
}
