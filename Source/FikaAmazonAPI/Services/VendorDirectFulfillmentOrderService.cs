using FikaAmazonAPI.AmazonSpApiSDK.Models.VendorDirectFulfillmentOrders;
using FikaAmazonAPI.Parameter.VendorDirectFulfillmentOrders;
using FikaAmazonAPI.Utils;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FikaAmazonAPI.Services
{
    public class VendorDirectFulfillmentOrderService : RequestService
    {
        public VendorDirectFulfillmentOrderService(AmazonCredential amazonCredential) : base(amazonCredential)
        {

        }


        public List<Order> GetOrders(ParameterVendorDirectFulfillmentGetOrders searchOrderList) =>
            Task.Run(() => GetOrdersAsync(searchOrderList)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<List<Order>> GetOrdersAsync(ParameterVendorDirectFulfillmentGetOrders searchOrderList, CancellationToken cancellationToken = default)
        {
            var orderList = new List<Order>();

            var queryParameters = searchOrderList.getParameters();
            //await CreateAuthorizedRequestAsync(VendorDirectFulfillmentOrdersApiUrls.GetOrders, RestSharp.Method.GET, parameter: queryParameters);
            await CreateAuthorizedRequestAsync(VendorDirectFulfillmentOrdersApiUrls.GetOrders, RestSharp.Method.Get, queryParameters, parameter: searchOrderList, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<GetOrdersResponse>(RateLimitType.VendorDirectFulfillmentOrdersV1_GetOrders, cancellationToken);
            var nextToken = response.Payload?.Pagination?.NextToken;
            orderList.AddRange(response.Payload.Orders);
            while (!string.IsNullOrEmpty(nextToken))
            {
                searchOrderList.NextToken = nextToken;
                var orderPayload = await GetOrdersAsync(searchOrderList, cancellationToken);
                orderList.AddRange(orderPayload);
            }
            return orderList;
        }

        public Order GetOrder(string PurchaseOrderNumber) =>
            Task.Run(() => GetOrderAsync(PurchaseOrderNumber)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<Order> GetOrderAsync(string PurchaseOrderNumber, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(VendorDirectFulfillmentOrdersApiUrls.GetOrder(PurchaseOrderNumber), RestSharp.Method.Get, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<GetOrderResponse>(RateLimitType.VendorDirectFulfillmentOrdersV1_GetOrder, cancellationToken);
            return response.Payload;
        }

        public TransactionId SubmitAcknowledgement(SubmitAcknowledgementRequest submitAcknowledgementRequest) =>
            Task.Run(() => SubmitAcknowledgementAsync(submitAcknowledgementRequest)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<TransactionId> SubmitAcknowledgementAsync(SubmitAcknowledgementRequest submitAcknowledgementRequest, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(VendorDirectFulfillmentOrdersApiUrls.SubmitAcknowledgement, RestSharp.Method.Post, postJsonObj: submitAcknowledgementRequest, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<SubmitAcknowledgementResponse>(RateLimitType.VendorDirectFulfillmentOrdersV1_SubmitAcknowledgement, cancellationToken);
            return response.Payload;
        }

    }
}
