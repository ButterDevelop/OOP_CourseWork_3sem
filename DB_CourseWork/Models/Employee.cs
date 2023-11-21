using Newtonsoft.Json;
using DB_CourseWork.Controls;
using System;

namespace DB_CourseWork.Models
{
    public class Employee : User
    {
        public static double SalaryPerDay = 100;

        private int      _ordersProccessed;
        private int      _daysWorked;
        private DateTime _dateHired;
        private DateTime _dateFired;
        private DateTime _dateLastSalaryPayed;
        private string   _bankAccountNumber;
        private double   _totalSalaryPayed;
        private bool     _isWorkingNow;

        public Employee() : base() 
        {
            _ordersProccessed = _daysWorked = 0;
            _dateHired = DateTime.UtcNow;
            _dateFired = new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            _bankAccountNumber = string.Empty;
            _totalSalaryPayed = 0;
            _isWorkingNow = true;
        }

        public Employee(User user) : base(user.UserName, user.Salt, user.HashedPassword, user.FullName, user.Email,
                                          user.Phone, RolesContainer.Employee, user.IsAccountSetupCompleted, user.AccountDeactivated)
        {
            _ordersProccessed = _daysWorked = 0;
            _dateHired = DateTime.UtcNow;
            _dateFired = new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            _bankAccountNumber = string.Empty;
            _totalSalaryPayed = 0;
            _isWorkingNow = true;
        }

        public Employee(string username, string password, string fullname, string email, string phone)
            : base(username, password, fullname, email, phone, RolesContainer.Employee)
        {
            _ordersProccessed = _daysWorked = 0;
            _dateHired = DateTime.UtcNow;
            _dateFired = new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            _bankAccountNumber = string.Empty;
            _totalSalaryPayed = 0;
            _isWorkingNow = true;
        }

        public Employee(string username, string salt, string hashedPassword, string fullname, string email, string phone, bool isAccountSetupCompleted, bool accountDeactivated,
                        int ordersProccessed, int daysWorked, DateTime dateHired, DateTime dateFired, string bankAccountNumber, double totalSalaryPayed, bool isWorkingNow) 
            : base(username, salt, hashedPassword, fullname, email, phone, RolesContainer.Employee, isAccountSetupCompleted, accountDeactivated)
        {
            _ordersProccessed = ordersProccessed;
            _daysWorked = daysWorked;
            _dateHired = dateHired;
            _dateFired = dateFired;
            _bankAccountNumber = bankAccountNumber;
            _totalSalaryPayed = totalSalaryPayed;
            _isWorkingNow = isWorkingNow;
        }

        public int OrderProccessed
        {
            get
            {
                return _ordersProccessed;
            }
            set
            {
                _ordersProccessed = value;
            }
        }

        public int DaysWorked
        {
            get
            {
                return _daysWorked;
            }
            set
            {
                _daysWorked = value;
            }
        }

        public DateTime DateHired
        {
            get
            {
                return _dateHired;
            }
            set
            {
                _dateHired = value;
            }
        }

        public DateTime DateFired
        {
            get
            {
                return _dateFired;
            }
            set
            {
                _dateFired = value;
            }
        }

        public DateTime DateLastSalaryPayed
        {
            get
            {
                return _dateLastSalaryPayed;
            }
            set
            {
                _dateLastSalaryPayed = value;
            }
        }

        public string BankAccountNumber
        {
            get
            {
                return _bankAccountNumber;
            }
            set
            {
                _bankAccountNumber = value;
            }
        }

        public double TotalSalaryPayed
        {
            get
            {
                return _totalSalaryPayed;
            }
            set
            {
                _totalSalaryPayed = value;
            }
        }

        public bool IsWorkingNow
        {
            get
            {
                return _isWorkingNow;
            }
            set
            {
                _isWorkingNow = value;
            }
        }

        [JsonIgnore]
        public double Salary
        {
            get
            {
                return SalaryPerDay * _daysWorked;
            }
        }


        public override string ToString()
        {
            return base.ToString() + ";" + _ordersProccessed + ";" + _daysWorked + ";" + _dateHired + ";" + _dateFired + ";" + _isWorkingNow;
        }

        public bool FireEmployee()
        {
            if (_isWorkingNow)
            {
                if (!PaySalary()) return false;
                _dateFired = DateTime.Now;
                _isWorkingNow = false;
                base.DeactivateAccount();
                return true;
            }
            return false;
        }

        public bool HireEmployee()
        {
            if (!_isWorkingNow)
            {
                _dateHired = DateTime.Now;
                _isWorkingNow = true;
                base.ActivateAccount();
                return true;
            }
            return false;
        }

        public bool PaySalary()
        {
            BankTransaction bankTransaction = new BankTransaction(BankTransaction.OurOrganizationBankAccountNumber, _bankAccountNumber, Salary, null);
            DatabaseContext.DbContext.BankTransactions.Add(bankTransaction);

            var result = bankTransaction.Debit(BankTransaction.OurOrganizationSecretCode);
            DatabaseContext.DbContext.BankTransactions.Update(bankTransaction);
            if (!result) return false;

            _totalSalaryPayed += Salary;
            _daysWorked = 0;
            _ordersProccessed = 0;
            _dateLastSalaryPayed = DateTime.Now;

            return true;
        }
    }
}
