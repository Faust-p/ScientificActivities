namespace ScientificActivities.Data.Models.Tables;

/// <summary>
///     13. Научное руководство студенческими научными работами
/// </summary>
public class ScientificSupervision
{
    public long Id { get; set; }
    
    public string WorkType { get; set; }
    
    public string ProjectName { get; set; } = string.Empty;
    
    public string Output { get; set; } = string.Empty; // выходные данные
    
    public int Points { get; set; }
}