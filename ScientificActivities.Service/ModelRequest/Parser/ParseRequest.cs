using ScientificActivities.Service.ModelRequest.Publication;

namespace ScientificActivities.Service.ModelRequest.Parser;

public class ParseRequest
{
    public ArticlesRequest ArticlesRequest { get; set; }
    public JournalRequest JournalRequest { get; set; }
    public PublishingHouseRequest? PublishingHouseRequest { get; set; }
}