using ScientificActivities.Services.DTO;

namespace ScientificActivities.Services.Interfaces;

public interface IDepartmentService
{
    IEnumerable<DepartmentDTO> GetAllDepartments();

    DepartmentDTO GetDepartment(long id);

    void InsertDepartment(DepartmentDTO department);
    
    void UpdateDepartment(DepartmentDTO department);
    
    void DeleteDepartment(long id);
}