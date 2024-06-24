namespace ScientificActivities.Service.ModelRequest.Publication;

public class JournalRequest : BaseModelRequest
{
    public string Name { get; set; }
    
    public Guid PublishingHouseId { get; set; }
    
    public string Status { get; set; }
    
    public string Rsci { get; set; }
    
    public string Vak { get; set; }
    
    public string CoreRsci { get; set; }
    
    public string? PublishingHouseName { get; set; }
}