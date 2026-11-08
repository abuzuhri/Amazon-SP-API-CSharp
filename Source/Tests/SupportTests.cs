using FikaAmazonAPI.AmazonSpApiSDK.Models.Support;
using FikaAmazonAPI.Parameter.Support;
using FikaAmazonAPI.Services;
using FikaAmazonAPI.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Tests
{
    [TestFixture]
    public class SupportTests
    {
        // Response bodies taken from the static sandbox examples in Amazon's support_2025-02-01.json model.
        private const string GetCaseResponse = @"{""caseId"": ""1234567890"", ""status"": ""RESOLVED"", ""subject"": ""test subject"", ""primaryEmail"": ""test_seller@domain.com"", ""ccEmails"": [""test_seller1@domain.com"", ""test_seller2@domain.com""], ""createdDate"": ""2024-01-12T10:00:00.000Z"", ""lastUpdatedDate"": ""2024-01-12T10:00:00.000Z"", ""resolvedDate"": ""2024-01-12T10:00:00.000Z"", ""appointments"": [{""appointmentId"": ""TestAppointmentId"", ""answeringParty"": ""RECEPTIONIST"", ""phoneNumber"": {""countryCode"": ""US"", ""number"": ""1234567890"", ""extension"": ""1""}, ""callbackTiming"": {""earliestCallbackTime"": ""2024-01-12T10:00:00.000Z"", ""latestCallbackTime"": ""2024-01-12T11:00:00.000Z""}, ""status"": ""SCHEDULED""}]}";

        private const string ListContactsResponse = @"{""nextToken"": ""SampleToken"", ""contacts"": [{""contactId"": ""TestContactId"", ""channel"": ""EMAIL"", ""emailContent"": {""sender"": {""displayName"": ""Test Selling Partner Name"", ""role"": ""SELLING_PARTNER""}, ""message"": ""sample email message"", ""attachments"": [{""name"": ""testAttachment.txt"", ""downloadUrl"": ""https://filelocation/filename""}]}, ""createdDate"": ""2024-01-12T11:00:00.000Z""}]}";

        [Test]
        public void Case_DeserialisesSandboxGetCaseResponse()
        {
            var supportCase = JsonConvert.DeserializeObject<Case>(GetCaseResponse)!;

            Assert.That(supportCase.CaseId, Is.EqualTo("1234567890"));
            Assert.That(supportCase.Status, Is.EqualTo(Case.StatusEnum.RESOLVED));
            Assert.That(supportCase.CcEmails, Is.EqualTo(new[] { "test_seller1@domain.com", "test_seller2@domain.com" }));
            Assert.That(supportCase.CreatedDate, Is.EqualTo(new DateTime(2024, 1, 12, 10, 0, 0, DateTimeKind.Utc)));

            var appointment = supportCase.Appointments.Single();
            Assert.That(appointment.Status, Is.EqualTo(Appointment.StatusEnum.SCHEDULED));
            Assert.That(appointment.AnsweringParty, Is.EqualTo(Appointment.AnsweringPartyEnum.RECEPTIONIST));
            Assert.That(appointment.PhoneNumber.Extension, Is.EqualTo("1"));
            Assert.That(appointment.CallbackTiming.LatestCallbackTime, Is.EqualTo(new DateTime(2024, 1, 12, 11, 0, 0, DateTimeKind.Utc)));
        }

        [Test]
        public void ListContactsResult_DeserialisesSandboxEmailContact()
        {
            var result = JsonConvert.DeserializeObject<ListContactsResult>(ListContactsResponse)!;

            Assert.That(result.NextToken, Is.EqualTo("SampleToken"));
            var contact = result.Contacts.Single();
            Assert.That(contact.Channel, Is.EqualTo(Contact.ChannelEnum.EMAIL));
            Assert.That(contact.EmailContent.Sender.Role, Is.EqualTo(Participant.RoleEnum.SELLINGPARTNER));
            Assert.That(contact.EmailContent.Attachments.Single().DownloadUrl, Is.EqualTo("https://filelocation/filename"));
            Assert.That(contact.ChatContent, Is.Null);
        }

        [Test]
        public void ListContactsResult_DeserialisesChatEvents()
        {
            const string json = @"{""contacts"": [{""contactId"": ""C1"", ""channel"": ""CHAT"", ""createdDate"": ""2024-01-12T11:00:00Z"", ""chatContent"": {""transcript"": ""hello"", ""events"": [{""timestamp"": ""2024-01-12T11:00:00Z"", ""type"": ""PARTICIPANT_JOINED"", ""participant"": {""displayName"": ""Amazon"", ""role"": ""AMAZON""}}, {""timestamp"": ""2024-01-12T11:01:00Z"", ""type"": ""MESSAGE"", ""message"": ""hello""}]}}]}";

            var contact = JsonConvert.DeserializeObject<ListContactsResult>(json)!.Contacts.Single();

            Assert.That(contact.Channel, Is.EqualTo(Contact.ChannelEnum.CHAT));
            Assert.That(contact.ChatContent.Events.Select(e => e.Type),
                Is.EqualTo(new[] { ChatEvent.TypeEnum.PARTICIPANTJOINED, ChatEvent.TypeEnum.MESSAGE }));
            Assert.That(contact.ChatContent.Events[0].Participant.Role, Is.EqualTo(Participant.RoleEnum.AMAZON));
        }

        [Test]
        public void Equals_ReturnsFalseWhenOnlyOneSideHasAList()
        {
            var timestamp = new DateTime(2024, 1, 12, 11, 0, 0, DateTimeKind.Utc);
            var withAttachments = new ChatEvent(timestamp: timestamp, type: ChatEvent.TypeEnum.ATTACHMENT,
                attachments: new List<Attachment> { new Attachment(name: "file.txt") });
            var withoutAttachments = new ChatEvent(timestamp: timestamp, type: ChatEvent.TypeEnum.ATTACHMENT);

            Assert.That(withAttachments.Equals(withoutAttachments), Is.False);
            Assert.That(withoutAttachments.Equals(withAttachments), Is.False);
        }

        [Test]
        public void ParameterListCases_SerialisesToAmazonRequestBody()
        {
            var parameter = new ParameterListCases
            {
                CaseFilters = new CaseFilters(
                    caseStatuses: new List<CaseFilters.CaseStatusesEnum> { CaseFilters.CaseStatusesEnum.PENDINGMERCHANTACTION },
                    createdDate: new DateFilter(after: new DateTime(2026, 9, 1, 0, 0, 0, DateTimeKind.Utc)),
                    subjectKeywords: "refund"),
                SortOrder = ListCasesRequest.SortOrderEnum.ASC,
                MaxResults = 25,
                MaxNumberOfPages = 2
            };

            var body = JObject.Parse(JsonConvert.SerializeObject(parameter.ToRequest()));

            Assert.That(body["sortOrder"]!.Value<string>(), Is.EqualTo("ASC"));
            Assert.That(body["maxResults"]!.Value<int>(), Is.EqualTo(25));
            Assert.That(body["caseFilters"]!["caseStatuses"]![0]!.Value<string>(), Is.EqualTo("PENDING_MERCHANT_ACTION"));
            Assert.That(body["caseFilters"]!["subjectKeywords"]!.Value<string>(), Is.EqualTo("refund"));
            Assert.That(body["caseFilters"]!["createdDate"]!["after"], Is.Not.Null);
            // Unset values are omitted, and paging controls never reach Amazon.
            Assert.That(body.ContainsKey("nextToken"), Is.False);
            Assert.That(body["caseFilters"]!["createdDate"]!.Value<JObject>()!.ContainsKey("before"), Is.False);
            Assert.That(body.ContainsKey("maxNumberOfPages"), Is.False);
        }

        [Test]
        public void ParameterListContacts_BuildsQueryParameters()
        {
            var parameter = new ParameterListContacts
            {
                MaxResults = 50,
                NextToken = "abc",
                SortOrder = SupportSortOrder.ASC,
                MaxNumberOfPages = 1
            };

            var query = parameter.getParameters();

            Assert.That(query, Is.EquivalentTo(new[]
            {
                new KeyValuePair<string, string>("maxResults", "50"),
                new KeyValuePair<string, string>("nextToken", "abc"),
                new KeyValuePair<string, string>("sortOrder", "ASC"),
            }));
        }

        [Test]
        [TestCase(0)]
        [TestCase(51)]
        public void ValidateListCases_RejectsMaxResultsOutOfRange(int maxResults)
        {
            Assert.Throws<InvalidDataException>(() =>
                SupportService.ValidateListCases(new ParameterListCases { MaxResults = maxResults }));
        }

        [Test]
        public void ValidateListCases_RejectsSubjectKeywordsOver200Characters()
        {
            var parameter = new ParameterListCases { CaseFilters = new CaseFilters(subjectKeywords: new string('a', 201)) };

            Assert.Throws<InvalidDataException>(() => SupportService.ValidateListCases(parameter));
        }

        [Test]
        public void ValidateListCases_AcceptsEmptyParameter()
        {
            Assert.DoesNotThrow(() => SupportService.ValidateListCases(new ParameterListCases()));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        public void ValidateListContacts_RequiresCaseId(string? caseId)
        {
            Assert.Throws<InvalidDataException>(() =>
                SupportService.ValidateListContacts(caseId!, new ParameterListContacts()));
        }

        [Test]
        public void RateLimitsDefinitions_RegistersEverySupportOperation()
        {
            var definitions = RateLimitsDefinitions.RateLimitsTime();

            foreach (var type in new[] { RateLimitType.Support_ListCases, RateLimitType.Support_GetCase, RateLimitType.Support_ListContacts })
                Assert.That(definitions.ContainsKey(type), Is.True, type.ToString());
        }
    }
}
