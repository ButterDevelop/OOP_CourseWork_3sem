using DB_CourseWork.DbRepositories.Csv;
using DB_CourseWork.Models;
using UnitTests.ObjectsCreatesAndAsserts;

namespace UnitTests.Csv
{
    [TestFixture]
    public class CsvPaymentRepositoryTests
    {
        private string _testFilePath = "testPayments.csv";
        private CsvPaymentRepository _csvPaymentRepository;

        [SetUp]
        public void Setup()
        {
            if (File.Exists(_testFilePath))
            {
                File.Delete(_testFilePath);
            }
            _csvPaymentRepository = new CsvPaymentRepository(_testFilePath);
        }

        [Test]
        public void Add_DoesNotThrowException_AndChangesId_WhenDuplicate()
        {
            var payment = PaymentCreateAndAssert.CreateNewPaymentForTest();
            _csvPaymentRepository.Add(payment);

            int oldMaxId = _csvPaymentRepository.GetAll().Max(p => p.Id);

            var paymentDuplicate = PaymentCreateAndAssert.CreateNewPaymentForTest();
            Assert.DoesNotThrow(() => _csvPaymentRepository.Add(paymentDuplicate));

            var addedDuplicate = _csvPaymentRepository.GetAll().FirstOrDefault(p => p.Id != payment.Id);

            Assert.NotNull(addedDuplicate);
            Assert.That(addedDuplicate.Id, Is.EqualTo(oldMaxId + 1));
        }

        [Test]
        public void Add_ThrowsException_WhenAddNull()
        {
            Assert.Throws<NullReferenceException>(() => _csvPaymentRepository.Add(null));
        }

        [Test]
        public void Add_AndGetAll_AddsFewPayments_ReturnsAllAddedPayments()
        {
            var paymentOne = PaymentCreateAndAssert.CreateNewPaymentForTest();
            paymentOne.Cost = 100.0;
            _csvPaymentRepository.Add(paymentOne);

            var paymentTwo = PaymentCreateAndAssert.CreateNewPaymentForTest();
            paymentTwo.Id = 2;
            paymentTwo.Cost = 200.0;
            _csvPaymentRepository.Add(paymentTwo);

            var result = _csvPaymentRepository.GetAll().OrderBy(p => p.Id).ToArray();

            Assert.That(result.Count, Is.EqualTo(2));
            PaymentCreateAndAssert.DefaultPaymentAssert(result[0], 100.0, 1);
            PaymentCreateAndAssert.DefaultPaymentAssert(result[1], 200.0, 2);
        }

        [Test]
        public void Add_AndGetAll_AddsPayment_ReturnsAddedPayment()
        {
            var payment = PaymentCreateAndAssert.CreateNewPaymentForTest();
            payment.Cost = 150.0;
            _csvPaymentRepository.Add(payment);

            var result = _csvPaymentRepository.GetAll();

            Assert.That(result.Count, Is.EqualTo(1));
            PaymentCreateAndAssert.DefaultPaymentAssert(result.First(), 150.0);
        }

        [Test]
        public void GetAll_ReturnsEmptyList_WhenNoData()
        {
            var result = _csvPaymentRepository.GetAll();

            Assert.IsEmpty(result);
        }

        [Test]
        public void Get_ReturnsNull_WhenNoData()
        {
            var fetchedPayment = _csvPaymentRepository.Get(999);

            Assert.IsNull(fetchedPayment);
        }

        [Test]
        public void Get_ReturnsNull_ForNonexistentPayment()
        {
            var payment = PaymentCreateAndAssert.CreateNewPaymentForTest();
            _csvPaymentRepository.Add(payment);

            var fetchedPayment = _csvPaymentRepository.Get(999);

            Assert.IsNull(fetchedPayment);
        }

        [Test]
        public void Get_ReturnsCorrectPayment()
        {
            var payment = PaymentCreateAndAssert.CreateNewPaymentForTest();
            _csvPaymentRepository.Add(payment);

            var fetchedPayment = _csvPaymentRepository.Get(1);

            PaymentCreateAndAssert.DefaultPaymentAssert(fetchedPayment);
        }

        [Test]
        public void Update_DoesNotThrowException_WhenNoData()
        {
            var updatedPayment = new Payment { Id = 1, Cost = 250.0 };

            Assert.DoesNotThrow(() => _csvPaymentRepository.Update(updatedPayment));
        }

        [Test]
        public void Update_DoesNotThrowException_WhenNoSuchId()
        {
            var payment = PaymentCreateAndAssert.CreateNewPaymentForTest();
            _csvPaymentRepository.Add(payment);
            var updatedPayment = new Payment { Id = 999, Cost = 350.0 };

            Assert.DoesNotThrow(() => _csvPaymentRepository.Update(updatedPayment));
        }

        [Test]
        public void Update_UpdatesPayment()
        {
            var payment = PaymentCreateAndAssert.CreateNewPaymentForTest();
            _csvPaymentRepository.Add(payment);
            var updatedPayment = PaymentCreateAndAssert.CreateNewPaymentForTest();
            updatedPayment.Cost = 250.0;
            _csvPaymentRepository.Update(updatedPayment);

            var fetchedPayment = _csvPaymentRepository.Get(1);

            PaymentCreateAndAssert.DefaultPaymentAssert(fetchedPayment, 250.0);
        }

        [Test]
        public void Delete_DoesNotThrowException_WhenNoData()
        {
            Assert.DoesNotThrow(() => _csvPaymentRepository.Delete(1));
        }

        [Test]
        public void Delete_DoesNotThrowException_WhenNoSuchId()
        {
            var payment = PaymentCreateAndAssert.CreateNewPaymentForTest();
            _csvPaymentRepository.Add(payment);

            Assert.DoesNotThrow(() => _csvPaymentRepository.Delete(999));
        }

        [Test]
        public void Delete_RemovesPayment()
        {
            var payment = PaymentCreateAndAssert.CreateNewPaymentForTest();
            _csvPaymentRepository.Add(payment);

            _csvPaymentRepository.Delete(1);

            var result = _csvPaymentRepository.GetAll();

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
