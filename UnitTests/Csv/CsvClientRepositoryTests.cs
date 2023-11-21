using DB_CourseWork.DbRepositories.Csv;
using DB_CourseWork.Models;
using UnitTests.ObjectsCreatesAndAsserts;

namespace UnitTests.Csv
{
    [TestFixture]
    public class CsvClientRepositoryTests
    {
        private string _testFilePath = "testClients.csv";
        private CsvClientRepository _csvClientRepository;

        [SetUp]
        public void Setup()
        {
            if (File.Exists(_testFilePath))
            {
                File.Delete(_testFilePath);
            }
            _csvClientRepository = new CsvClientRepository(_testFilePath);
        }

        [Test]
        public void Add_DoesNotThrowException_AndChangesId_WhenDuplicate()
        {
            var client = ClientCreateAndAssert.CreateNewClientForTest();
            _csvClientRepository.Add(client);

            int oldMaxId = _csvClientRepository.GetAll().Max(c => c.Id);

            var clientDuplicate = ClientCreateAndAssert.CreateNewClientForTest();
            Assert.DoesNotThrow(() => _csvClientRepository.Add(clientDuplicate));

            var addedDuplicate = _csvClientRepository.GetAll().FirstOrDefault(c => c.Id != client.Id);

            Assert.NotNull(addedDuplicate);
            Assert.That(addedDuplicate.Id, Is.EqualTo(oldMaxId + 1));
        }

        [Test]
        public void Add_ThrowsException_WhenAddNull()
        {
            Assert.Throws<NullReferenceException>(() => _csvClientRepository.Add(null));
        }

        [Test]
        public void Add_AndGetAll_AddsFewClients_ReturnsAllAddedClients()
        {
            var clientOne = ClientCreateAndAssert.CreateNewClientForTest();
            clientOne.FullName = "Test Client One";
            _csvClientRepository.Add(clientOne);

            var clientTwo = ClientCreateAndAssert.CreateNewClientForTest();
            clientTwo.FullName = "Test Client Two";
            _csvClientRepository.Add(clientTwo);

            var result = _csvClientRepository.GetAll().OrderBy(c => c.Id).ToArray();

            Assert.That(result.Count, Is.EqualTo(2));
            ClientCreateAndAssert.DefaultClientAssert(result[0], "Test Client One", 1);
            ClientCreateAndAssert.DefaultClientAssert(result[1], "Test Client Two", 2);
        }

        [Test]
        public void Add_AndGetAll_AddsClient_ReturnsAddedClient()
        {
            var client = ClientCreateAndAssert.CreateNewClientForTest();
            client.FullName = "Test GetAll Client";
            _csvClientRepository.Add(client);

            var result = _csvClientRepository.GetAll();

            Assert.That(result.Count, Is.EqualTo(1));
            ClientCreateAndAssert.DefaultClientAssert(result.First(), "Test GetAll Client");
        }

        [Test]
        public void GetAll_ReturnsEmptyList_WhenNoData()
        {
            var result = _csvClientRepository.GetAll();

            Assert.IsEmpty(result);
        }

        [Test]
        public void Get_ReturnsNull_WhenNoData()
        {
            var fetchedClient = _csvClientRepository.Get(999);

            Assert.IsNull(fetchedClient);
        }

        [Test]
        public void Get_ReturnsNull_ForNonexistentClient()
        {
            var client = ClientCreateAndAssert.CreateNewClientForTest();
            _csvClientRepository.Add(client);

            var fetchedClient = _csvClientRepository.Get(999);

            Assert.IsNull(fetchedClient);
        }

        [Test]
        public void Get_ReturnsCorrectClient()
        {
            var client = ClientCreateAndAssert.CreateNewClientForTest();
            _csvClientRepository.Add(client);

            var fetchedClient = _csvClientRepository.Get(1);

            ClientCreateAndAssert.DefaultClientAssert(fetchedClient);
        }

        [Test]
        public void Update_DoesNotThrowException_WhenNoData()
        {
            var updatedClient = new Client { Id = 1, FullName = "Updated Client" };

            Assert.DoesNotThrow(() => _csvClientRepository.Update(updatedClient));
        }

        [Test]
        public void Update_DoesNotThrowException_WhenNoSuchId()
        {
            var client = ClientCreateAndAssert.CreateNewClientForTest();
            _csvClientRepository.Add(client);
            var updatedClient = new Client { Id = 999, FullName = "Updated Client" };

            Assert.DoesNotThrow(() => _csvClientRepository.Update(updatedClient));
        }

        [Test]
        public void Update_UpdatesClient()
        {
            var client = ClientCreateAndAssert.CreateNewClientForTest();
            _csvClientRepository.Add(client);
            var updatedClient = ClientCreateAndAssert.CreateNewClientForTest();
            updatedClient.FullName = "Updated Client";
            _csvClientRepository.Update(updatedClient);

            var fetchedClient = _csvClientRepository.Get(1);

            ClientCreateAndAssert.DefaultClientAssert(fetchedClient, "Updated Client");
        }

        [Test]
        public void Delete_DoesNotThrowException_WhenNoData()
        {
            Assert.DoesNotThrow(() => _csvClientRepository.Delete(1));
        }

        [Test]
        public void Delete_DoesNotThrowException_WhenNoSuchId()
        {
            var client = ClientCreateAndAssert.CreateNewClientForTest();
            _csvClientRepository.Add(client);

            Assert.DoesNotThrow(() => _csvClientRepository.Delete(999));
        }

        [Test]
        public void Delete_RemovesClient()
        {
            var client = ClientCreateAndAssert.CreateNewClientForTest();
            _csvClientRepository.Add(client);

            _csvClientRepository.Delete(1);

            var result = _csvClientRepository.GetAll();

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
