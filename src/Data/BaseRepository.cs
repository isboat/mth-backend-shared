using MongoDB.Bson;
using MongoDB.Driver;

namespace MemeTokenHub.Shared.Data;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected readonly IMongoCollection<T> _collection;

    public BaseRepository(IMongoDatabase database, string collectionName)
    {
        _collection = database.GetCollection<T>(collectionName);
    }

    public async Task<T?> GetByIdAsync(string id)
    {
        var objectId = ObjectId.Parse(id);
        return await _collection.Find(Builders<T>.Filter.Eq("_id", objectId))
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _collection.Find(_ => true).ToListAsync();
    }

    public async Task<T> CreateAsync(T entity)
    {
        await _collection.InsertOneAsync(entity);
        return entity;
    }

    public async Task<T> UpdateAsync(string id, T entity)
    {
        var objectId = ObjectId.Parse(id);
        await _collection.ReplaceOneAsync(
            Builders<T>.Filter.Eq("_id", objectId), entity);
        return entity;
    }

    public async Task DeleteAsync(string id)
    {
        var objectId = ObjectId.Parse(id);
        await _collection.DeleteOneAsync(Builders<T>.Filter.Eq("_id", objectId));
    }
}
