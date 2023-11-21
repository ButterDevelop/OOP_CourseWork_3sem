using DB_CourseWork.DbRepositories.Csv;
using DB_CourseWork.Models;
using UnitTests.ObjectsCreatesAndAsserts;

namespace UnitTests.Csv
{
    [TestFixture]
    public class CsvServiceReportRepositoryTests
    {
        private string _testFilePath = "testServiceReports.csv";
        private CsvServiceReportRepository _csvServiceReportRepository;

        [SetUp]
        public void Setup()
        {
            if (File.Exists(_testFilePath))
            {
                File.Delete(_testFilePath);
            }
            _csvServiceReportRepository = new CsvServiceReportRepository(_testFilePath);
        }

        [Test]
        public void Add_DoesNotThrowException_AndChangesId_WhenDuplicate()
        {
            var serviceReport = ServiceReportCreateAndAssert.CreateNewServiceReportForTest();
            _csvServiceReportRepository.Add(serviceReport);

            int oldMaxId = _csvServiceReportRepository.GetAll().Max(sr => sr.Id);

            var serviceReportDuplicate = ServiceReportCreateAndAssert.CreateNewServiceReportForTest();
            Assert.DoesNotThrow(() => _csvServiceReportRepository.Add(serviceReportDuplicate));

            var addedDuplicate = _csvServiceReportRepository.GetAll().FirstOrDefault(sr => sr.Id != serviceReport.Id);

            Assert.NotNull(addedDuplicate);
            Assert.That(addedDuplicate.Id, Is.EqualTo(oldMaxId + 1));
        }

        [Test]
        public void Add_ThrowsException_WhenAddNull()
        {
            Assert.Throws<NullReferenceException>(() => _csvServiceReportRepository.Add(null));
        }

        [Test]
        public void Add_AndGetAll_AddsFewServiceReports_ReturnsAllAddedServiceReports()
        {
            var reportOne = ServiceReportCreateAndAssert.CreateNewServiceReportForTest();
            reportOne.Description = "Report One";
            _csvServiceReportRepository.Add(reportOne);

            var reportTwo = ServiceReportCreateAndAssert.CreateNewServiceReportForTest();
            reportTwo.Id = 2;
            reportTwo.Description = "Report Two";
            _csvServiceReportRepository.Add(reportTwo);

            var result = _csvServiceReportRepository.GetAll().OrderBy(sr => sr.Id).ToArray();

            Assert.That(result.Count, Is.EqualTo(2));
            ServiceReportCreateAndAssert.DefaultServiceReportAssert(result[0], "Report One", 1);
            ServiceReportCreateAndAssert.DefaultServiceReportAssert(result[1], "Report Two", 2);
        }

        [Test]
        public void Add_AndGetAll_AddsServiceReport_ReturnsAddedServiceReport()
        {
            var serviceReport = ServiceReportCreateAndAssert.CreateNewServiceReportForTest();
            serviceReport.Description = "Test GetAll ServiceReport";
            _csvServiceReportRepository.Add(serviceReport);

            var result = _csvServiceReportRepository.GetAll();

            Assert.That(result.Count, Is.EqualTo(1));
            ServiceReportCreateAndAssert.DefaultServiceReportAssert(result.First(), "Test GetAll ServiceReport");
        }

        [Test]
        public void GetAll_ReturnsEmptyList_WhenNoData()
        {
            var result = _csvServiceReportRepository.GetAll();

            Assert.IsEmpty(result);
        }

        [Test]
        public void Get_ReturnsNull_WhenNoData()
        {
            var fetchedServiceReport = _csvServiceReportRepository.Get(999);

            Assert.IsNull(fetchedServiceReport);
        }

        [Test]
        public void Get_ReturnsNull_ForNonexistentServiceReport()
        {
            var serviceReport = ServiceReportCreateAndAssert.CreateNewServiceReportForTest();
            _csvServiceReportRepository.Add(serviceReport);

            var fetchedServiceReport = _csvServiceReportRepository.Get(999);

            Assert.IsNull(fetchedServiceReport);
        }

        [Test]
        public void Get_ReturnsCorrectServiceReport()
        {
            var serviceReport = ServiceReportCreateAndAssert.CreateNewServiceReportForTest();
            _csvServiceReportRepository.Add(serviceReport);

            var fetchedServiceReport = _csvServiceReportRepository.Get(1);

            ServiceReportCreateAndAssert.DefaultServiceReportAssert(fetchedServiceReport);
        }

        [Test]
        public void Update_DoesNotThrowException_WhenNoData()
        {
            var updatedServiceReport = new ServiceReport { Id = 1, Description = "Updated Report" };

            Assert.DoesNotThrow(() => _csvServiceReportRepository.Update(updatedServiceReport));
        }

        [Test]
        public void Update_DoesNotThrowException_WhenNoSuchId()
        {
            var serviceReport = ServiceReportCreateAndAssert.CreateNewServiceReportForTest();
            _csvServiceReportRepository.Add(serviceReport);
            var updatedServiceReport = new ServiceReport { Id = 999, Description = "Updated Report" };

            Assert.DoesNotThrow(() => _csvServiceReportRepository.Update(updatedServiceReport));
        }

        [Test]
        public void Update_UpdatesServiceReport()
        {
            var serviceReport = ServiceReportCreateAndAssert.CreateNewServiceReportForTest();
            _csvServiceReportRepository.Add(serviceReport);
            var updatedServiceReport = ServiceReportCreateAndAssert.CreateNewServiceReportForTest();
            updatedServiceReport.Description = "Updated Report";
            _csvServiceReportRepository.Update(updatedServiceReport);

            var fetchedServiceReport = _csvServiceReportRepository.Get(1);

            ServiceReportCreateAndAssert.DefaultServiceReportAssert(fetchedServiceReport, "Updated Report");
        }

        [Test]
        public void Delete_DoesNotThrowException_WhenNoData()
        {
            Assert.DoesNotThrow(() => _csvServiceReportRepository.Delete(1));
        }

        [Test]
        public void Delete_DoesNotThrowException_WhenNoSuchId()
        {
            var serviceReport = ServiceReportCreateAndAssert.CreateNewServiceReportForTest();
            _csvServiceReportRepository.Add(serviceReport);

            Assert.DoesNotThrow(() => _csvServiceReportRepository.Delete(999));
        }

        [Test]
        public void Delete_RemovesServiceReport()
        {
            var serviceReport = ServiceReportCreateAndAssert.CreateNewServiceReportForTest();
            _csvServiceReportRepository.Add(serviceReport);

            _csvServiceReportRepository.Delete(1);

            var result = _csvServiceReportRepository.GetAll();

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
