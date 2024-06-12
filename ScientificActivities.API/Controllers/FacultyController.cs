using ScientificActivities.Data.Models.University;
using ScientificActivities.Service.ModelRequest.University;
using ScientificActivities.Service.Services.Interface.Services;

namespace ScientificActivities.API.Controllers;

public class FacultyController : BaseController<Faculty, FacultyRequest, IFacultyService>
{
    public FacultyController(IFacultyService service) : base(service)
    {
    }
}