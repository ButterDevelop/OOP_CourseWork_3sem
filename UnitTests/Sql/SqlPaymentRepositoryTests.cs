using DB_CourseWork.DbRepositories.Sql;
using DB_CourseWork.Models;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using UnitTests.ObjectsCreatesAndAsserts;

namespace UnitTests.Sql
{
    [TestFixture]
    public class SqlPaymentRepositoryTests
    {
        private SqlClientRepository _sqlClientRepository;
        private SqlPaymentRepository _sqlPaymentRepository;
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

            _sqlClientRepository = new SqlClientRepository(_sqlConnectionString);
            _sqlPaymentRepository = new SqlPaymentRepository(_sqlConnectionString);

            AddNecessaryData();
        }

        [Test]
        public void Add_DoesNotThrowException_AndChangesId_WhenDuplicate()
        {
            var payment = PaymentCreateAndAssert.CreateNewPaymentForTest();
            _sqlPaymentRepository.Add(payment);

            int oldMaxId = _sqlPaymentRepository.GetAll().Max(p => p.Id);

            var paymentDuplicate = PaymentCreateAndAssert.CreateNewPaymentForTest();
            Assert.DoesNotThrow(() => _sqlPaymentRepository.Add(paymentDuplicate));

            var addedDuplicate = _sqlPaymentRepository.GetAll().FirstOrDefault(p => p.Id != payment.Id);

            Assert.NotNull(addedDuplicate);
            Assert.That(addedDuplicate.Id, Is.EqualTo(oldMaxId + 1));
        }

        [Test]
        public void Add_ThrowsException_WhenAddNull()
        {
            Assert.Throws<NullReferenceException>(() => _sqlPaymentRepository.Add(null));
        }

        [Test]
        public void Add_AndGetAll_AddsFewPayments_ReturnsAllAddedPayments()
        {
            var paymentOne = PaymentCreateAndAssert.CreateNewPaymentForTest();
            paymentOne.Cost = 100.0;
            _sqlPaymentRepository.Add(paymentOne);

            var paymentTwo = PaymentCreateAndAssert.CreateNewPaymentForTest();
            paymentTwo.Id = 2;
            paymentTwo.Cost = 200.0;
            _sqlPaymentRepository.Add(paymentTwo);

            var result = _sqlPaymentRepository.GetAll().OrderBy(p => p.Id).ToArray();

            Assert.That(result.Length, Is.EqualTo(2));
            PaymentCreateAndAssert.DefaultPaymentAssert(result[0], 100.0, 1);
            PaymentCreateAndAssert.DefaultPaymentAssert(result[1], 200.0, 2);
        }

        [Test]
        public void Add_AndGetAll_AddsPayment_ReturnsAddedPayment()
        {
            var payment = PaymentCreateAndAssert.CreateNewPaymentForTest();
            payment.Cost = 150.0;
            _sqlPaymentRepository.Add(payment);

            var result = _sqlPaymentRepository.GetAll();

            Assert.That(result.Count, Is.EqualTo(1));
            PaymentCreateAndAssert.DefaultPaymentAssert(result.First(), 150.0);
        }

        [Test]
        public void GetAll_ReturnsEmptyList_WhenNoData()
        {
            var result = _sqlPaymentRepository.GetAll();

            Assert.IsEmpty(result);
        }

        [Test]
        public void Get_ReturnsNull_WhenNoData()
        {
            var fetchedPayment = _sqlPaymentRepository.Get(999);

            Assert.IsNull(fetchedPayment);
        }

        [Test]
        public void Get_ReturnsNull_ForNonexistentPayment()
        {
            var payment = PaymentCreateAndAssert.CreateNewPaymentForTest();
            _sqlPaymentRepository.Add(payment);

            var fetchedPayment = _sqlPaymentRepository.Get(999);

            Assert.IsNull(fetchedPayment);
        }

        [Test]
        public void Get_ReturnsCorrectPayment()
        {
            var payment = PaymentCreateAndAssert.CreateNewPaymentForTest();
            _sqlPaymentRepository.Add(payment);

            var fetchedPayment = _sqlPaymentRepository.Get(1);

            PaymentCreateAndAssert.DefaultPaymentAssert(fetchedPayment, 100.0);
        }

        [Test]
        public void Update_DoesNotThrowException_WhenNoData()
        {
            var updatedPayment = new Payment { Id = 1, Cost = 250.0 };

            Assert.DoesNotThrow(() => _sqlPaymentRepository.Update(updatedPayment));
        }

        [Test]
        public void Update_DoesNotThrowException_WhenNoSuchId()
        {
            var payment = PaymentCreateAndAssert.CreateNewPaymentForTest();
            _sqlPaymentRepository.Add(payment);
            var updatedPayment = new Payment { Id = 999, Cost = 350.0 };

            Assert.DoesNotThrow(() => _sqlPaymentRepository.Update(updatedPayment));
        }

        [Test]
        public void Update_UpdatesPayment()
        {
            var payment = PaymentCreateAndAssert.CreateNewPaymentForTest();
            _sqlPaymentRepository.Add(payment);
            var updatedPayment = PaymentCreateAndAssert.CreateNewPaymentForTest();
            updatedPayment.Cost = 250.0;
            _sqlPaymentRepository.Update(updatedPayment);

            var fetchedPayment = _sqlPaymentRepository.Get(1);

            PaymentCreateAndAssert.DefaultPaymentAssert(fetchedPayment, 250.0);
        }

        [Test]
        public void Delete_DoesNotThrowException_WhenNoData()
        {
            Assert.DoesNotThrow(() => _sqlPaymentRepository.Delete(1));
        }

        [Test]
        public void Delete_DoesNotThrowException_WhenNoSuchId()
        {
            var payment = PaymentCreateAndAssert.CreateNewPaymentForTest();
            _sqlPaymentRepository.Add(payment);

            Assert.DoesNotThrow(() => _sqlPaymentRepository.Delete(999));
        }

        [Test]
        public void Delete_RemovesPayment()
        {
            var payment = PaymentCreateAndAssert.CreateNewPaymentForTest();
            _sqlPaymentRepository.Add(payment);

            _sqlPaymentRepository.Delete(1);

            var result = _sqlPaymentRepository.GetAll();

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

                string createClientsTable = @"CREATE TABLE Clients (
                                                UserId INT PRIMARY KEY,
                                                DriverLicense NVARCHAR(50),
                                                Passport NVARCHAR(50),
                                                CardNumber NVARCHAR(50),
                                                Balance FLOAT,
                                                SumRating FLOAT,
                                                OrdersCount INT,
                                                FOREIGN KEY (UserId) REFERENCES Users(Id)
                                            );";

                using (var command = new SqlCommand(createUsersTable, connection))
                {
                    command.ExecuteNonQuery();
                }

                using (var command = new SqlCommand(createClientsTable, connection))
                {
                    command.ExecuteNonQuery();
                }

                string createPaymentsTable = @"CREATE TABLE Payments (
                                                 Id INT PRIMARY KEY IDENTITY,
                                                 CreatedTime DATETIME NOT NULL,
                                                 PayedTime DATETIME,
                                                 UserId INT,
                                                 Cost FLOAT NOT NULL,
                                                 IsPayed BIT NOT NULL,
                                                 IsRefunded BIT NOT NULL,
                                                 FOREIGN KEY (UserId) REFERENCES Users(Id)
                                             );";

                using (var command = new SqlCommand(createPaymentsTable, connection))
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

                string dropPaymentsTable = "DROP TABLE IF EXISTS Payments; DROP TABLE IF EXISTS Clients; DROP TABLE IF EXISTS Users;";

                using (var command = new SqlCommand(dropPaymentsTable, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        private void AddNecessaryData()
        {
            _sqlClientRepository.Add(ClientCreateAndAssert.CreateNewClientForTest());
        }

    }
}
