using ScientificActivities.Data.Models.University;

namespace ScientificActivities.Data.Models.Publication;

public class ArticlesAuthors : BaseModel
{
    public Article Article { get; set; } = null!;

    public Author Author { get; set; } = null!;
}