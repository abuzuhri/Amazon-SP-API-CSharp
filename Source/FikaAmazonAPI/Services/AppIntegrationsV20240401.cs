using FikaAmazonAPI.AmazonSpApiSDK.Models.AppIntegrationsV20240401;
using FikaAmazonAPI.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace FikaAmazonAPI.Services
{
    public class AppIntegrationsServiceV20240401: RequestService
    {
        public AppIntegrationsServiceV20240401(AmazonCredential amazonCredential) : base(amazonCredential)
        {

        }

        #region CreateNotification
        public CreateNotificationResponse CreateNotification(CreateNotificationRequest createNotificationRequest) =>
            Task.Run(() => CreateInboundPlanAsync(createNotificationRequest)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<CreateNotificationResponse> CreateInboundPlanAsync(CreateNotificationRequest createNotificationRequest, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(AppIntegrationsApiUrls.CreateNotification, RestSharp.Method.Post, postJsonObj: createNotificationRequest, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<CreateNotificationResponse>(RateLimitType.AppIntegrationsV20240401_CreateNotification, cancellationToken);
        }
        #endregion


        #region DeleteNotifications
        public bool DeleteNotifications(DeleteNotificationsRequest deleteNotificationsRequest) =>
            Task.Run(() => DeleteNotificationsAsync(deleteNotificationsRequest)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<bool> DeleteNotificationsAsync(DeleteNotificationsRequest deleteNotificationsRequest, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(AppIntegrationsApiUrls.DeleteNotifications, RestSharp.Method.Post, postJsonObj: deleteNotificationsRequest, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<DeleteNotificationsResponse>(RateLimitType.AppIntegrationsV20240401_DeleteNotifications, cancellationToken);
            if (response != null)
                return false;

            return true;
        }
        #endregion

        #region RecordActionFeedback
        public bool RecordActionFeedback(string notificationId, RecordActionFeedbackRequest recordActionFeedbackRequest) =>
            Task.Run(() => RecordActionFeedbackAsync(notificationId, recordActionFeedbackRequest)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<bool> RecordActionFeedbackAsync(string notificationId, RecordActionFeedbackRequest recordActionFeedbackRequest, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(AppIntegrationsApiUrls.RecordActionFeedback(notificationId), RestSharp.Method.Post, postJsonObj: recordActionFeedbackRequest, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<RecordActionFeedbackResponse>(RateLimitType.AppIntegrationsV20240401_RecordActionFeedback, cancellationToken);
            if (response != null)
                return false;

            return true;
        }
        #endregion
    }


}
