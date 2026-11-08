using FikaAmazonAPI.AmazonSpApiSDK.Models.Support;
using FikaAmazonAPI.Parameter.Support;

namespace FikaAmazonAPI.SampleCode;

public class SupportSample
{
    AmazonConnection amazonConnection;

    public SupportSample(AmazonConnection amazonConnection)
    {
        this.amazonConnection = amazonConnection;
    }

    public void ListCases()
    {
        // Pages through every result page internally and returns a flat list.
        // Set MaxNumberOfPages to stop after a given number of pages.
        var cases = amazonConnection.Support.ListCases(new ParameterListCases
        {
            CaseFilters = new CaseFilters(
                caseStatuses: new List<CaseFilters.CaseStatusesEnum> { CaseFilters.CaseStatusesEnum.PENDINGMERCHANTACTION },
                createdDate: new DateFilter(after: DateTime.UtcNow.AddDays(-30))),
            SortOrder = ListCasesRequest.SortOrderEnum.DESC,
            MaxResults = 50
        });
    }

    public void ListCasesOnePageWithNextToken()
    {
        // ONLY USE THIS SAMPLE IF YOU NEED TO GET ONE PAGE EACH TIME, otherwise remove parameter
        // 'MaxNumberOfPages' and the library will fetch all cases for you
        var parameter = new ParameterListCases
        {
            MaxResults = 10,
            MaxNumberOfPages = 1
        };

        var cases = amazonConnection.Support.ListCases(parameter);

        // ListCases leaves the token for the next unfetched page on the parameter object.
        while (!string.IsNullOrEmpty(parameter.NextToken))
        {
            var moreCases = amazonConnection.Support.ListCasesByNextToken(parameter);
            parameter.NextToken = moreCases.NextToken;
        }
    }

    public void GetCase()
    {
        var supportCase = amazonConnection.Support.GetCase("CASE_ID");
    }

    public void ListContacts()
    {
        var contacts = amazonConnection.Support.ListContacts("CASE_ID", new ParameterListContacts
        {
            SortOrder = SupportSortOrder.ASC,
            MaxResults = 50
        });

        foreach (var contact in contacts)
        {
            // Only the content matching the contact's channel is populated.
            // Attachment download URLs expire after 15 minutes.
            switch (contact.Channel)
            {
                case Contact.ChannelEnum.EMAIL:
                    var message = contact.EmailContent?.Message;
                    break;
                case Contact.ChannelEnum.CHAT:
                    var transcript = contact.ChatContent?.Transcript;
                    break;
                case Contact.ChannelEnum.PHONE:
                    var callNotes = contact.PhoneContent?.CallNotes;
                    break;
            }
        }
    }
}
