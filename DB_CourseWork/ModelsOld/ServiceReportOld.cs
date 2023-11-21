using Newtonsoft.Json;
using System;

namespace OOP_CourseWork.Models
{
    public class ServiceReportOld
    {
        private int _id;
        private string _description;
        private DateTime _startedDate;
        private DateTime _finishedDate;
        private double _additionalCost;
        private bool _isStarted;
        private bool _isFinished;
        private int _plannedCompletionDays;
        private EmployeeOld _worker;
        private CarOld _servicedCar;
        private string _employeeReport;

        public ServiceReportOld()
        {
            _id = 0;
            _description = string.Empty;
            _startedDate = DateTime.UtcNow;
            _finishedDate = new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            _additionalCost = 0;
            _isStarted = false;
            _isFinished = false;
            _plannedCompletionDays = 0;
            _worker = null;
            _servicedCar = new CarOld();
            _employeeReport = string.Empty;
        }

        public ServiceReportOld(int id, string description, CarOld servicedCar)
        {
            _id = id;
            _description = description;
            _startedDate = DateTime.UtcNow;
            _finishedDate = new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            _additionalCost = 0;
            _isStarted = false;
            _isFinished = false;
            _plannedCompletionDays = 0;
            _worker = null;
            _servicedCar = servicedCar;
            _employeeReport = string.Empty;
        }

        public ServiceReportOld(int id, string description, DateTime startedDate, DateTime finishedDate, double additionalCost, bool isStarted, bool isFinished, int plannedCompletionDays, EmployeeOld worker, CarOld servicedCar)
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
            _employeeReport = string.Empty;
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
                return (_plannedCompletionDays * EmployeeOld.SalaryPerDay) + _additionalCost;
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

        public EmployeeOld Worker
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

        public CarOld ServicedCar
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

    }
}
