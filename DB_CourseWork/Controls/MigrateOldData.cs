using DB_CourseWork.Models;
using Newtonsoft.Json;
using OOP_CourseWork.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace DB_CourseWork.Controls
{
    class MigrateOldData
    {
        private static string oldDBString = "";
        private static JsonSerializerSettings settingsJSON = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };

        public static List<UserOld> Users = new List<UserOld>();                       //simple
        public static List<CarOld> Cars = new List<CarOld>();                         //complicated
        public static List<OrderOld> Orders = new List<OrderOld>();                     //complicated
        public static List<PaymentOld> Payments = new List<PaymentOld>();                 //complicated
        public static List<BankTransactionOld> BankTransactions = new List<BankTransactionOld>(); //simple
        public static List<ServiceReportOld> ServiceReports = new List<ServiceReportOld>();     //complicated

        public static bool LoadJSON()
        {
            try
            {
                oldDBString = File.ReadAllText("db_UNENCRYPTED.json");
                JSON_export.Root deserialized = JsonConvert.DeserializeObject<JSON_export.Root>(oldDBString, settingsJSON);

                Users = deserialized.Users;
                Cars = deserialized.Cars;
                Orders = deserialized.Orders;
                Payments = deserialized.Payments;
                BankTransactions = deserialized.BankTransactions;
                ServiceReports = deserialized.ServiceReports;

                // Исправляем проблему дублирования. Присваиваем объекты из массива, новосозданные (дублированные) объекты удаляются.
                foreach (var a in Orders)
                {
                    a.OrderedCar = Cars[a.OrderedCar.Id];
                    a.OrderPayment = Payments[a.OrderPayment.Id];
                }
                foreach (var a in Payments)
                {
                    a.User = (ClientOld)Users[a.User.Id];
                }
                foreach (var a in ServiceReports)
                {
                    a.ServicedCar = Cars[a.ServicedCar.Id];
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void Migrate()
        {
            foreach (var user in Users)
            {
                if (user.Role == RolesContainer.Client)
                {
                    var client = (ClientOld)user;
                    var clientNew = new Client
                    {
                        Id = client.Id + 1,
                        UserName = client.UserName,
                        Email = client.Email,
                        AccountDeactivated = client.AccountDeactivated,
                        Balance = client.Balance,
                        CardNumber = client.CardNumber,
                        DriverLicense = client.DriverLicense,
                        FullName = client.FullName,
                        HashedPassword = client.HashedPassword,
                        IsAccountSetupCompleted = client.IsAccountSetupCompleted,
                        OrderCount = client.OrderCount,
                        Passport = client.Passport,
                        Phone = client.Phone,
                        SumRating = client.SumRating,
                        Role = client.Role,
                        Salt = client.Salt
                    };

                    DatabaseContext.DbContext.Clients.Add(clientNew);
                }
                else
                if (user.Role == RolesContainer.Employee)
                {
                    var employee = (EmployeeOld)user;
                    var employeeNew = new Employee
                    {
                        Id = employee.Id + 1,
                        UserName = employee.UserName,
                        Email = employee.Email,
                        AccountDeactivated = employee.AccountDeactivated,
                        FullName = employee.FullName,
                        HashedPassword = employee.HashedPassword,
                        IsAccountSetupCompleted = employee.IsAccountSetupCompleted,
                        Phone = employee.Phone,
                        Role = employee.Role,
                        Salt = employee.Salt,

                        BankAccountNumber = employee.BankAccountNumber,
                        DateFired = employee.DateFired.Year < 1950 ? new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc) : employee.DateFired.ToUniversalTime(),
                        DateHired = employee.DateHired.Year < 1950 ? new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc) : employee.DateHired.ToUniversalTime(),
                        DateLastSalaryPayed = employee.DateLastSalaryPayed.Year < 1950 ? new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc) : employee.DateLastSalaryPayed.ToUniversalTime(),
                        DaysWorked = employee.DaysWorked,
                        IsWorkingNow = employee.IsWorkingNow,
                        OrderProccessed = employee.OrderProccessed,
                        TotalSalaryPayed = employee.TotalSalaryPayed
                    };

                    DatabaseContext.DbContext.Employees.Add(employeeNew);
                }
                else
                if (user.Role == RolesContainer.Admin)
                {
                    var admin = (AdminOld)user;
                    var adminNew = new Admin
                    {
                        Id = admin.Id + 1,
                        UserName = admin.UserName,
                        Email = admin.Email,
                        AccountDeactivated = admin.AccountDeactivated,
                        FullName = admin.FullName,
                        HashedPassword = admin.HashedPassword,
                        IsAccountSetupCompleted = admin.IsAccountSetupCompleted,
                        Phone = admin.Phone,
                        Role = admin.Role,
                        Salt = admin.Salt,

                        TotalCarsServiced = admin.TotalCarsServiced
                    };

                    DatabaseContext.DbContext.Admins.Add(adminNew);
                }
            }

            foreach (var car in Cars)
            {
                var newCar = new Car
                {
                    Id = car.Id + 1,
                    Brand = car.Brand,
                    BuyTime = car.BuyTime.Year < 1950 ? new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc) : car.BuyTime.ToUniversalTime(),
                    CarLicensePlate = car.CarLicensePlate,
                    IsHidden = car.IsHidden,
                    LastServiceTime = car.LastServiceTime.Year < 1950 ? new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc) : car.LastServiceTime.ToUniversalTime(),
                    LocationX = car.LocationX,
                    LocationY = car.LocationY,
                    Model = car.Model,
                    PricePerHour = car.PricePerHour,
                    ProductionYear = car.ProductionYear.Year < 1950 ? new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc) : car.ProductionYear.ToUniversalTime().AddHours(2)
                };

                DatabaseContext.DbContext.Cars.Add(newCar);
            }

            foreach (var payment in Payments)
            {
                var newPayment = new Payment
                {
                    Id = payment.Id + 1,
                    Cost = payment.Cost,
                    CreatedTime = payment.CreatedTime.Year < 1950 ? new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc) : payment.CreatedTime.ToUniversalTime(),
                    IsPayed = payment.IsPayed,
                    IsRefunded = payment.IsRefunded,
                    PayedTime = payment.PayedTime.Year < 1950 ? new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc) : payment.PayedTime.ToUniversalTime(),
                    UserId = payment.User.Id + 1
                };

                DatabaseContext.DbContext.Payments.Add(newPayment);
            }

            foreach (var order in Orders)
            {
                List<int> OrderExtendPaymentsIds = new List<int>();
                foreach (var payment in order.OrderExtendPayments)
                {
                    OrderExtendPaymentsIds.Add(payment.Id + 1);
                }

                var newOrder = new Order
                {
                    Id = order.Id + 1,
                    IsCancelled = order.IsCancelled,
                    OrderBookingTime   = order.OrderBookingTime.Year < 1950 ? new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc) : order.OrderBookingTime.ToUniversalTime(),
                    OrderCancelledTime = order.OrderCancelledTime.Year < 1950 ? new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc) : order.OrderCancelledTime.ToUniversalTime(),
                    OrderCreatedTime   = order.OrderCreatedTime.Year < 1950 ? new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc) : order.OrderCreatedTime.ToUniversalTime(),
                    OrderExtendPaymentsIdsString = Order.GetStringFromOrderExtendPaymentsIds(OrderExtendPaymentsIds),
                    OrderedCarId = order.OrderedCar.Id + 1,
                    OrderHours = order.OrderHours,
                    OrderPaymentId = order.OrderPayment.Id + 1
                };

                DatabaseContext.DbContext.Orders.Add(newOrder);
            }

            HashSet<int> bankTransactionsIds = new HashSet<int>();
            foreach (var transaction in BankTransactions)
            {
                var newTransaction = new BankTransaction
                {
                    Id = transaction.Id + 1,
                    CancelledTime = transaction.CancelledTime.Year < 1950 ? new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc) : transaction.CancelledTime.ToUniversalTime(),
                    CreatedTime = transaction.CreatedTime.Year < 1950 ? new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc) : transaction.CreatedTime.ToUniversalTime(),
                    FromCardNumberOrBankAccountNumber = transaction.FromCardNumberOrBankAccountNumber,
                    IsCancelled = transaction.IsCancelled,
                    IsFinished = transaction.IsFinished,
                    PayedTime = transaction.PayedTime.Year < 1950 ? new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc) : transaction.PayedTime.ToUniversalTime(),
                    ToCardNumberOrBankAccountNumber = transaction.ToCardNumberOrBankAccountNumber,
                    TotalAmount = transaction.TotalAmount,
                    TotalTries = transaction.TotalTries,
                    UserId = null
                };
                if (transaction.User != null)
                {
                    newTransaction.UserId = transaction.User.Id + 1;
                }

                if (bankTransactionsIds.Contains(transaction.Id)) continue;
                bankTransactionsIds.Add(transaction.Id);

                DatabaseContext.DbContext.BankTransactions.Add(newTransaction);
            }

            foreach (var report in ServiceReports)
            {
                var newReport = new ServiceReport
                {
                    Id = report.Id + 1,
                    AdditionalCost = report.AdditionalCost,
                    EmployeeReport = report.EmployeeReport == null ? string.Empty : report.EmployeeReport,
                    Description = report.Description,
                    FinishedDate = report.FinishedDate.Year < 1950 ? new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc) : report.FinishedDate.ToUniversalTime(),
                    IsFinished = report.IsFinished,
                    IsStarted = report.IsStarted,
                    PlannedCompletionDays = report.PlannedCompletionDays,
                    ServicedCarId = report.ServicedCar.Id + 1,
                    StartedDate = report.StartedDate.Year < 1950 ? new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc) : report.StartedDate.ToUniversalTime(),
                    WorkerId = null
                };
                if (report.Worker != null)
                {
                    newReport.WorkerId = report.Worker.Id + 1;
                }

                DatabaseContext.DbContext.ServiceReports.Add(newReport);
            }

        }
    }
}