using ScientificActivities.Data.Models.UserActivity;

namespace ScientificActivities.Service.Services.Interface.Providers;

public interface IUserProvider : IProvider<User>
{
    Task<User?> FindAsync(string name, string surname, CancellationToken cancellationToken);
    
    Task<User?> FindAsync(string email, CancellationToken cancellationToken);
}