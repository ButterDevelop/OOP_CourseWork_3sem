using DB_CourseWork.Controls;
using DB_CourseWork.Interfaces;
using DB_CourseWork.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace DB_CourseWork.DbRepositories.Mongo
{
    public class MongoPaymentRepository : IPaymentStrategy
    {
        private readonly IMongoCollection<Payment> _payments;

        public MongoPaymentRepository(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            _payments = database.GetCollection<Payment>(Config.MONGO_PAYMENT_PATH);
        }

        public List<Payment> GetAll()
        {
            return _payments.Find(payment => true).ToList();
        }

        public Payment Get(int id)
        {
            return _payments.Find(payment => payment.Id == id).FirstOrDefault();
        }

        public void Add(Payment payment)
        {
            if (payment.Id == 0 || Get(payment.Id) != null)
            {
                var entities = GetAll();
                if (entities.Count > 0)
                {
                    payment.Id = entities.Max(r => r.Id) + 1;
                }
                else
                {
                    payment.Id = 1;
                }
            }

            _payments.InsertOne(payment);
        }

        public void Update(Payment payment)
        {
            _payments.ReplaceOne(existingPayment => existingPayment.Id == payment.Id, payment);
        }

        public void Delete(int id)
        {
            _payments.DeleteOne(payment => payment.Id == id);
        }
    }
}
