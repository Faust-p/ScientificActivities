namespace ScientificActivities.Data.Models.Tables;

public class PublishingHouse
{
    public long Id { get; set; }
    
    public string Name { get; set; } = string.Empty;
    
    public string Country { get; set; }
    
    public string City { get; set; }
    
    public List<Journal> Journals { get; set; } = null!;
}