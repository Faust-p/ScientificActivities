using ScientificActivities.Data.Models.University;
using ScientificActivities.Service.CustomException;
using ScientificActivities.Service.ModelRequest.University;
using ScientificActivities.Service.Services.Interface.Providers;
using ScientificActivities.Service.Services.Interface.Services;

namespace ScientificActivities.Service.Services;

public class FacultyService : IFacultyService
{
    private readonly IFacultyProvider _facultyProvider;

    public FacultyService(IFacultyProvider facultyProvider)
    {
        _facultyProvider = facultyProvider;
    }
    
    public async Task<Guid> CreateAsync(FacultyRequest entityRequest, CancellationToken cancellationToken)
        {
            if (await _facultyProvider.FindAsync(entityRequest.Name, cancellationToken) != null)
                throw new ExistIsEntityException("Такой факультет уже существует");

            var facultyDb = new Faculty(entityRequest.Name);
            await _facultyProvider.AddAsync(facultyDb, cancellationToken);
            return facultyDb.Id;
        }

        public async Task<Faculty?> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            var faculty = await _facultyProvider.FindAsync(id, cancellationToken);
            if (faculty == null)
                throw new NotExistException("Такого факультета не существует");
            return faculty;
        }

        public async Task<Faculty> GetAsync(string name, CancellationToken cancellationToken)
        {
            var faculty = await _facultyProvider.FindAsync(name, cancellationToken);
            if (faculty == null)
                throw new NotExistException("Такого факультета не существует");
            return faculty;
        }

        public async Task<Faculty> UpdateAsync(FacultyRequest entityRequest, CancellationToken cancellationToken)
        {
            var facultyDb = await GetAsync(entityRequest.Id, cancellationToken);
            if (facultyDb == null)
                throw new NotExistException("Такого факультета не существует");

            facultyDb.Name = entityRequest.Name;
            facultyDb.UpdateChange = DateTime.Now;

            await _facultyProvider.UpdateAsync(facultyDb, cancellationToken);
            return facultyDb;
        }

        public async Task<List<Faculty>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _facultyProvider.GetAllAsync(cancellationToken);
        }
}