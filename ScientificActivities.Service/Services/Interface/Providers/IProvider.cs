namespace ScientificActivities.Service.Services.Interface.Providers;

public interface IProvider<TEntity>
{
    Task<Guid> AddAsync(TEntity entity, CancellationToken cancellationToken);
    Task<TEntity?> FindAsync(Guid id, CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken);
    Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken);
}