using ScientificActivities.Data.Models.University;

namespace ScientificActivities.Data.Models.Publication;

public class ArticlesAuthors : BaseModel
{
    public ArticlesAuthors(Article article, Author author)
    {
        Article = article;
        Author = author;
    }

    protected ArticlesAuthors()
    {
    }

    public Article Article { get; set; } = null!;

    public Author Author { get; set; } = null!;
}