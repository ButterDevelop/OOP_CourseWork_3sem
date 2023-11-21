using DB_CourseWork.Controls;
using DB_CourseWork.Interfaces;
using DB_CourseWork.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace DB_CourseWork.DbRepositories.Mongo
{
    public class MongoCarRepository : ICarStrategy
    {
        private readonly IMongoCollection<Car> _cars;

        public MongoCarRepository(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            _cars = database.GetCollection<Car>(Config.MONGO_CAR_PATH);
        }

        public List<Car> GetAll()
        {
            return _cars.Find(car => true).ToList();
        }

        public Car Get(int id)
        {
            return _cars.Find(car => car.Id == id).FirstOrDefault();
        }

        public void Add(Car car)
        {
            if (car.Id == 0 || Get(car.Id) != null)
            {
                var entities = GetAll();
                if (entities.Count > 0)
                {
                    car.Id = entities.Max(r => r.Id) + 1;
                }
                else
                {
                    car.Id = 1;
                }
            }

            _cars.InsertOne(car);
        }

        public void Update(Car car)
        {
            _cars.ReplaceOne(existingCar => existingCar.Id == car.Id, car);
        }

        public void Delete(int id)
        {
            _cars.DeleteOne(car => car.Id == id);
        }
    }
}
