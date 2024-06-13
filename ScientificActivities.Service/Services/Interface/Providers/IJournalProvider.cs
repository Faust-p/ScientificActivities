using ScientificActivities.Data.Models.Publication;

namespace ScientificActivities.Service.Services.Interface.Providers;

public interface IJournalProvider : IProvider<Journal>
{
    Task<Journal?> FindAsync(string name, CancellationToken cancellationToken);
}