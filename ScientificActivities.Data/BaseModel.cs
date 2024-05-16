namespace ScientificActivities.Data;

public class BaseModel : IBaseModel
{
    protected BaseModel()
    {
        Id = Guid.NewGuid();
        DateCreate = DateTime.Now;
        UpdateChange = DateTime.Now;
    }

    public Guid Id { get; private init; }
    public DateTime DateCreate { get; private init; }
    public DateTime UpdateChange { get; set;}
}