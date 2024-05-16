using ScientificActivities.Data.Models.Publication;

namespace ScientificActivities.Service.Services.Interface.Providers;

public interface IPublishingHouseProvider : IProvider<PublishingHouse>
{
    Task<PublishingHouse?> FindAsync(string name, CancellationToken cancellationToken);
}