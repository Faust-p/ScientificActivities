using ScientificActivities.Parsers;
using ScientificActivities.Parsers.Parsers;
using ScientificActivities.Service.ModelRequest.Publication;
using ScientificActivities.Service.Services.Interface.Providers.Parsers;

namespace ScientificActivities.Infrastructure.Providers.Parsers;

public class JournalParseProvider : IJournalParseProvider
{
    public Task<JournalRequest> ParseAsync(string url, CancellationToken cancellationToken)
    {
         var parserResult = JournalHelper.TypeOfJournal(url);
        
         var journalRequest = new JournalRequest
        {
            Name = parserResult.Name,
            PublishingHouseId = parserResult.PublishingHouseId,
            Status = parserResult.Status
        };
        return Task.FromResult(journalRequest);
    }
}