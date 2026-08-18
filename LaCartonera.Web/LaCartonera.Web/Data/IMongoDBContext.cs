using MongoDB.Driver;

namespace LaCartonera.Web.Data
{
    public interface IMongoDBContext
    {
        IMongoClient CreateConnection();
    }
}
