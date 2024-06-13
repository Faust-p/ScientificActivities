using Microsoft.EntityFrameworkCore;
using ScientificActivities.Data.Models.University;
using ScientificActivities.Service.Services.Interface.Providers;

namespace ScientificActivities.Infrastructure.Providers;

public class FacultyProvider :IFacultyProvider
{
    private readonly ApplicationContext _applicationContext;

        public FacultyProvider(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<Guid> AddAsync(Faculty entity, CancellationToken cancellationToken)
        {
            _applicationContext.Add(entity);
            await _applicationContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return entity.Id;
        }

        public async Task<Faculty?> FindAsync(Guid id, CancellationToken cancellationToken)
        {
            var faculty = await _applicationContext.Faculties
                .FirstOrDefaultAsync(f => f.Id == id, cancellationToken: cancellationToken).ConfigureAwait(false);
            return faculty;
        }

        public async Task<Faculty?> FindAsync(string name, CancellationToken cancellationToken)
        {
            var faculty = await _applicationContext.Faculties
                .FirstOrDefaultAsync(f => f.Name == name, cancellationToken: cancellationToken).ConfigureAwait(false);
            return faculty;
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var faculty = await FindAsync(id, cancellationToken);
            ArgumentNullException.ThrowIfNull(faculty);
            _applicationContext.Remove(faculty);
            await _applicationContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Faculty> UpdateAsync(Faculty entity, CancellationToken cancellationToken)
        {
            _applicationContext.Update(entity);
            await _applicationContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return entity;
        }

        public async Task<List<Faculty>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _applicationContext.Faculties.ToListAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
        }
}