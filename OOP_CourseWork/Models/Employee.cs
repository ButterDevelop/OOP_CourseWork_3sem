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
        private double   _salaryPerHour;
        private bool     _isWorkingNow;

        public Employee() : base() 
        {
            _ordersProccessed = _hoursWorked = 0;
            _dateHired = DateTime.Now;
            _dateFired = DateTime.MinValue;
            _bankAccountNumber = string.Empty;
            _salaryPerHour = 0;
            _isWorkingNow = true;
        }

        public Employee(int id, string username, string password, string fullname, string email, string phone)
            : base(id, username, password, fullname, email, phone, RolesContainer.Employee)
        {
            _ordersProccessed = _hoursWorked = 0;
            _dateHired = DateTime.Now;
            _dateFired = DateTime.MinValue;
            _bankAccountNumber = string.Empty;
            _salaryPerHour = 0;
            _isWorkingNow = true;
        }

        public Employee(int id, string username, string salt, string hashedPassword, string fullname, string email, string phone, bool accountDeactivated,
                        int ordersProccessed, int hoursWorked, DateTime dateHired, DateTime dateFired, string bankAccountNumber, double salaryPerHour, bool isWorkingNow) 
            : base(id, username, salt, hashedPassword, fullname, email, phone, RolesContainer.Employee, accountDeactivated)
        {
            _ordersProccessed = ordersProccessed;
            _hoursWorked = hoursWorked;
            _dateHired = dateHired;
            _dateFired = dateFired;
            _bankAccountNumber = bankAccountNumber;
            _salaryPerHour = salaryPerHour;
            _isWorkingNow = isWorkingNow;
        }

        public int OrderProccessed
        {
            get
            {
                return _ordersProccessed;
            }
        }

        public int HoursWorked
        {
            get
            {
                return _hoursWorked;
            }
        }

        public DateTime DateHired
        {
            get
            {
                return _dateHired;
            }
        }

        public DateTime DateFired
        {
            get
            {
                return _dateFired;
            }
        }

        public DateTime DateLastSalaryPayed
        {
            get
            {
                return _dateLastSalaryPayed;
            }
        }

        public string BankAccountNumber
        {
            get
            {
                return _bankAccountNumber;
            }
        }

        public bool IsWorkingNow
        {
            get
            {
                return _isWorkingNow;
            }
        }

        public double SalaryPerHour
        {
            get
            {
                return _salaryPerHour;
            }
        }

        public double Salary
        {
            get
            {
                return (_salaryPerHour * _hoursWorked) + _ordersProccessed;
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
                                                                  _bankAccountNumber, Salary);
            SaveLoadControl.BankTransactions.Add(bankTransaction);

            if (!bankTransaction.Debit(BankTransaction.OurOrganizationSecretCode)) return false;

            _hoursWorked = 0;
            _ordersProccessed = 0;
            _dateLastSalaryPayed = DateTime.Now;

            return true;
        }
    }
}
