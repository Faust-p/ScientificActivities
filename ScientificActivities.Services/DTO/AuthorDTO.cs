using ScientificActivities.StorageEnums;

namespace ScientificActivities.Services.DTO;

public class AuthorDTO
{
    public long Id { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string SureName { get; set; } = string.Empty;

    public string Contacts { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    //public Department Department { get; set; }

    public long DepartmentId { get; set; }

    public EnumEmployeePosition? EmployeerPosition { get; set; }

    public EnumAcademicDegree? AcademicDegree { get; set; }
    
    //public Articles Articles { get; set; }
    
    public long ArticlesId { get; set; }
    
}