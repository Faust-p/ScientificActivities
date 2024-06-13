using Microsoft.EntityFrameworkCore;
using ScientificActivities.Data.Models.Publication;
using ScientificActivities.Service.Services.Interface.Providers;

namespace ScientificActivities.Infrastructure.Providers;

public class JournalProvider :IJournalProvider
{
    private readonly ApplicationContext _applicationContext;

        public JournalProvider(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<Guid> AddAsync(Journal entity, CancellationToken cancellationToken)
        {
            _applicationContext.Add(entity);
            await _applicationContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return entity.Id;
        }

        public async Task<Journal?> FindAsync(Guid id, CancellationToken cancellationToken)
        {
            var journal = await _applicationContext.Journals
                .FirstOrDefaultAsync(j => j.Id == id, cancellationToken: cancellationToken).ConfigureAwait(false);
            return journal;
        }

        public async Task<Journal?> FindAsync(string name, CancellationToken cancellationToken)
        {
            var journal = await _applicationContext.Journals
                .FirstOrDefaultAsync(j => j.Name == name, cancellationToken: cancellationToken).ConfigureAwait(false);
            return journal;
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var journal = await FindAsync(id, cancellationToken);
            ArgumentNullException.ThrowIfNull(journal);
            _applicationContext.Remove(journal);
            await _applicationContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Journal> UpdateAsync(Journal entity, CancellationToken cancellationToken)
        {
            _applicationContext.Update(entity);
            await _applicationContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return entity;
        }

        public async Task<List<Journal>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _applicationContext.Journals.ToListAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
        }
}