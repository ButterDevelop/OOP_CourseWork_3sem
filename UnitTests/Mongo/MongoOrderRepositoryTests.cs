using DB_CourseWork.DbRepositories.Mongo;
using DB_CourseWork.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using UnitTests.ObjectsCreatesAndAsserts;

namespace UnitTests.Mongo
{
    [TestFixture]
    public class MongoOrderRepositoryTests
    {
        private MongoOrderRepository _mongoOrderRepository;
        private IMongoCollection<Order> _orderCollection;

        [SetUp]
        public void Setup()
        {
            var builder = new ConfigurationBuilder()
                              .SetBasePath(Directory.GetCurrentDirectory())
                              .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            IConfiguration configuration = builder.Build();

            string? mongoConnectionString = configuration["ConnectionStrings:MongoConnectionString"],
                    mongoTestDatabaseName = configuration["ConnectionStrings:MongoTestDatabaseName"],
                    mongoTableName = configuration["MongoTableNames:MONGO_ORDER_PATH"];

            var client = new MongoClient(mongoConnectionString);
            var database = client.GetDatabase(mongoTestDatabaseName);

            _orderCollection = database.GetCollection<Order>(mongoTableName);
            _orderCollection.DeleteMany(FilterDefinition<Order>.Empty);

            _mongoOrderRepository = new MongoOrderRepository(mongoConnectionString, mongoTestDatabaseName);
        }

        [Test]
        public void Add_DoesNotThrowException_AndChangesId_WhenDuplicate()
        {
            var order = OrderCreateAndAssert.CreateNewOrderForTest();
            _mongoOrderRepository.Add(order);

            int oldMaxId = _mongoOrderRepository.GetAll().Max(o => o.Id);

            var orderDuplicate = OrderCreateAndAssert.CreateNewOrderForTest();
            Assert.DoesNotThrow(() => _mongoOrderRepository.Add(orderDuplicate));

            var addedDuplicate = _mongoOrderRepository.GetAll().FirstOrDefault(o => o.Id != order.Id);

            Assert.NotNull(addedDuplicate);
            Assert.That(addedDuplicate.Id, Is.EqualTo(oldMaxId + 1));
        }

        [Test]
        public void Add_ThrowsException_WhenAddNull()
        {
            Assert.Throws<NullReferenceException>(() => _mongoOrderRepository.Add(null));
        }

        [Test]
        public void Add_AndGetAll_AddsFewOrders_ReturnsAllAddedOrders()
        {
            var orderOne = OrderCreateAndAssert.CreateNewOrderForTest();
            orderOne.OrderedCarId = 1;
            _mongoOrderRepository.Add(orderOne);

            var orderTwo = OrderCreateAndAssert.CreateNewOrderForTest();
            orderTwo.OrderedCarId = 2;
            _mongoOrderRepository.Add(orderTwo);

            var result = _mongoOrderRepository.GetAll().OrderBy(o => o.Id).ToArray();

            Assert.That(result.Length, Is.EqualTo(2));
            OrderCreateAndAssert.DefaultOrderAssert(result[0], 1, 1);
            OrderCreateAndAssert.DefaultOrderAssert(result[1], 2, 2);
        }

        [Test]
        public void Add_AndGetAll_AddsOrder_ReturnsAddedOrder()
        {
            var order = OrderCreateAndAssert.CreateNewOrderForTest();
            order.OrderedCarId = 1;
            _mongoOrderRepository.Add(order);

            var result = _mongoOrderRepository.GetAll();

            Assert.That(result.Count, Is.EqualTo(1));
            OrderCreateAndAssert.DefaultOrderAssert(result.First(), 1);
        }

        [Test]
        public void GetAll_ReturnsEmptyList_WhenNoData()
        {
            var result = _mongoOrderRepository.GetAll();

            Assert.IsEmpty(result);
        }

        [Test]
        public void Get_ReturnsNull_WhenNoData()
        {
            var fetchedOrder = _mongoOrderRepository.Get(999);

            Assert.IsNull(fetchedOrder);
        }

        [Test]
        public void Get_ReturnsNull_ForNonexistentOrder()
        {
            var order = OrderCreateAndAssert.CreateNewOrderForTest();
            _mongoOrderRepository.Add(order);

            var fetchedOrder = _mongoOrderRepository.Get(999);

            Assert.IsNull(fetchedOrder);
        }

        [Test]
        public void Get_ReturnsCorrectOrder()
        {
            var order = OrderCreateAndAssert.CreateNewOrderForTest();
            _mongoOrderRepository.Add(order);

            var fetchedOrder = _mongoOrderRepository.Get(1);

            OrderCreateAndAssert.DefaultOrderAssert(fetchedOrder, 1);
        }

        [Test]
        public void Update_DoesNotThrowException_WhenNoData()
        {
            var updatedOrder = new Order { Id = 1, OrderedCarId = 1 };

            Assert.DoesNotThrow(() => _mongoOrderRepository.Update(updatedOrder));
        }

        [Test]
        public void Update_DoesNotThrowException_WhenNoSuchId()
        {
            var order = OrderCreateAndAssert.CreateNewOrderForTest();
            _mongoOrderRepository.Add(order);
            var updatedOrder = new Order { Id = 999, OrderedCarId = 999 };

            Assert.DoesNotThrow(() => _mongoOrderRepository.Update(updatedOrder));
        }

        [Test]
        public void Update_UpdatesOrder()
        {
            var order = OrderCreateAndAssert.CreateNewOrderForTest();
            _mongoOrderRepository.Add(order);
            var updatedOrder = OrderCreateAndAssert.CreateNewOrderForTest();
            updatedOrder.OrderedCarId = 2; // Изменение для проверки обновления
            _mongoOrderRepository.Update(updatedOrder);

            var fetchedOrder = _mongoOrderRepository.Get(1);

            OrderCreateAndAssert.DefaultOrderAssert(fetchedOrder, 2);
        }

        [Test]
        public void Delete_DoesNotThrowException_WhenNoData()
        {
            Assert.DoesNotThrow(() => _mongoOrderRepository.Delete(1));
        }

        [Test]
        public void Delete_DoesNotThrowException_WhenNoSuchId()
        {
            var order = OrderCreateAndAssert.CreateNewOrderForTest();
            _mongoOrderRepository.Add(order);

            Assert.DoesNotThrow(() => _mongoOrderRepository.Delete(999));
        }

        [Test]
        public void Delete_RemovesOrder()
        {
            var order = OrderCreateAndAssert.CreateNewOrderForTest();
            _mongoOrderRepository.Add(order);

            _mongoOrderRepository.Delete(1);

            var result = _mongoOrderRepository.GetAll();

            Assert.IsEmpty(result);
        }

        [TearDown]
        public void TearDown()
        {
            _orderCollection.DeleteMany(FilterDefinition<Order>.Empty);
        }
    }
}
