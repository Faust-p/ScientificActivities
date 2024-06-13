using ScientificActivities.Data.Models.University;
using ScientificActivities.Service.ModelRequest.University;
using ScientificActivities.Service.Services.Interface.Services;

namespace ScientificActivities.API.Controllers;

public class DepartmentController : BaseController<Department, DepartmentRequest, IDepartmentService>
{
    public DepartmentController(IDepartmentService service) : base(service)
    {
    }
}