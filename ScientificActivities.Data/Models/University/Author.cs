using ScientificActivities.Data.Models.Publication;
using ScientificActivities.StorageEnums;

namespace ScientificActivities.Data.Models.University;

public class Author : BaseModel
{
    public Author(string firstName, string lastName, string sureName, string contacts, string email, 
        Department department, EnumEmployeePosition position, EnumAcademicDegree degree)
    {
        FirstName = firstName;
        LastName = lastName;
        SureName = sureName;
        Contacts = contacts;
        Email = email;
        Department = department;
        EmployeerPosition = position;
        AcademicDegree = degree;
        Articles = new List<ArticlesAuthors>();
    }

    protected Author()
    {
    }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string? SureName { get; set; } = string.Empty;

    public string Contacts { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public Department Department { get; set; }
    
    public EnumEmployeePosition? EmployeerPosition { get; set; }

    public EnumAcademicDegree? AcademicDegree { get; set; }
    
    public List<ArticlesAuthors>? Articles { get; set; }
}