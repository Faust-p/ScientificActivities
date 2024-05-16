using ScientificActivities.Data.Models;
using ScientificActivities.Data.Models.Publication;
using ScientificActivities.Data.Models.University;
using ScientificActivities.Service.CustomException;
using ScientificActivities.Service.ModelRequest.University;
using ScientificActivities.Service.Services.Interface.Providers;
using ScientificActivities.Service.Services.Interface.Services;
using ScientificActivities.StorageEnums;

namespace ScientificActivities.Service.Services;

public class AuthorService : IAuthorService
{
    private readonly IAuthorProvider _authorProvider;
    private readonly IDepartmentProvider _departmentProvider;
    private readonly IArticlesProvider _articlesProvider;
    
    public AuthorService(IAuthorProvider authorProvider, IDepartmentProvider departmentProvider, IArticlesProvider articlesProvider)
    {
        _authorProvider = authorProvider;
        _departmentProvider = departmentProvider;
        _articlesProvider = articlesProvider;
    }


    public async Task<Guid> CreateAsync(AuthorRequest entityRequest, CancellationToken cancellationToken)
    {
        if (await _authorProvider.FindAsync(entityRequest.FirstName, entityRequest.SureName, cancellationToken) != null)
            throw new ExistIsEntityException("Такой автор существует");
        var department = await _departmentProvider.FindAsync(entityRequest.DepartmentId, cancellationToken);
        if (department == null)
            throw new MissingDivisionException("Не указана кафедра");
        var articles = await _articlesProvider.FindAsync(entityRequest.ArticlesId, cancellationToken);
        if (articles == null)
            throw new MissingDivisionException("Не указана статься");
        var authorDb = new Author(entityRequest.FirstName,
            entityRequest.LastName,
            entityRequest.SureName,
            entityRequest.Contacts,
            entityRequest.Email,
            department,
            (EnumEmployeePosition)Enum.Parse(typeof(EnumEmployeePosition), entityRequest.Position, true),
            (EnumAcademicDegree)Enum.Parse(typeof(EnumAcademicDegree), entityRequest.Degree, true),
            articles);
        await _authorProvider.AddAsync(authorDb, cancellationToken);
        return authorDb.Id;
    }

    public async Task<Author?> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        var author = await _authorProvider.FindAsync(id, cancellationToken);
        if (author == null)
            throw new NotExistException("Такого автора не существует");
        return author;
    }
    
    public async Task<Author> GetAsync(string firstName, string lastName, CancellationToken cancellationToken)
    {
        var author = await _authorProvider.FindAsync(firstName, lastName, cancellationToken);
        if (author == null)
            throw new NotExistException("Такого автора не существует");
        return author;
    }
    
    public async Task<Author> UpdateAsync(AuthorRequest entityRequest, CancellationToken cancellationToken)
    {
        var authorDb = await GetAsync(entityRequest.Id, cancellationToken);
        authorDb.FirstName = entityRequest.FirstName;
        authorDb.LastName = entityRequest.LastName;
        authorDb.SureName = entityRequest.SureName;
        authorDb.Contacts = entityRequest.Contacts;
        authorDb.Email = entityRequest.Email;
        
    }

    public async Task<List<Author>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _authorProvider.GetAllAsync(new CancellationToken());
    }
}