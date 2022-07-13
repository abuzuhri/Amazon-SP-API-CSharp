﻿using FikaAmazonAPI.AmazonSpApiSDK.Models.ListingsItems;
using FikaAmazonAPI.Parameter.ListingItem;
using FikaAmazonAPI.Utils;
using System.Threading.Tasks;

namespace FikaAmazonAPI.Services
{
    public class ListingsItemService : RequestService
    {
        public ListingsItemService(AmazonCredential amazonCredential) : base(amazonCredential)
        {
        }

        public Item GetListingsItem(ParameterGetListingsItem listingsItemParameters) =>
            Task.Run(() => GetListingsItemAsync(listingsItemParameters)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<Item> GetListingsItemAsync(ParameterGetListingsItem listingsItemParameters)
        {
            listingsItemParameters.Check();
            var queryParameters = listingsItemParameters.getParameters();
            await CreateAuthorizedRequestAsync(ListingsItemsApiUrls.GetListingItem(listingsItemParameters.sellerId, listingsItemParameters.sku), RestSharp.Method.Get, queryParameters, parameter: listingsItemParameters);
            return await ExecuteRequestAsync<Item>(RateLimitType.ListingsItem_GetListingsItem);
        }

        public ListingsItemSubmissionResponse PutListingsItem(ParameterPutListingItem parameterPutListingItem) =>
            Task.Run(() => PutListingsItemAsync(parameterPutListingItem)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<ListingsItemSubmissionResponse> PutListingsItemAsync(ParameterPutListingItem parameterPutListingItem)
        {
            parameterPutListingItem.Check();
            var queryParameters = parameterPutListingItem.getParameters();
            await CreateAuthorizedRequestAsync(ListingsItemsApiUrls.PutListingItem(parameterPutListingItem.sellerId, parameterPutListingItem.sku), RestSharp.Method.Put, postJsonObj: parameterPutListingItem.listingsItemPutRequest, queryParameters: queryParameters);
            var response = await ExecuteRequestAsync<ListingsItemSubmissionResponse>(RateLimitType.ListingsItem_PutListingsItem);
            return response;
        }

        public ListingsItemSubmissionResponse DeleteListingsItem(ParameterDeleteListingItem parameterDeleteListingItem) =>
            Task.Run(() => DeleteListingsItemAsync(parameterDeleteListingItem)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<ListingsItemSubmissionResponse> DeleteListingsItemAsync(ParameterDeleteListingItem parameterDeleteListingItem)
        {
            parameterDeleteListingItem.Check();
            var queryParameters = parameterDeleteListingItem.getParameters();
            await CreateAuthorizedRequestAsync(ListingsItemsApiUrls.DeleteListingItem(parameterDeleteListingItem.sellerId, parameterDeleteListingItem.sku), RestSharp.Method.Delete, queryParameters: queryParameters);
            var response = await ExecuteRequestAsync<ListingsItemSubmissionResponse>(RateLimitType.ListingsItem_DeleteListingsItem);
            return response;
        }

        public ListingsItemSubmissionResponse PatchListingsItem(ParameterPatchListingItem parameterPatchListingItem) =>
            Task.Run(() => PatchListingsItemAsync(parameterPatchListingItem)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<ListingsItemSubmissionResponse> PatchListingsItemAsync(ParameterPatchListingItem parameterPatchListingItem)
        {
            parameterPatchListingItem.Check();
            var queryParameters = parameterPatchListingItem.getParameters();
            await CreateAuthorizedRequestAsync(ListingsItemsApiUrls.PatchListingItem(parameterPatchListingItem.sellerId, parameterPatchListingItem.sku), RestSharp.Method.Patch, queryParameters: queryParameters, postJsonObj: parameterPatchListingItem.listingsItemPatchRequest);
            var response = await ExecuteRequestAsync<ListingsItemSubmissionResponse>(RateLimitType.ListingsItem_PatchListingsItem);
            return response;
        }
    }
}
