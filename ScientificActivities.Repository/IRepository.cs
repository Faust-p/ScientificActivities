namespace ScientificActivities.Repository;

public interface IRepository <T> where T : class
{
    Task<IEnumerable<T>> GetAll();

    Task<T> Get(long id);

    Task Create(T item);
    
    Task Update(T item);
    
    Task Delete(long id);
    
    Task Save();
}