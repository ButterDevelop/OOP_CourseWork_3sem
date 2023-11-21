using DB_CourseWork.DbRepositories.Csv;
using DB_CourseWork.Models;
using UnitTests.ObjectsCreatesAndAsserts;

namespace UnitTests.Csv
{
    [TestFixture]
    public class CsvAdminRepositoryTests
    {
        private string _testFilePath = "testAdmins.csv";
        private CsvAdminRepository _csvAdminRepository;

        [SetUp]
        public void Setup()
        {
            // ���������, ��� �������� ���� ������ ����� ������ ������
            if (File.Exists(_testFilePath))
            {
                File.Delete(_testFilePath);
            }
            _csvAdminRepository = new CsvAdminRepository(_testFilePath);
        }

        // ���� ID ��� �����, �� ����� ������� ������
        [Test]
        public void Add_DoesNotThrowException_AndChangesId_WhenDuplicate()
        {
            var admin = AdminCreateAndAssert.CreateNewAdminForTest();
            _csvAdminRepository.Add(admin);

            int oldMaxId = _csvAdminRepository.GetAll().Max(a => a.Id);

            var adminDuplicate = AdminCreateAndAssert.CreateNewAdminForTest();
            Assert.DoesNotThrow(() => _csvAdminRepository.Add(adminDuplicate));

            var addedDuplicate = _csvAdminRepository.GetAll().FirstOrDefault(a => a.Id != admin.Id);

            Assert.NotNull(addedDuplicate);
            Assert.That(addedDuplicate.Id, Is.EqualTo(oldMaxId + 1));
        }

        // ������ ��������� ���������� null ��������
        [Test]
        public void Add_ThrowsException_WhenAddNull()
        {
            Assert.Throws<NullReferenceException>(() => _csvAdminRepository.Add(null));
        }

        // ��������� Add � GetAll ������, ������ ����� ��������� ��������
        [Test]
        public void Add_AndGetAll_AddsFewAdmins_ReturnsAllAddedAdmins()
        {
            var adminOne = AdminCreateAndAssert.CreateNewAdminForTest();
            adminOne.FullName = "Test Admin One";
            _csvAdminRepository.Add(adminOne);

            var adminTwo = AdminCreateAndAssert.CreateNewAdminForTest();
            adminTwo.FullName = "Test Admin Two";
            _csvAdminRepository.Add(adminTwo);

            var result = _csvAdminRepository.GetAll().OrderBy(a => a.Id).ToArray();

            Assert.That(result.Length, Is.EqualTo(2));
            AdminCreateAndAssert.DefaultAdminAssert(result[0], "Test Admin One", 1);
            AdminCreateAndAssert.DefaultAdminAssert(result[1], "Test Admin Two", 2);
        }

        // ��������� Add � GetAll ��� ������ �������
        [Test]
        public void Add_AndGetAll_AddsAdmin_ReturnsAddedAdmin()
        {
            var admin = AdminCreateAndAssert.CreateNewAdminForTest();
            admin.FullName = "Test GetAll Admin";
            _csvAdminRepository.Add(admin);

            var result = _csvAdminRepository.GetAll();

            Assert.That(result.Count, Is.EqualTo(1));
            AdminCreateAndAssert.DefaultAdminAssert(result.First(), "Test GetAll Admin");
        }

        // ������ ������������ ������ ������, ���� ������ ���
        [Test]
        public void GetAll_ReturnsEmptyList_WhenNoData()
        {
            var result = _csvAdminRepository.GetAll();

            Assert.IsEmpty(result);
        }

        // ������������ null, ���� �� ������ ������ �������
        [Test]
        public void Get_ReturnsNull_WhenNoData()
        {
            var fetchedAdmin = _csvAdminRepository.Get(999);

            Assert.IsNull(fetchedAdmin);
        }

        // ����������, ���� ������ ��� �����. ������������ null, ���� �� ������ ������ �������
        [Test]
        public void Get_ReturnsNull_ForNonexistentAdmin()
        {
            var admin = AdminCreateAndAssert.CreateNewAdminForTest();
            _csvAdminRepository.Add(admin);

            var fetchedAdmin = _csvAdminRepository.Get(999);

            Assert.IsNull(fetchedAdmin);
        }

        // ������������ ����������������� � ������������ Get
        [Test]
        public void Get_ReturnsCorrectAdmin()
        {
            var admin = AdminCreateAndAssert.CreateNewAdminForTest();
            _csvAdminRepository.Add(admin);

            var fetchedAdmin = _csvAdminRepository.Get(1);

            AdminCreateAndAssert.DefaultAdminAssert(fetchedAdmin);
        }

        // ���� ��� ������, �� ������ � �� ���������
        [Test]
        public void Update_DoesNotThrowException_WhenNoData()
        {
            var updatedAdmin = new Admin { Id = 1, FullName = "Updated Admin" };

            Assert.DoesNotThrow(() => _csvAdminRepository.Update(updatedAdmin));
        }

        // ���� ��� ������ ID, �� ���� �� ����� �������� ������
        [Test]
        public void Update_DoesNotThrowException_WhenNoSuchId()
        {
            var admin = new Admin { Id = 1, FullName = "Test Admin" };
            _csvAdminRepository.Add(admin);
            var updatedAdmin = new Admin { Id = 999, FullName = "Updated Admin" };

            Assert.DoesNotThrow(() => _csvAdminRepository.Update(updatedAdmin));
        }

        [Test]
        public void Update_UpdatesAdmin()
        {
            var admin = AdminCreateAndAssert.CreateNewAdminForTest();
            _csvAdminRepository.Add(admin);
            var updatedAdmin = AdminCreateAndAssert.CreateNewAdminForTest();
            updatedAdmin.FullName = "Updated Admin";
            _csvAdminRepository.Update(updatedAdmin);

            var fetchedAdmin = _csvAdminRepository.Get(1);

            AdminCreateAndAssert.DefaultAdminAssert(fetchedAdmin, "Updated Admin");
        }

        [Test]
        public void Delete_DoesNotThrowException_WhenNoData()
        {
            Assert.DoesNotThrow(() => _csvAdminRepository.Delete(1));
        }

        [Test]
        public void Delete_DoesNotThrowException_WhenNoSuchId()
        {
            var admin = AdminCreateAndAssert.CreateNewAdminForTest();
            _csvAdminRepository.Add(admin);

            Assert.DoesNotThrow(() => _csvAdminRepository.Delete(999));
        }

        [Test]
        public void Delete_RemovesAdmin()
        {
            var admin = new Admin { Id = 1, FullName = "Test Admin" };
            _csvAdminRepository.Add(admin);

            _csvAdminRepository.Delete(1);

            var result = _csvAdminRepository.GetAll();

            Assert.IsEmpty(result);
        }

        [TearDown]
        public void TearDown()
        {
            // �������� ��������� ����� ����� ������� �����
            if (File.Exists(_testFilePath))
            {
                File.Delete(_testFilePath);
            }
        }
    }
}