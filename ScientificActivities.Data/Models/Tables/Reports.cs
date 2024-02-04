using ScientificActivities.StorageEnums;

namespace ScientificActivities.Data.Models.Tables;

/// <summary>
///     6. Доклады
/// </summary>
public class Reports
{
    public long Id { get; set; }
    
    public string ProjectName { get; set; } = string.Empty;
    
    public string Output { get; set; } = string.Empty; // выходные данные
    
    public EnumReportType Status { get; set; }
    
    public int Points { get; set; }
}