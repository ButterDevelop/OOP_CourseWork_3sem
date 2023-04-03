using OOP_CourseWork.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_CourseWork.Models
{
    internal class JSON_export
    {
        public class BankTransaction
        {
            public int Id { get; set; }
            public string FromCardNumberOrBankAccountNumber { get; set; }
            public string ToCardNumberOrBankAccountNumber { get; set; }
            public DateTime CreatedTime { get; set; }
            public DateTime PayedTime { get; set; }
            public DateTime CancelledTime { get; set; }
            public double TotalAmount { get; set; }
            public int TotalTries { get; set; }
            public bool IsFinished { get; set; }
            public bool IsCancelled { get; set; }
        }

        public class CarBrand
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
        }

        public class Car
        {
            public int Id { get; set; }
            public CarBrand Brand { get; set; }
            public string Model { get; set; }
            public double PricePerHour { get; set; }
            public DateTime ProductionYear { get; set; }
            public DateTime BuyTime { get; set; }
            public DateTime LastServiceTime { get; set; }
            public bool IsOnServiceNow { get; set; }
        }

        public class Order
        {
            public int Id { get; set; }
            public DateTime OrderCreatedTime { get; set; }
            public DateTime OrderPayedTime { get; set; }
            public DateTime OrderBookingTime { get; set; }
            public DateTime OrderReturnedTime { get; set; }
            public DateTime OrderCancelledTime { get; set; }
            public Car OrderedCar { get; set; }
            public int OrderHours { get; set; }
            public Payment OrderPayment { get; set; }
            public bool IsCancelled { get; set; }
        }

        public class Payment
        {
            public int Id { get; set; }
            public DateTime CreatedTime { get; set; }
            public DateTime PayedTime { get; set; }
            public Client User { get; set; }
            public double Cost { get; set; }
            public bool IsPayed { get; set; }
            public bool IsRefunded { get; set; }
        }

        public class Root
        {
            public List<User> Users { get; set; }
            public List<CarBrand> CarBrands { get; set; }
            public List<Car> Cars { get; set; }
            public List<Order> Orders { get; set; }
            public List<Payment> Payments { get; set; }
            public List<BankTransaction> BankTransactions { get; set; }
            public List<ServiceReport> ServiceReports { get; set; }
        }

        public class ServicedCar
        {
            public int Id { get; set; }
            public CarBrand Brand { get; set; }
            public string Model { get; set; }
            public double PricePerHour { get; set; }
            public DateTime ProductionYear { get; set; }
            public DateTime BuyTime { get; set; }
            public DateTime LastServiceTime { get; set; }
            public bool IsOnServiceNow { get; set; }
        }

        public class ServiceReport
        {
            public int Id { get; set; }
            public string Description { get; set; }
            public double Cost { get; set; }
            public DateTime StartedDate { get; set; }
            public DateTime FinishedDate { get; set; }
            public bool IsFinished { get; set; }
            public int PlannedCompletionDays { get; set; }
            public ServicedCar ServicedCar { get; set; }
        }

        public class Client
        {
            public int Id { get; set; }
            public string UserName { get; set; }
            public string Salt { get; set; }
            public string HashedPassword { get; set; }
            public string FullName { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public int Role { get; set; }
            public bool AccountDeactivated { get; set; }
            public string DriverLicense { get; set; }
            public string Passport { get; set; }
            public string CardNumber { get; set; }
            public double Balance { get; set; }
            public double SumRating { get; set; }
            public int OrderCount { get; set; }
            public double Rating { get; set; }
        }

        public class Employee
        {
            public int Id { get; set; }
            public string UserName { get; set; }
            public string Salt { get; set; }
            public string HashedPassword { get; set; }
            public string FullName { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public int Role { get; set; }
            public bool AccountDeactivated { get; set; }
            public int OrderProccessed { get; set; }
            public int HoursWorked { get; set; }
            public DateTime DateHired { get; set; }
            public DateTime DateFired { get; set; }
            public DateTime DateLastSalaryPayed { get; set; }
            public string BankAccountNumber { get; set; }
            public bool IsWorkingNow { get; set; }
            public double SalaryPerHour { get; set; }
            public double Salary { get; set; }
        }

        public class Admin
        {
            public int Id { get; set; }
            public string UserName { get; set; }
            public string Salt { get; set; }
            public string HashedPassword { get; set; }
            public string FullName { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public int Role { get; set; }
            public bool AccountDeactivated { get; set; }
            public int TotalCarServiced { get; set; }
        }
    }

    internal class JSON_export2
    {
        public class Root
        {
            public List<User> Users { get; set; }
            public List<CarBrand> CarBrands { get; set; }
            public List<Car> Cars { get; set; }
            public List<Order> Orders { get; set; }
            public List<Payment> Payments { get; set; }
            public List<BankTransaction> BankTransactions { get; set; }
            public List<ServiceReport> ServiceReports { get; set; }
        }
    }
}
