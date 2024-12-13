using MongoDB.Driver;
using Microsoft.Extensions.Options;
using HireAProBackend.Models;

namespace HireAProBackend.Services
{
    public class MongoDBService
    {
        public readonly IMongoDatabase _database;

        // Modificar para usar IOptions para acceder a las configuraciones
        public MongoDBService(IConfiguration configuration)
        {
            var connectionString = configuration.GetValue<string>("MongoDBSettings:ConnectionString");
            var databaseName = configuration.GetValue<string>("MongoDBSettings:DatabaseName");

            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return _database.GetCollection<T>(collectionName);
        }
    }
}
