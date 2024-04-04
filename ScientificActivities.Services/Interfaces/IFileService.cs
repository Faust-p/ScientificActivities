using ScientificActivities.Services.DTO;

namespace ScientificActivities.Services.Interfaces;

public interface IFileService
{
    IEnumerable<FileDTO> GetAllFiles();

    FileDTO GetFile(long id);

    void InsertFile(FileDTO file);
    
    void UpdateFile(FileDTO file);
    
    void DeleteFile(long id);
}