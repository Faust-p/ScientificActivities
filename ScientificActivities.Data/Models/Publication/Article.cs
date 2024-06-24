using ScientificActivities.Data.Models.University;
using ScientificActivities.StorageEnums;

namespace ScientificActivities.Data.Models.Publication;

/// <summary>
///     5.2   Статьи, опубликованные в
/// </summary>
public class Article : BaseModel
{
    public Article(string name, string number, DateTime year, string pages, EnumRSCI rsci, EnumVAK vak, Journal journal)
    {
        Name = name;
        Number = number;
        Year = year;
        Pages = pages;
        Rsci = rsci;
        Vak = vak;
        Journal = journal;
        Authors = new List<ArticlesAuthors>();
    }

    protected Article()
    {
    }
    
    public string Name { get; set; } 

    public string? Number { get; set; }

    public DateTime? Year { get; set; }

    public string? Pages { get; set; }

    public EnumRSCI? Rsci { get; set; }

    public EnumVAK? Vak { get; set; }
    
    public Journal? Journal { get; set; }
    
    public List<ArticlesAuthors>? Authors { get; set; }
}