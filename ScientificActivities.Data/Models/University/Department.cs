namespace ScientificActivities.Data.Models.University;

/// <summary>
///     Кафедра
/// </summary>
public class Department : BaseModel
{
    public Department(string name, Faculty faculty)
    {
        Name = name;
        Faculty = faculty;
        Authors = new List<Author>();
    }
    
    public string Name { get; set; } = null!;

    public Faculty Faculty { get; set; } = null!;
    
    public List<Author> Authors { get; set; } = null!;
}