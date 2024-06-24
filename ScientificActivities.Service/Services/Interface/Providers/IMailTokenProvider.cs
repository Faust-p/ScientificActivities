using ScientificActivities.Data.Models;
using ScientificActivities.Data.Models.UserActivity;

namespace ScientificActivities.Service.Services.Interface.Providers;

public interface IMailTokenProvider
{
    Task<Guid> AddAsync(MailToken entity, CancellationToken cancellationToken);
}