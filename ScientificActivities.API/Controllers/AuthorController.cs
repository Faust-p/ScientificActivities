using ScientificActivities.Data.Models.University;
using ScientificActivities.Service.ModelRequest.University;
using ScientificActivities.Service.Services.Interface.Services;

namespace ScientificActivities.API.Controllers;

public class AuthorController : BaseController<Author, AuthorRequest, IAuthorService>
{
    public AuthorController(IAuthorService service) : base(service)
    {
    }
}