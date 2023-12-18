using Microsoft.EntityFrameworkCore;
using MMC.Domain.IRepositories;
using MMC.Infrastructure.Data;

namespace MMC.Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly DBC _db;
    private DbSet<T> dbSet;
   

    public Repository(DBC db)
    {
        _db = db;
        dbSet = _db.Set<T>();
    }

    

    public async Task DeleteAsync(int id)
    {
        var model = await dbSet.FindAsync(id);
        if (model == null)
            return;
        dbSet.Remove(model);
        await _db.SaveChangesAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
        => await dbSet.ToListAsync();

    public async Task<T> GetAsync(int id) => await dbSet.FindAsync(id);

    public async Task<T> PostAsync(T entity)
    {
        await dbSet.AddAsync(entity);
        await _db.SaveChangesAsync();
        return entity;
    }

    public async Task<T> PutAsync(int id, T entity)
    {
        var data = await dbSet.FindAsync(id);
        if (data is null)
            return null;

        dbSet.Entry(data).CurrentValues.SetValues(entity);
        await _db.SaveChangesAsync();
        return data;
    }
}
