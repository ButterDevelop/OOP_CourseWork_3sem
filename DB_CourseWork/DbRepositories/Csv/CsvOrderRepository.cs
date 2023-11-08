using DB_CourseWork.Controls;
using DB_CourseWork.Interfaces;
using DB_CourseWork.Models;
using System.Collections.Generic;

namespace DB_CourseWork.DbRepositories.Csv
{
    class CsvOrderRepository : IOrderStrategy
    {
        private static readonly string _path = Config.CSV_ORDER_PATH;

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
