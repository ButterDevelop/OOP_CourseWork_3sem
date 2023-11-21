using DB_CourseWork.DbRepositories.Sql;
using DB_CourseWork.Models;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using UnitTests.ObjectsCreatesAndAsserts;

namespace UnitTests.Sql
{
    [TestFixture]
    public class SqlOrderRepositoryTests
    {
        private SqlClientRepository  _sqlClientRepository;
        private SqlPaymentRepository _sqlPaymentRepository;
        private SqlCarRepository     _sqlCarRepository;
        private SqlOrderRepository   _sqlOrderRepository;
        private string? _sqlConnectionString;

        [SetUp]
        public void Setup()
        {
            var builder = new ConfigurationBuilder()
                              .SetBasePath(Directory.GetCurrentDirectory())
                              .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            IConfiguration _configuration = builder.Build();

            _sqlConnectionString = _configuration["ConnectionStrings:SqlTestConnectionString"];

            // Создать тестовую базу данных
            CreateTestDatabase();

            _sqlClientRepository = new SqlClientRepository(_sqlConnectionString);
            _sqlPaymentRepository = new SqlPaymentRepository(_sqlConnectionString);
            _sqlCarRepository = new SqlCarRepository(_sqlConnectionString);
            _sqlOrderRepository = new SqlOrderRepository(_sqlConnectionString);

            AddNecessaryData();
        }

        [Test]
        public void Add_DoesNotThrowException_AndChangesId_WhenDuplicate()
        {
            var order = OrderCreateAndAssert.CreateNewOrderForTest();
            _sqlOrderRepository.Add(order);

            int oldMaxId = _sqlOrderRepository.GetAll().Max(o => o.Id);

            var orderDuplicate = OrderCreateAndAssert.CreateNewOrderForTest();
            Assert.DoesNotThrow(() => _sqlOrderRepository.Add(orderDuplicate));

            var addedDuplicate = _sqlOrderRepository.GetAll().FirstOrDefault(o => o.Id != order.Id);

            Assert.NotNull(addedDuplicate);
            Assert.That(addedDuplicate.Id, Is.EqualTo(oldMaxId + 1));
        }

        [Test]
        public void Add_ThrowsException_WhenAddNull()
        {
            Assert.Throws<NullReferenceException>(() => _sqlOrderRepository.Add(null));
        }

        [Test]
        public void Add_AndGetAll_AddsFewOrders_ReturnsAllAddedOrders()
        {
            var orderOne = OrderCreateAndAssert.CreateNewOrderForTest();
            orderOne.OrderedCarId = 1;
            _sqlOrderRepository.Add(orderOne);

            var orderTwo = OrderCreateAndAssert.CreateNewOrderForTest();
            orderTwo.OrderedCarId = 2;
            _sqlOrderRepository.Add(orderTwo);

            var result = _sqlOrderRepository.GetAll().OrderBy(o => o.Id).ToArray();

            Assert.That(result.Length, Is.EqualTo(2));
            OrderCreateAndAssert.DefaultOrderAssert(result[0], 1, 1);
            OrderCreateAndAssert.DefaultOrderAssert(result[1], 2, 2);
        }

        [Test]
        public void Add_AndGetAll_AddsOrder_ReturnsAddedOrder()
        {
            var order = OrderCreateAndAssert.CreateNewOrderForTest();
            order.OrderedCarId = 1;
            _sqlOrderRepository.Add(order);

            var result = _sqlOrderRepository.GetAll();

            Assert.That(result.Count, Is.EqualTo(1));
            OrderCreateAndAssert.DefaultOrderAssert(result.First(), 1);
        }

        [Test]
        public void GetAll_ReturnsEmptyList_WhenNoData()
        {
            var result = _sqlOrderRepository.GetAll();

            Assert.IsEmpty(result);
        }

        [Test]
        public void Get_ReturnsNull_WhenNoData()
        {
            var fetchedOrder = _sqlOrderRepository.Get(999);

            Assert.IsNull(fetchedOrder);
        }

        [Test]
        public void Get_ReturnsNull_ForNonexistentOrder()
        {
            var order = OrderCreateAndAssert.CreateNewOrderForTest();
            _sqlOrderRepository.Add(order);

            var fetchedOrder = _sqlOrderRepository.Get(999);

            Assert.IsNull(fetchedOrder);
        }

        [Test]
        public void Get_ReturnsCorrectOrder()
        {
            var order = OrderCreateAndAssert.CreateNewOrderForTest();
            _sqlOrderRepository.Add(order);

            var fetchedOrder = _sqlOrderRepository.Get(1);

            OrderCreateAndAssert.DefaultOrderAssert(fetchedOrder, 1);
        }

        [Test]
        public void Update_DoesNotThrowException_WhenNoData()
        {
            var updatedOrder = new Order { Id = 1, OrderedCarId = 1 };

            Assert.DoesNotThrow(() => _sqlOrderRepository.Update(updatedOrder));
        }

        [Test]
        public void Update_DoesNotThrowException_WhenNoSuchId()
        {
            var order = OrderCreateAndAssert.CreateNewOrderForTest();
            _sqlOrderRepository.Add(order);
            var updatedOrder = new Order { Id = 999, OrderedCarId = 999 };

            Assert.DoesNotThrow(() => _sqlOrderRepository.Update(updatedOrder));
        }

        [Test]
        public void Update_UpdatesOrder()
        {
            var order = OrderCreateAndAssert.CreateNewOrderForTest();
            _sqlOrderRepository.Add(order);
            var updatedOrder = OrderCreateAndAssert.CreateNewOrderForTest();
            updatedOrder.OrderedCarId = 2; // Изменение для проверки обновления
            _sqlOrderRepository.Update(updatedOrder);

            var fetchedOrder = _sqlOrderRepository.Get(1);

            OrderCreateAndAssert.DefaultOrderAssert(fetchedOrder, 2);
        }

        [Test]
        public void Delete_DoesNotThrowException_WhenNoData()
        {
            Assert.DoesNotThrow(() => _sqlOrderRepository.Delete(1));
        }

        [Test]
        public void Delete_DoesNotThrowException_WhenNoSuchId()
        {
            var order = OrderCreateAndAssert.CreateNewOrderForTest();
            _sqlOrderRepository.Add(order);

            Assert.DoesNotThrow(() => _sqlOrderRepository.Delete(999));
        }

        [Test]
        public void Delete_RemovesOrder()
        {
            var order = OrderCreateAndAssert.CreateNewOrderForTest();
            _sqlOrderRepository.Add(order);

            _sqlOrderRepository.Delete(1);

            var result = _sqlOrderRepository.GetAll();

            Assert.IsEmpty(result);
        }

        [TearDown]
        public void TearDown()
        {
            // Очистить тестовую базу данных
            DestroyTestDatabase();
        }

        private void CreateTestDatabase()
        {
            using (var connection = new SqlConnection(_sqlConnectionString))
            {
                connection.Open();

                string createUsersTable = @"CREATE TABLE Users (
                                               Id INT PRIMARY KEY IDENTITY,
                                               Username NVARCHAR(50) NOT NULL,
                                               Salt NVARCHAR(255) NOT NULL,
                                               HashedPassword NVARCHAR(255) NOT NULL,
                                               Fullname NVARCHAR(100),
                                               Email NVARCHAR(100),
                                               Phone NVARCHAR(20),
                                               Role INT NOT NULL,
                                               IsAccountSetupCompleted BIT NOT NULL,
                                               AccountDeactivated BIT NOT NULL
                                           );";

                string createClientsTable = @"CREATE TABLE Clients (
                                                UserId INT PRIMARY KEY,
                                                DriverLicense NVARCHAR(50),
                                                Passport NVARCHAR(50),
                                                CardNumber NVARCHAR(50),
                                                Balance FLOAT,
                                                SumRating FLOAT,
                                                OrdersCount INT,
                                                FOREIGN KEY (UserId) REFERENCES Users(Id)
                                            );";

                using (var command = new SqlCommand(createUsersTable, connection))
                {
                    command.ExecuteNonQuery();
                }

                using (var command = new SqlCommand(createClientsTable, connection))
                {
                    command.ExecuteNonQuery();
                }

                string createPaymentsTable = @"CREATE TABLE Payments (
                                                 Id INT PRIMARY KEY IDENTITY,
                                                 CreatedTime DATETIME NOT NULL,
                                                 PayedTime DATETIME,
                                                 UserId INT,
                                                 Cost FLOAT NOT NULL,
                                                 IsPayed BIT NOT NULL,
                                                 IsRefunded BIT NOT NULL,
                                                 FOREIGN KEY (UserId) REFERENCES Users(Id)
                                             );";

                using (var command = new SqlCommand(createPaymentsTable, connection))
                {
                    command.ExecuteNonQuery();
                }

                string createCarsTable = @"CREATE TABLE Cars (
                                               Id INT PRIMARY KEY IDENTITY,
                                               Brand NVARCHAR(50) NOT NULL,
                                               Model NVARCHAR(50) NOT NULL,
                                               CarLicensePlate NVARCHAR(50) NOT NULL,
                                               PricePerHour FLOAT NOT NULL,
                                               ProductionYear DATETIME,
                                               BuyTime DATETIME,
                                               LastServiceTime DATETIME,
                                               LocationX FLOAT,
                                               LocationY FLOAT,
                                               IsHidden BIT NOT NULL
                                           );";

                using (var command = new SqlCommand(createCarsTable, connection))
                {
                    command.ExecuteNonQuery();
                }

                string createOrdersTable = @"CREATE TABLE Orders (
                                                 Id INT PRIMARY KEY IDENTITY,
                                                 OrderCreatedTime DATETIME NOT NULL,
                                                 OrderBookingTime DATETIME,
                                                 OrderCancelledTime DATETIME,
                                                 OrderedCarId INT,
                                                 OrderedHours INT NOT NULL,
                                                 OrderPaymentId INT,
                                                 OrderExtendPaymentsIdsString NVARCHAR(255) NULL,
                                                 IsCancelled BIT NOT NULL,
                                                 FOREIGN KEY (OrderedCarId) REFERENCES Cars(Id),
                                                 FOREIGN KEY (OrderPaymentId) REFERENCES Payments(Id)
                                             );";

                using (var command = new SqlCommand(createOrdersTable, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        private void DestroyTestDatabase()
        {
            using (var connection = new SqlConnection(_sqlConnectionString))
            {
                connection.Open();

                string dropOrdersTable = "DROP TABLE IF EXISTS Orders; DROP TABLE IF EXISTS Cars; DROP TABLE IF EXISTS Payments; " +
                                         "DROP TABLE IF EXISTS Clients; DROP TABLE IF EXISTS Users;";

                using (var command = new SqlCommand(dropOrdersTable, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        private void AddNecessaryData()
        {
            _sqlClientRepository.Add(ClientCreateAndAssert.CreateNewClientForTest());

            _sqlPaymentRepository.Add(PaymentCreateAndAssert.CreateNewPaymentForTest());

            _sqlCarRepository.Add(CarCreateAndAssert.CreateNewCarForTest());
            _sqlCarRepository.Add(CarCreateAndAssert.CreateNewCarForTest());
        }
    }
}
