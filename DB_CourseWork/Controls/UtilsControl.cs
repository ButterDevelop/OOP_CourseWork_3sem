using DB_CourseWork.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DB_CourseWork.Controls
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
            Application.Run(new ChooseDBForm());

            if (DatabaseContext.ChosenDbType == DbType.None)
            {
                Environment.Exit(0);
            }

            DatabaseContext dbContext = DatabaseContext.GenerateDBContext(DatabaseContext.ChosenDbType);
            if (dbContext == null)
            {
                MessageBox.Show("Не удалось выбрать базу данных!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            DatabaseContext.DbContext = dbContext;

            //MigrateOldData.LoadJSON();
            //MigrateOldData.Migrate();
            //Environment.Exit(0);

            Application.Run(new LoginForm(dbContext));

            if (dbContext.CurrentUser is Client)
            {
                Application.Run(new ClientForm(dbContext));
            }
            else
            if (dbContext.CurrentUser is Employee)
            {
                Application.Run(new EmployeeForm(dbContext));
            }
            else
            if (dbContext.CurrentUser is Admin)
            {
                Application.Run(new AdminForm(dbContext));
            }
            else
            {
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

        public static Dictionary<int, Image> LoadCarsOrderImages()
        {
            Dictionary<int, Image> dict = new Dictionary<int, Image>();
            foreach (var car in DatabaseContext.DbContext.Cars.GetAll())
            {
                Image image;
                try
                {
                    image = LoadImageFromFileSafely($"images\\{DatabaseContext.DatabaseTypeName}\\car_{car.Id}.png");
                }
                catch
                {
                    image = (Image)Properties.Resources.TheImageHaveDisappeared.Clone();
                }
                dict.Add(car.Id, image);
            }

            return dict;
        }

        public static Image LoadImageFromFileSafely(string fileName)
        {
            Image image;
            using (var bmpTemp = new Bitmap(fileName))
            {
                image = new Bitmap(bmpTemp);
            }

            return image;
        }

    }
}
