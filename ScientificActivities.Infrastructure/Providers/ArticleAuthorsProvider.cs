using Microsoft.EntityFrameworkCore;
using ScientificActivities.Data.Models.Publication;
using ScientificActivities.Data.Models.University;
using ScientificActivities.Service.Services.Interface.Providers;

namespace ScientificActivities.Infrastructure.Providers;

public class ArticleAuthorsProvider : IArticleAuthorsProvider
{
    private readonly ApplicationContext _applicationContext;

        public ArticleAuthorsProvider(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<Guid> AddAsync(ArticlesAuthors entity, CancellationToken cancellationToken)
        {
            _applicationContext.Add(entity);
            await _applicationContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return entity.Id;
        }

        public async Task<ArticlesAuthors?> FindAsync(Guid id, CancellationToken cancellationToken)
        {
            var articleAuthor = await _applicationContext.ArticlesAuthors
                .Include(aa => aa.Article)
                .Include(aa => aa.Author)
                .FirstOrDefaultAsync(aa => aa.Id == id, cancellationToken: cancellationToken).ConfigureAwait(false);
            return articleAuthor;
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var articleAuthor = await FindAsync(id, cancellationToken);
            ArgumentNullException.ThrowIfNull(articleAuthor);
            _applicationContext.Remove(articleAuthor);
            await _applicationContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<ArticlesAuthors> UpdateAsync(ArticlesAuthors entity, CancellationToken cancellationToken)
        {
            _applicationContext.Update(entity);
            await _applicationContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return entity;
        }

        public async Task<List<ArticlesAuthors>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _applicationContext.ArticlesAuthors
                .Include(aa => aa.Article)
                .Include(aa => aa.Author)
                .ToListAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        public async Task<Article?> GetArticleByIdAsync(Guid articleId, CancellationToken cancellationToken)
        {
            var article = await _applicationContext.Articles
                .FirstOrDefaultAsync(a => a.Id == articleId, cancellationToken: cancellationToken).ConfigureAwait(false);
            return article;
        }

        public async Task<Author?> GetAuthorByIdAsync(Guid authorId, CancellationToken cancellationToken)
        {
            var author = await _applicationContext.Authors
                .FirstOrDefaultAsync(a => a.Id == authorId, cancellationToken: cancellationToken).ConfigureAwait(false);
            return author;
        }
}