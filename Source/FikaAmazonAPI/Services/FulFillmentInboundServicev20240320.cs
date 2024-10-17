using FikaAmazonAPI.AmazonSpApiSDK.Models.FulfillmentInboundv20240320;
using FikaAmazonAPI.Parameter.FulFillmentInbound.v20240320;
using FikaAmazonAPI.Utils;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FikaAmazonAPI.Services
{
    public class FulFillmentInboundServicev20240320 : RequestService
    {
        public FulFillmentInboundServicev20240320(AmazonCredential amazonCredential) : base(amazonCredential)
        {

        }

        #region ListInboundPlans
        public List<InboundPlanSummary> ListInboundPlans(ParameterListInboundPlans parameterListInboundPlans) =>
            Task.Run(() => ListInboundPlansAsync(parameterListInboundPlans)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<List<InboundPlanSummary>> ListInboundPlansAsync(ParameterListInboundPlans parameterListInboundPlans, CancellationToken cancellationToken = default)
        {
            var parameter = parameterListInboundPlans.getParameters();
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.ListInboundPlans, RestSharp.Method.Get, parameter, cancellationToken: cancellationToken);

            List<InboundPlanSummary> list = new List<InboundPlanSummary>();

            var response = await ExecuteRequestAsync<ListInboundPlansResponse>(RateLimitType.FulFillmentInboundV20240320_ListInboundPlans, cancellationToken);
            list.AddRange(response.InboundPlans);

            var totalPages = 1;
            if (response.Pagination != null && !string.IsNullOrEmpty(response.Pagination.NextToken))
            {
                var nextToken = response.Pagination.NextToken;
                while (!string.IsNullOrEmpty(nextToken) && (!parameterListInboundPlans.maxPages.HasValue || totalPages < parameterListInboundPlans.maxPages.Value))
                {
                    parameterListInboundPlans.PaginationToken = nextToken;
                    var getItemNextPage = await ListInboundPlansByNextTokenAsync(parameterListInboundPlans, cancellationToken);
                    list.AddRange(getItemNextPage.InboundPlans);
                    nextToken = getItemNextPage.Pagination?.NextToken;
                    totalPages++;
                }
            }

            return list;
        }

        private async Task<ListInboundPlansResponse> ListInboundPlansByNextTokenAsync(ParameterListInboundPlans parameterListInboundPlans, CancellationToken cancellationToken = default)
        {
            var parameter = parameterListInboundPlans.getParameters();

            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.ListInboundPlans, RestSharp.Method.Get, parameter, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<ListInboundPlansResponse>(RateLimitType.FulFillmentInboundV20240320_ListInboundPlans, cancellationToken);
        }
        #endregion

        #region CreateInboundPlan
        public CreateInboundPlanResponse CreateInboundPlan(CreateInboundPlanRequest createInboundPlanRequest) =>
            Task.Run(() => CreateInboundPlanAsync(createInboundPlanRequest)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<CreateInboundPlanResponse> CreateInboundPlanAsync(CreateInboundPlanRequest createInboundPlanRequest, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.CreateInboundPlan, RestSharp.Method.Post, postJsonObj: createInboundPlanRequest, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<CreateInboundPlanResponse>(RateLimitType.FulFillmentInboundV20240320_CreateInboundPlan, cancellationToken);
        }
        #endregion

        #region UpdateInboundPlanName
        public bool UpdateInboundPlanName(string inboundPlanId, UpdateInboundPlanNameRequest updateInboundPlanNameRequest) =>
            Task.Run(() => UpdateInboundPlanNameAsync(inboundPlanId, updateInboundPlanNameRequest)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<bool> UpdateInboundPlanNameAsync(string inboundPlanId, UpdateInboundPlanNameRequest updateInboundPlanNameRequest, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.UpdateInboundPlanName(inboundPlanId), RestSharp.Method.Put, postJsonObj: updateInboundPlanNameRequest, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<UpdateInboundPlanNameResponse>(RateLimitType.FulFillmentInboundV20240320_UpdateInboundPlanName, cancellationToken);
            if (response != null)
                return false;

            return true;
        }
        #endregion

        #region GetInboundPlan
        public InboundPlan GetInboundPlan(string inboundPlanId) =>
            Task.Run(() => GetInboundPlanAsync(inboundPlanId)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<InboundPlan> GetInboundPlanAsync(string inboundPlanId, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.GetInboundPlan(inboundPlanId), RestSharp.Method.Get, null, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<InboundPlan>(RateLimitType.FulFillmentInboundV20240320_GetInboundPlan, cancellationToken);
        }
        #endregion

        #region ListInboundPlanBoxes
        public List<Box> ListInboundPlanBoxes(ParameterListInboundPlanBase parameterListInboundPlanBase) =>
            Task.Run(() => ListInboundPlanBoxesAsync(parameterListInboundPlanBase)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<List<Box>> ListInboundPlanBoxesAsync(ParameterListInboundPlanBase parameterListInboundPlanBase, CancellationToken cancellationToken = default)
        {
            var parameter = parameterListInboundPlanBase.getParameters();
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.ListInboundPlanBoxes(parameterListInboundPlanBase.InboundPlanId), RestSharp.Method.Get, parameter, cancellationToken: cancellationToken);

            List<Box> list = new List<Box>();

            var response = await ExecuteRequestAsync<ListInboundPlanBoxesResponse>(RateLimitType.FulFillmentInboundV20240320_ListInboundPlanBoxes, cancellationToken);
            list.AddRange(response.Boxes);

            var totalPages = 1;
            if (response.Pagination != null && !string.IsNullOrEmpty(response.Pagination.NextToken))
            {
                var nextToken = response.Pagination.NextToken;
                while (!string.IsNullOrEmpty(nextToken) && (!parameterListInboundPlanBase.maxPages.HasValue || totalPages < parameterListInboundPlanBase.maxPages.Value))
                {
                    parameterListInboundPlanBase.PaginationToken = nextToken;
                    var getItemNextPage = await ListInboundPlanBoxesByNextTokenAsync(parameterListInboundPlanBase, cancellationToken);
                    list.AddRange(getItemNextPage.Boxes);
                    nextToken = getItemNextPage.Pagination?.NextToken;
                    totalPages++;
                }
            }

            return list;
        }

        private async Task<ListInboundPlanBoxesResponse> ListInboundPlanBoxesByNextTokenAsync(ParameterListInboundPlanBase parameterListInboundPlanBase, CancellationToken cancellationToken = default)
        {
            var parameter = parameterListInboundPlanBase.getParameters();
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.ListInboundPlanBoxes(parameterListInboundPlanBase.InboundPlanId), RestSharp.Method.Get, parameter, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<ListInboundPlanBoxesResponse>(RateLimitType.FulFillmentInboundV20240320_ListInboundPlanBoxes, cancellationToken);
        }
        #endregion

        #region CancelInboundPlan
        public CancelInboundPlanResponse CancelInboundPlan(string inboundPlanId) =>
            Task.Run(() => CancelInboundPlanAsync(inboundPlanId)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<CancelInboundPlanResponse> CancelInboundPlanAsync(string inboundPlanId, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.CancelInboundPlan(inboundPlanId), RestSharp.Method.Put, null, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<CancelInboundPlanResponse>(RateLimitType.FulFillmentInboundV20240320_CancelInboundPlan, cancellationToken);
        }
        #endregion

        #region ListInboundPlanItems
        public List<Item> ListInboundPlanItems(ParameterListInboundPlanBase parameterListInboundPlanBase) =>
        Task.Run(() => ListInboundPlanItemsAsync(parameterListInboundPlanBase)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<List<Item>> ListInboundPlanItemsAsync(ParameterListInboundPlanBase parameterListInboundPlanBase, CancellationToken cancellationToken = default)
        {
            var parameter = parameterListInboundPlanBase.getParameters();
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.ListInboundPlanItems(parameterListInboundPlanBase.InboundPlanId), RestSharp.Method.Get, parameter, cancellationToken: cancellationToken);

            List<Item> list = new List<Item>();

            var response = await ExecuteRequestAsync<ListInboundPlanItemsResponse>(RateLimitType.FulFillmentInboundV20240320_ListInboundPlanItems, cancellationToken);
            list.AddRange(response.Items);

            var totalPages = 1;
            if (response.Pagination != null && !string.IsNullOrEmpty(response.Pagination.NextToken))
            {
                var nextToken = response.Pagination.NextToken;
                while (!string.IsNullOrEmpty(nextToken) && (!parameterListInboundPlanBase.maxPages.HasValue || totalPages < parameterListInboundPlanBase.maxPages.Value))
                {
                    parameterListInboundPlanBase.PaginationToken = nextToken;
                    var getItemNextPage = await ListInboundPlanItemsByNextTokenAsync(parameterListInboundPlanBase, cancellationToken);
                    list.AddRange(getItemNextPage.Items);
                    nextToken = getItemNextPage.Pagination?.NextToken;
                    totalPages++;
                }
            }

            return list;
        }

        private async Task<ListInboundPlanItemsResponse> ListInboundPlanItemsByNextTokenAsync(ParameterListInboundPlanBase parameterListInboundPlanBase, CancellationToken cancellationToken = default)
        {
            var parameter = parameterListInboundPlanBase.getParameters();
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.ListInboundPlanItems(parameterListInboundPlanBase.InboundPlanId), RestSharp.Method.Get, parameter, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<ListInboundPlanItemsResponse>(RateLimitType.FulFillmentInboundV20240320_ListInboundPlanItems, cancellationToken);
        }
        #endregion

        #region SetPackingInformation
        public SetPackingInformationResponse SetPackingInformation(string inboundPlanId, SetPackingInformationRequest setPackingInformationRequest) =>
        Task.Run(() => SetPackingInformationAsync(inboundPlanId, setPackingInformationRequest)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<SetPackingInformationResponse> SetPackingInformationAsync(string inboundPlanId, SetPackingInformationRequest setPackingInformationRequest, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.SetPackingInformation(inboundPlanId), RestSharp.Method.Post, postJsonObj: setPackingInformationRequest, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<SetPackingInformationResponse>(RateLimitType.FulFillmentInboundV20240320_SetPackingInformation, cancellationToken);
        }
        #endregion

        #region ListPackingOptions
        public List<PackingOption> ListPackingOptions(ParameterListInboundPlanBase parameterListInboundPlanBase) =>
        Task.Run(() => ListPackingOptionsAsync(parameterListInboundPlanBase)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<List<PackingOption>> ListPackingOptionsAsync(ParameterListInboundPlanBase parameterListInboundPlanBase, CancellationToken cancellationToken = default)
        {
            var parameter = parameterListInboundPlanBase.getParameters();
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.ListPackingOptions(parameterListInboundPlanBase.InboundPlanId), RestSharp.Method.Get, parameter, cancellationToken: cancellationToken);

            List<PackingOption> list = new List<PackingOption>();

            var response = await ExecuteRequestAsync<ListPackingOptionsResponse>(RateLimitType.FulFillmentInboundV20240320_ListPackingOptions, cancellationToken);
            list.AddRange(response.PackingOptions);

            var totalPages = 1;
            if (response.Pagination != null && !string.IsNullOrEmpty(response.Pagination.NextToken))
            {
                var nextToken = response.Pagination.NextToken;
                while (!string.IsNullOrEmpty(nextToken) && (!parameterListInboundPlanBase.maxPages.HasValue || totalPages < parameterListInboundPlanBase.maxPages.Value))
                {
                    parameterListInboundPlanBase.PaginationToken = nextToken;
                    var getItemNextPage = await ListPackingOptionsByNextTokenAsync(parameterListInboundPlanBase, cancellationToken);
                    list.AddRange(getItemNextPage.PackingOptions);
                    nextToken = getItemNextPage.Pagination?.NextToken;
                    totalPages++;
                }
            }

            return list;

        }

        private async Task<ListPackingOptionsResponse> ListPackingOptionsByNextTokenAsync(ParameterListInboundPlanBase parameterListInboundPlanBase, CancellationToken cancellationToken = default)
        {
            var parameter = parameterListInboundPlanBase.getParameters();
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.ListPackingOptions(parameterListInboundPlanBase.InboundPlanId), RestSharp.Method.Get, parameter, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<ListPackingOptionsResponse>(RateLimitType.FulFillmentInboundV20240320_ListPackingOptions, cancellationToken);
        }
        #endregion

        #region GeneratePackingOptions
        public GeneratePackingOptionsResponse GeneratePackingOptions(string inboundPlanId) =>
        Task.Run(() => GeneratePackingOptionsAsync(inboundPlanId)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<GeneratePackingOptionsResponse> GeneratePackingOptionsAsync(string inboundPlanId, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.GeneratePackingOptions(inboundPlanId), RestSharp.Method.Post, null, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<GeneratePackingOptionsResponse>(RateLimitType.FulFillmentInboundV20240320_GeneratePackingOptions, cancellationToken);
        }
        #endregion

        #region ConfirmPackingOption
        public ConfirmPackingOptionResponse ConfirmPackingOption(string inboundPlanId, string packingOptionId) =>
        Task.Run(() => ConfirmPackingOptionAsync(inboundPlanId, packingOptionId)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<ConfirmPackingOptionResponse> ConfirmPackingOptionAsync(string inboundPlanId, string packingOptionId, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.ConfirmPackingOption(inboundPlanId, packingOptionId), RestSharp.Method.Post, null, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<ConfirmPackingOptionResponse>(RateLimitType.FulFillmentInboundV20240320_ConfirmPackingOption, cancellationToken);
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

            var response = await ExecuteRequestAsync<ListPackingGroupBoxesResponse>(RateLimitType.FulFillmentInboundV20240320_ListPackingGroupBoxes, cancellationToken);
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
            return await ExecuteRequestAsync<ListPackingGroupBoxesResponse>(RateLimitType.FulFillmentInboundV20240320_ListPackingGroupBoxes, cancellationToken);
        }
        #endregion

        #region ListPackingGroupItems
        public List<Item> ListPackingGroupItems(ParameterListPackingGroupItems parameterListPackingGroupItems) =>
            Task.Run(() => ListPackingGroupItemsAsync(parameterListPackingGroupItems)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<List<Item>> ListPackingGroupItemsAsync(ParameterListPackingGroupItems parameterListPackingGroupItems, CancellationToken cancellationToken = default)
        {
            var parameter = parameterListPackingGroupItems.getParameters();
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.ListPackingGroupItems(parameterListPackingGroupItems.InboundPlanId, parameterListPackingGroupItems.PackingGroupId), RestSharp.Method.Get, parameter, cancellationToken: cancellationToken);

            List<Item> list = new List<Item>();

            var response = await ExecuteRequestAsync<ListPackingGroupItemsResponse>(RateLimitType.FulFillmentInboundV20240320_ListPackingGroupItems, cancellationToken);
            list.AddRange(response.Items);

            var totalPages = 1;
            if (response.Pagination != null && !string.IsNullOrEmpty(response.Pagination.NextToken))
            {
                var nextToken = response.Pagination.NextToken;
                while (!string.IsNullOrEmpty(nextToken) && (!parameterListPackingGroupItems.maxPages.HasValue || totalPages < parameterListPackingGroupItems.maxPages.Value))
                {
                    parameterListPackingGroupItems.PaginationToken = nextToken;
                    var getItemNextPage = await ListPackingGroupItemsByNextTokenAsync(parameterListPackingGroupItems, cancellationToken);
                    list.AddRange(getItemNextPage.Items);
                    nextToken = getItemNextPage.Pagination?.NextToken;
                    totalPages++;
                }
            }
            return list;
        }


        private async Task<ListPackingGroupItemsResponse> ListPackingGroupItemsByNextTokenAsync(ParameterListPackingGroupItems parameterListPackingGroupItems, CancellationToken cancellationToken = default)
        {
            var parameter = parameterListPackingGroupItems.getParameters();
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.ListPackingGroupItems(parameterListPackingGroupItems.InboundPlanId, parameterListPackingGroupItems.PackingGroupId), RestSharp.Method.Get, parameter, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<ListPackingGroupItemsResponse>(RateLimitType.FulFillmentInboundV20240320_ListPackingGroupItems, cancellationToken);
        }
        #endregion

        #region ListInboundPlanPallets
        public List<Pallet> ListInboundPlanPallets(ParameterListInboundPlanBase parameterListInboundPlanBase) =>
        Task.Run(() => ListInboundPlanPalletsAsync(parameterListInboundPlanBase)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<List<Pallet>> ListInboundPlanPalletsAsync(ParameterListInboundPlanBase parameterListInboundPlanBase, CancellationToken cancellationToken = default)
        {
            var parameter = parameterListInboundPlanBase.getParameters();
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.ListInboundPlanPallets(parameterListInboundPlanBase.InboundPlanId), RestSharp.Method.Get, parameter, cancellationToken: cancellationToken);

            List<Pallet> list = new List<Pallet>();

            var response = await ExecuteRequestAsync<ListInboundPlanPalletsResponse>(RateLimitType.FulFillmentInboundV20240320_ListInboundPlanPallets, cancellationToken);
            list.AddRange(response.Pallets);

            var totalPages = 1;
            if (response.Pagination != null && !string.IsNullOrEmpty(response.Pagination.NextToken))
            {
                var nextToken = response.Pagination.NextToken;
                while (!string.IsNullOrEmpty(nextToken) && (!parameterListInboundPlanBase.maxPages.HasValue || totalPages < parameterListInboundPlanBase.maxPages.Value))
                {
                    parameterListInboundPlanBase.PaginationToken = nextToken;
                    var getItemNextPage = await ListInboundPlanPalletsByNextTokenAsync(parameterListInboundPlanBase, cancellationToken);
                    list.AddRange(getItemNextPage.Pallets);
                    nextToken = getItemNextPage.Pagination?.NextToken;
                    totalPages++;
                }
            }

            return list;

        }

        private async Task<ListInboundPlanPalletsResponse> ListInboundPlanPalletsByNextTokenAsync(ParameterListInboundPlanBase parameterListInboundPlanBase, CancellationToken cancellationToken = default)
        {
            var parameter = parameterListInboundPlanBase.getParameters();
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.ListInboundPlanPallets(parameterListInboundPlanBase.InboundPlanId), RestSharp.Method.Get, parameter, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<ListInboundPlanPalletsResponse>(RateLimitType.FulFillmentInboundV20240320_ListInboundPlanPallets, cancellationToken);
        }
        #endregion

        #region ListPlacementOptions
        public List<PlacementOption> ListPlacementOptions(ParameterListInboundPlanBase parameterListInboundPlanBase) =>
        Task.Run(() => ListPlacementOptionsAsync(parameterListInboundPlanBase)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<List<PlacementOption>> ListPlacementOptionsAsync(ParameterListInboundPlanBase parameterListInboundPlanBase, CancellationToken cancellationToken = default)
        {
            var parameter = parameterListInboundPlanBase.getParameters();
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.ListPlacementOptions(parameterListInboundPlanBase.InboundPlanId), RestSharp.Method.Get, parameter, cancellationToken: cancellationToken);

            List<PlacementOption> list = new List<PlacementOption>();

            var response = await ExecuteRequestAsync<ListPlacementOptionsResponse>(RateLimitType.FulFillmentInboundV20240320_ListPlacementOptions, cancellationToken);
            list.AddRange(response.PlacementOptions);

            var totalPages = 1;
            if (response.Pagination != null && !string.IsNullOrEmpty(response.Pagination.NextToken))
            {
                var nextToken = response.Pagination.NextToken;
                while (!string.IsNullOrEmpty(nextToken) && (!parameterListInboundPlanBase.maxPages.HasValue || totalPages < parameterListInboundPlanBase.maxPages.Value))
                {
                    parameterListInboundPlanBase.PaginationToken = nextToken;
                    var getItemNextPage = await ListPlacementOptionsByNextTokenAsync(parameterListInboundPlanBase, cancellationToken);
                    list.AddRange(getItemNextPage.PlacementOptions);
                    nextToken = getItemNextPage.Pagination?.NextToken;
                    totalPages++;
                }
            }

            return list;
        }

        private async Task<ListPlacementOptionsResponse> ListPlacementOptionsByNextTokenAsync(ParameterListInboundPlanBase parameterListInboundPlanBase, CancellationToken cancellationToken = default)
        {
            var parameter = parameterListInboundPlanBase.getParameters();
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.ListPlacementOptions(parameterListInboundPlanBase.InboundPlanId), RestSharp.Method.Get, parameter, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<ListPlacementOptionsResponse>(RateLimitType.FulFillmentInboundV20240320_ListPlacementOptions, cancellationToken);
        }
        #endregion

        #region GeneratePlacementOptions
        public GeneratePlacementOptionsResponse GeneratePlacementOptions(string inboundPlanId, GeneratePlacementOptionsRequest generatePlacementOptionsRequest) =>
        Task.Run(() => GeneratePlacementOptionsAsync(inboundPlanId, generatePlacementOptionsRequest)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<GeneratePlacementOptionsResponse> GeneratePlacementOptionsAsync(string inboundPlanId, GeneratePlacementOptionsRequest generatePlacementOptionsRequest, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.GeneratePlacementOptions(inboundPlanId), RestSharp.Method.Post, postJsonObj: generatePlacementOptionsRequest, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<GeneratePlacementOptionsResponse>(RateLimitType.FulFillmentInboundV20240320_GeneratePlacementOptions, cancellationToken);
        }
        #endregion

        #region ConfirmPlacementOption
        public ConfirmPlacementOptionResponse ConfirmPlacementOption(string inboundPlanId, string placementOptionId) =>
        Task.Run(() => ConfirmPlacementOptionAsync(inboundPlanId, placementOptionId)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<ConfirmPlacementOptionResponse> ConfirmPlacementOptionAsync(string inboundPlanId, string placementOptionId, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.ConfirmPlacementOption(inboundPlanId, placementOptionId), RestSharp.Method.Post, null, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<ConfirmPlacementOptionResponse>(RateLimitType.FulFillmentInboundV20240320_ConfirmPlacementOption, cancellationToken);
        }
        #endregion

        #region GetShipment
        public Shipment GetShipment(string inboundPlanId, string shipmentId) =>
        Task.Run(() => GetShipmentAsync(inboundPlanId, shipmentId)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<Shipment> GetShipmentAsync(string inboundPlanId, string shipmentId, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.GetShipment(inboundPlanId, shipmentId), RestSharp.Method.Get, null, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<Shipment>(RateLimitType.FulFillmentInboundV20240320_GetShipment, cancellationToken);
        }
        #endregion

        #region ListShipmentBoxes
        public List<Box> ListShipmentBoxes(ParameterListShipmentBase parameterListShipmentBase) =>
        Task.Run(() => ListShipmentBoxesAsync(parameterListShipmentBase)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<List<Box>> ListShipmentBoxesAsync(ParameterListShipmentBase parameterListShipmentBase, CancellationToken cancellationToken = default)
        {
            var parameter = parameterListShipmentBase.getParameters();
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.ListShipmentBoxes(parameterListShipmentBase.InboundPlanId, parameterListShipmentBase.ShipmentId), RestSharp.Method.Get, parameter, cancellationToken: cancellationToken);

            List<Box> list = new List<Box>();

            var response = await ExecuteRequestAsync<ListShipmentBoxesResponse>(RateLimitType.FulFillmentInboundV20240320_ListShipmentBoxes, cancellationToken);
            list.AddRange(response.Boxes);

            var totalPages = 1;
            if (response.Pagination != null && !string.IsNullOrEmpty(response.Pagination.NextToken))
            {
                var nextToken = response.Pagination.NextToken;
                while (!string.IsNullOrEmpty(nextToken) && (!parameterListShipmentBase.maxPages.HasValue || totalPages < parameterListShipmentBase.maxPages.Value))
                {
                    parameterListShipmentBase.PaginationToken = nextToken;
                    var getItemNextPage = await ListShipmentBoxesByNextTokenAsync(parameterListShipmentBase, cancellationToken);
                    list.AddRange(getItemNextPage.Boxes);
                    nextToken = getItemNextPage.Pagination?.NextToken;
                    totalPages++;
                }
            }

            return list;
        }

        private async Task<ListShipmentBoxesResponse> ListShipmentBoxesByNextTokenAsync(ParameterListShipmentBase parameterListShipmentBase, CancellationToken cancellationToken = default)
        {
            var parameter = parameterListShipmentBase.getParameters();
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.ListShipmentBoxes(parameterListShipmentBase.InboundPlanId, parameterListShipmentBase.ShipmentId), RestSharp.Method.Get, parameter, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<ListShipmentBoxesResponse>(RateLimitType.FulFillmentInboundV20240320_ListShipmentBoxes, cancellationToken);
        }
        #endregion

        #region GenerateShipmentContentUpdatePreviews
        public GenerateShipmentContentUpdatePreviewsResponse GenerateShipmentContentUpdatePreviews(string inboundPlanId, string shipmentId, GenerateShipmentContentUpdatePreviewsRequest generateShipmentContentUpdatePreviewsRequest) =>
        Task.Run(() => GenerateShipmentContentUpdatePreviewsAsync(inboundPlanId, shipmentId, generateShipmentContentUpdatePreviewsRequest)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<GenerateShipmentContentUpdatePreviewsResponse> GenerateShipmentContentUpdatePreviewsAsync(string inboundPlanId, string shipmentId, GenerateShipmentContentUpdatePreviewsRequest generateShipmentContentUpdatePreviewsRequest, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.GenerateShipmentContentUpdatePreviews(inboundPlanId, shipmentId), RestSharp.Method.Post, postJsonObj: generateShipmentContentUpdatePreviewsRequest, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<GenerateShipmentContentUpdatePreviewsResponse>(RateLimitType.FulFillmentInboundV20240320_GenerateShipmentContentUpdatePreviews, cancellationToken);
        }
        #endregion

        #region ListShipmentContentUpdatePreviews
        public List<ContentUpdatePreview> ListShipmentContentUpdatePreviews(ParameterListShipmentBase parameterListShipmentBase) =>
        Task.Run(() => ListShipmentContentUpdatePreviewsAsync(parameterListShipmentBase)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<List<ContentUpdatePreview>> ListShipmentContentUpdatePreviewsAsync(ParameterListShipmentBase parameterListShipmentBase, CancellationToken cancellationToken = default)
        {
            var parameter = parameterListShipmentBase.getParameters();
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.ListShipmentContentUpdatePreviews(parameterListShipmentBase.InboundPlanId, parameterListShipmentBase.ShipmentId), RestSharp.Method.Get, parameter, cancellationToken: cancellationToken);

            List<ContentUpdatePreview> list = new List<ContentUpdatePreview>();

            var response = await ExecuteRequestAsync<ListShipmentContentUpdatePreviewsResponse>(RateLimitType.FulFillmentInboundV20240320_ListShipmentContentUpdatePreviews, cancellationToken);
            list.AddRange(response.ContentUpdatePreviews);

            var totalPages = 1;
            if (response.Pagination != null && !string.IsNullOrEmpty(response.Pagination.NextToken))
            {
                var nextToken = response.Pagination.NextToken;
                while (!string.IsNullOrEmpty(nextToken) && (!parameterListShipmentBase.maxPages.HasValue || totalPages < parameterListShipmentBase.maxPages.Value))
                {
                    parameterListShipmentBase.PaginationToken = nextToken;
                    var getItemNextPage = await ListShipmentContentUpdatePreviewsByNextTokenAsync(parameterListShipmentBase, cancellationToken);
                    list.AddRange(getItemNextPage.ContentUpdatePreviews);
                    nextToken = getItemNextPage.Pagination?.NextToken;
                    totalPages++;
                }
            }

            return list;
        }

        private async Task<ListShipmentContentUpdatePreviewsResponse> ListShipmentContentUpdatePreviewsByNextTokenAsync(ParameterListShipmentBase parameterListShipmentBase, CancellationToken cancellationToken = default)
        {
            var parameter = parameterListShipmentBase.getParameters();
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.ListShipmentContentUpdatePreviews(parameterListShipmentBase.InboundPlanId, parameterListShipmentBase.ShipmentId), RestSharp.Method.Get, parameter, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<ListShipmentContentUpdatePreviewsResponse>(RateLimitType.FulFillmentInboundV20240320_ListShipmentContentUpdatePreviews, cancellationToken);
        }
        #endregion

        #region GetShipmentContentUpdatePreview
        public ContentUpdatePreview GetShipmentContentUpdatePreview(string inboundPlanId, string shipmentId, string contentUpdatePreviewId) =>
        Task.Run(() => GetShipmentContentUpdatePreviewAsync(inboundPlanId, shipmentId, contentUpdatePreviewId)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<ContentUpdatePreview> GetShipmentContentUpdatePreviewAsync(string inboundPlanId, string shipmentId, string contentUpdatePreviewId, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.GetShipmentContentUpdatePreview(inboundPlanId, shipmentId, contentUpdatePreviewId), RestSharp.Method.Get, null, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<ContentUpdatePreview>(RateLimitType.FulFillmentInboundV20240320_GetShipmentContentUpdatePreview, cancellationToken);
        }
        #endregion

        #region ConfirmShipmentContentUpdatePreview
        public ConfirmShipmentContentUpdatePreviewResponse ConfirmShipmentContentUpdatePreview(string inboundPlanId, string shipmentId, string contentUpdatePreviewId) =>
        Task.Run(() => ConfirmShipmentContentUpdatePreviewAsync(inboundPlanId, shipmentId, contentUpdatePreviewId)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<ConfirmShipmentContentUpdatePreviewResponse> ConfirmShipmentContentUpdatePreviewAsync(string inboundPlanId, string shipmentId, string contentUpdatePreviewId, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.ConfirmShipmentContentUpdatePreview(inboundPlanId, shipmentId, contentUpdatePreviewId), RestSharp.Method.Post, null, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<ConfirmShipmentContentUpdatePreviewResponse>(RateLimitType.FulFillmentInboundV20240320_ConfirmShipmentContentUpdatePreview, cancellationToken);
        }
        #endregion

        #region GetDeliveryChallanDocument
        public GetDeliveryChallanDocumentResponse GetDeliveryChallanDocument(string inboundPlanId, string shipmentId) =>
        Task.Run(() => GetDeliveryChallanDocumentAsync(inboundPlanId, shipmentId)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<GetDeliveryChallanDocumentResponse> GetDeliveryChallanDocumentAsync(string inboundPlanId, string shipmentId, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.GetDeliveryChallanDocument(inboundPlanId, shipmentId), RestSharp.Method.Get, null, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<GetDeliveryChallanDocumentResponse>(RateLimitType.FulFillmentInboundV20240320_GetDeliveryChallanDocument, cancellationToken);
        }
        #endregion

        #region GenerateDeliveryWindowOptions
        public GenerateDeliveryWindowOptionsResponse GenerateDeliveryWindowOptions(string inboundPlanId, string shipmentId) =>
        Task.Run(() => GenerateDeliveryWindowOptionsAsync(inboundPlanId, shipmentId)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<GenerateDeliveryWindowOptionsResponse> GenerateDeliveryWindowOptionsAsync(string inboundPlanId, string shipmentId, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.GenerateDeliveryWindowOptions(inboundPlanId, shipmentId), RestSharp.Method.Post, null, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<GenerateDeliveryWindowOptionsResponse>(RateLimitType.FulFillmentInboundV20240320_GenerateDeliveryWindowOptions, cancellationToken);
        }
        #endregion

        #region ListDeliveryWindowOptions
        public List<DeliveryWindowOption> ListDeliveryWindowOptions(ParameterListShipmentBase parameterListShipmentBase) =>
        Task.Run(() => ListDeliveryWindowOptionsAsync(parameterListShipmentBase)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<List<DeliveryWindowOption>> ListDeliveryWindowOptionsAsync(ParameterListShipmentBase parameterListShipmentBase, CancellationToken cancellationToken = default)
        {
            var parameter = parameterListShipmentBase.getParameters();
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.ListDeliveryWindowOptions(parameterListShipmentBase.InboundPlanId, parameterListShipmentBase.ShipmentId), RestSharp.Method.Get, parameter, cancellationToken: cancellationToken);

            List<DeliveryWindowOption> list = new List<DeliveryWindowOption>();

            var response = await ExecuteRequestAsync<ListDeliveryWindowOptionsResponse>(RateLimitType.FulFillmentInboundV20240320_ListDeliveryWindowOptions, cancellationToken);
            list.AddRange(response.DeliveryWindowOptions);

            var totalPages = 1;
            if (response.Pagination != null && !string.IsNullOrEmpty(response.Pagination.NextToken))
            {
                var nextToken = response.Pagination.NextToken;
                while (!string.IsNullOrEmpty(nextToken) && (!parameterListShipmentBase.maxPages.HasValue || totalPages < parameterListShipmentBase.maxPages.Value))
                {
                    parameterListShipmentBase.PaginationToken = nextToken;
                    var getItemNextPage = await ListDeliveryWindowOptionsByNextTokenAsync(parameterListShipmentBase, cancellationToken);
                    list.AddRange(getItemNextPage.DeliveryWindowOptions);
                    nextToken = getItemNextPage.Pagination?.NextToken;
                    totalPages++;
                }
            }

            return list;
        }

        private async Task<ListDeliveryWindowOptionsResponse> ListDeliveryWindowOptionsByNextTokenAsync(ParameterListShipmentBase parameterListShipmentBase, CancellationToken cancellationToken = default)
        {
            var parameter = parameterListShipmentBase.getParameters();
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.ListDeliveryWindowOptions(parameterListShipmentBase.InboundPlanId, parameterListShipmentBase.ShipmentId), RestSharp.Method.Get, parameter, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<ListDeliveryWindowOptionsResponse>(RateLimitType.FulFillmentInboundV20240320_ListDeliveryWindowOptions, cancellationToken);
        }
        #endregion

        #region ConfirmDeliveryWindowOption
        public ConfirmDeliveryWindowOptionsResponse ConfirmDeliveryWindowOption(string inboundPlanId, string shipmentId, string deliveryWindowOptionId) =>
        Task.Run(() => ConfirmDeliveryWindowOptionAsync(inboundPlanId, shipmentId, deliveryWindowOptionId)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<ConfirmDeliveryWindowOptionsResponse> ConfirmDeliveryWindowOptionAsync(string inboundPlanId, string shipmentId, string deliveryWindowOptionId, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.ConfirmDeliveryWindowOption(inboundPlanId, shipmentId, deliveryWindowOptionId), RestSharp.Method.Post, null, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<ConfirmDeliveryWindowOptionsResponse>(RateLimitType.FulFillmentInboundV20240320_ConfirmDeliveryWindowOption, cancellationToken);
        }
        #endregion

        #region ListShipmentItems
        public List<Item> ListShipmentItems(ParameterListShipmentBase parameterListShipmentBase) =>
        Task.Run(() => ListShipmentItemsAsync(parameterListShipmentBase)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<List<Item>> ListShipmentItemsAsync(ParameterListShipmentBase parameterListShipmentBase, CancellationToken cancellationToken = default)
        {
            var parameter = parameterListShipmentBase.getParameters();
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.ListShipmentItems(parameterListShipmentBase.InboundPlanId, parameterListShipmentBase.ShipmentId), RestSharp.Method.Get, parameter, cancellationToken: cancellationToken);

            List<Item> list = new List<Item>();

            var response = await ExecuteRequestAsync<ListShipmentItemsResponse>(RateLimitType.FulFillmentInboundV20240320_ListShipmentItems, cancellationToken);
            list.AddRange(response.Items);

            var totalPages = 1;
            if (response.Pagination != null && !string.IsNullOrEmpty(response.Pagination.NextToken))
            {
                var nextToken = response.Pagination.NextToken;
                while (!string.IsNullOrEmpty(nextToken) && (!parameterListShipmentBase.maxPages.HasValue || totalPages < parameterListShipmentBase.maxPages.Value))
                {
                    parameterListShipmentBase.PaginationToken = nextToken;
                    var getItemNextPage = await ListShipmentItemsByNextTokenAsync(parameterListShipmentBase, cancellationToken);
                    list.AddRange(getItemNextPage.Items);
                    nextToken = getItemNextPage.Pagination?.NextToken;
                    totalPages++;
                }
            }

            return list;
        }

        private async Task<ListShipmentItemsResponse> ListShipmentItemsByNextTokenAsync(ParameterListShipmentBase parameterListShipmentBase, CancellationToken cancellationToken = default)
        {
            var parameter = parameterListShipmentBase.getParameters();
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.ListShipmentItems(parameterListShipmentBase.InboundPlanId, parameterListShipmentBase.ShipmentId), RestSharp.Method.Get, parameter, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<ListShipmentItemsResponse>(RateLimitType.FulFillmentInboundV20240320_ListShipmentItems, cancellationToken);
        }
        #endregion

        #region UpdateShipmentName
        public bool UpdateShipmentName(string inboundPlanId, string shipmentId, UpdateShipmentNameRequest updateShipmentNameRequest) =>
            Task.Run(() => UpdateShipmentNameAsync(inboundPlanId, shipmentId, updateShipmentNameRequest)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<bool> UpdateShipmentNameAsync(string inboundPlanId, string shipmentId, UpdateShipmentNameRequest updateShipmentNameRequest, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.UpdateShipmentName(inboundPlanId, shipmentId), RestSharp.Method.Put, postJsonObj: updateShipmentNameRequest, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<UpdateShipmentNameResponse>(RateLimitType.FulFillmentInboundV20240320_UpdateShipmentName, cancellationToken);
            if (response != null)
                return false;

            return true;
        }
        #endregion

        #region ListShipmentPallets
        public List<Pallet> ListShipmentPallets(ParameterListShipmentBase parameterListShipmentBase) =>
        Task.Run(() => ListShipmentPalletsAsync(parameterListShipmentBase)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<List<Pallet>> ListShipmentPalletsAsync(ParameterListShipmentBase parameterListShipmentBase, CancellationToken cancellationToken = default)
        {
            var parameter = parameterListShipmentBase.getParameters();
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.ListShipmentPallets(parameterListShipmentBase.InboundPlanId, parameterListShipmentBase.ShipmentId), RestSharp.Method.Get, parameter, cancellationToken: cancellationToken);

            List<Pallet> list = new List<Pallet>();

            var response = await ExecuteRequestAsync<ListShipmentPalletsResponse>(RateLimitType.FulFillmentInboundV20240320_ListShipmentPallets, cancellationToken);
            list.AddRange(response.Pallets);

            var totalPages = 1;
            if (response.Pagination != null && !string.IsNullOrEmpty(response.Pagination.NextToken))
            {
                var nextToken = response.Pagination.NextToken;
                while (!string.IsNullOrEmpty(nextToken) && (!parameterListShipmentBase.maxPages.HasValue || totalPages < parameterListShipmentBase.maxPages.Value))
                {
                    parameterListShipmentBase.PaginationToken = nextToken;
                    var getItemNextPage = await ListShipmentPalletsByNextTokenAsync(parameterListShipmentBase, cancellationToken);
                    list.AddRange(getItemNextPage.Pallets);
                    nextToken = getItemNextPage.Pagination?.NextToken;
                    totalPages++;
                }
            }

            return list;
        }

        private async Task<ListShipmentPalletsResponse> ListShipmentPalletsByNextTokenAsync(ParameterListShipmentBase parameterListShipmentBase, CancellationToken cancellationToken = default)
        {
            var parameter = parameterListShipmentBase.getParameters();
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.ListShipmentPallets(parameterListShipmentBase.InboundPlanId, parameterListShipmentBase.ShipmentId), RestSharp.Method.Get, parameter, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<ListShipmentPalletsResponse>(RateLimitType.FulFillmentInboundV20240320_ListShipmentPallets, cancellationToken);
        }
        #endregion


        //#region UpdateShipmentDeliveryWindow
        //public UpdateShipmentDeliveryWindowResponse UpdateShipmentDeliveryWindow(string inboundPlanId, string shipmentId, UpdateShipmentDeliveryWindowRequest updateShipmentDeliveryWindowRequest) =>
        //Task.Run(() => UpdateShipmentDeliveryWindowAsync(inboundPlanId, shipmentId, updateShipmentDeliveryWindowRequest)).ConfigureAwait(false).GetAwaiter().GetResult();

        //public async Task<UpdateShipmentDeliveryWindowResponse> UpdateShipmentDeliveryWindowAsync(string inboundPlanId, string shipmentId, UpdateShipmentDeliveryWindowRequest updateShipmentDeliveryWindowRequest, CancellationToken cancellationToken = default)
        //{
        //    await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.UpdateShipmentDeliveryWindow(inboundPlanId, shipmentId), RestSharp.Method.Post, postJsonObj: updateShipmentDeliveryWindowRequest, cancellationToken: cancellationToken);
        //    return await ExecuteRequestAsync<UpdateShipmentDeliveryWindowResponse>(RateLimitType.FulFillmentInboundV20240320_UpdateShipmentDeliveryWindow, cancellationToken);
        //}
        //#endregion

        #region GetSelfShipAppointmentSlots
        public List<SelfShipAppointmentSlotsAvailability> GetSelfShipAppointmentSlots(ParameterListShipmentBase parameterListShipmentBase) =>
        Task.Run(() => GetSelfShipAppointmentSlotsAsync(parameterListShipmentBase)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<List<SelfShipAppointmentSlotsAvailability>> GetSelfShipAppointmentSlotsAsync(ParameterListShipmentBase parameterListShipmentBase, CancellationToken cancellationToken = default)
        {
            var parameter = parameterListShipmentBase.getParameters();
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.GetSelfShipAppointmentSlots(parameterListShipmentBase.InboundPlanId, parameterListShipmentBase.ShipmentId), RestSharp.Method.Get, parameter, cancellationToken: cancellationToken);

            List<SelfShipAppointmentSlotsAvailability> list = new List<SelfShipAppointmentSlotsAvailability>();

            var response = await ExecuteRequestAsync<GetSelfShipAppointmentSlotsResponse>(RateLimitType.FulFillmentInboundV20240320_GetSelfShipAppointmentSlots, cancellationToken);
            list.Add(response.SelfShipAppointmentSlotsAvailability);

            var totalPages = 1;
            if (response.Pagination != null && !string.IsNullOrEmpty(response.Pagination.NextToken))
            {
                var nextToken = response.Pagination.NextToken;
                while (!string.IsNullOrEmpty(nextToken) && (!parameterListShipmentBase.maxPages.HasValue || totalPages < parameterListShipmentBase.maxPages.Value))
                {
                parameterListShipmentBase.PaginationToken = nextToken;
                    var getItemNextPage = await GetSelfShipAppointmentSlotsByNextTokenAsync(parameterListShipmentBase, cancellationToken);
                    list.Add(getItemNextPage.SelfShipAppointmentSlotsAvailability);
                    nextToken = getItemNextPage.Pagination?.NextToken;
                    totalPages++;
                }
            }

            return list;

        }

        private async Task<GetSelfShipAppointmentSlotsResponse> GetSelfShipAppointmentSlotsByNextTokenAsync(ParameterListShipmentBase parameterListShipmentBase, CancellationToken cancellationToken = default)
        {
            var parameter = parameterListShipmentBase.getParameters();
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.GetSelfShipAppointmentSlots(parameterListShipmentBase.InboundPlanId, parameterListShipmentBase.ShipmentId), RestSharp.Method.Get, parameter, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<GetSelfShipAppointmentSlotsResponse>(RateLimitType.FulFillmentInboundV20240320_GetSelfShipAppointmentSlots, cancellationToken);
        }
        #endregion

        #region GenerateSelfShipAppointmentSlots
        public GenerateSelfShipAppointmentSlotsResponse GenerateSelfShipAppointmentSlots(string inboundPlanId, string shipmentId, GenerateSelfShipAppointmentSlotsRequest generateSelfShipAppointmentSlotsRequest) =>
        Task.Run(() => GenerateSelfShipAppointmentSlotsAsync(inboundPlanId, shipmentId, generateSelfShipAppointmentSlotsRequest)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<GenerateSelfShipAppointmentSlotsResponse> GenerateSelfShipAppointmentSlotsAsync(string inboundPlanId, string shipmentId, GenerateSelfShipAppointmentSlotsRequest generateSelfShipAppointmentSlotsRequest, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.GenerateSelfShipAppointmentSlots(inboundPlanId, shipmentId), RestSharp.Method.Post, postJsonObj: generateSelfShipAppointmentSlotsRequest, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<GenerateSelfShipAppointmentSlotsResponse>(RateLimitType.FulFillmentInboundV20240320_GenerateSelfShipAppointmentSlots, cancellationToken);
        }
        #endregion

        #region CancelSelfShipAppointment
        public CancelSelfShipAppointmentResponse CancelSelfShipAppointment(string inboundPlanId, string shipmentId, CancelSelfShipAppointmentRequest cancelSelfShipAppointmentRequest) =>
        Task.Run(() => CancelSelfShipAppointmentAsync(inboundPlanId, shipmentId, cancelSelfShipAppointmentRequest)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<CancelSelfShipAppointmentResponse> CancelSelfShipAppointmentAsync(string inboundPlanId, string shipmentId, CancelSelfShipAppointmentRequest cancelSelfShipAppointmentRequest, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.CancelSelfShipAppointment(inboundPlanId, shipmentId), RestSharp.Method.Put, postJsonObj: cancelSelfShipAppointmentRequest, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<CancelSelfShipAppointmentResponse>(RateLimitType.FulFillmentInboundV20240320_CancelSelfShipAppointment, cancellationToken);
        }
        #endregion

        #region ScheduleSelfShipAppointment
        public ScheduleSelfShipAppointmentResponse ScheduleSelfShipAppointment(string inboundPlanId, string shipmentId, string slotId, ScheduleSelfShipAppointmentRequest scheduleSelfShipAppointmentRequest) =>
        Task.Run(() => ScheduleSelfShipAppointmentAsync(inboundPlanId, shipmentId, slotId, scheduleSelfShipAppointmentRequest)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<ScheduleSelfShipAppointmentResponse> ScheduleSelfShipAppointmentAsync(string inboundPlanId, string shipmentId, string slotId, ScheduleSelfShipAppointmentRequest scheduleSelfShipAppointmentRequest, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.ScheduleSelfShipAppointment(inboundPlanId, shipmentId, slotId), RestSharp.Method.Post, postJsonObj: scheduleSelfShipAppointmentRequest, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<ScheduleSelfShipAppointmentResponse>(RateLimitType.FulFillmentInboundV20240320_ScheduleSelfShipAppointment, cancellationToken);
        }
        #endregion

        #region UpdateShipmentSourceAddress
        public UpdateShipmentSourceAddressResponse UpdateShipmentSourceAddress(string inboundPlanId, string shipmentId, UpdateShipmentSourceAddressRequest updateShipmentSourceAddressRequest) =>
        Task.Run(() => UpdateShipmentSourceAddressAsync(inboundPlanId, shipmentId, updateShipmentSourceAddressRequest)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<UpdateShipmentSourceAddressResponse> UpdateShipmentSourceAddressAsync(string inboundPlanId, string shipmentId, UpdateShipmentSourceAddressRequest updateShipmentSourceAddressRequest, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.UpdateShipmentSourceAddress(inboundPlanId, shipmentId), RestSharp.Method.Put, postJsonObj: updateShipmentSourceAddressRequest, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<UpdateShipmentSourceAddressResponse>(RateLimitType.FulFillmentInboundV20240320_UpdateShipmentSourceAddress, cancellationToken);
        }
        #endregion

        #region UpdateShipmentTrackingDetails
        public UpdateShipmentTrackingDetailsResponse UpdateShipmentTrackingDetails(string inboundPlanId, string shipmentId, UpdateShipmentTrackingDetailsRequest updateShipmentTrackingDetailsRequest) =>
        Task.Run(() => UpdateShipmentTrackingDetailsAsync(inboundPlanId, shipmentId, updateShipmentTrackingDetailsRequest)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<UpdateShipmentTrackingDetailsResponse> UpdateShipmentTrackingDetailsAsync(string inboundPlanId, string shipmentId, UpdateShipmentTrackingDetailsRequest updateShipmentTrackingDetailsRequest, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.UpdateShipmentTrackingDetails(inboundPlanId, shipmentId), RestSharp.Method.Put, postJsonObj: updateShipmentTrackingDetailsRequest, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<UpdateShipmentTrackingDetailsResponse>(RateLimitType.FulFillmentInboundV20240320_UpdateShipmentTrackingDetails, cancellationToken);
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

            var response = await ExecuteRequestAsync<ListTransportationOptionsResponse>(RateLimitType.FulFillmentInboundV20240320_ListTransportationOptions, cancellationToken);
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
            return await ExecuteRequestAsync<ListTransportationOptionsResponse>(RateLimitType.FulFillmentInboundV20240320_ListTransportationOptions, cancellationToken);
        }
        #endregion

        #region GenerateTransportationOptions
        public GenerateTransportationOptionsResponse GenerateTransportationOptions(string inboundPlanId, GenerateTransportationOptionsRequest generateTransportationOptionsRequest) =>
        Task.Run(() => GenerateTransportationOptionsAsync(inboundPlanId, generateTransportationOptionsRequest)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<GenerateTransportationOptionsResponse> GenerateTransportationOptionsAsync(string inboundPlanId, GenerateTransportationOptionsRequest generateTransportationOptionsRequest, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.GenerateTransportationOptions(inboundPlanId), RestSharp.Method.Post, postJsonObj: generateTransportationOptionsRequest, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<GenerateTransportationOptionsResponse>(RateLimitType.FulFillmentInboundV20240320_GenerateTransportationOptions, cancellationToken);
        }
        #endregion

        #region ConfirmTransportationOptions
        public ConfirmTransportationOptionsResponse ConfirmTransportationOptions(string inboundPlanId, ConfirmTransportationOptionsRequest confirmTransportationOptionsRequest) =>
        Task.Run(() => ConfirmTransportationOptionsAsync(inboundPlanId, confirmTransportationOptionsRequest)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<ConfirmTransportationOptionsResponse> ConfirmTransportationOptionsAsync(string inboundPlanId, ConfirmTransportationOptionsRequest confirmTransportationOptionsRequest, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.ConfirmTransportationOptions(inboundPlanId), RestSharp.Method.Post, postJsonObj: confirmTransportationOptionsRequest, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<ConfirmTransportationOptionsResponse>(RateLimitType.FulFillmentInboundV20240320_ConfirmTransportationOptions, cancellationToken);
        }
        #endregion

        #region ListItemComplianceDetails
        public ListItemComplianceDetailsResponse ListItemComplianceDetails(ParematerListItemComplianceDetails parematerListItemComplianceDetails) =>
        Task.Run(() => ListItemComplianceDetailsAsync(parematerListItemComplianceDetails)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<ListItemComplianceDetailsResponse> ListItemComplianceDetailsAsync(ParematerListItemComplianceDetails parematerListItemComplianceDetails, CancellationToken cancellationToken = default)
        {
            var parameter = parematerListItemComplianceDetails.getParameters();
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.ListItemComplianceDetails, RestSharp.Method.Get, parameter, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<ListItemComplianceDetailsResponse>(RateLimitType.FulFillmentInboundV20240320_ListItemComplianceDetails, cancellationToken);
        }
        #endregion

        #region UpdateItemComplianceDetails
        public UpdateItemComplianceDetailsResponse UpdateItemComplianceDetails(ParameterUpdateItemComplianceDetails parameterUpdateItemComplianceDetails, UpdateItemComplianceDetailsRequest updateItemComplianceDetailsRequest) =>
        Task.Run(() => UpdateItemComplianceDetailsAsync(parameterUpdateItemComplianceDetails, updateItemComplianceDetailsRequest)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<UpdateItemComplianceDetailsResponse> UpdateItemComplianceDetailsAsync(ParameterUpdateItemComplianceDetails parameterUpdateItemComplianceDetails, UpdateItemComplianceDetailsRequest updateItemComplianceDetailsRequest, CancellationToken cancellationToken = default)
        {
            var parameter = parameterUpdateItemComplianceDetails.getParameters();
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.UpdateItemComplianceDetails, RestSharp.Method.Put, parameter: parameter, postJsonObj: updateItemComplianceDetailsRequest, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<UpdateItemComplianceDetailsResponse>(RateLimitType.FulFillmentInboundV20240320_UpdateItemComplianceDetails, cancellationToken);
        }
        #endregion

        #region CreateMarketplaceItemLabels
        public CreateMarketplaceItemLabelsResponse CreateMarketplaceItemLabels(CreateMarketplaceItemLabelsRequest createMarketplaceItemLabelsRequest) =>
            Task.Run(() => CreateMarketplaceItemLabelsAsync(createMarketplaceItemLabelsRequest)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<CreateMarketplaceItemLabelsResponse> CreateMarketplaceItemLabelsAsync(CreateMarketplaceItemLabelsRequest createMarketplaceItemLabelsRequest, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.CreateMarketplaceItemLabels, RestSharp.Method.Post, postJsonObj: createMarketplaceItemLabelsRequest, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<CreateMarketplaceItemLabelsResponse>(RateLimitType.FulFillmentInboundV20240320_CreateMarketplaceItemLabels, cancellationToken);
        }
        #endregion

        #region ListPrepDetails
        public List<MskuPrepDetail> ListPrepDetails(ParameterListPrepDetails parameterListPrep) =>
            Task.Run(() => ListPrepDetailsAsync(parameterListPrep)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<List<MskuPrepDetail>> ListPrepDetailsAsync(ParameterListPrepDetails parameterListPrepDetails, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(parameterListPrepDetails.marketplaceId))
            {
                parameterListPrepDetails.marketplaceId = AmazonCredential.MarketPlace.ID;
            }

            var parameter = parameterListPrepDetails.getParameters();
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.ListPrepDetails, RestSharp.Method.Get, parameter, cancellationToken: cancellationToken);

            var response = await ExecuteRequestAsync<ListPrepDetailsResponse>(RateLimitType.FulFillmentInboundV20240320_ListPrepDetails, cancellationToken);

            return response?.MskuPrepDetails;
        }
        #endregion

        #region SetPrepDetails
        public SetPrepDetailsResponse SetPrepDetails(SetPrepDetailsRequest setPrepDetailsRequest) =>
            Task.Run(() => SetPrepDetailsAsync(setPrepDetailsRequest)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<SetPrepDetailsResponse> SetPrepDetailsAsync(SetPrepDetailsRequest setPrepDetailsRequest, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.SetPrepDetails, RestSharp.Method.Post, postJsonObj: setPrepDetailsRequest, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<SetPrepDetailsResponse>(RateLimitType.FulFillmentInboundV20240320_SetPrepDetails, cancellationToken);
        }
        #endregion

        #region GetInboundOperationStatus
        public InboundOperationStatus GetInboundOperationStatus(string operationId) =>
        Task.Run(() => GetInboundOperationStatusAsync(operationId)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<InboundOperationStatus> GetInboundOperationStatusAsync(string operationId, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(FulFillmentInboundApiUrls.GetInboundOperationStatus(operationId), RestSharp.Method.Get, null, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<InboundOperationStatus>(RateLimitType.FulFillmentInboundV20240320_GetInboundOperationStatus, cancellationToken);
        }
        #endregion
        }
    }

