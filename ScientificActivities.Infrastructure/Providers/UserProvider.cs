using Microsoft.EntityFrameworkCore;
using ScientificActivities.Data.Models.UserActivity;
using ScientificActivities.Service.Services.Interface.Providers;

namespace ScientificActivities.Infrastructure.Providers;

public class UserProvider : IUserProvider
{
    private readonly ApplicationContext _applicationContext;

    public UserProvider(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    public async Task<Guid> AddAsync(User entity, CancellationToken cancellationToken)
    {
        _applicationContext.Add(entity);
        await _applicationContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        return entity.Id;
    }

    public async Task<User?> FindAsync(Guid id, CancellationToken cancellationToken)
    {
        var user = await _applicationContext.Users
            .FirstOrDefaultAsync(u => u.Id == id, cancellationToken: cancellationToken).ConfigureAwait(false);
        return user;
    }

    public async Task<User?> FindAsync(string name, string surname, CancellationToken cancellationToken)
    {
        var user = await _applicationContext.Users
            .FirstOrDefaultAsync(u => u.FirstName == name &&
                u.SureName == surname, 
                cancellationToken: cancellationToken).ConfigureAwait(false);
        return user;
    }

    public async Task<User?> FindAsync(string email, CancellationToken cancellationToken)
    {
        var user = await _applicationContext.Users
            .FirstOrDefaultAsync(u => u.Email == email, cancellationToken: cancellationToken).ConfigureAwait(false);
        return user;
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var user = await FindAsync(id, cancellationToken);
        ArgumentNullException.ThrowIfNull(user);
        _applicationContext.Remove(user);
        await _applicationContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    }

    public async Task<User> UpdateAsync(User entity, CancellationToken cancellationToken)
    {
        _applicationContext.Update(entity);
        await _applicationContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        return entity;
    }

    public async Task<List<User>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _applicationContext.Users.ToListAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
    }
}