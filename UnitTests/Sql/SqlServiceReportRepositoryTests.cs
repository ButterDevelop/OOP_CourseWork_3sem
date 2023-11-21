using DB_CourseWork.DbRepositories.Sql;
using DB_CourseWork.Models;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using UnitTests.ObjectsCreatesAndAsserts;

namespace UnitTests.Sql
{
    [TestFixture]
    public class SqlServiceReportRepositoryTests
    {
        private SqlEmployeeRepository _sqlEmployeeRepository;
        private SqlCarRepository _sqlCarRepository;
        private SqlServiceReportRepository _sqlServiceReportRepository;
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
            _sqlCarRepository = new SqlCarRepository(_sqlConnectionString);
            _sqlServiceReportRepository = new SqlServiceReportRepository(_sqlConnectionString);

            AddNecessaryData();
        }

        [Test]
        public void Add_DoesNotThrowException_AndChangesId_WhenDuplicate()
        {
            var serviceReport = ServiceReportCreateAndAssert.CreateNewServiceReportForTest();
            _sqlServiceReportRepository.Add(serviceReport);

            int oldMaxId = _sqlServiceReportRepository.GetAll().Max(sr => sr.Id);

            var serviceReportDuplicate = ServiceReportCreateAndAssert.CreateNewServiceReportForTest();
            Assert.DoesNotThrow(() => _sqlServiceReportRepository.Add(serviceReportDuplicate));

            var addedDuplicate = _sqlServiceReportRepository.GetAll().FirstOrDefault(sr => sr.Id != serviceReport.Id);

            Assert.NotNull(addedDuplicate);
            Assert.That(addedDuplicate.Id, Is.EqualTo(oldMaxId + 1));
        }

        [Test]
        public void Add_ThrowsException_WhenAddNull()
        {
            Assert.Throws<NullReferenceException>(() => _sqlServiceReportRepository.Add(null));
        }

        [Test]
        public void Add_AndGetAll_AddsFewServiceReports_ReturnsAllAddedServiceReports()
        {
            var reportOne = ServiceReportCreateAndAssert.CreateNewServiceReportForTest();
            reportOne.Description = "Report One";
            _sqlServiceReportRepository.Add(reportOne);

            var reportTwo = ServiceReportCreateAndAssert.CreateNewServiceReportForTest();
            reportTwo.Id = 2;
            reportTwo.Description = "Report Two";
            _sqlServiceReportRepository.Add(reportTwo);

            var result = _sqlServiceReportRepository.GetAll().OrderBy(sr => sr.Id).ToArray();

            Assert.That(result.Length, Is.EqualTo(2));
            ServiceReportCreateAndAssert.DefaultServiceReportAssert(result[0], "Report One", 1);
            ServiceReportCreateAndAssert.DefaultServiceReportAssert(result[1], "Report Two", 2);
        }

        [Test]
        public void Add_AndGetAll_AddsServiceReport_ReturnsAddedServiceReport()
        {
            var serviceReport = ServiceReportCreateAndAssert.CreateNewServiceReportForTest();
            serviceReport.Description = "Test GetAll ServiceReport";
            _sqlServiceReportRepository.Add(serviceReport);

            var result = _sqlServiceReportRepository.GetAll();

            Assert.That(result.Count, Is.EqualTo(1));
            ServiceReportCreateAndAssert.DefaultServiceReportAssert(result.First(), "Test GetAll ServiceReport");
        }

        [Test]
        public void GetAll_ReturnsEmptyList_WhenNoData()
        {
            var result = _sqlServiceReportRepository.GetAll();

            Assert.IsEmpty(result);
        }

        [Test]
        public void Get_ReturnsNull_WhenNoData()
        {
            var fetchedServiceReport = _sqlServiceReportRepository.Get(999);

            Assert.IsNull(fetchedServiceReport);
        }

        [Test]
        public void Get_ReturnsNull_ForNonexistentServiceReport()
        {
            var serviceReport = ServiceReportCreateAndAssert.CreateNewServiceReportForTest();
            _sqlServiceReportRepository.Add(serviceReport);

            var fetchedServiceReport = _sqlServiceReportRepository.Get(999);

            Assert.IsNull(fetchedServiceReport);
        }

        [Test]
        public void Get_ReturnsCorrectServiceReport()
        {
            var serviceReport = ServiceReportCreateAndAssert.CreateNewServiceReportForTest();
            _sqlServiceReportRepository.Add(serviceReport);

            var fetchedServiceReport = _sqlServiceReportRepository.Get(1);

            ServiceReportCreateAndAssert.DefaultServiceReportAssert(fetchedServiceReport);
        }

        [Test]
        public void Update_DoesNotThrowException_WhenNoData()
        {
            var updatedServiceReport = new ServiceReport { Id = 1, Description = "Updated Report" };

            Assert.DoesNotThrow(() => _sqlServiceReportRepository.Update(updatedServiceReport));
        }

        [Test]
        public void Update_DoesNotThrowException_WhenNoSuchId()
        {
            var serviceReport = ServiceReportCreateAndAssert.CreateNewServiceReportForTest();
            _sqlServiceReportRepository.Add(serviceReport);
            var updatedServiceReport = new ServiceReport { Id = 999, Description = "Updated Report" };

            Assert.DoesNotThrow(() => _sqlServiceReportRepository.Update(updatedServiceReport));
        }

        [Test]
        public void Update_UpdatesServiceReport()
        {
            var serviceReport = ServiceReportCreateAndAssert.CreateNewServiceReportForTest();
            _sqlServiceReportRepository.Add(serviceReport);
            var updatedServiceReport = ServiceReportCreateAndAssert.CreateNewServiceReportForTest();
            updatedServiceReport.Description = "Updated Report";
            _sqlServiceReportRepository.Update(updatedServiceReport);

            var fetchedServiceReport = _sqlServiceReportRepository.Get(1);

            ServiceReportCreateAndAssert.DefaultServiceReportAssert(fetchedServiceReport, "Updated Report");
        }

        [Test]
        public void Delete_DoesNotThrowException_WhenNoData()
        {
            Assert.DoesNotThrow(() => _sqlServiceReportRepository.Delete(1));
        }

        [Test]
        public void Delete_DoesNotThrowException_WhenNoSuchId()
        {
            var serviceReport = ServiceReportCreateAndAssert.CreateNewServiceReportForTest();
            _sqlServiceReportRepository.Add(serviceReport);

            Assert.DoesNotThrow(() => _sqlServiceReportRepository.Delete(999));
        }

        [Test]
        public void Delete_RemovesServiceReport()
        {
            var serviceReport = ServiceReportCreateAndAssert.CreateNewServiceReportForTest();
            _sqlServiceReportRepository.Add(serviceReport);

            _sqlServiceReportRepository.Delete(1);

            var result = _sqlServiceReportRepository.GetAll();

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

                string createServiceReportsTable = @"CREATE TABLE ServiceReports (
                                                       Id INT PRIMARY KEY IDENTITY,
                                                       Description NVARCHAR(255),
                                                       StartedDate DATETIME,
                                                       FinishedDate DATETIME,
                                                       AdditionalCost FLOAT,
                                                       IsStarted BIT,
                                                       IsFinished BIT,
                                                       PlannedCompletionDays INT,
                                                       WorkerId INT NULL,
                                                       ServicedCarId INT,
                                                       EmployeeReport NVARCHAR(255),
                                                       FOREIGN KEY (WorkerId) REFERENCES Employees(UserId),
                                                       FOREIGN KEY (ServicedCarId) REFERENCES Cars(Id)
                                                   );";

                using (var command = new SqlCommand(createServiceReportsTable, connection))
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

                string dropServiceReportsTable = "DROP TABLE IF EXISTS ServiceReports; DROP TABLE IF EXISTS Cars; " +
                                                 "DROP TABLE IF EXISTS Employees; DROP TABLE IF EXISTS Users;";

                using (var command = new SqlCommand(dropServiceReportsTable, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        private void AddNecessaryData()
        {
            _sqlEmployeeRepository.Add(EmployeeCreateAndAssert.CreateNewEmployeeForTest());

            _sqlCarRepository.Add(CarCreateAndAssert.CreateNewCarForTest());
            _sqlCarRepository.Add(CarCreateAndAssert.CreateNewCarForTest());
        }

    }
}