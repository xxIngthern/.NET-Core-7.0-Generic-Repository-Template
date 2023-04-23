using Core.Entity;
using Core.Repository;
using Environment.Settings;
using MongoDB.Driver;

namespace Repository;

public class BaseRepository<TEntity>:IRepository<TEntity> 
    where TEntity:class, IEntity, new()
{
    private readonly IMongoCollection<TEntity> _collection;
    public BaseRepository(DatabaseSettings connection, BaseContext context)
    {
        _collection = context.GetDatabase(connection.DatabaseName).GetCollection<TEntity>(connection.CollectionName);
    }
    public void Add(TEntity entity)
    {
        _collection.InsertOne(entity);
    }

    public void Update(string id, TEntity entity)
    {
        _collection.ReplaceOne(e => e.Id == id, entity);
    }

    public void Delete(string id)
    {
        _collection.DeleteOne(e => e.Id == id);
    }

    public async Task<TEntity> GetByIdAsync(string id)
    {
        return await _collection.Find(e => e.Id == id).FirstOrDefaultAsync();
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        return await _collection.Find(_ => true).ToListAsync();
    }
}