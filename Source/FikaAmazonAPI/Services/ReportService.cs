using FikaAmazonAPI.AmazonSpApiSDK.Models.Exceptions;
using FikaAmazonAPI.AmazonSpApiSDK.Models.Reports;
using FikaAmazonAPI.Parameter.Report;
using FikaAmazonAPI.Search;
using FikaAmazonAPI.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.Services
{
    public class ReportService : RequestService
    {
        public ReportService(AmazonCredential amazonCredential) : base(amazonCredential)
        {
        }
        #region GetReport
        public List<Report> GetReports(ParameterReportList parameterReportList)
        {
            if (parameterReportList.createdSince.HasValue)
            {
                var totalDays = (parameterReportList.createdSince.Value - DateTime.UtcNow).TotalDays;
                if (totalDays > 90)
                {
                    throw new AmazonInvalidInputException("Amazon api not accepting createdSince more than 90 days ,"+
                        "The earliest report creation date and time for reports to include in the response, in ISO 8601 date time format. The default is 90 days ago. Reports are retained for a maximum of 90 days. https://github.com/amzn/selling-partner-api-docs/blob/main/references/reports-api/reports_2021-06-30.md#parameters");
                }

            }
            var parameters = parameterReportList.getParameters();

            CreateAuthorizedRequest(ReportApiUrls.GetReports, RestSharp.Method.GET, parameters);
            var response = ExecuteRequest<GetReportsResponseV00>(RateLimitType.Report_GetReports);
            parameterReportList.nextToken = response.NextToken;
            var list = response.Reports;

            while (!string.IsNullOrEmpty(parameterReportList.nextToken))
            {
                var nextTokenResponse = GetReportsByNextToken(parameterReportList);
                list.AddRange(nextTokenResponse.Reports);
                parameterReportList.nextToken = nextTokenResponse.NextToken;
            }
            return list;
        }

        public Report GetReport(string reportId)
        {

            CreateAuthorizedRequest(ReportApiUrls.GetReport(reportId), RestSharp.Method.GET);
            var response = ExecuteRequest<Report>(RateLimitType.Report_GetReport);
            if (response != null)
                return response;
            return null;
        }
        public bool CancelReport(string reportId)
        {

            CreateAuthorizedRequest(ReportApiUrls.CancelReport(reportId), RestSharp.Method.DELETE);
            var response = ExecuteRequest<CancelReportResponse>(RateLimitType.Report_CancelReport);
            if (response != null && response.Errors != null)
                return false;
            return true;
        }

        public ReportScheduleList GetReportSchedules(ParameterReportSchedules parametersSchedules)
        {
            var parameters = parametersSchedules.getParameters();
            CreateAuthorizedRequest(ReportApiUrls.GetReportSchedules, RestSharp.Method.GET, parameters);
            var response = ExecuteRequest<GetReportSchedulesResponseV00>(RateLimitType.Report_GetReportSchedules);
            if (response != null && response.ReportSchedules != null)
                return response.ReportSchedules;
            return null;
        }

        private GetReportsResponseV00 GetReportsByNextToken(ParameterReportList parameterReportList)
        {
            var parameterReportListNew = new ParameterReportList();
            parameterReportListNew.nextToken = parameterReportList.nextToken;
            var parameters = parameterReportListNew.getParameters();

            CreateAuthorizedRequest(ReportApiUrls.GetReports, RestSharp.Method.GET, parameters);
            var response = ExecuteRequest<GetReportsResponseV00>(RateLimitType.Report_GetReports);
            return response;
        }

        public string CreateReport(ParameterCreateReportSpecification createReportSpecification)
        {
            CreateAuthorizedRequest(ReportApiUrls.CreateReport, RestSharp.Method.POST, null, createReportSpecification);
            var response = ExecuteRequest<AmazonSpApiSDK.Models.Reports.CreateReportResult>(RateLimitType.Report_CreateReport);

            if (response == null)
                return null;


            return response.ReportId;
        }

        public string CreateReportSchedule(ParameterCreateReportScheduleSpecification createReportScheduleSpecification)
        {
            CreateAuthorizedRequest(ReportApiUrls.CreateReportSchedule, RestSharp.Method.POST, null, createReportScheduleSpecification);
            var response = ExecuteRequest<CreateReportScheduleResult>(RateLimitType.Report_CreateReportSchedule);

            if (response == null)
                return null;


            return response.ReportScheduleId;
        }

        public ReportSchedule GetReportSchedule(string reportScheduleId)
        {

            CreateAuthorizedRequest(ReportApiUrls.GetReportSchedule(reportScheduleId), RestSharp.Method.GET);
            var response = ExecuteRequest<ReportSchedule>(RateLimitType.Report_GetReportSchedules);
            if (response != null)
                return response;
            return null;
        }

        public ReportDocument GetReportDocument(string reportDocumentId, IParameterBasedPII ParameterBasedPII = null)
        {
            CreateAuthorizedRequest(ReportApiUrls.GetReportDocument(reportDocumentId), RestSharp.Method.GET,parameter: ParameterBasedPII);
            var response = ExecuteRequest<ReportDocument>(RateLimitType.Report_GetReportDocument);
            if (response != null)
                return response;
            return null;
        }
        public string GetReportFile(string reportDocumentId)
        {
            var reportDocument = GetReportDocument(reportDocumentId);
            return GetFile(reportDocument);
        }

        private string GetFile(ReportDocument reportDocument)
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
                var stream = client.OpenRead(reportDocument.Url);
                using (Stream s = File.Create(tempFilePath))
                {
                    stream?.CopyTo(s);
                }
            }

            return isCompressionFile ? FileTransform.Decompress(tempFilePath) : tempFilePath;
        }

        public void SaveStreamToFile(string fileFullPath, Stream stream)
        {
            if (stream.Length == 0) return;

            // Create a FileStream object to write a stream to a file
            using (FileStream fileStream = System.IO.File.Create(fileFullPath, (int)stream.Length))
            {
                // Fill the bytes[] array with the stream data
                byte[] bytesInStream = new byte[stream.Length];
                stream.Read(bytesInStream, 0, (int)bytesInStream.Length);

                // Use FileStream object to write to the specified file
                fileStream.Write(bytesInStream, 0, bytesInStream.Length);
            }
        }
        public bool CancelReportSchedule(string reportScheduleId)
        {

            CreateAuthorizedRequest(ReportApiUrls.CancelReportSchedule(reportScheduleId), RestSharp.Method.DELETE);
            var response = ExecuteRequest<CancelReportScheduleResponse>(RateLimitType.Report_CancelReportSchedule);
            if (response != null && response.Errors != null)
                return false;
            return true;
        }
        #endregion


        public string CreateReportAndDownloadFile(ReportTypes reportTypes, DateTime? dataStartTime = null, DateTime? dataEndTime = null, ReportOptions reportOptions = null)
        {

            var parameters = new ParameterCreateReportSpecification();
            parameters.reportType = reportTypes;
            
            parameters.marketplaceIds = new MarketplaceIds();
            
            parameters.marketplaceIds.Add(AmazonCredential.MarketPlace.ID);

            if (reportOptions != null)
                parameters.reportOptions = reportOptions;

            if (dataStartTime.HasValue)
                parameters.dataStartTime = dataStartTime;
            if (dataEndTime.HasValue)
                parameters.dataEndTime = dataEndTime;

            var reportId = CreateReport(parameters);
            var filePath = string.Empty;
            string ReportDocumentId = string.Empty;

            while (string.IsNullOrEmpty(ReportDocumentId))
            {
                var reportData = GetReport(reportId);
                if (!string.IsNullOrEmpty(reportData.ReportDocumentId))
                {
                    filePath = GetReportFile(reportData.ReportDocumentId);
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
                else Thread.Sleep(1000 * 60);
            }

            return filePath;
        }


        public IList<string> DownloadExistingReportAndDownloadFile(ReportTypes reportTypes, DateTime? createdSince = null, DateTime? createdUntil = null)
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

            var reports = GetReports(parameters);

            var reportsPath =new List<string>();


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
