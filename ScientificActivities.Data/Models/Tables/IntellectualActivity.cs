using ScientificActivities.StorageEnums;

namespace ScientificActivities.Data.Models.Tables;

/// <summary>
///     8. Результаты интеллектуальной деятельности, учтенные в государственных информационных системах, государственных  и иных структурах
/// </summary>
public class IntellectualActivity
{
    public long Id { get; set; }
    
    public int PerformersNumber { get; set; }
    
    public float SharePercentage { get; set; } // долевое участие
    
    public string ProjectName { get; set; } = string.Empty;
    
    public string Output { get; set; } = string.Empty; // выходные данные
    
    public DateTime RegistrationDate { get; set; } 
    
    public EnumImplementationAct EnumImplementationAct { get; set; }
    
    public int Points { get; set; }
}