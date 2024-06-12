namespace ScientificActivities.Data.Models.University;

public class Faculty : BaseModel
{
    public Faculty(string name)
    {
        Name = name;
        Departments = new List<Department>();
    }

    protected Faculty()
    {
    }

    public string Name { get; set; } = string.Empty;

    public List<Department> Departments { get; set; } = null!;
}