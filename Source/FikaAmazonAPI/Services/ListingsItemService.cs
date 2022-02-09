using FikaAmazonAPI.AmazonSpApiSDK.Models.ListingsItems;
using FikaAmazonAPI.Parameter.ListingItem;

namespace FikaAmazonAPI.Services
{
    public class ListingsItemService : RequestService
    {
        public ListingsItemService(AmazonCredential amazonCredential) : base(amazonCredential)
        {
        }

        public Item GetListingsItem(ParameterGetListingsItem listingsItemParameters)
        {
            listingsItemParameters.Check();
            var queryParameters = listingsItemParameters.getParameters();
            CreateAuthorizedRequest(ListingsItemsApiUrls.GetListingItem(listingsItemParameters.sellerId, listingsItemParameters.sku), RestSharp.Method.GET, queryParameters, parameter: listingsItemParameters);
            return ExecuteRequest<Item>();
        }

        public ListingsItemSubmissionResponse PutListingsItem(ParameterPutListingItem parameterPutListingItem)
        {
            parameterPutListingItem.Check();
            var queryParameters = parameterPutListingItem.getParameters();
            CreateAuthorizedRequest(ListingsItemsApiUrls.PutListingItem(parameterPutListingItem.sellerId, parameterPutListingItem.sku), RestSharp.Method.PUT, postJsonObj: parameterPutListingItem.listingsItemPutRequest, queryParameters: queryParameters);
            var response = ExecuteRequest<ListingsItemSubmissionResponse>();
            return response;
        }

        public ListingsItemSubmissionResponse DeleteListingsItem(ParameterDeleteListingItem parameterDeleteListingItem)
        {
            parameterDeleteListingItem.Check();
            var queryParameters = parameterDeleteListingItem.getParameters();
            CreateAuthorizedRequest(ListingsItemsApiUrls.DeleteListingItem(parameterDeleteListingItem.sellerId, parameterDeleteListingItem.sku), RestSharp.Method.DELETE, queryParameters: queryParameters);
            var response = ExecuteRequest<ListingsItemSubmissionResponse>();
            return response;
        }

        public ListingsItemSubmissionResponse PatchListingsItem(ParameterPatchListingItem parameterPatchListingItem)
        {
            parameterPatchListingItem.Check();
            var queryParameters = parameterPatchListingItem.getParameters();
            CreateAuthorizedRequest(ListingsItemsApiUrls.PatchListingItem(parameterPatchListingItem.sellerId, parameterPatchListingItem.sku), RestSharp.Method.PATCH, queryParameters: queryParameters, postJsonObj: parameterPatchListingItem.listingsItemPatchRequest);
            var response = ExecuteRequest<ListingsItemSubmissionResponse>();
            return response;
        }
    }
}
