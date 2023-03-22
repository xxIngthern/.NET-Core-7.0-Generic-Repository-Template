using Core.Entity;
using Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class BaseRepository<TEntity> :IRepository<TEntity> 
    where TEntity:class, IEntity,new()
{
    private readonly BaseContext _context;
    private readonly DbSet<TEntity> _dbSet;

    protected BaseRepository(BaseContext context, DbSet<TEntity> dbSet)
    {
        _context = context;
        _dbSet = dbSet;
    }
    public void Add(TEntity entity)
    {
        _dbSet.Add(entity);
        _context.SaveChanges();
    }

    public void Update(TEntity entity)
    {
        _dbSet.Update(entity);
    }

    public void Delete(TEntity entity)
    {
        _dbSet.Remove(entity);
    }

    public async Task<TEntity> GetByIdAsync(int id)
    {
        var entity = await _dbSet.Where(e => e.Id == id).SingleOrDefaultAsync();
        return entity!;
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        var entities = await _dbSet.AsNoTracking().ToListAsync();
        return entities;
    }
}