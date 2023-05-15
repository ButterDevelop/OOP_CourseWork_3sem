using OOP_CourseWork.Controls;
using System;
using System.Windows.Forms;

namespace OOP_CourseWork
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            UtilsControl.StartNeccesaryForm();
        }
    }
}
