using ScientificActivities.Data.Models.University;

namespace ScientificActivities.Service.Services.Interface.Providers;

public interface IFacultyProvider : IProvider<Faculty>
{
    Task<Faculty?> FindAsync(string name, CancellationToken cancellationToken);
}