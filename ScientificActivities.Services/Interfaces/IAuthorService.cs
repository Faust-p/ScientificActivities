using ScientificActivities.Services.DTO;

namespace ScientificActivities.Services.Interfaces;

public interface IAuthorService
{
    IEnumerable<AuthorDTO> GetAllAuthors();

    AuthorDTO GetAuthor(long id);

    void InsertAuthor(AuthorDTO author);
    
    void UpdateAuthor(AuthorDTO author);
    
    void DeleteAuthor(long id);
}