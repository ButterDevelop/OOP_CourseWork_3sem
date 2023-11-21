using DB_CourseWork.DbRepositories.Mongo;
using DB_CourseWork.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using UnitTests.ObjectsCreatesAndAsserts;

namespace UnitTests.Mongo
{
    [TestFixture]
    public class MongoAdminRepositoryTests
    {
        private MongoAdminRepository _mongoAdminRepository;
        private IMongoCollection<Admin> _adminCollection;

        [SetUp]
        public void Setup()
        {
            var builder = new ConfigurationBuilder()
                              .SetBasePath(Directory.GetCurrentDirectory())
                              .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            IConfiguration _configuration = builder.Build();

            string? mongoConnectionString = _configuration["ConnectionStrings:MongoConnectionString"],
                    mongoTestDatabaseName = _configuration["ConnectionStrings:MongoTestDatabaseName"],
                    mongoTableName        = _configuration["MongoTableNames:MONGO_ADMIN_PATH"];

            // Подключение к тестовой базе данных MongoDB
            var client = new MongoClient(mongoConnectionString);
            var database = client.GetDatabase(mongoTestDatabaseName);

            // Получаем доступ к коллекции и очищаем её перед каждым тестом
            _adminCollection = database.GetCollection<Admin>(mongoTableName);
            _adminCollection.DeleteMany(FilterDefinition<Admin>.Empty);

            _mongoAdminRepository = new MongoAdminRepository(mongoConnectionString, mongoTestDatabaseName);
        }

        [Test]
        public void Add_DoesNotThrowException_AndChangesId_WhenDuplicate()
        {
            var admin = AdminCreateAndAssert.CreateNewAdminForTest();
            _mongoAdminRepository.Add(admin);

            int oldMaxId = _mongoAdminRepository.GetAll().Max(a => a.Id);

            var adminDuplicate = AdminCreateAndAssert.CreateNewAdminForTest();
            Assert.DoesNotThrow(() => _mongoAdminRepository.Add(adminDuplicate));

            var addedDuplicate = _mongoAdminRepository.GetAll().FirstOrDefault(a => a.Id != admin.Id);

            Assert.NotNull(addedDuplicate);
            Assert.That(addedDuplicate.Id, Is.EqualTo(oldMaxId + 1));
        }

        [Test]
        public void Add_ThrowsException_WhenAddNull()
        {
            Assert.Throws<NullReferenceException>(() => _mongoAdminRepository.Add(null));
        }

        [Test]
        public void Add_AndGetAll_AddsFewAdmins_ReturnsAllAddedAdmins()
        {
            var adminOne = AdminCreateAndAssert.CreateNewAdminForTest();
            adminOne.FullName = "Test Admin One";
            _mongoAdminRepository.Add(adminOne);

            var adminTwo = AdminCreateAndAssert.CreateNewAdminForTest();
            adminTwo.FullName = "Test Admin Two";
            _mongoAdminRepository.Add(adminTwo);

            var result = _mongoAdminRepository.GetAll().OrderBy(a => a.Id).ToArray();

            Assert.That(result.Length, Is.EqualTo(2));
            AdminCreateAndAssert.DefaultAdminAssert(result[0], "Test Admin One", 1);
            AdminCreateAndAssert.DefaultAdminAssert(result[1], "Test Admin Two", 2);
        }

        [Test]
        public void Add_AndGetAll_AddsAdmin_ReturnsAddedAdmin()
        {
            var admin = AdminCreateAndAssert.CreateNewAdminForTest();
            admin.FullName = "Test GetAll Admin";
            _mongoAdminRepository.Add(admin);

            var result = _mongoAdminRepository.GetAll();

            Assert.That(result.Count, Is.EqualTo(1));
            AdminCreateAndAssert.DefaultAdminAssert(result.First(), "Test GetAll Admin");
        }

        [Test]
        public void GetAll_ReturnsEmptyList_WhenNoData()
        {
            var result = _mongoAdminRepository.GetAll();

            Assert.IsEmpty(result);
        }

        [Test]
        public void Get_ReturnsNull_WhenNoData()
        {
            var fetchedAdmin = _mongoAdminRepository.Get(999);

            Assert.IsNull(fetchedAdmin);
        }

        [Test]
        public void Get_ReturnsNull_ForNonexistentAdmin()
        {
            var admin = AdminCreateAndAssert.CreateNewAdminForTest();
            _mongoAdminRepository.Add(admin);

            var fetchedAdmin = _mongoAdminRepository.Get(999);

            Assert.IsNull(fetchedAdmin);
        }

        [Test]
        public void Get_ReturnsCorrectAdmin()
        {
            var admin = AdminCreateAndAssert.CreateNewAdminForTest();
            _mongoAdminRepository.Add(admin);

            var fetchedAdmin = _mongoAdminRepository.Get(1);

            AdminCreateAndAssert.DefaultAdminAssert(fetchedAdmin);
        }

        [Test]
        public void Update_DoesNotThrowException_WhenNoData()
        {
            var updatedAdmin = new Admin { Id = 1, FullName = "Updated Admin" };

            Assert.DoesNotThrow(() => _mongoAdminRepository.Update(updatedAdmin));
        }

        [Test]
        public void Update_DoesNotThrowException_WhenNoSuchId()
        {
            var admin = AdminCreateAndAssert.CreateNewAdminForTest();
            _mongoAdminRepository.Add(admin);
            var updatedAdmin = new Admin { Id = 999, FullName = "Updated Admin" };

            Assert.DoesNotThrow(() => _mongoAdminRepository.Update(updatedAdmin));
        }

        [Test]
        public void Update_UpdatesAdmin()
        {
            var admin = AdminCreateAndAssert.CreateNewAdminForTest();
            _mongoAdminRepository.Add(admin);
            var updatedAdmin = AdminCreateAndAssert.CreateNewAdminForTest();
            updatedAdmin.FullName = "Updated Admin";
            _mongoAdminRepository.Update(updatedAdmin);

            var fetchedAdmin = _mongoAdminRepository.Get(1);

            AdminCreateAndAssert.DefaultAdminAssert(fetchedAdmin, "Updated Admin");
        }

        [Test]
        public void Delete_DoesNotThrowException_WhenNoData()
        {
            Assert.DoesNotThrow(() => _mongoAdminRepository.Delete(1));
        }

        [Test]
        public void Delete_DoesNotThrowException_WhenNoSuchId()
        {
            var admin = AdminCreateAndAssert.CreateNewAdminForTest();
            _mongoAdminRepository.Add(admin);

            Assert.DoesNotThrow(() => _mongoAdminRepository.Delete(999));
        }

        [Test]
        public void Delete_RemovesAdmin()
        {
            var admin = new Admin { Id = 1, FullName = "Test Admin" };
            _mongoAdminRepository.Add(admin);

            _mongoAdminRepository.Delete(1);

            var result = _mongoAdminRepository.GetAll();

            Assert.IsEmpty(result);
        }

        [TearDown]
        public void TearDown()
        {
            // Очистка коллекции после каждого теста
            _adminCollection.DeleteMany(FilterDefinition<Admin>.Empty);
        }
    }
}
