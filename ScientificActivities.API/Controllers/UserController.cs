using ScientificActivities.Data.Models.UserActivity;
using ScientificActivities.Service.ModelRequest.UserActivity;
using ScientificActivities.Service.Services.Interface.Services;

namespace ScientificActivities.API.Controllers;

public class UserController : BaseController<User, UserRequest, IUserService>
{
    public UserController(IUserService service) : base(service)
    {
    }
}