using ScientificActivities.Data.Models.Publication;
using ScientificActivities.Service.ModelRequest.Publication;
using ScientificActivities.Service.Services.Interface.Services;

namespace ScientificActivities.API.Controllers;

public class JournalController : BaseController<Journal, JournalRequest, IJournalService>
{
    public JournalController(IJournalService service) : base(service)
    {
    }
}