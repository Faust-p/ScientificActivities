namespace ScientificActivities.Data;

public interface IBaseModel
{
    Guid Id { get; }
    
    public DateTime DateCreate { get; }
    
    public DateTime UpdateChange { get; }
}