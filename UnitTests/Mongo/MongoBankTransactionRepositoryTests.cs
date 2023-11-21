using DB_CourseWork.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using DB_CourseWork.DbRepositories.Mongo;
using UnitTests.ObjectsCreatesAndAsserts;

namespace UnitTests.Mongo
{
    [TestFixture]
    public class MongoBankTransactionRepositoryTests
    {
        private MongoBankTransactionRepository _mongoBankTransactionRepository;
        private IMongoCollection<BankTransaction> _transactionCollection;

        [SetUp]
        public void Setup()
        {
            var builder = new ConfigurationBuilder()
                              .SetBasePath(Directory.GetCurrentDirectory())
                              .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            IConfiguration configuration = builder.Build();

            string? mongoConnectionString = configuration["ConnectionStrings:MongoConnectionString"],
                    mongoTestDatabaseName = configuration["ConnectionStrings:MongoTestDatabaseName"],
                    mongoTableName = configuration["MongoTableNames:MONGO_BANK_TRANSACTION_PATH"];

            var client = new MongoClient(mongoConnectionString);
            var database = client.GetDatabase(mongoTestDatabaseName);

            _transactionCollection = database.GetCollection<BankTransaction>(mongoTableName);
            _transactionCollection.DeleteMany(FilterDefinition<BankTransaction>.Empty);

            _mongoBankTransactionRepository = new MongoBankTransactionRepository(mongoConnectionString, mongoTestDatabaseName);
        }

        [Test]
        public void Add_DoesNotThrowException_AndChangesId_WhenDuplicate()
        {
            var transaction = BankTransactionCreateAndAssert.CreateNewBankTransactionForTest();
            _mongoBankTransactionRepository.Add(transaction);

            int oldMaxId = _mongoBankTransactionRepository.GetAll().Max(t => t.Id);

            var transactionDuplicate = BankTransactionCreateAndAssert.CreateNewBankTransactionForTest();
            Assert.DoesNotThrow(() => _mongoBankTransactionRepository.Add(transactionDuplicate));

            var addedDuplicate = _mongoBankTransactionRepository.GetAll().FirstOrDefault(t => t.Id != transaction.Id);

            Assert.NotNull(addedDuplicate);
            Assert.That(addedDuplicate.Id, Is.EqualTo(oldMaxId + 1));
        }

        [Test]
        public void Add_ThrowsException_WhenAddNull()
        {
            Assert.Throws<NullReferenceException>(() => _mongoBankTransactionRepository.Add(null));
        }

        [Test]
        public void Add_AndGetAll_AddsFewTransactions_ReturnsAllAddedTransactions()
        {
            var transactionOne = BankTransactionCreateAndAssert.CreateNewBankTransactionForTest();
            transactionOne.TotalAmount = 1000;
            _mongoBankTransactionRepository.Add(transactionOne);

            var transactionTwo = BankTransactionCreateAndAssert.CreateNewBankTransactionForTest();
            transactionTwo.TotalAmount = 2000;
            _mongoBankTransactionRepository.Add(transactionTwo);

            var result = _mongoBankTransactionRepository.GetAll().OrderBy(t => t.Id).ToArray();

            Assert.That(result.Length, Is.EqualTo(2));
            BankTransactionCreateAndAssert.DefaultBankTransactionAssert(result[0], 1000, 1);
            BankTransactionCreateAndAssert.DefaultBankTransactionAssert(result[1], 2000, 2);
        }

        [Test]
        public void Add_AndGetAll_AddsTransaction_ReturnsAddedTransaction()
        {
            var transaction = BankTransactionCreateAndAssert.CreateNewBankTransactionForTest();
            transaction.TotalAmount = 2000;
            _mongoBankTransactionRepository.Add(transaction);

            var result = _mongoBankTransactionRepository.GetAll();

            Assert.That(result.Count, Is.EqualTo(1));
            BankTransactionCreateAndAssert.DefaultBankTransactionAssert(result.First(), 2000);
        }

        [Test]
        public void GetAll_ReturnsEmptyList_WhenNoData()
        {
            var result = _mongoBankTransactionRepository.GetAll();

            Assert.IsEmpty(result);
        }

        [Test]
        public void Get_ReturnsNull_WhenNoData()
        {
            var fetchedTransaction = _mongoBankTransactionRepository.Get(999);

            Assert.IsNull(fetchedTransaction);
        }

        [Test]
        public void Get_ReturnsNull_ForNonexistentTransaction()
        {
            var transaction = BankTransactionCreateAndAssert.CreateNewBankTransactionForTest();
            _mongoBankTransactionRepository.Add(transaction);

            var fetchedTransaction = _mongoBankTransactionRepository.Get(999);

            Assert.IsNull(fetchedTransaction);
        }

        [Test]
        public void Get_ReturnsCorrectTransaction()
        {
            var transaction = BankTransactionCreateAndAssert.CreateNewBankTransactionForTest();
            _mongoBankTransactionRepository.Add(transaction);

            var fetchedTransaction = _mongoBankTransactionRepository.Get(1);

            BankTransactionCreateAndAssert.DefaultBankTransactionAssert(fetchedTransaction, 1000);
        }

        [Test]
        public void Update_DoesNotThrowException_WhenNoData()
        {
            var updatedTransaction = new BankTransaction { Id = 1, TotalAmount = 1500 };

            Assert.DoesNotThrow(() => _mongoBankTransactionRepository.Update(updatedTransaction));
        }

        [Test]
        public void Update_DoesNotThrowException_WhenNoSuchId()
        {
            var transaction = BankTransactionCreateAndAssert.CreateNewBankTransactionForTest();
            _mongoBankTransactionRepository.Add(transaction);
            var updatedTransaction = new BankTransaction { Id = 999, TotalAmount = 1500 };

            Assert.DoesNotThrow(() => _mongoBankTransactionRepository.Update(updatedTransaction));
        }

        [Test]
        public void Update_UpdatesTransaction()
        {
            var transaction = BankTransactionCreateAndAssert.CreateNewBankTransactionForTest();
            _mongoBankTransactionRepository.Add(transaction);
            var updatedTransaction = BankTransactionCreateAndAssert.CreateNewBankTransactionForTest();
            updatedTransaction.TotalAmount = 1500;
            _mongoBankTransactionRepository.Update(updatedTransaction);

            var fetchedTransaction = _mongoBankTransactionRepository.Get(1);

            BankTransactionCreateAndAssert.DefaultBankTransactionAssert(fetchedTransaction, 1500);
        }

        [Test]
        public void Delete_DoesNotThrowException_WhenNoData()
        {
            Assert.DoesNotThrow(() => _mongoBankTransactionRepository.Delete(1));
        }

        [Test]
        public void Delete_DoesNotThrowException_WhenNoSuchId()
        {
            var transaction = BankTransactionCreateAndAssert.CreateNewBankTransactionForTest();
            _mongoBankTransactionRepository.Add(transaction);

            Assert.DoesNotThrow(() => _mongoBankTransactionRepository.Delete(999));
        }

        [Test]
        public void Delete_RemovesTransaction()
        {
            var transaction = new BankTransaction { Id = 1, TotalAmount = 1000 };
            _mongoBankTransactionRepository.Add(transaction);

            _mongoBankTransactionRepository.Delete(1);

            var result = _mongoBankTransactionRepository.GetAll();

            Assert.IsEmpty(result);
        }

        [TearDown]
        public void TearDown()
        {
            _transactionCollection.DeleteMany(FilterDefinition<BankTransaction>.Empty);
        }

    }
}
