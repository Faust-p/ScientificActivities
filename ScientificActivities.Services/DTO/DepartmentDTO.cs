namespace ScientificActivities.Services.DTO;

public class DepartmentDTO
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    //public Faculty Faculty { get; set; } = null!;

    public long FacultyId { get; set; }
    
}