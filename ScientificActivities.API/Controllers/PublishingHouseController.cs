using Microsoft.AspNetCore.Mvc;
using ScientificActivities.Data.Models.Publication;
using ScientificActivities.Service.ModelRequest.Publication;
using ScientificActivities.Service.Services.Interface.Services;

namespace ScientificActivities.API.Controllers;

public class PublishingHouseController : BaseController<PublishingHouse, PublishingHouseRequest, IPublishingHouseService>
{
    public PublishingHouseController(IPublishingHouseService service) : base(service)
    {
    }
    
    [HttpPost("CreateParse")]
    public async Task<IActionResult> CreateParseAsync(string url)
    {
        ArgumentNullException.ThrowIfNull(url);
        var id = await _service.CreateParseAsync(url, new CancellationToken());
        return Ok(id);
    }
}