using FikaAmazonAPI.AmazonSpApiSDK.Models.Messaging;
using FikaAmazonAPI.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FikaAmazonAPI.Services
{
    public class MessagingService : RequestService
    {

        public MessagingService(AmazonCredential amazonCredential) : base(amazonCredential)
        {

        }

        public GetMessagingActionsForOrderResponse GetMessagingActionsForOrder(string amazonOrderId) =>
            Task.Run(() => GetMessagingActionsForOrderAsync(amazonOrderId)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<GetMessagingActionsForOrderResponse> GetMessagingActionsForOrderAsync(string amazonOrderId)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("marketplaceIds", AmazonCredential.MarketPlace.ID));

            await CreateAuthorizedRequestAsync(MessaginApiUrls.GetMessagingActionsForOrder(amazonOrderId), RestSharp.Method.Get, queryParameters);

            var response = await ExecuteRequestAsync<GetMessagingActionsForOrderResponse>(RateLimitType.Messaging_GetMessagingActionsForOrder);

            return response;

        }

        public bool ConfirmCustomizationDetails(string amazonOrderId, CreateConfirmCustomizationDetailsRequest createConfirmCustomizationDetailsRequest) =>
            Task.Run(() => ConfirmCustomizationDetailsAsync(amazonOrderId, createConfirmCustomizationDetailsRequest)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<bool> ConfirmCustomizationDetailsAsync(string amazonOrderId, CreateConfirmCustomizationDetailsRequest createConfirmCustomizationDetailsRequest)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("marketplaceIds", AmazonCredential.MarketPlace.ID));

            await CreateAuthorizedRequestAsync(MessaginApiUrls.ConfirmCustomizationDetails(amazonOrderId), RestSharp.Method.Post, queryParameters, postJsonObj: createConfirmCustomizationDetailsRequest);

            var response = await ExecuteRequestAsync<CreateConfirmCustomizationDetailsResponse>(RateLimitType.Messaging_ConfirmCustomizationDetails);
            if (response != null)
                return true;
            return false;

        }

        public bool CreateConfirmDeliveryDetails(string amazonOrderId, CreateConfirmCustomizationDetailsRequest createConfirmCustomizationDetailsRequest) =>
            Task.Run(() => CreateConfirmDeliveryDetailsAsync(amazonOrderId, createConfirmCustomizationDetailsRequest)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<bool> CreateConfirmDeliveryDetailsAsync(string amazonOrderId, CreateConfirmCustomizationDetailsRequest createConfirmCustomizationDetailsRequest)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("marketplaceIds", AmazonCredential.MarketPlace.ID));

            await CreateAuthorizedRequestAsync(MessaginApiUrls.CreateConfirmDeliveryDetails(amazonOrderId), RestSharp.Method.Post, queryParameters, postJsonObj: createConfirmCustomizationDetailsRequest);

            var response = await ExecuteRequestAsync<CreateConfirmCustomizationDetailsResponse>(RateLimitType.Messaging_CreateConfirmDeliveryDetails);
            if (response != null)
                return true;
            return false;

        }

        public bool CreateLegalDisclosure(string amazonOrderId, CreateLegalDisclosureRequest createLegalDisclosureRequest) =>
            Task.Run(() => CreateLegalDisclosureAsync(amazonOrderId, createLegalDisclosureRequest)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<bool> CreateLegalDisclosureAsync(string amazonOrderId, CreateLegalDisclosureRequest createLegalDisclosureRequest)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("marketplaceIds", AmazonCredential.MarketPlace.ID));

            await CreateAuthorizedRequestAsync(MessaginApiUrls.CreateLegalDisclosure(amazonOrderId), RestSharp.Method.Post, queryParameters, postJsonObj: createLegalDisclosureRequest);

            var response = await ExecuteRequestAsync<CreateLegalDisclosureResponse>(RateLimitType.Messaging_CreateLegalDisclosure);
            if (response != null)
                return true;
            return false;

        }

        public bool CreateNegativeFeedbackRemoval(string amazonOrderId) =>
            Task.Run(() => CreateNegativeFeedbackRemovalAsync(amazonOrderId)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<bool> CreateNegativeFeedbackRemovalAsync(string amazonOrderId)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("marketplaceIds", AmazonCredential.MarketPlace.ID));

            await CreateAuthorizedRequestAsync(MessaginApiUrls.CreateNegativeFeedbackRemoval(amazonOrderId), RestSharp.Method.Post, queryParameters);

            var response = await ExecuteRequestAsync<CreateNegativeFeedbackRemovalResponse>(RateLimitType.Messaging_CreateNegativeFeedbackRemoval);
            if (response != null)
                return true;
            return false;

        }

        public bool CreateConfirmOrderDetails(string amazonOrderId, CreateConfirmOrderDetailsRequest createConfirmOrderDetailsRequest) =>
            Task.Run(() => CreateConfirmOrderDetailsAsync(amazonOrderId, createConfirmOrderDetailsRequest)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<bool> CreateConfirmOrderDetailsAsync(string amazonOrderId, CreateConfirmOrderDetailsRequest createConfirmOrderDetailsRequest)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("marketplaceIds", AmazonCredential.MarketPlace.ID));

            await CreateAuthorizedRequestAsync(MessaginApiUrls.CreateConfirmOrderDetails(amazonOrderId), RestSharp.Method.Post, queryParameters, postJsonObj: createConfirmOrderDetailsRequest);

            var response = await ExecuteRequestAsync<CreateConfirmOrderDetailsResponse>(RateLimitType.Messaging_CreateConfirmOrderDetails);
            if (response != null)
                return true;
            return false;
        }

        public bool CreateConfirmServiceDetails(string amazonOrderId, CreateConfirmServiceDetailsRequest createConfirmServiceDetailsRequest) =>
            Task.Run(() => CreateConfirmServiceDetailsAsync(amazonOrderId, createConfirmServiceDetailsRequest)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<bool> CreateConfirmServiceDetailsAsync(string amazonOrderId, CreateConfirmServiceDetailsRequest createConfirmServiceDetailsRequest)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("marketplaceIds", AmazonCredential.MarketPlace.ID));

            await CreateAuthorizedRequestAsync(MessaginApiUrls.CreateConfirmServiceDetails(amazonOrderId), RestSharp.Method.Post, queryParameters, postJsonObj: createConfirmServiceDetailsRequest);

            var response = await ExecuteRequestAsync<CreateConfirmOrderDetailsResponse>(RateLimitType.Messaging_CreateConfirmServiceDetails);
            if (response != null)
                return true;
            return false;

        }

        public bool CreateAmazonMotors(string amazonOrderId, CreateAmazonMotorsRequest createAmazonMotorsRequest) =>
            Task.Run(() => CreateAmazonMotorsAsync(amazonOrderId, createAmazonMotorsRequest)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<bool> CreateAmazonMotorsAsync(string amazonOrderId, CreateAmazonMotorsRequest createAmazonMotorsRequest)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("marketplaceIds", AmazonCredential.MarketPlace.ID));
            await CreateAuthorizedRequestAsync(MessaginApiUrls.CreateAmazonMotors(amazonOrderId), RestSharp.Method.Post, queryParameters, postJsonObj: createAmazonMotorsRequest);

            var response = await ExecuteRequestAsync<CreateConfirmOrderDetailsResponse>(RateLimitType.Messaging_CreateAmazonMotors);
            if (response != null)
                return true;
            return false;
        }

        public bool CreateWarranty(string amazonOrderId, CreateWarrantyRequest createWarrantyRequest) =>
            Task.Run(() => CreateWarrantyAsync(amazonOrderId, createWarrantyRequest)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<bool> CreateWarrantyAsync(string amazonOrderId, CreateWarrantyRequest createWarrantyRequest)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("marketplaceIds", AmazonCredential.MarketPlace.ID));
            await CreateAuthorizedRequestAsync(MessaginApiUrls.CreateWarranty(amazonOrderId), RestSharp.Method.Post, queryParameters, postJsonObj: createWarrantyRequest);

            var response = await ExecuteRequestAsync<CreateConfirmOrderDetailsResponse>(RateLimitType.Messaging_CreateWarranty);
            if (response != null)
                return true;
            return false;
        }

        public GetAttributesResponse GetAttributes(string amazonOrderId) =>
            Task.Run(() => GetAttributesAsync(amazonOrderId)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<GetAttributesResponse> GetAttributesAsync(string amazonOrderId)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("marketplaceIds", AmazonCredential.MarketPlace.ID));

            await CreateAuthorizedRequestAsync(MessaginApiUrls.GetAttributes(amazonOrderId), RestSharp.Method.Get, queryParameters);

            var response = await ExecuteRequestAsync<GetAttributesResponse>(RateLimitType.Messaging_GetAttributes);

            return response;

        }
        public bool CreateDigitalAccessKey(string amazonOrderId, CreateDigitalAccessKeyRequest createDigitalAccessKeyRequest) =>
            Task.Run(() => CreateDigitalAccessKeyAsync(amazonOrderId, createDigitalAccessKeyRequest)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<bool> CreateDigitalAccessKeyAsync(string amazonOrderId, CreateDigitalAccessKeyRequest createDigitalAccessKeyRequest)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("marketplaceIds", AmazonCredential.MarketPlace.ID));
            await CreateAuthorizedRequestAsync(MessaginApiUrls.CreateDigitalAccessKey(amazonOrderId), RestSharp.Method.Post, queryParameters, postJsonObj: createDigitalAccessKeyRequest);

            var response = await ExecuteRequestAsync<CreateConfirmOrderDetailsResponse>(RateLimitType.Messaging_CreateDigitalAccessKey);
            if (response != null)
                return true;
            return false;
        }

        public bool CreateUnexpectedProblem(string amazonOrderId, CreateUnexpectedProblemRequest createUnexpectedProblemRequest) =>
            Task.Run(() => CreateUnexpectedProblemAsync(amazonOrderId, createUnexpectedProblemRequest)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<bool> CreateUnexpectedProblemAsync(string amazonOrderId, CreateUnexpectedProblemRequest createUnexpectedProblemRequest)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("marketplaceIds", AmazonCredential.MarketPlace.ID));
            await CreateAuthorizedRequestAsync(MessaginApiUrls.CreateUnexpectedProblem(amazonOrderId), RestSharp.Method.Post, queryParameters, postJsonObj: createUnexpectedProblemRequest);

            var response = await ExecuteRequestAsync<CreateUnexpectedProblemResponse>(RateLimitType.Messaging_CreateUnexpectedProblem);
            if (response != null)
                return true;
            return false;
        }



    }
}
