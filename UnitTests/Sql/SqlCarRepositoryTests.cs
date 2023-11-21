using DB_CourseWork.DbRepositories.Sql;
using DB_CourseWork.Models;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Transactions;
using UnitTests.ObjectsCreatesAndAsserts;

namespace UnitTests.Sql
{
    [TestFixture]
    public class SqlCarRepositoryTests
    {
        private SqlCarRepository _sqlCarRepository;
        private string? _sqlConnectionString;

        [SetUp]
        public void Setup()
        {
            var builder = new ConfigurationBuilder()
                              .SetBasePath(Directory.GetCurrentDirectory())
                              .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            IConfiguration _configuration = builder.Build();

            _sqlConnectionString = _configuration["ConnectionStrings:SqlTestConnectionString"];

            // Создать тестовую базу данных
            CreateTestDatabase();

            _sqlCarRepository = new SqlCarRepository(_sqlConnectionString);
        }

        [Test]
        public void Add_DoesNotThrowException_AndChangesId_WhenDuplicate()
        {
            var car = CarCreateAndAssert.CreateNewCarForTest();
            _sqlCarRepository.Add(car);

            int oldMaxId = _sqlCarRepository.GetAll().Max(c => c.Id);

            var carDuplicate = CarCreateAndAssert.CreateNewCarForTest();
            Assert.DoesNotThrow(() => _sqlCarRepository.Add(carDuplicate));

            var addedDuplicate = _sqlCarRepository.GetAll().FirstOrDefault(c => c.Id != car.Id);

            Assert.NotNull(addedDuplicate);
            Assert.That(addedDuplicate.Id, Is.EqualTo(oldMaxId + 1));
        }

        [Test]
        public void Add_ThrowsException_WhenAddNull()
        {
            Assert.Throws<NullReferenceException>(() => _sqlCarRepository.Add(null));
        }

        [Test]
        public void Add_AndGetAll_AddsFewCars_ReturnsAllAddedCars()
        {
            var carOne = CarCreateAndAssert.CreateNewCarForTest();
            carOne.Brand = "Brand One";
            _sqlCarRepository.Add(carOne);

            var carTwo = CarCreateAndAssert.CreateNewCarForTest();
            carTwo.Brand = "Brand Two";
            _sqlCarRepository.Add(carTwo);

            var result = _sqlCarRepository.GetAll().OrderBy(c => c.Id).ToArray();

            Assert.That(result.Length, Is.EqualTo(2));
            CarCreateAndAssert.DefaultCarAssert(result[0], "Brand One", 1);
            CarCreateAndAssert.DefaultCarAssert(result[1], "Brand Two", 2);
        }

        [Test]
        public void Add_AndGetAll_AddsCar_ReturnsAddedCar()
        {
            var car = CarCreateAndAssert.CreateNewCarForTest();
            car.Brand = "Test GetAll Car";
            _sqlCarRepository.Add(car);

            var result = _sqlCarRepository.GetAll();

            Assert.That(result.Count, Is.EqualTo(1));
            CarCreateAndAssert.DefaultCarAssert(result.First(), "Test GetAll Car");
        }

        [Test]
        public void GetAll_ReturnsEmptyList_WhenNoData()
        {
            var result = _sqlCarRepository.GetAll();

            Assert.IsEmpty(result);
        }

        [Test]
        public void Get_ReturnsNull_WhenNoData()
        {
            var fetchedCar = _sqlCarRepository.Get(999);

            Assert.IsNull(fetchedCar);
        }

        [Test]
        public void Get_ReturnsNull_ForNonexistentCar()
        {
            var car = CarCreateAndAssert.CreateNewCarForTest();
            _sqlCarRepository.Add(car);

            var fetchedCar = _sqlCarRepository.Get(999);

            Assert.IsNull(fetchedCar);
        }

        [Test]
        public void Get_ReturnsCorrectCar()
        {
            var car = CarCreateAndAssert.CreateNewCarForTest();
            _sqlCarRepository.Add(car);

            var fetchedCar = _sqlCarRepository.Get(1);

            CarCreateAndAssert.DefaultCarAssert(fetchedCar);
        }

        [Test]
        public void Update_DoesNotThrowException_WhenNoData()
        {
            var updatedCar = new Car { Id = 1, Brand = "Updated Car" };

            Assert.DoesNotThrow(() => _sqlCarRepository.Update(updatedCar));
        }

        [Test]
        public void Update_DoesNotThrowException_WhenNoSuchId()
        {
            var car = CarCreateAndAssert.CreateNewCarForTest();
            _sqlCarRepository.Add(car);
            var updatedCar = new Car { Id = 999, Brand = "Updated Car" };

            Assert.DoesNotThrow(() => _sqlCarRepository.Update(updatedCar));
        }

        [Test]
        public void Update_UpdatesCar()
        {
            var car = CarCreateAndAssert.CreateNewCarForTest();
            _sqlCarRepository.Add(car);
            var updatedCar = CarCreateAndAssert.CreateNewCarForTest();
            updatedCar.Brand = "Updated Car";
            _sqlCarRepository.Update(updatedCar);

            var fetchedCar = _sqlCarRepository.Get(1);

            CarCreateAndAssert.DefaultCarAssert(fetchedCar, "Updated Car");
        }

        [Test]
        public void Delete_DoesNotThrowException_WhenNoData()
        {
            Assert.DoesNotThrow(() => _sqlCarRepository.Delete(1));
        }

        [Test]
        public void Delete_DoesNotThrowException_WhenNoSuchId()
        {
            var car = CarCreateAndAssert.CreateNewCarForTest();
            _sqlCarRepository.Add(car);

            Assert.DoesNotThrow(() => _sqlCarRepository.Delete(999));
        }

        [Test]
        public void Delete_RemovesCar()
        {
            var car = CarCreateAndAssert.CreateNewCarForTest();
            _sqlCarRepository.Add(car);

            _sqlCarRepository.Delete(1);

            var result = _sqlCarRepository.GetAll();

            Assert.IsEmpty(result);
        }

        [TearDown]
        public void TearDown()
        {
            // Очистить тестовую базу данных
            DestroyTestDatabase();
        }

        private void CreateTestDatabase()
        {
            using (var connection = new SqlConnection(_sqlConnectionString))
            {
                connection.Open();

                string createCarsTable = @"CREATE TABLE Cars (
                                               Id INT PRIMARY KEY IDENTITY,
                                               Brand NVARCHAR(50) NOT NULL,
                                               Model NVARCHAR(50) NOT NULL,
                                               CarLicensePlate NVARCHAR(50) NOT NULL,
                                               PricePerHour FLOAT NOT NULL,
                                               ProductionYear DATETIME,
                                               BuyTime DATETIME,
                                               LastServiceTime DATETIME,
                                               LocationX FLOAT,
                                               LocationY FLOAT,
                                               IsHidden BIT NOT NULL
                                           );";

                using (var command = new SqlCommand(createCarsTable, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        private void DestroyTestDatabase()
        {
            using (var connection = new SqlConnection(_sqlConnectionString))
            {
                connection.Open();

                string dropCarsTable = "DROP TABLE IF EXISTS Cars;";

                using (var command = new SqlCommand(dropCarsTable, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}

