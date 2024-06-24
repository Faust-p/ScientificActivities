using ScientificActivities.Parsers;
using ScientificActivities.Service.ModelRequest.Parser;
using ScientificActivities.Service.Services.Interface.Providers.Parsers;
using ScientificActivities.Service.Services.Interface.Services;

namespace ScientificActivities.Infrastructure.Providers.Parsers;

public class ParseProvider : IParseProvider
{
    public Task<ParseRequest> ParseAsync(string url, CancellationToken cancellationToken)
    {
        var parserResult = ParseHelper.FullParse(url);
        return Task.FromResult(parserResult);
    }
}