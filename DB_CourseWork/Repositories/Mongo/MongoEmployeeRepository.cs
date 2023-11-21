using DB_CourseWork.Controls;
using DB_CourseWork.Interfaces;
using DB_CourseWork.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace DB_CourseWork.DbRepositories.Mongo
{
    public class MongoEmployeeRepository : IEmployeeStrategy
    {
        private readonly IMongoCollection<Employee> _employees;

        public MongoEmployeeRepository(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            _employees = database.GetCollection<Employee>(Config.MONGO_EMPLOYEE_PATH);
        }

        public List<Employee> GetAll()
        {
            return _employees.Find(employee => true).ToList();
        }

        public Employee Get(int id)
        {
            return _employees.Find(employee => employee.Id == id).FirstOrDefault();
        }

        public void Add(Employee employee)
        {
            if (employee.Id == 0 || Get(employee.Id) != null)
            {
                var entities = GetAll();
                if (entities.Count > 0)
                {
                    employee.Id = entities.Max(r => r.Id) + 1;
                }
                else
                {
                    employee.Id = 1;
                }
            }

            _employees.InsertOne(employee);
        }

        public void Update(Employee employee)
        {
            _employees.ReplaceOne(existingEmployee => existingEmployee.Id == employee.Id, employee);
        }

        public void Delete(int id)
        {
            _employees.DeleteOne(employee => employee.Id == id);
        }
    }
}
