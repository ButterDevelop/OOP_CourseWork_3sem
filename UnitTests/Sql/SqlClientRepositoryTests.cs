using DB_CourseWork.DbRepositories.Sql;
using DB_CourseWork.Models;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using UnitTests.ObjectsCreatesAndAsserts;

namespace UnitTests.Sql
{
    [TestFixture]
    public class SqlClientRepositoryTests
    {
        private SqlClientRepository _sqlClientRepository;
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
        }

        [Test]
        public void Add_DoesNotThrowException_AndChangesId_WhenDuplicate()
        {
            var client = ClientCreateAndAssert.CreateNewClientForTest();
            _sqlClientRepository.Add(client);

            int oldMaxId = _sqlClientRepository.GetAll().Max(c => c.Id);

            var clientDuplicate = ClientCreateAndAssert.CreateNewClientForTest();
            Assert.DoesNotThrow(() => _sqlClientRepository.Add(clientDuplicate));

            var addedDuplicate = _sqlClientRepository.GetAll().FirstOrDefault(c => c.Id != client.Id);

            Assert.NotNull(addedDuplicate);
            Assert.That(addedDuplicate.Id, Is.EqualTo(oldMaxId + 1));
        }

        [Test]
        public void Add_ThrowsException_WhenAddNull()
        {
            Assert.Throws<NullReferenceException>(() => _sqlClientRepository.Add(null));
        }

        [Test]
        public void Add_AndGetAll_AddsFewClients_ReturnsAllAddedClients()
        {
            var clientOne = ClientCreateAndAssert.CreateNewClientForTest();
            clientOne.FullName = "Test Client One";
            _sqlClientRepository.Add(clientOne);

            var clientTwo = ClientCreateAndAssert.CreateNewClientForTest();
            clientTwo.FullName = "Test Client Two";
            _sqlClientRepository.Add(clientTwo);

            var result = _sqlClientRepository.GetAll().OrderBy(c => c.Id).ToArray();

            Assert.That(result.Length, Is.EqualTo(2));
            ClientCreateAndAssert.DefaultClientAssert(result[0], "Test Client One", 1);
            ClientCreateAndAssert.DefaultClientAssert(result[1], "Test Client Two", 2);
        }

        [Test]
        public void Add_AndGetAll_AddsClient_ReturnsAddedClient()
        {
            var client = ClientCreateAndAssert.CreateNewClientForTest();
            client.FullName = "Test GetAll Client";
            _sqlClientRepository.Add(client);

            var result = _sqlClientRepository.GetAll();

            Assert.That(result.Count, Is.EqualTo(1));
            ClientCreateAndAssert.DefaultClientAssert(result.First(), "Test GetAll Client");
        }

        [Test]
        public void GetAll_ReturnsEmptyList_WhenNoData()
        {
            var result = _sqlClientRepository.GetAll();

            Assert.IsEmpty(result);
        }

        [Test]
        public void Get_ReturnsNull_WhenNoData()
        {
            var fetchedClient = _sqlClientRepository.Get(999);

            Assert.IsNull(fetchedClient);
        }

        [Test]
        public void Get_ReturnsNull_ForNonexistentClient()
        {
            var client = ClientCreateAndAssert.CreateNewClientForTest();
            _sqlClientRepository.Add(client);

            var fetchedClient = _sqlClientRepository.Get(999);

            Assert.IsNull(fetchedClient);
        }

        [Test]
        public void Get_ReturnsCorrectClient()
        {
            var client = ClientCreateAndAssert.CreateNewClientForTest();
            _sqlClientRepository.Add(client);

            var fetchedClient = _sqlClientRepository.Get(1);

            ClientCreateAndAssert.DefaultClientAssert(fetchedClient);
        }

        [Test]
        public void Update_DoesNotThrowException_WhenNoData()
        {
            var updatedClient = new Client { Id = 1, FullName = "Updated Client" };

            Assert.DoesNotThrow(() => _sqlClientRepository.Update(updatedClient));
        }

        [Test]
        public void Update_DoesNotThrowException_WhenNoSuchId()
        {
            var client = ClientCreateAndAssert.CreateNewClientForTest();
            _sqlClientRepository.Add(client);
            var updatedClient = new Client { Id = 999, FullName = "Updated Client" };

            Assert.DoesNotThrow(() => _sqlClientRepository.Update(updatedClient));
        }

        [Test]
        public void Update_UpdatesClient()
        {
            var client = ClientCreateAndAssert.CreateNewClientForTest();
            _sqlClientRepository.Add(client);
            var updatedClient = ClientCreateAndAssert.CreateNewClientForTest();
            updatedClient.FullName = "Updated Client";
            _sqlClientRepository.Update(updatedClient);

            var fetchedClient = _sqlClientRepository.Get(1);

            ClientCreateAndAssert.DefaultClientAssert(fetchedClient, "Updated Client");
        }

        [Test]
        public void Delete_DoesNotThrowException_WhenNoData()
        {
            Assert.DoesNotThrow(() => _sqlClientRepository.Delete(1));
        }

        [Test]
        public void Delete_DoesNotThrowException_WhenNoSuchId()
        {
            var client = ClientCreateAndAssert.CreateNewClientForTest();
            _sqlClientRepository.Add(client);

            Assert.DoesNotThrow(() => _sqlClientRepository.Delete(999));
        }

        [Test]
        public void Delete_RemovesClient()
        {
            var client = ClientCreateAndAssert.CreateNewClientForTest();
            _sqlClientRepository.Add(client);

            _sqlClientRepository.Delete(1);

            var result = _sqlClientRepository.GetAll();

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
            }
        }

        private void DestroyTestDatabase()
        {
            using (var connection = new SqlConnection(_sqlConnectionString))
            {
                connection.Open();

                string dropClientsTable = "DROP TABLE IF EXISTS Clients; DROP TABLE IF EXISTS Users;";

                using (var command = new SqlCommand(dropClientsTable, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
