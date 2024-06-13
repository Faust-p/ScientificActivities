using ScientificActivities.Data.Models.University;
using ScientificActivities.Service.CustomException;
using ScientificActivities.Service.ModelRequest.University;
using ScientificActivities.Service.Services.Interface.Providers;
using ScientificActivities.Service.Services.Interface.Services;

namespace ScientificActivities.Service.Services;

public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentProvider _departmentProvider;
    private readonly IFacultyProvider _facultyProvider;

    public DepartmentService(IDepartmentProvider departmentProvider, IFacultyProvider facultyProvider)
    {
        _departmentProvider = departmentProvider;
        _facultyProvider = facultyProvider;
    }

    public async Task<Guid> CreateAsync(DepartmentRequest entityRequest, CancellationToken cancellationToken)
    {
        if (await _departmentProvider.FindAsync(entityRequest.Name, cancellationToken) != null)
            throw new ExistIsEntityException("Такая кафедра уже существует");

        var faculty = await _facultyProvider.FindAsync(entityRequest.FacultyId, cancellationToken);
        if (faculty == null)
            throw new MissingDivisionException("Такого факультета не существует");

        var departmentDb = new Department(entityRequest.Name, faculty);
        await _departmentProvider.AddAsync(departmentDb, cancellationToken);
        return departmentDb.Id;
    }

    public async Task<Department?> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        var department = await _departmentProvider.FindAsync(id, cancellationToken);
        if (department == null)
            throw new NotExistException("Такой кафедры не существует");
        return department;
    }

    public async Task<Department> GetAsync(string name, CancellationToken cancellationToken)
    {
        var department = await _departmentProvider.FindAsync(name, cancellationToken);
        if (department == null)
            throw new NotExistException("Такой кафедры не существует");
        return department;
    }

    public async Task<Department> UpdateAsync(DepartmentRequest entityRequest, CancellationToken cancellationToken)
    {
        var departmentDb = await GetAsync(entityRequest.Id, cancellationToken);
        if (departmentDb == null)
            throw new NotExistException("Такой кафедры не существует");

        var faculty = await _facultyProvider.FindAsync(entityRequest.FacultyId, cancellationToken);
        if (faculty == null)
            throw new MissingDivisionException("Такого факультета не существует");

        departmentDb.Name = entityRequest.Name;
        departmentDb.Faculty = faculty;
        departmentDb.UpdateChange = DateTime.Now;

        await _departmentProvider.UpdateAsync(departmentDb, cancellationToken);
        return departmentDb;
    }

    public async Task<List<Department>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _departmentProvider.GetAllAsync(cancellationToken);
    }
}