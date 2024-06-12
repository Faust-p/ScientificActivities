using ScientificActivities.Data.Models.Publication;
using ScientificActivities.Service.ModelRequest.Publication;
using ScientificActivities.Service.Services.Interface.Services;

namespace ScientificActivities.API.Controllers;

public class PublishingHouseController : BaseController<PublishingHouse, PublishingHouseRequest, IPublishingHouseService>
{
    public PublishingHouseController(IPublishingHouseService service) : base(service)
    {
    }
}