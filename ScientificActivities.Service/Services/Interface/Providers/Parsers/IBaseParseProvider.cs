namespace ScientificActivities.Service.Services.Interface.Providers.Parsers;

public interface IBaseParseProvider<TEntity>
{
    Task<TEntity> ParseAsync(string url, CancellationToken cancellationToken);
}
