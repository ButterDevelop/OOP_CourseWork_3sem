using Newtonsoft.Json;
using OOP_CourseWork.Controls;
using System;

namespace OOP_CourseWork.Models
{
    internal class ServiceReport
    {
        private int _id;
        private string _description;
        private DateTime _startedDate;
        private DateTime _finishedDate;
        private double _additionalCost;
        private bool _isStarted;
        private bool _isFinished;
        private int _plannedCompletionDays;
        private Employee _worker;
        private Car _servicedCar;
        private string _employeeReport;

        public ServiceReport() 
        {
            _id = 0;
            _description = string.Empty;
            _startedDate = DateTime.Now;
            _finishedDate = DateTime.MinValue;
            _additionalCost = 0;
            _isStarted = false;
            _isFinished = false;
            _plannedCompletionDays = 0;
            _worker = null;
            _servicedCar = new Car();
        }

        public ServiceReport(int id, string description, Car servicedCar)
        {
            _id = id;
            _description = description;
            _startedDate = DateTime.Now;
            _finishedDate = DateTime.MinValue;
            _additionalCost = 0;
            _isStarted = false;
            _isFinished = false;
            _plannedCompletionDays = 0;
            _worker = null;
            _servicedCar = servicedCar;
        }

        public ServiceReport(int id, string description, DateTime startedDate, DateTime finishedDate, double additionalCost, bool isStarted, bool isFinished, int plannedCompletionDays, Employee worker, Car servicedCar)
        {
            _id = id;
            _description = description;
            _startedDate = startedDate;
            _finishedDate = finishedDate;
            _additionalCost = additionalCost;
            _isStarted = isStarted;
            _isFinished = isFinished;
            _plannedCompletionDays = plannedCompletionDays;
            _worker = worker;
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
                if (_worker is null) return 0;
                return (_plannedCompletionDays * Employee.SalaryPerDay) + _additionalCost;
            }
        }

        public double AdditionalCost
        {
            get
            {
                return _additionalCost;
            }
            set
            {
                _additionalCost = value;
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

        public bool IsStarted
        {
            get
            {
                return _isStarted;
            }
            set
            {
                _isStarted = value;
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

        public Employee Worker
        {
            get
            {
                return _worker;
            }
            set
            {
                _worker = value;
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

        public string EmployeeReport
        {
            get
            {
                return _employeeReport;
            }
            set
            {
                _employeeReport = value;
            }
        }


        public void FinishService()
        {
            _finishedDate = DateTime.Now;
            _isFinished = true;

            BankTransaction bankTransaction = new BankTransaction(SaveLoadControl.BankTransactions.Count, 
                                                                  BankTransaction.OurOrganizationBankAccountNumber, 
                                                                  BankTransaction.ServiceCentreBankAccountNumber, 
                                                                  AdditionalCost,
                                                                  null);
            SaveLoadControl.BankTransactions.Add(bankTransaction);

            ServicedCar.LastServiceTime = DateTime.Now;
            Worker.DaysWorked += _plannedCompletionDays;
            Worker.OrderProccessed += 1;

            Worker.PaySalary();
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
