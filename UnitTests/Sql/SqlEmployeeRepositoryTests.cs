using DB_CourseWork.DbRepositories.Sql;
using DB_CourseWork.Models;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using UnitTests.ObjectsCreatesAndAsserts;

namespace UnitTests.Sql
{
    [TestFixture]
    public class SqlEmployeeRepositoryTests
    {
        private SqlEmployeeRepository _sqlEmployeeRepository;
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

            _sqlEmployeeRepository = new SqlEmployeeRepository(_sqlConnectionString);
        }

        [Test]
        public void Add_DoesNotThrowException_AndChangesId_WhenDuplicate()
        {
            var employee = EmployeeCreateAndAssert.CreateNewEmployeeForTest();
            _sqlEmployeeRepository.Add(employee);

            int oldMaxId = _sqlEmployeeRepository.GetAll().Max(e => e.Id);

            var employeeDuplicate = EmployeeCreateAndAssert.CreateNewEmployeeForTest();
            Assert.DoesNotThrow(() => _sqlEmployeeRepository.Add(employeeDuplicate));

            var addedDuplicate = _sqlEmployeeRepository.GetAll().FirstOrDefault(e => e.Id != employee.Id);

            Assert.NotNull(addedDuplicate);
            Assert.That(addedDuplicate.Id, Is.EqualTo(oldMaxId + 1));
        }

        [Test]
        public void Add_ThrowsException_WhenAddNull()
        {
            Assert.Throws<NullReferenceException>(() => _sqlEmployeeRepository.Add(null));
        }

        [Test]
        public void Add_AndGetAll_AddsFewEmployees_ReturnsAllAddedEmployees()
        {
            var employeeOne = EmployeeCreateAndAssert.CreateNewEmployeeForTest();
            employeeOne.FullName = "Test Employee One";
            _sqlEmployeeRepository.Add(employeeOne);

            var employeeTwo = EmployeeCreateAndAssert.CreateNewEmployeeForTest();
            employeeTwo.FullName = "Test Employee Two";
            _sqlEmployeeRepository.Add(employeeTwo);

            var result = _sqlEmployeeRepository.GetAll().OrderBy(e => e.Id).ToArray();

            Assert.That(result.Length, Is.EqualTo(2));
            EmployeeCreateAndAssert.DefaultEmployeeAssert(result[0], "Test Employee One", 1);
            EmployeeCreateAndAssert.DefaultEmployeeAssert(result[1], "Test Employee Two", 2);
        }

        [Test]
        public void Add_AndGetAll_AddsEmployee_ReturnsAddedEmployee()
        {
            var employee = EmployeeCreateAndAssert.CreateNewEmployeeForTest();
            employee.FullName = "Test GetAll Employee";
            _sqlEmployeeRepository.Add(employee);

            var result = _sqlEmployeeRepository.GetAll();

            Assert.That(result.Count, Is.EqualTo(1));
            EmployeeCreateAndAssert.DefaultEmployeeAssert(result.First(), "Test GetAll Employee");
        }

        [Test]
        public void GetAll_ReturnsEmptyList_WhenNoData()
        {
            var result = _sqlEmployeeRepository.GetAll();

            Assert.IsEmpty(result);
        }

        [Test]
        public void Get_ReturnsNull_WhenNoData()
        {
            var fetchedEmployee = _sqlEmployeeRepository.Get(999);

            Assert.IsNull(fetchedEmployee);
        }

        [Test]
        public void Get_ReturnsNull_ForNonexistentEmployee()
        {
            var employee = EmployeeCreateAndAssert.CreateNewEmployeeForTest();
            _sqlEmployeeRepository.Add(employee);

            var fetchedEmployee = _sqlEmployeeRepository.Get(999);

            Assert.IsNull(fetchedEmployee);
        }

        [Test]
        public void Get_ReturnsCorrectEmployee()
        {
            var employee = EmployeeCreateAndAssert.CreateNewEmployeeForTest();
            _sqlEmployeeRepository.Add(employee);

            var fetchedEmployee = _sqlEmployeeRepository.Get(1);

            EmployeeCreateAndAssert.DefaultEmployeeAssert(fetchedEmployee);
        }

        [Test]
        public void Update_DoesNotThrowException_WhenNoData()
        {
            var updatedEmployee = EmployeeCreateAndAssert.CreateNewEmployeeForTest();
            updatedEmployee.FullName = "Updated Employee";

            Assert.DoesNotThrow(() => _sqlEmployeeRepository.Update(updatedEmployee));
        }

        [Test]
        public void Update_DoesNotThrowException_WhenNoSuchId()
        {
            var employee = EmployeeCreateAndAssert.CreateNewEmployeeForTest();
            _sqlEmployeeRepository.Add(employee);
            var updatedEmployee = EmployeeCreateAndAssert.CreateNewEmployeeForTest();
            updatedEmployee.FullName = "Updated Employee";

            Assert.DoesNotThrow(() => _sqlEmployeeRepository.Update(updatedEmployee));
        }

        [Test]
        public void Update_UpdatesEmployee()
        {
            var employee = EmployeeCreateAndAssert.CreateNewEmployeeForTest();
            _sqlEmployeeRepository.Add(employee);
            var updatedEmployee = EmployeeCreateAndAssert.CreateNewEmployeeForTest();
            updatedEmployee.FullName = "Updated Employee";
            _sqlEmployeeRepository.Update(updatedEmployee);

            var fetchedEmployee = _sqlEmployeeRepository.Get(1);

            EmployeeCreateAndAssert.DefaultEmployeeAssert(fetchedEmployee, "Updated Employee");
        }

        [Test]
        public void Delete_DoesNotThrowException_WhenNoData()
        {
            Assert.DoesNotThrow(() => _sqlEmployeeRepository.Delete(1));
        }

        [Test]
        public void Delete_DoesNotThrowException_WhenNoSuchId()
        {
            var employee = EmployeeCreateAndAssert.CreateNewEmployeeForTest();
            _sqlEmployeeRepository.Add(employee);

            Assert.DoesNotThrow(() => _sqlEmployeeRepository.Delete(999));
        }

        [Test]
        public void Delete_RemovesEmployee()
        {
            var employee = EmployeeCreateAndAssert.CreateNewEmployeeForTest();
            _sqlEmployeeRepository.Add(employee);

            _sqlEmployeeRepository.Delete(1);

            var result = _sqlEmployeeRepository.GetAll();

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

                string createUsersTable = @"CREATE TABLE Users (
                                               Id INT PRIMARY KEY IDENTITY,
                                               Username NVARCHAR(50) NOT NULL,
                                               Salt NVARCHAR(255) NOT NULL,
                                               HashedPassword NVARCHAR(255) NOT NULL,
                                               Fullname NVARCHAR(100),
                                               Email NVARCHAR(100),
                                               Phone NVARCHAR(20),
                                               Role INT NOT NULL,
                                               IsAccountSetupCompleted BIT NOT NULL,
                                               AccountDeactivated BIT NOT NULL
                                           );";

                string createEmployeesTable = @"CREATE TABLE Employees (
                                                  UserId INT PRIMARY KEY,
                                                  OrdersProcessed INT,
                                                  DaysWorked INT,
                                                  DateHired DATETIME,
                                                  DateFired DATETIME,
                                                  DateLastSalaryPayed DATETIME,
                                                  BankAccountNumber NVARCHAR(50),
                                                  TotalSalaryPaid FLOAT,
                                                  IsWorkingNow BIT,
                                                  FOREIGN KEY (UserId) REFERENCES Users(Id)
                                              );";

                using (var command = new SqlCommand(createUsersTable, connection))
                {
                    command.ExecuteNonQuery();
                }

                using (var command = new SqlCommand(createEmployeesTable, connection))
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

                string dropEmployeesTable = "DROP TABLE IF EXISTS Employees; DROP TABLE IF EXISTS Users;";

                using (var command = new SqlCommand(dropEmployeesTable, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
