using ScientificActivities.Data.Models;
using ScientificActivities.Data.Models.UserActivity;
using ScientificActivities.Service.Services.Interface.Providers;

namespace ScientificActivities.Infrastructure.Providers;

public class MailTokenProvider : IMailTokenProvider
{
    private readonly ApplicationContext _applicationContext;

    public MailTokenProvider(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    public async Task<Guid> AddAsync(MailToken entity, CancellationToken cancellationToken)
    {
        _applicationContext.Add(entity);
        await _applicationContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        return entity.Id;
    }
}