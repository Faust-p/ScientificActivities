using Microsoft.Extensions.DependencyInjection;
using ScientificActivities.Service.Services;
using ScientificActivities.Service.Services.Interface.Services;

namespace ScientificActivities.DependencyInjection;

public static partial class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection service)
    {
        service.AddScoped<IArticleAuthorsService, ArticleAuthorsService>();
        service.AddScoped<IArticlesService, ArticlesService>();
        service.AddScoped<IAuthorService, AuthorService>();
        service.AddScoped<IDepartmentService, DepartmentService>();
        service.AddScoped<IFacultyService, FacultyService>();
        service.AddScoped<IJournalService, JournalService>();
        service.AddScoped<IPublishingHouseService, PublishingHouseService>();
        service.AddScoped<IUserService, UserService>();
        
        return service;
    }
}