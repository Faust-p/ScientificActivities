namespace ScientificActivities.Data.Models.Tables;

/// <summary>
///     3. Научно-исследовательские проекты
/// </summary>
public class ResearchProjects
{
    public long Id { get; set; }
    
    public string ProjectName { get; set; } = string.Empty;
    
    public string Agreement { get; set; } = string.Empty;
    
    public int Points { get; set; }
}