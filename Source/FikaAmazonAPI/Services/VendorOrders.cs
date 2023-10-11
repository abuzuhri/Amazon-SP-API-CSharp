using FikaAmazonAPI.AmazonSpApiSDK.Models.VendorOrders;
using FikaAmazonAPI.AmazonSpApiSDK.Models.VendorTransactions;
using FikaAmazonAPI.Parameter.VendorOrders;
using FikaAmazonAPI.Utils;
using System.Collections.Generic;
using System.Threading;
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
        public async Task<List<Order>> GetPurchaseOrdersAsync(ParameterVendorOrdersGetPurchaseOrders searchOrderList, CancellationToken cancellationToken = default)
        {
            var orderList = new List<Order>();
            string nextToken;
            do
            {
                var queryParameters = searchOrderList.getParameters();
                await CreateAuthorizedRequestAsync(VendorOrdersApiUrls.GetPurchaseOrders, RestSharp.Method.Get, queryParameters, parameter: searchOrderList, cancellationToken: cancellationToken);
                GetPurchaseOrdersResponse response = await ExecuteRequestAsync<GetPurchaseOrdersResponse>(RateLimitType.VendorOrdersV1_GetPurchaseOrders, cancellationToken);
                nextToken = response.Payload?.Pagination?.NextToken;
                searchOrderList.nextToken = nextToken;
                orderList.AddRange(response.Payload.Orders);
            } while (!string.IsNullOrEmpty(nextToken));
            return orderList;
        }

        public List<OrderStatus> GetPurchaseOrdersStatus(ParameterVendorOrdersGetPurchaseOrdersStatus searchOrderList) =>
            Task.Run(() => GetPurchaseOrdersStatusAsync(searchOrderList)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<List<OrderStatus>> GetPurchaseOrdersStatusAsync(ParameterVendorOrdersGetPurchaseOrdersStatus searchOrderList, CancellationToken cancellationToken = default)
        {
            var orderStatusList = new List<OrderStatus>();
            string nextToken;
            do
            {
                var queryParameters = searchOrderList.getParameters();
                await CreateAuthorizedRequestAsync(VendorOrdersApiUrls.GetPurchaseOrdersStatus, RestSharp.Method.Get, queryParameters, parameter: searchOrderList, cancellationToken: cancellationToken);
                GetPurchaseOrdersStatusResponse response = await ExecuteRequestAsync<GetPurchaseOrdersStatusResponse>(RateLimitType.VendorOrdersV1_GetPurchaseOrdersStatus, cancellationToken);
                nextToken = response.Payload?.Pagination?.NextToken;
                searchOrderList.nextToken = nextToken;
                orderStatusList.AddRange(response.Payload.OrdersStatus);
            } while (!string.IsNullOrEmpty(nextToken));
            return orderStatusList;
        }

        public Order GetPurchaseOrder(string PurchaseOrderNumber) =>
            Task.Run(() => GetPurchaseOrderAsync(PurchaseOrderNumber)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<Order> GetPurchaseOrderAsync(string PurchaseOrderNumber, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(VendorOrdersApiUrls.GetPurchaseOrder(PurchaseOrderNumber), RestSharp.Method.Get, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<GetPurchaseOrderResponse>(RateLimitType.VendorOrdersV1_GetPurchaseOrder, cancellationToken);
            return response.Payload;
        }

        public TransactionId SubmitAcknowledgement(SubmitAcknowledgementRequest submitAcknowledgementRequest) =>
            Task.Run(() => SubmitAcknowledgementAsync(submitAcknowledgementRequest)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<TransactionId> SubmitAcknowledgementAsync(SubmitAcknowledgementRequest submitAcknowledgementRequest, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(VendorOrdersApiUrls.SubmitAcknowledgement, RestSharp.Method.Post, postJsonObj: submitAcknowledgementRequest, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<SubmitAcknowledgementResponse>(RateLimitType.VendorOrdersV1_SubmitAcknowledgement, cancellationToken);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
    }
}
