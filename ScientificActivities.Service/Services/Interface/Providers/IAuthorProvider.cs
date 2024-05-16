using ScientificActivities.Data.Models;
using ScientificActivities.Data.Models.University;

namespace ScientificActivities.Service.Services.Interface.Providers;

public interface IAuthorProvider : IProvider<Author>
{
    Task<Author?> FindAsync(string firstName, string lastName, CancellationToken cancellationToken);
}