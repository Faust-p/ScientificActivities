using ScientificActivities.StorageEnums;

namespace ScientificActivities.Data.Models.Tables;

/// <summary>
///     11. Членство в редколлегиях
/// </summary>
public class EditorialMembership
{
    public long Id { get; set; }
    
    public EnumEditorialBoards EnumEditorialBoards { get; set; }
    
    public int Points { get; set; }
}