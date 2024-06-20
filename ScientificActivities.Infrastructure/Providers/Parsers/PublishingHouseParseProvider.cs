using ScientificActivities.Parsers.Parsers;
using ScientificActivities.Service.ModelRequest.Publication;
using ScientificActivities.Service.Services.Interface.Providers.Parsers;

namespace ScientificActivities.Infrastructure.Providers.Parsers;

public class PublishingHouseParseProvider : IPublishingHouseParseProvider
{
    public Task<PublishingHouseRequest> ParseAsync(string url, CancellationToken cancellationToken)
    {
        var parserResult = PublishingHouseParser.ParseByPublishinHouse(url);
        
        var publishingHouseRequest = new PublishingHouseRequest
        {
            Name = parserResult.Name,
            Country = parserResult.Country,
            City = parserResult.City
        };
        return Task.FromResult(publishingHouseRequest);
    }
}