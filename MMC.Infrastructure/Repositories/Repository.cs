using Microsoft.EntityFrameworkCore;
using MMC.Application.IRepositories;
using MMC.Infrastructure.Data;

namespace MMC.Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly DBC _db;
    private DbSet<T> _table;
   

    public Repository(DBC db)
    {
        _db = db;
        _table = _db.Set<T>();
    }

    

    public async Task DeleteAsync(int id)
    {
        var model = await _table.FindAsync(id);
        if (model == null)
            return;
        _table.Remove(model);
        await _db.SaveChangesAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
        => await _table.ToListAsync();

    public async Task<T> GetAsync(int id) => await _table.FindAsync(id);

    public async Task<T> PostAsync(T entity)
    {
        await _table.AddAsync(entity);
        await _db.SaveChangesAsync();
        return entity;
    }

    public async Task<T> PutAsync(int id, T entity)
    {
        var data = await _table.FindAsync(id); ;
        if (data is null)
            return null;

        _table.Entry(data).CurrentValues.SetValues(entity);
        await _db.SaveChangesAsync();
        return data;
    }
}
