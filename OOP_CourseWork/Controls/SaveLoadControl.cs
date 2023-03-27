using OOP_CourseWork.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OOP_CourseWork.Controls
{
    internal class SaveLoadControl
    {
        public static readonly string UsersDBPath = "users.csv";
        public static readonly string BrandsDBPath = "brands.csv";
        public static readonly string CarsDBPath = "cars.csv";
        public static List<User>            Users = new List<User>();
        public static List<CarBrand>        CarBrands = new List<CarBrand>();
        public static List<Car>             Cars = new List<Car>();
        public static List<Order>           Orders = new List<Order>();
        public static List<Payment>         Payments = new List<Payment>();
        public static List<BankTransaction> BankTransactions = new List<BankTransaction>();

        public static bool SaveUsers()
        {
            string result = "";
            foreach (User user in Users)
            {
                if (user == null || string.IsNullOrEmpty(user.UserName)) continue;
                if (user is Admin) result += ((Admin)user).ToString();
                else
                if (user is Employee) result += ((Employee)user).ToString();
                else
                if (user is Client) result += ((Client)user).ToString();
                else continue;
                result += Environment.NewLine;
            }
            File.WriteAllText(UsersDBPath, result);
            return true;
        }

        public static bool LoadUsers()
        {
            if (!File.Exists(UsersDBPath)) return false;

            List<User> users = new List<User>();
            string[] lines = File.ReadAllLines(UsersDBPath);
            foreach (var line in lines)
            {
                var splited = line.Split(new char[1] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                switch (splited[0])
                {
                    case "Client"  : break;
                    case "Employee": break;
                    case "Admin"   : break;
                    default: continue;
                }
                try
                {
                    string role = splited[0];
                    int id = int.Parse(splited[1]);
                    string username = splited[2];
                    string salt = splited[3];
                    string hashedPassword = splited[4];
                    string fullname = splited[5];
                    string email = splited[6];
                    string phone = splited[7];
                    bool accountDeactivated = bool.Parse(splited[8]);

                    Regex validatePhone = new Regex("^\\+?[1-9][0-9]{7,14}$");
                    Regex validateEmail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

                    if (id < 0 || !validatePhone.IsMatch(phone) || !validateEmail.IsMatch(email) || Convert.FromBase64String(hashedPassword).Length != CryptographyControl.bytesSize) continue;
                    byte[] temp = Convert.FromBase64String(salt);

                    if (role == "Client")
                    {
                        string driverLicense = splited[9];
                        string passport = splited[10];
                        string cardNumber = splited[11];
                        double balance = double.Parse(splited[12]);
                        double sumRating = double.Parse(splited[13]);
                        int ordersCount = int.Parse(splited[14]);

                        if (balance < 0 || sumRating < 0 || ordersCount < 0) continue;

                        Client client = new Client(id, username, salt, hashedPassword, fullname, email, phone, accountDeactivated, 
                                                   driverLicense, passport, cardNumber, balance, sumRating, ordersCount);
                        users.Add(client);
                    } else 
                    if (role == "Employee")
                    {
                        int ordersProccessed = int.Parse(splited[9]);
                        int hoursWorked = int.Parse(splited[10]);
                        DateTime dateHired = DateTime.Parse(splited[11]);
                        DateTime dateFired = DateTime.Parse(splited[12]);
                        double salaryPerHour = double.Parse(splited[13]);
                        bool isWorkingNow = bool.Parse(splited[14]);

                        if (ordersProccessed < 0 || hoursWorked < 0) continue;

                        Employee employee = new Employee(id, username, salt, hashedPassword, fullname, email, phone, accountDeactivated, 
                                                         ordersProccessed, hoursWorked, dateHired, dateFired, salaryPerHour, isWorkingNow);
                        users.Add(employee);
                    } else 
                    if (role == "Admin")
                    {
                        Admin admin = new Admin(id, username, salt, hashedPassword, fullname, email, phone, accountDeactivated);
                        users.Add(admin);
                    }
                }
                catch
                {
                    continue;
                }
            }

            Users = users;

            return true;
        }
    }
}
