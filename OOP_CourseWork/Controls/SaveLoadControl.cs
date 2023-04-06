using Newtonsoft.Json;
using OOP_CourseWork.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_CourseWork.Controls
{
    internal class SaveLoadControl
    {
        public static readonly string DBPath = "db.json";
        public static readonly string UsersDBPath = "users.csv";
        public static readonly string BrandsDBPath = "brands.csv";
        public static readonly string CarsDBPath = "cars.csv";
        public static readonly string OrdersDBPath = "orders.csv";
        public static readonly string PaymentsDBPath = "payments.csv";
        public static readonly string BankTransactionsDBPath = "banktransactions.csv";
        public static readonly string ServiceReportsDBPath = "banktransactions.csv";
        public static List<User>            Users = new List<User>();                       //simple
        public static List<CarBrand>        CarBrands = new List<CarBrand>();               //simple
        public static List<Car>             Cars = new List<Car>();                         //complicated
        public static List<Order>           Orders = new List<Order>();                     //complicated
        public static List<Payment>         Payments = new List<Payment>();                 //complicated
        public static List<BankTransaction> BankTransactions = new List<BankTransaction>(); //simple
        public static List<ServiceReport>   ServiceReports = new List<ServiceReport>();     //complicated
        public static JsonSerializerSettings settingsJSON = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
        public static User CurrentUser = null;

        public static bool SaveJSON()
        {
            try
            {
                JSON_export.Root export = new JSON_export.Root();
                export.Users = Users;
                export.CarBrands = CarBrands;
                export.Cars = Cars;
                export.Orders = Orders;
                export.Payments = Payments;
                export.BankTransactions = BankTransactions;
                export.ServiceReports = ServiceReports;

                var json = JsonConvert.SerializeObject(export, settingsJSON);
                File.WriteAllText(DBPath, json);

                return true;
            } catch
            {
                return false;
            }
        }

        public static bool LoadJSON()
        {
            try
            {
                string data = File.ReadAllText(DBPath);
                JSON_export.Root deserialized = JsonConvert.DeserializeObject<JSON_export.Root>(data, settingsJSON);

                Users = deserialized.Users;
                CarBrands = deserialized.CarBrands;
                Cars = deserialized.Cars;
                Orders = deserialized.Orders;
                Payments = deserialized.Payments;
                BankTransactions = deserialized.BankTransactions;
                ServiceReports = deserialized.ServiceReports;

                // Исправляем проблему дублирования. Присваиваем объекты из массива, новосозданные (дублированные) объекты удаляются.
                foreach (var a in Cars)
                {
                    a.Brand = CarBrands[a.Brand.Id];
                }
                foreach (var a in Orders)
                {
                    a.OrderedCar = Cars[a.OrderedCar.Id];
                    a.OrderPayment = Payments[a.OrderPayment.Id];
                }
                foreach (var a in Payments)
                {
                    a.User = (Client)Users[a.User.Id];
                }
                foreach (var a in ServiceReports)
                {
                    a.ServicedCar = Cars[a.ServicedCar.Id];
                }

                return true;
            } catch
            {
                return false;
            }
        }
    }
}
