namespace ScientificActivities.Data.Models.Tables;

/// <summary>
///     5.1 Монографии 
/// </summary>
public class Monographs
{
    public long Id { get; set; }
    
    public List<СoАuthor>? СoАuthor { get; set; } //??
    
    public float SharePercentage { get; set; }
    
    public string ProjectName { get; set; } = string.Empty;
    
    public string Output { get; set; } = string.Empty;
    
    public int Workload { get; set; }
    
    public int Points { get; set; }
}