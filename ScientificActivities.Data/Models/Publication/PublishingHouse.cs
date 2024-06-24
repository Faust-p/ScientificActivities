namespace ScientificActivities.Data.Models.Publication;

public class PublishingHouse : BaseModel
{
    public PublishingHouse(string name, string country, string city)
    {
        Name = name;
        Country = country;
        City = city;
        Journals = new List<Journal>();
    }

    protected PublishingHouse()
    {
    }
    
    public string Name { get; set; } = string.Empty;
    
    public string? Country { get; set; }
    
    public string? City { get; set; }
    
    public List<Journal> Journals { get; set; } 
}