using FikaAmazonAPI.AmazonSpApiSDK.Models.VendorOrders;
using FikaAmazonAPI.Parameter.VendorOrders;
using FikaAmazonAPI.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FikaAmazonAPI.Services
{
    public class VendorOrderService : RequestService
    {
        public VendorOrderService(AmazonCredential amazonCredential) : base(amazonCredential)
        {

        }


        public List<Order> GetPurchaseOrders(ParameterVendorOrdersGetPurchaseOrders searchOrderList) =>
            Task.Run(() => GetPurchaseOrdersAsync(searchOrderList)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<List<Order>> GetPurchaseOrdersAsync(ParameterVendorOrdersGetPurchaseOrders searchOrderList)
        {
            var orderList = new List<Order>();
            string nextToken;
            do
            {
                var queryParameters = searchOrderList.getParameters();
                await CreateAuthorizedRequestAsync(VendorOrdersApiUrls.GetPurchaseOrders, RestSharp.Method.Get, queryParameters, parameter: searchOrderList);
                GetPurchaseOrdersResponse response = await ExecuteRequestAsync<GetPurchaseOrdersResponse>(RateLimitType.VendorOrdersV1_GetPurchaseOrders);
                nextToken = response.Payload?.Pagination?.NextToken;
                searchOrderList.nextToken = nextToken;
                orderList.AddRange(response.Payload.Orders);
            } while (!string.IsNullOrEmpty(nextToken));
            return orderList;
        }

        public List<OrderStatus> GetPurchaseOrdersStatus(ParameterVendorOrdersGetPurchaseOrdersStatus searchOrderList) =>
            Task.Run(() => GetPurchaseOrdersStatusAsync(searchOrderList)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<List<OrderStatus>> GetPurchaseOrdersStatusAsync(ParameterVendorOrdersGetPurchaseOrdersStatus searchOrderList)
        {
            var orderStatusList = new List<OrderStatus>();
            string nextToken;
            do
            {
                var queryParameters = searchOrderList.getParameters();
                await CreateAuthorizedRequestAsync(VendorOrdersApiUrls.GetPurchaseOrdersStatus, RestSharp.Method.Get, queryParameters, parameter: searchOrderList);
                GetPurchaseOrdersStatusResponse response = await ExecuteRequestAsync<GetPurchaseOrdersStatusResponse>(RateLimitType.VendorOrdersV1_GetPurchaseOrdersStatus);
                nextToken = response.Payload?.Pagination?.NextToken;
                searchOrderList.nextToken = nextToken;
                orderStatusList.AddRange(response.Payload.OrdersStatus);
            } while (!string.IsNullOrEmpty(nextToken));
            return orderStatusList;
        }

        public Order GetPurchaseOrder(string PurchaseOrderNumber) =>
            Task.Run(() => GetPurchaseOrderAsync(PurchaseOrderNumber)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<Order> GetPurchaseOrderAsync(string PurchaseOrderNumber)
        {
            await CreateAuthorizedRequestAsync(VendorOrdersApiUrls.GetPurchaseOrder(PurchaseOrderNumber), RestSharp.Method.Get);
            var response = await ExecuteRequestAsync<GetPurchaseOrderResponse>(RateLimitType.VendorOrdersV1_GetPurchaseOrder);
            return response.Payload;
        }

        public TransactionId SubmitAcknowledgement(SubmitAcknowledgementRequest submitAcknowledgementRequest) =>
            Task.Run(() => SubmitAcknowledgementAsync(submitAcknowledgementRequest)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<TransactionId> SubmitAcknowledgementAsync(SubmitAcknowledgementRequest submitAcknowledgementRequest)
        {
            await CreateAuthorizedRequestAsync(VendorOrdersApiUrls.SubmitAcknowledgement, RestSharp.Method.Post, postJsonObj: submitAcknowledgementRequest);
            var response = await ExecuteRequestAsync<SubmitAcknowledgementResponse>(RateLimitType.VendorOrdersV1_SubmitAcknowledgement);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

    }
}
