using ScientificActivities.Data.Models.Publication;
using ScientificActivities.Data.Models.University;

namespace ScientificActivities.Service.Services.Interface.Providers;

public interface IArticleAuthorsProvider : IProvider<ArticlesAuthors>
{
    Task<Article?> GetArticleByIdAsync(Guid articleId, CancellationToken cancellationToken);
    Task<Author?> GetAuthorByIdAsync(Guid authorId, CancellationToken cancellationToken);
}