using MongoDB.Driver;

namespace MemeTokenHub.Shared.Configuration;

public interface IMongoConnection
{
    IMongoDatabase GetDatabase(string databaseName);
}

public class MongoConnection : IMongoConnection
{
    private readonly IMongoClient _client;

    public MongoConnection(string connectionString)
    {
        _client = new MongoClient(connectionString);
    }

    public IMongoDatabase GetDatabase(string databaseName)
    {
        return _client.GetDatabase(databaseName);
    }
}
