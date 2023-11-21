using DB_CourseWork.DbRepositories.Mongo;
using DB_CourseWork.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using UnitTests.ObjectsCreatesAndAsserts;

namespace UnitTests.Mongo
{
    [TestFixture]
    public class MongoPaymentRepositoryTests
    {
        private MongoPaymentRepository _mongoPaymentRepository;
        private IMongoCollection<Payment> _paymentCollection;

        [SetUp]
        public void Setup()
        {
            var builder = new ConfigurationBuilder()
                              .SetBasePath(Directory.GetCurrentDirectory())
                              .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            IConfiguration configuration = builder.Build();

            string? mongoConnectionString = configuration["ConnectionStrings:MongoConnectionString"],
                    mongoTestDatabaseName = configuration["ConnectionStrings:MongoTestDatabaseName"],
                    mongoTableName = configuration["MongoTableNames:MONGO_PAYMENT_PATH"];

            var client = new MongoClient(mongoConnectionString);
            var database = client.GetDatabase(mongoTestDatabaseName);

            _paymentCollection = database.GetCollection<Payment>(mongoTableName);
            _paymentCollection.DeleteMany(FilterDefinition<Payment>.Empty);

            _mongoPaymentRepository = new MongoPaymentRepository(mongoConnectionString, mongoTestDatabaseName);
        }

        [Test]
        public void Add_DoesNotThrowException_AndChangesId_WhenDuplicate()
        {
            var payment = PaymentCreateAndAssert.CreateNewPaymentForTest();
            _mongoPaymentRepository.Add(payment);

            int oldMaxId = _mongoPaymentRepository.GetAll().Max(p => p.Id);

            var paymentDuplicate = PaymentCreateAndAssert.CreateNewPaymentForTest();
            Assert.DoesNotThrow(() => _mongoPaymentRepository.Add(paymentDuplicate));

            var addedDuplicate = _mongoPaymentRepository.GetAll().FirstOrDefault(p => p.Id != payment.Id);

            Assert.NotNull(addedDuplicate);
            Assert.That(addedDuplicate.Id, Is.EqualTo(oldMaxId + 1));
        }

        [Test]
        public void Add_ThrowsException_WhenAddNull()
        {
            Assert.Throws<NullReferenceException>(() => _mongoPaymentRepository.Add(null));
        }

        [Test]
        public void Add_AndGetAll_AddsFewPayments_ReturnsAllAddedPayments()
        {
            var paymentOne = PaymentCreateAndAssert.CreateNewPaymentForTest();
            paymentOne.Cost = 100.0;
            _mongoPaymentRepository.Add(paymentOne);

            var paymentTwo = PaymentCreateAndAssert.CreateNewPaymentForTest();
            paymentTwo.Id = 2;
            paymentTwo.Cost = 200.0;
            _mongoPaymentRepository.Add(paymentTwo);

            var result = _mongoPaymentRepository.GetAll().OrderBy(p => p.Id).ToArray();

            Assert.That(result.Length, Is.EqualTo(2));
            PaymentCreateAndAssert.DefaultPaymentAssert(result[0], 100.0, 1);
            PaymentCreateAndAssert.DefaultPaymentAssert(result[1], 200.0, 2);
        }

        [Test]
        public void Add_AndGetAll_AddsPayment_ReturnsAddedPayment()
        {
            var payment = PaymentCreateAndAssert.CreateNewPaymentForTest();
            payment.Cost = 150.0;
            _mongoPaymentRepository.Add(payment);

            var result = _mongoPaymentRepository.GetAll();

            Assert.That(result.Count, Is.EqualTo(1));
            PaymentCreateAndAssert.DefaultPaymentAssert(result.First(), 150.0);
        }

        [Test]
        public void GetAll_ReturnsEmptyList_WhenNoData()
        {
            var result = _mongoPaymentRepository.GetAll();

            Assert.IsEmpty(result);
        }

        [Test]
        public void Get_ReturnsNull_WhenNoData()
        {
            var fetchedPayment = _mongoPaymentRepository.Get(999);

            Assert.IsNull(fetchedPayment);
        }

        [Test]
        public void Get_ReturnsNull_ForNonexistentPayment()
        {
            var payment = PaymentCreateAndAssert.CreateNewPaymentForTest();
            _mongoPaymentRepository.Add(payment);

            var fetchedPayment = _mongoPaymentRepository.Get(999);

            Assert.IsNull(fetchedPayment);
        }

        [Test]
        public void Get_ReturnsCorrectPayment()
        {
            var payment = PaymentCreateAndAssert.CreateNewPaymentForTest();
            _mongoPaymentRepository.Add(payment);

            var fetchedPayment = _mongoPaymentRepository.Get(1);

            PaymentCreateAndAssert.DefaultPaymentAssert(fetchedPayment, 100.0);
        }

        [Test]
        public void Update_DoesNotThrowException_WhenNoData()
        {
            var updatedPayment = new Payment { Id = 1, Cost = 250.0 };

            Assert.DoesNotThrow(() => _mongoPaymentRepository.Update(updatedPayment));
        }

        [Test]
        public void Update_DoesNotThrowException_WhenNoSuchId()
        {
            var payment = PaymentCreateAndAssert.CreateNewPaymentForTest();
            _mongoPaymentRepository.Add(payment);
            var updatedPayment = new Payment { Id = 999, Cost = 350.0 };

            Assert.DoesNotThrow(() => _mongoPaymentRepository.Update(updatedPayment));
        }

        [Test]
        public void Update_UpdatesPayment()
        {
            var payment = PaymentCreateAndAssert.CreateNewPaymentForTest();
            _mongoPaymentRepository.Add(payment);
            var updatedPayment = PaymentCreateAndAssert.CreateNewPaymentForTest();
            updatedPayment.Cost = 250.0;
            _mongoPaymentRepository.Update(updatedPayment);

            var fetchedPayment = _mongoPaymentRepository.Get(1);

            PaymentCreateAndAssert.DefaultPaymentAssert(fetchedPayment, 250.0);
        }

        [Test]
        public void Delete_DoesNotThrowException_WhenNoData()
        {
            Assert.DoesNotThrow(() => _mongoPaymentRepository.Delete(1));
        }

        [Test]
        public void Delete_DoesNotThrowException_WhenNoSuchId()
        {
            var payment = PaymentCreateAndAssert.CreateNewPaymentForTest();
            _mongoPaymentRepository.Add(payment);

            Assert.DoesNotThrow(() => _mongoPaymentRepository.Delete(999));
        }

        [Test]
        public void Delete_RemovesPayment()
        {
            var payment = PaymentCreateAndAssert.CreateNewPaymentForTest();
            _mongoPaymentRepository.Add(payment);

            _mongoPaymentRepository.Delete(1);

            var result = _mongoPaymentRepository.GetAll();

            Assert.IsEmpty(result);
        }

        [TearDown]
        public void TearDown()
        {
            _paymentCollection.DeleteMany(FilterDefinition<Payment>.Empty);
        }
    }
}
