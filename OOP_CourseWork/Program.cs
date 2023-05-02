using OOP_CourseWork.Controls;
using OOP_CourseWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public static void Calculate()
        {
            List<string> names = new List<string>
            {
                "АВС лекция",
                "АВС практика",
                "АВС лаба",
                "История лекция",
                "История практика",
                "МДиСУБД лекция",
                "МДиСУБД лаба",
                "ООП лекция",
                "ООП лаба",
                "КГ лекция",
                "КГ лаба",
                "Физкультура",
                "ЯПВУ лекция",
                "ЯПВУ практика",
                "Нейросети лекция",
                "Нейросети лаба",
                "АиСД лекция",
                "АиСД лаба",
                "АиСД практика"
            };

            List<double> hours = new List<double>
            {
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
            };

            List<DateTime> datesEnd = new List<DateTime>();
            for (int i = 0; i < 19; i++) datesEnd.Add(DateTime.MinValue);

            hours[names.FindIndex(x => x == "АВС лекция"      )] = 34 - 2;
            hours[names.FindIndex(x => x == "АВС практика"    )] = 17 - 0;
            hours[names.FindIndex(x => x == "АВС лаба"        )] = 17 - 0;
            hours[names.FindIndex(x => x == "История лекция"  )] = 17 - 4;
            hours[names.FindIndex(x => x == "История практика")] = 17 - 0;
            hours[names.FindIndex(x => x == "МДиСУБД лекция"  )] = 34 - 4;
            hours[names.FindIndex(x => x == "МДиСУБД лаба"    )] = 34 - 0;
            hours[names.FindIndex(x => x == "ООП лекция"      )] = 51 - 4;
            hours[names.FindIndex(x => x == "ООП лаба"        )] = 34 - 0;
            hours[names.FindIndex(x => x == "КГ лекция"       )] = 17 - 4;
            hours[names.FindIndex(x => x == "КГ лаба"       )] = 25.5 - 0;
            hours[names.FindIndex(x => x == "Физкультура"     )] = 58 - 4;
            hours[names.FindIndex(x => x == "ЯПВУ лекция"     )] = 34 - 4;
            hours[names.FindIndex(x => x == "ЯПВУ практика"   )] = 34 - 0;
            hours[names.FindIndex(x => x == "Нейросети лекция")] = 34 - 4;
            hours[names.FindIndex(x => x == "Нейросети лаба")] = 25.5 - 0;
            hours[names.FindIndex(x => x == "АиСД лекция"   )] = 25.5 - 2;
            hours[names.FindIndex(x => x == "АиСД лаба"       )] = 17 - 0;
            hours[names.FindIndex(x => x == "АиСД практика" )] = 25.5 - 0;

            DateTime startDate = DateTime.Parse("16.02.2023 08:00:00");

            int week = 0;

            List<List<string>> overTheLine = new List<List<string>>
            {
                new List<string>
                {
                    "АиСД лекция",
                    "ООП лекция",
                    "АиСД практика"
                },
                new List<string>
                {
                    "КГ лаба",
                    "КГ лекция",
                    "Физкультура",
                    "АиСД лаба"
                },
                new List<string>
                {
                    "История практика",
                    "ЯПВУ практика",
                    "Нейросети лаба",
                    "ЯПВУ лекция"
                },
                new List<string>
                {
                    "АВС лекция",
                    "Физкультура"
                },
                new List<string>
                {
                    "МДиСУБД лекция",
                    "Нейросети лекция",
                    "МДиСУБД лаба"
                }
            };

            List<List<string>> underTheLine = new List<List<string>>
            {
                new List<string>
                {
                    "АиСД лекция",
                    "ООП лекция",
                    "АиСД практика"
                },
                new List<string>
                {
                    "АВС практика",
                    "АВС лаба",
                    "ООП лекция",
                    "Физкультура",
                    "КГ лаба"
                },
                new List<string>
                {
                    "История лекция",
                    "ЯПВУ практика",
                    "Нейросети лаба",
                    "ЯПВУ лекция"
                },
                new List<string>
                {
                    "ООП лаба",
                    "ООП лаба",
                    "АВС лекция",
                    "Физкультура"
                },
                new List<string>
                {
                    "МДиСУБД лекция",
                    "Нейросети лекция",
                    "МДиСУБД лаба"
                }
            };

            List<DateTime> holidays = new List<DateTime>
            {
                DateTime.Parse("08.03.2023 08:00:00"),
                DateTime.Parse("25.04.2023 08:00:00"),
                DateTime.Parse("01.05.2023 08:00:00"),
                DateTime.Parse("09.05.2023 08:00:00")
            };

            while (true)
            {
                bool flag = true;
                for (int i = 0; i < 19; i++)
                {
                    if (hours[i] > 1e-7) flag = false;
                }
                if (flag) break;

                if (startDate.DayOfWeek == DayOfWeek.Saturday || startDate.DayOfWeek == DayOfWeek.Sunday ||
                    holidays.Contains(startDate))
                {
                    startDate = startDate.AddDays(1);
                    continue;
                }

                if (startDate.DayOfWeek == DayOfWeek.Monday) ++week;

                int day_of_week = 0;
                switch (startDate.DayOfWeek)
                {
                    case DayOfWeek.Monday: day_of_week = 0; break;
                    case DayOfWeek.Tuesday: day_of_week = 1; break;
                    case DayOfWeek.Wednesday: day_of_week = 2; break;
                    case DayOfWeek.Thursday: day_of_week = 3; break;
                    case DayOfWeek.Friday: day_of_week = 4; break;
                }

                List<List<string>> schedule = null;
                if (week % 2 == 0)
                {
                    //Над чертой
                    schedule = overTheLine;
                }
                else
                {
                    //Под чертой
                    schedule = underTheLine;
                }

                foreach (var subject in schedule[day_of_week])
                {
                    double hours_to_decrease = 2;
                    switch (subject)
                    {
                        case "КГ лаба": hours_to_decrease = 1.5; break;
                        case "Нейросети лаба": hours_to_decrease = 1.5; break;
                        case "АиСД лекция": hours_to_decrease = 1.5; break;
                        case "АиСД практика": hours_to_decrease = 1.5; break;
                        case "ООП лекция": hours_to_decrease = 2; break;
                    }
                    hours_to_decrease = 2;

                    int index = names.FindIndex(x => x == subject);

                    hours[index] -= hours_to_decrease;
                    if (hours[index] <= 1e-7 && (datesEnd[index] - DateTime.MinValue).TotalSeconds < 10) datesEnd[index] = startDate;
                }

                startDate = startDate.AddDays(1);
                //Console.WriteLine(startDate);
            }

            string result = "";
            for (int i = 0; i < 19; i++)
            {
                result += names[i] + " => " + datesEnd[i] + Environment.NewLine;
            }

            MessageBox.Show(result);
            Environment.Exit(0);
        }
    }
}
