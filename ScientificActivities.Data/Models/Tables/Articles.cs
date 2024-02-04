namespace ScientificActivities.Data.Models.Tables;

/// <summary>
///     5.2   Статьи, опубликованные в
/// </summary>
public class Articles
{
    public long Id { get; set; }
    
    public List<СoАuthor>? СoАuthor { get; set; } //??
    
    public float SharePercentage { get; set; } // долевое участие
    
    public string ProjectName { get; set; } = string.Empty;
    
    public string Output { get; set; } = string.Empty; // выходные данные
    
    public int Workload { get; set; } // Объём работы
    
    public string Circulation { get; set; } = string.Empty; //Тираж
    
    public int Points { get; set; }
}