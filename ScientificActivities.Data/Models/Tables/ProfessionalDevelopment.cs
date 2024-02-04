namespace ScientificActivities.Data.Models.Tables;

/// <summary>
///     1. Повышение профессионального уровня
/// </summary>
public class ProfessionalDevelopment
{
    public long Id { get; set; }
    
    public string ProjectName { get; set; } = string.Empty;
    
    public string NameHAC { get; set; } = string.Empty;
    
    public int Points { get; set; }
}