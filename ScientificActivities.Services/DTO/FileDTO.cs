namespace ScientificActivities.Services.DTO;

public class FileDTO
{
    public long Id { get; set; }

    //public Author Author { get; set; }
    
    public long AuthorId { get; set; }

    public string Url { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;
}