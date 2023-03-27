using Core.Entity;
using Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class BaseRepository<TEntity> :IRepository<TEntity> 
    where TEntity:class, IEntity,new()
{
    private readonly BaseContext _context;
  
    protected BaseRepository(BaseContext context)
    {
        _context = context;
       
    }
    public void Add(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
        _context.SaveChanges();
    }

    public void Update(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
    }

    public void Delete(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
    }

    public async Task<TEntity> GetByIdAsync(int id)
    {
        var entity = await _context.Set<TEntity>().Where(e => e.Id == id).SingleOrDefaultAsync();
        return (entity ?? null) ?? throw new InvalidOperationException();
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        var entities = await _context.Set<TEntity>().AsNoTracking().ToListAsync();
        return entities;
    }
}