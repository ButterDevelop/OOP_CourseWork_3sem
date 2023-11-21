using DB_CourseWork.Controls;
using DB_CourseWork.Interfaces;
using DB_CourseWork.Models;
using System.Collections.Generic;
using System.Linq;

namespace DB_CourseWork.DbRepositories.Csv
{
    public class CsvPaymentRepository : IPaymentStrategy
    {
        private string _path = Config.CSV_PAYMENT_PATH;

        public CsvPaymentRepository(string path = null)
        {
            if (path != null) _path = path;
        }

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
            if (entity.Id == 0 || payments.FirstOrDefault(r => r.Id == entity.Id) != null)
            {
                if (payments.Count > 0)
                {
                    entity.Id = payments.Max(r => r.Id) + 1;
                }
                else
                {
                    entity.Id = 1;
                }
            }
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
