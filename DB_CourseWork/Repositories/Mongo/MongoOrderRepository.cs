using DB_CourseWork.Controls;
using DB_CourseWork.Interfaces;
using DB_CourseWork.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace DB_CourseWork.DbRepositories.Mongo
{
    public class MongoOrderRepository : IOrderStrategy
    {
        private readonly IMongoCollection<Order> _orders;

        public MongoOrderRepository(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            _orders = database.GetCollection<Order>(Config.MONGO_ORDER_PATH);
        }

        public List<Order> GetAll()
        {
            return _orders.Find(order => true).ToList();
        }

        public Order Get(int id)
        {
            return _orders.Find(order => order.Id == id).FirstOrDefault();
        }

        public void Add(Order order)
        {
            if (order.Id == 0 || Get(order.Id) != null)
            {
                var entities = GetAll();
                if (entities.Count > 0)
                {
                    order.Id = entities.Max(r => r.Id) + 1;
                }
                else
                {
                    order.Id = 1;
                }
            }

            _orders.InsertOne(order);
        }

        public void Update(Order order)
        {
            _orders.ReplaceOne(existingOrder => existingOrder.Id == order.Id, order);
        }

        public void Delete(int id)
        {
            _orders.DeleteOne(order => order.Id == id);
        }
    }
}
