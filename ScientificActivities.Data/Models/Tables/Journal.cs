using ScientificActivities.StorageEnums;

namespace ScientificActivities.Data.Models.Tables;

public class Journal
{
    public long Id { get; set; }
    
    public string Name { get; set; } = string.Empty;
    
    public PublishingHouse PublishingHouse { get; set; }
    
    public long PublishingHouseId { get; set; }
    
    public EnumJournalStatus? EnumJournalStatus { get; set; }
    
    public List<Articles> Articles { get; set; } = null!;
}