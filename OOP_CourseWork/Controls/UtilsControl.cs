using OOP_CourseWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_CourseWork.Controls
{
    internal class UtilsControl
    {
        public static void StartNeccesaryForm()
        {
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
                //Application.Run(new AdminForm());
            }
            else
            {
                Environment.Exit(0);
            }
        }


        public static void LoadDB_Click()
        {
            SaveLoadControl.LoadJSON();
        }

        public static void SaveDB_Click()
        {
            SaveLoadControl.SaveJSON();
        }

        public static void CreateSomeData()
        {
            SaveLoadControl.CarBrands.Add(new CarBrand(0, "Мицубиси", "Японская компания"));
            SaveLoadControl.CarBrands.Add(new CarBrand(1, "Вольксваген", "Немецкая компания"));
            SaveLoadControl.CarBrands.Add(new CarBrand(2, "Джили", "Китайская компания"));
            SaveLoadControl.CarBrands.Add(new CarBrand(3, "Форд", "Американская компания"));

            SaveLoadControl.Cars.Add(new Car(0, SaveLoadControl.CarBrands[0], "Аутландер", 10,
                                     new DateTime(1980, 10, 11), new DateTime(2023, 01, 01), new DateTime(2023, 02, 01)));
            SaveLoadControl.Cars.Add(new Car(1, SaveLoadControl.CarBrands[1], "Поло", 20,
                                     new DateTime(1990, 09, 03), new DateTime(2023, 01, 01), new DateTime(2023, 02, 02)));
            SaveLoadControl.Cars.Add(new Car(2, SaveLoadControl.CarBrands[2], "Кулрэй", 30,
                                     new DateTime(2000, 08, 04), new DateTime(2023, 01, 01), new DateTime(2023, 02, 03)));

            SaveLoadControl.ServiceReports.Add(new ServiceReport(0, "Плановая проверка", 3, SaveLoadControl.Cars[0]));
            SaveLoadControl.ServiceReports.Add(new ServiceReport(1, "Плановая проверка", 2, SaveLoadControl.Cars[1]));
            SaveLoadControl.ServiceReports.Add(new ServiceReport(2, "Плановая проверка", 1, SaveLoadControl.Cars[2]));

            SaveLoadControl.Users.Add(new Client(0, "User1", "Password1", "Иванов Иван Иванович", "user1@gmail.com", "+375291111111",
                                                 "AA1746354", "HB31865832", "4155 0253 3531 4351"));
            SaveLoadControl.Users.Add(new Employee(1, "Employee2", "Password2", "Петров Пётр Петрович", "employee2@gmail.com", "+375292222222"));
            SaveLoadControl.Users.Add(new Admin(2, "Admin3", "Password3", "Николаев Николай Николаевич", "admin3@gmail.com", "+375293333333"));

            SaveLoadControl.Payments.Add(new Payment(0, DateTime.Today, DateTime.Now, (Client)SaveLoadControl.Users[0], 10, true, false));

            SaveLoadControl.BankTransactions.Add(new BankTransaction(0, ((Client)SaveLoadControl.Users[0]).CardNumber,
                                                                     BankTransaction.OurOrganizationBankAccountNumber, 10));

            SaveLoadControl.Orders.Add(new Order(0, 0, SaveLoadControl.Cars[0], (Client)SaveLoadControl.Users[0], DateTime.Now, 1));
        }

        public static void CheckData()
        {
            try
            {
                MessageBox.Show(((Client)SaveLoadControl.Users[0]).ToString());
                MessageBox.Show(((Employee)SaveLoadControl.Users[1]).ToString());
                MessageBox.Show(((Admin)SaveLoadControl.Users[2]).ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("no content: " + ex.ToString());
            }
        }

        public static void ClearData()
        {
            SaveLoadControl.Users.Clear();
            SaveLoadControl.CarBrands.Clear();
            SaveLoadControl.Cars.Clear();
            SaveLoadControl.Orders.Clear();
            SaveLoadControl.Payments.Clear();
            SaveLoadControl.BankTransactions.Clear();
            SaveLoadControl.ServiceReports.Clear();
        }
    }
}
