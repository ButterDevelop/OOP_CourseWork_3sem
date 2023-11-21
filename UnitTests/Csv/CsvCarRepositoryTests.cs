using DB_CourseWork.DbRepositories.Csv;
using DB_CourseWork.Models;
using UnitTests.ObjectsCreatesAndAsserts;

namespace UnitTests.Csv
{
    [TestFixture]
    public class CsvCarRepositoryTests
    {
        private string _testFilePath = "testCars.csv";
        private CsvCarRepository _csvCarRepository;

        [SetUp]
        public void Setup()
        {
            if (File.Exists(_testFilePath))
            {
                File.Delete(_testFilePath);
            }
            _csvCarRepository = new CsvCarRepository(_testFilePath);
        }

        [Test]
        public void Add_DoesNotThrowException_AndChangesId_WhenDuplicate()
        {
            var car = CarCreateAndAssert.CreateNewCarForTest();
            _csvCarRepository.Add(car);

            int oldMaxId = _csvCarRepository.GetAll().Max(c => c.Id);

            var carDuplicate = CarCreateAndAssert.CreateNewCarForTest();
            Assert.DoesNotThrow(() => _csvCarRepository.Add(carDuplicate));

            var addedDuplicate = _csvCarRepository.GetAll().FirstOrDefault(c => c.Id != car.Id);

            Assert.NotNull(addedDuplicate);
            Assert.That(addedDuplicate.Id, Is.EqualTo(oldMaxId + 1));
        }

        [Test]
        public void Add_ThrowsException_WhenAddNull()
        {
            Assert.Throws<NullReferenceException>(() => _csvCarRepository.Add(null));
        }

        [Test]
        public void Add_AndGetAll_AddsFewCars_ReturnsAllAddedCars()
        {
            var carOne = CarCreateAndAssert.CreateNewCarForTest();
            carOne.Brand = "Brand One";
            _csvCarRepository.Add(carOne);

            var carTwo = CarCreateAndAssert.CreateNewCarForTest();
            carTwo.Brand = "Brand Two";
            _csvCarRepository.Add(carTwo);

            var result = _csvCarRepository.GetAll().OrderBy(c => c.Id).ToArray();

            Assert.That(result.Count, Is.EqualTo(2));
            CarCreateAndAssert.DefaultCarAssert(result[0], "Brand One", 1);
            CarCreateAndAssert.DefaultCarAssert(result[1], "Brand Two", 2);
        }

        [Test]
        public void Add_AndGetAll_AddsCar_ReturnsAddedCar()
        {
            var car = CarCreateAndAssert.CreateNewCarForTest();
            car.Brand = "Test GetAll Car";
            _csvCarRepository.Add(car);

            var result = _csvCarRepository.GetAll();

            Assert.That(result.Count, Is.EqualTo(1));
            CarCreateAndAssert.DefaultCarAssert(result.First(), "Test GetAll Car");
        }

        [Test]
        public void GetAll_ReturnsEmptyList_WhenNoData()
        {
            var result = _csvCarRepository.GetAll();

            Assert.IsEmpty(result);
        }

        [Test]
        public void Get_ReturnsNull_WhenNoData()
        {
            var fetchedCar = _csvCarRepository.Get(999);

            Assert.IsNull(fetchedCar);
        }

        [Test]
        public void Get_ReturnsNull_ForNonexistentCar()
        {
            var car = CarCreateAndAssert.CreateNewCarForTest();
            _csvCarRepository.Add(car);

            var fetchedCar = _csvCarRepository.Get(999);

            Assert.IsNull(fetchedCar);
        }

        [Test]
        public void Get_ReturnsCorrectCar()
        {
            var car = CarCreateAndAssert.CreateNewCarForTest();
            _csvCarRepository.Add(car);

            var fetchedCar = _csvCarRepository.Get(1);

            CarCreateAndAssert.DefaultCarAssert(fetchedCar);
        }

        [Test]
        public void Update_DoesNotThrowException_WhenNoData()
        {
            var updatedCar = new Car { Id = 1, Brand = "Updated Car" };

            Assert.DoesNotThrow(() => _csvCarRepository.Update(updatedCar));
        }

        [Test]
        public void Update_DoesNotThrowException_WhenNoSuchId()
        {
            var car = CarCreateAndAssert.CreateNewCarForTest();
            _csvCarRepository.Add(car);
            var updatedCar = new Car { Id = 999, Brand = "Updated Car" };

            Assert.DoesNotThrow(() => _csvCarRepository.Update(updatedCar));
        }

        [Test]
        public void Update_UpdatesCar()
        {
            var car = CarCreateAndAssert.CreateNewCarForTest();
            _csvCarRepository.Add(car);
            var updatedCar = CarCreateAndAssert.CreateNewCarForTest();
            updatedCar.Brand = "Updated Car";
            _csvCarRepository.Update(updatedCar);

            var fetchedCar = _csvCarRepository.Get(1);

            CarCreateAndAssert.DefaultCarAssert(fetchedCar, "Updated Car");
        }

        [Test]
        public void Delete_DoesNotThrowException_WhenNoData()
        {
            Assert.DoesNotThrow(() => _csvCarRepository.Delete(1));
        }

        [Test]
        public void Delete_DoesNotThrowException_WhenNoSuchId()
        {
            var car = CarCreateAndAssert.CreateNewCarForTest();
            _csvCarRepository.Add(car);

            Assert.DoesNotThrow(() => _csvCarRepository.Delete(999));
        }

        [Test]
        public void Delete_RemovesCar()
        {
            var car = CarCreateAndAssert.CreateNewCarForTest();
            _csvCarRepository.Add(car);

            _csvCarRepository.Delete(1);

            var result = _csvCarRepository.GetAll();

            Assert.IsEmpty(result);
        }

        [TearDown]
        public void TearDown()
        {
            if (File.Exists(_testFilePath))
            {
                File.Delete(_testFilePath);
            }
        }
    }
}
