using ScientificActivities.StorageEnums;

namespace ScientificActivities.Data.Models.Tables;

/// <summary>
///     7.3 Репортажи, аналитические комментарии во всех средствах массовой информации
/// </summary>
public class Reportage
{
    public long Id { get; set; }
    
    public string ProjectName { get; set; } = string.Empty;
    
    public ActivityKind ActivityKind { get; set; }
    
    public string Output { get; set; } = string.Empty; // выходные данные
    
    public int Points { get; set; }
}