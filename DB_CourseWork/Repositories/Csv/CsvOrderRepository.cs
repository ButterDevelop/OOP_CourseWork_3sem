using DB_CourseWork.Controls;
using DB_CourseWork.Interfaces;
using DB_CourseWork.Models;
using System.Collections.Generic;
using System.Linq;

namespace DB_CourseWork.DbRepositories.Csv
{
    public class CsvOrderRepository : IOrderStrategy
    {
        private string _path = Config.CSV_ORDER_PATH;

        public CsvOrderRepository(string path = null) 
        {
            if (path != null) _path = path;
        }

        public void Connect() { }

        public List<Order> GetAll()
        {
            return CsvSerializer.ReadFromFile<Order>(_path);
        }

        public Order Get(int id)
        {
            return CsvSerializer.ReadFromFile<Order>(_path).Find(order => order.Id == id);
        }

        public void Add(Order entity)
        {
            var orders = GetAll();
            if (entity.Id == 0 || orders.FirstOrDefault(r => r.Id == entity.Id) != null)
            {
                if (orders.Count > 0)
                {
                    entity.Id = orders.Max(r => r.Id) + 1;
                }
                else
                {
                    entity.Id = 1;
                }
            }
            orders.Add(entity);
            CsvSerializer.WriteToFile(_path, orders);
        }

        public void Update(Order entity)
        {
            var orders = GetAll();
            int index = orders.FindIndex(order => order.Id == entity.Id);
            if (index != -1)
            {
                orders[index] = entity;
                CsvSerializer.WriteToFile(_path, orders);
            }
        }

        public void Delete(int id)
        {
            var orders = GetAll();
            orders.RemoveAll(order => order.Id == id);
            CsvSerializer.WriteToFile(_path, orders);
        }
    }

}
