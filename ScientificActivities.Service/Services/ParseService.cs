using ScientificActivities.Service.Services.Interface.Providers.Parsers;
using ScientificActivities.Service.Services.Interface.Services;

namespace ScientificActivities.Service.Services;

public class ParseService : IParseService
{
    private readonly IArticlesService _articlesService;
    private readonly IJournalService _journalService;
    private readonly IPublishingHouseService _publishingHouseService;
    private readonly IParseProvider _parseProvider;

    public ParseService(IArticlesService articlesService, IJournalService journalService, IPublishingHouseService publishingHouseService, IParseProvider parseProvider)
    {
        _articlesService = articlesService;
        _journalService = journalService;
        _publishingHouseService = publishingHouseService;
        _parseProvider = parseProvider;
    }

    public async Task ParseFullAsync(string url, CancellationToken cancellationToken)
    {
        var entityRequest = await _parseProvider.ParseAsync(url, cancellationToken);

        if (entityRequest.PublishingHouseRequest != null && !string.IsNullOrWhiteSpace(entityRequest.PublishingHouseRequest.Name))
        {
            entityRequest.JournalRequest.PublishingHouseId = await _publishingHouseService.CreateAsync(entityRequest.PublishingHouseRequest, cancellationToken);
        }

        entityRequest.ArticlesRequest.JournalId = await _journalService.CreateAsync(entityRequest.JournalRequest, cancellationToken);
        
        await _articlesService.CreateAsync(entityRequest.ArticlesRequest, cancellationToken);
    }
}