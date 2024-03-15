using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Xsl;

namespace OwnProject2.Data
{
    internal class DB
    {
        private static MongoClient GetClient()
        {
            string connectionString = "mongodb+srv://emilohrstrom:Mongodb93@cluster2.3ipcg3p.mongodb.net/?retryWrites=true&w=majority&appName=Cluster2";

            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
            settings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };

            var mongoClient = new MongoClient(settings);

            return mongoClient;
        }

        public static IMongoCollection<Models.Dog> DogCollection()
        {
            var client = GetClient();

            var database = client.GetDatabase("myDogDb");

            var dogCollection = database.GetCollection<Models.Dog>("MyDogs");

            return dogCollection;
        }

    }
}
