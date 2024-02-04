namespace ScientificActivities.Data.Models;

public class Table
{
    public long Id { get; set; }
    
    public Author Author { get; set; }
    
    public long AuthorId { get; set; }
}