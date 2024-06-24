
namespace ScientificActivities.Service.ModelRequest.Publication;

public class ArticlesRequest : BaseModelRequest
{
    public string Name { get; set; } 

    public string? Number { get; set; }

    public DateTime Year { get; set; }

    public string? Pages { get; set; }
    
    public string Rsci { get; set; }
    
    public string Vak { get; set; }
    
    public Guid JournalId { get; set; }
    
    public string JounalName { get; set; }
    
    //public List<ArticleAuthorsRequest> AuthorsList { get; set; }
}