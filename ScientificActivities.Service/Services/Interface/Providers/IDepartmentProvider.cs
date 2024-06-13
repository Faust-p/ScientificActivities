using ScientificActivities.Data.Models.University;

namespace ScientificActivities.Service.Services.Interface.Providers;

public interface IDepartmentProvider : IProvider<Department>
{
    Task<Department?> FindAsync(string name, CancellationToken cancellationToken);
}