using DB_CourseWork.DbRepositories.Csv;
using DB_CourseWork.Models;
using UnitTests.ObjectsCreatesAndAsserts;

namespace UnitTests.Csv
{
    [TestFixture]
    public class CsvBankTransactionRepositoryTests
    {
        private string _testFilePath = "testBankTransactions.csv";
        private CsvBankTransactionRepository _csvBankTransactionRepository;

        [SetUp]
        public void Setup()
        {
            if (File.Exists(_testFilePath))
            {
                File.Delete(_testFilePath);
            }
            _csvBankTransactionRepository = new CsvBankTransactionRepository(_testFilePath);
        }

        [Test]
        public void Add_DoesNotThrowException_AndChangesId_WhenDuplicate()
        {
            var transaction = BankTransactionCreateAndAssert.CreateNewBankTransactionForTest();
            _csvBankTransactionRepository.Add(transaction);

            int oldMaxId = _csvBankTransactionRepository.GetAll().Max(t => t.Id);

            var transactionDuplicate = BankTransactionCreateAndAssert.CreateNewBankTransactionForTest();
            Assert.DoesNotThrow(() => _csvBankTransactionRepository.Add(transactionDuplicate));

            var addedDuplicate = _csvBankTransactionRepository.GetAll().FirstOrDefault(t => t.Id != transaction.Id);

            Assert.NotNull(addedDuplicate);
            Assert.That(addedDuplicate.Id, Is.EqualTo(oldMaxId + 1));
        }

        [Test]
        public void Add_ThrowsException_WhenAddNull()
        {
            Assert.Throws<NullReferenceException>(() => _csvBankTransactionRepository.Add(null));
        }

        [Test]
        public void Add_AndGetAll_AddsFewTransactions_ReturnsAllAddedTransactions()
        {
            var transactionOne = BankTransactionCreateAndAssert.CreateNewBankTransactionForTest();
            transactionOne.TotalAmount = 1000;
            _csvBankTransactionRepository.Add(transactionOne);

            var transactionTwo = BankTransactionCreateAndAssert.CreateNewBankTransactionForTest();
            transactionTwo.TotalAmount = 2000;
            _csvBankTransactionRepository.Add(transactionTwo);

            var result = _csvBankTransactionRepository.GetAll().OrderBy(t => t.Id).ToArray();

            Assert.That(result.Length, Is.EqualTo(2));
            BankTransactionCreateAndAssert.DefaultBankTransactionAssert(result[0], 1000, 1);
            BankTransactionCreateAndAssert.DefaultBankTransactionAssert(result[1], 2000, 2);
        }

        // Тестируем Add и GetAll для одного объекта
        [Test]
        public void Add_AndGetAll_AddsTransactions_ReturnsAddedTransaction()
        {
            var transaction = BankTransactionCreateAndAssert.CreateNewBankTransactionForTest();
            transaction.TotalAmount = 2000;
            _csvBankTransactionRepository.Add(transaction);

            var result = _csvBankTransactionRepository.GetAll();

            Assert.That(result.Count, Is.EqualTo(1));
            BankTransactionCreateAndAssert.DefaultBankTransactionAssert(result.First(), 2000);
        }

        [Test]
        public void GetAll_ReturnsEmptyList_WhenNoData()
        {
            var result = _csvBankTransactionRepository.GetAll();

            Assert.IsEmpty(result);
        }

        [Test]
        public void Get_ReturnsNull_WhenNoData()
        {
            var fetchedTransaction = _csvBankTransactionRepository.Get(999);

            Assert.IsNull(fetchedTransaction);
        }

        // Аналогично, если данных нет вовсе. Возвращается null, если не найден нужный элемент
        [Test]
        public void Get_ReturnsNull_ForNonexistentTransaction()
        {
            var transaction = BankTransactionCreateAndAssert.CreateNewBankTransactionForTest();
            _csvBankTransactionRepository.Add(transaction);

            var fetchedTransaction = _csvBankTransactionRepository.Get(999);

            Assert.IsNull(fetchedTransaction);
        }

        [Test]
        public void Get_ReturnsCorrectTransaction()
        {
            var transaction = BankTransactionCreateAndAssert.CreateNewBankTransactionForTest();
            _csvBankTransactionRepository.Add(transaction);

            var fetchedTransaction = _csvBankTransactionRepository.Get(1);

            BankTransactionCreateAndAssert.DefaultBankTransactionAssert(fetchedTransaction, 1000);
        }

        [Test]
        public void Update_DoesNotThrowException_WhenNoData()
        {
            var updatedTransaction = new BankTransaction { Id = 1, TotalAmount = 1500 };

            Assert.DoesNotThrow(() => _csvBankTransactionRepository.Update(updatedTransaction));
        }

        // Если нет такого ID, то тоже не стоит выдавать ошибку
        [Test]
        public void Update_DoesNotThrowException_WhenNoSuchId()
        {
            var transaction = new BankTransaction { Id = 1, TotalAmount = 1000 };
            _csvBankTransactionRepository.Add(transaction);
            var updatedTransaction = new BankTransaction { Id = 999, TotalAmount = 1500 };

            Assert.DoesNotThrow(() => _csvBankTransactionRepository.Update(updatedTransaction));
        }

        [Test]
        public void Update_UpdatesTransaction()
        {
            var transaction = BankTransactionCreateAndAssert.CreateNewBankTransactionForTest();
            _csvBankTransactionRepository.Add(transaction);
            var updatedTransaction = BankTransactionCreateAndAssert.CreateNewBankTransactionForTest();
            updatedTransaction.TotalAmount = 1500;
            _csvBankTransactionRepository.Update(updatedTransaction);

            var fetchedTransaction = _csvBankTransactionRepository.Get(1);

            BankTransactionCreateAndAssert.DefaultBankTransactionAssert(fetchedTransaction, 1500);
        }

        [Test]
        public void Delete_DoesNotThrowException_WhenNoData()
        {
            Assert.DoesNotThrow(() => _csvBankTransactionRepository.Delete(1));
        }

        [Test]
        public void Delete_DoesNotThrowException_WhenNoSuchId()
        {
            var transaction = BankTransactionCreateAndAssert.CreateNewBankTransactionForTest();
            _csvBankTransactionRepository.Add(transaction);

            Assert.DoesNotThrow(() => _csvBankTransactionRepository.Delete(999));
        }

        [Test]
        public void Delete_RemovesTransaction()
        {
            var transaction = new BankTransaction { Id = 1, TotalAmount = 1000 };
            _csvBankTransactionRepository.Add(transaction);

            _csvBankTransactionRepository.Delete(1);

            var result = _csvBankTransactionRepository.GetAll();

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
