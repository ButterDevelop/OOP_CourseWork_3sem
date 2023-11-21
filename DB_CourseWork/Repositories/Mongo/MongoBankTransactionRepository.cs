using DB_CourseWork.Controls;
using DB_CourseWork.Interfaces;
using DB_CourseWork.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace DB_CourseWork.DbRepositories.Mongo
{
    public class MongoBankTransactionRepository : IBankTransactionStrategy
    {
        private readonly IMongoCollection<BankTransaction> _bankTransactions;

        public MongoBankTransactionRepository(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            _bankTransactions = database.GetCollection<BankTransaction>(Config.MONGO_BANK_TRANSACTION_PATH);
        }

        public List<BankTransaction> GetAll()
        {
            return _bankTransactions.Find(transaction => true).ToList();
        }

        public BankTransaction Get(int id)
        {
            return _bankTransactions.Find(transaction => transaction.Id == id).FirstOrDefault();
        }

        public void Add(BankTransaction entity)
        {
            if (entity.Id == 0 || Get(entity.Id) != null)
            {
                var entities = GetAll();
                if (entities.Count > 0)
                {
                    entity.Id = entities.Max(r => r.Id) + 1;
                }
                else
                {
                    entity.Id = 1;
                }
            }

            _bankTransactions.InsertOne(entity);
        }

        public void Update(BankTransaction bankTransaction)
        {
            _bankTransactions.ReplaceOne(existingTransaction => existingTransaction.Id == bankTransaction.Id, bankTransaction);
        }

        public void Delete(int id)
        {
            _bankTransactions.DeleteOne(transaction => transaction.Id == id);
        }
    }
}
