using OOP_CourseWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_CourseWork.Controls
{
    internal class UtilsControl
    {
        public enum PasswordScore
        {
            Blank = 0,
            VeryWeak = 1,
            Weak = 2,
            Medium = 3,
            Strong = 4,
            VeryStrong = 5
        }

        public static PasswordScore CheckPasswordStrength(string password)
        {
            int score = 0;

            if (password.Length < 1) return PasswordScore.Blank;
            if (password.Length < 4) return PasswordScore.Weak;

            if (password.Length >= 8) ++score;
            if (password.Length >= 12) ++score;
            if (Regex.Match(password, "\\d+", RegexOptions.ECMAScript).Success) ++score;
            if (Regex.Match(password, "[a-zа-я]", RegexOptions.ECMAScript).Success && 
                Regex.Match(password, "[A-ZА-Я]", RegexOptions.ECMAScript).Success) ++score;
            if (Regex.Match(password, "[!@#$%^&*?_~.,\\-£+()]", RegexOptions.ECMAScript).Success) ++score;

            return (PasswordScore)score;
        }

        public static void StartNeccesaryForm()
        {
            SaveLoadControl.LoadJSON();

            new Thread(() => SaveLoadControl.SaveWithCheck()).Start();
            Thread.Sleep(250);

            Application.Run(new LoginForm());

            if (SaveLoadControl.CurrentUser is Client)
            {
                Application.Run(new ClientForm());
            }
            else
            if (SaveLoadControl.CurrentUser is Employee)
            {
                //Application.Run(new EmployeeForm());
            }
            else
            if (SaveLoadControl.CurrentUser is Admin)
            {
                Application.Run(new AdminForm());
            }
            else
            {
                SaveLoadControl.SaveJSON();
                Environment.Exit(0);
            }
        }

        public static void GetRandomCoords(out double locationX, out double locationY)
        {
            const int arr_length = 5;
            double[] x_s = new double[arr_length] { 52.405456, 52.406755, 52.407157, 52.405168, 52.406949 };
            double[] y_s = new double[arr_length] { 30.937795, 30.936868, 30.939400, 30.940515, 30.935177 };

            Random random = new Random(Guid.NewGuid().GetHashCode());
            int index = random.Next(arr_length);

            locationX = x_s[index];
            locationY = y_s[index];
        }


        public static void CreateSomeData()
        {
            SaveLoadControl.Cars.Add(new Car(0, "Мицубиси", "Аутландер", "4718 AX-3", 10,
                                     new DateTime(1980, 10, 11), new DateTime(2023, 01, 01), new DateTime(2023, 02, 01), 52.4057051, 30.9380874));
            SaveLoadControl.Cars.Add(new Car(1, "Вольгсфаген", "Поло", "5819 AA-3", 20,
                                     new DateTime(1990, 09, 03), new DateTime(2023, 01, 01), new DateTime(2023, 02, 02), 52.4057052, 30.9380875));
            SaveLoadControl.Cars.Add(new Car(2, "Джили", "Кулрэй", "1523 IP-3", 30,
                                     new DateTime(2000, 08, 04), new DateTime(2023, 01, 01), new DateTime(2023, 02, 03), 52.4057053, 30.9380876));

            SaveLoadControl.ServiceReports.Add(new ServiceReport(0, "Плановая проверка", SaveLoadControl.Cars[0]));
            SaveLoadControl.ServiceReports.Add(new ServiceReport(1, "Плановая проверка", SaveLoadControl.Cars[1]));
            SaveLoadControl.ServiceReports.Add(new ServiceReport(2, "Плановая проверка", SaveLoadControl.Cars[2]));

            SaveLoadControl.Users.Add(new Client(0, "User1", "Password1", "Иванов Иван Иванович", "user1@gmail.com", "+375291111111",
                                                 "AA1746354", "HB31865832", "4155 0253 3531 4351"));
            SaveLoadControl.Users.Add(new Employee(1, "Employee2", "Password2", "Петров Пётр Петрович", "employee2@gmail.com", "+375292222222"));
            SaveLoadControl.Users.Add(new Admin(2, "Admin3", "Password3", "Николаев Николай Николаевич", "admin3@gmail.com", "+375293333333"));

            SaveLoadControl.Payments.Add(new Payment(0, DateTime.Today, DateTime.Now, (Client)SaveLoadControl.Users[0], 10, true, false));

            SaveLoadControl.BankTransactions.Add(new BankTransaction(0, ((Client)SaveLoadControl.Users[0]).CardNumber,
                                                                     BankTransaction.OurOrganizationBankAccountNumber, 10, SaveLoadControl.CurrentUser));

            SaveLoadControl.Orders.Add(new Order(0, SaveLoadControl.Payments[0], SaveLoadControl.Cars[0], (Client)SaveLoadControl.Users[0], DateTime.Now, 1));
        }

        public static void ClearData()
        {
            SaveLoadControl.Users.Clear();
            SaveLoadControl.Cars.Clear();
            SaveLoadControl.Orders.Clear();
            SaveLoadControl.Payments.Clear();
            SaveLoadControl.BankTransactions.Clear();
            SaveLoadControl.ServiceReports.Clear();
            //SaveLoadControl.CurrentUser = null;
        }
    }
}
