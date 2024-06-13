using Microsoft.EntityFrameworkCore;
using ScientificActivities.Data.Models.University;
using ScientificActivities.Service.Services.Interface.Providers;

namespace ScientificActivities.Infrastructure.Providers;

public class AuthorProvider : IAuthorProvider
{
    private readonly ApplicationContext _applicationContext;

        public AuthorProvider(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<Guid> AddAsync(Author entity, CancellationToken cancellationToken)
        {
            _applicationContext.Add(entity);
            await _applicationContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return entity.Id;
        }

        public async Task<Author?> FindAsync(Guid id, CancellationToken cancellationToken)
        {
            var author = await _applicationContext.Authors
                .FirstOrDefaultAsync(a => a.Id == id, cancellationToken: cancellationToken).ConfigureAwait(false);
            return author;
        }

        public async Task<Author?> FindAsync(string firstName, string lastName, CancellationToken cancellationToken)
        {
            var author = await _applicationContext.Authors
                .FirstOrDefaultAsync(a => a.FirstName == firstName && a.LastName == lastName, cancellationToken: cancellationToken).ConfigureAwait(false);
            return author;
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var author = await FindAsync(id, cancellationToken);
            ArgumentNullException.ThrowIfNull(author);
            _applicationContext.Remove(author);
            await _applicationContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Author> UpdateAsync(Author entity, CancellationToken cancellationToken)
        {
            _applicationContext.Update(entity);
            await _applicationContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return entity;
        }

        public async Task<List<Author>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _applicationContext.Authors.ToListAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
        }
}