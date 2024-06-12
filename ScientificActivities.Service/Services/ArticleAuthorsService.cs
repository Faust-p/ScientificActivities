using ScientificActivities.Data.Models.Publication;
using ScientificActivities.Service.ModelRequest.Publication;
using ScientificActivities.Service.Services.Interface.Providers;
using ScientificActivities.Service.Services.Interface.Services;

namespace ScientificActivities.Service.Services;

public class ArticleAuthorsService : IArticleAuthorsService
{
    private readonly IArticleAuthorsProvider _articleAuthorsProvider;

        public ArticleAuthorsService(IArticleAuthorsProvider articleAuthorsProvider)
        {
            _articleAuthorsProvider = articleAuthorsProvider;
        }

        public async Task<Guid> CreateAsync(ArticleAuthorsRequest entityRequest, CancellationToken cancellationToken)
        {
            // Получаем объекты Article и Author
            var article = await _articleAuthorsProvider.GetArticleByIdAsync(entityRequest.ArticleId, cancellationToken);
            var author = await _articleAuthorsProvider.GetAuthorByIdAsync(entityRequest.AuthorId, cancellationToken);

            if (article == null || author == null)
            {
                throw new Exception("Article or Author not found");
            }

            var articleAuthor = new ArticlesAuthors(article, author);

            await _articleAuthorsProvider.AddAsync(articleAuthor, cancellationToken);
            return articleAuthor.Id;
        }

        public async Task<ArticlesAuthors?> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _articleAuthorsProvider.FindAsync(id, cancellationToken);
        }

        public async Task<ArticlesAuthors> UpdateAsync(ArticleAuthorsRequest entityRequest, CancellationToken cancellationToken)
        {
            var articleAuthor = await _articleAuthorsProvider.FindAsync(entityRequest.Id, cancellationToken);
            if (articleAuthor == null)
            {
                throw new Exception("ArticleAuthor not found");
            }

            // Получаем объекты Article и Author
            var article = await _articleAuthorsProvider.GetArticleByIdAsync(entityRequest.ArticleId, cancellationToken);
            var author = await _articleAuthorsProvider.GetAuthorByIdAsync(entityRequest.AuthorId, cancellationToken);

            if (article == null || author == null)
            {
                throw new Exception("Article or Author not found");
            }

            articleAuthor.Article = article;
            articleAuthor.Author = author;

            await _articleAuthorsProvider.UpdateAsync(articleAuthor, cancellationToken);
            return articleAuthor;
        }

        public async Task<List<ArticlesAuthors>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _articleAuthorsProvider.GetAllAsync(cancellationToken);
        }
}