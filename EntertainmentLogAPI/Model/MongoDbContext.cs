using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntertainmentLogAPI.Model
{
    public class MongoDbContext
    {
        public class MongoDBContext
        {
            public static string ConnectionString = "mongodb://192.168.1.100/";
            public static string DatabaseName = "entlog";
            public static bool IsSSL = false;

            private IMongoDatabase _database { get; }

            public MongoDBContext()
            {
                try
                {
                    MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(ConnectionString));
                    if (IsSSL)
                    {
                        settings.SslSettings = new SslSettings { EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12 };
                    }
                    var mongoClient = new MongoClient(settings);
                    _database = mongoClient.GetDatabase(DatabaseName).WithWriteConcern(WriteConcern.Acknowledged);
                }
                catch (Exception ex)
                {
                    throw new Exception("Cannot access to db server.", ex);
                }
            }

            public IMongoCollection<Occasion> Occasions
            {
                get
                {
                    return _database.GetCollection<Occasion>("Occasion");
                }
            }
        }

    }
}
