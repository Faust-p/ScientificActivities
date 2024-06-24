using ScientificActivities.Data.Models.Publication;
using ScientificActivities.Service.ModelRequest.Publication;

namespace ScientificActivities.Service.Services.Interface.Services;

public interface IPublishingHouseService : IBaseNameService<PublishingHouse, PublishingHouseRequest>
{
    Task<Guid> ParseAsync(string url, CancellationToken cancellationToken);
}