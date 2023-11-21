using DB_CourseWork.DbRepositories.Mongo;
using DB_CourseWork.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using UnitTests.ObjectsCreatesAndAsserts;

namespace UnitTests.Mongo
{
    [TestFixture]
    public class MongoCarRepositoryTests
    {
        private MongoCarRepository _mongoCarRepository;
        private IMongoCollection<Car> _carCollection;

        [SetUp]
        public void Setup()
        {
            var builder = new ConfigurationBuilder()
                              .SetBasePath(Directory.GetCurrentDirectory())
                              .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            IConfiguration configuration = builder.Build();

            string? mongoConnectionString = configuration["ConnectionStrings:MongoConnectionString"],
                    mongoTestDatabaseName = configuration["ConnectionStrings:MongoTestDatabaseName"],
                    mongoTableName = configuration["MongoTableNames:MONGO_CAR_PATH"];

            var client = new MongoClient(mongoConnectionString);
            var database = client.GetDatabase(mongoTestDatabaseName);

            _carCollection = database.GetCollection<Car>(mongoTableName);
            _carCollection.DeleteMany(FilterDefinition<Car>.Empty);

            _mongoCarRepository = new MongoCarRepository(mongoConnectionString, mongoTestDatabaseName);
        }

        [Test]
        public void Add_DoesNotThrowException_AndChangesId_WhenDuplicate()
        {
            var car = CarCreateAndAssert.CreateNewCarForTest();
            _mongoCarRepository.Add(car);

            int oldMaxId = _mongoCarRepository.GetAll().Max(c => c.Id);

            var carDuplicate = CarCreateAndAssert.CreateNewCarForTest();
            Assert.DoesNotThrow(() => _mongoCarRepository.Add(carDuplicate));

            var addedDuplicate = _mongoCarRepository.GetAll().FirstOrDefault(c => c.Id != car.Id);

            Assert.NotNull(addedDuplicate);
            Assert.That(addedDuplicate.Id, Is.EqualTo(oldMaxId + 1));
        }

        [Test]
        public void Add_ThrowsException_WhenAddNull()
        {
            Assert.Throws<NullReferenceException>(() => _mongoCarRepository.Add(null));
        }

        [Test]
        public void Add_AndGetAll_AddsFewCars_ReturnsAllAddedCars()
        {
            var carOne = CarCreateAndAssert.CreateNewCarForTest();
            carOne.Brand = "Brand One";
            _mongoCarRepository.Add(carOne);

            var carTwo = CarCreateAndAssert.CreateNewCarForTest();
            carTwo.Brand = "Brand Two";
            _mongoCarRepository.Add(carTwo);

            var result = _mongoCarRepository.GetAll().OrderBy(c => c.Id).ToArray();

            Assert.That(result.Length, Is.EqualTo(2));
            CarCreateAndAssert.DefaultCarAssert(result[0], "Brand One", 1);
            CarCreateAndAssert.DefaultCarAssert(result[1], "Brand Two", 2);
        }

        [Test]
        public void Add_AndGetAll_AddsCar_ReturnsAddedCar()
        {
            var car = CarCreateAndAssert.CreateNewCarForTest();
            car.Brand = "Test GetAll Car";
            _mongoCarRepository.Add(car);

            var result = _mongoCarRepository.GetAll();

            Assert.That(result.Count, Is.EqualTo(1));
            CarCreateAndAssert.DefaultCarAssert(result.First(), "Test GetAll Car");
        }

        [Test]
        public void GetAll_ReturnsEmptyList_WhenNoData()
        {
            var result = _mongoCarRepository.GetAll();

            Assert.IsEmpty(result);
        }

        [Test]
        public void Get_ReturnsNull_WhenNoData()
        {
            var fetchedCar = _mongoCarRepository.Get(999);

            Assert.IsNull(fetchedCar);
        }

        [Test]
        public void Get_ReturnsNull_ForNonexistentCar()
        {
            var car = CarCreateAndAssert.CreateNewCarForTest();
            _mongoCarRepository.Add(car);

            var fetchedCar = _mongoCarRepository.Get(999);

            Assert.IsNull(fetchedCar);
        }

        [Test]
        public void Get_ReturnsCorrectCar()
        {
            var car = CarCreateAndAssert.CreateNewCarForTest();
            _mongoCarRepository.Add(car);

            var fetchedCar = _mongoCarRepository.Get(1);

            CarCreateAndAssert.DefaultCarAssert(fetchedCar);
        }

        [Test]
        public void Update_DoesNotThrowException_WhenNoData()
        {
            var updatedCar = new Car { Id = 1, Brand = "Updated Car" };

            Assert.DoesNotThrow(() => _mongoCarRepository.Update(updatedCar));
        }

        [Test]
        public void Update_DoesNotThrowException_WhenNoSuchId()
        {
            var car = CarCreateAndAssert.CreateNewCarForTest();
            _mongoCarRepository.Add(car);
            var updatedCar = new Car { Id = 999, Brand = "Updated Car" };

            Assert.DoesNotThrow(() => _mongoCarRepository.Update(updatedCar));
        }

        [Test]
        public void Update_UpdatesCar()
        {
            var car = CarCreateAndAssert.CreateNewCarForTest();
            _mongoCarRepository.Add(car);
            var updatedCar = CarCreateAndAssert.CreateNewCarForTest();
            updatedCar.Brand = "Updated Car";
            _mongoCarRepository.Update(updatedCar);

            var fetchedCar = _mongoCarRepository.Get(1);

            CarCreateAndAssert.DefaultCarAssert(fetchedCar, "Updated Car");
        }

        [Test]
        public void Delete_DoesNotThrowException_WhenNoData()
        {
            Assert.DoesNotThrow(() => _mongoCarRepository.Delete(1));
        }

        [Test]
        public void Delete_DoesNotThrowException_WhenNoSuchId()
        {
            var car = CarCreateAndAssert.CreateNewCarForTest();
            _mongoCarRepository.Add(car);

            Assert.DoesNotThrow(() => _mongoCarRepository.Delete(999));
        }

        [Test]
        public void Delete_RemovesCar()
        {
            var car = CarCreateAndAssert.CreateNewCarForTest();
            _mongoCarRepository.Add(car);

            _mongoCarRepository.Delete(1);

            var result = _mongoCarRepository.GetAll();

            Assert.IsEmpty(result);
        }

        [TearDown]
        public void TearDown()
        {
            _carCollection.DeleteMany(FilterDefinition<Car>.Empty);
        }
    }
}

