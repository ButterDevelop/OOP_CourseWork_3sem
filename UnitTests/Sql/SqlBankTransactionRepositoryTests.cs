using DB_CourseWork.Models;
using Microsoft.Extensions.Configuration;
using DB_CourseWork.DbRepositories.Sql;
using System.Data.SqlClient;
using UnitTests.ObjectsCreatesAndAsserts;

namespace UnitTests.Sql
{
    [TestFixture]
    public class SqlBankTransactionRepositoryTests
    {
        private SqlClientRepository          _sqlClientRepository;
        private SqlBankTransactionRepository _sqlBankTransactionRepository;
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
            _sqlBankTransactionRepository = new SqlBankTransactionRepository(_sqlConnectionString);

            AddNecessaryData();
        }

        [Test]
        public void Add_DoesNotThrowException_AndChangesId_WhenDuplicate()
        {
            var transaction = BankTransactionCreateAndAssert.CreateNewBankTransactionForTest();
            _sqlBankTransactionRepository.Add(transaction);

            int oldMaxId = _sqlBankTransactionRepository.GetAll().Max(t => t.Id);

            var transactionDuplicate = BankTransactionCreateAndAssert.CreateNewBankTransactionForTest();
            Assert.DoesNotThrow(() => _sqlBankTransactionRepository.Add(transactionDuplicate));

            var addedDuplicate = _sqlBankTransactionRepository.GetAll().FirstOrDefault(t => t.Id != transaction.Id);

            Assert.NotNull(addedDuplicate);
            Assert.That(addedDuplicate.Id, Is.EqualTo(oldMaxId + 1));
        }

        [Test]
        public void Add_ThrowsException_WhenAddNull()
        {
            Assert.Throws<NullReferenceException>(() => _sqlBankTransactionRepository.Add(null));
        }

        [Test]
        public void Add_AndGetAll_AddsFewTransactions_ReturnsAllAddedTransactions()
        {
            var transactionOne = BankTransactionCreateAndAssert.CreateNewBankTransactionForTest();
            transactionOne.TotalAmount = 1000;
            _sqlBankTransactionRepository.Add(transactionOne);

            var transactionTwo = BankTransactionCreateAndAssert.CreateNewBankTransactionForTest();
            transactionTwo.TotalAmount = 2000;
            _sqlBankTransactionRepository.Add(transactionTwo);

            var result = _sqlBankTransactionRepository.GetAll().OrderBy(t => t.Id).ToArray();

            Assert.That(result.Length, Is.EqualTo(2));
            BankTransactionCreateAndAssert.DefaultBankTransactionAssert(result[0], 1000, 1);
            BankTransactionCreateAndAssert.DefaultBankTransactionAssert(result[1], 2000, 2);
        }

        [Test]
        public void Add_AndGetAll_AddsTransaction_ReturnsAddedTransaction()
        {
            var transaction = BankTransactionCreateAndAssert.CreateNewBankTransactionForTest();
            transaction.TotalAmount = 2000;
            _sqlBankTransactionRepository.Add(transaction);

            var result = _sqlBankTransactionRepository.GetAll();

            Assert.That(result.Count, Is.EqualTo(1));
            BankTransactionCreateAndAssert.DefaultBankTransactionAssert(result.First(), 2000);
        }

        [Test]
        public void GetAll_ReturnsEmptyList_WhenNoData()
        {
            var result = _sqlBankTransactionRepository.GetAll();

            Assert.IsEmpty(result);
        }

        [Test]
        public void Get_ReturnsNull_WhenNoData()
        {
            var fetchedTransaction = _sqlBankTransactionRepository.Get(999);

            Assert.IsNull(fetchedTransaction);
        }

        [Test]
        public void Get_ReturnsNull_ForNonexistentTransaction()
        {
            var transaction = BankTransactionCreateAndAssert.CreateNewBankTransactionForTest();
            _sqlBankTransactionRepository.Add(transaction);

            var fetchedTransaction = _sqlBankTransactionRepository.Get(999);

            Assert.IsNull(fetchedTransaction);
        }

        [Test]
        public void Get_ReturnsCorrectTransaction()
        {
            var transaction = BankTransactionCreateAndAssert.CreateNewBankTransactionForTest();
            _sqlBankTransactionRepository.Add(transaction);

            var fetchedTransaction = _sqlBankTransactionRepository.Get(1);

            BankTransactionCreateAndAssert.DefaultBankTransactionAssert(fetchedTransaction, 1000);
        }

        [Test]
        public void Update_DoesNotThrowException_WhenNoData()
        {
            var updatedTransaction = new BankTransaction { Id = 1, TotalAmount = 1500 };

            Assert.DoesNotThrow(() => _sqlBankTransactionRepository.Update(updatedTransaction));
        }

        [Test]
        public void Update_DoesNotThrowException_WhenNoSuchId()
        {
            var transaction = BankTransactionCreateAndAssert.CreateNewBankTransactionForTest();
            _sqlBankTransactionRepository.Add(transaction);
            var updatedTransaction = new BankTransaction { Id = 999, TotalAmount = 1500 };

            Assert.DoesNotThrow(() => _sqlBankTransactionRepository.Update(updatedTransaction));
        }

        [Test]
        public void Update_UpdatesTransaction()
        {
            var transaction = BankTransactionCreateAndAssert.CreateNewBankTransactionForTest();
            _sqlBankTransactionRepository.Add(transaction);
            var updatedTransaction = BankTransactionCreateAndAssert.CreateNewBankTransactionForTest();
            updatedTransaction.TotalAmount = 1500;
            _sqlBankTransactionRepository.Update(updatedTransaction);

            var fetchedTransaction = _sqlBankTransactionRepository.Get(1);

            BankTransactionCreateAndAssert.DefaultBankTransactionAssert(fetchedTransaction, 1500);
        }

        [Test]
        public void Delete_DoesNotThrowException_WhenNoData()
        {
            Assert.DoesNotThrow(() => _sqlBankTransactionRepository.Delete(1));
        }

        [Test]
        public void Delete_DoesNotThrowException_WhenNoSuchId()
        {
            var transaction = BankTransactionCreateAndAssert.CreateNewBankTransactionForTest();
            _sqlBankTransactionRepository.Add(transaction);

            Assert.DoesNotThrow(() => _sqlBankTransactionRepository.Delete(999));
        }

        [Test]
        public void Delete_RemovesTransaction()
        {
            var transaction = new BankTransaction { Id = 1, TotalAmount = 1000 };
            _sqlBankTransactionRepository.Add(transaction);

            _sqlBankTransactionRepository.Delete(1);

            var result = _sqlBankTransactionRepository.GetAll();

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

                string createTransactionsTable = @"CREATE TABLE BankTransactions (
                                                       Id INT PRIMARY KEY IDENTITY,
                                                       FromCardNumberOrBankAccountNumber NVARCHAR(50),
                                                       ToCardNumberOrBankAccountNumber NVARCHAR(50),
                                                       UserId INT NULL,
                                                       CreatedTime DATETIME NOT NULL,
                                                       PayedTime DATETIME,
                                                       CancelledTime DATETIME,
                                                       TotalAmount FLOAT NOT NULL,
                                                       TotalTries INT NOT NULL,
                                                       IsFinished BIT NOT NULL,
                                                       IsCancelled BIT NOT NULL,
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

                using (var command = new SqlCommand(createTransactionsTable, connection))
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

                string dropTransactionsTable = "DROP TABLE IF EXISTS BankTransactions; DROP TABLE IF EXISTS Clients; DROP TABLE IF EXISTS Users;";

                using (var command = new SqlCommand(dropTransactionsTable, connection))
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
