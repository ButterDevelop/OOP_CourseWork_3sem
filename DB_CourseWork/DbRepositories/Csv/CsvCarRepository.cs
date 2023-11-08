using DB_CourseWork.Controls;
using DB_CourseWork.Interfaces;
using DB_CourseWork.Models;
using System.Collections.Generic;

namespace DB_CourseWork.DbRepositories.Csv
{
    class CsvCarRepository : ICarStrategy
    {
        private static readonly string _path = Config.CSV_CAR_PATH;

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
