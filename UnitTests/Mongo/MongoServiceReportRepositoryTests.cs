using DB_CourseWork.DbRepositories.Mongo;
using DB_CourseWork.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using UnitTests.ObjectsCreatesAndAsserts;

namespace UnitTests.Mongo
{
    [TestFixture]
    public class MongoServiceReportRepositoryTests
    {
        private MongoServiceReportRepository _mongoServiceReportRepository;
        private IMongoCollection<ServiceReport> _serviceReportCollection;

        [SetUp]
        public void Setup()
        {
            var builder = new ConfigurationBuilder()
                              .SetBasePath(Directory.GetCurrentDirectory())
                              .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            IConfiguration configuration = builder.Build();

            string? mongoConnectionString = configuration["ConnectionStrings:MongoConnectionString"],
                    mongoTestDatabaseName = configuration["ConnectionStrings:MongoTestDatabaseName"],
                    mongoTableName = configuration["MongoTableNames:MONGO_SERVICE_REPORT_PATH"];

            var client = new MongoClient(mongoConnectionString);
            var database = client.GetDatabase(mongoTestDatabaseName);

            _serviceReportCollection = database.GetCollection<ServiceReport>(mongoTableName);
            _serviceReportCollection.DeleteMany(FilterDefinition<ServiceReport>.Empty);

            _mongoServiceReportRepository = new MongoServiceReportRepository(mongoConnectionString, mongoTestDatabaseName);
        }

        [Test]
        public void Add_DoesNotThrowException_AndChangesId_WhenDuplicate()
        {
            var serviceReport = ServiceReportCreateAndAssert.CreateNewServiceReportForTest();
            _mongoServiceReportRepository.Add(serviceReport);

            int oldMaxId = _mongoServiceReportRepository.GetAll().Max(sr => sr.Id);

            var serviceReportDuplicate = ServiceReportCreateAndAssert.CreateNewServiceReportForTest();
            Assert.DoesNotThrow(() => _mongoServiceReportRepository.Add(serviceReportDuplicate));

            var addedDuplicate = _mongoServiceReportRepository.GetAll().FirstOrDefault(sr => sr.Id != serviceReport.Id);

            Assert.NotNull(addedDuplicate);
            Assert.That(addedDuplicate.Id, Is.EqualTo(oldMaxId + 1));
        }

        [Test]
        public void Add_ThrowsException_WhenAddNull()
        {
            Assert.Throws<NullReferenceException>(() => _mongoServiceReportRepository.Add(null));
        }

        [Test]
        public void Add_AndGetAll_AddsFewServiceReports_ReturnsAllAddedServiceReports()
        {
            var reportOne = ServiceReportCreateAndAssert.CreateNewServiceReportForTest();
            reportOne.Description = "Report One";
            _mongoServiceReportRepository.Add(reportOne);

            var reportTwo = ServiceReportCreateAndAssert.CreateNewServiceReportForTest();
            reportTwo.Id = 2;
            reportTwo.Description = "Report Two";
            _mongoServiceReportRepository.Add(reportTwo);

            var result = _mongoServiceReportRepository.GetAll().OrderBy(sr => sr.Id).ToArray();

            Assert.That(result.Length, Is.EqualTo(2));
            ServiceReportCreateAndAssert.DefaultServiceReportAssert(result[0], "Report One", 1);
            ServiceReportCreateAndAssert.DefaultServiceReportAssert(result[1], "Report Two", 2);
        }

        [Test]
        public void Add_AndGetAll_AddsServiceReport_ReturnsAddedServiceReport()
        {
            var serviceReport = ServiceReportCreateAndAssert.CreateNewServiceReportForTest();
            serviceReport.Description = "Test GetAll ServiceReport";
            _mongoServiceReportRepository.Add(serviceReport);

            var result = _mongoServiceReportRepository.GetAll();

            Assert.That(result.Count, Is.EqualTo(1));
            ServiceReportCreateAndAssert.DefaultServiceReportAssert(result.First(), "Test GetAll ServiceReport");
        }

        [Test]
        public void GetAll_ReturnsEmptyList_WhenNoData()
        {
            var result = _mongoServiceReportRepository.GetAll();

            Assert.IsEmpty(result);
        }

        [Test]
        public void Get_ReturnsNull_WhenNoData()
        {
            var fetchedServiceReport = _mongoServiceReportRepository.Get(999);

            Assert.IsNull(fetchedServiceReport);
        }

        [Test]
        public void Get_ReturnsNull_ForNonexistentServiceReport()
        {
            var serviceReport = ServiceReportCreateAndAssert.CreateNewServiceReportForTest();
            _mongoServiceReportRepository.Add(serviceReport);

            var fetchedServiceReport = _mongoServiceReportRepository.Get(999);

            Assert.IsNull(fetchedServiceReport);
        }

        [Test]
        public void Get_ReturnsCorrectServiceReport()
        {
            var serviceReport = ServiceReportCreateAndAssert.CreateNewServiceReportForTest();
            _mongoServiceReportRepository.Add(serviceReport);

            var fetchedServiceReport = _mongoServiceReportRepository.Get(1);

            ServiceReportCreateAndAssert.DefaultServiceReportAssert(fetchedServiceReport);
        }

        [Test]
        public void Update_DoesNotThrowException_WhenNoData()
        {
            var updatedServiceReport = new ServiceReport { Id = 1, Description = "Updated Report" };

            Assert.DoesNotThrow(() => _mongoServiceReportRepository.Update(updatedServiceReport));
        }

        [Test]
        public void Update_DoesNotThrowException_WhenNoSuchId()
        {
            var serviceReport = ServiceReportCreateAndAssert.CreateNewServiceReportForTest();
            _mongoServiceReportRepository.Add(serviceReport);
            var updatedServiceReport = new ServiceReport { Id = 999, Description = "Updated Report" };

            Assert.DoesNotThrow(() => _mongoServiceReportRepository.Update(updatedServiceReport));
        }

        [Test]
        public void Update_UpdatesServiceReport()
        {
            var serviceReport = ServiceReportCreateAndAssert.CreateNewServiceReportForTest();
            _mongoServiceReportRepository.Add(serviceReport);
            var updatedServiceReport = ServiceReportCreateAndAssert.CreateNewServiceReportForTest();
            updatedServiceReport.Description = "Updated Report";
            _mongoServiceReportRepository.Update(updatedServiceReport);

            var fetchedServiceReport = _mongoServiceReportRepository.Get(1);

            ServiceReportCreateAndAssert.DefaultServiceReportAssert(fetchedServiceReport, "Updated Report");
        }

        [Test]
        public void Delete_DoesNotThrowException_WhenNoData()
        {
            Assert.DoesNotThrow(() => _mongoServiceReportRepository.Delete(1));
        }

        [Test]
        public void Delete_DoesNotThrowException_WhenNoSuchId()
        {
            var serviceReport = ServiceReportCreateAndAssert.CreateNewServiceReportForTest();
            _mongoServiceReportRepository.Add(serviceReport);

            Assert.DoesNotThrow(() => _mongoServiceReportRepository.Delete(999));
        }

        [Test]
        public void Delete_RemovesServiceReport()
        {
            var serviceReport = ServiceReportCreateAndAssert.CreateNewServiceReportForTest();
            _mongoServiceReportRepository.Add(serviceReport);

            _mongoServiceReportRepository.Delete(1);

            var result = _mongoServiceReportRepository.GetAll();

            Assert.IsEmpty(result);
        }

        [TearDown]
        public void TearDown()
        {
            _serviceReportCollection.DeleteMany(FilterDefinition<ServiceReport>.Empty);
        }
    }
}