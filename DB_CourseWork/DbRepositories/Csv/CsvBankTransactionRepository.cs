using DB_CourseWork.Controls;
using DB_CourseWork.Interfaces;
using DB_CourseWork.Models;
using System.Collections.Generic;

namespace DB_CourseWork.DbRepositories.Csv
{
    class CsvBankTransactionRepository : IBankTransactionStrategy
    {
        private static readonly string _path = Config.CSV_BANK_TRANSACTION_PATH;

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
