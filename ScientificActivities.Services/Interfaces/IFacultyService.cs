using ScientificActivities.Services.DTO;

namespace ScientificActivities.Services.Interfaces;

public interface IFacultyService
{
    IEnumerable<FacultyDTO> GetAllFacultys();

    FacultyDTO GetFaculty(long id);

    void InsertFaculty(FacultyDTO faculty);
    
    void UpdateFaculty(FacultyDTO faculty);
    
    void DeleteFaculty(long id);
}