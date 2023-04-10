using Newtonsoft.Json;
using OOP_CourseWork.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_CourseWork.Models
{
    internal class ServiceReport
    {
        public static readonly double CostPerOneDay = 100;

        private int _id;
        private string _description;
        private DateTime _startedDate;
        private DateTime _finishedDate;
        private double _additionalCost;
        private bool _isFinished;
        private int _plannedCompletionDays;
        private Car _servicedCar;

        public ServiceReport() 
        {
            _id = 0;
            _description = string.Empty;
            _startedDate = DateTime.Now;
            _finishedDate = DateTime.MinValue;
            _additionalCost = 0;
            _isFinished = false;
            _plannedCompletionDays = 0;
            _servicedCar = new Car();
        }

        public ServiceReport(int id, string description, int plannedCompletionDays, Car servicedCar)
        {
            _id = id;
            _description = description;
            _startedDate = DateTime.Now;
            _finishedDate = DateTime.MinValue;
            _additionalCost = 0;
            _isFinished = false;
            _plannedCompletionDays = plannedCompletionDays;
            _servicedCar = servicedCar;
        }

        public ServiceReport(int id, string description, DateTime startedDate, DateTime finishedDate, double additionalCost, bool isFinished, int plannedCompletionDays, Car servicedCar)
        {
            _id = id;
            _description = description;
            _startedDate = startedDate;
            _finishedDate = finishedDate;
            _additionalCost = additionalCost;
            _isFinished = isFinished;
            _plannedCompletionDays = plannedCompletionDays;
            _servicedCar = servicedCar;
        }

        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }

        [JsonIgnore]
        public double Cost
        {
            get
            {
                return (_plannedCompletionDays * CostPerOneDay) + _additionalCost;
            }
        }

        public DateTime StartedDate
        {
            get
            {
                return _startedDate;
            }
            set
            {
                _startedDate = value;
            }
        }

        public DateTime FinishedDate
        {
            get
            {
                return _finishedDate;
            }
            set
            {
                _finishedDate = value;
            }
        }

        public bool IsFinished
        {
            get
            {
                return _isFinished;
            }
            set
            {
                _isFinished = value;
            }
        }

        public int PlannedCompletionDays
        {
            get
            {
                return _plannedCompletionDays;
            }
            set
            {
                _plannedCompletionDays = value;
            }
        }

        public Car ServicedCar
        {
            get
            {
                return _servicedCar;
            }
            set
            {
                _servicedCar = value;
            }
        }


        public void FinishService()
        {
            _finishedDate = DateTime.Now;
            _isFinished = true;

            BankTransaction bankTransaction = new BankTransaction(SaveLoadControl.BankTransactions.Count, 
                                                                  BankTransaction.OurOrganizationBankAccountNumber, 
                                                                  BankTransaction.ServiceCentreBankAccountNumber, 
                                                                  Cost,
                                                                  null);
            SaveLoadControl.BankTransactions.Add(bankTransaction);
        }

        public bool IncreaseAdditionalCost(double amount)
        {
            if ((long)_additionalCost + amount > int.MaxValue) return false;
            _additionalCost += amount;
            return true;
        }
        public bool DecreaseAdditionalCost(double amount)
        {
            if (_additionalCost < amount) return false;
            _additionalCost -= amount;
            return true;
        }
    }
}
