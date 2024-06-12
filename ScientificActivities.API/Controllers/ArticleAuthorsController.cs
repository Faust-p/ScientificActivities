using Microsoft.AspNetCore.Mvc;
using ScientificActivities.Data.Models.Publication;
using ScientificActivities.Service.ModelRequest.Publication;
using ScientificActivities.Service.Services.Interface.Services;

namespace ScientificActivities.API.Controllers;

public class ArticleAuthorsController : BaseController<ArticlesAuthors, ArticleAuthorsRequest, IArticleAuthorsService>
{
    public ArticleAuthorsController(IArticleAuthorsService service) : base(service)
    {
    }
}