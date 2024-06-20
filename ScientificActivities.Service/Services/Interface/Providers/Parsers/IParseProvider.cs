namespace ScientificActivities.Service.Services.Interface.Providers.Parsers;

public interface IParseProvider<TEntity>
{
    Task<TEntity> ParseAsync(string url, CancellationToken cancellationToken);
}
