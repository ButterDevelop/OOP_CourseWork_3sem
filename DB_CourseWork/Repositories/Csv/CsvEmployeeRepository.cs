using DB_CourseWork.Controls;
using DB_CourseWork.Interfaces;
using DB_CourseWork.Models;
using System.Collections.Generic;
using System.Linq;

namespace DB_CourseWork.DbRepositories.Csv
{
    public class CsvEmployeeRepository : IEmployeeStrategy
    {
        private string _path = Config.CSV_EMPLOYEE_PATH;

        public CsvEmployeeRepository(string path = null)
        {
            if (path != null) _path = path;
        }

        public void Connect() { }

        public List<Employee> GetAll()
        {
            return CsvSerializer.ReadFromFile<Employee>(_path);
        }

        public Employee Get(int id)
        {
            return CsvSerializer.ReadFromFile<Employee>(_path).Find(employee => employee.Id == id);
        }

        public void Add(Employee entity)
        {
            var employees = GetAll();
            if (entity.Id == 0 || employees.FirstOrDefault(r => r.Id == entity.Id) != null)
            {
                if (employees.Count > 0)
                {
                    entity.Id = employees.Max(r => r.Id) + 1;
                }
                else
                {
                    entity.Id = 1;
                }
            }
            employees.Add(entity);
            CsvSerializer.WriteToFile(_path, employees);
        }

        public void Update(Employee entity)
        {
            var employees = GetAll();
            int index = employees.FindIndex(employee => employee.Id == entity.Id);
            if (index != -1)
            {
                employees[index] = entity;
                CsvSerializer.WriteToFile(_path, employees);
            }
        }

        public void Delete(int id)
        {
            var employees = GetAll();
            employees.RemoveAll(employee => employee.Id == id);
            CsvSerializer.WriteToFile(_path, employees);
        }
    }

}
