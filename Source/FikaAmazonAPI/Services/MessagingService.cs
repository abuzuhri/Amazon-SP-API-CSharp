using FikaAmazonAPI.AmazonSpApiSDK.Models.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace FikaAmazonAPI.Services
{
    public class MessagingService : RequestService
    {

        public MessagingService(AmazonCredential amazonCredential) : base(amazonCredential)
        {

        }

        public GetMessagingActionsForOrderResponse GetMessagingActionsForOrder(string amazonOrderId)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("marketplaceIds", AmazonCredential.MarketPlace.ID));

            CreateAuthorizedRequest(MessaginApiUrls.GetMessagingActionsForOrder(amazonOrderId, AmazonCredential.MarketPlace.ID), RestSharp.Method.GET, queryParameters);

            var response = ExecuteRequest<GetMessagingActionsForOrderResponse>();

            return response;

        }
        public bool ConfirmCustomizationDetails(string amazonOrderId, CreateConfirmCustomizationDetailsRequest createConfirmCustomizationDetailsRequest)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("marketplaceIds", AmazonCredential.MarketPlace.ID));

            CreateAuthorizedRequest(MessaginApiUrls.ConfirmCustomizationDetails(amazonOrderId), RestSharp.Method.POST, queryParameters, postJsonObj: createConfirmCustomizationDetailsRequest);

            var response = ExecuteRequest<CreateConfirmCustomizationDetailsResponse>();
            if (response != null)
                return true;
            return false;

        }
        public bool CreateConfirmDeliveryDetails(string amazonOrderId, CreateConfirmCustomizationDetailsRequest createConfirmCustomizationDetailsRequest)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("marketplaceIds", AmazonCredential.MarketPlace.ID));

            CreateAuthorizedRequest(MessaginApiUrls.CreateConfirmDeliveryDetails(amazonOrderId), RestSharp.Method.POST, queryParameters, postJsonObj: createConfirmCustomizationDetailsRequest);

            var response = ExecuteRequest<CreateConfirmCustomizationDetailsResponse>();
            if (response != null)
                return true;
            return false;

        }

        public bool CreateLegalDisclosure(string amazonOrderId, CreateLegalDisclosureRequest createLegalDisclosureRequest)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("marketplaceIds", AmazonCredential.MarketPlace.ID));

            CreateAuthorizedRequest(MessaginApiUrls.CreateLegalDisclosure(amazonOrderId), RestSharp.Method.POST, queryParameters, postJsonObj: createLegalDisclosureRequest);

            var response = ExecuteRequest<CreateLegalDisclosureResponse>();
            if (response != null)
                return true;
            return false;

        }
        public bool CreateNegativeFeedbackRemoval(string amazonOrderId)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("marketplaceIds", AmazonCredential.MarketPlace.ID));

            CreateAuthorizedRequest(MessaginApiUrls.CreateNegativeFeedbackRemoval(amazonOrderId), RestSharp.Method.POST, queryParameters);

            var response = ExecuteRequest<CreateNegativeFeedbackRemovalResponse>();
            if (response != null)
                return true;
            return false;

        }
        public bool CreateConfirmOrderDetails(string amazonOrderId, CreateConfirmOrderDetailsRequest createConfirmOrderDetailsRequest)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("marketplaceIds", AmazonCredential.MarketPlace.ID));

            CreateAuthorizedRequest(MessaginApiUrls.CreateConfirmOrderDetails(amazonOrderId), RestSharp.Method.POST, queryParameters, postJsonObj: createConfirmOrderDetailsRequest);

            var response = ExecuteRequest<CreateConfirmOrderDetailsResponse>();
            if (response != null)
                return true;
            return false;

        }
        public bool CreateConfirmServiceDetails(string amazonOrderId, CreateConfirmServiceDetailsRequest createConfirmServiceDetailsRequest)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("marketplaceIds", AmazonCredential.MarketPlace.ID));

            CreateAuthorizedRequest(MessaginApiUrls.CreateConfirmServiceDetails(amazonOrderId), RestSharp.Method.POST, queryParameters, postJsonObj: createConfirmServiceDetailsRequest);

            var response = ExecuteRequest<CreateConfirmOrderDetailsResponse>();
            if (response != null)
                return true;
            return false;

        }
        public bool CreateAmazonMotors(string amazonOrderId, CreateAmazonMotorsRequest createAmazonMotorsRequest)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("marketplaceIds", AmazonCredential.MarketPlace.ID));
            CreateAuthorizedRequest(MessaginApiUrls.CreateAmazonMotors(amazonOrderId), RestSharp.Method.POST, queryParameters, postJsonObj: createAmazonMotorsRequest);

            var response = ExecuteRequest<CreateConfirmOrderDetailsResponse>();
            if (response != null)
                return true;
            return false;
        }
        public bool CreateWarranty(string amazonOrderId, CreateWarrantyRequest createWarrantyRequest)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("marketplaceIds", AmazonCredential.MarketPlace.ID));
            CreateAuthorizedRequest(MessaginApiUrls.CreateWarranty(amazonOrderId), RestSharp.Method.POST, queryParameters, postJsonObj: createWarrantyRequest);

            var response = ExecuteRequest<CreateConfirmOrderDetailsResponse>();
            if (response != null)
                return true;
            return false;
        }
        public GetAttributesResponse GetAttributes(string amazonOrderId)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("marketplaceIds", AmazonCredential.MarketPlace.ID));

            CreateAuthorizedRequest(MessaginApiUrls.GetAttributes(amazonOrderId), RestSharp.Method.GET, queryParameters);

            var response = ExecuteRequest<GetAttributesResponse>();

            return response;

        }
        public bool CreateDigitalAccessKey(string amazonOrderId, CreateDigitalAccessKeyRequest createDigitalAccessKeyRequest)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("marketplaceIds", AmazonCredential.MarketPlace.ID));
            CreateAuthorizedRequest(MessaginApiUrls.CreateDigitalAccessKey(amazonOrderId), RestSharp.Method.POST, queryParameters, postJsonObj: createDigitalAccessKeyRequest);

            var response = ExecuteRequest<CreateConfirmOrderDetailsResponse>();
            if (response != null)
                return true;
            return false;
        }
        public bool CreateUnexpectedProblem(string amazonOrderId, CreateUnexpectedProblemRequest createUnexpectedProblemRequest)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("marketplaceIds", AmazonCredential.MarketPlace.ID));
            CreateAuthorizedRequest(MessaginApiUrls.CreateUnexpectedProblem(amazonOrderId), RestSharp.Method.POST, queryParameters, postJsonObj: createUnexpectedProblemRequest);

            var response = ExecuteRequest<CreateUnexpectedProblemResponse>();
            if (response != null)
                return true;
            return false;
        }



    }
}
