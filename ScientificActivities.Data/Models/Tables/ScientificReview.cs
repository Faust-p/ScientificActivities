namespace ScientificActivities.Data.Models.Tables;

/// <summary>
///     10. Научное рецензирование и редактирование
/// </summary>
public class ScientificReview
{
    public long Id { get; set; }
    
    public string ProjectName { get; set; } = string.Empty;
    
    public string Output { get; set; } = string.Empty; // выходные данные
    
    public int Points { get; set; }
}