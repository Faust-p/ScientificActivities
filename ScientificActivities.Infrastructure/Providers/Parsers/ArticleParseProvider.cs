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
            Name = parserResult.Item1.Name,
            Number = parserResult.Item1.Number,
            Year = parserResult.Item1.Year,
            Pages = parserResult.Item1.Pages,
            Rsci = parserResult.Item1.Rsci,
            Vak = parserResult.Item1.Vak,
            JournalId = parserResult.Item1.JournalId
        };
        return Task.FromResult(journalRequest);
    }
}