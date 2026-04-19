using FikaAmazonAPI.AmazonSpApiSDK.Models.ListingsItems;
using FikaAmazonAPI.Parameter.ListingItem;
using FikaAmazonAPI.Utils;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FikaAmazonAPI.Services
{
    public class ListingsItemService : RequestService
    {
        public ListingsItemService(AmazonCredential amazonCredential, ILoggerFactory? loggerFactory) : base(amazonCredential, loggerFactory)
        {
        }

        public Item GetListingsItem(ParameterGetListingsItem listingsItemParameters) =>
            Task.Run(() => GetListingsItemAsync(listingsItemParameters)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<Item> GetListingsItemAsync(ParameterGetListingsItem listingsItemParameters, CancellationToken cancellationToken = default)
        {
            listingsItemParameters.Check();
            var queryParameters = listingsItemParameters.getParameters();
            await CreateAuthorizedRequestAsync(ListingsItemsApiUrls.GetListingItem(listingsItemParameters.sellerId, listingsItemParameters.sku), RestSharp.Method.Get, queryParameters, parameter: listingsItemParameters, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<Item>(RateLimitType.ListingsItem_GetListingsItem, cancellationToken);
        }

        public List<Item> SearchListingsItems(ParameterSearchListingsItems parameterSearchListingsItems) =>
            Task.Run(() => SearchListingsItemsAsync(parameterSearchListingsItems)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<List<Item>> SearchListingsItemsAsync(ParameterSearchListingsItems parameterSearchListingsItems, CancellationToken cancellationToken = default)
        {
            var param = parameterSearchListingsItems.getParameters();
            await CreateAuthorizedRequestAsync(ListingsItemsApiUrls.SearchListingsItems(parameterSearchListingsItems.sellerId), RestSharp.Method.Get, param, cancellationToken: cancellationToken);

            List<Item> list = new List<Item>();

            var response = await ExecuteRequestAsync<ItemSearchResults>(RateLimitType.ListingsItem_SearchListingsItems, cancellationToken);
            list.AddRange(response.Items);

            var totalPages = 1;
            if (response.Pagination != null && !string.IsNullOrEmpty(response.Pagination.NextToken))
            {
                var nextToken = response.Pagination.NextToken;
                while (!string.IsNullOrEmpty(nextToken) && (!parameterSearchListingsItems.maxPages.HasValue || totalPages < parameterSearchListingsItems.maxPages.Value))
                {
                    parameterSearchListingsItems.pageToken = nextToken;
                    var getItemNextPage = await SearchListingsItemsByNextTokenAsync(parameterSearchListingsItems, cancellationToken);
                    list.AddRange(getItemNextPage.Items);
                    nextToken = getItemNextPage.Pagination?.NextToken;
                    totalPages++;
                }
            }

            return list;
        }

        private async Task<ItemSearchResults> SearchListingsItemsByNextTokenAsync(ParameterSearchListingsItems parameterSearchListingsItems, CancellationToken cancellationToken = default)
        {
            var param = parameterSearchListingsItems.getParameters();

            await CreateAuthorizedRequestAsync(ListingsItemsApiUrls.SearchListingsItems(parameterSearchListingsItems.sellerId), RestSharp.Method.Get, param, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<ItemSearchResults>(RateLimitType.ListingsItem_SearchListingsItems, cancellationToken);
        }

        public ListingsItemSubmissionResponse PutListingsItem(ParameterPutListingItem parameterPutListingItem) =>
            Task.Run(() => PutListingsItemAsync(parameterPutListingItem)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<ListingsItemSubmissionResponse> PutListingsItemAsync(ParameterPutListingItem parameterPutListingItem, CancellationToken cancellationToken = default)
        {
            if (parameterPutListingItem.marketplaceIds == null || parameterPutListingItem.marketplaceIds.Count == 0)
            {
                parameterPutListingItem.marketplaceIds = new List<string>() { AmazonCredential.MarketPlace.ID };
            }

            parameterPutListingItem.Check();
            var queryParameters = parameterPutListingItem.getParameters();
            await CreateAuthorizedRequestAsync(ListingsItemsApiUrls.PutListingItem(parameterPutListingItem.sellerId, parameterPutListingItem.sku), RestSharp.Method.Put, queryParameters, postJsonObj: parameterPutListingItem.listingsItemPutRequest, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<ListingsItemSubmissionResponse>(RateLimitType.ListingsItem_PutListingsItem, cancellationToken);
            return response;
        }

        public ListingsItemSubmissionResponse DeleteListingsItem(ParameterDeleteListingItem parameterDeleteListingItem) =>
            Task.Run(() => DeleteListingsItemAsync(parameterDeleteListingItem)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<ListingsItemSubmissionResponse> DeleteListingsItemAsync(ParameterDeleteListingItem parameterDeleteListingItem, CancellationToken cancellationToken = default)
        {
            parameterDeleteListingItem.Check();
            var queryParameters = parameterDeleteListingItem.getParameters();
            await CreateAuthorizedRequestAsync(ListingsItemsApiUrls.DeleteListingItem(parameterDeleteListingItem.sellerId, parameterDeleteListingItem.sku), RestSharp.Method.Delete, queryParameters: queryParameters, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<ListingsItemSubmissionResponse>(RateLimitType.ListingsItem_DeleteListingsItem, cancellationToken);
            return response;
        }

        public ListingsItemSubmissionResponse PatchListingsItem(ParameterPatchListingItem parameterPatchListingItem) =>
            Task.Run(() => PatchListingsItemAsync(parameterPatchListingItem)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<ListingsItemSubmissionResponse> PatchListingsItemAsync(ParameterPatchListingItem parameterPatchListingItem, CancellationToken cancellationToken = default)
        {
            parameterPatchListingItem.Check();
            var queryParameters = parameterPatchListingItem.getParameters();
            await CreateAuthorizedRequestAsync(ListingsItemsApiUrls.PatchListingItem(parameterPatchListingItem.sellerId, parameterPatchListingItem.sku), RestSharp.Method.Patch, queryParameters: queryParameters, postJsonObj: parameterPatchListingItem.listingsItemPatchRequest, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<ListingsItemSubmissionResponse>(RateLimitType.ListingsItem_PatchListingsItem, cancellationToken);
            return response;
        }
    }
}
