using DB_CourseWork.Controls;
using DB_CourseWork.Interfaces;
using DB_CourseWork.Models;
using System.Collections.Generic;
using System.Linq;

namespace DB_CourseWork.DbRepositories.Csv
{
    public class CsvCarRepository : ICarStrategy
    {
        private string _path = Config.CSV_CAR_PATH;

        public CsvCarRepository(string path = null) 
        {
            if (path != null) _path = path;
        }

        public void Connect() { }

        public List<Car> GetAll()
        {
            return CsvSerializer.ReadFromFile<Car>(_path);
        }

        public Car Get(int id)
        {
            return CsvSerializer.ReadFromFile<Car>(_path).Find(car => car.Id == id);
        }

        public void Add(Car entity)
        {
            var cars = GetAll();
            if (entity.Id == 0 || cars.FirstOrDefault(r => r.Id == entity.Id) != null)
            {
                if (cars.Count > 0)
                {
                    entity.Id = cars.Max(r => r.Id) + 1;
                }
                else
                {
                    entity.Id = 1;
                }
            }
            cars.Add(entity);
            CsvSerializer.WriteToFile(_path, cars);
        }

        public void Update(Car entity)
        {
            var cars = GetAll();
            int index = cars.FindIndex(car => car.Id == entity.Id);
            if (index != -1)
            {
                cars[index] = entity;
                CsvSerializer.WriteToFile(_path, cars);
            }
        }

        public void Delete(int id)
        {
            var cars = GetAll();
            cars.RemoveAll(car => car.Id == id);
            CsvSerializer.WriteToFile(_path, cars);
        }
    }

}
