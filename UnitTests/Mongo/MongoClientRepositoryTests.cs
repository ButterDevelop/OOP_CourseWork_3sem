using DB_CourseWork.DbRepositories.Mongo;
using DB_CourseWork.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using UnitTests.ObjectsCreatesAndAsserts;

namespace UnitTests.Mongo
{
    [TestFixture]
    public class MongoClientRepositoryTests
    {
        private MongoClientRepository _mongoClientRepository;
        private IMongoCollection<Client> _clientCollection;

        [SetUp]
        public void Setup()
        {
            var builder = new ConfigurationBuilder()
                              .SetBasePath(Directory.GetCurrentDirectory())
                              .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            IConfiguration configuration = builder.Build();

            string? mongoConnectionString = configuration["ConnectionStrings:MongoConnectionString"],
                    mongoTestDatabaseName = configuration["ConnectionStrings:MongoTestDatabaseName"],
                    mongoTableName = configuration["MongoTableNames:MONGO_CLIENT_PATH"];

            var client = new MongoClient(mongoConnectionString);
            var database = client.GetDatabase(mongoTestDatabaseName);

            _clientCollection = database.GetCollection<Client>(mongoTableName);
            _clientCollection.DeleteMany(FilterDefinition<Client>.Empty);

            _mongoClientRepository = new MongoClientRepository(mongoConnectionString, mongoTestDatabaseName);
        }

        [Test]
        public void Add_DoesNotThrowException_AndChangesId_WhenDuplicate()
        {
            var client = ClientCreateAndAssert.CreateNewClientForTest();
            _mongoClientRepository.Add(client);

            int oldMaxId = _mongoClientRepository.GetAll().Max(c => c.Id);

            var clientDuplicate = ClientCreateAndAssert.CreateNewClientForTest();
            Assert.DoesNotThrow(() => _mongoClientRepository.Add(clientDuplicate));

            var addedDuplicate = _mongoClientRepository.GetAll().FirstOrDefault(c => c.Id != client.Id);

            Assert.NotNull(addedDuplicate);
            Assert.That(addedDuplicate.Id, Is.EqualTo(oldMaxId + 1));
        }

        [Test]
        public void Add_ThrowsException_WhenAddNull()
        {
            Assert.Throws<NullReferenceException>(() => _mongoClientRepository.Add(null));
        }

        [Test]
        public void Add_AndGetAll_AddsFewClients_ReturnsAllAddedClients()
        {
            var clientOne = ClientCreateAndAssert.CreateNewClientForTest();
            clientOne.FullName = "Test Client One";
            _mongoClientRepository.Add(clientOne);

            var clientTwo = ClientCreateAndAssert.CreateNewClientForTest();
            clientTwo.FullName = "Test Client Two";
            _mongoClientRepository.Add(clientTwo);

            var result = _mongoClientRepository.GetAll().OrderBy(c => c.Id).ToArray();

            Assert.That(result.Length, Is.EqualTo(2));
            ClientCreateAndAssert.DefaultClientAssert(result[0], "Test Client One", 1);
            ClientCreateAndAssert.DefaultClientAssert(result[1], "Test Client Two", 2);
        }

        [Test]
        public void Add_AndGetAll_AddsClient_ReturnsAddedClient()
        {
            var client = ClientCreateAndAssert.CreateNewClientForTest();
            client.FullName = "Test GetAll Client";
            _mongoClientRepository.Add(client);

            var result = _mongoClientRepository.GetAll();

            Assert.That(result.Count, Is.EqualTo(1));
            ClientCreateAndAssert.DefaultClientAssert(result.First(), "Test GetAll Client");
        }

        [Test]
        public void GetAll_ReturnsEmptyList_WhenNoData()
        {
            var result = _mongoClientRepository.GetAll();

            Assert.IsEmpty(result);
        }

        [Test]
        public void Get_ReturnsNull_WhenNoData()
        {
            var fetchedClient = _mongoClientRepository.Get(999);

            Assert.IsNull(fetchedClient);
        }

        [Test]
        public void Get_ReturnsNull_ForNonexistentClient()
        {
            var client = ClientCreateAndAssert.CreateNewClientForTest();
            _mongoClientRepository.Add(client);

            var fetchedClient = _mongoClientRepository.Get(999);

            Assert.IsNull(fetchedClient);
        }

        [Test]
        public void Get_ReturnsCorrectClient()
        {
            var client = ClientCreateAndAssert.CreateNewClientForTest();
            _mongoClientRepository.Add(client);

            var fetchedClient = _mongoClientRepository.Get(1);

            ClientCreateAndAssert.DefaultClientAssert(fetchedClient);
        }

        [Test]
        public void Update_DoesNotThrowException_WhenNoData()
        {
            var updatedClient = new Client { Id = 1, FullName = "Updated Client" };

            Assert.DoesNotThrow(() => _mongoClientRepository.Update(updatedClient));
        }

        [Test]
        public void Update_DoesNotThrowException_WhenNoSuchId()
        {
            var client = ClientCreateAndAssert.CreateNewClientForTest();
            _mongoClientRepository.Add(client);
            var updatedClient = new Client { Id = 999, FullName = "Updated Client" };

            Assert.DoesNotThrow(() => _mongoClientRepository.Update(updatedClient));
        }

        [Test]
        public void Update_UpdatesClient()
        {
            var client = ClientCreateAndAssert.CreateNewClientForTest();
            _mongoClientRepository.Add(client);
            var updatedClient = ClientCreateAndAssert.CreateNewClientForTest();
            updatedClient.FullName = "Updated Client";
            _mongoClientRepository.Update(updatedClient);

            var fetchedClient = _mongoClientRepository.Get(1);

            ClientCreateAndAssert.DefaultClientAssert(fetchedClient, "Updated Client");
        }

        [Test]
        public void Delete_DoesNotThrowException_WhenNoData()
        {
            Assert.DoesNotThrow(() => _mongoClientRepository.Delete(1));
        }

        [Test]
        public void Delete_DoesNotThrowException_WhenNoSuchId()
        {
            var client = ClientCreateAndAssert.CreateNewClientForTest();
            _mongoClientRepository.Add(client);

            Assert.DoesNotThrow(() => _mongoClientRepository.Delete(999));
        }

        [Test]
        public void Delete_RemovesClient()
        {
            var client = ClientCreateAndAssert.CreateNewClientForTest();
            _mongoClientRepository.Add(client);

            _mongoClientRepository.Delete(1);

            var result = _mongoClientRepository.GetAll();

            Assert.IsEmpty(result);
        }

        [TearDown]
        public void TearDown()
        {
            _clientCollection.DeleteMany(FilterDefinition<Client>.Empty);
        }
    }
}
