using ScientificActivities.Data.Models.Publication;
using ScientificActivities.Service.ModelRequest.Publication;
using ScientificActivities.Service.Services.Interface.Services;

namespace ScientificActivities.API.Controllers;

public class ArticleController : BaseController<Article, ArticlesRequest, IArticlesService>
{
    public ArticleController(IArticlesService service) : base(service)
    {
    }
}