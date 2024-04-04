using ScientificActivities.Services.DTO;

namespace ScientificActivities.Services.Interfaces;

public interface IСoАuthorService
{
    IEnumerable<СoАuthorDTO> GetAllСoАuthors();

    СoАuthorDTO GetСoАuthor(long id);

    void InsertСoАuthor(СoАuthorDTO coАuthor);
    
    void UpdateСoАuthor(СoАuthorDTO coАuthor);
    
    void DeleteСoАuthor(long id);
}