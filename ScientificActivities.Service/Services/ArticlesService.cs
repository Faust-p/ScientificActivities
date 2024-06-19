using ScientificActivities.Data.Models.Publication;
using ScientificActivities.Service.Converters;
using ScientificActivities.Service.CustomException;
using ScientificActivities.Service.ModelRequest.Publication;
using ScientificActivities.Service.Services.Interface.Providers;
using ScientificActivities.Service.Services.Interface.Services;
using ScientificActivities.StorageEnums;

namespace ScientificActivities.Service.Services;

public class ArticlesService : IArticlesService
{
    private readonly IArticlesProvider _articlesProvider;
    private readonly IJournalProvider _journalProvider;

    public ArticlesService(IArticlesProvider articlesProvider, IJournalProvider journalProvider)
    {
        _articlesProvider = articlesProvider;
        _journalProvider = journalProvider;
    }


    public async Task<Guid> CreateAsync(ArticlesRequest entityRequest, CancellationToken cancellationToken)
    {
        if (await _articlesProvider.FindAsync(entityRequest.Name, cancellationToken) != null)
            throw new ExistIsEntityException("Такая статья уже существует");
        var journal = await _journalProvider.FindAsync(entityRequest.JournalId, cancellationToken);
        if (journal == null)
            throw new MissingDivisionException("Такого журнала не существует");
        var articlesDb = new Article(entityRequest.Name,
            entityRequest.Number,
            entityRequest.Year,
            entityRequest.Pages,
            (EnumRSCI) Enum.Parse(typeof(EnumRSCI), entityRequest.Rsci, true),
            (EnumVAK) Enum.Parse(typeof(EnumVAK), entityRequest.Vak, true),
            journal);
        await _articlesProvider.AddAsync(articlesDb, cancellationToken);
        return articlesDb.Id;
    }

    public async Task<Article?> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        var articles = await _articlesProvider.FindAsync(id, cancellationToken);
        if (articles == null)
            throw new NotExistException("Такой статьи не существует");
        return articles;
    }

    public async Task<Article> GetAsync(string name, CancellationToken cancellationToken)
    {
        var articles = await _articlesProvider.FindAsync(name, cancellationToken);
        if (articles == null)
            throw new NotExistException("Такой статьи не существует");
        return articles;
    }
    
    public async Task<Article> UpdateAsync(ArticlesRequest entityRequest, CancellationToken cancellationToken)
    {
        var articlesDb = await GetAsync(entityRequest.Id, cancellationToken);
        var journal = await _journalProvider.FindAsync(entityRequest.JournalId, cancellationToken);
        if (journal == null)
            throw new MissingDirectionException("Такого журнала не существует");
        
        var newArticlesDb = ArticlesConverter.ConverterArticlesRequest(entityRequest, journal);
        articlesDb.Name = newArticlesDb.Name;
        articlesDb.Number = newArticlesDb.Number;
        articlesDb.Year = newArticlesDb.Year;
        articlesDb.Pages = newArticlesDb.Pages;
        articlesDb.Rsci = newArticlesDb.Rsci;
        articlesDb.Vak = newArticlesDb.Vak;
        articlesDb.UpdateChange = DateTime.Now;
        await _articlesProvider.UpdateAsync(articlesDb, cancellationToken);
        return articlesDb;
    }

    public async Task<List<Article>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _articlesProvider.GetAllAsync(new CancellationToken());
    }
    
    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        await _articlesProvider.DeleteAsync(id, cancellationToken);
    }
}