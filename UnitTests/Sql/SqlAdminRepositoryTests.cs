using DB_CourseWork.DbRepositories.Sql;
using DB_CourseWork.Models;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using UnitTests.ObjectsCreatesAndAsserts;

namespace UnitTests.Sql
{
    [TestFixture]
    public class SqlAdminRepositoryTests
    {
        private string? _sqlConnectionString;
        private SqlAdminRepository _sqlAdminRepository;

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

            _sqlAdminRepository = new SqlAdminRepository(_sqlConnectionString);
        }

        [Test]
        public void Add_DoesNotThrowException_AndChangesId_WhenDuplicate()
        {
            var admin = AdminCreateAndAssert.CreateNewAdminForTest();
            _sqlAdminRepository.Add(admin);

            int oldMaxId = _sqlAdminRepository.GetAll().Max(a => a.Id);

            var adminDuplicate = AdminCreateAndAssert.CreateNewAdminForTest();
            Assert.DoesNotThrow(() => _sqlAdminRepository.Add(adminDuplicate));

            var addedDuplicate = _sqlAdminRepository.GetAll().FirstOrDefault(a => a.Id != admin.Id);

            Assert.NotNull(addedDuplicate);
            Assert.That(addedDuplicate.Id, Is.EqualTo(oldMaxId + 1));
        }

        [Test]
        public void Add_ThrowsException_WhenAddNull()
        {
            Assert.Throws<NullReferenceException>(() => _sqlAdminRepository.Add(null));
        }

        [Test]
        public void Add_AndGetAll_AddsFewAdmins_ReturnsAllAddedAdmins()
        {
            var adminOne = AdminCreateAndAssert.CreateNewAdminForTest();
            adminOne.FullName = "Test Admin One";
            _sqlAdminRepository.Add(adminOne);

            var adminTwo = AdminCreateAndAssert.CreateNewAdminForTest();
            adminTwo.FullName = "Test Admin Two";
            _sqlAdminRepository.Add(adminTwo);

            var result = _sqlAdminRepository.GetAll().OrderBy(a => a.Id).ToArray();

            Assert.That(result.Length, Is.EqualTo(2));
            AdminCreateAndAssert.DefaultAdminAssert(result[0], "Test Admin One", 1);
            AdminCreateAndAssert.DefaultAdminAssert(result[1], "Test Admin Two", 2);
        }

        [Test]
        public void Add_AndGetAll_AddsAdmin_ReturnsAddedAdmin()
        {
            var admin = AdminCreateAndAssert.CreateNewAdminForTest();
            admin.FullName = "Test GetAll Admin";
            _sqlAdminRepository.Add(admin);

            var result = _sqlAdminRepository.GetAll();

            Assert.That(result.Count, Is.EqualTo(1));
            AdminCreateAndAssert.DefaultAdminAssert(result.First(), "Test GetAll Admin");
        }

        [Test]
        public void GetAll_ReturnsEmptyList_WhenNoData()
        {
            var result = _sqlAdminRepository.GetAll();

            Assert.IsEmpty(result);
        }

        [Test]
        public void Get_ReturnsNull_WhenNoData()
        {
            var fetchedAdmin = _sqlAdminRepository.Get(999);

            Assert.IsNull(fetchedAdmin);
        }

        [Test]
        public void Get_ReturnsNull_ForNonexistentAdmin()
        {
            var admin = AdminCreateAndAssert.CreateNewAdminForTest();
            _sqlAdminRepository.Add(admin);

            var fetchedAdmin = _sqlAdminRepository.Get(999);

            Assert.IsNull(fetchedAdmin);
        }

        [Test]
        public void Get_ReturnsCorrectAdmin()
        {
            var admin = AdminCreateAndAssert.CreateNewAdminForTest();
            _sqlAdminRepository.Add(admin);

            var fetchedAdmin = _sqlAdminRepository.Get(1);

            AdminCreateAndAssert.DefaultAdminAssert(fetchedAdmin);
        }

        [Test]
        public void Update_DoesNotThrowException_WhenNoData()
        {
            var updatedAdmin = new Admin { Id = 1, FullName = "Updated Admin" };

            Assert.DoesNotThrow(() => _sqlAdminRepository.Update(updatedAdmin));
        }

        [Test]
        public void Update_DoesNotThrowException_WhenNoSuchId()
        {
            var admin = AdminCreateAndAssert.CreateNewAdminForTest();
            _sqlAdminRepository.Add(admin);
            var updatedAdmin = new Admin { Id = 999, FullName = "Updated Admin" };

            Assert.DoesNotThrow(() => _sqlAdminRepository.Update(updatedAdmin));
        }

        [Test]
        public void Update_UpdatesAdmin()
        {
            var admin = AdminCreateAndAssert.CreateNewAdminForTest();
            _sqlAdminRepository.Add(admin);
            var updatedAdmin = AdminCreateAndAssert.CreateNewAdminForTest();
            updatedAdmin.FullName = "Updated Admin";
            _sqlAdminRepository.Update(updatedAdmin);

            var fetchedAdmin = _sqlAdminRepository.Get(1);

            AdminCreateAndAssert.DefaultAdminAssert(fetchedAdmin, "Updated Admin");
        }

        [Test]
        public void Delete_DoesNotThrowException_WhenNoData()
        {
            Assert.DoesNotThrow(() => _sqlAdminRepository.Delete(1));
        }

        [Test]
        public void Delete_DoesNotThrowException_WhenNoSuchId()
        {
            var admin = AdminCreateAndAssert.CreateNewAdminForTest();
            _sqlAdminRepository.Add(admin);

            Assert.DoesNotThrow(() => _sqlAdminRepository.Delete(999));
        }

        [Test]
        public void Delete_RemovesAdmin()
        {
            var admin = new Admin { Id = 1, FullName = "Test Admin" };
            _sqlAdminRepository.Add(admin);

            _sqlAdminRepository.Delete(1);

            var result = _sqlAdminRepository.GetAll();

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

                string createUsersTable = @"
                    CREATE TABLE Users (
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

                string createAdminsTable = @"
                    CREATE TABLE Admins (
                        UserId INT PRIMARY KEY,
                        TotalCarsServiced INT,
                        FOREIGN KEY (UserId) REFERENCES Users(Id)
                    );";

                using (var command = new SqlCommand(createUsersTable, connection))
                {
                    command.ExecuteNonQuery();
                }

                using (var command = new SqlCommand(createAdminsTable, connection))
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

                string dropAdminsTable = "DROP TABLE IF EXISTS Admins;";
                string dropUsersTable = "DROP TABLE IF EXISTS Users;";

                using (var command = new SqlCommand(dropAdminsTable, connection))
                {
                    command.ExecuteNonQuery();
                }

                using (var command = new SqlCommand(dropUsersTable, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
