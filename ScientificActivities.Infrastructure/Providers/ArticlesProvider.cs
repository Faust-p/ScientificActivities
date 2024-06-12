using Microsoft.EntityFrameworkCore;
using ScientificActivities.Data.Models.Publication;
using ScientificActivities.Service.Services.Interface.Providers;

namespace ScientificActivities.Infrastructure.Providers;

public class ArticlesProvider : IArticlesProvider
{
    private readonly ApplicationContext _applicationContext;

        public ArticlesProvider(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<Guid> AddAsync(Article entity, CancellationToken cancellationToken)
        {
            _applicationContext.Add(entity);
            await _applicationContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return entity.Id;
        }

        public async Task<Article?> FindAsync(Guid id, CancellationToken cancellationToken)
        {
            var article = await _applicationContext.Articles
                .FirstOrDefaultAsync(a => a.Id == id, cancellationToken: cancellationToken).ConfigureAwait(false);
            return article;
        }

        public async Task<Article?> FindAsync(string name, CancellationToken cancellationToken)
        {
            var article = await _applicationContext.Articles
                .FirstOrDefaultAsync(a => a.Name == name, cancellationToken: cancellationToken).ConfigureAwait(false);
            return article;
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var article = await FindAsync(id, cancellationToken);
            ArgumentNullException.ThrowIfNull(article);
            _applicationContext.Remove(article);
            await _applicationContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Article> UpdateAsync(Article entity, CancellationToken cancellationToken)
        {
            _applicationContext.Update(entity);
            await _applicationContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return entity;
        }

        public async Task<List<Article>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _applicationContext.Articles.ToListAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
        }
}