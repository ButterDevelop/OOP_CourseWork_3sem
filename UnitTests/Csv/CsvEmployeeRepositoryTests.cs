using DB_CourseWork.DbRepositories.Csv;
using DB_CourseWork.Models;
using UnitTests.ObjectsCreatesAndAsserts;

namespace UnitTests.Csv
{
    [TestFixture]
    public class CsvEmployeeRepositoryTests
    {
        private string _testFilePath = "testEmployees.csv";
        private CsvEmployeeRepository _csvEmployeeRepository;

        [SetUp]
        public void Setup()
        {
            if (File.Exists(_testFilePath))
            {
                File.Delete(_testFilePath);
            }
            _csvEmployeeRepository = new CsvEmployeeRepository(_testFilePath);
        }

        [Test]
        public void Add_DoesNotThrowException_AndChangesId_WhenDuplicate()
        {
            var employee = EmployeeCreateAndAssert.CreateNewEmployeeForTest();
            _csvEmployeeRepository.Add(employee);

            int oldMaxId = _csvEmployeeRepository.GetAll().Max(e => e.Id);

            var employeeDuplicate = EmployeeCreateAndAssert.CreateNewEmployeeForTest();
            Assert.DoesNotThrow(() => _csvEmployeeRepository.Add(employeeDuplicate));

            var addedDuplicate = _csvEmployeeRepository.GetAll().FirstOrDefault(e => e.Id != employee.Id);

            Assert.NotNull(addedDuplicate);
            Assert.That(addedDuplicate.Id, Is.EqualTo(oldMaxId + 1));
        }

        [Test]
        public void Add_ThrowsException_WhenAddNull()
        {
            Assert.Throws<NullReferenceException>(() => _csvEmployeeRepository.Add(null));
        }

        [Test]
        public void Add_AndGetAll_AddsFewEmployees_ReturnsAllAddedEmployees()
        {
            var employeeOne = EmployeeCreateAndAssert.CreateNewEmployeeForTest();
            employeeOne.FullName = "Test Employee One";
            _csvEmployeeRepository.Add(employeeOne);

            var employeeTwo = EmployeeCreateAndAssert.CreateNewEmployeeForTest();
            employeeTwo.FullName = "Test Employee Two";
            _csvEmployeeRepository.Add(employeeTwo);

            var result = _csvEmployeeRepository.GetAll().OrderBy(e => e.Id).ToArray();

            Assert.That(result.Count, Is.EqualTo(2));
            EmployeeCreateAndAssert.DefaultEmployeeAssert(result[0], "Test Employee One", 1);
            EmployeeCreateAndAssert.DefaultEmployeeAssert(result[1], "Test Employee Two", 2);
        }

        [Test]
        public void Add_AndGetAll_AddsEmployee_ReturnsAddedEmployee()
        {
            var employee = EmployeeCreateAndAssert.CreateNewEmployeeForTest();
            employee.FullName = "Test GetAll Employee";
            _csvEmployeeRepository.Add(employee);

            var result = _csvEmployeeRepository.GetAll();

            Assert.That(result.Count, Is.EqualTo(1));
            EmployeeCreateAndAssert.DefaultEmployeeAssert(result.First(), "Test GetAll Employee");
        }

        [Test]
        public void GetAll_ReturnsEmptyList_WhenNoData()
        {
            var result = _csvEmployeeRepository.GetAll();

            Assert.IsEmpty(result);
        }

        [Test]
        public void Get_ReturnsNull_WhenNoData()
        {
            var fetchedEmployee = _csvEmployeeRepository.Get(999);

            Assert.IsNull(fetchedEmployee);
        }

        [Test]
        public void Get_ReturnsNull_ForNonexistentEmployee()
        {
            var employee = EmployeeCreateAndAssert.CreateNewEmployeeForTest();
            _csvEmployeeRepository.Add(employee);

            var fetchedEmployee = _csvEmployeeRepository.Get(999);

            Assert.IsNull(fetchedEmployee);
        }

        [Test]
        public void Get_ReturnsCorrectEmployee()
        {
            var employee = EmployeeCreateAndAssert.CreateNewEmployeeForTest();
            _csvEmployeeRepository.Add(employee);

            var fetchedEmployee = _csvEmployeeRepository.Get(1);

            EmployeeCreateAndAssert.DefaultEmployeeAssert(fetchedEmployee);
        }

        [Test]
        public void Update_DoesNotThrowException_WhenNoData()
        {
            var updatedEmployee = new Employee { Id = 1, FullName = "Updated Employee" };

            Assert.DoesNotThrow(() => _csvEmployeeRepository.Update(updatedEmployee));
        }

        [Test]
        public void Update_DoesNotThrowException_WhenNoSuchId()
        {
            var employee = EmployeeCreateAndAssert.CreateNewEmployeeForTest();
            _csvEmployeeRepository.Add(employee);
            var updatedEmployee = new Employee { Id = 999, FullName = "Updated Employee" };

            Assert.DoesNotThrow(() => _csvEmployeeRepository.Update(updatedEmployee));
        }

        [Test]
        public void Update_UpdatesEmployee()
        {
            var employee = EmployeeCreateAndAssert.CreateNewEmployeeForTest();
            _csvEmployeeRepository.Add(employee);
            var updatedEmployee = EmployeeCreateAndAssert.CreateNewEmployeeForTest();
            updatedEmployee.FullName = "Updated Employee";
            _csvEmployeeRepository.Update(updatedEmployee);

            var fetchedEmployee = _csvEmployeeRepository.Get(1);

            EmployeeCreateAndAssert.DefaultEmployeeAssert(fetchedEmployee, "Updated Employee");
        }

        [Test]
        public void Delete_DoesNotThrowException_WhenNoData()
        {
            Assert.DoesNotThrow(() => _csvEmployeeRepository.Delete(1));
        }

        [Test]
        public void Delete_DoesNotThrowException_WhenNoSuchId()
        {
            var employee = EmployeeCreateAndAssert.CreateNewEmployeeForTest();
            _csvEmployeeRepository.Add(employee);

            Assert.DoesNotThrow(() => _csvEmployeeRepository.Delete(999));
        }

        [Test]
        public void Delete_RemovesEmployee()
        {
            var employee = EmployeeCreateAndAssert.CreateNewEmployeeForTest();
            _csvEmployeeRepository.Add(employee);

            _csvEmployeeRepository.Delete(1);

            var result = _csvEmployeeRepository.GetAll();

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
