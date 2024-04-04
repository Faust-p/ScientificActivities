using Microsoft.EntityFrameworkCore;

namespace ScientificActivities.Repository;

public class Repository <T> : IRepository<T> where T: class
{
    private readonly DataContext _db;
    private  DbSet<T> _entities;

    public Repository(DataContext context)
    {
        this._db = context;
        this._entities = context.Set<T>();
    }
    
    public async Task<IEnumerable<T>> GetAll()
    {
        return _entities.AsEnumerable();
    }

    public async Task<T> Get(long id)
    {
        return await _entities.FindAsync(id);
    }

    public async Task Create(T item)
    {
        _entities.AddAsync(item);
    }

    public async Task Update(T item)
    {
        _entities.Update(item);
    }

    public async Task Delete(long id)
    {
        T item = await _entities.FindAsync(id);
        _entities.Remove(item);
    }

    public async Task Save()
    {
        _db.SaveChangesAsync();
    }
}