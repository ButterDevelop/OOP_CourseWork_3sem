using DB_CourseWork.DbRepositories.Csv;
using DB_CourseWork.Models;
using UnitTests.ObjectsCreatesAndAsserts;

namespace UnitTests.Csv
{
    [TestFixture]
    public class CsvOrderRepositoryTests
    {
        private string _testFilePath = "testOrders.csv";
        private CsvOrderRepository _csvOrderRepository;

        [SetUp]
        public void Setup()
        {
            if (File.Exists(_testFilePath))
            {
                File.Delete(_testFilePath);
            }
            _csvOrderRepository = new CsvOrderRepository(_testFilePath);
        }

        [Test]
        public void Add_DoesNotThrowException_AndChangesId_WhenDuplicate()
        {
            var order = OrderCreateAndAssert.CreateNewOrderForTest();
            _csvOrderRepository.Add(order);

            int oldMaxId = _csvOrderRepository.GetAll().Max(o => o.Id);

            var orderDuplicate = OrderCreateAndAssert.CreateNewOrderForTest();
            Assert.DoesNotThrow(() => _csvOrderRepository.Add(orderDuplicate));

            var addedDuplicate = _csvOrderRepository.GetAll().FirstOrDefault(o => o.Id != order.Id);

            Assert.NotNull(addedDuplicate);
            Assert.That(addedDuplicate.Id, Is.EqualTo(oldMaxId + 1));
        }

        [Test]
        public void Add_ThrowsException_WhenAddNull()
        {
            Assert.Throws<NullReferenceException>(() => _csvOrderRepository.Add(null));
        }

        [Test]
        public void Add_AndGetAll_AddsFewOrders_ReturnsAllAddedOrders()
        {
            var orderOne = OrderCreateAndAssert.CreateNewOrderForTest();
            orderOne.OrderedCarId = 1;
            _csvOrderRepository.Add(orderOne);

            var orderTwo = OrderCreateAndAssert.CreateNewOrderForTest();
            orderTwo.OrderedCarId = 2;
            _csvOrderRepository.Add(orderTwo);

            var result = _csvOrderRepository.GetAll().OrderBy(o => o.Id).ToArray();

            Assert.That(result.Count, Is.EqualTo(2));
            OrderCreateAndAssert.DefaultOrderAssert(result[0], 1, 1);
            OrderCreateAndAssert.DefaultOrderAssert(result[1], 2, 2);
        }

        [Test]
        public void Add_AndGetAll_AddsOrder_ReturnsAddedOrder()
        {
            var order = OrderCreateAndAssert.CreateNewOrderForTest();
            order.OrderedCarId = 1;
            _csvOrderRepository.Add(order);

            var result = _csvOrderRepository.GetAll();

            Assert.That(result.Count, Is.EqualTo(1));
            OrderCreateAndAssert.DefaultOrderAssert(result.First(), 1);
        }

        [Test]
        public void GetAll_ReturnsEmptyList_WhenNoData()
        {
            var result = _csvOrderRepository.GetAll();

            Assert.IsEmpty(result);
        }

        [Test]
        public void Get_ReturnsNull_WhenNoData()
        {
            var fetchedOrder = _csvOrderRepository.Get(999);

            Assert.IsNull(fetchedOrder);
        }

        [Test]
        public void Get_ReturnsNull_ForNonexistentOrder()
        {
            var order = OrderCreateAndAssert.CreateNewOrderForTest();
            _csvOrderRepository.Add(order);

            var fetchedOrder = _csvOrderRepository.Get(999);

            Assert.IsNull(fetchedOrder);
        }

        [Test]
        public void Get_ReturnsCorrectOrder()
        {
            var order = OrderCreateAndAssert.CreateNewOrderForTest();
            _csvOrderRepository.Add(order);

            var fetchedOrder = _csvOrderRepository.Get(1);

            OrderCreateAndAssert.DefaultOrderAssert(fetchedOrder, 1);
        }

        [Test]
        public void Update_DoesNotThrowException_WhenNoData()
        {
            var updatedOrder = new Order { Id = 1, OrderedCarId = 1 };

            Assert.DoesNotThrow(() => _csvOrderRepository.Update(updatedOrder));
        }

        [Test]
        public void Update_DoesNotThrowException_WhenNoSuchId()
        {
            var order = OrderCreateAndAssert.CreateNewOrderForTest();
            _csvOrderRepository.Add(order);
            var updatedOrder = new Order { Id = 999, OrderedCarId = 999 };

            Assert.DoesNotThrow(() => _csvOrderRepository.Update(updatedOrder));
        }

        [Test]
        public void Update_UpdatesOrder()
        {
            var order = OrderCreateAndAssert.CreateNewOrderForTest();
            _csvOrderRepository.Add(order);
            var updatedOrder = OrderCreateAndAssert.CreateNewOrderForTest();
            updatedOrder.OrderedCarId = 2; // Изменение для проверки обновления
            _csvOrderRepository.Update(updatedOrder);

            var fetchedOrder = _csvOrderRepository.Get(1);

            OrderCreateAndAssert.DefaultOrderAssert(fetchedOrder, 2);
        }

        [Test]
        public void Delete_DoesNotThrowException_WhenNoData()
        {
            Assert.DoesNotThrow(() => _csvOrderRepository.Delete(1));
        }

        [Test]
        public void Delete_DoesNotThrowException_WhenNoSuchId()
        {
            var order = OrderCreateAndAssert.CreateNewOrderForTest();
            _csvOrderRepository.Add(order);

            Assert.DoesNotThrow(() => _csvOrderRepository.Delete(999));
        }

        [Test]
        public void Delete_RemovesOrder()
        {
            var order = OrderCreateAndAssert.CreateNewOrderForTest();
            _csvOrderRepository.Add(order);

            _csvOrderRepository.Delete(1);

            var result = _csvOrderRepository.GetAll();

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