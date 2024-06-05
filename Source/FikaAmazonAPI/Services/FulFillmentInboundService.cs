using FikaAmazonAPI.AmazonSpApiSDK.Models.FulfillmentInbound;
using FikaAmazonAPI.Parameter.FulFillmentInbound;
using FikaAmazonAPI.Utils;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FikaAmazonAPI.Services
{
    public class FulFillmentInboundService : RequestService
    {
        public FulFillmentInboundService(AmazonCredential amazonCredential) : base(amazonCredential)
        {

        }

        #region GetListInboundPlans
        public List<InboundPlanSummary> GetListInboundPlans(ParameterGetListInboundPlans parameterGetListInboundPlans) =>
            Task.Run(() => GetListInboundPlansAsync(parameterGetListInboundPlans)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<List<InboundPlanSummary>> GetListInboundPlansAsync(ParameterGetListInboundPlans parameterGetListInboundPlans, CancellationToken cancellationToken = default)
        {
            var parameter = parameterGetListInboundPlans.getParameters();
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.GetListInboundPlans, RestSharp.Method.Get, parameter, cancellationToken: cancellationToken);

            List<InboundPlanSummary> list = new List<InboundPlanSummary>();

            var response = await ExecuteRequestAsync<ListInboundPlansResponse>(RateLimitType.FulFillmentInbound_GetListInboundPlans, cancellationToken);
            list.AddRange(response.InboundPlans);

            var totalPages = 1;
            if (response.Pagination != null && !string.IsNullOrEmpty(response.Pagination.NextToken))
            {
                var nextToken = response.Pagination.NextToken;
                while (!string.IsNullOrEmpty(nextToken) && (!parameterGetListInboundPlans.maxPages.HasValue || totalPages < parameterGetListInboundPlans.maxPages.Value))
                {
                    parameterGetListInboundPlans.PaginationToken = nextToken;
                    var getItemNextPage = await GetListInboundPlansByNextTokenAsync(parameterGetListInboundPlans, cancellationToken);
                    list.AddRange(getItemNextPage.InboundPlans);
                    nextToken = getItemNextPage.Pagination?.NextToken;
                    totalPages++;
                }
            }

            return list;
        }

        private async Task<ListInboundPlansResponse> GetListInboundPlansByNextTokenAsync(ParameterGetListInboundPlans parameterGetListInboundPlans, CancellationToken cancellationToken = default)
        {
            var parameter = parameterGetListInboundPlans.getParameters();

            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.GetListInboundPlans, RestSharp.Method.Get, parameter, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<ListInboundPlansResponse>(RateLimitType.FulFillmentInbound_GetListInboundPlans, cancellationToken);
        }
        #endregion

        #region CreateInboundPlan
        public CreateInboundPlanResponse CreateInboundPlan(CreateInboundPlanRequest createInboundPlanRequest) =>
           Task.Run(() => CreateInboundPlanAsync(createInboundPlanRequest)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<CreateInboundPlanResponse> CreateInboundPlanAsync(CreateInboundPlanRequest createInboundPlanRequest, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.CreateInboundPlan, RestSharp.Method.Post, postJsonObj: createInboundPlanRequest, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<CreateInboundPlanResponse>(RateLimitType.FulFillmentInbound_CreateInboundPlan, cancellationToken);
        }
        #endregion

        #region GetInboundPlan
        public InboundPlan GetInboundPlan(string inboundPlanId) =>
           Task.Run(() => GetInboundPlanAsync(inboundPlanId)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<InboundPlan> GetInboundPlanAsync(string inboundPlanId, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.GetInboundPlan(inboundPlanId), RestSharp.Method.Get, null, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<InboundPlan>(RateLimitType.FulFillmentInbound_GetInboundPlan, cancellationToken);
        }
        #endregion

        #region ListInboundPlanBoxes
        public List<Box> ListInboundPlanBoxes(ParameterListInboundPlan parameterListInboundPlan) =>
           Task.Run(() => ListInboundPlanBoxesAsync(parameterListInboundPlan)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<List<Box>> ListInboundPlanBoxesAsync(ParameterListInboundPlan parameterListInboundPlan, CancellationToken cancellationToken = default)
        {
            var parameter = parameterListInboundPlan.getParameters();
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.ListInboundPlanBoxes(parameterListInboundPlan.InboundPlanId), RestSharp.Method.Get, parameter, cancellationToken: cancellationToken);

            List<Box> list = new List<Box>();

            var response = await ExecuteRequestAsync<ListInboundPlanBoxesResponse>(RateLimitType.FulFillmentInbound_ListInboundPlanBoxes, cancellationToken);
            list.AddRange(response.Boxes);

            var totalPages = 1;
            if (response.Pagination != null && !string.IsNullOrEmpty(response.Pagination.NextToken))
            {
                var nextToken = response.Pagination.NextToken;
                while (!string.IsNullOrEmpty(nextToken) && (!parameterListInboundPlan.maxPages.HasValue || totalPages < parameterListInboundPlan.maxPages.Value))
                {
                    parameterListInboundPlan.PaginationToken = nextToken;
                    var getItemNextPage = await GetListInboundPlanBoxesByNextTokenAsync(parameterListInboundPlan, cancellationToken);
                    list.AddRange(getItemNextPage.Boxes);
                    nextToken = getItemNextPage.Pagination?.NextToken;
                    totalPages++;
                }
            }

            return list;
        }

        private async Task<ListInboundPlanBoxesResponse> GetListInboundPlanBoxesByNextTokenAsync(ParameterListInboundPlan parameterListInboundPlan, CancellationToken cancellationToken = default)
        {
            var parameter = parameterListInboundPlan.getParameters();
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.ListInboundPlanBoxes(parameterListInboundPlan.InboundPlanId), RestSharp.Method.Get, parameter, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<ListInboundPlanBoxesResponse>(RateLimitType.FulFillmentInbound_ListInboundPlanBoxes, cancellationToken);
        }
        #endregion

        #region CancelInboundPlan
        public CancelInboundPlanResponse CancelInboundPlan(string inboundPlanId) =>
         Task.Run(() => CancelInboundPlanAsync(inboundPlanId)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<CancelInboundPlanResponse> CancelInboundPlanAsync(string inboundPlanId, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.CancelInboundPlan(inboundPlanId), RestSharp.Method.Put, null, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<CancelInboundPlanResponse>(RateLimitType.FulFillmentInbound_CancelInboundPlan, cancellationToken);
        }
        #endregion

        #region ListInboundPlanItems
        public List<Item> ListInboundPlanItems(ParameterListInboundPlan parameterListInboundPlan) =>
        Task.Run(() => ListInboundPlanItemsAsync(parameterListInboundPlan)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<List<Item>> ListInboundPlanItemsAsync(ParameterListInboundPlan parameterListInboundPlan, CancellationToken cancellationToken = default)
        {
            var parameter = parameterListInboundPlan.getParameters();
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.ListInboundPlanItems(parameterListInboundPlan.InboundPlanId), RestSharp.Method.Get, parameter, cancellationToken: cancellationToken);

            List<Item> list = new List<Item>();

            var response = await ExecuteRequestAsync<ListInboundPlanItemsResponse>(RateLimitType.FulFillmentInbound_ListInboundPlanItems, cancellationToken);
            list.AddRange(response.Items);

            var totalPages = 1;
            if (response.Pagination != null && !string.IsNullOrEmpty(response.Pagination.NextToken))
            {
                var nextToken = response.Pagination.NextToken;
                while (!string.IsNullOrEmpty(nextToken) && (!parameterListInboundPlan.maxPages.HasValue || totalPages < parameterListInboundPlan.maxPages.Value))
                {
                    parameterListInboundPlan.PaginationToken = nextToken;
                    var getItemNextPage = await ListInboundPlanItemsByNextTokenAsync(parameterListInboundPlan, cancellationToken);
                    list.AddRange(getItemNextPage.Items);
                    nextToken = getItemNextPage.Pagination?.NextToken;
                    totalPages++;
                }
            }

            return list;
        }

        private async Task<ListInboundPlanItemsResponse> ListInboundPlanItemsByNextTokenAsync(ParameterListInboundPlan parameterListInboundPlan, CancellationToken cancellationToken = default)
        {
            var parameter = parameterListInboundPlan.getParameters();
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.ListInboundPlanItems(parameterListInboundPlan.InboundPlanId), RestSharp.Method.Get, parameter, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<ListInboundPlanItemsResponse>(RateLimitType.FulFillmentInbound_ListInboundPlanItems, cancellationToken);
        }
        #endregion

        #region SetPackingInformation
        public SetPackingInformationResponse SetPackingInformation(string inboundPlanId, SetPackingInformationRequest setPackingInformationRequest) =>
        Task.Run(() => SetPackingInformationAsync(inboundPlanId, setPackingInformationRequest)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<SetPackingInformationResponse> SetPackingInformationAsync(string inboundPlanId, SetPackingInformationRequest setPackingInformationRequest, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.SetPackingInformation(inboundPlanId), RestSharp.Method.Post, postJsonObj: setPackingInformationRequest, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<SetPackingInformationResponse>(RateLimitType.FulFillmentInbound_SetPackingInformation, cancellationToken);
        }
        #endregion

        #region ListPackingOptions
        public List<PackingOption> ListPackingOptions(ParameterListInboundPlan parameterListInboundPlan) =>
        Task.Run(() => ListPackingOptionsAsync(parameterListInboundPlan)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<List<PackingOption>> ListPackingOptionsAsync(ParameterListInboundPlan parameterListInboundPlan, CancellationToken cancellationToken = default)
        {
            var parameter = parameterListInboundPlan.getParameters();
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.ListPackingOptions(parameterListInboundPlan.InboundPlanId), RestSharp.Method.Get, parameter, cancellationToken: cancellationToken);

            List<PackingOption> list = new List<PackingOption>();

            var response = await ExecuteRequestAsync<ListPackingOptionsResponse>(RateLimitType.FulFillmentInbound_ListPackingOptions, cancellationToken);
            list.AddRange(response.PackingOptions);

            var totalPages = 1;
            if (response.Pagination != null && !string.IsNullOrEmpty(response.Pagination.NextToken))
            {
                var nextToken = response.Pagination.NextToken;
                while (!string.IsNullOrEmpty(nextToken) && (!parameterListInboundPlan.maxPages.HasValue || totalPages < parameterListInboundPlan.maxPages.Value))
                {
                    parameterListInboundPlan.PaginationToken = nextToken;
                    var getItemNextPage = await ListPackingOptionsAsyncByNextTokenAsync(parameterListInboundPlan, cancellationToken);
                    list.AddRange(getItemNextPage.PackingOptions);
                    nextToken = getItemNextPage.Pagination?.NextToken;
                    totalPages++;
                }
            }

            return list;

        }

        private async Task<ListPackingOptionsResponse> ListPackingOptionsAsyncByNextTokenAsync(ParameterListInboundPlan parameterListInboundPlan, CancellationToken cancellationToken = default)
        {
            var parameter = parameterListInboundPlan.getParameters();
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.ListPackingOptions(parameterListInboundPlan.InboundPlanId), RestSharp.Method.Get, parameter, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<ListPackingOptionsResponse>(RateLimitType.FulFillmentInbound_ListPackingOptions, cancellationToken);
        }
        #endregion

        #region GeneratePackingOptions
        public GeneratePackingOptionsResponse GeneratePackingOptions(string inboundPlanId) =>
        Task.Run(() => GeneratePackingOptionsAsync(inboundPlanId)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<GeneratePackingOptionsResponse> GeneratePackingOptionsAsync(string inboundPlanId, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.GeneratePackingOptions(inboundPlanId), RestSharp.Method.Post, null, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<GeneratePackingOptionsResponse>(RateLimitType.FulFillmentInbound_GeneratePackingOptions, cancellationToken);
        }
        #endregion

        #region ConfirmPackingOption
        public ConfirmPackingOptionResponse ConfirmPackingOption(ParameterConfirmPackingOption parameterConfirmPackingOption) =>
        Task.Run(() => ConfirmPackingOptionAsync(parameterConfirmPackingOption)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<ConfirmPackingOptionResponse> ConfirmPackingOptionAsync(ParameterConfirmPackingOption parameterConfirmPackingOption, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.ConfirmPackingOption(parameterConfirmPackingOption.InboundPlanId, parameterConfirmPackingOption.PackingOptionId), RestSharp.Method.Post, null, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<ConfirmPackingOptionResponse>(RateLimitType.FulFillmentInbound_ConfirmPackingOption, cancellationToken);
        }
        #endregion

        #region ListPackingGroupItems
        public List<Item> ListPackingGroupItems(ParameterListPackingGroupItems parameterListPackingGroupItems) =>
        Task.Run(() => ListPackingGroupItemsAsync(parameterListPackingGroupItems)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<List<Item>> ListPackingGroupItemsAsync(ParameterListPackingGroupItems parameterListPackingGroupItems, CancellationToken cancellationToken = default)
        {
            var parameter = parameterListPackingGroupItems.getParameters();
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.ListPackingGroupItems(parameterListPackingGroupItems.InboundPlanId, parameterListPackingGroupItems.PackingOptionId, parameterListPackingGroupItems.PackingGroupId), RestSharp.Method.Get, parameter, cancellationToken: cancellationToken);

            List<Item> list = new List<Item>();

            var response = await ExecuteRequestAsync<ListPackingGroupItemsResponse>(RateLimitType.FulFillmentInbound_ListPackingGroupItems, cancellationToken);
            list.AddRange(response.Items);

            var totalPages = 1;
            if (response.Pagination != null && !string.IsNullOrEmpty(response.Pagination.NextToken))
            {
                var nextToken = response.Pagination.NextToken;
                while (!string.IsNullOrEmpty(nextToken) && (!parameterListPackingGroupItems.maxPages.HasValue || totalPages < parameterListPackingGroupItems.maxPages.Value))
                {
                    parameterListPackingGroupItems.PaginationToken = nextToken;
                    var getItemNextPage = await ListPackingGroupItemsAsyncByNextTokenAsync(parameterListPackingGroupItems, cancellationToken);
                    list.AddRange(getItemNextPage.Items);
                    nextToken = getItemNextPage.Pagination?.NextToken;
                    totalPages++;
                }
            }
            return list;
        }


        private async Task<ListPackingGroupItemsResponse> ListPackingGroupItemsAsyncByNextTokenAsync(ParameterListPackingGroupItems parameterListPackingGroupItems, CancellationToken cancellationToken = default)
        {
            var parameter = parameterListPackingGroupItems.getParameters();
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.ListPackingGroupItems(parameterListPackingGroupItems.InboundPlanId, parameterListPackingGroupItems.PackingOptionId, parameterListPackingGroupItems.PackingGroupId), RestSharp.Method.Get, parameter, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<ListPackingGroupItemsResponse>(RateLimitType.FulFillmentInbound_ListPackingGroupItems, cancellationToken);
        }
        #endregion

        #region ListInboundPlanPallets
        public List<Pallet> ListInboundPlanPallets(ParameterListInboundPlan parameterListInboundPlan) =>
        Task.Run(() => ListInboundPlanPalletsAsync(parameterListInboundPlan)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<List<Pallet>> ListInboundPlanPalletsAsync(ParameterListInboundPlan parameterListInboundPlan, CancellationToken cancellationToken = default)
        {
            var parameter = parameterListInboundPlan.getParameters();
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.ListInboundPlanPallets(parameterListInboundPlan.InboundPlanId), RestSharp.Method.Get, parameter, cancellationToken: cancellationToken);

            List<Pallet> list = new List<Pallet>();

            var response = await ExecuteRequestAsync<ListInboundPlanPalletsResponse>(RateLimitType.FulFillmentInbound_ListInboundPlanPallets, cancellationToken);
            list.AddRange(response.Pallets);

            var totalPages = 1;
            if (response.Pagination != null && !string.IsNullOrEmpty(response.Pagination.NextToken))
            {
                var nextToken = response.Pagination.NextToken;
                while (!string.IsNullOrEmpty(nextToken) && (!parameterListInboundPlan.maxPages.HasValue || totalPages < parameterListInboundPlan.maxPages.Value))
                {
                    parameterListInboundPlan.PaginationToken = nextToken;
                    var getItemNextPage = await ListPackingGroupItemsAsyncByNextTokenAsync(parameterListInboundPlan, cancellationToken);
                    list.AddRange(getItemNextPage.Pallets);
                    nextToken = getItemNextPage.Pagination?.NextToken;
                    totalPages++;
                }
            }

            return list;

        }

        private async Task<ListInboundPlanPalletsResponse> ListPackingGroupItemsAsyncByNextTokenAsync(ParameterListInboundPlan parameterListInboundPlan, CancellationToken cancellationToken = default)
        {
            var parameter = parameterListInboundPlan.getParameters();
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.ListInboundPlanPallets(parameterListInboundPlan.InboundPlanId), RestSharp.Method.Get, parameter, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<ListInboundPlanPalletsResponse>(RateLimitType.FulFillmentInbound_ListInboundPlanPallets, cancellationToken);
        }
        #endregion

        #region ListPlacementOptions
        public List<PlacementOption> ListPlacementOptions(ParameterListInboundPlan parameterListInboundPlan) =>
        Task.Run(() => ListPlacementOptionsAsync(parameterListInboundPlan)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<List<PlacementOption>> ListPlacementOptionsAsync(ParameterListInboundPlan parameterListInboundPlan, CancellationToken cancellationToken = default)
        {
            var parameter = parameterListInboundPlan.getParameters();
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.ListPlacementOptions(parameterListInboundPlan.InboundPlanId), RestSharp.Method.Get, parameter, cancellationToken: cancellationToken);

            List<PlacementOption> list = new List<PlacementOption>();

            var response = await ExecuteRequestAsync<ListPlacementOptionsResponse>(RateLimitType.FulFillmentInbound_ListPlacementOptions, cancellationToken);
            list.AddRange(response.PlacementOptions);

            var totalPages = 1;
            if (response.Pagination != null && !string.IsNullOrEmpty(response.Pagination.NextToken))
            {
                var nextToken = response.Pagination.NextToken;
                while (!string.IsNullOrEmpty(nextToken) && (!parameterListInboundPlan.maxPages.HasValue || totalPages < parameterListInboundPlan.maxPages.Value))
                {
                    parameterListInboundPlan.PaginationToken = nextToken;
                    var getItemNextPage = await ListPlacementOptionsAsyncByNextTokenAsync(parameterListInboundPlan, cancellationToken);
                    list.AddRange(getItemNextPage.PlacementOptions);
                    nextToken = getItemNextPage.Pagination?.NextToken;
                    totalPages++;
                }
            }

            return list;
        }

        private async Task<ListPlacementOptionsResponse> ListPlacementOptionsAsyncByNextTokenAsync(ParameterListInboundPlan parameterListInboundPlan, CancellationToken cancellationToken = default)
        {
            var parameter = parameterListInboundPlan.getParameters();
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.ListPlacementOptions(parameterListInboundPlan.InboundPlanId), RestSharp.Method.Get, parameter, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<ListPlacementOptionsResponse>(RateLimitType.FulFillmentInbound_ListPlacementOptions, cancellationToken);
        }
        #endregion

        #region GeneratePlacementOptions
        public GeneratePlacementOptionsResponse GeneratePlacementOptions(string inboundPlanId, GeneratePlacementOptionsRequest generatePlacementOptionsRequest) =>
        Task.Run(() => GeneratePlacementOptionsAsync(inboundPlanId, generatePlacementOptionsRequest)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<GeneratePlacementOptionsResponse> GeneratePlacementOptionsAsync(string inboundPlanId, GeneratePlacementOptionsRequest generatePlacementOptionsRequest, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.GeneratePlacementOptions(inboundPlanId), RestSharp.Method.Post, postJsonObj: generatePlacementOptionsRequest, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<GeneratePlacementOptionsResponse>(RateLimitType.FulFillmentInbound_GeneratePlacementOptions, cancellationToken);
        }
        #endregion

        #region ConfirmPlacementOption
        public ConfirmPlacementOptionResponse ConfirmPlacementOption(string inboundPlanId, string placementOptionId) =>
        Task.Run(() => ConfirmPlacementOptionAsync(inboundPlanId, placementOptionId)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<ConfirmPlacementOptionResponse> ConfirmPlacementOptionAsync(string inboundPlanId, string placementOptionId, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.ConfirmPlacementOption(inboundPlanId, placementOptionId), RestSharp.Method.Post, null, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<ConfirmPlacementOptionResponse>(RateLimitType.FulFillmentInbound_ConfirmPlacementOption, cancellationToken);
        }
        #endregion

        #region GetShipment
        public AmazonSpApiSDK.Models.FulfillmentInbound.Shipment GetShipment(string inboundPlanId, string shipmentId) =>
        Task.Run(() => GetShipmentAsync(inboundPlanId, shipmentId)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<AmazonSpApiSDK.Models.FulfillmentInbound.Shipment> GetShipmentAsync(string inboundPlanId, string shipmentId, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.GetShipment(inboundPlanId, shipmentId), RestSharp.Method.Get, null, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<AmazonSpApiSDK.Models.FulfillmentInbound.Shipment>(RateLimitType.FulFillmentInbound_GetShipment, cancellationToken);
        }
        #endregion

        #region GetDeliveryChallanDocument
        public GetDeliveryChallanDocumentResponse GetDeliveryChallanDocument(string inboundPlanId, string shipmentId) =>
        Task.Run(() => GetDeliveryChallanDocumentAsync(inboundPlanId, shipmentId)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<GetDeliveryChallanDocumentResponse> GetDeliveryChallanDocumentAsync(string inboundPlanId, string shipmentId, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.GetDeliveryChallanDocument(inboundPlanId, shipmentId), RestSharp.Method.Get, null, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<GetDeliveryChallanDocumentResponse>(RateLimitType.FulFillmentInbound_GetDeliveryChallanDocument, cancellationToken);
        }
        #endregion

        #region GetSelfShipAppointmentSlots
        public List<SelfShipAppointmentSlotsAvailability> GetSelfShipAppointmentSlots(string shipmentId, ParameterListInboundPlan parameterListInboundPlan) =>
        Task.Run(() => GetSelfShipAppointmentSlotsAsync(shipmentId, parameterListInboundPlan)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<List<SelfShipAppointmentSlotsAvailability>> GetSelfShipAppointmentSlotsAsync(string shipmentId, ParameterListInboundPlan parameterListInboundPlan, CancellationToken cancellationToken = default)
        {
            var parameter = parameterListInboundPlan.getParameters();
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.GetSelfShipAppointmentSlots(parameterListInboundPlan.InboundPlanId, shipmentId), RestSharp.Method.Get, parameter, cancellationToken: cancellationToken);

            List<SelfShipAppointmentSlotsAvailability> list = new List<SelfShipAppointmentSlotsAvailability>();

            var response = await ExecuteRequestAsync<GetSelfShipAppointmentSlotsResponse>(RateLimitType.FulFillmentInbound_GetSelfShipAppointmentSlots, cancellationToken);
            list.Add(response.SelfShipAppointmentSlotsAvailability);

            var totalPages = 1;
            if (response.Pagination != null && !string.IsNullOrEmpty(response.Pagination.NextToken))
            {
                var nextToken = response.Pagination.NextToken;
                while (!string.IsNullOrEmpty(nextToken) && (!parameterListInboundPlan.maxPages.HasValue || totalPages < parameterListInboundPlan.maxPages.Value))
                {
                    parameterListInboundPlan.PaginationToken = nextToken;
                    var getItemNextPage = await GetSelfShipAppointmentSlotsByNextTokenAsync(shipmentId, parameterListInboundPlan, cancellationToken);
                    list.Add(getItemNextPage.SelfShipAppointmentSlotsAvailability);
                    nextToken = getItemNextPage.Pagination?.NextToken;
                    totalPages++;
                }
            }

            return list;

        }

        private async Task<GetSelfShipAppointmentSlotsResponse> GetSelfShipAppointmentSlotsByNextTokenAsync(string shipmentId, ParameterListInboundPlan parameterListInboundPlan, CancellationToken cancellationToken = default)
        {
            var parameter = parameterListInboundPlan.getParameters();
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.GetSelfShipAppointmentSlots(parameterListInboundPlan.InboundPlanId, shipmentId), RestSharp.Method.Get, parameter, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<GetSelfShipAppointmentSlotsResponse>(RateLimitType.FulFillmentInbound_GetSelfShipAppointmentSlots, cancellationToken);
        }
        #endregion 

        #region GenerateSelfShipAppointmentSlots
        public GenerateSelfShipAppointmentSlotsResponse GenerateSelfShipAppointmentSlots(string inboundPlanId, string shipmentId, GenerateSelfShipAppointmentSlotsRequest generateSelfShipAppointmentSlotsRequest) =>
        Task.Run(() => GenerateSelfShipAppointmentSlotsAsync(inboundPlanId, shipmentId, generateSelfShipAppointmentSlotsRequest)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<GenerateSelfShipAppointmentSlotsResponse> GenerateSelfShipAppointmentSlotsAsync(string inboundPlanId, string shipmentId, GenerateSelfShipAppointmentSlotsRequest generateSelfShipAppointmentSlotsRequest, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.GenerateSelfShipAppointmentSlots(inboundPlanId, shipmentId), RestSharp.Method.Post, postJsonObj: generateSelfShipAppointmentSlotsRequest, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<GenerateSelfShipAppointmentSlotsResponse>(RateLimitType.FulFillmentInbound_GenerateSelfShipAppointmentSlots, cancellationToken);
        }
        #endregion

        #region CancelSelfShipAppointment
        public CancelSelfShipAppointmentResponse CancelSelfShipAppointment(string inboundPlanId, string shipmentId, string slotId, CancelSelfShipAppointmentRequest cancelSelfShipAppointmentRequest) =>
        Task.Run(() => CancelSelfShipAppointmentAsync(inboundPlanId, shipmentId, slotId, cancelSelfShipAppointmentRequest)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<CancelSelfShipAppointmentResponse> CancelSelfShipAppointmentAsync(string inboundPlanId, string shipmentId, string slotId, CancelSelfShipAppointmentRequest cancelSelfShipAppointmentRequest, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.CancelSelfShipAppointment(inboundPlanId, shipmentId, slotId), RestSharp.Method.Put, postJsonObj: cancelSelfShipAppointmentRequest, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<CancelSelfShipAppointmentResponse>(RateLimitType.FulFillmentInbound_CancelSelfShipAppointment, cancellationToken);
        }
        #endregion

        #region ScheduleSelfShipAppointment
        public ScheduleSelfShipAppointmentResponse ScheduleSelfShipAppointment(string inboundPlanId, string shipmentId, string slotId, ScheduleSelfShipAppointmentRequest scheduleSelfShipAppointmentRequest) =>
        Task.Run(() => ScheduleSelfShipAppointmentAsync(inboundPlanId, shipmentId, slotId, scheduleSelfShipAppointmentRequest)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<ScheduleSelfShipAppointmentResponse> ScheduleSelfShipAppointmentAsync(string inboundPlanId, string shipmentId, string slotId, ScheduleSelfShipAppointmentRequest scheduleSelfShipAppointmentRequest, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.ScheduleSelfShipAppointment(inboundPlanId, shipmentId, slotId), RestSharp.Method.Post, postJsonObj: scheduleSelfShipAppointmentRequest, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<ScheduleSelfShipAppointmentResponse>(RateLimitType.FulFillmentInbound_ScheduleSelfShipAppointment, cancellationToken);
        }
        #endregion

        #region UpdateShipmentTrackingDetails
        public UpdateShipmentTrackingDetailsResponse UpdateShipmentTrackingDetails(string inboundPlanId, string shipmentId, UpdateShipmentTrackingDetailsRequest updateShipmentTrackingDetailsRequest) =>
        Task.Run(() => UpdateShipmentTrackingDetailsAsync(inboundPlanId, shipmentId, updateShipmentTrackingDetailsRequest)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<UpdateShipmentTrackingDetailsResponse> UpdateShipmentTrackingDetailsAsync(string inboundPlanId, string shipmentId, UpdateShipmentTrackingDetailsRequest updateShipmentTrackingDetailsRequest, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.UpdateShipmentTrackingDetails(inboundPlanId, shipmentId), RestSharp.Method.Put, postJsonObj: updateShipmentTrackingDetailsRequest, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<UpdateShipmentTrackingDetailsResponse>(RateLimitType.FulFillmentInbound_UpdateShipmentTrackingDetails, cancellationToken);
        }
        #endregion

        #region ListTransportationOptions
        public List<TransportationOption> ListTransportationOptions(string inboundPlanId, ParameterListTransportationOptions parameterListTransportationOptions) =>
        Task.Run(() => ListTransportationOptionsAsync(inboundPlanId, parameterListTransportationOptions)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<List<TransportationOption>> ListTransportationOptionsAsync(string inboundPlanId, ParameterListTransportationOptions parameterListTransportationOptions, CancellationToken cancellationToken = default)
        {
            var parameter = parameterListTransportationOptions.getParameters();
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.ListTransportationOptions(inboundPlanId), RestSharp.Method.Get, parameter, cancellationToken: cancellationToken);

            List<TransportationOption> list = new List<TransportationOption>();

            var response = await ExecuteRequestAsync<ListTransportationOptionsResponse>(RateLimitType.FulFillmentInbound_ListTransportationOptions, cancellationToken);
            list.AddRange(response.TransportationOptions);

            var totalPages = 1;
            if (response.Pagination != null && !string.IsNullOrEmpty(response.Pagination.NextToken))
            {
                var nextToken = response.Pagination.NextToken;
                while (!string.IsNullOrEmpty(nextToken) && (!parameterListTransportationOptions.maxPages.HasValue || totalPages < parameterListTransportationOptions.maxPages.Value))
                {
                    parameterListTransportationOptions.PaginationToken = nextToken;
                    var getItemNextPage = await ListTransportationOptionsByNextTokenAsync(inboundPlanId, parameterListTransportationOptions, cancellationToken);
                    list.AddRange(getItemNextPage.TransportationOptions);
                    nextToken = getItemNextPage.Pagination?.NextToken;
                    totalPages++;
                }
            }

            return list;

        }

        private async Task<ListTransportationOptionsResponse> ListTransportationOptionsByNextTokenAsync(string inboundPlanId, ParameterListTransportationOptions parameterListTransportationOptions, CancellationToken cancellationToken = default)
        {
            var parameter = parameterListTransportationOptions.getParameters();
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.ListTransportationOptions(inboundPlanId), RestSharp.Method.Get, parameter, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<ListTransportationOptionsResponse>(RateLimitType.FulFillmentInbound_ListTransportationOptions, cancellationToken);
        }
        #endregion

        #region GenerateTransportationOptions
        public GenerateTransportationOptionsResponse GenerateTransportationOptions(string inboundPlanId, GenerateTransportationOptionsRequest generateTransportationOptionsRequest) =>
        Task.Run(() => GenerateTransportationOptionsAsync(inboundPlanId, generateTransportationOptionsRequest)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<GenerateTransportationOptionsResponse> GenerateTransportationOptionsAsync(string inboundPlanId, GenerateTransportationOptionsRequest generateTransportationOptionsRequest, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.GenerateTransportationOptions(inboundPlanId), RestSharp.Method.Post, postJsonObj: generateTransportationOptionsRequest, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<GenerateTransportationOptionsResponse>(RateLimitType.FulFillmentInbound_GenerateTransportationOptions, cancellationToken);
        }
        #endregion

        #region ConfirmTransportationOptions
        public ConfirmTransportationOptionsResponse ConfirmTransportationOptions(string inboundPlanId, ConfirmTransportationOptionsRequest confirmTransportationOptionsRequest) =>
        Task.Run(() => ConfirmTransportationOptionsAsync(inboundPlanId, confirmTransportationOptionsRequest)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<ConfirmTransportationOptionsResponse> ConfirmTransportationOptionsAsync(string inboundPlanId, ConfirmTransportationOptionsRequest confirmTransportationOptionsRequest, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.ConfirmTransportationOptions(inboundPlanId), RestSharp.Method.Post, postJsonObj: confirmTransportationOptionsRequest, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<ConfirmTransportationOptionsResponse>(RateLimitType.FulFillmentInbound_ConfirmTransportationOptions, cancellationToken);
        }
        #endregion

        #region ListItemComplianceDetails
        public ListItemComplianceDetailsResponse ListItemComplianceDetails(ParematerListItemComplianceDetails parematerListItemComplianceDetails) =>
        Task.Run(() => ListItemComplianceDetailsAsync(parematerListItemComplianceDetails)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<ListItemComplianceDetailsResponse> ListItemComplianceDetailsAsync(ParematerListItemComplianceDetails parematerListItemComplianceDetails, CancellationToken cancellationToken = default)
        {
            var parameter = parematerListItemComplianceDetails.getParameters();
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.ListItemComplianceDetails(), RestSharp.Method.Get, parameter, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<ListItemComplianceDetailsResponse>(RateLimitType.FulFillmentInbound_ListItemComplianceDetails, cancellationToken);
        }
        #endregion

        #region UpdateItemComplianceDetails
        public UpdateItemComplianceDetailsResponse UpdateItemComplianceDetails(ParameterUpdateItemComplianceDetails parameterUpdateItemComplianceDetails, UpdateItemComplianceDetailsRequest updateItemComplianceDetailsRequest) =>
        Task.Run(() => UpdateItemComplianceDetailsAsync(parameterUpdateItemComplianceDetails, updateItemComplianceDetailsRequest)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<UpdateItemComplianceDetailsResponse> UpdateItemComplianceDetailsAsync(ParameterUpdateItemComplianceDetails parameterUpdateItemComplianceDetails, UpdateItemComplianceDetailsRequest updateItemComplianceDetailsRequest, CancellationToken cancellationToken = default)
        {
            var parameter = parameterUpdateItemComplianceDetails.getParameters();
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.UpdateItemComplianceDetails(), RestSharp.Method.Put, parameter: parameter, postJsonObj: updateItemComplianceDetailsRequest, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<UpdateItemComplianceDetailsResponse>(RateLimitType.FulFillmentInbound_UpdateItemComplianceDetails, cancellationToken);
        }
        #endregion

        #region GetInboundOperationStatus
        public InboundOperationStatus GetInboundOperationStatus(string operationId) =>
        Task.Run(() => GetInboundOperationStatusAsync(operationId)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<InboundOperationStatus> GetInboundOperationStatusAsync(string operationId, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.GetInboundOperationStatus(operationId), RestSharp.Method.Get, null, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<InboundOperationStatus>(RateLimitType.FulFillmentInbound_GetInboundOperationStatus, cancellationToken);
        }
        #endregion

        #region UpdateInboundPlanName
        public bool UpdateInboundPlanName(string inboundPlanId, UpdateInboundPlanNameRequest updateInboundPlanNameRequest) =>
          Task.Run(() => UpdateInboundPlanNameAsync(inboundPlanId, updateInboundPlanNameRequest)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<bool> UpdateInboundPlanNameAsync(string inboundPlanId, UpdateInboundPlanNameRequest updateInboundPlanNameRequest, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.UpdateInboundPlanName(inboundPlanId), RestSharp.Method.Put, postJsonObj: updateInboundPlanNameRequest, cancellationToken: cancellationToken);

            var response = await ExecuteRequestAsync<object>(RateLimitType.FulFillmentInbound_UpdateInboundPlanName, cancellationToken);

            return true;
        }

        #endregion

        #region UpdateInboundPlanName
        public bool UpdateShipmentName(string inboundPlanId, string shipmentId, UpdateShipmentNameRequest updateShipmentNameRequest) =>
          Task.Run(() => UpdateShipmentNameAsync(inboundPlanId, shipmentId, updateShipmentNameRequest)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<bool> UpdateShipmentNameAsync(string inboundPlanId, string shipmentId, UpdateShipmentNameRequest updateShipmentNameRequest, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.UpdateShipmentName(inboundPlanId, shipmentId), RestSharp.Method.Put, postJsonObj: updateShipmentNameRequest, cancellationToken: cancellationToken);

            var response = await ExecuteRequestAsync<object>(RateLimitType.FulFillmentInbound_UpdateShipmentName, cancellationToken);

            return true;
        }

        #endregion

        #region GenerateShipmentContentUpdatePreviews
        public GenerateShipmentContentUpdatePreviewsResponse GenerateShipmentContentUpdatePreviews(string inboundPlanId, string shipmentId, GenerateShipmentContentUpdatePreviewsRequest generateShipmentContentUpdatePreviewsRequest) =>
          Task.Run(() => GenerateShipmentContentUpdatePreviewsAsync(inboundPlanId, shipmentId, generateShipmentContentUpdatePreviewsRequest)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<GenerateShipmentContentUpdatePreviewsResponse> GenerateShipmentContentUpdatePreviewsAsync(string inboundPlanId, string shipmentId, GenerateShipmentContentUpdatePreviewsRequest generateShipmentContentUpdatePreviewsRequest, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.GenerateShipmentContentUpdatePreviews(inboundPlanId, shipmentId), RestSharp.Method.Post, postJsonObj: generateShipmentContentUpdatePreviewsRequest, cancellationToken: cancellationToken);

            return await ExecuteRequestAsync<GenerateShipmentContentUpdatePreviewsResponse>(RateLimitType.FulFillmentInbound_GenerateShipmentContentUpdatePreviews, cancellationToken);
        }
        #endregion

        #region GetShipmentContentUpdatePreview
        public ContentUpdatePreview GetShipmentContentUpdatePreview(string inboundPlanId, string shipmentId, string contentUpdatePreviewId) =>
          Task.Run(() => GetShipmentContentUpdatePreviewAsync(inboundPlanId, shipmentId, contentUpdatePreviewId)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<ContentUpdatePreview> GetShipmentContentUpdatePreviewAsync(string inboundPlanId, string shipmentId, string contentUpdatePreviewId, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.GetShipmentContentUpdatePreview(inboundPlanId, shipmentId, contentUpdatePreviewId), RestSharp.Method.Get, null, cancellationToken: cancellationToken);

            return await ExecuteRequestAsync<ContentUpdatePreview>(RateLimitType.FulFillmentInbound_GetShipmentContentUpdatePreview, cancellationToken);
        }

        #endregion

        #region ConfirmShipmentContentUpdatePreview
        public ConfirmShipmentContentUpdatePreviewResponse ConfirmShipmentContentUpdatePreview(string inboundPlanId, string shipmentId, string contentUpdatePreviewId) =>
          Task.Run(() => ConfirmShipmentContentUpdatePreviewAsync(inboundPlanId, shipmentId, contentUpdatePreviewId)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<ConfirmShipmentContentUpdatePreviewResponse> ConfirmShipmentContentUpdatePreviewAsync(string inboundPlanId, string shipmentId, string contentUpdatePreviewId, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.ConfirmShipmentContentUpdatePreview(inboundPlanId, shipmentId, contentUpdatePreviewId), RestSharp.Method.Post, null, cancellationToken: cancellationToken);

            return await ExecuteRequestAsync<ConfirmShipmentContentUpdatePreviewResponse>(RateLimitType.FulFillmentInbound_ConfirmShipmentContentUpdatePreview, cancellationToken);
        }
        #endregion

        #region ConfirmDeliveryWindowOptions
        public ConfirmDeliveryWindowOptionsResponse ConfirmDeliveryWindowOptions(string inboundPlanId, string shipmentId, string deliveryWindowOptionId) =>
          Task.Run(() => ConfirmDeliveryWindowOptionsAsync(inboundPlanId, shipmentId, deliveryWindowOptionId)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<ConfirmDeliveryWindowOptionsResponse> ConfirmDeliveryWindowOptionsAsync(string inboundPlanId, string shipmentId, string deliveryWindowOptionId, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.ConfirmDeliveryWindowOptions(inboundPlanId, shipmentId, deliveryWindowOptionId), RestSharp.Method.Post, null, cancellationToken: cancellationToken);

            return await ExecuteRequestAsync<ConfirmDeliveryWindowOptionsResponse>(RateLimitType.FulFillmentInbound_ConfirmDeliveryWindowOptions, cancellationToken);
        }
        #endregion

        #region GenerateDeliveryWindowOptions
        public GenerateDeliveryWindowOptionsResponse GenerateDeliveryWindowOptions(string inboundPlanId, string shipmentId) =>
          Task.Run(() => GenerateDeliveryWindowOptionsAsync(inboundPlanId, shipmentId)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<GenerateDeliveryWindowOptionsResponse> GenerateDeliveryWindowOptionsAsync(string inboundPlanId, string shipmentId, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.GenerateDeliveryWindowOptions(inboundPlanId, shipmentId), RestSharp.Method.Post, null, cancellationToken: cancellationToken);

            return await ExecuteRequestAsync<GenerateDeliveryWindowOptionsResponse>(RateLimitType.FulFillmentInbound_GenerateDeliveryWindowOptions, cancellationToken);
        }
        #endregion

        #region UpdateShipmentSourceAddress
        public UpdateShipmentSourceAddressResponse UpdateShipmentSourceAddress(string inboundPlanId, string shipmentId, UpdateShipmentSourceAddressRequest updateShipmentSourceAddressRequest) =>
          Task.Run(() => UpdateShipmentSourceAddressAsync(inboundPlanId, shipmentId, updateShipmentSourceAddressRequest)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<UpdateShipmentSourceAddressResponse> UpdateShipmentSourceAddressAsync(string inboundPlanId, string shipmentId, UpdateShipmentSourceAddressRequest updateShipmentSourceAddressRequest, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.UpdateShipmentSourceAddress(inboundPlanId, shipmentId), RestSharp.Method.Put, postJsonObj: updateShipmentSourceAddressRequest, cancellationToken: cancellationToken);

            return await ExecuteRequestAsync<UpdateShipmentSourceAddressResponse>(RateLimitType.FulFillmentInbound_UpdateShipmentSourceAddress, cancellationToken);
        }
        #endregion

        #region CreateMarketplaceItemLabels
        public CreateMarketplaceItemLabelsResponse CreateMarketplaceItemLabels(CreateMarketplaceItemLabelsRequest updateShipmentSourceAddressRequest) =>
          Task.Run(() => CreateMarketplaceItemLabelsAsync(updateShipmentSourceAddressRequest)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<CreateMarketplaceItemLabelsResponse> CreateMarketplaceItemLabelsAsync(CreateMarketplaceItemLabelsRequest updateShipmentSourceAddressRequest, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.CreateMarketplaceItemLabels(), RestSharp.Method.Post, postJsonObj: updateShipmentSourceAddressRequest, cancellationToken: cancellationToken);

            return await ExecuteRequestAsync<CreateMarketplaceItemLabelsResponse>(RateLimitType.FulFillmentInbound_CreateMarketplaceItemLabels, cancellationToken);
        }
        #endregion

        #region ListPackingGroupBoxes
        public List<Box> ListPackingGroupBoxes(ParameterListPackingGroupBoxes parameterListPackingGroupBoxes) =>
        Task.Run(() => ListPackingGroupBoxesAsync(parameterListPackingGroupBoxes)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<List<Box>> ListPackingGroupBoxesAsync(ParameterListPackingGroupBoxes parameterListPackingGroupBoxes, CancellationToken cancellationToken = default)
        {
            var parameter = parameterListPackingGroupBoxes.getParameters();
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.ListPackingGroupBoxes(parameterListPackingGroupBoxes.InboundPlanId, parameterListPackingGroupBoxes.PackingGroupId), RestSharp.Method.Get, parameter, cancellationToken: cancellationToken);

            List<Box> list = new List<Box>();

            var response = await ExecuteRequestAsync<ListPackingGroupBoxesResponse>(RateLimitType.FulFillmentInbound_ListPackingGroupBoxes, cancellationToken);
            list.AddRange(response.Boxes);

            var totalPages = 1;
            if (response.Pagination != null && !string.IsNullOrEmpty(response.Pagination.NextToken))
            {
                var nextToken = response.Pagination.NextToken;
                while (!string.IsNullOrEmpty(nextToken) && (!parameterListPackingGroupBoxes.maxPages.HasValue || totalPages < parameterListPackingGroupBoxes.maxPages.Value))
                {
                    parameterListPackingGroupBoxes.PaginationToken = nextToken;
                    var getItemNextPage = await ListPackingGroupBoxesByNextTokenAsync(parameterListPackingGroupBoxes, cancellationToken);
                    list.AddRange(getItemNextPage.Boxes);
                    nextToken = getItemNextPage.Pagination?.NextToken;
                    totalPages++;
                }
            }

            return list;

        }

        private async Task<ListPackingGroupBoxesResponse> ListPackingGroupBoxesByNextTokenAsync(ParameterListPackingGroupBoxes parameterListPackingGroupBoxes, CancellationToken cancellationToken = default)
        {
            var parameter = parameterListPackingGroupBoxes.getParameters();
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.ListPackingGroupBoxes(parameterListPackingGroupBoxes.InboundPlanId, parameterListPackingGroupBoxes.PackingGroupId), RestSharp.Method.Get, parameter, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<ListPackingGroupBoxesResponse>(RateLimitType.FulFillmentInbound_ListPackingGroupBoxes, cancellationToken);
        }
        #endregion

        #region ListShipmentBoxes
        public List<Box> ListShipmentBoxes(ParameterListInboundPlanShipment parameterListInboundPlanShipment) =>
        Task.Run(() => ListShipmentBoxesAsync(parameterListInboundPlanShipment)).ConfigureAwait(false).GetAwaiter().GetResult();

        private async Task<ListShipmentBoxesResponse> ListShipmentBoxesByNextTokenAsync(ParameterListInboundPlanShipment parameterListInboundPlanShipment, CancellationToken cancellationToken = default)
        {
            var parameter = parameterListInboundPlanShipment.getParameters();
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.ListPackingGroupBoxes(parameterListInboundPlanShipment.InboundPlanId, parameterListInboundPlanShipment.ShipmentId), RestSharp.Method.Get, parameter, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<ListShipmentBoxesResponse>(RateLimitType.FulFillmentInbound_ListShipmentBoxes, cancellationToken);
        }

        public async Task<List<Box>> ListShipmentBoxesAsync(ParameterListInboundPlanShipment parameterListInboundPlanShipment, CancellationToken cancellationToken = default)
        {
            var parameter = parameterListInboundPlanShipment.getParameters();
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.ListPackingGroupBoxes(parameterListInboundPlanShipment.InboundPlanId, parameterListInboundPlanShipment.ShipmentId), RestSharp.Method.Get, parameter, cancellationToken: cancellationToken);

            List<Box> list = new List<Box>();

            var response = await ExecuteRequestAsync<ListShipmentBoxesResponse>(RateLimitType.FulFillmentInbound_ListShipmentBoxes, cancellationToken);
            list.AddRange(response.Boxes);

            var totalPages = 1;
            if (response.Pagination != null && !string.IsNullOrEmpty(response.Pagination.NextToken))
            {
                var nextToken = response.Pagination.NextToken;
                while (!string.IsNullOrEmpty(nextToken) && (!parameterListInboundPlanShipment.maxPages.HasValue || totalPages < parameterListInboundPlanShipment.maxPages.Value))
                {
                    parameterListInboundPlanShipment.PaginationToken = nextToken;
                    var getItemNextPage = await ListShipmentBoxesByNextTokenAsync(parameterListInboundPlanShipment, cancellationToken);
                    list.AddRange(getItemNextPage.Boxes);
                    nextToken = getItemNextPage.Pagination?.NextToken;
                    totalPages++;
                }
            }

            return list;

        }

        #endregion

        #region ListShipmentContentUpdatePreviews
        public List<ContentUpdatePreview> ListShipmentContentUpdatePreviews(ParameterListInboundPlanShipment parameterListInboundPlanShipment) =>
        Task.Run(() => ListShipmentContentUpdatePreviewsAsync(parameterListInboundPlanShipment)).ConfigureAwait(false).GetAwaiter().GetResult();

        private async Task<ListShipmentContentUpdatePreviewsResponse> ListShipmentContentUpdatePreviewsByNextTokenAsync(ParameterListInboundPlanShipment parameterListInboundPlanShipment, CancellationToken cancellationToken = default)
        {
            var parameter = parameterListInboundPlanShipment.getParameters();
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.ListShipmentContentUpdatePreviews(parameterListInboundPlanShipment.InboundPlanId, parameterListInboundPlanShipment.ShipmentId), RestSharp.Method.Get, parameter, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<ListShipmentContentUpdatePreviewsResponse>(RateLimitType.FulFillmentInbound_ListShipmentContentUpdatePreviews, cancellationToken);
        }

        public async Task<List<ContentUpdatePreview>> ListShipmentContentUpdatePreviewsAsync(ParameterListInboundPlanShipment parameterListInboundPlanShipment, CancellationToken cancellationToken = default)
        {
            var parameter = parameterListInboundPlanShipment.getParameters();
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.ListShipmentContentUpdatePreviews(parameterListInboundPlanShipment.InboundPlanId, parameterListInboundPlanShipment.ShipmentId), RestSharp.Method.Get, parameter, cancellationToken: cancellationToken);

            List<ContentUpdatePreview> list = new List<ContentUpdatePreview>();

            var response = await ExecuteRequestAsync<ListShipmentContentUpdatePreviewsResponse>(RateLimitType.FulFillmentInbound_ListShipmentContentUpdatePreviews, cancellationToken);
            list.AddRange(response.ContentUpdatePreviews);

            var totalPages = 1;
            if (response.Pagination != null && !string.IsNullOrEmpty(response.Pagination.NextToken))
            {
                var nextToken = response.Pagination.NextToken;
                while (!string.IsNullOrEmpty(nextToken) && (!parameterListInboundPlanShipment.maxPages.HasValue || totalPages < parameterListInboundPlanShipment.maxPages.Value))
                {
                    parameterListInboundPlanShipment.PaginationToken = nextToken;
                    var getItemNextPage = await ListShipmentContentUpdatePreviewsByNextTokenAsync(parameterListInboundPlanShipment, cancellationToken);
                    list.AddRange(getItemNextPage.ContentUpdatePreviews);
                    nextToken = getItemNextPage.Pagination?.NextToken;
                    totalPages++;
                }
            }

            return list;

        }

        #endregion

        #region ListDeliveryWindowOptions
        public List<DeliveryWindowOption> ListDeliveryWindowOptions(ParameterListInboundPlanShipment parameterListInboundPlanShipment) =>
        Task.Run(() => ListDeliveryWindowOptionsAsync(parameterListInboundPlanShipment)).ConfigureAwait(false).GetAwaiter().GetResult();

        private async Task<ListDeliveryWindowOptionsResponse> ListDeliveryWindowOptionsByNextTokenAsync(ParameterListInboundPlanShipment parameterListInboundPlanShipment, CancellationToken cancellationToken = default)
        {
            var parameter = parameterListInboundPlanShipment.getParameters();
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.ListDeliveryWindowOptions(parameterListInboundPlanShipment.InboundPlanId, parameterListInboundPlanShipment.ShipmentId), RestSharp.Method.Get, parameter, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<ListDeliveryWindowOptionsResponse>(RateLimitType.FulFillmentInbound_ListDeliveryWindowOptions, cancellationToken);
        }

        public async Task<List<DeliveryWindowOption>> ListDeliveryWindowOptionsAsync(ParameterListInboundPlanShipment parameterListInboundPlanShipment, CancellationToken cancellationToken = default)
        {
            var parameter = parameterListInboundPlanShipment.getParameters();
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.ListDeliveryWindowOptions(parameterListInboundPlanShipment.InboundPlanId, parameterListInboundPlanShipment.ShipmentId), RestSharp.Method.Get, parameter, cancellationToken: cancellationToken);

            List<DeliveryWindowOption> list = new List<DeliveryWindowOption>();

            var response = await ExecuteRequestAsync<ListDeliveryWindowOptionsResponse>(RateLimitType.FulFillmentInbound_ListDeliveryWindowOptions, cancellationToken);
            list.AddRange(response.DeliveryWindowOptions);

            var totalPages = 1;
            if (response.Pagination != null && !string.IsNullOrEmpty(response.Pagination.NextToken))
            {
                var nextToken = response.Pagination.NextToken;
                while (!string.IsNullOrEmpty(nextToken) && (!parameterListInboundPlanShipment.maxPages.HasValue || totalPages < parameterListInboundPlanShipment.maxPages.Value))
                {
                    parameterListInboundPlanShipment.PaginationToken = nextToken;
                    var getItemNextPage = await ListDeliveryWindowOptionsByNextTokenAsync(parameterListInboundPlanShipment, cancellationToken);
                    list.AddRange(getItemNextPage.DeliveryWindowOptions);
                    nextToken = getItemNextPage.Pagination?.NextToken;
                    totalPages++;
                }
            }

            return list;

        }

        #endregion

        #region ListShipmentItems
        public List<Item> ListShipmentItems(ParameterListInboundPlanShipment parameterListInboundPlanShipment) =>
        Task.Run(() => ListShipmentItemsAsync(parameterListInboundPlanShipment)).ConfigureAwait(false).GetAwaiter().GetResult();

        private async Task<ListShipmentItemsResponse> ListShipmentItemsByNextTokenAsync(ParameterListInboundPlanShipment parameterListInboundPlanShipment, CancellationToken cancellationToken = default)
        {
            var parameter = parameterListInboundPlanShipment.getParameters();
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.ListShipmentItems(parameterListInboundPlanShipment.InboundPlanId, parameterListInboundPlanShipment.ShipmentId), RestSharp.Method.Get, parameter, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<ListShipmentItemsResponse>(RateLimitType.FulFillmentInbound_ListShipmentItems, cancellationToken);
        }

        public async Task<List<Item>> ListShipmentItemsAsync(ParameterListInboundPlanShipment parameterListInboundPlanShipment, CancellationToken cancellationToken = default)
        {
            var parameter = parameterListInboundPlanShipment.getParameters();
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.ListShipmentItems(parameterListInboundPlanShipment.InboundPlanId, parameterListInboundPlanShipment.ShipmentId), RestSharp.Method.Get, parameter, cancellationToken: cancellationToken);

            List<Item> list = new List<Item>();

            var response = await ExecuteRequestAsync<ListShipmentItemsResponse>(RateLimitType.FulFillmentInbound_ListShipmentItems, cancellationToken);
            list.AddRange(response.Items);

            var totalPages = 1;
            if (response.Pagination != null && !string.IsNullOrEmpty(response.Pagination.NextToken))
            {
                var nextToken = response.Pagination.NextToken;
                while (!string.IsNullOrEmpty(nextToken) && (!parameterListInboundPlanShipment.maxPages.HasValue || totalPages < parameterListInboundPlanShipment.maxPages.Value))
                {
                    parameterListInboundPlanShipment.PaginationToken = nextToken;
                    var getItemNextPage = await ListShipmentItemsByNextTokenAsync(parameterListInboundPlanShipment, cancellationToken);
                    list.AddRange(getItemNextPage.Items);
                    nextToken = getItemNextPage.Pagination?.NextToken;
                    totalPages++;
                }
            }

            return list;

        }
        #endregion

        #region ListShipmentPallets
        public List<Pallet> ListShipmentPallets(ParameterListInboundPlanShipment parameterListInboundPlanShipment) =>
        Task.Run(() => ListShipmentPalletsAsync(parameterListInboundPlanShipment)).ConfigureAwait(false).GetAwaiter().GetResult();

        private async Task<ListShipmentPalletsResponse> ListShipmentPalletsByNextTokenAsync(ParameterListInboundPlanShipment parameterListInboundPlanShipment, CancellationToken cancellationToken = default)
        {
            var parameter = parameterListInboundPlanShipment.getParameters();
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.ListShipmentPallets(parameterListInboundPlanShipment.InboundPlanId, parameterListInboundPlanShipment.ShipmentId), RestSharp.Method.Get, parameter, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<ListShipmentPalletsResponse>(RateLimitType.FulFillmentInbound_ListShipmentPallets, cancellationToken);
        }

        public async Task<List<Pallet>> ListShipmentPalletsAsync(ParameterListInboundPlanShipment parameterListInboundPlanShipment, CancellationToken cancellationToken = default)
        {
            var parameter = parameterListInboundPlanShipment.getParameters();
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.ListShipmentPallets(parameterListInboundPlanShipment.InboundPlanId, parameterListInboundPlanShipment.ShipmentId), RestSharp.Method.Get, parameter, cancellationToken: cancellationToken);

            List<Pallet> list = new List<Pallet>();

            var response = await ExecuteRequestAsync<ListShipmentPalletsResponse>(RateLimitType.FulFillmentInbound_ListShipmentPallets, cancellationToken);
            list.AddRange(response.Pallets);

            var totalPages = 1;
            if (response.Pagination != null && !string.IsNullOrEmpty(response.Pagination.NextToken))
            {
                var nextToken = response.Pagination.NextToken;
                while (!string.IsNullOrEmpty(nextToken) && (!parameterListInboundPlanShipment.maxPages.HasValue || totalPages < parameterListInboundPlanShipment.maxPages.Value))
                {
                    parameterListInboundPlanShipment.PaginationToken = nextToken;
                    var getItemNextPage = await ListShipmentPalletsByNextTokenAsync(parameterListInboundPlanShipment, cancellationToken);
                    list.AddRange(getItemNextPage.Pallets);
                    nextToken = getItemNextPage.Pagination?.NextToken;
                    totalPages++;
                }
            }

            return list;

        }
        #endregion

    }
}
