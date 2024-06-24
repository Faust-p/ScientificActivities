using ScientificActivities.Data.Enums;

namespace ScientificActivities.Data.Models.Publication;

public class Journal : BaseModel
{
    public Journal(string name, PublishingHouse publishingHouse, EnumRSCI rsci, EnumVAK vak, EnumCoreRSCI coreRsci)
    {
        Name = name;
        PublishingHouse = publishingHouse;
        Rsci = rsci;
        Vak = vak;
        CoreRsci = coreRsci;
        Articles = new List<Article>();
    }

    protected Journal()
    {
    }


    public string Name { get; set; } = string.Empty;

    public PublishingHouse? PublishingHouse { get; set; }
    
    public EnumRSCI? Rsci { get; set; }
    
    public EnumVAK? Vak { get; set; }
    
    public EnumCoreRSCI? CoreRsci { get; set; }
    
    public List<Article> Articles { get; set; } = new List<Article>();
}