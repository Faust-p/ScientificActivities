using ScientificActivities.Service.ModelRequest.Publication;

namespace ScientificActivities.Service.ModelRequest.University;

public class AuthorRequest : BaseModelRequest
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string SureName { get; set; }

    public string Contacts { get; set; }

    public string Email { get; set; }
    
    public Guid DepartmentId { get; set; }
    
    public string Position { get; set; }
    
    public string Degree { get; set; }
    
    public List<ArticleAuthorsRequest> ArticlesList { get; set; }
}