namespace ScientificActivities.Service.ModelRequest.Publication;

public class ArticleAuthorsRequest : BaseModelRequest
{
    public Guid ArticleId { get; set; }
    
    public Guid AuthorId { get; set; }
}