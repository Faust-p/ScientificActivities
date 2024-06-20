using ScientificActivities.Parsers;
using ScientificActivities.Service.ModelRequest.Publication;
using ScientificActivities.Service.Services.Interface.Providers.Parsers;

namespace ScientificActivities.Infrastructure.Providers.Parsers;

public class ArticleParseProvider : IArticleParseProvider
{
    public Task<ArticlesRequest> ParseAsync(string url, CancellationToken cancellationToken)
    {
        var parserResult = ArticleHelper.TypeOfJournal(url);
        
        var journalRequest = new ArticlesRequest
        {
            Name = parserResult.Name,
            Number = parserResult.Number,
            Year = parserResult.Year,
            Pages = parserResult.Pages,
            Rsci = parserResult.Rsci,
            Vak = parserResult.Vak,
            JournalId = parserResult.JournalId
        };
        return Task.FromResult(journalRequest);
    }
}