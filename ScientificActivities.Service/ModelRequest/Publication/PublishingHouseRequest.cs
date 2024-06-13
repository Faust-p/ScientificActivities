namespace ScientificActivities.Service.ModelRequest.Publication;

public class PublishingHouseRequest : BaseModelRequest
{
    public string Name { get; set; }
    
    public string Country { get; set; }
    
    public string City { get; set; }
}