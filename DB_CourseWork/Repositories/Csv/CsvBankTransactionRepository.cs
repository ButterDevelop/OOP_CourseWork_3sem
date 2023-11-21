using DB_CourseWork.Controls;
using DB_CourseWork.Interfaces;
using DB_CourseWork.Models;
using System.Collections.Generic;
using System.Linq;

namespace DB_CourseWork.DbRepositories.Csv
{
    public class CsvBankTransactionRepository : IBankTransactionStrategy
    {
        private string _path = Config.CSV_BANK_TRANSACTION_PATH;

        public CsvBankTransactionRepository(string path = null)
        {
            if (path != null) _path = path;
        }

        public void Connect() { }

        public List<BankTransaction> GetAll()
        {
            return CsvSerializer.ReadFromFile<BankTransaction>(_path);
        }

        public BankTransaction Get(int id)
        {
            return CsvSerializer.ReadFromFile<BankTransaction>(_path).Find(bankTransaction => bankTransaction.Id == id);
        }

        public void Add(BankTransaction entity)
        {
            var bankTransactions = GetAll();
            if (entity.Id == 0 || bankTransactions.FirstOrDefault(r => r.Id == entity.Id) != null)
            {
                if (bankTransactions.Count > 0)
                {
                    entity.Id = bankTransactions.Max(r => r.Id) + 1;
                }
                else
                {
                    entity.Id = 1;
                }
            }
            bankTransactions.Add(entity);
            CsvSerializer.WriteToFile(_path, bankTransactions);
        }

        public void Update(BankTransaction entity)
        {
            var bankTransactions = GetAll();
            int index = bankTransactions.FindIndex(bankTransaction => bankTransaction.Id == entity.Id);
            if (index != -1)
            {
                bankTransactions[index] = entity;
                CsvSerializer.WriteToFile(_path, bankTransactions);
            }
        }

        public void Delete(int id)
        {
            var bankTransactions = GetAll();
            bankTransactions.RemoveAll(bankTransaction => bankTransaction.Id == id);
            CsvSerializer.WriteToFile(_path, bankTransactions);
        }
    }

}
