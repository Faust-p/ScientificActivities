namespace ScientificActivities.Service.ModelRequest.University;

public class FacultyRequest : BaseModelRequest
{
    public string Name { get; set; }
    
    public List<DepartmentRequest>? Departments { get; set; }
}