using ScientificActivities.Data.Models.Publication;

namespace ScientificActivities.Service.Services.Interface.Providers;

public interface IArticlesProvider : IProvider<Article>
{
    Task<Article?> FindAsync(string name, CancellationToken cancellationToken);
}