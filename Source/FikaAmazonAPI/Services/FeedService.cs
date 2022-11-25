using FikaAmazonAPI.AmazonSpApiSDK.Models.Exceptions;
using FikaAmazonAPI.AmazonSpApiSDK.Models.Feeds;
using FikaAmazonAPI.ConstructFeed;
using FikaAmazonAPI.ConstructFeed.Messages;
using FikaAmazonAPI.Parameter.Feed;
using FikaAmazonAPI.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.Services
{
    public class FeedService : RequestService
    {

        public FeedService(AmazonCredential amazonCredential) : base(amazonCredential)
        {

        }



        public IList<Feed> GetFeeds(ParameterGetFeed parameterGetFeed) =>
            Task.Run(() => GetFeedsAsync(parameterGetFeed)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<IList<Feed>> GetFeedsAsync(ParameterGetFeed parameterGetFeed)
        {
            List<Feed> list = new List<Feed>();

            var parameter = parameterGetFeed.getParameters();

            await CreateAuthorizedRequestAsync(FeedsApiUrls.GetFeeds, RestSharp.Method.Get, parameter);
            var response = await ExecuteRequestAsync<GetFeedsResponseV00>(RateLimitType.Feed_GetFeeds);

            list.AddRange(response.Feeds);
            var nextToken = response.NextToken;

            while (!string.IsNullOrEmpty(nextToken))
            {
                var data = GetFeedsByNextToken(nextToken);
                list.AddRange(data.Feeds);
                nextToken = data.NextToken;
            }

            return list;
        }


        public GetFeedsResponseV00 GetFeedsByNextToken(string nextToken) =>
            Task.Run(() => GetFeedsByNextTokenAsync(nextToken)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<GetFeedsResponseV00> GetFeedsByNextTokenAsync(string nextToken)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("nextToken", nextToken));


            await CreateAuthorizedRequestAsync(FeedsApiUrls.GetFeeds, RestSharp.Method.Get, queryParameters);
            var response = await ExecuteRequestAsync<GetFeedsResponseV00>(RateLimitType.Feed_GetFeeds);
            return response;
        }


        public CreateFeedResult CreateFeed(CreateFeedSpecification createFeedSpecification) =>
            Task.Run(() => CreateFeedAsync(createFeedSpecification)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<CreateFeedResult> CreateFeedAsync(CreateFeedSpecification createFeedSpecification)
        {
            await CreateAuthorizedRequestAsync(FeedsApiUrls.CreateFeed, RestSharp.Method.Post, postJsonObj: createFeedSpecification);
            var response = await ExecuteRequestAsync<CreateFeedResult>(RateLimitType.Feed_CreateFeed);

            return response;
        }
        public Feed GetFeed(string feedId) =>
            Task.Run(() => GetFeedAsync(feedId)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<Feed> GetFeedAsync(string feedId)
        {
            await CreateAuthorizedRequestAsync(FeedsApiUrls.GetFeed(feedId), RestSharp.Method.Get);
            var response = await ExecuteRequestAsync<Feed>(RateLimitType.Feed_GetFeed);
            if (response != null)
                return response;
            return null;
        }
        public Feed CancelFeed(string feedId) =>
            Task.Run(() => CancelFeedAsync(feedId)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<Feed> CancelFeedAsync(string feedId)
        {
            await CreateAuthorizedRequestAsync(FeedsApiUrls.CancelFeed(feedId), RestSharp.Method.Delete);
            var response = await ExecuteRequestAsync<Feed>(RateLimitType.Feed_CancelFeed);
            if (response != null)
                return response;
            return null;
        }

        public FeedDocument GetFeedDocument(string feedDocumentId) =>
            Task.Run(() => GetFeedDocumentAsync(feedDocumentId)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<FeedDocument> GetFeedDocumentAsync(string feedDocumentId)
        {
            await CreateAuthorizedRequestAsync(FeedsApiUrls.GetFeedDocument(feedDocumentId), RestSharp.Method.Get);
            var response = await ExecuteRequestAsync<FeedDocument>(RateLimitType.Feed_GetFeedDocument);
            if (response != null)
                return response;
            return null;
        }

        [Obsolete("Use GetFeedDocumentProcessingReportAsync as it handles compressed responses.")]
        public ProcessingReportMessage GetFeedDocumentProcessingReport(string url) =>
            Task.Run(() => GetFeedDocumentProcessingReportAsync(url)).ConfigureAwait(false).GetAwaiter().GetResult();

        [Obsolete("Use GetFeedDocumentProcessingReportAsync as it handles compressed responses.")]
        public async Task<ProcessingReportMessage> GetFeedDocumentProcessingReportAsync(string url)
        {
            ProcessingReportMessage processingReport = null;
            string responseContent;
            try
            {
                var stream = await GetStreamFromUrlAsync(url);
                var xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(FeedAmazonEnvelope));
                FeedAmazonEnvelope response = null;

                try
                {
                    response = (FeedAmazonEnvelope)xmlSerializer.Deserialize(stream);
                }
                catch (Exception e)
                {
                    StreamReader reader = new StreamReader(stream);
                    responseContent = reader.ReadToEnd();
                    throw new AmazonProcessingReportDeserializeException("Something went wrong on deserialize report stream", responseContent);
                }

                processingReport = response.Message[0].ProcessingReport;

            }
            catch (AmazonProcessingReportDeserializeException ex)
            {
                throw;
            }
            return processingReport;
        }

        public ProcessingReportMessage GetFeedDocumentProcessingReport(FeedDocument feedDocument) =>
            Task.Run(() => GetFeedDocumentProcessingReportAsync(feedDocument)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<ProcessingReportMessage> GetFeedDocumentProcessingReportAsync(FeedDocument feedDocument)
        {
            ProcessingReportMessage processingReport = null;
            string responseContent;
            try
            {
                var stream = await GetStreamFromUrlAsync(feedDocument.Url);
                if (feedDocument.CompressionAlgorithm.HasValue && (feedDocument.CompressionAlgorithm.Value == FeedDocument.CompressionAlgorithmEnum.GZIP))
                    stream = new System.IO.Compression.GZipStream(stream, System.IO.Compression.CompressionMode.Decompress);
                var xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(FeedAmazonEnvelope));
                FeedAmazonEnvelope response = null;

                try
                {
                    response = (FeedAmazonEnvelope)xmlSerializer.Deserialize(stream);
                }
                catch (Exception e)
                {
                    StreamReader reader = new StreamReader(stream);
                    responseContent = reader.ReadToEnd();
                    throw new AmazonProcessingReportDeserializeException("Something went wrong on deserialize report stream", responseContent);
                }

                processingReport = response.Message[0].ProcessingReport;

            }
            catch (AmazonProcessingReportDeserializeException ex)
            {
                throw;
            }
            return processingReport;
        }

        public CreateFeedDocumentResult CreateFeedDocument(ContentType contentType) =>
            Task.Run(() => CreateFeedDocumentAsync(contentType)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<CreateFeedDocumentResult> CreateFeedDocumentAsync(ContentType contentType)
        {
            var contxt = LinqHelper.GetEnumMemberValue(contentType);
            var createFeedDocumentSpecification = new AmazonSpApiSDK.Models.Feeds.CreateFeedDocumentSpecification(contxt);

            await CreateAuthorizedRequestAsync(FeedsApiUrls.CreateFeedDocument, RestSharp.Method.Post, postJsonObj: createFeedDocumentSpecification);
            var response = await ExecuteRequestAsync<CreateFeedDocumentResult>(RateLimitType.Feed_CreateFeedDocument);
            if (response != null)
                return response;
            return null;
        }

        public string SubmitFeed(string XmlContentOrFilePath, FeedType feedType, List<string> marketPlaceIds = null, FeedOptions feedOptions = null, ContentType contentType = ContentType.XML) =>
            Task.Run(() => SubmitFeedAsync(XmlContentOrFilePath, feedType, marketPlaceIds, feedOptions, contentType)).ConfigureAwait(false).GetAwaiter().GetResult();

        /// <summary>
        /// read full step  https://github.com/amzn/selling-partner-api-docs/blob/main/guides/en-US/use-case-guides/feeds-api-use-case-guide/feeds-api-use-case-guide_2021-06-30.md
        /// </summary>
        /// <param name="xml"></param>
        /// <param name="feedType"></param>
        /// <returns></returns>
        public async Task<string> SubmitFeedAsync(string feedContentOrFilePath, FeedType feedType, List<string> marketPlaceIds = null, FeedOptions feedOptions = null, ContentType contentType = ContentType.XML)
        {
            //We are creating Feed Document
            var feedCreate = CreateFeedDocument(contentType);

            //Uploading encoded invoice file
            _ = await PostFileDataAsync(feedCreate.Url, feedContentOrFilePath, contentType);

            CreateFeedSpecification createFeedSpecification = new CreateFeedSpecification()
            {
                FeedType = feedType.ToString(),
                InputFeedDocumentId = feedCreate.FeedDocumentId,
                MarketplaceIds = marketPlaceIds ?? new List<string> { AmazonCredential.MarketPlace.ID },
                FeedOptions = feedOptions
            };

            //Submit XML
            var feed = await CreateFeedAsync(createFeedSpecification);

            return feed.FeedId;
        }


        private static async Task<Stream> GetStreamFromUrlAsync(string url)
        {
            byte[] imageData = null;

            using (var wc = new System.Net.WebClient())
                imageData = await wc.DownloadDataTaskAsync(new Uri(url));

            return new MemoryStream(imageData);
        }

        private async Task<string> PostFileDataAsync(string destinationUrl, string contentOrFilePath, ContentType contentType = ContentType.XML)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(destinationUrl);

            byte[] bytes;
            if (Uri.IsWellFormedUriString(contentOrFilePath, UriKind.RelativeOrAbsolute))
                bytes = File.ReadAllBytes(contentOrFilePath);
            else
                bytes = System.Text.Encoding.UTF8.GetBytes(contentOrFilePath);
            request.ContentType = LinqHelper.GetEnumMemberValue(contentType);
            request.ContentLength = bytes.Length;
            request.Method = "PUT";
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Close();
                HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream responseStream = response.GetResponseStream();
                    string responseStr = await new StreamReader(responseStream).ReadToEndAsync();
                    return responseStr;
                }
            }
            return null;
        }

    }
}
