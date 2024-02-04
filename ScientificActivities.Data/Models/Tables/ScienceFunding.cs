namespace ScientificActivities.Data.Models.Tables;

/// <summary>
///     2. Финансирование науки
/// </summary>
public class ScienceFunding
{
    public long Id { get; set; }
    
    public string ProjectName { get; set; } = string.Empty;
    
    public int Points { get; set; }
}