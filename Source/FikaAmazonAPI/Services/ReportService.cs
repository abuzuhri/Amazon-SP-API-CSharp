using FikaAmazonAPI.AmazonSpApiSDK.Models.Exceptions;
using FikaAmazonAPI.AmazonSpApiSDK.Models.Reports;
using FikaAmazonAPI.AmazonSpApiSDK.Models.Token;
using FikaAmazonAPI.Parameter;
using FikaAmazonAPI.Parameter.Report;
using FikaAmazonAPI.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.Services
{
    public class ReportService : RequestService
    {
        public ReportService(AmazonCredential amazonCredential) : base(amazonCredential)
        {
        }
        #region GetReport
        public List<Report> GetReports(ParameterReportList parameterReportList) =>
            Task.Run(() => GetReportsAsync(parameterReportList)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<List<Report>> GetReportsAsync(ParameterReportList parameterReportList)
        {
            if (parameterReportList.createdSince.HasValue)
            {
                var totalDays = (parameterReportList.createdSince.Value - DateTime.UtcNow).TotalDays;
                if (totalDays > 90)
                {
                    throw new AmazonInvalidInputException("Amazon api not accepting createdSince more than 90 days ," +
                        "The earliest report creation date and time for reports to include in the response, in ISO 8601 date time format. The default is 90 days ago. Reports are retained for a maximum of 90 days. https://github.com/amzn/selling-partner-api-docs/blob/main/references/reports-api/reports_2021-06-30.md#parameters");
                }
            }
            var parameters = parameterReportList.getParameters();

            await CreateAuthorizedRequestAsync(ReportApiUrls.GetReports, RestSharp.Method.Get, parameters);
            var response = await ExecuteRequestAsync<GetReportsResponseV00>(RateLimitType.Report_GetReports);
            parameterReportList.nextToken = response.NextToken;
            var list = response.Reports;

            while (!string.IsNullOrEmpty(parameterReportList.nextToken))
            {
                var nextTokenResponse = await GetReportsByNextTokenAsync(parameterReportList);
                list.AddRange(nextTokenResponse.Reports);
                parameterReportList.nextToken = nextTokenResponse.NextToken;
            }
            return list;
        }

        public Report GetReport(string reportId) =>
            Task.Run(() => GetReportAsync(reportId)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<Report> GetReportAsync(string reportId)
        {

            await CreateAuthorizedRequestAsync(ReportApiUrls.GetReport(reportId), RestSharp.Method.Get);
            var response = await ExecuteRequestAsync<Report>(RateLimitType.Report_GetReport);
            if (response != null)
                return response;
            return null;
        }

        public bool CancelReport(string reportId) =>
            Task.Run(() => CancelReportAsync(reportId)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<bool> CancelReportAsync(string reportId)
        {

            await CreateAuthorizedRequestAsync(ReportApiUrls.CancelReport(reportId), RestSharp.Method.Delete);
            var response = await ExecuteRequestAsync<CancelReportResponse>(RateLimitType.Report_CancelReport);
            if (response != null && response.Errors != null)
                return false;
            return true;
        }

        public ReportScheduleList GetReportSchedules(ParameterReportSchedules parametersSchedules) =>
            Task.Run(() => GetReportSchedulesAsync(parametersSchedules)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<ReportScheduleList> GetReportSchedulesAsync(ParameterReportSchedules parametersSchedules)
        {
            var parameters = parametersSchedules.getParameters();
            await CreateAuthorizedRequestAsync(ReportApiUrls.GetReportSchedules, RestSharp.Method.Get, parameters);
            var response = await ExecuteRequestAsync<GetReportSchedulesResponseV00>(RateLimitType.Report_GetReportSchedules);
            if (response != null && response.ReportSchedules != null)
                return response.ReportSchedules;
            return null;
        }

        public GetReportsResponseV00 GetReportsByNextToken(ParameterReportList parameterReportList) =>
            Task.Run(() => GetReportsByNextTokenAsync(parameterReportList)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<GetReportsResponseV00> GetReportsByNextTokenAsync(ParameterReportList parameterReportList)
        {
            var parameterReportListNew = new ParameterReportList();
            parameterReportListNew.nextToken = parameterReportList.nextToken;
            var parameters = parameterReportListNew.getParameters();

            await CreateAuthorizedRequestAsync(ReportApiUrls.GetReports, RestSharp.Method.Get, parameters);
            var response = await ExecuteRequestAsync<GetReportsResponseV00>(RateLimitType.Report_GetReports);
            return response;
        }

        public string CreateReport(ParameterCreateReportSpecification createReportSpecification) =>
            Task.Run(() => CreateReportAsync(createReportSpecification)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<string> CreateReportAsync(ParameterCreateReportSpecification createReportSpecification)
        {
            await CreateAuthorizedRequestAsync(ReportApiUrls.CreateReport, RestSharp.Method.Post, null, createReportSpecification);
            var response = await ExecuteRequestAsync<AmazonSpApiSDK.Models.Reports.CreateReportResult>(RateLimitType.Report_CreateReport);

            if (response == null)
                return null;


            return response.ReportId;
        }

        public string CreateReportSchedule(ParameterCreateReportScheduleSpecification createReportScheduleSpecification) =>
            Task.Run(() => CreateReportScheduleAsync(createReportScheduleSpecification)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<string> CreateReportScheduleAsync(ParameterCreateReportScheduleSpecification createReportScheduleSpecification)
        {
            await CreateAuthorizedRequestAsync(ReportApiUrls.CreateReportSchedule, RestSharp.Method.Post, null, createReportScheduleSpecification);
            var response = await ExecuteRequestAsync<CreateReportScheduleResult>(RateLimitType.Report_CreateReportSchedule);

            if (response == null)
                return null;


            return response.ReportScheduleId;
        }

        public ReportSchedule GetReportSchedule(string reportScheduleId) =>
            Task.Run(() => GetReportScheduleAsync(reportScheduleId)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<ReportSchedule> GetReportScheduleAsync(string reportScheduleId)
        {
            await CreateAuthorizedRequestAsync(ReportApiUrls.GetReportSchedule(reportScheduleId), RestSharp.Method.Get);
            var response = await ExecuteRequestAsync<ReportSchedule>(RateLimitType.Report_GetReportSchedules);
            if (response != null)
                return response;
            return null;
        }

        public ReportDocument GetReportDocument(string reportDocumentId, bool isRestrictedReport = false) =>
            Task.Run(() => GetReportDocumentAsync(reportDocumentId, isRestrictedReport)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<ReportDocument> GetReportDocumentAsync(string reportDocumentId, bool isRestrictedReport = false)
        {
            ParameterBasedPII parameterBasedPII = null;

            if (isRestrictedReport)
            {
                parameterBasedPII = new ParameterBasedPII()
                {
                    IsNeedRestrictedDataToken = true,
                    RestrictedDataTokenRequest = new CreateRestrictedDataTokenRequest
                    {
                        restrictedResources = new List<RestrictedResource>
                        {
                            new RestrictedResource
                            {
                                method = Method.GET.ToString(),
                                path = ReportApiUrls.GetReportDocument(reportDocumentId)
                            }
                        }
                    }
                };
            }

            await CreateAuthorizedRequestAsync(ReportApiUrls.GetReportDocument(reportDocumentId), RestSharp.Method.Get, parameter: parameterBasedPII);
            var response = await ExecuteRequestAsync<ReportDocument>(RateLimitType.Report_GetReportDocument);
            if (response != null)
                return response;
            return null;
        }
        public string GetReportFile(string reportDocumentId, bool isRestrictedReport = false) =>
            Task.Run(() => GetReportFileAsync(reportDocumentId, isRestrictedReport)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<string> GetReportFileAsync(string reportDocumentId, bool isRestrictedReport = false)
        {
            var reportDocument = await GetReportDocumentAsync(reportDocumentId, isRestrictedReport);
            return GetFile(reportDocument);
        }

        private string GetFile(ReportDocument reportDocument) =>
            Task.Run(() => GetFileAsync(reportDocument)).ConfigureAwait(false).GetAwaiter().GetResult();
        private async Task<string> GetFileAsync(ReportDocument reportDocument)
        {
            bool isCompressionFile = false;
            bool isEncryptedFile = reportDocument.EncryptionDetails != null;

            if (reportDocument.CompressionAlgorithm is ReportDocument.CompressionAlgorithmEnum.GZIP)
                isCompressionFile = true;

            var client = new System.Net.WebClient();
            string fileName = Guid.NewGuid().ToString();

            if (isCompressionFile)
            {
                client.Headers[System.Net.HttpRequestHeader.AcceptEncoding] = "gzip";
                fileName += ".gz";
            }
            else fileName += ".txt";

            string tempFilePath = Path.Combine(Path.GetTempPath() + fileName);

            if (isEncryptedFile)
            {
                //Later will check
                byte[] rawData = client.DownloadData(reportDocument.Url);
                byte[] key = Convert.FromBase64String(reportDocument.EncryptionDetails.Key);
                byte[] iv = Convert.FromBase64String(reportDocument.EncryptionDetails.InitializationVector);
                var reportData = FileTransform.DecryptString(key, iv, rawData);
                File.WriteAllText(tempFilePath, reportData);
            }
            else
            {
                var stream = await client.OpenReadTaskAsync(new Uri(reportDocument.Url));
                using (Stream s = File.Create(tempFilePath))
                {
                    stream?.CopyTo(s);
                }
            }

            return isCompressionFile ? FileTransform.Decompress(tempFilePath) : tempFilePath;
        }

        public async void SaveStreamToFileAsync(string fileFullPath, Stream stream)
        {
            if (stream.Length == 0) return;

            // Create a FileStream object to write a stream to a file
            using (FileStream fileStream = System.IO.File.Create(fileFullPath, (int)stream.Length))
            {
                // Fill the bytes[] array with the stream data
                byte[] bytesInStream = new byte[stream.Length];
                await stream.ReadAsync(bytesInStream, 0, (int)bytesInStream.Length);

                // Use FileStream object to write to the specified file
                fileStream.Write(bytesInStream, 0, bytesInStream.Length);
            }
        }
        public bool CancelReportSchedule(string reportScheduleId) =>
            Task.Run(() => CancelReportScheduleAsync(reportScheduleId)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<bool> CancelReportScheduleAsync(string reportScheduleId)
        {
            await CreateAuthorizedRequestAsync(ReportApiUrls.CancelReportSchedule(reportScheduleId), RestSharp.Method.Delete);
            var response = await ExecuteRequestAsync<CancelReportScheduleResponse>(RateLimitType.Report_CancelReportSchedule);
            if (response != null && response.Errors != null)
                return false;
            return true;
        }
        #endregion


        public string CreateReportAndDownloadFile(ReportTypes reportType, DateTime? dataStartTime = null, DateTime? dataEndTime = null, ReportOptions reportOptions = null, bool isRestrictedReport = false) =>
            Task.Run(() => CreateReportAndDownloadFileAsync(reportType, dataStartTime, dataEndTime, reportOptions, isRestrictedReport)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<string> CreateReportAndDownloadFileAsync(ReportTypes reportType, DateTime? dataStartTime = null, DateTime? dataEndTime = null, ReportOptions reportOptions = null, bool isRestrictedReport = false, List<MarketPlace> marketplaces = null)
        {
            if (!isRestrictedReport && Enum.TryParse<RestrictedReportTypes>(reportType.ToString(), out _))
            {
                isRestrictedReport = true;
            }

            var parameters = new ParameterCreateReportSpecification();
            parameters.reportType = reportType;

            parameters.marketplaceIds = new MarketplaceIds();

            if (marketplaces == null)
            {
                parameters.marketplaceIds.Add(AmazonCredential.MarketPlace.ID);
            }
            else
            {
                parameters.marketplaceIds.AddRange(marketplaces.Select(x => x.ID).ToList());
            }

            if (reportOptions != null)
                parameters.reportOptions = reportOptions;

            if (dataStartTime.HasValue)
                parameters.dataStartTime = dataStartTime;
            if (dataEndTime.HasValue)
                parameters.dataEndTime = dataEndTime;

            var reportId = await CreateReportAsync(parameters);
            var filePath = string.Empty;
            string ReportDocumentId = string.Empty;

            while (string.IsNullOrEmpty(ReportDocumentId))
            {
                var reportData = await GetReportAsync(reportId);
                if (!string.IsNullOrEmpty(reportData.ReportDocumentId))
                {
                    filePath = await GetReportFileAsync(reportData.ReportDocumentId, isRestrictedReport);
                    break;
                }
                if (reportData.ProcessingStatus == Report.ProcessingStatusEnum.FATAL)
                {
                    throw new Exception("Error with Generate report FATAL");
                }
                if (reportData.ProcessingStatus == Report.ProcessingStatusEnum.CANCELLED)
                {
                    return null;
                }
                else Task.Delay(500).Wait();
            }
            return filePath;
        }


        public IList<string> DownloadExistingReportAndDownloadFile(ReportTypes reportTypes, DateTime? createdSince = null, DateTime? createdUntil = null) =>
            Task.Run(() => DownloadExistingReportAndDownloadFileAsync(reportTypes, createdSince, createdUntil)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<IList<string>> DownloadExistingReportAndDownloadFileAsync(ReportTypes reportTypes, DateTime? createdSince = null, DateTime? createdUntil = null)
        {
            var parameters = new ParameterReportList();
            parameters.reportTypes = new List<ReportTypes>();
            parameters.reportTypes.Add(reportTypes);

            parameters.marketplaceIds = new MarketplaceIds();
            parameters.marketplaceIds.Add(AmazonCredential.MarketPlace.ID);


            if (createdSince.HasValue)
                parameters.createdSince = createdSince;
            if (createdUntil.HasValue)
                parameters.createdUntil = createdUntil;

            var reports = await GetReportsAsync(parameters);

            var reportsPath = new List<string>();


            foreach (var reportData in reports)
            {
                if (!string.IsNullOrEmpty(reportData.ReportDocumentId))
                {
                    var filePath = GetReportFile(reportData.ReportDocumentId);
                    reportsPath.Add(filePath);

                }
            }

            return reportsPath;
        }
    }
}
