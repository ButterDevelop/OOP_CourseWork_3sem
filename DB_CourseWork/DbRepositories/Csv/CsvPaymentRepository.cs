using DB_CourseWork.Controls;
using DB_CourseWork.Interfaces;
using DB_CourseWork.Models;
using System.Collections.Generic;

namespace DB_CourseWork.DbRepositories.Csv
{
    class CsvPaymentRepository : IPaymentStrategy
    {
        private static readonly string _path = Config.CSV_PAYMENT_PATH;

        public void Connect() { }

        public List<Payment> GetAll()
        {
            return CsvSerializer.ReadFromFile<Payment>(_path);
        }

        public Payment Get(int id)
        {
            return CsvSerializer.ReadFromFile<Payment>(_path).Find(payment => payment.Id == id);
        }

        public void Add(Payment entity)
        {
            var payments = GetAll();
            payments.Add(entity);
            CsvSerializer.WriteToFile(_path, payments);
        }

        public void Update(Payment entity)
        {
            var payments = GetAll();
            int index = payments.FindIndex(payment => payment.Id == entity.Id);
            if (index != -1)
            {
                payments[index] = entity;
                CsvSerializer.WriteToFile(_path, payments);
            }
        }

        public void Delete(int id)
        {
            var payments = GetAll();
            payments.RemoveAll(payment => payment.Id == id);
            CsvSerializer.WriteToFile(_path, payments);
        }
    }

}
