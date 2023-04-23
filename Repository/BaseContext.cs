using MongoDB.Driver;

namespace Repository;

public class BaseContext : MongoClient
{
    public BaseContext(string connectionString) : base(connectionString)
    {
        
    }
}