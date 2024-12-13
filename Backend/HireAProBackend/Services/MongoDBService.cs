using MongoDB.Driver;
using Microsoft.Extensions.Options;
using HireAProBackend.Models;
using DotNetEnv;

namespace HireAProBackend.Services
{
    public class MongoDBService
    {
        public readonly IMongoDatabase _database;

        // Modificar para usar IOptions para acceder a las configuraciones
        public MongoDBService(IConfiguration configuration)
        {
            Env.Load();
            var envMongoUser = Environment.GetEnvironmentVariable("mongo_admin");
            var envMongoPasswd = Environment.GetEnvironmentVariable("mongo_passwd");

            var escapedMongoUser = Uri.EscapeDataString(envMongoUser);
            var escapedMongoPasswd = Uri.EscapeDataString(envMongoPasswd);

            var connectionString = $"mongodb://{escapedMongoUser}:{escapedMongoPasswd}@148.113.191.24:27017";

            var databaseName = configuration.GetValue<string>("MongoDBSettings:DatabaseName");

            var client = new MongoClient(connectionString);
            _database = client.GetDatabase("hire-a-pro");
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return _database.GetCollection<T>(collectionName);
        }
    }
}
