using DB_CourseWork.Controls;
using DB_CourseWork.Interfaces;
using DB_CourseWork.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace DB_CourseWork.DbRepositories.Mongo
{
    public class MongoClientRepository : IClientStrategy
    {
        private readonly IMongoCollection<Client> _clients;

        public MongoClientRepository(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            _clients = database.GetCollection<Client>(Config.MONGO_CLIENT_PATH);
        }

        public List<Client> GetAll()
        {
            return _clients.Find(client => true).ToList();
        }

        public Client Get(int id)
        {
            return _clients.Find(client => client.Id == id).FirstOrDefault();
        }

        public void Add(Client client)
        {
            if (client.Id == 0 || Get(client.Id) != null)
            {
                var entities = GetAll();
                if (entities.Count > 0)
                {
                    client.Id = entities.Max(r => r.Id) + 1;
                }
                else
                {
                    client.Id = 1;
                }
            }

            _clients.InsertOne(client);
        }

        public void Update(Client client)
        {
            _clients.ReplaceOne(existingClient => existingClient.Id == client.Id, client);
        }

        public void Delete(int id)
        {
            _clients.DeleteOne(client => client.Id == id);
        }
    }
}
