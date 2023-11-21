using DB_CourseWork.DbRepositories.Mongo;
using DB_CourseWork.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using UnitTests.ObjectsCreatesAndAsserts;

namespace UnitTests.Mongo
{
    [TestFixture]
    public class MongoEmployeeRepositoryTests
    {
        private MongoEmployeeRepository _mongoEmployeeRepository;
        private IMongoCollection<Employee> _employeeCollection;

        [SetUp]
        public void Setup()
        {
            var builder = new ConfigurationBuilder()
                              .SetBasePath(Directory.GetCurrentDirectory())
                              .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            IConfiguration configuration = builder.Build();

            string? mongoConnectionString = configuration["ConnectionStrings:MongoConnectionString"],
                    mongoTestDatabaseName = configuration["ConnectionStrings:MongoTestDatabaseName"],
                    mongoTableName = configuration["MongoTableNames:MONGO_EMPLOYEE_PATH"];

            var client = new MongoClient(mongoConnectionString);
            var database = client.GetDatabase(mongoTestDatabaseName);

            _employeeCollection = database.GetCollection<Employee>(mongoTableName);
            _employeeCollection.DeleteMany(FilterDefinition<Employee>.Empty);

            _mongoEmployeeRepository = new MongoEmployeeRepository(mongoConnectionString, mongoTestDatabaseName);
        }

        [Test]
        public void Add_DoesNotThrowException_AndChangesId_WhenDuplicate()
        {
            var employee = EmployeeCreateAndAssert.CreateNewEmployeeForTest();
            _mongoEmployeeRepository.Add(employee);

            int oldMaxId = _mongoEmployeeRepository.GetAll().Max(e => e.Id);

            var employeeDuplicate = EmployeeCreateAndAssert.CreateNewEmployeeForTest();
            Assert.DoesNotThrow(() => _mongoEmployeeRepository.Add(employeeDuplicate));

            var addedDuplicate = _mongoEmployeeRepository.GetAll().FirstOrDefault(e => e.Id != employee.Id);

            Assert.NotNull(addedDuplicate);
            Assert.That(addedDuplicate.Id, Is.EqualTo(oldMaxId + 1));
        }

        [Test]
        public void Add_ThrowsException_WhenAddNull()
        {
            Assert.Throws<NullReferenceException>(() => _mongoEmployeeRepository.Add(null));
        }

        [Test]
        public void Add_AndGetAll_AddsFewEmployees_ReturnsAllAddedEmployees()
        {
            var employeeOne = EmployeeCreateAndAssert.CreateNewEmployeeForTest();
            employeeOne.FullName = "Test Employee One";
            _mongoEmployeeRepository.Add(employeeOne);

            var employeeTwo = EmployeeCreateAndAssert.CreateNewEmployeeForTest();
            employeeTwo.FullName = "Test Employee Two";
            _mongoEmployeeRepository.Add(employeeTwo);

            var result = _mongoEmployeeRepository.GetAll().OrderBy(e => e.Id).ToArray();

            Assert.That(result.Length, Is.EqualTo(2));
            EmployeeCreateAndAssert.DefaultEmployeeAssert(result[0], "Test Employee One", 1);
            EmployeeCreateAndAssert.DefaultEmployeeAssert(result[1], "Test Employee Two", 2);
        }

        [Test]
        public void Add_AndGetAll_AddsEmployee_ReturnsAddedEmployee()
        {
            var employee = EmployeeCreateAndAssert.CreateNewEmployeeForTest();
            employee.FullName = "Test GetAll Employee";
            _mongoEmployeeRepository.Add(employee);

            var result = _mongoEmployeeRepository.GetAll();

            Assert.That(result.Count, Is.EqualTo(1));
            EmployeeCreateAndAssert.DefaultEmployeeAssert(result.First(), "Test GetAll Employee");
        }

        [Test]
        public void GetAll_ReturnsEmptyList_WhenNoData()
        {
            var result = _mongoEmployeeRepository.GetAll();

            Assert.IsEmpty(result);
        }

        [Test]
        public void Get_ReturnsNull_WhenNoData()
        {
            var fetchedEmployee = _mongoEmployeeRepository.Get(999);

            Assert.IsNull(fetchedEmployee);
        }

        [Test]
        public void Get_ReturnsNull_ForNonexistentEmployee()
        {
            var employee = EmployeeCreateAndAssert.CreateNewEmployeeForTest();
            _mongoEmployeeRepository.Add(employee);

            var fetchedEmployee = _mongoEmployeeRepository.Get(999);

            Assert.IsNull(fetchedEmployee);
        }

        [Test]
        public void Get_ReturnsCorrectEmployee()
        {
            var employee = EmployeeCreateAndAssert.CreateNewEmployeeForTest();
            _mongoEmployeeRepository.Add(employee);

            var fetchedEmployee = _mongoEmployeeRepository.Get(1);

            EmployeeCreateAndAssert.DefaultEmployeeAssert(fetchedEmployee);
        }

        [Test]
        public void Update_DoesNotThrowException_WhenNoData()
        {
            var updatedEmployee = new Employee { Id = 1, FullName = "Updated Employee" };

            Assert.DoesNotThrow(() => _mongoEmployeeRepository.Update(updatedEmployee));
        }

        [Test]
        public void Update_DoesNotThrowException_WhenNoSuchId()
        {
            var employee = EmployeeCreateAndAssert.CreateNewEmployeeForTest();
            _mongoEmployeeRepository.Add(employee);
            var updatedEmployee = new Employee { Id = 999, FullName = "Updated Employee" };

            Assert.DoesNotThrow(() => _mongoEmployeeRepository.Update(updatedEmployee));
        }

        [Test]
        public void Update_UpdatesEmployee()
        {
            var employee = EmployeeCreateAndAssert.CreateNewEmployeeForTest();
            _mongoEmployeeRepository.Add(employee);
            var updatedEmployee = EmployeeCreateAndAssert.CreateNewEmployeeForTest();
            updatedEmployee.FullName = "Updated Employee";
            _mongoEmployeeRepository.Update(updatedEmployee);

            var fetchedEmployee = _mongoEmployeeRepository.Get(1);

            EmployeeCreateAndAssert.DefaultEmployeeAssert(fetchedEmployee, "Updated Employee");
        }

        [Test]
        public void Delete_DoesNotThrowException_WhenNoData()
        {
            Assert.DoesNotThrow(() => _mongoEmployeeRepository.Delete(1));
        }

        [Test]
        public void Delete_DoesNotThrowException_WhenNoSuchId()
        {
            var employee = EmployeeCreateAndAssert.CreateNewEmployeeForTest();
            _mongoEmployeeRepository.Add(employee);

            Assert.DoesNotThrow(() => _mongoEmployeeRepository.Delete(999));
        }

        [Test]
        public void Delete_RemovesEmployee()
        {
            var employee = EmployeeCreateAndAssert.CreateNewEmployeeForTest();
            _mongoEmployeeRepository.Add(employee);

            _mongoEmployeeRepository.Delete(1);

            var result = _mongoEmployeeRepository.GetAll();

            Assert.IsEmpty(result);
        }

        [TearDown]
        public void TearDown()
        {
            _employeeCollection.DeleteMany(FilterDefinition<Employee>.Empty);
        }
    }
}
