using ScientificActivities.StorageEnums;

namespace ScientificActivities.Data.Models.Tables;

/// <summary>
///     9. Членство в оргкомитетах научных мероприятий (конференций, семинаров, круглых столов, выставок и др.)
/// </summary>
public class OrganizingMembership
{
    public long Id { get; set; }
    
    public string ProjectName { get; set; } = string.Empty;
    
    public DateTime EventDate { get; set; } 
    
    public string EventPlace { get; set; }
    
    public EnumEventLevel EnumEventLevel { get; set; }
    
    public int Points { get; set; }
}