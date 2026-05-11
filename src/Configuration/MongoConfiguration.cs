using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace MemeTokenHub.Shared.Configuration;

public static class MongoConfiguration
{
    public static IServiceCollection AddMongoDb(
        this IServiceCollection services, string connectionString, string databaseName)
    {
        services.AddSingleton<IMongoConnection>(
            new MongoConnection(connectionString));
        services.AddScoped(provider =>
        {
            var connection = provider.GetRequiredService<IMongoConnection>();
            return connection.GetDatabase(databaseName);
        });

        return services;
    }
}
