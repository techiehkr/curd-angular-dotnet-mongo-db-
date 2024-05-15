using Microsoft.Extensions.Options;
using MongoDB.Driver;
using backend.Models;
using backend.Configuration;

namespace backend.Data;

public class MongoDbContext 
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(IOptions<MongoDBConfiguration> settings)
    {
        var client = new MongoClient(settings.Value.ConnectionString);
        _database = client.GetDatabase(settings.Value.DatabaseName);
    }

    public IMongoCollection<PaymentCard> paymentcard => _database.GetCollection<PaymentCard>("PaymentCard");
}