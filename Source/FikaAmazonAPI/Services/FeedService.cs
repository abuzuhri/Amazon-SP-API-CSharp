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
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.Services
{
    public class FeedService : RequestService
    {

        public FeedService(AmazonCredential amazonCredential) : base(amazonCredential)
        {

        }



        public IList<Feed> GetFeeds(ParameterGetFeed parameterGetFeed)
        {
            List<Feed> list = new List<Feed>();

            var parameter = parameterGetFeed.getParameters();

            CreateAuthorizedRequest(FeedsApiUrls.GetFeeds, RestSharp.Method.GET, parameter);
            var response = ExecuteRequest<GetFeedsResponseV00>(RateLimitType.Feed_GetFeeds);

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


        private GetFeedsResponseV00 GetFeedsByNextToken(string nextToken)
        {
            List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>();
            queryParameters.Add(new KeyValuePair<string, string>("nextToken", nextToken));


            CreateAuthorizedRequest(FeedsApiUrls.GetFeeds, RestSharp.Method.GET, queryParameters);
            var response = ExecuteRequest<GetFeedsResponseV00>(RateLimitType.Feed_GetFeeds);
            return response;
        }


        public CreateFeedResult CreateFeed(CreateFeedSpecification createFeedSpecification)
        {
            CreateAuthorizedRequest(FeedsApiUrls.CreateFeed, RestSharp.Method.POST, postJsonObj: createFeedSpecification);
            var response = ExecuteRequest<CreateFeedResult>(RateLimitType.Feed_CreateFeed);

            return response;
        }
        public Feed GetFeed(string feedId)
        {
            CreateAuthorizedRequest(FeedsApiUrls.GetFeed(feedId), RestSharp.Method.GET);
            var response = ExecuteRequest<Feed>(RateLimitType.Feed_CreateFeed);
            if (response != null)
                return response;
            return null;
        }
        public Feed CancelFeed(string feedId)
        {
            CreateAuthorizedRequest(FeedsApiUrls.CancelFeed(feedId), RestSharp.Method.DELETE);
            var response = ExecuteRequest<Feed>(RateLimitType.Feed_CancelFeed);
            if (response != null)
                return response;
            return null;
        }

        public FeedDocument GetFeedDocument(string feedDocumentId)
        {
            CreateAuthorizedRequest(FeedsApiUrls.GetFeedDocument(feedDocumentId), RestSharp.Method.GET);
            var response = ExecuteRequest<FeedDocument>(RateLimitType.Feed_GetFeedDocument);
            if (response != null)
                return response;
            return null;
        }

        public ProcessingReportMessage GetFeedDocumentProcessingReport(string url)
        {
            ProcessingReportMessage processingReport = null;
            string responseContent;
            try
            {
                var stream = GetStreamFromUrl(url);
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
            catch(AmazonProcessingReportDeserializeException ex)
            {
                throw ex;
            }
            catch(Exception ex)
            {
                
            }
            return processingReport;
        }

        public CreateFeedDocumentResult CreateFeedDocument(ContentType contentType)
        {
            var contxt = LinqHelper.GetEnumMemberValue(contentType);
            var createFeedDocumentSpecification = new AmazonSpApiSDK.Models.Feeds.CreateFeedDocumentSpecification(contxt);

            CreateAuthorizedRequest(FeedsApiUrls.CreateFeedDocument, RestSharp.Method.POST, postJsonObj: createFeedDocumentSpecification);
            var response = ExecuteRequest<CreateFeedDocumentResult>(RateLimitType.Feed_CreateFeedDocument);
            if (response != null)
                return response;
            return null;
        }

        /// <summary>
        /// read full step  https://github.com/amzn/selling-partner-api-docs/blob/main/guides/en-US/use-case-guides/feeds-api-use-case-guide/feeds-api-use-case-guide_2021-06-30.md
        /// </summary>
        /// <param name="xml"></param>
        /// <param name="feedType"></param>
        /// <returns></returns>
        public string SubmitFeed(string XmlContentOrFilePath, FeedType feedType, List<string> marketPlaceIds = null, FeedOptions feedOptions = null,ContentType contentType= ContentType.XML)
        {

            //We are creating Feed Document
            var feedCreate = CreateFeedDocument(contentType);

            var responce = string.Empty;
            //Uploading encoded invoice file
            if (contentType == ContentType.PDF)
            {
                responce = postFileData(feedCreate.Url, XmlContentOrFilePath, contentType);
            }
            else if(contentType == ContentType.TXT)
            {
                responce = postXMLData(feedCreate.Url, XmlContentOrFilePath, contentType);
            }
            else
            {
                responce = postXMLData(feedCreate.Url, XmlContentOrFilePath);
            }

            CreateFeedSpecification createFeedSpecification = new CreateFeedSpecification()
            {
                FeedType = feedType.ToString(),
                InputFeedDocumentId = feedCreate.FeedDocumentId,
                MarketplaceIds = marketPlaceIds ?? new List<string> { AmazonCredential.MarketPlace.ID },
                FeedOptions = feedOptions
            };

            //Submit XML
            var feed = CreateFeed(createFeedSpecification);

            return feed.FeedId;
        }


        private static Stream GetStreamFromUrl(string url)
        {
            byte[] imageData = null;

            using (var wc = new System.Net.WebClient())
                imageData = wc.DownloadData(url);

            return new MemoryStream(imageData);
        }

        private string postXMLData(string destinationUrl, string requestXml, ContentType contentType= ContentType.XML)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(destinationUrl);
            byte[] bytes;
            bytes = System.Text.Encoding.ASCII.GetBytes(requestXml);
            request.ContentType = LinqHelper.GetEnumMemberValue(contentType);
            request.ContentLength = bytes.Length;
            request.Method = "PUT";
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();
            HttpWebResponse response;
            response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream responseStream = response.GetResponseStream();
                string responseStr = new StreamReader(responseStream).ReadToEnd();
                return responseStr;
            }
            return null;
        }

        private string postFileData(string destinationUrl, string pathFile, ContentType contentType = ContentType.XML)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(destinationUrl);
            byte[] bytes= File.ReadAllBytes(pathFile);
            //bytes = System.Text.Encoding.ASCII.GetBytes(requestXml);
            request.ContentType = LinqHelper.GetEnumMemberValue(contentType);
            request.ContentLength = bytes.Length;
            request.Method = "PUT";
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();
            HttpWebResponse response;
            response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream responseStream = response.GetResponseStream();
                string responseStr = new StreamReader(responseStream).ReadToEnd();
                return responseStr;
            }
            return null;
        }

    }
}
