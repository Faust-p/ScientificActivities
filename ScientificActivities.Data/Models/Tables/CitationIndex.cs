using ScientificActivities.StorageEnums;

namespace ScientificActivities.Data.Models.Tables;

/// <summary>
///     4. Индекс цитируемости
/// </summary>
public class CitationIndex
{
    public long Id { get; set; }
    
    public EnumEmployeePosition EmployeerPosition { get; set; } //??
    
    public EnumIndex EnumIndex { get; set; }
    
    public int Points { get; set; }
}