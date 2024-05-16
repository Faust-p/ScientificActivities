namespace ScientificActivities.Service.ModelRequest.Publication;

public class JournalRequest : BaseModelRequest
{
    public string Name { get; set; }
    
    public Guid PublishingHouseId { get; set; }
    
    public string Status { get; set; }
}