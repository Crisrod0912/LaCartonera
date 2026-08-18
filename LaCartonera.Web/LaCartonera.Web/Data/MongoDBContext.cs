using MongoDB.Driver;

namespace LaCartonera.Web.Data
{
    public class MongoDBContext : IMongoDBContext
    {
        private readonly string? _variable;

        public MongoDBContext(IConfiguration configuration)
        {
            _variable = configuration["urlWebApi"]
                ?? configuration["Default"]
                ?? throw new InvalidOperationException("Connection string 'urlWebApi' not found in configuration (appsettings.json).");
        }

        public IMongoClient CreateConnection()
            => new MongoClient(_variable);
    }
}
