namespace ScientificActivities.Data.Models.Tables;

/// <summary>
///     7. Научно-просветительская деятельность
/// </summary>
public class ScientificEducationalActivities
{
    public long Id { get; set; }
    
    public List<СoАuthor>? СoАuthor { get; set; } //??
    
    public float SharePercentage { get; set; } // долевое участие
    
    public string ProjectName { get; set; } = string.Empty;
    
    public string Output { get; set; } = string.Empty; // выходные данные
    
    public int Workload { get; set; } // Объём работы
    
    public string ISBN { get; set; } = string.Empty; //??
    
    public int Points { get; set; }
}