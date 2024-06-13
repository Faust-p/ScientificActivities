using Microsoft.EntityFrameworkCore;
using ScientificActivities.Data.Models.University;
using ScientificActivities.Service.Services.Interface.Providers;

namespace ScientificActivities.Infrastructure.Providers;

public class DepartmentProvider : IDepartmentProvider
{
    private readonly ApplicationContext _applicationContext;

        public DepartmentProvider(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<Guid> AddAsync(Department entity, CancellationToken cancellationToken)
        {
            _applicationContext.Add(entity);
            await _applicationContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return entity.Id;
        }

        public async Task<Department?> FindAsync(Guid id, CancellationToken cancellationToken)
        {
            var department = await _applicationContext.Departments
                .FirstOrDefaultAsync(d => d.Id == id, cancellationToken: cancellationToken).ConfigureAwait(false);
            return department;
        }

        public async Task<Department?> FindAsync(string name, CancellationToken cancellationToken)
        {
            var department = await _applicationContext.Departments
                .FirstOrDefaultAsync(d => d.Name == name, cancellationToken: cancellationToken).ConfigureAwait(false);
            return department;
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var department = await FindAsync(id, cancellationToken);
            ArgumentNullException.ThrowIfNull(department);
            _applicationContext.Remove(department);
            await _applicationContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Department> UpdateAsync(Department entity, CancellationToken cancellationToken)
        {
            _applicationContext.Update(entity);
            await _applicationContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return entity;
        }

        public async Task<List<Department>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _applicationContext.Departments.ToListAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
        }
}