using DB_CourseWork.Controls;
using DB_CourseWork.Interfaces;
using DB_CourseWork.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace DB_CourseWork.DbRepositories.Mongo
{
    public class MongoAdminRepository : IAdminStrategy
    {
        private readonly IMongoCollection<Admin> _admins;

        public MongoAdminRepository(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            _admins = database.GetCollection<Admin>(Config.MONGO_ADMIN_PATH);
        }

        public List<Admin> GetAll()
        {
            return _admins.Find(admin => true).ToList();
        }

        public Admin Get(int id)
        {
            return _admins.Find(admin => admin.Id == id).FirstOrDefault();
        }

        public void Add(Admin admin)
        {
            if (admin.Id == 0 || Get(admin.Id) != null)
            {
                var entities = GetAll();
                if (entities.Count > 0)
                {
                    admin.Id = entities.Max(r => r.Id) + 1;
                }
                else
                {
                    admin.Id = 1;
                }
            }

            _admins.InsertOne(admin);
        }

        public void Update(Admin admin)
        {
            _admins.ReplaceOne(existingAdmin => existingAdmin.Id == admin.Id, admin);
        }

        public void Delete(int id)
        {
            _admins.DeleteOne(admin => admin.Id == id);
        }
    }
}
