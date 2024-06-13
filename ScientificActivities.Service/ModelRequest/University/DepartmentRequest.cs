namespace ScientificActivities.Service.ModelRequest.University;

public class DepartmentRequest : BaseModelRequest
{
    public string Name { get; set; }
    
    public Guid FacultyId { get; set; }
    
    public List<AuthorRequest> Authors { get; set; }
}