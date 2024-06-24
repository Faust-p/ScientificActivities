using ScientificActivities.Data;
using ScientificActivities.Service.ModelRequest;

namespace ScientificActivities.Service.Services.Interface.Services;

public interface IBaseService<TEntityDb, TEntityRequest>
    where TEntityDb: IBaseModel
    where TEntityRequest: BaseModelRequest
{
    Task<Guid> CreateAsync(TEntityRequest entityRequest, CancellationToken cancellationToken);
    Task<TEntityDb?> GetAsync(Guid id, CancellationToken cancellationToken);
    Task<TEntityDb> UpdateAsync(TEntityRequest entityRequest, CancellationToken cancellationToken);
    Task<List<TEntityDb>> GetAllAsync(CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
}