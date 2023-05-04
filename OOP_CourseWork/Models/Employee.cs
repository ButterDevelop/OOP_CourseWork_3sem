using Newtonsoft.Json;
using OOP_CourseWork.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_CourseWork.Models
{
    internal class Employee : User
    {
        private int      _ordersProccessed;
        private int      _hoursWorked;
        private DateTime _dateHired;
        private DateTime _dateFired;
        private DateTime _dateLastSalaryPayed;
        private string   _bankAccountNumber;
        private double   _salaryPerDay;
        private bool     _isWorkingNow;

        public Employee() : base() 
        {
            _ordersProccessed = _hoursWorked = 0;
            _dateHired = DateTime.Now;
            _dateFired = DateTime.MinValue;
            _bankAccountNumber = string.Empty;
            _salaryPerDay = 0;
            _isWorkingNow = true;
        }

        public Employee(User user) : base(user.Id, user.UserName, user.Salt, user.HashedPassword, user.FullName, user.Email,
                                          user.Phone, RolesContainer.Employee, user.IsAccountSetupCompleted, user.AccountDeactivated)
        {
            _ordersProccessed = _hoursWorked = 0;
            _dateHired = DateTime.Now;
            _dateFired = DateTime.MinValue;
            _bankAccountNumber = string.Empty;
            _salaryPerDay = 0;
            _isWorkingNow = true;
        }

        public Employee(int id, string username, string password, string fullname, string email, string phone)
            : base(id, username, password, fullname, email, phone, RolesContainer.Employee)
        {
            _ordersProccessed = _hoursWorked = 0;
            _dateHired = DateTime.Now;
            _dateFired = DateTime.MinValue;
            _bankAccountNumber = string.Empty;
            _salaryPerDay = 0;
            _isWorkingNow = true;
        }

        public Employee(int id, string username, string salt, string hashedPassword, string fullname, string email, string phone, bool isAccountSetupCompleted, bool accountDeactivated,
                        int ordersProccessed, int hoursWorked, DateTime dateHired, DateTime dateFired, string bankAccountNumber, double salaryPerHour, bool isWorkingNow) 
            : base(id, username, salt, hashedPassword, fullname, email, phone, RolesContainer.Employee, isAccountSetupCompleted, accountDeactivated)
        {
            _ordersProccessed = ordersProccessed;
            _hoursWorked = hoursWorked;
            _dateHired = dateHired;
            _dateFired = dateFired;
            _bankAccountNumber = bankAccountNumber;
            _salaryPerDay = salaryPerHour;
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

        public int HoursWorked
        {
            get
            {
                return _hoursWorked;
            }
            set
            {
                _hoursWorked = value;
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

        public double SalaryPerDay
        {
            get
            {
                return _salaryPerDay;
            }
            set
            {
                _salaryPerDay = value;
            }
        }

        [JsonIgnore]
        public double Salary
        {
            get
            {
                return (_salaryPerDay * _hoursWorked) + _ordersProccessed;
            }
        }


        public override string ToString()
        {
            return base.ToString() + ";" + _ordersProccessed + ";" + _hoursWorked + ";" + _dateHired + ";" + _dateFired + ";" + _isWorkingNow;
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

        public bool PaySalary()
        {
            BankTransaction bankTransaction = new BankTransaction(SaveLoadControl.BankTransactions.Count, BankTransaction.OurOrganizationBankAccountNumber,
                                                                  _bankAccountNumber, Salary, null);
            SaveLoadControl.BankTransactions.Add(bankTransaction);

            if (!bankTransaction.Debit(BankTransaction.OurOrganizationSecretCode)) return false;

            _hoursWorked = 0;
            _ordersProccessed = 0;
            _dateLastSalaryPayed = DateTime.Now;

            return true;
        }
    }
}
