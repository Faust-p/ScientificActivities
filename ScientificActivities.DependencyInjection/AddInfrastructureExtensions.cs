using Microsoft.Extensions.DependencyInjection;
using ScientificActivities.Infrastructure;
using ScientificActivities.Infrastructure.Providers;
using ScientificActivities.Infrastructure.Providers.Parsers;
using ScientificActivities.Service.Services.Interface.Providers;
using ScientificActivities.Service.Services.Interface.Providers.Parsers;

namespace ScientificActivities.DependencyInjection;

public static partial class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection service)
    {
        service.AddDbContext<ApplicationContext>();
        service.AddScoped<IArticleAuthorsProvider, ArticleAuthorsProvider>();
        service.AddScoped<IArticlesProvider, ArticlesProvider>();
        service.AddScoped<IAuthorProvider, AuthorProvider>();
        service.AddScoped<IDepartmentProvider, DepartmentProvider>();
        service.AddScoped<IFacultyProvider, FacultyProvider>();
        service.AddScoped<IJournalProvider, JournalProvider>();
        service.AddScoped<IPublishingHouseProvider, PublishingHouseProvider>();
        service.AddScoped<IUserProvider, UserProvider>();
        service.AddScoped<IArticleParseProvider, ArticleParseProvider>();
        service.AddScoped<IJournalParseProvider, JournalParseProvider>();
        service.AddScoped<IPublishingHouseParseProvider, PublishingHouseParseProvider>();
        
        return service;
    }
}