using FuneralHome.Models;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace FuneralHome.Utils
{
    public static class Configuration
    {
        public static IMongoQueryable<Order> GetCollection()
        {
            var mongoClientSettings = new MongoClientSettings
            {
                Servers = new[]
                {
                    new MongoServerAddress("myFirstCluster", 27017),
                    new MongoServerAddress("mySecondCluster", 27017),
                    new MongoServerAddress("myThirdCluster", 27017)
                },
                ConnectionMode = ConnectionMode.ReplicaSet,
                ReplicaSetName = "reply"
            };

            var mongoClient = new MongoClient(mongoClientSettings);
            var mongoDatabase = mongoClient.GetDatabase("funeralHome");
            
            return mongoDatabase.GetCollection<Order>("orders")
                .AsQueryable(new AggregateOptions
                    {
                        AllowDiskUse = true
                    }
                );
        }
    }
}