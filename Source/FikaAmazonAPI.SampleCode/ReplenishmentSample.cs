using FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment;
using FikaAmazonAPI.Utils;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FikaAmazonAPI.SampleCode
{
    public class ReplenishmentSample
    {
        AmazonConnection amazonConnection;
        public ReplenishmentSample(AmazonConnection amazonConnection)
        {
            this.amazonConnection = amazonConnection;
        }

        /// <summary>
        /// Find Subscribe-and-Save offers that have paused or at-risk deliveries in the next 30 days,
        /// sorted by inventory ascending so the most worrying ones surface first.
        /// </summary>
        public async Task<ListOffersResponse> ListAtRiskOffersAsync()
        {
            return await amazonConnection.Replenishment.ListOffersAsync(new ListOffersRequest
            {
                Pagination = new ListOffersRequestPagination { Limit = 100, Offset = 0 },
                Filters = new ListOffersRequestFilters
                {
                    MarketplaceId = amazonConnection.GetCurrentMarketplace.ID,
                    ProgramTypes  = new List<ProgramType> { ProgramType.SUBSCRIBE_AND_SAVE },
                    DeliveriesConditions = new List<DeliveryConditionType>
                    {
                        //DeliveryConditionType.NEXT_30_DAYS_DELIVERIES_PAUSED_PRICING,
                        //DeliveryConditionType.NEXT_30_DAYS_DELIVERIES_PAUSED_NON_BUYABLE,
                        DeliveryConditionType.NEXT_30_DAYS_DELIVERIES_AT_LOW_INVENTORY_RISK,
                        //DeliveryConditionType.NEXT_30_DAYS_DELIVERIES_AT_LOW_INVENTORY_RISK_ONLY,
                    },
                },
                Sort = new ListOffersRequestSort
                {
                    Order = SortOrder.ASC,
                    Key   = ListOffersSortKey.INVENTORY,
                },
            });
        }

        /// <summary>
        /// Pull per-offer metrics for the previous calendar month at the offer level (with SKU
        /// and FulfillmentChannelType, both added in the April 2026 release).
        /// </summary>
        public async Task<ListOfferMetricsResponse> GetOfferMetricsForLastMonthAsync()
        {
            var lastMonthStart = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 1, 0, 0, 0, DateTimeKind.Utc).AddMonths(-1);
            var lastMonthEnd   = lastMonthStart.AddMonths(1).AddSeconds(-1);

            return await amazonConnection.Replenishment.ListOfferMetricsAsync(new ListOfferMetricsRequest
            {
                Pagination = new ListOfferMetricsRequestPagination { Limit = 500, Offset = 0 },
                Filters = new ListOfferMetricsRequestFilters
                {
                    AggregationFrequency = AggregationFrequency.MONTH,
                    TimeInterval = new TimeInterval { StartDate = lastMonthStart, EndDate = lastMonthEnd },
                    TimePeriodType = TimePeriodType.PERFORMANCE,
                    MarketplaceId = amazonConnection.GetCurrentMarketplace.ID,
                    ProgramTypes = new List<ProgramType> { ProgramType.SUBSCRIBE_AND_SAVE },
                },
                Sort = new ListOfferMetricsRequestSort
                {
                    Order = SortOrder.DESC,
                    Key   = ListOfferMetricsSortKey.TOTAL_SUBSCRIPTIONS_REVENUE,
                },
            });
        }

        /// <summary>
        /// Pull seller-level metrics for the previous calendar month including the new
        /// REVENUE_PENETRATION metric (April 2026 release).
        /// </summary>
        public async Task<GetSellingPartnerMetricsResponse> GetSellingPartnerMetricsAsync()
        {
            var lastMonthStart = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 1, 0, 0, 0, DateTimeKind.Utc).AddMonths(-1);
            var lastMonthEnd   = lastMonthStart.AddMonths(1).AddSeconds(-1);

            return await amazonConnection.Replenishment.GetSellingPartnerMetricsAsync(new GetSellingPartnerMetricsRequest
            {
                AggregationFrequency = AggregationFrequency.MONTH,
                TimeInterval = new TimeInterval { StartDate = lastMonthStart, EndDate = lastMonthEnd },
                TimePeriodType = TimePeriodType.PERFORMANCE,
                MarketplaceId = amazonConnection.GetCurrentMarketplace.ID,
                ProgramTypes = new List<ProgramType> { ProgramType.SUBSCRIBE_AND_SAVE },
                Metrics = new List<Metric>
                {
                    Metric.TOTAL_SUBSCRIPTIONS_REVENUE,
                    Metric.SHIPPED_SUBSCRIPTION_UNITS,
                    Metric.ACTIVE_SUBSCRIPTIONS,
                    Metric.REVENUE_PENETRATION,
                },
            });
        }
    }
}
