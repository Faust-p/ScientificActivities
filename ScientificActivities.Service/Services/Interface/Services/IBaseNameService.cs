using ScientificActivities.Data;
using ScientificActivities.Service.ModelRequest;

namespace ScientificActivities.Service.Services.Interface.Services;

public interface IBaseNameService<TEntityDb, TEntityRequest> : IBaseService<TEntityDb, TEntityRequest>
    where TEntityDb: IBaseModel
    where TEntityRequest: BaseModelRequest
{
    Task<TEntityDb> GetAsync(string name, CancellationToken cancellationToken);
}