using Newtonsoft.Json;
using DB_CourseWork.Controls;
using System;

namespace DB_CourseWork.Models
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
        private int _workerId;
        private int _servicedCarId;
        private string _employeeReport;

        public ServiceReport() 
        {
            _id = -1;
            _description = string.Empty;
            _startedDate = DateTime.Now;
            _finishedDate = DateTime.MinValue;
            _additionalCost = 0;
            _isStarted = false;
            _isFinished = false;
            _plannedCompletionDays = 0;
            _workerId = -1;
            _servicedCarId = -1;
        }

        public ServiceReport(string description, Car servicedCar)
        {
            _id = -1;
            _description = description;
            _startedDate = DateTime.Now;
            _finishedDate = DateTime.MinValue;
            _additionalCost = 0;
            _isStarted = false;
            _isFinished = false;
            _plannedCompletionDays = 0;
            _workerId = -1;
            _servicedCarId = servicedCar.Id;
        }

        public ServiceReport(string description, DateTime startedDate, DateTime finishedDate, double additionalCost, bool isStarted, bool isFinished, int plannedCompletionDays, Employee worker, Car servicedCar)
        {
            _id = -1;
            _description = description;
            _startedDate = startedDate;
            _finishedDate = finishedDate;
            _additionalCost = additionalCost;
            _isStarted = isStarted;
            _isFinished = isFinished;
            _plannedCompletionDays = plannedCompletionDays;
            _workerId = worker.Id;
            _servicedCarId = servicedCar.Id;
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
                if (_workerId == -1) return 0;
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

        public int WorkerId
        {
            get
            {
                return _workerId;
            }
            set
            {
                _workerId = value;
            }
        }

        public int ServicedCarId
        {
            get
            {
                return _servicedCarId;
            }
            set
            {
                _servicedCarId = value;
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

            BankTransaction bankTransaction = new BankTransaction(BankTransaction.OurOrganizationBankAccountNumber, 
                                                                  BankTransaction.ServiceCentreBankAccountNumber, 
                                                                  AdditionalCost,
                                                                  null);
            DatabaseContext.DbContext.BankTransactions.Add(bankTransaction);

            var servicedCar = DatabaseContext.DbContext.Cars.Get(ServicedCarId);
            servicedCar.LastServiceTime = DateTime.Now;
            DatabaseContext.DbContext.Cars.Update(servicedCar);

            var worker = DatabaseContext.DbContext.Employees.Get(WorkerId);

            worker.DaysWorked += _plannedCompletionDays;
            worker.OrderProccessed += 1;

            worker.PaySalary();

            DatabaseContext.DbContext.Employees.Update(worker);
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
