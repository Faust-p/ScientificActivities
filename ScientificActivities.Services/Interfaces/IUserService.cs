using ScientificActivities.Services.DTO;

namespace ScientificActivities.Services.Interfaces;

public interface IUserService
{
    IEnumerable<UserDTO> GetAllUsers();

    UserDTO GetUser(long id);

    void InsertUser(UserDTO user);
    
    void UpdateUser(UserDTO user);
    
    void DeleteUser(long id);
}